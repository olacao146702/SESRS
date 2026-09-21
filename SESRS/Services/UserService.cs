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
            SELECT user_id, username, full_name, role
            FROM users
            WHERE username = @username
            AND password = @password
            LIMIT 1;";

        using MySqlConnection connection = database.GetConnection();
        connection.Open();

        using MySqlCommand command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);

        using MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new User
            {
                UserId = reader.GetInt32("user_id"),
                Username = reader.GetString("username"),
                FullName = reader.GetString("full_name"),
                Role = reader.GetString("role")
            };
        }

        return null;
    }
}