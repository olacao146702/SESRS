using System.Data;
using MySqlConnector;
using SESRS.Data;
using SESRS.Helpers;
using SESRS.Models;

namespace SESRS.Services;

public class GradeService
{
    private readonly DatabaseConnection _database = new();
    private readonly AuditService _audit = new();
    private readonly NotificationService _notifications = new();

    // ===============================================================
    // GRADING SETUP (components and scale)
    // ===============================================================

    public DataTable GetComponentsTable()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT gc.component_id, gc.subject_id,
                   COALESCE(s.subject_code, 'All subjects (default)') AS applies_to,
                   gc.name, gc.weight, gc.sort_order
            FROM grading_components gc
            LEFT JOIN subjects s ON s.subject_id = gc.subject_id
            ORDER BY (gc.subject_id IS NOT NULL), s.subject_code, gc.sort_order, gc.component_id;
            """);
    }

    public List<GradeComponent> GetEffectiveComponents(int subjectId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return LoadEffective(connection, null, subjectId);
    }

    public GradeComponent? GetComponent(int componentId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable t = Sql.Table(connection, null,
            "SELECT * FROM grading_components WHERE component_id = @id;", ("@id", componentId));

        return t.Rows.Count == 0 ? null : MapComponent(t.Rows[0]);
    }

    public int SaveComponent(GradeComponent component)
    {
        Session.RequireAdmin();

        string name = (component.Name ?? "").Trim();

        if (name.Length == 0 || name.Length > 50)
        {
            throw new BusinessRuleException("Component name is required (up to 50 characters).");
        }

        if (component.Weight <= 0 || component.Weight > 100)
        {
            throw new BusinessRuleException("The weight must be greater than 0 and at most 100.");
        }

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            RequireScopeEditable(connection, transaction, component.SubjectId);

            if (Sql.Int(connection, transaction, """
                    SELECT COUNT(*) FROM grading_components
                    WHERE name = @n AND (subject_id <=> @s) AND component_id <> @id;
                    """, ("@n", name), ("@s", component.SubjectId), ("@id", component.ComponentId)) > 0)
            {
                throw new BusinessRuleException($"A component named \"{name}\" already exists in this setup.");
            }

            int id = component.ComponentId;

            if (id == 0)
            {
                id = (int)Sql.Insert(connection, transaction, """
                    INSERT INTO grading_components (subject_id, name, weight, sort_order)
                    VALUES (@s, @n, @w, @o);
                    """, ("@s", component.SubjectId), ("@n", name), ("@w", component.Weight),
                    ("@o", component.SortOrder));
            }
            else
            {
                Sql.Exec(connection, transaction, """
                    UPDATE grading_components SET name = @n, weight = @w, sort_order = @o
                    WHERE component_id = @id;
                    """, ("@n", name), ("@w", component.Weight), ("@o", component.SortOrder), ("@id", id));
            }

            _audit.Log(connection, transaction,
                component.ComponentId == 0 ? "GRADING_COMPONENT_ADDED" : "GRADING_COMPONENT_UPDATED",
                "grading_component", id.ToString(), $"{name} {component.Weight}%");

            transaction.Commit();
            return id;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void DeleteComponent(int componentId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        GradeComponent? component = null;
        DataTable t = Sql.Table(connection, null,
            "SELECT * FROM grading_components WHERE component_id = @id;", ("@id", componentId));

        if (t.Rows.Count == 0)
        {
            return;
        }

        component = MapComponent(t.Rows[0]);
        RequireScopeEditable(connection, null, component.SubjectId);

        Sql.Exec(connection, null,
            "DELETE FROM grading_components WHERE component_id = @id;", ("@id", componentId));

        _audit.Log(connection, null, "GRADING_COMPONENT_DELETED", "grading_component",
            componentId.ToString(), component.Name);
    }

    /// <summary>Changing a setup after scores exist would silently change what saved percentages mean.</summary>
    private static void RequireScopeEditable(MySqlConnection connection, MySqlTransaction? transaction, int? subjectId)
    {
        bool hasScores = subjectId == null
            ? Sql.Int(connection, transaction, """
                  SELECT COUNT(*) FROM grade_scores gs
                  JOIN grading_components gc ON gc.component_id = gs.component_id
                  WHERE gc.subject_id IS NULL;
                  """) > 0
            : Sql.Int(connection, transaction, """
                  SELECT COUNT(*) FROM grades WHERE subject_id = @s AND percent IS NOT NULL;
                  """, ("@s", subjectId)) > 0;

        if (hasScores)
        {
            throw new BusinessRuleException(
                "Scores have already been entered under this grading setup, so it can no longer be changed. " +
                "Create a subject-specific setup before grading starts instead.");
        }
    }

    public DataTable GetScaleTable()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT scale_id, min_percent, grade_point, result
            FROM grading_scale ORDER BY min_percent DESC;
            """);
    }

    public ScaleRow? GetScaleRow(int scaleId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable t = Sql.Table(connection, null,
            "SELECT * FROM grading_scale WHERE scale_id = @id;", ("@id", scaleId));

        return t.Rows.Count == 0 ? null : MapScale(t.Rows[0]);
    }

    public int SaveScaleRow(ScaleRow row)
    {
        Session.RequireAdmin();

        if (row.MinPercent < 0 || row.MinPercent > 100)
        {
            throw new BusinessRuleException("The minimum percent must be between 0 and 100.");
        }

        if (row.GradePoint < 1m || row.GradePoint > 5m)
        {
            throw new BusinessRuleException("The grade point must be between 1.00 and 5.00.");
        }

        if (row.Result is not ("Passed" or "Failed"))
        {
            throw new BusinessRuleException("The result must be Passed or Failed.");
        }

        using var connection = _database.GetConnection();
        connection.Open();

        if (Sql.Int(connection, null,
                "SELECT COUNT(*) FROM grading_scale WHERE min_percent = @m AND scale_id <> @id;",
                ("@m", row.MinPercent), ("@id", row.ScaleId)) > 0)
        {
            throw new BusinessRuleException($"A scale row starting at {row.MinPercent:0.##}% already exists.");
        }

        int id = row.ScaleId;

        if (id == 0)
        {
            id = (int)Sql.Insert(connection, null,
                "INSERT INTO grading_scale (min_percent, grade_point, result) VALUES (@m, @g, @r);",
                ("@m", row.MinPercent), ("@g", row.GradePoint), ("@r", row.Result));
        }
        else
        {
            Sql.Exec(connection, null,
                "UPDATE grading_scale SET min_percent = @m, grade_point = @g, result = @r WHERE scale_id = @id;",
                ("@m", row.MinPercent), ("@g", row.GradePoint), ("@r", row.Result), ("@id", id));
        }

        _audit.Log(connection, null, row.ScaleId == 0 ? "GRADING_SCALE_ADDED" : "GRADING_SCALE_UPDATED",
            "grading_scale", id.ToString(), $"{row.MinPercent:0.##}% -> {row.GradePoint:0.00} {row.Result}");

        return id;
    }

    public void DeleteScaleRow(int scaleId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        if (Sql.Int(connection, null, "SELECT COUNT(*) FROM grading_scale;") <= 1)
        {
            throw new BusinessRuleException("The scale needs at least one row.");
        }

        Sql.Exec(connection, null, "DELETE FROM grading_scale WHERE scale_id = @id;", ("@id", scaleId));
        _audit.Log(connection, null, "GRADING_SCALE_DELETED", "grading_scale", scaleId.ToString());
    }

    // ===============================================================
    // GRADE SHEET (administrator)
    // ===============================================================

    /// <summary>Classes (section + subject) with approved students, for the grade-entry picker.</summary>
    public DataTable GetClasses(string schoolYear, string semester)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT d.section_id, d.subject_id,
                   CONCAT(sec.section_code, '  |  ', s.subject_code, ' - ', s.subject_name,
                          '  (', COUNT(*), ' students)') AS label
            FROM enrollment_details d
            JOIN enrollments e ON e.enrollment_id = d.enrollment_id AND e.status = 'Approved'
            JOIN sections sec ON sec.section_id = d.section_id
            JOIN subjects s ON s.subject_id = d.subject_id
            WHERE e.school_year = @sy AND e.semester = @sem
            GROUP BY d.section_id, d.subject_id, sec.section_code, s.subject_code, s.subject_name
            ORDER BY sec.section_code, s.subject_code;
            """, ("@sy", schoolYear), ("@sem", semester));
    }

    public GradeSheet GetSheet(int sectionId, int subjectId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        (string schoolYear, string semester, string label) = LoadClass(connection, null, sectionId, subjectId);

        List<GradeComponent> components = LoadEffective(connection, null, subjectId);
        List<ScaleRow> scale = LoadScale(connection, null);

        DataTable roster = Sql.Table(connection, null, """
            SELECT st.student_id, COALESCE(st.student_number, '') AS student_number,
                   CONCAT(st.last_name, ', ', st.first_name) AS student_name,
                   g.grade_id, g.percent, g.final_grade,
                   COALESCE(g.result, '') AS result, COALESCE(g.grade_status, '') AS grade_status
            FROM enrollment_details d
            JOIN enrollments e ON e.enrollment_id = d.enrollment_id AND e.status = 'Approved'
            JOIN students st ON st.student_id = e.student_id
            LEFT JOIN grades g ON g.student_id = st.student_id AND g.subject_id = d.subject_id
                              AND g.school_year = e.school_year AND g.semester = e.semester
            WHERE d.section_id = @sec AND d.subject_id = @sub
            ORDER BY st.last_name, st.first_name;
            """, ("@sec", sectionId), ("@sub", subjectId));

        var scores = new Dictionary<(int Grade, int Component), decimal>();
        var gradeIds = roster.Rows.Cast<DataRow>()
            .Where(r => r["grade_id"] != DBNull.Value)
            .Select(r => Convert.ToInt32(r["grade_id"]))
            .ToList();

        if (gradeIds.Count > 0)
        {
            foreach (DataRow r in Sql.Table(connection, null,
                         $"SELECT grade_id, component_id, score FROM grade_scores WHERE grade_id IN ({string.Join(",", gradeIds)});").Rows)
            {
                scores[(Convert.ToInt32(r["grade_id"]), Convert.ToInt32(r["component_id"]))] =
                    Convert.ToDecimal(r["score"]);
            }
        }

        var rows = new DataTable();
        rows.Columns.Add("student_id", typeof(int));
        rows.Columns.Add("student_number", typeof(string));
        rows.Columns.Add("student_name", typeof(string));

        foreach (GradeComponent c in components)
        {
            rows.Columns.Add("c_" + c.ComponentId, typeof(decimal));
        }

        rows.Columns.Add("special", typeof(string));
        rows.Columns.Add("percent", typeof(decimal));
        rows.Columns.Add("final_grade", typeof(decimal));
        rows.Columns.Add("result", typeof(string));
        rows.Columns.Add("grade_status", typeof(string));

        foreach (DataRow r in roster.Rows)
        {
            DataRow row = rows.NewRow();
            row["student_id"] = r["student_id"];
            row["student_number"] = r["student_number"];
            row["student_name"] = r["student_name"];

            if (r["grade_id"] != DBNull.Value)
            {
                int gradeId = Convert.ToInt32(r["grade_id"]);

                foreach (GradeComponent c in components)
                {
                    if (scores.TryGetValue((gradeId, c.ComponentId), out decimal score))
                    {
                        row["c_" + c.ComponentId] = score;
                    }
                }
            }

            string result = Convert.ToString(r["result"]) ?? "";
            row["special"] = result is "Incomplete" or "Dropped" ? result : "";
            row["percent"] = r["percent"];
            row["final_grade"] = r["final_grade"];
            row["result"] = result;
            row["grade_status"] = r["grade_status"];
            rows.Rows.Add(row);
        }

        return new GradeSheet
        {
            SectionId = sectionId,
            SubjectId = subjectId,
            ClassLabel = label,
            SchoolYear = schoolYear,
            Semester = semester,
            Components = components,
            Scale = scale,
            Rows = rows
        };
    }

    public int SaveSheet(int sectionId, int subjectId, IReadOnlyList<GradeEntry> entries, string? reason)
    {
        var admin = Session.RequireAdmin();
        reason = string.IsNullOrWhiteSpace(reason) ? null : reason.Trim();

        if (reason != null && reason.Length > 255)
        {
            throw new BusinessRuleException("The reason must be 255 characters or fewer.");
        }

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            (string schoolYear, string semester, string label) = LoadClass(connection, transaction, sectionId, subjectId);

            List<GradeComponent> components = LoadEffective(connection, transaction, subjectId);
            string? weightProblem = GradeCalculator.ValidateWeights(components);

            if (weightProblem != null)
            {
                throw new BusinessRuleException(weightProblem + " Fix it under Academics > Grading Setup.");
            }

            List<ScaleRow> scale = LoadScale(connection, transaction);

            HashSet<int> roster = Sql.Table(connection, transaction, """
                    SELECT DISTINCT e.student_id
                    FROM enrollment_details d
                    JOIN enrollments e ON e.enrollment_id = d.enrollment_id AND e.status = 'Approved'
                    WHERE d.section_id = @sec AND d.subject_id = @sub;
                    """, ("@sec", sectionId), ("@sub", subjectId))
                .Rows.Cast<DataRow>().Select(r => Convert.ToInt32(r[0])).ToHashSet();

            int saved = 0;

            foreach (GradeEntry entry in entries)
            {
                if (!roster.Contains(entry.StudentId))
                {
                    throw new BusinessRuleException("A student on this sheet is not enrolled in this class.");
                }

                string? special = string.IsNullOrEmpty(entry.Special) ? null : entry.Special;

                if (special is not (null or "Incomplete" or "Dropped"))
                {
                    throw new BusinessRuleException("Special marks can only be Incomplete or Dropped.");
                }

                GradeComputation computed = GradeCalculator.Compute(components, scale, entry.Scores, special);

                DataTable existingTable = Sql.Table(connection, transaction, """
                    SELECT grade_id, percent, final_grade, result, grade_status
                    FROM grades
                    WHERE student_id = @s AND subject_id = @sub AND school_year = @sy AND semester = @sem
                    FOR UPDATE;
                    """, ("@s", entry.StudentId), ("@sub", subjectId), ("@sy", schoolYear), ("@sem", semester));

                DataRow? existing = existingTable.Rows.Count == 0 ? null : existingTable.Rows[0];
                int? gradeId = existing == null ? null : Convert.ToInt32(existing["grade_id"]);

                var oldScores = new Dictionary<int, decimal>();

                if (gradeId != null)
                {
                    foreach (DataRow r in Sql.Table(connection, transaction,
                                 "SELECT component_id, score FROM grade_scores WHERE grade_id = @g;",
                                 ("@g", gradeId)).Rows)
                    {
                        oldScores[Convert.ToInt32(r["component_id"])] = Convert.ToDecimal(r["score"]);
                    }
                }

                var newScores = components
                    .Where(c => entry.Scores.TryGetValue(c.ComponentId, out decimal? s) && s != null)
                    .ToDictionary(c => c.ComponentId, c => entry.Scores[c.ComponentId]!.Value);

                string oldResult = existing == null ? "" : Convert.ToString(existing["result"]) ?? "";
                string newResult = computed.Result;

                bool changed = existing == null
                    ? newScores.Count > 0 || special != null
                    : !SameScores(oldScores, newScores) || oldResult != newResult;

                if (!changed)
                {
                    continue;
                }

                string oldStatus = existing == null ? "" : Convert.ToString(existing["grade_status"]) ?? "Draft";
                bool wasPublished = oldStatus == "Published";

                if (wasPublished && computed.Result == "Pending")
                {
                    throw new BusinessRuleException(
                        "A published grade cannot be cleared. Unpublish the sheet first, or complete every score.");
                }

                if (wasPublished && reason == null)
                {
                    throw new BusinessRuleException(
                        "You changed a published grade. Please enter the reason for the revision.");
                }

                string newStatus = wasPublished ? "Published" : "Draft";

                if (gradeId == null)
                {
                    gradeId = (int)Sql.Insert(connection, transaction, """
                        INSERT INTO grades (student_id, subject_id, school_year, semester, section_id,
                                            percent, final_grade, result, grade_status, is_published,
                                            updated_by, updated_at)
                        VALUES (@s, @sub, @sy, @sem, @sec, @p, @f, @r, 'Draft', 0, @u, NOW());
                        """,
                        ("@s", entry.StudentId), ("@sub", subjectId), ("@sy", schoolYear), ("@sem", semester),
                        ("@sec", sectionId), ("@p", computed.Percent), ("@f", computed.GradePoint),
                        ("@r", computed.Result), ("@u", admin.UserId));
                }
                else
                {
                    Sql.Exec(connection, transaction, """
                        UPDATE grades
                        SET percent = @p, final_grade = @f, result = @r, grade_status = @st,
                            section_id = @sec, remarks = COALESCE(@remarks, remarks),
                            updated_by = @u, updated_at = NOW()
                        WHERE grade_id = @g;
                        """,
                        ("@p", computed.Percent), ("@f", computed.GradePoint), ("@r", computed.Result),
                        ("@st", newStatus), ("@sec", sectionId),
                        ("@remarks", wasPublished ? reason : null), ("@u", admin.UserId), ("@g", gradeId));
                }

                Sql.Exec(connection, transaction, "DELETE FROM grade_scores WHERE grade_id = @g;", ("@g", gradeId));

                foreach (var (componentId, score) in newScores)
                {
                    Sql.Exec(connection, transaction,
                        "INSERT INTO grade_scores (grade_id, component_id, score) VALUES (@g, @c, @s);",
                        ("@g", gradeId), ("@c", componentId), ("@s", score));
                }

                decimal? oldFinal = existing == null || existing["final_grade"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(existing["final_grade"]);

                WriteGradeAudit(connection, transaction, gradeId, entry.StudentId, subjectId, admin,
                    existing == null ? "ENTERED" : wasPublished ? "REVISED" : "CHANGED",
                    oldFinal, computed.GradePoint, oldStatus, newStatus, wasPublished ? reason : null);

                if (wasPublished)
                {
                    NotifyStudent(connection, transaction, entry.StudentId, "Grade revised",
                        $"Your grade for {SubjectCode(connection, transaction, subjectId)} was revised: {reason}",
                        "grades");
                }

                saved++;
            }

            _audit.Log(connection, transaction, "GRADES_SAVED", "class",
                $"{sectionId}/{subjectId}", $"{label}: {saved} grade(s) saved");

            transaction.Commit();
            return saved;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>Marks a complete sheet as reviewed so it can be published.</summary>
    public int Review(int sectionId, int subjectId)
    {
        var admin = Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            List<RosterGrade> roster = LoadRosterGrades(connection, transaction, sectionId, subjectId);

            if (roster.Count == 0)
            {
                throw new BusinessRuleException("This class has no enrolled students.");
            }

            int incomplete = roster.Count(r => r.GradeId == null || r.Result == "Pending");

            if (incomplete > 0)
            {
                throw new BusinessRuleException(
                    $"{incomplete} student(s) still have missing scores. Complete them before review.");
            }

            int changed = 0;

            foreach (RosterGrade r in roster.Where(r => r.Status == "Draft"))
            {
                Sql.Exec(connection, transaction,
                    "UPDATE grades SET grade_status = 'Reviewed', updated_by = @u, updated_at = NOW() WHERE grade_id = @g;",
                    ("@u", admin.UserId), ("@g", r.GradeId));

                WriteGradeAudit(connection, transaction, r.GradeId, r.StudentId, subjectId, admin,
                    "REVIEWED", r.Final, r.Final, "Draft", "Reviewed", null);
                changed++;
            }

            if (changed == 0)
            {
                throw new BusinessRuleException("There is nothing to review: every grade is already reviewed or published.");
            }

            _audit.Log(connection, transaction, "GRADES_REVIEWED", "class", $"{sectionId}/{subjectId}",
                changed + " grade(s)");

            transaction.Commit();
            return changed;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>Publishes reviewed grades: students can see them from this moment.</summary>
    public int Publish(int sectionId, int subjectId)
    {
        var admin = Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            List<RosterGrade> roster = LoadRosterGrades(connection, transaction, sectionId, subjectId);

            if (roster.Any(r => r.GradeId == null || r.Status == "Draft"))
            {
                throw new BusinessRuleException(
                    "Every grade must be complete and reviewed before publishing. Use REVIEW first.");
            }

            string code = SubjectCode(connection, transaction, subjectId);
            int published = 0;

            foreach (RosterGrade r in roster.Where(r => r.Status == "Reviewed"))
            {
                Sql.Exec(connection, transaction, """
                    UPDATE grades
                    SET grade_status = 'Published', is_published = 1, published_at = NOW(),
                        updated_by = @u, updated_at = NOW()
                    WHERE grade_id = @g;
                    """, ("@u", admin.UserId), ("@g", r.GradeId));

                WriteGradeAudit(connection, transaction, r.GradeId, r.StudentId, subjectId, admin,
                    "PUBLISHED", r.Final, r.Final, "Reviewed", "Published", null);

                NotifyStudent(connection, transaction, r.StudentId, "New grade published",
                    $"Your grade for {code} is now available.", "grades");

                published++;
            }

            if (published == 0)
            {
                throw new BusinessRuleException("There is nothing to publish: all grades are already published.");
            }

            _audit.Log(connection, transaction, "GRADES_PUBLISHED", "class", $"{sectionId}/{subjectId}",
                published + " grade(s)");

            transaction.Commit();
            return published;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>Withdraws published grades (they become drafts again and disappear from students).</summary>
    public int Unpublish(int sectionId, int subjectId, string reason)
    {
        var admin = Session.RequireAdmin();

        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new BusinessRuleException("Please enter the reason for withdrawing these grades.");
        }

        reason = reason.Trim();

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            List<RosterGrade> published = LoadRosterGrades(connection, transaction, sectionId, subjectId)
                .Where(r => r.Status == "Published").ToList();

            if (published.Count == 0)
            {
                throw new BusinessRuleException("No grades are published for this class.");
            }

            string code = SubjectCode(connection, transaction, subjectId);

            foreach (RosterGrade r in published)
            {
                Sql.Exec(connection, transaction, """
                    UPDATE grades
                    SET grade_status = 'Draft', is_published = 0, published_at = NULL,
                        remarks = @reason, updated_by = @u, updated_at = NOW()
                    WHERE grade_id = @g;
                    """, ("@reason", reason), ("@u", admin.UserId), ("@g", r.GradeId));

                WriteGradeAudit(connection, transaction, r.GradeId, r.StudentId, subjectId, admin,
                    "UNPUBLISHED", r.Final, r.Final, "Published", "Draft", reason);

                NotifyStudent(connection, transaction, r.StudentId, "Grade withdrawn",
                    $"Your published grade for {code} was withdrawn for correction: {reason}", "grades");
            }

            _audit.Log(connection, transaction, "GRADES_UNPUBLISHED", "class", $"{sectionId}/{subjectId}", reason);

            transaction.Commit();
            return published.Count;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>Records a result from before the system was used (credited subject). Published immediately.</summary>
    public void RecordPriorGrade(
        int studentId, int subjectId, string schoolYear, string semester, decimal gradePoint, string result)
    {
        var admin = Session.RequireAdmin();

        if (!System.Text.RegularExpressions.Regex.IsMatch(schoolYear ?? "", @"^\d{4}-\d{4}$"))
        {
            throw new BusinessRuleException("School year must look like 2025-2026.");
        }

        if (!Academic.Semesters.Contains(semester))
        {
            throw new BusinessRuleException("Please choose a valid semester.");
        }

        if (gradePoint < 1m || gradePoint > 5m)
        {
            throw new BusinessRuleException("The grade must be between 1.00 and 5.00.");
        }

        if (result is not ("Passed" or "Failed"))
        {
            throw new BusinessRuleException("The result must be Passed or Failed.");
        }

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            if (Sql.Int(connection, transaction, """
                    SELECT COUNT(*) FROM grades
                    WHERE student_id = @s AND subject_id = @sub AND school_year = @sy AND semester = @sem;
                    """, ("@s", studentId), ("@sub", subjectId), ("@sy", schoolYear), ("@sem", semester)) > 0)
            {
                throw new BusinessRuleException("A grade for that subject and term already exists for this student.");
            }

            long gradeId = Sql.Insert(connection, transaction, """
                INSERT INTO grades (student_id, subject_id, school_year, semester, final_grade, result,
                                    grade_status, is_published, published_at, remarks, updated_by, updated_at)
                VALUES (@s, @sub, @sy, @sem, @g, @r, 'Published', 1, NOW(), 'Credited record', @u, NOW());
                """,
                ("@s", studentId), ("@sub", subjectId), ("@sy", schoolYear), ("@sem", semester),
                ("@g", gradePoint), ("@r", result), ("@u", admin.UserId));

            WriteGradeAudit(connection, transaction, (int)gradeId, studentId, subjectId, admin,
                "CREDITED", null, gradePoint, "", "Published", "Prior record entered by registrar");

            NotifyStudent(connection, transaction, studentId, "Academic record updated",
                $"A grade for {SubjectCode(connection, transaction, subjectId)} ({schoolYear}) was added to your record.",
                "grades");

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>Active students as dropdown choices (for entering prior records).</summary>
    public List<(int Id, string Label)> GetStudentChoices()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
                SELECT student_id, COALESCE(student_number, '-') AS student_number,
                       CONCAT(last_name, ', ', first_name) AS name
                FROM students WHERE status = 'Active'
                ORDER BY last_name, first_name;
                """)
            .Rows.Cast<DataRow>()
            .Select(r => (Convert.ToInt32(r["student_id"]), $"{r["student_number"]}  -  {r["name"]}"))
            .ToList();
    }

    public DataTable GetGradeAudit(int studentId, int subjectId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT changed_at, COALESCE(changed_by_name, 'System') AS changed_by, action,
                   old_final, new_final, old_status, new_status, COALESCE(reason, '') AS reason
            FROM grade_audit
            WHERE student_id = @s AND subject_id = @sub
            ORDER BY grade_audit_id;
            """, ("@s", studentId), ("@sub", subjectId));
    }

    // ===============================================================
    // STUDENT VIEW (published grades only)
    // ===============================================================

    public DataTable GetMyGrades(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT g.school_year, g.semester, s.subject_code, s.subject_name, s.units,
                   g.final_grade, g.result, COALESCE(g.remarks, '') AS remarks
            FROM grades g
            JOIN subjects s ON s.subject_id = g.subject_id
            WHERE g.student_id = @s AND g.is_published = 1
            ORDER BY g.school_year DESC,
                     FIELD(g.semester, '1st Semester', '2nd Semester', 'Summer') DESC,
                     s.subject_code;
            """, ("@s", studentId));
    }

    public GradeSummary GetSummary(int studentId)
    {
        Session.RequireStudentSelfOrAdmin(studentId);

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable t = Sql.Table(connection, null, """
            SELECT g.final_grade, g.result, s.units
            FROM grades g JOIN subjects s ON s.subject_id = g.subject_id
            WHERE g.student_id = @s AND g.is_published = 1;
            """, ("@s", studentId));

        decimal points = 0;
        int attempted = 0, earned = 0;

        foreach (DataRow r in t.Rows)
        {
            int units = Convert.ToInt32(r["units"]);

            if (r["final_grade"] != DBNull.Value)
            {
                points += Convert.ToDecimal(r["final_grade"]) * units;
                attempted += units;
            }

            if (Convert.ToString(r["result"]) == "Passed")
            {
                earned += units;
            }
        }

        return new GradeSummary(
            attempted == 0 ? null : Math.Round(points / attempted, 2, MidpointRounding.AwayFromZero),
            earned, attempted);
    }

    /// <summary>Every grade of a student including drafts (administrators only).</summary>
    public DataTable GetStudentRecord(int studentId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT g.school_year, g.semester, s.subject_code, s.subject_name, s.units,
                   g.percent, g.final_grade, g.result, g.grade_status AS status
            FROM grades g JOIN subjects s ON s.subject_id = g.subject_id
            WHERE g.student_id = @s
            ORDER BY g.school_year DESC,
                     FIELD(g.semester, '1st Semester', '2nd Semester', 'Summer') DESC, s.subject_code;
            """, ("@s", studentId));
    }

    // ===============================================================
    // Helpers
    // ===============================================================

    private sealed record RosterGrade(int StudentId, int? GradeId, string Result, string Status, decimal? Final);

    private static List<RosterGrade> LoadRosterGrades(
        MySqlConnection connection, MySqlTransaction? transaction, int sectionId, int subjectId)
    {
        return Sql.Table(connection, transaction, """
                SELECT st.student_id, g.grade_id, COALESCE(g.result, '') AS result,
                       COALESCE(g.grade_status, '') AS grade_status, g.final_grade
                FROM enrollment_details d
                JOIN enrollments e ON e.enrollment_id = d.enrollment_id AND e.status = 'Approved'
                JOIN students st ON st.student_id = e.student_id
                LEFT JOIN grades g ON g.student_id = st.student_id AND g.subject_id = d.subject_id
                                  AND g.school_year = e.school_year AND g.semester = e.semester
                WHERE d.section_id = @sec AND d.subject_id = @sub;
                """, ("@sec", sectionId), ("@sub", subjectId))
            .Rows.Cast<DataRow>()
            .Select(r => new RosterGrade(
                Convert.ToInt32(r["student_id"]),
                r["grade_id"] == DBNull.Value ? null : Convert.ToInt32(r["grade_id"]),
                Convert.ToString(r["result"]) ?? "",
                Convert.ToString(r["grade_status"]) ?? "",
                r["final_grade"] == DBNull.Value ? null : Convert.ToDecimal(r["final_grade"])))
            .ToList();
    }

    private static (string SchoolYear, string Semester, string Label) LoadClass(
        MySqlConnection connection, MySqlTransaction? transaction, int sectionId, int subjectId)
    {
        DataTable t = Sql.Table(connection, transaction, """
            SELECT sec.school_year, sec.semester,
                   CONCAT(sec.section_code, ' - ', s.subject_code, ' ', s.subject_name) AS label
            FROM sections sec, subjects s
            WHERE sec.section_id = @sec AND s.subject_id = @sub;
            """, ("@sec", sectionId), ("@sub", subjectId));

        if (t.Rows.Count == 0)
        {
            throw new BusinessRuleException("That class no longer exists.");
        }

        return (Convert.ToString(t.Rows[0]["school_year"]) ?? "",
                Convert.ToString(t.Rows[0]["semester"]) ?? "",
                Convert.ToString(t.Rows[0]["label"]) ?? "");
    }

    private static List<GradeComponent> LoadEffective(
        MySqlConnection connection, MySqlTransaction? transaction, int subjectId)
    {
        DataTable own = Sql.Table(connection, transaction, """
            SELECT * FROM grading_components WHERE subject_id = @s ORDER BY sort_order, component_id;
            """, ("@s", subjectId));

        DataTable source = own.Rows.Count > 0
            ? own
            : Sql.Table(connection, transaction,
                "SELECT * FROM grading_components WHERE subject_id IS NULL ORDER BY sort_order, component_id;");

        return source.Rows.Cast<DataRow>().Select(MapComponent).ToList();
    }

    private static List<ScaleRow> LoadScale(MySqlConnection connection, MySqlTransaction? transaction)
    {
        return Sql.Table(connection, transaction, "SELECT * FROM grading_scale ORDER BY min_percent DESC;")
            .Rows.Cast<DataRow>().Select(MapScale).ToList();
    }

    private static GradeComponent MapComponent(DataRow r)
    {
        return new GradeComponent(
            Convert.ToInt32(r["component_id"]),
            r["subject_id"] == DBNull.Value ? null : Convert.ToInt32(r["subject_id"]),
            Convert.ToString(r["name"]) ?? "",
            Convert.ToDecimal(r["weight"]),
            Convert.ToInt32(r["sort_order"]));
    }

    private static ScaleRow MapScale(DataRow r)
    {
        return new ScaleRow(
            Convert.ToInt32(r["scale_id"]),
            Convert.ToDecimal(r["min_percent"]),
            Convert.ToDecimal(r["grade_point"]),
            Convert.ToString(r["result"]) ?? "");
    }

    private static bool SameScores(Dictionary<int, decimal> a, Dictionary<int, decimal> b)
    {
        return a.Count == b.Count && a.All(p => b.TryGetValue(p.Key, out decimal v) && v == p.Value);
    }

    private static string SubjectCode(MySqlConnection connection, MySqlTransaction? transaction, int subjectId)
    {
        return Convert.ToString(Sql.Scalar(connection, transaction,
            "SELECT subject_code FROM subjects WHERE subject_id = @s;", ("@s", subjectId))) ?? "";
    }

    private void NotifyStudent(
        MySqlConnection connection, MySqlTransaction transaction, int studentId,
        string title, string message, string link)
    {
        object? userId = Sql.Scalar(connection, transaction,
            "SELECT user_id FROM users WHERE student_id = @s AND role = 'Student' LIMIT 1;",
            ("@s", studentId));

        if (userId != null)
        {
            _notifications.Create(connection, transaction, Convert.ToInt32(userId), title, message, link);
        }
    }

    private static void WriteGradeAudit(
        MySqlConnection connection, MySqlTransaction transaction, int? gradeId, int studentId, int subjectId,
        User admin, string action, decimal? oldFinal, decimal? newFinal, string oldStatus, string newStatus,
        string? reason)
    {
        Sql.Exec(connection, transaction, """
            INSERT INTO grade_audit (grade_id, student_id, subject_id, changed_by, changed_by_name, action,
                                     old_final, new_final, old_status, new_status, reason)
            VALUES (@g, @s, @sub, @u, @name, @a, @of, @nf, @os, @ns, @reason);
            """,
            ("@g", gradeId), ("@s", studentId), ("@sub", subjectId), ("@u", admin.UserId),
            ("@name", admin.FullName.Length > 0 ? admin.FullName : admin.Username), ("@a", action),
            ("@of", oldFinal), ("@nf", newFinal), ("@os", oldStatus), ("@ns", newStatus), ("@reason", reason));
    }
}
