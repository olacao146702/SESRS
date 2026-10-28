using System.Data;
using MySqlConnector;
using SESRS.Data;
using SESRS.Helpers;
using SESRS.Models;

namespace SESRS.Services;

/// <summary>Thrown when an enrollment fails validation; carries every reason and suggestion.</summary>
public sealed class EnrollmentBlockedException : BusinessRuleException
{
    public ValidationResult Result { get; }

    public EnrollmentBlockedException(ValidationResult result)
        : base("Your enrollment cannot be submitted yet:\n- " +
               string.Join("\n- ", result.Issues.Select(i => i.Message)))
    {
        Result = result;
    }
}

public class EnrollmentService
{
    private readonly DatabaseConnection _database = new();
    private readonly AuditService _audit = new();
    private readonly NotificationService _notifications = new();
    private readonly PeriodService _periods = new();

    private const string ActiveStatuses = "('Pending','Approved')";

    private const string ScheduleTextSql = """
        (SELECT GROUP_CONCAT(CONCAT(LEFT(sc.day, 3), ' ', TIME_FORMAT(sc.start_time, '%l:%i %p'), '-',
                                    TIME_FORMAT(sc.end_time, '%l:%i %p'))
                             ORDER BY FIELD(sc.day,'Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday'),
                                      sc.start_time SEPARATOR '; ')
         FROM schedules sc WHERE sc.section_id = d.section_id AND sc.subject_id = d.subject_id)
        """;

    // ===============================================================
    // STUDENT SIDE
    // ===============================================================

    public EnrollmentContext GetContext(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        AcademicPeriod? period = _periods.GetCurrent();

        if (period == null)
        {
            return new EnrollmentContext(null, false,
                "No enrollment period has been set yet. Please check again later.", null, null, null);
        }

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable latest = Sql.Table(connection, null, """
            SELECT enrollment_id, status, remarks
            FROM enrollments
            WHERE student_id = @s AND school_year = @sy AND semester = @sem
              AND status <> 'Cancelled'
            ORDER BY enrollment_id DESC LIMIT 1;
            """, ("@s", studentId), ("@sy", period.SchoolYear), ("@sem", period.Semester));

        bool open = period.IsOpenOn(DateTime.Today);

        string message = open
            ? $"Enrollment for {period.Label} is open until {period.EnrollmentEnd:MMM d, yyyy}."
            : DateTime.Today < period.EnrollmentStart.Date
                ? $"Enrollment for {period.Label} opens on {period.EnrollmentStart:MMM d, yyyy}."
                : $"Enrollment for {period.Label} closed on {period.EnrollmentEnd:MMM d, yyyy}.";

        if (latest.Rows.Count == 0)
        {
            return new EnrollmentContext(period, open, message, null, null, null);
        }

        DataRow row = latest.Rows[0];

        return new EnrollmentContext(
            period, open, message,
            Convert.ToInt32(row["enrollment_id"]),
            Convert.ToString(row["status"]),
            row["remarks"] as string);
    }

    /// <summary>Subjects this student may enroll in this term, with their sections and live slot counts.</summary>
    public List<SubjectOffering> GetOfferings(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        AcademicPeriod period = _periods.GetCurrent()
            ?? throw new BusinessRuleException("No enrollment period has been set yet.");

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable student = Sql.Table(connection, null,
            "SELECT program_id, year_level FROM students WHERE student_id = @s;", ("@s", studentId));

        if (student.Rows.Count == 0)
        {
            throw new BusinessRuleException("Student record not found.");
        }

        int programId = Convert.ToInt32(student.Rows[0]["program_id"]);
        int yearLevel = Convert.ToInt32(student.Rows[0]["year_level"]);

        // This term's subjects for the student's year, plus unfinished subjects of lower years
        // offered in the same semester (back subjects).
        DataTable subjects = Sql.Table(connection, null, """
            SELECT cu.subject_id, cu.year_level, s.subject_code, s.subject_name, s.units,
                   COALESCE((SELECT GROUP_CONCAT(ps.subject_code ORDER BY ps.subject_code SEPARATOR ', ')
                             FROM subject_prerequisites p
                             JOIN subjects ps ON ps.subject_id = p.prerequisite_subject_id
                             WHERE p.subject_id = cu.subject_id), '') AS prerequisites
            FROM curriculum cu
            JOIN subjects s ON s.subject_id = cu.subject_id AND s.status = 'Active'
            WHERE cu.program_id = @p AND cu.semester = @sem AND cu.year_level <= @y
            ORDER BY cu.year_level, s.subject_code;
            """, ("@p", programId), ("@sem", period.Semester), ("@y", yearLevel));

        HashSet<int> completed = GetCompletedSubjects(connection, null, studentId);
        var offerings = new List<SubjectOffering>();

        foreach (DataRow row in subjects.Rows)
        {
            int subjectId = Convert.ToInt32(row["subject_id"]);

            var offering = new SubjectOffering
            {
                SubjectId = subjectId,
                SubjectCode = Convert.ToString(row["subject_code"]) ?? "",
                SubjectName = Convert.ToString(row["subject_name"]) ?? "",
                Units = Convert.ToInt32(row["units"]),
                YearLevel = Convert.ToInt32(row["year_level"]),
                Prerequisites = Convert.ToString(row["prerequisites"]) ?? ""
            };

            if (completed.Contains(subjectId))
            {
                // Completed subjects are listed for reference only.
                offering.Status = OfferingStatus.Completed;
                offering.StatusMessage = "Already completed";
                offerings.Add(offering);
                continue;
            }

            List<string> missing = GetMissingPrerequisites(connection, null, subjectId, completed);

            if (missing.Count > 0)
            {
                offering.Status = OfferingStatus.PrerequisiteMissing;
                offering.StatusMessage = "Requires " + string.Join(", ", missing);
            }

            offering.Sections.AddRange(
                LoadSectionOffers(connection, null, period, programId, subjectId, 0));

            if (offering.Sections.Count == 0 && offering.Status == OfferingStatus.Available)
            {
                offering.Status = OfferingStatus.NoSections;
                offering.StatusMessage = "No sections offered this term";
            }

            offerings.Add(offering);
        }

        return offerings;
    }

    /// <summary>Checks a proposed enrollment without saving it (used for live feedback).</summary>
    public ValidationResult Validate(int studentId, IReadOnlyList<Selection> selections)
    {
        RequireSelf(studentId);

        AcademicPeriod period = _periods.GetCurrent()
            ?? throw new BusinessRuleException("No enrollment period has been set yet.");

        using var connection = _database.GetConnection();
        connection.Open();

        int returnedId = FindReturnedEnrollment(connection, null, studentId, period);

        return ValidateCore(connection, null, studentId, period, selections, returnedId, true);
    }

    /// <summary>Submits (or re-submits a returned) enrollment request. Returns the enrollment id.</summary>
    public int Submit(int studentId, IReadOnlyList<Selection> selections)
    {
        RequireSelf(studentId);

        AcademicPeriod period = _periods.GetCurrent()
            ?? throw new BusinessRuleException("No enrollment period has been set yet.");

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            // Serialize this student's submissions and the sections being claimed so that
            // two students cannot take the last slot at the same time.
            Sql.Scalar(connection, transaction,
                "SELECT student_id FROM students WHERE student_id = @s FOR UPDATE;", ("@s", studentId));

            foreach (int sectionId in selections.Select(s => s.SectionId).Distinct().OrderBy(i => i))
            {
                Sql.Scalar(connection, transaction,
                    "SELECT section_id FROM sections WHERE section_id = @id FOR UPDATE;", ("@id", sectionId));
            }

            int returnedId = FindReturnedEnrollment(connection, transaction, studentId, period);

            ValidationResult result = ValidateCore(
                connection, transaction, studentId, period, selections, returnedId, true);

            if (!result.IsValid)
            {
                throw new EnrollmentBlockedException(result);
            }

            int enrollmentId;

            if (returnedId > 0)
            {
                enrollmentId = returnedId;

                Sql.Exec(connection, transaction, """
                    UPDATE enrollments
                    SET status = 'Pending', submitted_at = NOW(), total_units = @u,
                        remarks = NULL, reviewed_by = NULL, reviewed_at = NULL
                    WHERE enrollment_id = @id;
                    """, ("@u", result.TotalUnits), ("@id", enrollmentId));

                Sql.Exec(connection, transaction,
                    "DELETE FROM enrollment_details WHERE enrollment_id = @id;", ("@id", enrollmentId));
            }
            else
            {
                enrollmentId = (int)Sql.Insert(connection, transaction, """
                    INSERT INTO enrollments (student_id, school_year, semester, status, submitted_at, total_units)
                    VALUES (@s, @sy, @sem, 'Pending', NOW(), @u);
                    """,
                    ("@s", studentId), ("@sy", period.SchoolYear), ("@sem", period.Semester),
                    ("@u", result.TotalUnits));
            }

            foreach (Selection selection in selections)
            {
                Sql.Exec(connection, transaction, """
                    INSERT INTO enrollment_details (enrollment_id, subject_id, section_id, units)
                    VALUES (@e, @sub, @sec, @u);
                    """,
                    ("@e", enrollmentId), ("@sub", selection.SubjectId), ("@sec", selection.SectionId),
                    ("@u", result.UnitsBySubject[selection.SubjectId]));

                Sql.Exec(connection, transaction, """
                    UPDATE waitlist SET status = 'Enrolled'
                    WHERE student_id = @s AND section_id = @sec AND subject_id = @sub
                      AND status IN ('Waiting', 'Notified');
                    """, ("@s", studentId), ("@sec", selection.SectionId), ("@sub", selection.SubjectId));
            }

            DataTable names = Sql.Table(connection, transaction, """
                SELECT u.user_id, CONCAT(s.first_name, ' ', s.last_name) AS name
                FROM students s
                LEFT JOIN users u ON u.student_id = s.student_id AND u.role = 'Student'
                WHERE s.student_id = @s;
                """, ("@s", studentId));

            string studentName = Convert.ToString(names.Rows[0]["name"]) ?? "A student";

            if (names.Rows[0]["user_id"] != DBNull.Value)
            {
                _notifications.Create(connection, transaction,
                    Convert.ToInt32(names.Rows[0]["user_id"]),
                    "Enrollment submitted",
                    $"Your enrollment for {period.Label} ({result.TotalUnits} units) was submitted and is waiting for review.",
                    "enrollment");
            }

            _notifications.NotifyAdmins(connection, transaction,
                "New enrollment request",
                $"{studentName} submitted an enrollment for {period.Label} ({result.TotalUnits} units).",
                "enrollment_review");

            _audit.Log(connection, transaction, "ENROLLMENT_SUBMITTED", "enrollment",
                enrollmentId.ToString(), $"{period.Label}, {result.TotalUnits} units");

            transaction.Commit();
            return enrollmentId;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public DataTable GetMyEnrollments(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT enrollment_id, school_year, semester, status, total_units,
                   submitted_at, reviewed_at, COALESCE(remarks, '') AS remarks
            FROM enrollments
            WHERE student_id = @s
            ORDER BY enrollment_id DESC;
            """, ("@s", studentId));
    }

    public DataTable GetEnrollmentLines(int enrollmentId)
    {
        using var connection = _database.GetConnection();
        connection.Open();

        int ownerId = Sql.Int(connection, null,
            "SELECT student_id FROM enrollments WHERE enrollment_id = @id;", ("@id", enrollmentId));

        if (ownerId == 0)
        {
            return new DataTable();
        }

        Session.RequireStudentSelfOrAdmin(ownerId);

        return Sql.Table(connection, null, $"""
            SELECT d.enrollment_detail_id, s.subject_code, s.subject_name, d.units,
                   sec.section_code,
                   COALESCE({ScheduleTextSql}, 'No schedule') AS schedule,
                   COALESCE((SELECT GROUP_CONCAT(DISTINCT sc.instructor SEPARATOR ', ')
                             FROM schedules sc
                             WHERE sc.section_id = d.section_id AND sc.subject_id = d.subject_id
                               AND sc.instructor IS NOT NULL), '') AS instructor,
                   COALESCE((SELECT GROUP_CONCAT(DISTINCT sc.room SEPARATOR ', ')
                             FROM schedules sc
                             WHERE sc.section_id = d.section_id AND sc.subject_id = d.subject_id
                               AND sc.room IS NOT NULL), '') AS room
            FROM enrollment_details d
            JOIN subjects s ON s.subject_id = d.subject_id
            JOIN sections sec ON sec.section_id = d.section_id
            WHERE d.enrollment_id = @id
            ORDER BY s.subject_code;
            """, ("@id", enrollmentId));
    }

    /// <summary>Selections of a returned enrollment so the student can edit and resubmit.</summary>
    public List<Selection> GetSelections(int enrollmentId)
    {
        using var connection = _database.GetConnection();
        connection.Open();

        int ownerId = Sql.Int(connection, null,
            "SELECT student_id FROM enrollments WHERE enrollment_id = @id;", ("@id", enrollmentId));

        Session.RequireStudentSelfOrAdmin(ownerId);

        return Sql.Table(connection, null,
                "SELECT subject_id, section_id FROM enrollment_details WHERE enrollment_id = @id;",
                ("@id", enrollmentId))
            .Rows.Cast<DataRow>()
            .Select(r => new Selection(Convert.ToInt32(r["subject_id"]), Convert.ToInt32(r["section_id"])))
            .ToList();
    }

    /// <summary>Cancels a request. Students may cancel Pending/Returned; administrators may cancel any open one.</summary>
    public void Cancel(int enrollmentId)
    {
        var user = Session.RequireLogin();

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            DataTable t = Sql.Table(connection, transaction,
                "SELECT student_id, status FROM enrollments WHERE enrollment_id = @id FOR UPDATE;",
                ("@id", enrollmentId));

            if (t.Rows.Count == 0)
            {
                throw new BusinessRuleException("That enrollment no longer exists.");
            }

            int studentId = Convert.ToInt32(t.Rows[0]["student_id"]);
            string status = Convert.ToString(t.Rows[0]["status"]) ?? "";

            Session.RequireStudentSelfOrAdmin(studentId);

            bool allowed = user.Role == "Admin"
                ? status is "Pending" or "Approved" or "Returned"
                : status is "Pending" or "Returned";

            if (!allowed)
            {
                throw new BusinessRuleException(status == "Approved"
                    ? "An approved enrollment can only be changed by the registrar. Please contact the registrar's office."
                    : $"A {status.ToLower()} enrollment cannot be cancelled.");
            }

            ReleaseAndMarkStatus(connection, transaction, enrollmentId, "Cancelled",
                user.Role == "Admin" ? "Cancelled by the registrar" : "Cancelled by the student");

            if (user.Role == "Admin")
            {
                NotifyStudent(connection, transaction, studentId, "Enrollment cancelled",
                    "Your enrollment was cancelled by the registrar.", "enrollment");
            }

            _audit.Log(connection, transaction, "ENROLLMENT_CANCELLED", "enrollment", enrollmentId.ToString());

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    // ---------------------------------------------------------------
    // Waitlist
    // ---------------------------------------------------------------

    public void JoinWaitlist(int studentId, int sectionId, int subjectId)
    {
        RequireSelf(studentId);

        AcademicPeriod period = _periods.GetCurrent()
            ?? throw new BusinessRuleException("No enrollment period has been set yet.");

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            DataTable student = Sql.Table(connection, transaction,
                "SELECT program_id FROM students WHERE student_id = @s AND status = 'Active' FOR UPDATE;",
                ("@s", studentId));

            if (student.Rows.Count == 0)
            {
                throw new BusinessRuleException("Your student record is not active.");
            }

            int programId = Convert.ToInt32(student.Rows[0]["program_id"]);

            SectionOffer? offer = LoadSectionOffers(connection, transaction, period, programId, subjectId, 0)
                .FirstOrDefault(o => o.SectionId == sectionId);

            if (offer == null)
            {
                throw new BusinessRuleException("That section is not offered for your program this term.");
            }

            if (offer.Available > 0)
            {
                throw new BusinessRuleException("This section still has open slots. You can enroll in it directly.");
            }

            if (GetCompletedSubjects(connection, transaction, studentId).Contains(subjectId))
            {
                throw new BusinessRuleException("You have already completed this subject.");
            }

            Sql.Exec(connection, transaction, """
                INSERT INTO waitlist (student_id, section_id, subject_id, status)
                VALUES (@s, @sec, @sub, 'Waiting')
                ON DUPLICATE KEY UPDATE status = 'Waiting', created_at = IF(status = 'Waiting', created_at, NOW());
                """, ("@s", studentId), ("@sec", sectionId), ("@sub", subjectId));

            _audit.Log(connection, transaction, "WAITLIST_JOINED", "section", sectionId.ToString(),
                "Subject " + subjectId);

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void LeaveWaitlist(int studentId, int sectionId, int subjectId)
    {
        RequireSelf(studentId);

        using var connection = _database.GetConnection();
        connection.Open();

        Sql.Exec(connection, null, """
            UPDATE waitlist SET status = 'Removed'
            WHERE student_id = @s AND section_id = @sec AND subject_id = @sub
              AND status IN ('Waiting', 'Notified');
            """, ("@s", studentId), ("@sec", sectionId), ("@sub", subjectId));
    }

    public DataTable GetMyWaitlist(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT w.section_id, w.subject_id, s.subject_code, s.subject_name,
                   sec.section_code, w.status, w.created_at
            FROM waitlist w
            JOIN subjects s ON s.subject_id = w.subject_id
            JOIN sections sec ON sec.section_id = w.section_id
            WHERE w.student_id = @s AND w.status IN ('Waiting', 'Notified')
            ORDER BY w.created_at;
            """, ("@s", studentId));
    }

    // ===============================================================
    // ADMINISTRATOR SIDE
    // ===============================================================

    public DataTable GetEnrollments(string status, string? schoolYear, string? semester)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT e.enrollment_id, COALESCE(s.student_number, '') AS student_number,
                   CONCAT(s.last_name, ', ', s.first_name) AS student_name,
                   p.program_code, s.year_level, e.school_year, e.semester,
                   e.total_units, e.status, e.submitted_at, e.reviewed_at
            FROM enrollments e
            JOIN students s ON s.student_id = e.student_id
            JOIN programs p ON p.program_id = s.program_id
            WHERE (@status = 'All' OR e.status = @status)
              AND (@sy IS NULL OR e.school_year = @sy)
              AND (@sem IS NULL OR e.semester = @sem)
            ORDER BY FIELD(e.status, 'Pending', 'Returned', 'Approved', 'Rejected', 'Cancelled'),
                     e.submitted_at DESC, e.enrollment_id DESC;
            """,
            ("@status", status), ("@sy", schoolYear), ("@sem", semester));
    }

    public int GetTotalEnrollments()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Int(connection, null,
            "SELECT COUNT(*) FROM enrollments WHERE status IN ('Pending', 'Approved');");
    }

    public (string Remarks, string Student, string Term, string Status, int Units) GetSummary(int enrollmentId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable t = Sql.Table(connection, null, """
            SELECT CONCAT(s.first_name, ' ', s.last_name) AS name, e.school_year, e.semester,
                   e.status, e.total_units, COALESCE(e.remarks, '') AS remarks
            FROM enrollments e JOIN students s ON s.student_id = e.student_id
            WHERE e.enrollment_id = @id;
            """, ("@id", enrollmentId));

        if (t.Rows.Count == 0)
        {
            throw new BusinessRuleException("That enrollment no longer exists.");
        }

        DataRow r = t.Rows[0];

        return (Convert.ToString(r["remarks"]) ?? "", Convert.ToString(r["name"]) ?? "",
            $"{r["school_year"]}, {r["semester"]}", Convert.ToString(r["status"]) ?? "",
            Convert.ToInt32(r["total_units"]));
    }

    public void Approve(int enrollmentId, string? remarks)
    {
        Review(enrollmentId, "Approved", remarks, requireRemarks: false);
    }

    public void Reject(int enrollmentId, string remarks)
    {
        Review(enrollmentId, "Rejected", remarks, requireRemarks: true);
    }

    /// <summary>Sends a Pending or Approved enrollment back to the student for correction.</summary>
    public void ReturnForCorrection(int enrollmentId, string remarks)
    {
        Review(enrollmentId, "Returned", remarks, requireRemarks: true);
    }

    private void Review(int enrollmentId, string newStatus, string? remarks, bool requireRemarks)
    {
        var admin = Session.RequireAdmin();

        remarks = string.IsNullOrWhiteSpace(remarks) ? null : remarks.Trim();

        if (requireRemarks && remarks == null)
        {
            throw new BusinessRuleException("Please enter remarks explaining your decision.");
        }

        if (remarks != null && remarks.Length > 255)
        {
            throw new BusinessRuleException("Remarks must be 255 characters or fewer.");
        }

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            DataTable t = Sql.Table(connection, transaction, """
                SELECT student_id, status, school_year, semester
                FROM enrollments WHERE enrollment_id = @id FOR UPDATE;
                """, ("@id", enrollmentId));

            if (t.Rows.Count == 0)
            {
                throw new BusinessRuleException("That enrollment no longer exists.");
            }

            DataRow row = t.Rows[0];
            int studentId = Convert.ToInt32(row["student_id"]);
            string current = Convert.ToString(row["status"]) ?? "";
            string schoolYear = Convert.ToString(row["school_year"]) ?? "";
            string semester = Convert.ToString(row["semester"]) ?? "";

            bool allowed = newStatus switch
            {
                "Approved" => current == "Pending",
                "Rejected" => current == "Pending",
                "Returned" => current is "Pending" or "Approved",
                _ => false
            };

            if (!allowed)
            {
                throw new BusinessRuleException(
                    $"A {current.ToLower()} enrollment cannot be marked {newStatus.ToLower()}.");
            }

            if (newStatus == "Approved")
            {
                AcademicPeriod period = _periods.GetByTerm(connection, transaction, schoolYear, semester)
                    ?? throw new BusinessRuleException("The academic period for this enrollment no longer exists.");

                List<Selection> selections = Sql.Table(connection, transaction,
                        "SELECT subject_id, section_id FROM enrollment_details WHERE enrollment_id = @id;",
                        ("@id", enrollmentId))
                    .Rows.Cast<DataRow>()
                    .Select(r => new Selection(Convert.ToInt32(r["subject_id"]), Convert.ToInt32(r["section_id"])))
                    .ToList();

                // Re-check against current data (grades, schedules, sections may have changed).
                ValidationResult result = ValidateCore(
                    connection, transaction, studentId, period, selections, enrollmentId, false);

                if (!result.IsValid)
                {
                    throw new BusinessRuleException(
                        "This enrollment can no longer be approved:\n- " +
                        string.Join("\n- ", result.Issues.Select(i => i.Message)) +
                        "\nReturn it to the student for correction.");
                }
            }

            if (newStatus is "Rejected" or "Returned")
            {
                ReleaseAndMarkStatus(connection, transaction, enrollmentId, newStatus, remarks);
            }

            Sql.Exec(connection, transaction, """
                UPDATE enrollments
                SET status = @status, reviewed_by = @admin, reviewed_at = NOW(), remarks = @remarks,
                    total_units = (SELECT COALESCE(SUM(units), 0) FROM enrollment_details WHERE enrollment_id = @id)
                WHERE enrollment_id = @id;
                """,
                ("@status", newStatus), ("@admin", admin.UserId), ("@remarks", remarks), ("@id", enrollmentId));

            string term = $"{schoolYear}, {semester}";
            string suffix = remarks == null ? "" : " Remarks: " + remarks;

            (string title, string text) = newStatus switch
            {
                "Approved" => ("Enrollment approved",
                    $"Your enrollment for {term} was approved. Your schedule is now available." + suffix),
                "Rejected" => ("Enrollment rejected",
                    $"Your enrollment for {term} was rejected." + suffix),
                _ => ("Enrollment returned for correction",
                    $"Your enrollment for {term} needs correction. Please update and resubmit." + suffix)
            };

            NotifyStudent(connection, transaction, studentId, title, text,
                newStatus == "Approved" ? "schedule" : "enrollment");

            _audit.Log(connection, transaction, "ENROLLMENT_" + newStatus.ToUpper(), "enrollment",
                enrollmentId.ToString(), remarks);

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>Class list for a section's subject (approved enrollments).</summary>
    public DataTable GetClassList(int sectionId, int subjectId, bool includePending)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT COALESCE(s.student_number, '') AS student_number,
                   CONCAT(s.last_name, ', ', s.first_name, ' ', COALESCE(s.middle_name, '')) AS student_name,
                   p.program_code, s.year_level, e.status
            FROM enrollment_details d
            JOIN enrollments e ON e.enrollment_id = d.enrollment_id
            JOIN students s ON s.student_id = e.student_id
            JOIN programs p ON p.program_id = s.program_id
            WHERE d.section_id = @sec AND d.subject_id = @sub
              AND (e.status = 'Approved' OR (@pending = 1 AND e.status = 'Pending'))
            ORDER BY s.last_name, s.first_name;
            """, ("@sec", sectionId), ("@sub", subjectId), ("@pending", includePending ? 1 : 0));
    }

    // ===============================================================
    // VALIDATION ENGINE
    // ===============================================================

    private ValidationResult ValidateCore(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        int studentId,
        AcademicPeriod period,
        IReadOnlyList<Selection> selections,
        int ignoreEnrollmentId,
        bool checkWindow)
    {
        var result = new ValidationResult();

        // ---- the student ------------------------------------------------------------
        DataTable studentTable = Sql.Table(connection, transaction, """
            SELECT student_number, status, program_id, year_level, email, phone, address
            FROM students WHERE student_id = @s;
            """, ("@s", studentId));

        if (studentTable.Rows.Count == 0)
        {
            throw new BusinessRuleException("Student record not found.");
        }

        DataRow student = studentTable.Rows[0];
        int programId = Convert.ToInt32(student["program_id"]);
        int studentYear = Convert.ToInt32(student["year_level"]);

        if (Convert.ToString(student["status"]) != "Active")
        {
            result.Issues.Add(new ValidationIssue(
                "Your student record is not active. Please contact the registrar's office."));
        }

        var missingRequirements = new List<string>();

        if (student["student_number"] == DBNull.Value) missingRequirements.Add("student number");
        if (string.IsNullOrWhiteSpace(student["email"] as string)) missingRequirements.Add("email address");
        if (string.IsNullOrWhiteSpace(student["phone"] as string)) missingRequirements.Add("phone number");
        if (string.IsNullOrWhiteSpace(student["address"] as string)) missingRequirements.Add("address");

        if (missingRequirements.Count > 0)
        {
            result.Issues.Add(new ValidationIssue(
                "Your profile is incomplete (missing " + string.Join(", ", missingRequirements) +
                "). Please complete it before enrolling."));
        }

        // ---- the enrollment period ---------------------------------------------------
        if (checkWindow && !period.IsOpenOn(DateTime.Today))
        {
            result.Issues.Add(new ValidationIssue(
                $"Enrollment for {period.Label} is not open today. It runs from " +
                $"{period.EnrollmentStart:MMM d, yyyy} to {period.EnrollmentEnd:MMM d, yyyy}."));
        }

        // ---- duplicate submission ---------------------------------------------------
        DataTable existing = Sql.Table(connection, transaction, $"""
            SELECT status FROM enrollments
            WHERE student_id = @s AND school_year = @sy AND semester = @sem
              AND status IN {ActiveStatuses} AND enrollment_id <> @ignore
            LIMIT 1;
            """,
            ("@s", studentId), ("@sy", period.SchoolYear), ("@sem", period.Semester),
            ("@ignore", ignoreEnrollmentId));

        if (existing.Rows.Count > 0)
        {
            result.Issues.Add(new ValidationIssue(
                $"You already have a {Convert.ToString(existing.Rows[0]["status"])!.ToLower()} enrollment " +
                $"for {period.Label}. Cancel it first if you need to change your subjects."));
            return result;
        }

        // ---- selection basics -------------------------------------------------------
        if (selections.Count == 0)
        {
            result.Issues.Add(new ValidationIssue("Select at least one subject."));
            return result;
        }

        foreach (var group in selections.GroupBy(s => s.SubjectId).Where(g => g.Count() > 1))
        {
            result.Issues.Add(new ValidationIssue(
                "The same subject was selected more than once.", group.Key));
        }

        if (result.Issues.Any(i => i.Message.StartsWith("The same subject")))
        {
            return result;
        }

        string subjectIds = string.Join(",", selections.Select(s => s.SubjectId));

        // ---- curriculum membership, status, units ------------------------------------
        DataTable curriculum = Sql.Table(connection, transaction, $"""
            SELECT cu.subject_id, cu.year_level, cu.semester, s.subject_code, s.subject_name,
                   s.units, s.status
            FROM curriculum cu
            JOIN subjects s ON s.subject_id = cu.subject_id
            WHERE cu.program_id = @p AND cu.subject_id IN ({subjectIds});
            """, ("@p", programId));

        var byId = curriculum.Rows.Cast<DataRow>()
            .ToDictionary(r => Convert.ToInt32(r["subject_id"]));

        HashSet<int> completed = GetCompletedSubjects(connection, transaction, studentId);
        var labels = new Dictionary<int, string>();
        var meetingsBySubject = new Dictionary<int, List<MeetingTime>>();

        foreach (Selection selection in selections)
        {
            if (!byId.TryGetValue(selection.SubjectId, out DataRow? subject))
            {
                result.Issues.Add(new ValidationIssue(
                    "A selected subject is not part of your program's curriculum.", selection.SubjectId));
                continue;
            }

            string code = Convert.ToString(subject["subject_code"]) ?? "";
            labels[selection.SubjectId] = code;
            result.UnitsBySubject[selection.SubjectId] = Convert.ToInt32(subject["units"]);

            if (Convert.ToString(subject["status"]) != "Active")
            {
                result.Issues.Add(new ValidationIssue($"{code} is not available for enrollment.", selection.SubjectId));
                continue;
            }

            if (Convert.ToString(subject["semester"]) != period.Semester ||
                Convert.ToInt32(subject["year_level"]) > studentYear)
            {
                result.Issues.Add(new ValidationIssue(
                    $"{code} is not offered to your year level in {period.Semester}.", selection.SubjectId));
                continue;
            }

            if (completed.Contains(selection.SubjectId))
            {
                result.Issues.Add(new ValidationIssue(
                    $"{code} was already completed and cannot be taken again.", selection.SubjectId));
                continue;
            }

            List<string> missing = GetMissingPrerequisites(connection, transaction, selection.SubjectId, completed);

            if (missing.Count > 0)
            {
                result.Issues.Add(new ValidationIssue(
                    $"{code} requires {string.Join(", ", missing)}, which you have not completed.",
                    selection.SubjectId));
            }
        }

        // ---- sections: ownership, schedule, capacity ---------------------------------
        foreach (Selection selection in selections)
        {
            if (!labels.TryGetValue(selection.SubjectId, out string? code))
            {
                continue;
            }

            DataTable section = Sql.Table(connection, transaction, """
                SELECT section_code, program_id, semester, school_year, capacity, status
                FROM sections WHERE section_id = @id;
                """, ("@id", selection.SectionId));

            if (section.Rows.Count == 0 ||
                Convert.ToInt32(section.Rows[0]["program_id"]) != programId ||
                Convert.ToString(section.Rows[0]["semester"]) != period.Semester ||
                Convert.ToString(section.Rows[0]["school_year"]) != period.SchoolYear ||
                Convert.ToString(section.Rows[0]["status"]) != "Active")
            {
                result.Issues.Add(new ValidationIssue(
                    $"The section chosen for {code} is not available this term.", selection.SubjectId,
                    AlternativeSections(connection, transaction, period, programId, selection.SubjectId,
                        selection.SectionId, new List<MeetingTime>(), ignoreEnrollmentId)));
                continue;
            }

            string sectionCode = Convert.ToString(section.Rows[0]["section_code"]) ?? "";

            List<MeetingTime> meetings = LoadMeetings(connection, transaction, selection.SectionId, selection.SubjectId);

            if (meetings.Count == 0)
            {
                result.Issues.Add(new ValidationIssue(
                    $"Section {sectionCode} does not offer {code}.", selection.SubjectId,
                    AlternativeSections(connection, transaction, period, programId, selection.SubjectId,
                        selection.SectionId, new List<MeetingTime>(), ignoreEnrollmentId)));
                continue;
            }

            meetingsBySubject[selection.SubjectId] = meetings;

            int taken = CountTaken(connection, transaction, selection.SectionId, selection.SubjectId, ignoreEnrollmentId);
            int capacity = Convert.ToInt32(section.Rows[0]["capacity"]);

            if (taken >= capacity)
            {
                List<string> alternatives = AlternativeSections(connection, transaction, period, programId,
                    selection.SubjectId, selection.SectionId, new List<MeetingTime>(), ignoreEnrollmentId);

                alternatives.Add("You can also join the waitlist for " + sectionCode + " and be notified if a slot opens.");

                result.Issues.Add(new ValidationIssue(
                    $"Section {sectionCode} is full for {code} ({taken}/{capacity}).",
                    selection.SubjectId, alternatives));
            }
        }

        // ---- schedule overlaps ---------------------------------------------------------
        var scheduled = selections.Where(s => meetingsBySubject.ContainsKey(s.SubjectId)).ToList();

        for (int i = 0; i < scheduled.Count; i++)
        {
            for (int j = i + 1; j < scheduled.Count; j++)
            {
                MeetingTime? a = null, b = null;

                foreach (MeetingTime x in meetingsBySubject[scheduled[i].SubjectId])
                {
                    foreach (MeetingTime y in meetingsBySubject[scheduled[j].SubjectId])
                    {
                        if (x.Overlaps(y))
                        {
                            a = x;
                            b = y;
                        }
                    }
                }

                if (a == null || b == null)
                {
                    continue;
                }

                int subjectJ = scheduled[j].SubjectId;

                var others = scheduled
                    .Where(s => s.SubjectId != subjectJ)
                    .SelectMany(s => meetingsBySubject[s.SubjectId])
                    .ToList();

                result.Issues.Add(new ValidationIssue(
                    $"Schedule conflict: {labels[scheduled[i].SubjectId]} ({a.Text}) overlaps " +
                    $"{labels[subjectJ]} ({b.Text}).",
                    subjectJ,
                    AlternativeSections(connection, transaction, period, programId, subjectJ,
                        scheduled[j].SectionId, others, ignoreEnrollmentId)));
            }
        }

        // ---- units -----------------------------------------------------------------------
        int total = result.TotalUnits;

        if (total > period.MaxUnits)
        {
            result.Issues.Add(new ValidationIssue(
                $"Your selection is {total} units, above the maximum of {period.MaxUnits}. Remove a subject."));
        }
        else if (total < period.MinUnits)
        {
            result.Issues.Add(new ValidationIssue(
                $"Your selection is {total} units, below the minimum of {period.MinUnits}. Add more subjects, " +
                "or ask the registrar if you are finishing your program."));
        }

        return result;
    }

    // ---------------------------------------------------------------
    // Helpers
    // ---------------------------------------------------------------

    private static void RequireSelf(int studentId)
    {
        var user = Session.RequireLogin();

        if (user.Role != "Student" || user.StudentId != studentId)
        {
            throw new UnauthorizedAccessException("Only the student can enroll for themselves.");
        }
    }

    private static int FindReturnedEnrollment(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        int studentId,
        AcademicPeriod period)
    {
        return Sql.Int(connection, transaction, """
            SELECT enrollment_id FROM enrollments
            WHERE student_id = @s AND school_year = @sy AND semester = @sem AND status = 'Returned'
            ORDER BY enrollment_id DESC LIMIT 1;
            """, ("@s", studentId), ("@sy", period.SchoolYear), ("@sem", period.Semester));
    }

    private static HashSet<int> GetCompletedSubjects(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        int studentId)
    {
        return Sql.Table(connection, transaction, """
                SELECT DISTINCT subject_id FROM grades
                WHERE student_id = @s AND is_published = 1 AND result = 'Passed';
                """, ("@s", studentId))
            .Rows.Cast<DataRow>()
            .Select(r => Convert.ToInt32(r[0]))
            .ToHashSet();
    }

    private static List<string> GetMissingPrerequisites(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        int subjectId,
        HashSet<int> completed)
    {
        return Sql.Table(connection, transaction, """
                SELECT p.prerequisite_subject_id, s.subject_code
                FROM subject_prerequisites p
                JOIN subjects s ON s.subject_id = p.prerequisite_subject_id
                WHERE p.subject_id = @id ORDER BY s.subject_code;
                """, ("@id", subjectId))
            .Rows.Cast<DataRow>()
            .Where(r => !completed.Contains(Convert.ToInt32(r["prerequisite_subject_id"])))
            .Select(r => Convert.ToString(r["subject_code"]) ?? "")
            .ToList();
    }

    private static List<MeetingTime> LoadMeetings(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        int sectionId,
        int subjectId)
    {
        return Sql.Table(connection, transaction, """
                SELECT day, start_time, end_time, room, instructor
                FROM schedules
                WHERE section_id = @sec AND subject_id = @sub
                ORDER BY FIELD(day,'Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday'),
                         start_time;
                """, ("@sec", sectionId), ("@sub", subjectId))
            .Rows.Cast<DataRow>()
            .Select(r => new MeetingTime(
                Convert.ToString(r["day"]) ?? "",
                (TimeSpan)r["start_time"],
                (TimeSpan)r["end_time"],
                r["room"] as string,
                r["instructor"] as string))
            .ToList();
    }

    private static int CountTaken(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        int sectionId,
        int subjectId,
        int ignoreEnrollmentId)
    {
        return Sql.Int(connection, transaction, $"""
            SELECT COUNT(*)
            FROM enrollment_details d
            JOIN enrollments e ON e.enrollment_id = d.enrollment_id
            WHERE d.section_id = @sec AND d.subject_id = @sub
              AND e.status IN {ActiveStatuses} AND e.enrollment_id <> @ignore;
            """, ("@sec", sectionId), ("@sub", subjectId), ("@ignore", ignoreEnrollmentId));
    }

    private List<SectionOffer> LoadSectionOffers(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        AcademicPeriod period,
        int programId,
        int subjectId,
        int ignoreEnrollmentId)
    {
        DataTable sections = Sql.Table(connection, transaction, """
            SELECT sec.section_id, sec.section_code, sec.section_name, sec.capacity
            FROM sections sec
            WHERE sec.program_id = @p AND sec.semester = @sem AND sec.school_year = @sy
              AND sec.status = 'Active'
              AND EXISTS (SELECT 1 FROM schedules sc
                          WHERE sc.section_id = sec.section_id AND sc.subject_id = @sub)
            ORDER BY sec.section_code;
            """,
            ("@p", programId), ("@sem", period.Semester), ("@sy", period.SchoolYear), ("@sub", subjectId));

        var offers = new List<SectionOffer>();

        foreach (DataRow row in sections.Rows)
        {
            int sectionId = Convert.ToInt32(row["section_id"]);

            offers.Add(new SectionOffer
            {
                SectionId = sectionId,
                SectionCode = Convert.ToString(row["section_code"]) ?? "",
                SectionName = Convert.ToString(row["section_name"]) ?? "",
                Capacity = Convert.ToInt32(row["capacity"]),
                Taken = CountTaken(connection, transaction, sectionId, subjectId, ignoreEnrollmentId),
                Meetings = LoadMeetings(connection, transaction, sectionId, subjectId)
            });
        }

        return offers;
    }

    /// <summary>Other sections of the subject with free slots that do not clash with the given meetings.</summary>
    private List<string> AlternativeSections(
        MySqlConnection connection,
        MySqlTransaction? transaction,
        AcademicPeriod period,
        int programId,
        int subjectId,
        int excludeSectionId,
        List<MeetingTime> otherMeetings,
        int ignoreEnrollmentId)
    {
        return LoadSectionOffers(connection, transaction, period, programId, subjectId, ignoreEnrollmentId)
            .Where(o => o.SectionId != excludeSectionId
                        && o.Available > 0
                        && !o.Meetings.Any(m => otherMeetings.Any(m.Overlaps)))
            .Select(o => $"Try section {o.SectionCode}: {o.ScheduleText} ({o.Available} slot(s) left)")
            .ToList();
    }

    private void ReleaseAndMarkStatus(
        MySqlConnection connection,
        MySqlTransaction transaction,
        int enrollmentId,
        string status,
        string? remarks)
    {
        // Pending and Approved enrollments hold slots; releasing one may let a waitlisted student in.
        DataTable held = Sql.Table(connection, transaction,
            "SELECT section_id, subject_id FROM enrollment_details WHERE enrollment_id = @id;",
            ("@id", enrollmentId));

        Sql.Exec(connection, transaction,
            "UPDATE enrollments SET status = @st, remarks = @r WHERE enrollment_id = @id;",
            ("@st", status), ("@r", remarks), ("@id", enrollmentId));

        foreach (DataRow row in held.Rows)
        {
            NotifyWaitlist(connection, transaction,
                Convert.ToInt32(row["section_id"]), Convert.ToInt32(row["subject_id"]));
        }
    }

    private void NotifyWaitlist(
        MySqlConnection connection,
        MySqlTransaction transaction,
        int sectionId,
        int subjectId)
    {
        DataTable info = Sql.Table(connection, transaction, """
            SELECT sec.section_code, sec.capacity, s.subject_code
            FROM sections sec, subjects s
            WHERE sec.section_id = @sec AND s.subject_id = @sub;
            """, ("@sec", sectionId), ("@sub", subjectId));

        if (info.Rows.Count == 0)
        {
            return;
        }

        int free = Convert.ToInt32(info.Rows[0]["capacity"]) -
                   CountTaken(connection, transaction, sectionId, subjectId, 0);

        // Count people already told about a slot so we do not over-promise.
        free -= Sql.Int(connection, transaction, """
            SELECT COUNT(*) FROM waitlist
            WHERE section_id = @sec AND subject_id = @sub AND status = 'Notified';
            """, ("@sec", sectionId), ("@sub", subjectId));

        if (free <= 0)
        {
            return;
        }

        DataTable next = Sql.Table(connection, transaction, """
            SELECT w.waitlist_id, u.user_id
            FROM waitlist w
            JOIN users u ON u.student_id = w.student_id AND u.role = 'Student'
            WHERE w.section_id = @sec AND w.subject_id = @sub AND w.status = 'Waiting'
            ORDER BY w.created_at, w.waitlist_id
            LIMIT @free;
            """, ("@sec", sectionId), ("@sub", subjectId), ("@free", free));

        foreach (DataRow row in next.Rows)
        {
            Sql.Exec(connection, transaction,
                "UPDATE waitlist SET status = 'Notified' WHERE waitlist_id = @id;",
                ("@id", row["waitlist_id"]));

            _notifications.Create(connection, transaction, Convert.ToInt32(row["user_id"]),
                "A slot opened",
                $"A slot is available in section {info.Rows[0]["section_code"]} for {info.Rows[0]["subject_code"]}. " +
                "Enroll now before it is taken.",
                "enrollment");
        }
    }

    private void NotifyStudent(
        MySqlConnection connection,
        MySqlTransaction transaction,
        int studentId,
        string title,
        string message,
        string link)
    {
        object? userId = Sql.Scalar(connection, transaction,
            "SELECT user_id FROM users WHERE student_id = @s AND role = 'Student' LIMIT 1;",
            ("@s", studentId));

        if (userId != null)
        {
            _notifications.Create(connection, transaction, Convert.ToInt32(userId), title, message, link);
        }
    }
}
