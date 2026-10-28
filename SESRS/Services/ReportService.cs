using System.Data;
using SESRS.Data;
using SESRS.Helpers;

namespace SESRS.Services;

public sealed record ReportFilter(
    string? SchoolYear,
    string? Semester,
    int? ProgramId,
    int? YearLevel,
    int? SectionId);

public sealed record ReportDefinition(
    string Key,
    string Name,
    string Description,
    bool UsesTerm,
    bool UsesProgram,
    bool UsesYear,
    bool UsesSection,
    bool Landscape = true);

public sealed record ReportResult(string Title, string Subtitle, DataTable Table, bool Landscape);

/// <summary>Administrator reports. Every report is role-protected and read-only.</summary>
public class ReportService
{
    private readonly DatabaseConnection _database = new();
    private readonly PeriodService _periods = new();

    public static readonly IReadOnlyList<ReportDefinition> Definitions = new List<ReportDefinition>
    {
        new("students", "Student Master List",
            "Every student with program, year level and status.", false, true, true, false),
        new("enrollment_summary", "Enrollment Summary",
            "Enrollment requests by program and year level for a term, with approved units.", true, true, true, false),
        new("section_capacity", "Section Capacities",
            "Slots used and remaining for every subject of every section in a term.", true, true, true, true),
        new("class_list", "Class Lists",
            "Students enrolled in each subject of a section (approved and pending).", true, false, false, true),
        new("subject_enrollment", "Subject Enrollment",
            "Number of students enrolled in each subject for a term.", true, true, false, false),
        new("grade_sheets", "Grade Sheets",
            "Grades of a term by section and subject, including their review status.", true, false, false, true),
        new("performance", "Academic Performance",
            "General weighted average, units earned and failed subjects per student (published grades).", false, true, true, false),
        new("incomplete_enrollment", "Pending or Incomplete Enrollment",
            "Active students without an approved enrollment this term, and what is missing.", true, true, true, false),
        new("curriculum_completion", "Curriculum Completion",
            "Completed units, percent complete and remaining subjects per student.", false, true, true, false)
    };

    public ReportResult Run(string key, ReportFilter filter)
    {
        Session.RequireAdmin();

        ReportDefinition definition = Definitions.FirstOrDefault(d => d.Key == key)
            ?? throw new BusinessRuleException("Unknown report.");

        using var connection = _database.GetConnection();
        connection.Open();

        string? schoolYear = filter.SchoolYear;
        string? semester = filter.Semester;

        if (definition.UsesTerm && (schoolYear == null || semester == null))
        {
            var current = _periods.GetCurrent()
                ?? throw new BusinessRuleException("Choose a term. No current term has been set.");

            schoolYear = current.SchoolYear;
            semester = current.Semester;
        }

        var parameters = new (string, object?)[]
        {
            ("@sy", schoolYear), ("@sem", semester), ("@p", filter.ProgramId),
            ("@y", filter.YearLevel), ("@sec", filter.SectionId)
        };

        string query = key switch
        {
            "students" => StudentsSql,
            "enrollment_summary" => EnrollmentSummarySql,
            "section_capacity" => SectionCapacitySql,
            "class_list" => ClassListSql,
            "subject_enrollment" => SubjectEnrollmentSql,
            "grade_sheets" => GradeSheetsSql,
            "performance" => PerformanceSql,
            "incomplete_enrollment" => IncompleteSql,
            _ => CurriculumCompletionSql
        };

        DataTable table = Sql.Table(connection, null, query, parameters);

        string subtitle = definition.UsesTerm ? $"{schoolYear}, {semester}" : "As of " + DateTime.Today.ToString("MMM d, yyyy");

        new AuditService().Log(connection, null, "REPORT_RUN", "report", key, $"{table.Rows.Count} row(s)");

        return new ReportResult(definition.Name, subtitle, table, definition.Landscape);
    }

    // ---------------------------------------------------------------
    // Queries. Optional filters use "(@x IS NULL OR column = @x)".
    // ---------------------------------------------------------------

    private const string StudentsSql = """
        SELECT COALESCE(s.student_number, '') AS student_number,
               CONCAT(s.last_name, ', ', s.first_name, ' ', COALESCE(s.middle_name, '')) AS student_name,
               s.gender, p.program_code, s.year_level, s.status,
               COALESCE(s.email, '') AS email, COALESCE(s.phone, '') AS phone
        FROM students s
        JOIN programs p ON p.program_id = s.program_id
        WHERE (@p IS NULL OR s.program_id = @p) AND (@y IS NULL OR s.year_level = @y)
        ORDER BY s.last_name, s.first_name;
        """;

    private const string EnrollmentSummarySql = """
        SELECT p.program_code, s.year_level,
               COALESCE(SUM(e.status = 'Pending'), 0) AS pending,
               COALESCE(SUM(e.status = 'Approved'), 0) AS approved,
               COALESCE(SUM(e.status = 'Returned'), 0) AS returned,
               COALESCE(SUM(e.status = 'Rejected'), 0) AS rejected,
               COALESCE(SUM(e.status = 'Cancelled'), 0) AS cancelled,
               COUNT(*) AS total_requests,
               COALESCE(SUM(CASE WHEN e.status = 'Approved' THEN e.total_units END), 0) AS approved_units
        FROM enrollments e
        JOIN students s ON s.student_id = e.student_id
        JOIN programs p ON p.program_id = s.program_id
        WHERE e.school_year = @sy AND e.semester = @sem
          AND (@p IS NULL OR s.program_id = @p) AND (@y IS NULL OR s.year_level = @y)
        GROUP BY p.program_code, s.year_level
        ORDER BY p.program_code, s.year_level;
        """;

    private const string SectionCapacitySql = """
        SELECT sec.section_code, p.program_code, sec.year_level, sub.subject_code,
               sec.capacity,
               COALESCE(SUM(e.status = 'Approved'), 0) AS approved,
               COALESCE(SUM(e.status = 'Pending'), 0) AS pending,
               sec.capacity - COALESCE(SUM(e.enrollment_id IS NOT NULL), 0) AS slots_left
        FROM sections sec
        JOIN programs p ON p.program_id = sec.program_id
        JOIN (SELECT DISTINCT section_id, subject_id FROM schedules) ss ON ss.section_id = sec.section_id
        JOIN subjects sub ON sub.subject_id = ss.subject_id
        LEFT JOIN enrollment_details d ON d.section_id = ss.section_id AND d.subject_id = ss.subject_id
        LEFT JOIN enrollments e ON e.enrollment_id = d.enrollment_id AND e.status IN ('Approved', 'Pending')
        WHERE sec.school_year = @sy AND sec.semester = @sem
          AND (@p IS NULL OR sec.program_id = @p) AND (@y IS NULL OR sec.year_level = @y)
          AND (@sec IS NULL OR sec.section_id = @sec)
        GROUP BY sec.section_id, sec.section_code, p.program_code, sec.year_level, sub.subject_id,
                 sub.subject_code, sec.capacity
        ORDER BY sec.section_code, sub.subject_code;
        """;

    private const string ClassListSql = """
        SELECT sec.section_code, sub.subject_code, sub.subject_name,
               COALESCE(s.student_number, '') AS student_number,
               CONCAT(s.last_name, ', ', s.first_name) AS student_name,
               p.program_code, s.year_level, e.status
        FROM enrollment_details d
        JOIN enrollments e ON e.enrollment_id = d.enrollment_id AND e.status IN ('Approved', 'Pending')
        JOIN students s ON s.student_id = e.student_id
        JOIN programs p ON p.program_id = s.program_id
        JOIN sections sec ON sec.section_id = d.section_id
        JOIN subjects sub ON sub.subject_id = d.subject_id
        WHERE e.school_year = @sy AND e.semester = @sem AND (@sec IS NULL OR d.section_id = @sec)
        ORDER BY sec.section_code, sub.subject_code, s.last_name, s.first_name;
        """;

    private const string SubjectEnrollmentSql = """
        SELECT sub.subject_code, sub.subject_name, sub.units,
               COUNT(DISTINCT d.section_id) AS sections,
               COALESCE(SUM(e.status = 'Approved'), 0) AS approved,
               COALESCE(SUM(e.status = 'Pending'), 0) AS pending,
               COUNT(*) AS total_students
        FROM enrollment_details d
        JOIN enrollments e ON e.enrollment_id = d.enrollment_id AND e.status IN ('Approved', 'Pending')
        JOIN students s ON s.student_id = e.student_id
        JOIN subjects sub ON sub.subject_id = d.subject_id
        WHERE e.school_year = @sy AND e.semester = @sem AND (@p IS NULL OR s.program_id = @p)
        GROUP BY sub.subject_id, sub.subject_code, sub.subject_name, sub.units
        ORDER BY total_students DESC, sub.subject_code;
        """;

    private const string GradeSheetsSql = """
        SELECT COALESCE(sec.section_code, '') AS section_code, sub.subject_code,
               COALESCE(s.student_number, '') AS student_number,
               CONCAT(s.last_name, ', ', s.first_name) AS student_name,
               g.percent, g.final_grade, g.result, g.grade_status AS status
        FROM grades g
        JOIN students s ON s.student_id = g.student_id
        JOIN subjects sub ON sub.subject_id = g.subject_id
        LEFT JOIN sections sec ON sec.section_id = g.section_id
        WHERE g.school_year = @sy AND g.semester = @sem AND (@sec IS NULL OR g.section_id = @sec)
        ORDER BY sec.section_code, sub.subject_code, s.last_name, s.first_name;
        """;

    private const string PerformanceSql = """
        SELECT COALESCE(s.student_number, '') AS student_number,
               CONCAT(s.last_name, ', ', s.first_name) AS student_name,
               p.program_code, s.year_level,
               ROUND(SUM(g.final_grade * sub.units) /
                     NULLIF(SUM(CASE WHEN g.final_grade IS NOT NULL THEN sub.units END), 0), 2) AS weighted_average,
               COALESCE(SUM(CASE WHEN g.result = 'Passed' THEN sub.units END), 0) AS units_earned,
               COALESCE(SUM(CASE WHEN g.final_grade IS NOT NULL THEN sub.units END), 0) AS units_graded,
               COALESCE(SUM(g.result = 'Failed'), 0) AS failed_subjects
        FROM students s
        JOIN programs p ON p.program_id = s.program_id
        LEFT JOIN grades g ON g.student_id = s.student_id AND g.is_published = 1
        LEFT JOIN subjects sub ON sub.subject_id = g.subject_id
        WHERE s.status = 'Active' AND (@p IS NULL OR s.program_id = @p) AND (@y IS NULL OR s.year_level = @y)
        GROUP BY s.student_id, s.student_number, s.last_name, s.first_name, p.program_code, s.year_level
        ORDER BY s.last_name, s.first_name;
        """;

    private const string IncompleteSql = """
        SELECT COALESCE(s.student_number, '') AS student_number,
               CONCAT(s.last_name, ', ', s.first_name) AS student_name,
               p.program_code, s.year_level,
               COALESCE((SELECT e.status FROM enrollments e
                         WHERE e.student_id = s.student_id AND e.school_year = @sy AND e.semester = @sem
                           AND e.status <> 'Cancelled'
                         ORDER BY e.enrollment_id DESC LIMIT 1), 'Not enrolled') AS enrollment_status,
               COALESCE((SELECT e.remarks FROM enrollments e
                         WHERE e.student_id = s.student_id AND e.school_year = @sy AND e.semester = @sem
                           AND e.status <> 'Cancelled'
                         ORDER BY e.enrollment_id DESC LIMIT 1), '') AS remarks,
               COALESCE(CONCAT_WS(', ',
                   IF(s.email IS NULL OR s.email = '', 'email', NULL),
                   IF(s.phone IS NULL OR s.phone = '', 'phone', NULL),
                   IF(s.address IS NULL OR s.address = '', 'address', NULL)), '') AS missing_profile
        FROM students s
        JOIN programs p ON p.program_id = s.program_id
        WHERE s.status = 'Active'
          AND NOT EXISTS (SELECT 1 FROM enrollments e
                          WHERE e.student_id = s.student_id AND e.school_year = @sy
                            AND e.semester = @sem AND e.status = 'Approved')
          AND (@p IS NULL OR s.program_id = @p) AND (@y IS NULL OR s.year_level = @y)
        ORDER BY s.last_name, s.first_name;
        """;

    private const string CurriculumCompletionSql = """
        SELECT COALESCE(s.student_number, '') AS student_number,
               CONCAT(s.last_name, ', ', s.first_name) AS student_name,
               p.program_code, s.year_level,
               tot.total_units,
               COALESCE(done.units, 0) AS completed_units,
               ROUND(100 * COALESCE(done.units, 0) / NULLIF(tot.total_units, 0), 1) AS percent_complete,
               tot.subject_count - COALESCE(done.subject_count, 0) AS remaining_subjects
        FROM students s
        JOIN programs p ON p.program_id = s.program_id
        JOIN (SELECT cu.program_id, SUM(sub.units) AS total_units, COUNT(*) AS subject_count
              FROM curriculum cu JOIN subjects sub ON sub.subject_id = cu.subject_id
              GROUP BY cu.program_id) tot ON tot.program_id = s.program_id
        LEFT JOIN (SELECT st.student_id, SUM(sub.units) AS units, COUNT(*) AS subject_count
                   FROM (SELECT DISTINCT student_id, subject_id FROM grades
                         WHERE is_published = 1 AND result = 'Passed') g
                   JOIN students st ON st.student_id = g.student_id
                   JOIN curriculum cu ON cu.program_id = st.program_id AND cu.subject_id = g.subject_id
                   JOIN subjects sub ON sub.subject_id = g.subject_id
                   GROUP BY st.student_id) done ON done.student_id = s.student_id
        WHERE s.status = 'Active' AND (@p IS NULL OR s.program_id = @p) AND (@y IS NULL OR s.year_level = @y)
        ORDER BY s.last_name, s.first_name;
        """;
}
