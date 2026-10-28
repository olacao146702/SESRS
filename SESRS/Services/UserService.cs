using MySqlConnector;
using SESRS.Data;
using SESRS.Helpers;
using SESRS.Models;

namespace SESRS.Services;

public enum LoginStatus
{
    Success,
    InvalidCredentials,
    AccountInactive,
    Locked
}

public sealed record LoginResult(
    LoginStatus Status,
    User? User = null,
    DateTime? LockedUntil = null);

public class UserService
{
    private const int MaxFailedAttempts = 5;
    private const int LockoutMinutes = 15;

    private readonly DatabaseConnection database = new();
    private readonly AuditService _audit = new();

    public LoginResult Login(string username, string password)
    {
        const string query = """
            SELECT
                user_id, username, password_hash, full_name, role, student_id,
                status, must_change_password, failed_attempts, locked_until,
                (locked_until IS NOT NULL AND locked_until > NOW()) AS is_locked
            FROM users
            WHERE username = @username
            LIMIT 1;
            """;

        using MySqlConnection connection = database.GetConnection();
        connection.Open();

        int userId;
        string storedUsername, passwordHash, fullName, role, status;
        int? studentId;
        bool mustChangePassword, isLocked;
        int failedAttempts;
        DateTime? lockedUntil;

        using (var command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@username", username);

            using MySqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return new LoginResult(LoginStatus.InvalidCredentials);
            }

            userId = reader.GetInt32("user_id");
            storedUsername = reader.GetString("username");
            passwordHash = reader.GetString("password_hash");
            fullName = reader.GetString("full_name");
            role = reader.GetString("role");
            studentId = reader.IsDBNull(reader.GetOrdinal("student_id"))
                ? null
                : reader.GetInt32("student_id");
            status = reader.GetString("status");
            mustChangePassword = Convert.ToInt32(reader["must_change_password"]) != 0;
            failedAttempts = reader.GetInt32("failed_attempts");
            lockedUntil = reader.IsDBNull(reader.GetOrdinal("locked_until"))
                ? null
                : reader.GetDateTime("locked_until");
            isLocked = Convert.ToInt32(reader["is_locked"]) == 1;
        }

        if (isLocked)
        {
            return new LoginResult(LoginStatus.Locked, null, lockedUntil);
        }

        if (!BCrypt.Net.BCrypt.Verify(password, passwordHash))
        {
            RegisterFailedAttempt(connection, userId, storedUsername, failedAttempts);
            return new LoginResult(LoginStatus.InvalidCredentials);
        }

        // Status is revealed only after the password is correct so that
        // outsiders cannot discover which usernames exist.
        if (status != "Active")
        {
            return new LoginResult(LoginStatus.AccountInactive);
        }

        using (var update = new MySqlCommand(
            """
            UPDATE users
            SET failed_attempts = 0, locked_until = NULL, last_login_at = NOW()
            WHERE user_id = @userId;
            """,
            connection))
        {
            update.Parameters.AddWithValue("@userId", userId);
            update.ExecuteNonQuery();
        }

        _audit.LogAs(connection, null, userId, storedUsername, "LOGIN", "user", userId.ToString(), null);

        return new LoginResult(
            LoginStatus.Success,
            new User
            {
                UserId = userId,
                Username = storedUsername,
                FullName = fullName,
                Role = role,
                StudentId = studentId,
                MustChangePassword = mustChangePassword
            });
    }

    private void RegisterFailedAttempt(
        MySqlConnection connection,
        int userId,
        string username,
        int previousFailures)
    {
        int failures = previousFailures + 1;
        bool lockNow = failures >= MaxFailedAttempts;

        string query = lockNow
            ? """
              UPDATE users
              SET failed_attempts = 0,
                  locked_until = DATE_ADD(NOW(), INTERVAL @minutes MINUTE)
              WHERE user_id = @userId;
              """
            : """
              UPDATE users SET failed_attempts = @failures WHERE user_id = @userId;
              """;

        using var command = new MySqlCommand(query, connection);

        command.Parameters.AddWithValue("@userId", userId);

        if (lockNow)
        {
            command.Parameters.AddWithValue("@minutes", LockoutMinutes);
        }
        else
        {
            command.Parameters.AddWithValue("@failures", failures);
        }

        command.ExecuteNonQuery();

        _audit.LogAs(
            connection,
            null,
            userId,
            username,
            lockNow ? "ACCOUNT_LOCKED" : "LOGIN_FAILED",
            "user",
            userId.ToString(),
            lockNow ? $"Locked for {LockoutMinutes} minutes after {MaxFailedAttempts} failed attempts" : null);
    }

    /// <summary>Changes the password of the signed-in user.</summary>
    public void ChangePassword(string currentPassword, string newPassword, string confirmPassword)
    {
        User user = Session.RequireLogin();

        if (string.IsNullOrEmpty(currentPassword))
        {
            throw new BusinessRuleException("Please enter your current password.");
        }

        if (newPassword != confirmPassword)
        {
            throw new BusinessRuleException("The new password and its confirmation do not match.");
        }

        string? policyError = PasswordHelper.Validate(newPassword, user.Username);

        if (policyError != null)
        {
            throw new BusinessRuleException(policyError);
        }

        if (newPassword == currentPassword)
        {
            throw new BusinessRuleException("The new password must be different from your current password.");
        }

        using MySqlConnection connection = database.GetConnection();
        connection.Open();

        string? storedHash;

        using (var select = new MySqlCommand(
            "SELECT password_hash FROM users WHERE user_id = @userId;",
            connection))
        {
            select.Parameters.AddWithValue("@userId", user.UserId);
            storedHash = select.ExecuteScalar() as string;
        }

        if (storedHash == null || !BCrypt.Net.BCrypt.Verify(currentPassword, storedHash))
        {
            throw new BusinessRuleException("Your current password is incorrect.");
        }

        using (var update = new MySqlCommand(
            """
            UPDATE users
            SET password_hash = @hash, must_change_password = 0
            WHERE user_id = @userId;
            """,
            connection))
        {
            update.Parameters.AddWithValue("@hash", BCrypt.Net.BCrypt.HashPassword(newPassword));
            update.Parameters.AddWithValue("@userId", user.UserId);
            update.ExecuteNonQuery();
        }

        _audit.Log(connection, null, "PASSWORD_CHANGED", "user", user.UserId.ToString());

        user.MustChangePassword = false;
    }
}
