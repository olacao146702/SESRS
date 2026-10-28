using SESRS.Helpers;
using MySqlConnector;
using SESRS.Data;
using SESRS.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SESRS.Services;

public class StudentService
{
    private readonly DatabaseConnection _database = new();
    private readonly AuditService _audit = new();
    private readonly NotificationService _notifications = new();

    public List<(int Id, string Name)> GetActivePrograms()
    {
        Session.RequireAdmin();

        var programs = new List<(int Id, string Name)>();

        using var connection = _database.GetConnection();
        connection.Open();

        string query = """
        SELECT program_id, program_name
        FROM programs
        WHERE status = 'Active'
        ORDER BY program_name;
        """;

        using var command = new MySqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            programs.Add((
                reader.GetInt32("program_id"),
                reader.GetString("program_name")
            ));
        }

        return programs;
    }

    public (string StudentNumber, string ProgramName, int YearLevel)?
        GetStudentDashboardInfo(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        using var connection = _database.GetConnection();
        connection.Open();

        string query = """
        SELECT
            s.student_number,
            p.program_name,
            s.year_level
        FROM students s
        INNER JOIN programs p
            ON s.program_id = p.program_id
        WHERE s.student_id = @studentId
        LIMIT 1;
        """;

        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@studentId",
            studentId);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return (
                reader.IsDBNull(reader.GetOrdinal("student_number"))
                    ? ""
                    : reader.GetString("student_number"),

                reader.GetString("program_name"),

                reader.GetInt32("year_level")
            );
        }

        return null;
    }

    public DataTable GetAllStudents()
    {
        Session.RequireAdmin();

        DataTable table = new DataTable();

        using var connection = _database.GetConnection();
        connection.Open();

        string query = """
    SELECT
        s.student_id,
        s.student_number,
        CONCAT(
            s.first_name, ' ',
            IFNULL(s.middle_name, ''), ' ',
            s.last_name
        ) AS student_name,
        s.email,
        p.program_code,
        p.program_name,
        s.year_level,
        s.gender,
        s.phone,
        s.status
    FROM students s
    LEFT JOIN programs p
        ON s.program_id = p.program_id
    ORDER BY s.student_number;
    """;

        using var command = new MySqlCommand(query, connection);
        using var adapter = new MySqlDataAdapter(command);

        adapter.Fill(table);

        return table;
    }

    public DataTable SearchStudents(string keyword)
    {
        Session.RequireAdmin();

        DataTable table = new DataTable();

        using var connection = _database.GetConnection();
        connection.Open();

        string query = """
        SELECT
            s.student_id,
            s.student_number,
            CONCAT(
                s.first_name, ' ',
                IFNULL(s.middle_name, ''), ' ',
                s.last_name
            ) AS student_name,
            s.email,
            p.program_code,
            p.program_name,
            s.year_level,
            s.gender,
            s.phone,
            s.status
        FROM students s
        LEFT JOIN programs p
            ON s.program_id = p.program_id
        WHERE
            s.student_number LIKE @keyword
            OR CONCAT(
                s.first_name, ' ',
                IFNULL(s.middle_name, ''), ' ',
                s.last_name
            ) LIKE @keyword
            OR s.email LIKE @keyword
            OR p.program_code LIKE @keyword
            OR p.program_name LIKE @keyword
            OR s.status LIKE @keyword
        ORDER BY s.student_number;
        """;

        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@keyword",
            "%" + keyword + "%"
        );

        using var adapter = new MySqlDataAdapter(command);

        adapter.Fill(table);

        return table;
    }

    public DataTable GetStudentById(int studentId)
    {
        Session.RequireAdmin();

        DataTable table = new DataTable();

        using var connection = _database.GetConnection();
        connection.Open();

        string query = """
        SELECT
            s.student_id,
            s.student_number,
            s.first_name,
            s.middle_name,
            s.last_name,
            s.gender,
            s.birth_date,
            s.email,
            s.phone,
            s.address,
            s.program_id,
            s.year_level,
            s.status
        FROM students s
        WHERE s.student_id = @studentId;
        """;

        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@studentId",
            studentId
        );

        using var adapter = new MySqlDataAdapter(command);

        adapter.Fill(table);

        return table;
    }

    public bool UpdateStudent(
    int studentId,
    string firstName,
    string middleName,
    string lastName,
    string gender,
    DateTime birthDate,
    string email,
    string phone,
    string address,
    int programId,
    int yearLevel)
    {
        Session.RequireAdmin();

        Validate.StudentProfile(firstName, middleName, lastName, gender, birthDate, email, phone, address, programId, yearLevel);

        using var connection = _database.GetConnection();
        connection.Open();

        string query = """
    UPDATE students
    SET
        first_name = @firstName,
        middle_name = @middleName,
        last_name = @lastName,
        gender = @gender,
        birth_date = @birthDate,
        email = @email,
        phone = @phone,
        address = @address,
        program_id = @programId,
        year_level = @yearLevel
    WHERE student_id = @studentId;
    """;

        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue(
            "@firstName",
            firstName);

        command.Parameters.AddWithValue(
            "@middleName",
            middleName);

        command.Parameters.AddWithValue(
            "@lastName",
            lastName);

        command.Parameters.AddWithValue(
            "@gender",
            gender);

        command.Parameters.AddWithValue(
            "@birthDate",
            birthDate);

        command.Parameters.AddWithValue(
            "@email",
            email);

        command.Parameters.AddWithValue(
            "@phone",
            phone);

        command.Parameters.AddWithValue(
            "@address",
            address);

        command.Parameters.AddWithValue(
            "@programId",
            programId);

        command.Parameters.AddWithValue(
            "@yearLevel",
            yearLevel);

        command.Parameters.AddWithValue(
            "@studentId",
            studentId);

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected > 0)
        {
            _audit.Log(connection, null, "STUDENT_UPDATED", "student", studentId.ToString());
        }

        return rowsAffected > 0;
    }

    public bool ToggleStudentStatus(int studentId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            DataTable current = Sql.Table(connection, transaction,
                "SELECT status, student_number FROM students WHERE student_id = @s FOR UPDATE;",
                ("@s", studentId));

            if (current.Rows.Count == 0)
            {
                transaction.Rollback();
                return false;
            }

            string currentStatus = Convert.ToString(current.Rows[0]["status"]) ?? "Inactive";
            string? number = current.Rows[0]["student_number"] as string;
            string newStatus = currentStatus == "Active" ? "Inactive" : "Active";

            // Records created before administrators issued the numbers may have none.
            // Activating one assigns the next official number automatically.
            if (newStatus == "Active" && number == null)
            {
                number = GenerateStudentNumber(connection, transaction);

                Sql.Exec(connection, transaction,
                    "UPDATE students SET student_number = @n WHERE student_id = @s;",
                    ("@n", number), ("@s", studentId));

                _audit.Log(connection, transaction, "STUDENT_NUMBER_ASSIGNED", "student",
                    studentId.ToString(), "Student number " + number);
            }

            // The student record and the login account must always agree.
            Sql.Exec(connection, transaction,
                "UPDATE students SET status = @status WHERE student_id = @s;",
                ("@status", newStatus), ("@s", studentId));

            Sql.Exec(connection, transaction,
                "UPDATE users SET status = @status WHERE student_id = @s AND role = 'Student';",
                ("@status", newStatus), ("@s", studentId));

            _audit.Log(connection, transaction,
                newStatus == "Active" ? "STUDENT_ACTIVATED" : "STUDENT_DEACTIVATED",
                "student", studentId.ToString());

            if (newStatus == "Active")
            {
                object? userId = Sql.Scalar(connection, transaction,
                    "SELECT user_id FROM users WHERE student_id = @s AND role = 'Student' LIMIT 1;",
                    ("@s", studentId));

                if (userId != null)
                {
                    _notifications.Create(connection, transaction, Convert.ToInt32(userId),
                        "Account activated",
                        "Your account is active. Your student number is " + number + ".");
                }
            }

            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public int GetTotalStudents()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        string query = "SELECT COUNT(*) FROM students;";

        using var command = new MySqlCommand(query, connection);

        return Convert.ToInt32(command.ExecuteScalar());
    }

    public int GetTotalActiveStudents()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        string query = """
        SELECT COUNT(*)
        FROM students
        WHERE status = 'Active';
        """;

        using var command = new MySqlCommand(query, connection);

        return Convert.ToInt32(command.ExecuteScalar());
    }

    // =========================================================
    // ADMIN-CREATED STUDENT ACCOUNTS
    // =========================================================

    /// <summary>
    /// Creates the student record and an Active login account. The system generates the official
    /// student number (YYYY####, unique) and a temporary password; the number is also the username.
    /// The student must change the password at first login.
    /// </summary>
    public CreatedStudentAccount CreateStudentAccount(NewStudentRequest request)
    {
        Session.RequireAdmin();

        NewStudentRequest r = Normalize(request);
        ValidateNewStudent(r);

        string temporaryPassword = PasswordHelper.GenerateTemporaryPassword();
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(temporaryPassword);

        string fullName = string.Join(
            " ",
            new[] { r.FirstName, r.MiddleName, r.LastName }
                .Where(part => !string.IsNullOrWhiteSpace(part)));

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            int duration;

            using (var program = new MySqlCommand(
                "SELECT duration_years FROM programs WHERE program_id = @id AND status = 'Active';",
                connection,
                transaction))
            {
                program.Parameters.AddWithValue("@id", r.ProgramId);
                object? value = program.ExecuteScalar();

                if (value == null || value == DBNull.Value)
                {
                    throw new BusinessRuleException("The selected program is not available.");
                }

                duration = Convert.ToInt32(value);
            }

            if (r.YearLevel < 1 || r.YearLevel > duration)
            {
                throw new BusinessRuleException(
                    $"Year level must be between 1 and {duration} for the selected program.");
            }

            string studentNumber = GenerateStudentNumber(connection, transaction);

            long studentId = Sql.Insert(connection, transaction, """
                INSERT INTO students
                    (student_number, first_name, middle_name, last_name, gender,
                     birth_date, email, phone, address, program_id, year_level, status)
                VALUES
                    (@number, @first, @middle, @last, @gender,
                     @birth, @email, @phone, @address, @program, @year, 'Active');
                """,
                ("@number", studentNumber), ("@first", r.FirstName), ("@middle", r.MiddleName),
                ("@last", r.LastName), ("@gender", r.Gender), ("@birth", r.BirthDate.Date),
                ("@email", r.Email), ("@phone", r.Phone), ("@address", r.Address),
                ("@program", r.ProgramId), ("@year", r.YearLevel));

            long userId = Sql.Insert(connection, transaction, """
                INSERT INTO users
                    (username, password_hash, full_name, role, student_id, status, must_change_password)
                VALUES
                    (@username, @hash, @fullName, 'Student', @studentId, 'Active', 1);
                """,
                ("@username", studentNumber), ("@hash", passwordHash), ("@fullName", fullName),
                ("@studentId", studentId));

            _notifications.Create(
                connection,
                transaction,
                (int)userId,
                "Welcome to SESRS",
                "Your student account was created by the registrar. Your student number is "
                    + studentNumber + ".");

            _audit.Log(
                connection,
                transaction,
                "STUDENT_ACCOUNT_CREATED",
                "student",
                studentId.ToString(),
                "Student number " + studentNumber);

            transaction.Commit();

            return new CreatedStudentAccount(
                (int)studentId,
                studentNumber,
                new IssuedCredentials(fullName, studentNumber, temporaryPassword));
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>
    /// Next unused student number for this year (YYYY####). The locking read makes two administrators
    /// creating students at the same moment receive different numbers; the database also enforces uniqueness.
    /// </summary>
    private static string GenerateStudentNumber(MySqlConnection connection, MySqlTransaction transaction)
    {
        string year = DateTime.Now.Year.ToString();

        int next = Sql.Int(connection, transaction, """
            SELECT COALESCE(MAX(CAST(SUBSTRING(student_number, 5) AS UNSIGNED)), 0)
            FROM students
            WHERE student_number REGEXP '^[0-9]{8}$' AND student_number LIKE @prefix
            FOR UPDATE;
            """, ("@prefix", year + "%")) + 1;

        while (next <= 9999)
        {
            string candidate = year + next.ToString("D4");

            // A staff username could coincide with a number; skip it so the login stays unique.
            if (!ValueExists(connection, transaction, "students", "student_number", candidate) &&
                !ValueExists(connection, transaction, "users", "username", candidate))
            {
                return candidate;
            }

            next++;
        }

        throw new BusinessRuleException("No more student numbers are available for this year.");
    }

    /// <summary>
    /// Issues a new temporary password (account recovery). The student must
    /// change it at the next login, and any lockout is cleared.
    /// </summary>
    public IssuedCredentials ResetStudentPassword(int studentId)
    {
        Session.RequireAdmin();

        string temporaryPassword = PasswordHelper.GenerateTemporaryPassword();
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(temporaryPassword);

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            int userId;
            string username, fullName;

            using (var select = new MySqlCommand(
                """
                SELECT user_id, username, full_name
                FROM users
                WHERE student_id = @studentId AND role = 'Student'
                LIMIT 1
                FOR UPDATE;
                """,
                connection,
                transaction))
            {
                select.Parameters.AddWithValue("@studentId", studentId);

                using var reader = select.ExecuteReader();

                if (!reader.Read())
                {
                    throw new BusinessRuleException("This student does not have a login account.");
                }

                userId = reader.GetInt32("user_id");
                username = reader.GetString("username");
                fullName = reader.GetString("full_name");
            }

            using (var update = new MySqlCommand(
                """
                UPDATE users
                SET password_hash = @hash,
                    must_change_password = 1,
                    failed_attempts = 0,
                    locked_until = NULL
                WHERE user_id = @userId;
                """,
                connection,
                transaction))
            {
                update.Parameters.AddWithValue("@hash", passwordHash);
                update.Parameters.AddWithValue("@userId", userId);
                update.ExecuteNonQuery();
            }

            _notifications.Create(
                connection,
                transaction,
                userId,
                "Password reset",
                "Your password was reset by the registrar. Sign in with your temporary password and choose a new one.");

            _audit.Log(
                connection,
                transaction,
                "PASSWORD_RESET",
                "student",
                studentId.ToString(),
                $"Username {username}");

            transaction.Commit();

            return new IssuedCredentials(fullName, username, temporaryPassword);
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    private static bool ValueExists(
        MySqlConnection connection,
        MySqlTransaction transaction,
        string table,
        string column,
        string value)
    {
        // table and column are internal constants, never user input.
        using var command = new MySqlCommand(
            $"SELECT COUNT(*) FROM {table} WHERE {column} = @value;",
            connection,
            transaction);

        command.Parameters.AddWithValue("@value", value);

        return Convert.ToInt32(command.ExecuteScalar()) > 0;
    }

    private static string? NullIfBlank(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }

    private static NewStudentRequest Normalize(NewStudentRequest r)
    {
        return r with
        {
            FirstName = (r.FirstName ?? "").Trim(),
            MiddleName = NullIfBlank(r.MiddleName),
            LastName = (r.LastName ?? "").Trim(),
            Gender = (r.Gender ?? "").Trim(),
            Email = (r.Email ?? "").Trim(),
            Phone = (r.Phone ?? "").Trim(),
            Address = (r.Address ?? "").Trim()
        };
    }

    private static void ValidateNewStudent(NewStudentRequest r)
    {
        // The same rules as editing a student, plus: contact details are collected at registration
        // because enrollment requires them.
        Validate.StudentProfile(r.FirstName, r.MiddleName, r.LastName, r.Gender, r.BirthDate,
            r.Email, r.Phone, r.Address, r.ProgramId, r.YearLevel);

        if (r.Email.Length == 0 || r.Phone.Length == 0 || r.Address.Length == 0)
        {
            throw new BusinessRuleException("Email, phone number and address are required.");
        }
    }
}
