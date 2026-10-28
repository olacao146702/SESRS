using System.Text.Json;
using MySqlConnector;

namespace SESRS.Data;

public class DatabaseConnection
{
    // Used only when no environment variable or config file is present
    // (matches the original local XAMPP setup).
    private const string DefaultConnectionString =
        "Server=localhost;Port=3306;Database=sesrs_db;User ID=root;Password= ;";

    private static readonly Lazy<string> ConnectionString = new(Resolve);

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString.Value);
    }

    /// <summary>
    /// Order: SESRS_CONNECTION environment variable, then sesrs.config.json
    /// next to the executable, then the default above.
    /// </summary>
    private static string Resolve()
    {
        string? fromEnvironment =
            Environment.GetEnvironmentVariable("SESRS_CONNECTION");

        if (!string.IsNullOrWhiteSpace(fromEnvironment))
        {
            return fromEnvironment;
        }

        string path = Path.Combine(AppContext.BaseDirectory, "sesrs.config.json");

        if (File.Exists(path))
        {
            using JsonDocument document = JsonDocument.Parse(File.ReadAllText(path));

            if (document.RootElement.TryGetProperty("ConnectionString", out JsonElement value))
            {
                string? configured = value.GetString();

                if (!string.IsNullOrWhiteSpace(configured))
                {
                    return configured;
                }
            }
        }

        return DefaultConnectionString;
    }
}
