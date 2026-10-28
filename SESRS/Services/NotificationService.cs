using System.Data;
using MySqlConnector;
using SESRS.Data;
using SESRS.Helpers;

namespace SESRS.Services;

/// <summary>
/// Creates notifications for real system events. Callers pass their own
/// connection and transaction so the notification is saved (or rolled back)
/// together with the event that caused it.
/// </summary>
public class NotificationService
{
    private readonly DatabaseConnection _database = new();

    public void Create(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        int userId,
        string title,
        string message,
        string? link = null)
    {
        const string query = """
            INSERT INTO notifications (user_id, title, message, link)
            VALUES (@userId, @title, @message, @link);
            """;

        using var command = new MySqlCommand(query, connection, transaction);

        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@title", Truncate(title, 100));
        command.Parameters.AddWithValue("@message", Truncate(message, 255));
        command.Parameters.AddWithValue("@link", (object?)link ?? DBNull.Value);

        command.ExecuteNonQuery();
    }

    /// <summary>Notifies every active administrator (for example about a new enrollment request).</summary>
    public void NotifyAdmins(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        string title,
        string message,
        string? link = null)
    {
        const string query = """
            INSERT INTO notifications (user_id, title, message, link)
            SELECT user_id, @title, @message, @link
            FROM users
            WHERE role = 'Admin' AND status = 'Active';
            """;

        using var command = new MySqlCommand(query, connection, transaction);

        command.Parameters.AddWithValue("@title", Truncate(title, 100));
        command.Parameters.AddWithValue("@message", Truncate(message, 255));
        command.Parameters.AddWithValue("@link", (object?)link ?? DBNull.Value);

        command.ExecuteNonQuery();
    }

    // ---------------------------------------------------------------
    // Reading (for the signed-in user only)
    // ---------------------------------------------------------------

    public DataTable GetMine()
    {
        var user = Session.RequireLogin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT notification_id, title, message, created_at, is_read, link,
                   CASE WHEN is_read = 0 THEN 'New' ELSE '' END AS state
            FROM notifications
            WHERE user_id = @userId
            ORDER BY created_at DESC, notification_id DESC
            LIMIT 500;
            """, ("@userId", user.UserId));
    }

    public int CountUnread()
    {
        var user = Session.RequireLogin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Int(connection, null,
            "SELECT COUNT(*) FROM notifications WHERE user_id = @userId AND is_read = 0;",
            ("@userId", user.UserId));
    }

    public void MarkRead(int notificationId)
    {
        var user = Session.RequireLogin();

        using var connection = _database.GetConnection();
        connection.Open();

        // The user id in the WHERE clause stops anyone marking another person's notifications.
        Sql.Exec(connection, null,
            "UPDATE notifications SET is_read = 1 WHERE notification_id = @id AND user_id = @userId;",
            ("@id", notificationId), ("@userId", user.UserId));
    }

    public void MarkAllRead()
    {
        var user = Session.RequireLogin();

        using var connection = _database.GetConnection();
        connection.Open();

        Sql.Exec(connection, null,
            "UPDATE notifications SET is_read = 1 WHERE user_id = @userId AND is_read = 0;",
            ("@userId", user.UserId));
    }

    private static string Truncate(string value, int max)
    {
        return value.Length > max ? value[..max] : value;
    }
}
