using System.Data;
using System.Text.RegularExpressions;
using SESRS.Data;
using SESRS.Helpers;
using SESRS.Models;

namespace SESRS.Services;

/// <summary>Staff (administrator) accounts and account unlocking. Student accounts are managed on the Students screen.</summary>
public class UserAdminService
{
    private readonly DatabaseConnection _database = new();
    private readonly AuditService _audit = new();

    public DataTable GetUsers()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT user_id, username, full_name, role, status, last_login_at,
                   CASE WHEN locked_until IS NOT NULL AND locked_until > NOW() THEN 'Locked' ELSE '' END AS lock_state,
                   CASE WHEN must_change_password = 1 THEN 'Yes' ELSE '' END AS must_change_password
            FROM users
            ORDER BY (role = 'Admin') DESC, username;
            """);
    }

    public IssuedCredentials CreateAdministrator(string username, string fullName)
    {
        Session.RequireAdmin();

        username = (username ?? "").Trim();
        fullName = (fullName ?? "").Trim();

        if (!Regex.IsMatch(username, @"^[A-Za-z0-9._\-]{4,30}$"))
        {
            throw new BusinessRuleException(
                "Username must be 4 to 30 characters (letters, numbers, dots, underscores or hyphens).");
        }

        Validate.RequireText(fullName, "Full name", 3, 100);

        string temporaryPassword = PasswordHelper.GenerateTemporaryPassword();

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            if (Sql.Int(connection, transaction, "SELECT COUNT(*) FROM users WHERE username = @u;", ("@u", username)) > 0)
            {
                throw new BusinessRuleException($"The username \"{username}\" is already taken.");
            }

            long id = Sql.Insert(connection, transaction, """
                INSERT INTO users (username, password_hash, full_name, role, status, must_change_password)
                VALUES (@u, @h, @n, 'Admin', 'Active', 1);
                """,
                ("@u", username), ("@h", BCrypt.Net.BCrypt.HashPassword(temporaryPassword)), ("@n", fullName));

            _audit.Log(connection, transaction, "ADMIN_CREATED", "user", id.ToString(), username);

            transaction.Commit();
            return new IssuedCredentials(fullName, username, temporaryPassword);
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void SetAdministratorActive(int userId, bool active)
    {
        var self = Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            string? role = Sql.Scalar(connection, transaction,
                "SELECT role FROM users WHERE user_id = @id FOR UPDATE;", ("@id", userId)) as string;

            if (role == null)
            {
                throw new BusinessRuleException("That account no longer exists.");
            }

            if (role != "Admin")
            {
                throw new BusinessRuleException("Student accounts are activated or deactivated on the Students screen.");
            }

            if (!active)
            {
                if (userId == self.UserId)
                {
                    throw new BusinessRuleException("You cannot deactivate your own account.");
                }

                int otherAdmins = Sql.Int(connection, transaction, """
                    SELECT COUNT(*) FROM users WHERE role = 'Admin' AND status = 'Active' AND user_id <> @id;
                    """, ("@id", userId));

                if (otherAdmins == 0)
                {
                    throw new BusinessRuleException("At least one active administrator must remain.");
                }
            }

            Sql.Exec(connection, transaction, "UPDATE users SET status = @s WHERE user_id = @id;",
                ("@s", active ? "Active" : "Inactive"), ("@id", userId));

            _audit.Log(connection, transaction, active ? "ADMIN_ACTIVATED" : "ADMIN_DEACTIVATED",
                "user", userId.ToString());

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public IssuedCredentials ResetAdministratorPassword(int userId)
    {
        var self = Session.RequireAdmin();

        if (userId == self.UserId)
        {
            throw new BusinessRuleException("Use Change Password to change your own password.");
        }

        string temporaryPassword = PasswordHelper.GenerateTemporaryPassword();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable t = Sql.Table(connection, null,
            "SELECT username, full_name, role FROM users WHERE user_id = @id;", ("@id", userId));

        if (t.Rows.Count == 0)
        {
            throw new BusinessRuleException("That account no longer exists.");
        }

        if (Convert.ToString(t.Rows[0]["role"]) != "Admin")
        {
            throw new BusinessRuleException("Reset student passwords on the Students screen.");
        }

        Sql.Exec(connection, null, """
            UPDATE users SET password_hash = @h, must_change_password = 1, failed_attempts = 0, locked_until = NULL
            WHERE user_id = @id;
            """, ("@h", BCrypt.Net.BCrypt.HashPassword(temporaryPassword)), ("@id", userId));

        _audit.Log(connection, null, "ADMIN_PASSWORD_RESET", "user", userId.ToString(),
            Convert.ToString(t.Rows[0]["username"]));

        return new IssuedCredentials(Convert.ToString(t.Rows[0]["full_name"]) ?? "",
            Convert.ToString(t.Rows[0]["username"]) ?? "", temporaryPassword);
    }

    /// <summary>Clears a lockout caused by repeated wrong passwords (any role).</summary>
    public void Unlock(int userId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        Sql.Exec(connection, null,
            "UPDATE users SET failed_attempts = 0, locked_until = NULL WHERE user_id = @id;", ("@id", userId));

        _audit.Log(connection, null, "ACCOUNT_UNLOCKED", "user", userId.ToString());
    }
}
