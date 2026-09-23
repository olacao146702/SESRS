using MySqlConnector;
using SESRS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SESRS.Services;

public class StudentService
{
    private readonly DatabaseConnection _database = new();

    public bool StudentNumberExists(string studentNumber)
    {
        using var connection = _database.GetConnection();
        connection.Open();

        string query = """
            SELECT COUNT(*)
            FROM students
            WHERE student_number = @studentNumber;
            """;

        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@studentNumber", studentNumber);

        int count = Convert.ToInt32(command.ExecuteScalar());

        return count > 0;
    }

    public bool UsernameExists(string username)
    {
        using var connection = _database.GetConnection();
        connection.Open();

        string query = """
            SELECT COUNT(*)
            FROM users
            WHERE username = @username;
            """;

        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@username", username);

        int count = Convert.ToInt32(command.ExecuteScalar());

        return count > 0;
    }

    public bool RegisterStudent(
        string username,
        string passwordHash,
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
        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            // 1. Insert student record
            // Student Number is NULL because Admin will assign it later.
            string studentQuery = """
            INSERT INTO students
            (
                student_number,
                first_name,
                middle_name,
                last_name,
                gender,
                birth_date,
                email,
                phone,
                address,
                program_id,
                year_level,
                status,
                created_at
            )
            VALUES
            (
                NULL,
                @firstName,
                @middleName,
                @lastName,
                @gender,
                @birthDate,
                @email,
                @phone,
                @address,
                @programId,
                @yearLevel,
                'Pending',
                NOW()
            );

            SELECT LAST_INSERT_ID();
            """;

            using var studentCommand = new MySqlCommand(
                studentQuery,
                connection,
                transaction);

            studentCommand.Parameters.AddWithValue(
                "@firstName",
                firstName);

            studentCommand.Parameters.AddWithValue(
                "@middleName",
                middleName);

            studentCommand.Parameters.AddWithValue(
                "@lastName",
                lastName);

            studentCommand.Parameters.AddWithValue(
                "@gender",
                gender);

            studentCommand.Parameters.AddWithValue(
                "@birthDate",
                birthDate);

            studentCommand.Parameters.AddWithValue(
                "@email",
                email);

            studentCommand.Parameters.AddWithValue(
                "@phone",
                phone);

            studentCommand.Parameters.AddWithValue(
                "@address",
                address);

            studentCommand.Parameters.AddWithValue(
                "@programId",
                programId);

            studentCommand.Parameters.AddWithValue(
                "@yearLevel",
                yearLevel);

            int studentId = Convert.ToInt32(
                studentCommand.ExecuteScalar());

            // 2. Insert user account
            // Account is Pending until Admin approves the student.
            string userQuery = """
            INSERT INTO users
            (
                username,
                password_hash,
                full_name,
                role,
                student_id,
                created_at,
                status
            )
            VALUES
            (
                @username,
                @passwordHash,
                @fullName,
                'Student',
                @studentId,
                NOW(),
                'Pending'
            );
            """;

            string fullName =
                $"{firstName} {middleName} {lastName}".Trim();

            using var userCommand = new MySqlCommand(
                userQuery,
                connection,
                transaction);

            userCommand.Parameters.AddWithValue(
                "@username",
                username);

            userCommand.Parameters.AddWithValue(
                "@passwordHash",
                passwordHash);

            userCommand.Parameters.AddWithValue(
                "@fullName",
                fullName);

            userCommand.Parameters.AddWithValue(
                "@studentId",
                studentId);

            userCommand.ExecuteNonQuery();

            // Both inserts succeeded.
            transaction.Commit();

            return true;
        }
        catch (Exception ex)
        {
            // Something failed, so undo everything.
            transaction.Rollback();

            // Show the actual database error for debugging.
            MessageBox.Show(
                "Registration Error:\n\n" + ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return false;
        }
    }

    public List<(int Id, string Name)> GetActivePrograms()
    {
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

    public DataTable GetPendingStudents()
    {
        DataTable table = new DataTable();

        using var connection = _database.GetConnection();
        connection.Open();

        string query = @"
        SELECT
            s.student_id,
            CONCAT(
                s.first_name, ' ',
                IFNULL(s.middle_name, ''), ' ',
                s.last_name
            ) AS student_name,
            s.email,
            p.program_code,
            p.program_name,
            s.year_level,
            s.status
        FROM students s
        LEFT JOIN programs p
            ON s.program_id = p.program_id
        WHERE s.status = 'Pending'
        ORDER BY s.created_at DESC;
    ";

        using var command = new MySqlCommand(query, connection);
        using var adapter = new MySqlDataAdapter(command);

        adapter.Fill(table);

        return table;
    }

    public bool ApproveStudent(int studentId)
    {
        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            // Get the current year
            string year = DateTime.Now.Year.ToString();

            // Find the next student number for this year
            string numberQuery = @"
            SELECT MAX(student_number)
            FROM students
            WHERE student_number LIKE @yearPrefix;";

            using var numberCommand =
                new MySqlCommand(numberQuery, connection, transaction);

            numberCommand.Parameters.AddWithValue(
                "@yearPrefix",
                year + "%"
            );

            object? result = numberCommand.ExecuteScalar();

            int nextNumber = 1;

            if (result != null && result != DBNull.Value)
            {
                string lastNumber = result.ToString()!;

                if (lastNumber.Length >= 8 &&
                    int.TryParse(lastNumber.Substring(4), out int lastSequence))
                {
                    nextNumber = lastSequence + 1;
                }
            }

            // Create the new Student Number
            string studentNumber =
                year + nextNumber.ToString("D4");

            // Make sure the generated number is not already used
            string checkQuery = @"
            SELECT COUNT(*)
            FROM students
            WHERE student_number = @studentNumber;";

            using var checkCommand =
                new MySqlCommand(checkQuery, connection, transaction);

            checkCommand.Parameters.AddWithValue(
                "@studentNumber",
                studentNumber
            );

            long existingCount =
                Convert.ToInt64(checkCommand.ExecuteScalar());

            if (existingCount > 0)
            {
                transaction.Rollback();
                return false;
            }

            // Activate the student
            string studentQuery = @"
            UPDATE students
            SET
                student_number = @studentNumber,
                status = 'Active'
            WHERE student_id = @studentId
              AND status = 'Pending';";

            using var studentCommand =
                new MySqlCommand(studentQuery, connection, transaction);

            studentCommand.Parameters.AddWithValue(
                "@studentNumber",
                studentNumber
            );

            studentCommand.Parameters.AddWithValue(
                "@studentId",
                studentId
            );

            int studentRows =
                studentCommand.ExecuteNonQuery();

            if (studentRows == 0)
            {
                transaction.Rollback();
                return false;
            }

            // Activate the student's login account
            string userQuery = @"
            UPDATE users
            SET status = 'Active'
            WHERE student_id = @studentId
              AND role = 'Student'
              AND status = 'Pending';";

            using var userCommand =
                new MySqlCommand(userQuery, connection, transaction);

            userCommand.Parameters.AddWithValue(
                "@studentId",
                studentId
            );

            int userRows =
                userCommand.ExecuteNonQuery();

            if (userRows == 0)
            {
                transaction.Rollback();
                return false;
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

    public DataTable GetAllStudents()
    {
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
}