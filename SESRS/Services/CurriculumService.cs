using System.Data;
using SESRS.Data;
using SESRS.Helpers;

namespace SESRS.Services;

/// <summary>Which subjects belong to each program, in which year/semester, and their prerequisites.</summary>
public class CurriculumService
{
    private readonly DatabaseConnection _database = new();
    private readonly AuditService _audit = new();

    public DataTable GetCurriculum(int programId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT cu.curriculum_id, cu.year_level, cu.semester,
                   s.subject_code, s.subject_name, s.units,
                   COALESCE((SELECT GROUP_CONCAT(ps.subject_code ORDER BY ps.subject_code SEPARATOR ', ')
                             FROM subject_prerequisites p
                             JOIN subjects ps ON ps.subject_id = p.prerequisite_subject_id
                             WHERE p.subject_id = cu.subject_id), '') AS prerequisites
            FROM curriculum cu
            JOIN subjects s ON s.subject_id = cu.subject_id
            WHERE cu.program_id = @programId
            ORDER BY cu.year_level, FIELD(cu.semester, '1st Semester', '2nd Semester', 'Summer'), s.subject_code;
            """, ("@programId", programId));
    }

    /// <summary>Active subjects not yet in this program's curriculum.</summary>
    public List<(int Id, string Label)> GetSubjectsNotInCurriculum(int programId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable table = Sql.Table(connection, null, """
            SELECT s.subject_id, s.subject_code, s.subject_name
            FROM subjects s
            WHERE s.status = 'Active'
              AND s.subject_id NOT IN (SELECT subject_id FROM curriculum WHERE program_id = @programId)
            ORDER BY s.subject_code;
            """, ("@programId", programId));

        return table.Rows.Cast<DataRow>()
            .Select(r => (Convert.ToInt32(r["subject_id"]),
                          $"{r["subject_code"]} - {r["subject_name"]}"))
            .ToList();
    }

    public List<(int Id, string Label)> GetAllSubjects()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable table = Sql.Table(connection, null,
            "SELECT subject_id, subject_code, subject_name FROM subjects ORDER BY subject_code;");

        return table.Rows.Cast<DataRow>()
            .Select(r => (Convert.ToInt32(r["subject_id"]),
                          $"{r["subject_code"]} - {r["subject_name"]}"))
            .ToList();
    }

    public void AddEntry(int programId, int subjectId, int yearLevel, string semester)
    {
        Session.RequireAdmin();

        if (yearLevel < 1 || yearLevel > 6)
        {
            throw new BusinessRuleException("Please choose a valid year level.");
        }

        if (!SESRS.Models.Academic.Semesters.Contains(semester))
        {
            throw new BusinessRuleException("Please choose a valid semester.");
        }

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            if (Sql.Int(connection, transaction, """
                    SELECT COUNT(*) FROM curriculum WHERE program_id = @p AND subject_id = @s;
                    """, ("@p", programId), ("@s", subjectId)) > 0)
            {
                throw new BusinessRuleException("That subject is already in this program's curriculum.");
            }

            if (Sql.Int(connection, transaction, """
                    SELECT COUNT(*) FROM subjects WHERE subject_id = @s AND status = 'Active';
                    """, ("@s", subjectId)) == 0)
            {
                throw new BusinessRuleException("That subject is not available.");
            }

            Sql.Exec(connection, transaction, """
                INSERT INTO curriculum (program_id, subject_id, year_level, semester, school_year)
                VALUES (@p, @s, @y, @sem, 'ALL');
                """, ("@p", programId), ("@s", subjectId), ("@y", yearLevel), ("@sem", semester));

            _audit.Log(connection, transaction, "CURRICULUM_ADDED", "program", programId.ToString(),
                $"Subject {subjectId}, year {yearLevel}, {semester}");

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void RemoveEntry(int curriculumId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        Sql.Exec(connection, null,
            "DELETE FROM curriculum WHERE curriculum_id = @id;", ("@id", curriculumId));

        _audit.Log(connection, null, "CURRICULUM_REMOVED", "curriculum", curriculumId.ToString());
    }

    public List<int> GetPrerequisiteIds(int subjectId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null,
                "SELECT prerequisite_subject_id FROM subject_prerequisites WHERE subject_id = @s;",
                ("@s", subjectId))
            .Rows.Cast<DataRow>()
            .Select(r => Convert.ToInt32(r[0]))
            .ToList();
    }

    public int GetSubjectIdForEntry(int curriculumId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Int(connection, null,
            "SELECT subject_id FROM curriculum WHERE curriculum_id = @id;", ("@id", curriculumId));
    }

    /// <summary>Replaces the prerequisites of a subject, rejecting self-reference and circular chains.</summary>
    public void SetPrerequisites(int subjectId, IReadOnlyCollection<int> prerequisiteIds)
    {
        Session.RequireAdmin();

        if (prerequisiteIds.Contains(subjectId))
        {
            throw new BusinessRuleException("A subject cannot be its own prerequisite.");
        }

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            // Would any chosen prerequisite (directly or indirectly) require this subject?
            foreach (int prerequisite in prerequisiteIds)
            {
                if (RequiresSubject(connection, transaction, prerequisite, subjectId))
                {
                    throw new BusinessRuleException(
                        "That would create a circular prerequisite chain (a prerequisite already depends on this subject).");
                }
            }

            Sql.Exec(connection, transaction,
                "DELETE FROM subject_prerequisites WHERE subject_id = @s;", ("@s", subjectId));

            foreach (int prerequisite in prerequisiteIds)
            {
                Sql.Exec(connection, transaction,
                    "INSERT INTO subject_prerequisites (subject_id, prerequisite_subject_id) VALUES (@s, @p);",
                    ("@s", subjectId), ("@p", prerequisite));
            }

            _audit.Log(connection, transaction, "PREREQUISITES_SET", "subject", subjectId.ToString(),
                prerequisiteIds.Count + " prerequisite(s)");

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    private static bool RequiresSubject(
        MySqlConnector.MySqlConnection connection,
        MySqlConnector.MySqlTransaction transaction,
        int startSubjectId,
        int targetSubjectId)
    {
        var seen = new HashSet<int>();
        var stack = new Stack<int>();
        stack.Push(startSubjectId);

        while (stack.Count > 0)
        {
            int current = stack.Pop();

            if (!seen.Add(current))
            {
                continue;
            }

            DataTable parents = Sql.Table(connection, transaction,
                "SELECT prerequisite_subject_id FROM subject_prerequisites WHERE subject_id = @s;",
                ("@s", current));

            foreach (DataRow row in parents.Rows)
            {
                int parent = Convert.ToInt32(row[0]);

                if (parent == targetSubjectId)
                {
                    return true;
                }

                stack.Push(parent);
            }
        }

        return false;
    }
}
