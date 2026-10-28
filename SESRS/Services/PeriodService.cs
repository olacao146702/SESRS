using System.Data;
using System.Text.RegularExpressions;
using MySqlConnector;
using SESRS.Data;
using SESRS.Helpers;
using SESRS.Models;

namespace SESRS.Services;

public class PeriodService
{
    private readonly DatabaseConnection _database = new();
    private readonly AuditService _audit = new();

    public DataTable GetAll()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT period_id, school_year, semester, enrollment_start, enrollment_end,
                   min_units, max_units,
                   CASE WHEN is_current = 1 THEN 'Current' ELSE '' END AS current_term
            FROM academic_periods
            ORDER BY school_year DESC, FIELD(semester, '1st Semester', '2nd Semester', 'Summer') DESC;
            """);
    }

    /// <summary>The term students are currently enrolling for, or null if none is set.</summary>
    public AcademicPeriod? GetCurrent()
    {
        Session.RequireLogin();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable table = Sql.Table(connection, null,
            "SELECT * FROM academic_periods WHERE is_current = 1 LIMIT 1;");

        return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
    }

    public AcademicPeriod? GetByTerm(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        string schoolYear,
        string semester)
    {
        DataTable table = Sql.Table(connection, transaction,
            "SELECT * FROM academic_periods WHERE school_year = @sy AND semester = @sem LIMIT 1;",
            ("@sy", schoolYear), ("@sem", semester));

        return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
    }

    public AcademicPeriod? Get(int periodId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable table = Sql.Table(connection, null,
            "SELECT * FROM academic_periods WHERE period_id = @id;", ("@id", periodId));

        return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
    }

    /// <summary>Creates (PeriodId = 0) or updates a period. Returns its id.</summary>
    public int Save(AcademicPeriod period)
    {
        Session.RequireAdmin();
        Validate(period);

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            int duplicate = Sql.Int(connection, transaction, """
                SELECT COUNT(*) FROM academic_periods
                WHERE school_year = @sy AND semester = @sem AND period_id <> @id;
                """,
                ("@sy", period.SchoolYear), ("@sem", period.Semester), ("@id", period.PeriodId));

            if (duplicate > 0)
            {
                throw new BusinessRuleException(
                    $"{period.SchoolYear}, {period.Semester} already exists.");
            }

            if (period.IsCurrent)
            {
                Sql.Exec(connection, transaction, "UPDATE academic_periods SET is_current = 0;");
            }

            int id = period.PeriodId;

            if (id == 0)
            {
                id = (int)Sql.Insert(connection, transaction, """
                    INSERT INTO academic_periods
                        (school_year, semester, enrollment_start, enrollment_end, min_units, max_units, is_current)
                    VALUES (@sy, @sem, @start, @end, @min, @max, @cur);
                    """,
                    ("@sy", period.SchoolYear), ("@sem", period.Semester),
                    ("@start", period.EnrollmentStart.Date), ("@end", period.EnrollmentEnd.Date),
                    ("@min", period.MinUnits), ("@max", period.MaxUnits),
                    ("@cur", period.IsCurrent ? 1 : 0));
            }
            else
            {
                int rows = Sql.Exec(connection, transaction, """
                    UPDATE academic_periods
                    SET school_year = @sy, semester = @sem, enrollment_start = @start,
                        enrollment_end = @end, min_units = @min, max_units = @max,
                        is_current = @cur
                    WHERE period_id = @id;
                    """,
                    ("@sy", period.SchoolYear), ("@sem", period.Semester),
                    ("@start", period.EnrollmentStart.Date), ("@end", period.EnrollmentEnd.Date),
                    ("@min", period.MinUnits), ("@max", period.MaxUnits),
                    ("@cur", period.IsCurrent ? 1 : 0), ("@id", id));

                if (rows == 0)
                {
                    throw new BusinessRuleException("That academic period no longer exists.");
                }
            }

            _audit.Log(connection, transaction,
                period.PeriodId == 0 ? "PERIOD_CREATED" : "PERIOD_UPDATED",
                "academic_period", id.ToString(), period.Label);

            transaction.Commit();
            return id;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void SetCurrent(int periodId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            if (Sql.Int(connection, transaction,
                    "SELECT COUNT(*) FROM academic_periods WHERE period_id = @id;",
                    ("@id", periodId)) == 0)
            {
                throw new BusinessRuleException("That academic period no longer exists.");
            }

            Sql.Exec(connection, transaction, "UPDATE academic_periods SET is_current = 0;");
            Sql.Exec(connection, transaction,
                "UPDATE academic_periods SET is_current = 1 WHERE period_id = @id;",
                ("@id", periodId));

            _audit.Log(connection, transaction, "PERIOD_SET_CURRENT", "academic_period", periodId.ToString());

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void Delete(int periodId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        AcademicPeriod? period = null;
        DataTable table = Sql.Table(connection, null,
            "SELECT * FROM academic_periods WHERE period_id = @id;", ("@id", periodId));

        if (table.Rows.Count == 0)
        {
            return;
        }

        period = Map(table.Rows[0]);

        int used = Sql.Int(connection, null, """
            SELECT (SELECT COUNT(*) FROM enrollments WHERE school_year = @sy AND semester = @sem)
                 + (SELECT COUNT(*) FROM sections WHERE school_year = @sy AND semester = @sem);
            """,
            ("@sy", period.SchoolYear), ("@sem", period.Semester));

        if (used > 0)
        {
            throw new BusinessRuleException(
                "This period already has sections or enrollments and cannot be deleted.");
        }

        Sql.Exec(connection, null,
            "DELETE FROM academic_periods WHERE period_id = @id;", ("@id", periodId));

        _audit.Log(connection, null, "PERIOD_DELETED", "academic_period", periodId.ToString(), period.Label);
    }

    private static void Validate(AcademicPeriod p)
    {
        Match m = Regex.Match(p.SchoolYear ?? "", @"^(\d{4})-(\d{4})$");

        if (!m.Success || int.Parse(m.Groups[2].Value) != int.Parse(m.Groups[1].Value) + 1)
        {
            throw new BusinessRuleException(
                "School year must look like 2026-2027 (two consecutive years).");
        }

        if (!Academic.Semesters.Contains(p.Semester))
        {
            throw new BusinessRuleException("Please choose a valid semester.");
        }

        if (p.EnrollmentEnd.Date < p.EnrollmentStart.Date)
        {
            throw new BusinessRuleException("The enrollment end date cannot be before the start date.");
        }

        if (p.MinUnits < 0 || p.MaxUnits < 1 || p.MinUnits > p.MaxUnits || p.MaxUnits > 40)
        {
            throw new BusinessRuleException(
                "Unit limits are invalid: minimum must not exceed maximum, and maximum must be between 1 and 40.");
        }
    }

    private static AcademicPeriod Map(DataRow row)
    {
        return new AcademicPeriod(
            Convert.ToInt32(row["period_id"]),
            Convert.ToString(row["school_year"]) ?? "",
            Convert.ToString(row["semester"]) ?? "",
            Convert.ToDateTime(row["enrollment_start"]),
            Convert.ToDateTime(row["enrollment_end"]),
            Convert.ToInt32(row["min_units"]),
            Convert.ToInt32(row["max_units"]),
            Convert.ToInt32(row["is_current"]) == 1);
    }
}
