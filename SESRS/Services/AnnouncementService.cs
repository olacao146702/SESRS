using System.Data;
using SESRS.Data;
using SESRS.Helpers;

namespace SESRS.Services;

public sealed record AnnouncementDraft(
    int AnnouncementId,
    string Title,
    string Body,
    int? ProgramId,
    int? YearLevel,
    int? SectionId,
    DateTime? ExpiresAt);

/// <summary>School announcements for all students or a program / year level / section.</summary>
public class AnnouncementService
{
    private readonly DatabaseConnection _database = new();
    private readonly AuditService _audit = new();

    public DataTable GetAll()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT a.announcement_id, a.title, a.body,
                   CONCAT_WS(' / ',
                       COALESCE(p.program_code, 'All programs'),
                       COALESCE(CONCAT('Year ', a.year_level), 'All years'),
                       COALESCE(sec.section_code, 'All sections')) AS audience,
                   CASE WHEN a.is_active = 0 THEN 'Withdrawn'
                        WHEN a.expires_at IS NOT NULL AND a.expires_at < CURDATE() THEN 'Expired'
                        ELSE 'Active' END AS status,
                   COALESCE(u.full_name, '-') AS posted_by, a.created_at, a.expires_at
            FROM announcements a
            LEFT JOIN programs p ON p.program_id = a.program_id
            LEFT JOIN sections sec ON sec.section_id = a.section_id
            LEFT JOIN users u ON u.user_id = a.posted_by
            ORDER BY a.created_at DESC, a.announcement_id DESC;
            """);
    }

    public AnnouncementDraft? Get(int id)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable t = Sql.Table(connection, null,
            "SELECT * FROM announcements WHERE announcement_id = @id;", ("@id", id));

        if (t.Rows.Count == 0)
        {
            return null;
        }

        DataRow r = t.Rows[0];

        return new AnnouncementDraft(
            id,
            Convert.ToString(r["title"]) ?? "",
            Convert.ToString(r["body"]) ?? "",
            r["program_id"] == DBNull.Value ? null : Convert.ToInt32(r["program_id"]),
            r["year_level"] == DBNull.Value ? null : Convert.ToInt32(r["year_level"]),
            r["section_id"] == DBNull.Value ? null : Convert.ToInt32(r["section_id"]),
            r["expires_at"] == DBNull.Value ? null : Convert.ToDateTime(r["expires_at"]));
    }

    /// <summary>Publishes an announcement and notifies the targeted active students. Returns how many were notified.</summary>
    public int Publish(AnnouncementDraft draft)
    {
        var admin = Session.RequireAdmin();
        Check(draft);

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            long id = Sql.Insert(connection, transaction, """
                INSERT INTO announcements (title, body, program_id, year_level, section_id, posted_by, expires_at)
                VALUES (@t, @b, @p, @y, @sec, @u, @exp);
                """,
                ("@t", draft.Title.Trim()), ("@b", draft.Body.Trim()), ("@p", draft.ProgramId),
                ("@y", draft.YearLevel), ("@sec", draft.SectionId), ("@u", admin.UserId),
                ("@exp", draft.ExpiresAt?.Date));

            string message = draft.Body.Trim().Replace("\r", " ").Replace("\n", " ");

            if (message.Length > 250)
            {
                message = message[..250] + "...";
            }

            string title = "Announcement: " + draft.Title.Trim();

            if (title.Length > 100)
            {
                title = title[..97] + "...";
            }

            int notified = Sql.Exec(connection, transaction, """
                INSERT INTO notifications (user_id, title, message, link)
                SELECT u.user_id, @t, @m, 'announcements'
                FROM users u
                JOIN students s ON s.student_id = u.student_id
                WHERE u.role = 'Student' AND u.status = 'Active' AND s.status = 'Active'
                  AND (@p IS NULL OR s.program_id = @p)
                  AND (@y IS NULL OR s.year_level = @y)
                  AND (@sec IS NULL OR EXISTS (
                        SELECT 1 FROM enrollment_details d
                        JOIN enrollments e ON e.enrollment_id = d.enrollment_id
                        WHERE e.student_id = s.student_id AND e.status IN ('Pending', 'Approved')
                          AND d.section_id = @sec));
                """,
                ("@t", title), ("@m", message), ("@p", draft.ProgramId), ("@y", draft.YearLevel),
                ("@sec", draft.SectionId));

            _audit.Log(connection, transaction, "ANNOUNCEMENT_PUBLISHED", "announcement", id.ToString(),
                $"{draft.Title.Trim()} ({notified} notified)");

            transaction.Commit();
            return notified;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>Edits an announcement (students are not notified again).</summary>
    public void Update(AnnouncementDraft draft)
    {
        Session.RequireAdmin();
        Check(draft);

        using var connection = _database.GetConnection();
        connection.Open();

        int rows = Sql.Exec(connection, null, """
            UPDATE announcements
            SET title = @t, body = @b, program_id = @p, year_level = @y, section_id = @sec, expires_at = @exp
            WHERE announcement_id = @id;
            """,
            ("@t", draft.Title.Trim()), ("@b", draft.Body.Trim()), ("@p", draft.ProgramId),
            ("@y", draft.YearLevel), ("@sec", draft.SectionId), ("@exp", draft.ExpiresAt?.Date),
            ("@id", draft.AnnouncementId));

        if (rows == 0)
        {
            throw new BusinessRuleException("That announcement no longer exists.");
        }

        _audit.Log(connection, null, "ANNOUNCEMENT_UPDATED", "announcement",
            draft.AnnouncementId.ToString(), draft.Title.Trim());
    }

    public void SetActive(int id, bool active)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        Sql.Exec(connection, null, "UPDATE announcements SET is_active = @a WHERE announcement_id = @id;",
            ("@a", active ? 1 : 0), ("@id", id));

        _audit.Log(connection, null, active ? "ANNOUNCEMENT_RESTORED" : "ANNOUNCEMENT_WITHDRAWN",
            "announcement", id.ToString());
    }

    public void Delete(int id)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        Sql.Exec(connection, null, "DELETE FROM announcements WHERE announcement_id = @id;", ("@id", id));
        _audit.Log(connection, null, "ANNOUNCEMENT_DELETED", "announcement", id.ToString());
    }

    private static void Check(AnnouncementDraft d)
    {
        Validate.RequireText(d.Title, "Title", 1, 150);
        Validate.RequireText(d.Body, "Message", 1, 5000);

        if (d.YearLevel is < 1 or > 6)
        {
            throw new BusinessRuleException("Year level must be between 1 and 6.");
        }

        if (d.ExpiresAt != null && d.ExpiresAt.Value.Date < DateTime.Today)
        {
            throw new BusinessRuleException("The expiry date cannot be in the past.");
        }
    }
}
