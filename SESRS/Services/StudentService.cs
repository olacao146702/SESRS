using MySqlConnector;
using SESRS.Data;

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
    int yearLevel,
    string studentNumber)
    {
        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            // 1. Insert student record
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
                @studentNumber,
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
                'Active',
                NOW()
            );

            SELECT LAST_INSERT_ID();
            """;

            using var studentCommand = new MySqlCommand(
                studentQuery,
                connection,
                transaction);

            studentCommand.Parameters.AddWithValue("@studentNumber", studentNumber);
            studentCommand.Parameters.AddWithValue("@firstName", firstName);
            studentCommand.Parameters.AddWithValue("@middleName", middleName);
            studentCommand.Parameters.AddWithValue("@lastName", lastName);
            studentCommand.Parameters.AddWithValue("@gender", gender);
            studentCommand.Parameters.AddWithValue("@birthDate", birthDate);
            studentCommand.Parameters.AddWithValue("@email", email);
            studentCommand.Parameters.AddWithValue("@phone", phone);
            studentCommand.Parameters.AddWithValue("@address", address);
            studentCommand.Parameters.AddWithValue("@programId", programId);
            studentCommand.Parameters.AddWithValue("@yearLevel", yearLevel);

            int studentId = Convert.ToInt32(studentCommand.ExecuteScalar());

            // 2. Insert user account
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
                'Active'
            );
            """;

            string fullName = $"{firstName} {middleName} {lastName}".Trim();

            using var userCommand = new MySqlCommand(
                userQuery,
                connection,
                transaction);

            userCommand.Parameters.AddWithValue("@username", username);
            userCommand.Parameters.AddWithValue("@passwordHash", passwordHash);
            userCommand.Parameters.AddWithValue("@fullName", fullName);
            userCommand.Parameters.AddWithValue("@studentId", studentId);

            userCommand.ExecuteNonQuery();

            // Both inserts succeeded
            transaction.Commit();

            return true;
        }
        catch
        {
            // Something failed, so undo everything
            transaction.Rollback();

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

    public (string StudentNumber, string ProgramName, int YearLevel)? GetStudentDashboardInfo(int studentId)
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

        command.Parameters.AddWithValue("@studentId", studentId);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return (
                reader.GetString("student_number"),
                reader.GetString("program_name"),
                reader.GetInt32("year_level")
            );
        }

        return null;
    }


}