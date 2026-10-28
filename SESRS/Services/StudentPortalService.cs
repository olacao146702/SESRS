using System.Data;
using System.Text.RegularExpressions;
using SESRS.Data;
using SESRS.Helpers;
using SESRS.Models;

namespace SESRS.Services;

/// <summary>Read models and limited self-service actions for the student portal.</summary>
public class StudentPortalService
{
    private readonly DatabaseConnection _database = new();
    private readonly AuditService _audit = new();
    private readonly PeriodService _periods = new();

    // ---------------------------------------------------------------
    // Profile
    // ---------------------------------------------------------------

    public StudentProfile GetProfile(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        using var connection = _database.GetConnection();
        connection.Open();

        return ReadProfile(connection, studentId);
    }

    private static StudentProfile ReadProfile(MySqlConnector.MySqlConnection connection, int studentId)
    {
        DataTable t = Sql.Table(connection, null, """
            SELECT s.student_id, s.student_number, s.first_name, s.middle_name, s.last_name, s.gender,
                   s.birth_date, s.email, s.phone, s.address, s.year_level, s.status,
                   p.program_code, p.program_name
            FROM students s
            JOIN programs p ON p.program_id = s.program_id
            WHERE s.student_id = @s;
            """, ("@s", studentId));

        if (t.Rows.Count == 0)
        {
            throw new BusinessRuleException("Student record not found.");
        }

        DataRow r = t.Rows[0];

        string Text(string column) => r[column] as string ?? "";

        string fullName = string.Join(" ",
            new[] { Text("first_name"), Text("middle_name"), Text("last_name") }
                .Where(part => part.Length > 0));

        return new StudentProfile(
            studentId,
            Text("student_number"),
            fullName,
            Text("gender"),
            r["birth_date"] == DBNull.Value ? null : Convert.ToDateTime(r["birth_date"]),
            Text("email"),
            Text("phone"),
            Text("address"),
            Text("program_code"),
            Text("program_name"),
            Convert.ToInt32(r["year_level"]),
            Text("status"));
    }

    /// <summary>Students may change only their own email, phone and address.</summary>
    public void UpdateContact(int studentId, string email, string phone, string address)
    {
        var user = Session.RequireLogin();

        if (user.Role != "Student" || user.StudentId != studentId)
        {
            throw new UnauthorizedAccessException("You can only update your own profile.");
        }

        email = (email ?? "").Trim();
        phone = (phone ?? "").Trim();
        address = (address ?? "").Trim();

        if (email.Length == 0 || email.Length > 100 ||
            !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new BusinessRuleException("Please enter a valid email address.");
        }

        if (!Regex.IsMatch(phone, @"^[0-9+\-\s()]{7,20}$"))
        {
            throw new BusinessRuleException("Please enter a valid phone number.");
        }

        if (address.Length == 0 || address.Length > 255)
        {
            throw new BusinessRuleException("Please enter your address (up to 255 characters).");
        }

        using var connection = _database.GetConnection();
        connection.Open();

        Sql.Exec(connection, null, """
            UPDATE students SET email = @email, phone = @phone, address = @address
            WHERE student_id = @s;
            """, ("@email", email), ("@phone", phone), ("@address", address), ("@s", studentId));

        _audit.Log(connection, null, "PROFILE_UPDATED", "student", studentId.ToString());
    }

    // ---------------------------------------------------------------
    // Timetable
    // ---------------------------------------------------------------

    /// <summary>Meetings of the current term's pending or approved enrollment.</summary>
    public List<TimetableEntry> GetTimetable(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        AcademicPeriod? period = _periods.GetCurrent();

        if (period == null)
        {
            return new List<TimetableEntry>();
        }

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
                SELECT s.subject_code, s.subject_name, sec.section_code, sc.day, sc.start_time, sc.end_time,
                       COALESCE(sc.room, '') AS room, COALESCE(sc.instructor, '') AS instructor, e.status
                FROM enrollments e
                JOIN enrollment_details d ON d.enrollment_id = e.enrollment_id
                JOIN subjects s ON s.subject_id = d.subject_id
                JOIN sections sec ON sec.section_id = d.section_id
                JOIN schedules sc ON sc.section_id = d.section_id AND sc.subject_id = d.subject_id
                WHERE e.student_id = @s AND e.school_year = @sy AND e.semester = @sem
                  AND e.status IN ('Approved', 'Pending')
                ORDER BY FIELD(sc.day,'Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday'),
                         sc.start_time;
                """,
                ("@s", studentId), ("@sy", period.SchoolYear), ("@sem", period.Semester))
            .Rows.Cast<DataRow>()
            .Select(r => new TimetableEntry(
                Convert.ToString(r["subject_code"]) ?? "",
                Convert.ToString(r["subject_name"]) ?? "",
                Convert.ToString(r["section_code"]) ?? "",
                Convert.ToString(r["day"]) ?? "",
                (TimeSpan)r["start_time"],
                (TimeSpan)r["end_time"],
                Convert.ToString(r["room"]) ?? "",
                Convert.ToString(r["instructor"]) ?? "",
                Convert.ToString(r["status"]) ?? ""))
            .ToList();
    }

    // ---------------------------------------------------------------
    // Curriculum progress
    // ---------------------------------------------------------------

    public CurriculumProgress GetCurriculumProgress(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable student = Sql.Table(connection, null,
            "SELECT program_id, year_level FROM students WHERE student_id = @s;", ("@s", studentId));

        if (student.Rows.Count == 0)
        {
            throw new BusinessRuleException("Student record not found.");
        }

        int programId = Convert.ToInt32(student.Rows[0]["program_id"]);
        int studentYear = Convert.ToInt32(student.Rows[0]["year_level"]);

        DataTable curriculum = Sql.Table(connection, null, """
            SELECT cu.subject_id, cu.year_level, cu.semester, s.subject_code, s.subject_name, s.units
            FROM curriculum cu
            JOIN subjects s ON s.subject_id = cu.subject_id
            WHERE cu.program_id = @p
            ORDER BY cu.year_level, FIELD(cu.semester, '1st Semester', '2nd Semester', 'Summer'), s.subject_code;
            """, ("@p", programId));

        var prerequisites = Sql.Table(connection, null, """
                SELECT p.subject_id, p.prerequisite_subject_id, ps.subject_code
                FROM subject_prerequisites p
                JOIN subjects ps ON ps.subject_id = p.prerequisite_subject_id;
                """)
            .Rows.Cast<DataRow>()
            .GroupBy(r => Convert.ToInt32(r["subject_id"]))
            .ToDictionary(
                g => g.Key,
                g => g.Select(r => (Id: Convert.ToInt32(r["prerequisite_subject_id"]),
                                    Code: Convert.ToString(r["subject_code"]) ?? "")).ToList());

        // Latest published result per subject (the last grade row wins).
        var latestGrade = new Dictionary<int, (string Result, object Grade, string Term)>();

        foreach (DataRow r in Sql.Table(connection, null, """
                     SELECT subject_id, result, final_grade, school_year, semester FROM grades
                     WHERE student_id = @s AND is_published = 1 ORDER BY grade_id;
                     """, ("@s", studentId)).Rows)
        {
            latestGrade[Convert.ToInt32(r["subject_id"])] =
                (Convert.ToString(r["result"]) ?? "", r["final_grade"],
                 r["school_year"] + "|" + r["semester"]);
        }

        var passed = new HashSet<int>(Sql.Table(connection, null, """
                SELECT DISTINCT subject_id FROM grades
                WHERE student_id = @s AND is_published = 1 AND result = 'Passed';
                """, ("@s", studentId))
            .Rows.Cast<DataRow>().Select(r => Convert.ToInt32(r[0])));

        var enrolled = new Dictionary<int, (string Status, string Term)>();

        foreach (DataRow r in Sql.Table(connection, null, """
                     SELECT d.subject_id, e.status, e.school_year, e.semester
                     FROM enrollment_details d
                     JOIN enrollments e ON e.enrollment_id = d.enrollment_id
                     WHERE e.student_id = @s AND e.status IN ('Pending', 'Approved');
                     """, ("@s", studentId)).Rows)
        {
            enrolled[Convert.ToInt32(r["subject_id"])] =
                (Convert.ToString(r["status"]) ?? "", r["school_year"] + "|" + r["semester"]);
        }

        var result = new DataTable();
        result.Columns.Add("year_level", typeof(string));
        result.Columns.Add("semester", typeof(string));
        result.Columns.Add("subject_code", typeof(string));
        result.Columns.Add("subject_name", typeof(string));
        result.Columns.Add("units", typeof(int));
        result.Columns.Add("prerequisites", typeof(string));
        result.Columns.Add("status", typeof(string));
        result.Columns.Add("grade", typeof(string));
        result.Columns.Add("note", typeof(string));

        int completedUnits = 0, totalUnits = 0, remaining = 0, deficiencies = 0;

        foreach (DataRow row in curriculum.Rows)
        {
            int subjectId = Convert.ToInt32(row["subject_id"]);
            int units = Convert.ToInt32(row["units"]);
            int year = Convert.ToInt32(row["year_level"]);

            prerequisites.TryGetValue(subjectId, out var required);
            required ??= new List<(int Id, string Code)>();

            string status;
            string note = "";
            string grade = "";

            if (latestGrade.TryGetValue(subjectId, out var g) && g.Grade != DBNull.Value)
            {
                grade = Convert.ToDecimal(g.Grade).ToString("0.00");
            }

            if (passed.Contains(subjectId))
            {
                status = "Completed";
                completedUnits += units;
            }
            else
            {
                remaining++;

                var missing = required.Where(p => !passed.Contains(p.Id)).Select(p => p.Code).ToList();

                bool isEnrolled = enrolled.TryGetValue(subjectId, out var enrollment);
                bool hasGrade = latestGrade.TryGetValue(subjectId, out var last);

                // A published result for the term the student was enrolled in is final for that
                // enrollment, so it takes priority over the (finished) enrollment itself.
                bool gradedThisEnrollment = isEnrolled && hasGrade && last.Term == enrollment.Term;

                if (isEnrolled && !gradedThisEnrollment)
                {
                    status = enrollment.Status == "Approved" ? "Enrolled" : "Pending approval";
                }
                else if (hasGrade && last.Result == "Failed")
                {
                    status = "Failed - retake";
                    note = "Must be taken again";

                    if (year <= studentYear)
                    {
                        deficiencies++;
                    }
                }
                else if (hasGrade && last.Result == "Dropped")
                {
                    status = "Remaining";
                    note = "Dropped - take again";
                }
                else if (hasGrade && last.Result == "Incomplete")
                {
                    status = "Incomplete";
                    note = "Complete the requirements";
                }
                else if (missing.Count > 0)
                {
                    status = "Prerequisite needed";
                    note = "Needs " + string.Join(", ", missing);

                    if (year <= studentYear)
                    {
                        deficiencies++;
                    }
                }
                else
                {
                    status = "Remaining";
                }
            }

            totalUnits += units;

            result.Rows.Add(
                Academic.YearLabel(year),
                row["semester"],
                row["subject_code"],
                row["subject_name"],
                units,
                string.Join(", ", required.Select(p => p.Code)),
                status,
                grade,
                note);
        }

        return new CurriculumProgress(result, completedUnits, totalUnits, remaining, deficiencies);
    }

    // ---------------------------------------------------------------
    // Announcements
    // ---------------------------------------------------------------

    public DataTable GetAnnouncements(int studentId, int limit = 100)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        using var connection = _database.GetConnection();
        connection.Open();

        return ReadAnnouncements(connection, studentId, limit);
    }

    private static DataTable ReadAnnouncements(
        MySqlConnector.MySqlConnection connection, int studentId, int limit)
    {
        return Sql.Table(connection, null, """
            SELECT a.announcement_id, a.title, a.body, a.created_at,
                   COALESCE(u.full_name, 'Registrar') AS posted_by
            FROM announcements a
            JOIN students st ON st.student_id = @s
            LEFT JOIN users u ON u.user_id = a.posted_by
            WHERE a.is_active = 1
              AND (a.expires_at IS NULL OR a.expires_at >= CURDATE())
              AND (a.program_id IS NULL OR a.program_id = st.program_id)
              AND (a.year_level IS NULL OR a.year_level = st.year_level)
              AND (a.section_id IS NULL OR EXISTS (
                     SELECT 1 FROM enrollment_details d
                     JOIN enrollments e ON e.enrollment_id = d.enrollment_id
                     WHERE e.student_id = st.student_id AND e.status IN ('Pending', 'Approved')
                       AND d.section_id = a.section_id))
            ORDER BY a.created_at DESC, a.announcement_id DESC
            LIMIT @limit;
            """, ("@s", studentId), ("@limit", limit));
    }

    // ---------------------------------------------------------------
    // Home
    // ---------------------------------------------------------------

    public HomeSummary GetHomeSummary(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        // Deadline and requirement reminders come from real dates/data and are created once per term.
        RefreshReminders(studentId);

        AcademicPeriod? period = _periods.GetCurrent();

        using var connection = _database.GetConnection();
        connection.Open();

        StudentProfile profile = ReadProfile(connection, studentId);
        var alerts = new List<string>();
        string status = "Not enrolled";
        int units = 0;

        if (period == null)
        {
            alerts.Add("No enrollment period has been set yet.");
        }
        else
        {
            DateTime today = DateTime.Today;

            if (period.IsOpenOn(today))
            {
                int days = (period.EnrollmentEnd.Date - today).Days;
                alerts.Add($"Enrollment for {period.Label} is open until {period.EnrollmentEnd:MMM d, yyyy}" +
                           (days <= 3 ? $" ({(days == 0 ? "closes today" : days + " day(s) left")})." : "."));
            }
            else if (today < period.EnrollmentStart.Date)
            {
                alerts.Add($"Enrollment for {period.Label} opens on {period.EnrollmentStart:MMM d, yyyy}.");
            }
            else
            {
                alerts.Add($"Enrollment for {period.Label} closed on {period.EnrollmentEnd:MMM d, yyyy}.");
            }

            DataTable latest = Sql.Table(connection, null, """
                SELECT status, total_units, remarks FROM enrollments
                WHERE student_id = @s AND school_year = @sy AND semester = @sem AND status <> 'Cancelled'
                ORDER BY enrollment_id DESC LIMIT 1;
                """, ("@s", studentId), ("@sy", period.SchoolYear), ("@sem", period.Semester));

            if (latest.Rows.Count > 0)
            {
                status = Convert.ToString(latest.Rows[0]["status"]) ?? status;
                units = Convert.ToInt32(latest.Rows[0]["total_units"]);

                if (status == "Returned")
                {
                    alerts.Add("Your enrollment was returned: " + latest.Rows[0]["remarks"] + " Please correct and resubmit.");
                }
                else if (status == "Rejected")
                {
                    alerts.Add("Your enrollment was rejected: " + latest.Rows[0]["remarks"]);
                }
            }
        }

        List<string> missing = MissingProfileFields(profile);

        if (missing.Count > 0)
        {
            alerts.Add("Your profile is missing: " + string.Join(", ", missing) + ". It is required for enrollment.");
        }

        foreach (DataRow r in Sql.Table(connection, null, """
                     SELECT s.subject_code, sec.section_code
                     FROM waitlist w
                     JOIN subjects s ON s.subject_id = w.subject_id
                     JOIN sections sec ON sec.section_id = w.section_id
                     WHERE w.student_id = @s AND w.status = 'Notified';
                     """, ("@s", studentId)).Rows)
        {
            alerts.Add($"A slot opened in {r["section_code"]} for {r["subject_code"]}. Enroll now.");
        }

        CurriculumProgress progress = GetCurriculumProgress(studentId);

        int unread = Sql.Int(connection, null, """
            SELECT COUNT(*) FROM notifications n
            JOIN users u ON u.user_id = n.user_id
            WHERE u.student_id = @s AND u.role = 'Student' AND n.is_read = 0;
            """, ("@s", studentId));

        DataTable recent = Sql.Table(connection, null, """
            SELECT n.notification_id, n.title, n.message, n.created_at, n.is_read, n.link
            FROM notifications n
            JOIN users u ON u.user_id = n.user_id
            WHERE u.student_id = @s AND u.role = 'Student'
            ORDER BY n.created_at DESC, n.notification_id DESC LIMIT 6;
            """, ("@s", studentId));

        return new HomeSummary(
            profile, period, status, units, unread,
            progress.CompletedUnits, progress.TotalUnits, alerts,
            ReadAnnouncements(connection, studentId, 5), recent);
    }

    public static List<string> MissingProfileFields(StudentProfile p)
    {
        var missing = new List<string>();

        if (p.Email.Length == 0) missing.Add("email address");
        if (p.Phone.Length == 0) missing.Add("phone number");
        if (p.Address.Length == 0) missing.Add("address");

        return missing;
    }

    /// <summary>
    /// Creates deadline and requirement notifications from the real academic calendar.
    /// Each message is created once (it is skipped if an identical one already exists).
    /// </summary>
    public void RefreshReminders(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        AcademicPeriod? period = _periods.GetCurrent();

        if (period == null)
        {
            return;
        }

        using var connection = _database.GetConnection();
        connection.Open();

        object? userValue = Sql.Scalar(connection, null,
            "SELECT user_id FROM users WHERE student_id = @s AND role = 'Student' LIMIT 1;",
            ("@s", studentId));

        if (userValue == null)
        {
            return;
        }

        int userId = Convert.ToInt32(userValue);
        DateTime today = DateTime.Today;

        if (period.IsOpenOn(today))
        {
            Remind(connection, userId, "Enrollment is open",
                $"Enrollment for {period.Label} is open until {period.EnrollmentEnd:MMM d, yyyy}.", "enrollment");

            if ((period.EnrollmentEnd.Date - today).Days <= 3)
            {
                Remind(connection, userId, "Enrollment closing soon",
                    $"Enrollment for {period.Label} closes on {period.EnrollmentEnd:MMM d, yyyy}.", "enrollment");
            }

            StudentProfile profile = ReadProfile(connection, studentId);
            List<string> missing = MissingProfileFields(profile);

            bool hasEnrollment = Sql.Int(connection, null, """
                SELECT COUNT(*) FROM enrollments
                WHERE student_id = @s AND school_year = @sy AND semester = @sem
                  AND status IN ('Pending', 'Approved');
                """, ("@s", studentId), ("@sy", period.SchoolYear), ("@sem", period.Semester)) > 0;

            if (missing.Count > 0 && !hasEnrollment)
            {
                Remind(connection, userId, "Missing enrollment requirements",
                    $"Enrollment for {period.Label} requires your {string.Join(", ", missing)}. Update your profile.",
                    "profile");
            }
        }
        else if (period.EnrollmentStart.Date > today && (period.EnrollmentStart.Date - today).Days <= 3)
        {
            Remind(connection, userId, "Enrollment opens soon",
                $"Enrollment for {period.Label} opens on {period.EnrollmentStart:MMM d, yyyy}.", "enrollment");
        }
    }

    private static void Remind(
        MySqlConnector.MySqlConnection connection, int userId, string title, string message, string link)
    {
        Sql.Exec(connection, null, """
            INSERT INTO notifications (user_id, title, message, link)
            SELECT @u, @t, @m, @l FROM DUAL
            WHERE NOT EXISTS (
                SELECT 1 FROM notifications WHERE user_id = @u AND title = @t AND message = @m);
            """, ("@u", userId), ("@t", title), ("@m", message), ("@l", link));
    }
}
