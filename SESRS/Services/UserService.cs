using MySqlConnector;
using SESRS.Data;
using SESRS.Models;

namespace SESRS.Services;

public class UserService
{
    private readonly DatabaseConnection database = new DatabaseConnection();

    public User? Login(string username, string password)
    {
        const string query = @"
            SELECT user_id, username, password_hash, full_name, role, student_id, status
            FROM users
            WHERE username = @username
            LIMIT 1;";

        using MySqlConnection connection = database.GetConnection();
        connection.Open();

        using MySqlCommand command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@username", username);

        using MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            string passwordHash = reader.GetString("password_hash");
            string status = reader.GetString("status");

            if (status != "Active")
            {
                return null;
            }

            bool passwordCorrect =
                BCrypt.Net.BCrypt.Verify(password, passwordHash);

            if (!passwordCorrect)
            {
                return null;
            }

            return new User
            {
                UserId = reader.GetInt32("user_id"),
                Username = reader.GetString("username"),
                FullName = reader.GetString("full_name"),
                Role = reader.GetString("role"),
                StudentId = reader.IsDBNull(reader.GetOrdinal("student_id"))
                    ? null
                    : reader.GetInt32("student_id")
            };
        }

        return null;
    }
}