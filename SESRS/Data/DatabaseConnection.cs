using MySqlConnector;

namespace SESRS.Data;

public class DatabaseConnection
{
    private readonly string connectionString =
        "Server=localhost;Port=3306;Database=sesrs_db;User ID=root;Password=;";

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}