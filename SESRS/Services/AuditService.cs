using System.Data;
using MySqlConnector;
using SESRS.Data;
using SESRS.Helpers;

namespace SESRS.Services;

/// <summary>
/// Writes to audit_log. Overloads that take a connection and transaction let
/// the audit entry commit or roll back together with the change it describes.
/// </summary>
public class AuditService
{
    private readonly DatabaseConnection _database = new();

    public void Log(string action, string entityType, string? entityId = null, string? details = null)
    {
        using MySqlConnection connection = _database.GetConnection();
        connection.Open();

        Log(connection, null, action, entityType, entityId, details);
    }

    public void Log(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        string action,
        string entityType,
        string? entityId = null,
        string? details = null)
    {
        var user = Session.CurrentUser;

        LogAs(
            connection,
            transaction,
            user?.UserId,
            user?.Username,
            action,
            entityType,
            entityId,
            details);
    }

    /// <summary>Audit entries between two dates (inclusive), newest first, at most 5000.</summary>
    public DataTable Search(DateTime from, DateTime to)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT audit_id, created_at, COALESCE(username, '(system)') AS username, action,
                   entity_type, COALESCE(entity_id, '') AS entity_id, COALESCE(details, '') AS details
            FROM audit_log
            WHERE created_at >= @from AND created_at < @to
            ORDER BY audit_id DESC
            LIMIT 5000;
            """, ("@from", from.Date), ("@to", to.Date.AddDays(1)));
    }

    /// <summary>Used when no one is signed in yet (for example login attempts).</summary>
    public void LogAs(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        int? userId,
        string? username,
        string action,
        string entityType,
        string? entityId,
        string? details)
    {
        const string query = """
            INSERT INTO audit_log
                (user_id, username, action, entity_type, entity_id, details)
            VALUES
                (@userId, @username, @action, @entityType, @entityId, @details);
            """;

        using var command = new MySqlCommand(query, connection, transaction);

        command.Parameters.AddWithValue("@userId", (object?)userId ?? DBNull.Value);
        command.Parameters.AddWithValue("@username", (object?)username ?? DBNull.Value);
        command.Parameters.AddWithValue("@action", action);
        command.Parameters.AddWithValue("@entityType", entityType);
        command.Parameters.AddWithValue("@entityId", (object?)entityId ?? DBNull.Value);
        command.Parameters.AddWithValue(
            "@details",
            details == null
                ? DBNull.Value
                : details.Length > 500 ? details[..500] : details);

        command.ExecuteNonQuery();
    }
}
