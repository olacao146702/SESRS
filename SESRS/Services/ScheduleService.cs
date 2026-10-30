using System.Data;
using MySqlConnector;
using SESRS.Data;
using SESRS.Helpers;
using SESRS.Models;

namespace SESRS.Services;

/// <summary>Class meetings (day, time, room, instructor) for each section, with conflict detection.</summary>
public class ScheduleService
{
    private readonly DatabaseConnection _database = new();
    private readonly AuditService _audit = new();
    private readonly NotificationService _notifications = new();



    public DataTable GetForSection(int sectionId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable table = Sql.Table(connection, null, """
        SELECT
            MIN(sc.schedule_id) AS schedule_id,

            GROUP_CONCAT(
                sc.schedule_id
                ORDER BY FIELD(
                    sc.day, 'Monday', 'Tuesday', 'Wednesday',
                    'Thursday', 'Friday', 'Saturday', 'Sunday'
                )
                SEPARATOR ','
            ) AS schedule_ids,

            GROUP_CONCAT(
                sc.day
                ORDER BY FIELD(
                    sc.day, 'Monday', 'Tuesday', 'Wednesday',
                    'Thursday', 'Friday', 'Saturday', 'Sunday'
                )
                SEPARATOR ','
            ) AS raw_days,

            s.subject_code,
            s.subject_name,
            sc.start_time,
            sc.end_time,
            COALESCE(sc.room, '') AS room,
            COALESCE(sc.instructor, '') AS instructor

        FROM schedules sc
        JOIN subjects s ON s.subject_id = sc.subject_id

        WHERE sc.section_id = @sectionId

        GROUP BY
            sc.subject_id,
            s.subject_code,
            s.subject_name,
            sc.start_time,
            sc.end_time,
            sc.room,
            sc.instructor

        ORDER BY
            MIN(FIELD(
                sc.day, 'Monday', 'Tuesday', 'Wednesday',
                'Thursday', 'Friday', 'Saturday', 'Sunday'
            )),
            sc.start_time;
        """, ("@sectionId", sectionId));

        // Add a separate column for the readable day pattern.
        if (!table.Columns.Contains("days_display"))
        {
            table.Columns.Add("days_display", typeof(string));
        }

        foreach (DataRow row in table.Rows)
        {
            string rawDays = Convert.ToString(row["raw_days"]) ?? "";

            string[] days = rawDays.Split(
                ',',
                StringSplitOptions.RemoveEmptyEntries |
                StringSplitOptions.TrimEntries);

            var daySet = days.ToHashSet(StringComparer.OrdinalIgnoreCase);

            string displayPattern =
                daySet.SetEquals(new[] { "Monday", "Wednesday", "Friday" })
                    ? "MWF"
                : daySet.SetEquals(new[]
                    {
                    "Monday", "Tuesday", "Wednesday",
                    "Thursday", "Friday"
                    })
                    ? "Monday-Friday"
                : daySet.SetEquals(new[] { "Monday", "Tuesday", "Wednesday" })
                    ? "MSAT1"
                : daySet.SetEquals(new[] { "Thursday", "Friday", "Saturday" })
                    ? "MSAT2"
                : string.Join(", ", days.Select(day => day switch
                {
                    "Monday" => "M",
                    "Tuesday" => "T",
                    "Wednesday" => "W",
                    "Thursday" => "Th",
                    "Friday" => "F",
                    "Saturday" => "Sat",
                    "Sunday" => "Sun",
                    _ => day
                }));

            row["days_display"] = displayPattern;
        }

        return table;
    }


    /// <summary>Sections as dropdown choices.</summary>
    public DataTable GetSectionChoices()
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
            SELECT s.section_id,
                   CONCAT(s.section_code, ' - ', p.program_code, ' ', s.year_level, ' (',
                          s.school_year, ', ', s.semester, ')') AS label
            FROM sections s
            JOIN programs p ON p.program_id = s.program_id
            ORDER BY s.school_year DESC, s.semester, s.section_code;
            """);
    }

    /// <summary>Subjects in the curriculum of the section's program, year level and semester.</summary>
    public List<(int Id, string Label)> GetSubjectChoices(int sectionId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        return Sql.Table(connection, null, """
                SELECT s.subject_id, s.subject_code, s.subject_name
                FROM sections sec
                JOIN curriculum cu ON cu.program_id = sec.program_id
                                  AND cu.year_level = sec.year_level
                                  AND cu.semester = sec.semester
                JOIN subjects s ON s.subject_id = cu.subject_id
                WHERE sec.section_id = @sectionId
                ORDER BY s.subject_code;
                """, ("@sectionId", sectionId))
            .Rows.Cast<DataRow>()
            .Select(r => (Convert.ToInt32(r["subject_id"]), $"{r["subject_code"]} - {r["subject_name"]}"))
            .ToList();
    }

    public ScheduleEntry? Get(int scheduleId)
    {
        Session.RequireAdmin();

        using var connection = _database.GetConnection();
        connection.Open();

        DataTable t = Sql.Table(connection, null,
            "SELECT * FROM schedules WHERE schedule_id = @id;", ("@id", scheduleId));

        if (t.Rows.Count == 0)
        {
            return null;
        }

        DataRow r = t.Rows[0];

        return new ScheduleEntry(
            Convert.ToInt32(r["schedule_id"]),
            Convert.ToInt32(r["section_id"]),
            Convert.ToInt32(r["subject_id"]),
            r["instructor"] as string,
            r["room"] as string,
            Convert.ToString(r["day"]) ?? "",
            (TimeSpan)r["start_time"],
            (TimeSpan)r["end_time"]);
    }

    public int Save(ScheduleEntry entry)
    {
        Session.RequireAdmin();

        ScheduleEntry e = entry with
        {
            Instructor = string.IsNullOrWhiteSpace(entry.Instructor) ? null : entry.Instructor.Trim(),
            Room = string.IsNullOrWhiteSpace(entry.Room) ? null : entry.Room.Trim()
        };

        if (!Academic.Days.Contains(e.Day))
        {
            throw new BusinessRuleException("Please choose a valid day.");
        }

        if (e.End <= e.Start)
        {
            throw new BusinessRuleException("The end time must be after the start time.");
        }

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            DataTable sectionTable = Sql.Table(connection, transaction, """
                SELECT section_id, section_code, program_id, year_level, semester, school_year, status
                FROM sections WHERE section_id = @id FOR UPDATE;
                """, ("@id", e.SectionId));

            if (sectionTable.Rows.Count == 0)
            {
                throw new BusinessRuleException("That section no longer exists.");
            }

            DataRow section = sectionTable.Rows[0];

            int inCurriculum = Sql.Int(connection, transaction, """
                SELECT COUNT(*) FROM curriculum
                WHERE program_id = @p AND subject_id = @s AND year_level = @y AND semester = @sem;
                """,
                ("@p", section["program_id"]), ("@s", e.SubjectId),
                ("@y", section["year_level"]), ("@sem", section["semester"]));

            if (inCurriculum == 0)
            {
                throw new BusinessRuleException(
                    "That subject is not in the curriculum for this section's program, year level and semester.");
            }

            CheckResourceConflicts(connection, transaction, e, section);
            CheckEnrolledStudentConflicts(connection, transaction, e);

            int id = e.ScheduleId;
            bool isNew = id == 0;
            ScheduleEntry? before = null;

            if (!isNew)
            {
                before = ReadEntry(connection, transaction, id)
                    ?? throw new BusinessRuleException("That schedule entry no longer exists.");
            }

            if (isNew)
            {
                id = (int)Sql.Insert(connection, transaction, """
                    INSERT INTO schedules (section_id, subject_id, instructor, room, day, start_time, end_time)
                    VALUES (@sec, @sub, @ins, @room, @day, @start, @end);
                    """,
                    ("@sec", e.SectionId), ("@sub", e.SubjectId), ("@ins", e.Instructor),
                    ("@room", e.Room), ("@day", e.Day), ("@start", e.Start), ("@end", e.End));
            }
            else
            {
                Sql.Exec(connection, transaction, """
                    UPDATE schedules
                    SET section_id = @sec, subject_id = @sub, instructor = @ins, room = @room,
                        day = @day, start_time = @start, end_time = @end
                    WHERE schedule_id = @id;
                    """,
                    ("@sec", e.SectionId), ("@sub", e.SubjectId), ("@ins", e.Instructor),
                    ("@room", e.Room), ("@day", e.Day), ("@start", e.Start), ("@end", e.End),
                    ("@id", id));
            }

            string description = $"{section["section_code"]}: {e.Day} {Academic.FormatTime(e.Start)}-{Academic.FormatTime(e.End)}"
                + (e.Room == null ? "" : " @ " + e.Room);

            if (!isNew)
            {
                NotifyAffected(connection, transaction, before!.SectionId, before.SubjectId,
                    "Schedule changed", "A class meeting was updated. New time: " + description + ". Please review your timetable.");

                if (before.SectionId != e.SectionId || before.SubjectId != e.SubjectId)
                {
                    NotifyAffected(connection, transaction, e.SectionId, e.SubjectId,
                        "Schedule changed", "A class meeting was added: " + description + ". Please review your timetable.");
                }
            }
            else
            {
                NotifyAffected(connection, transaction, e.SectionId, e.SubjectId,
                    "Schedule changed", "A class meeting was added: " + description + ". Please review your timetable.");
            }

            _audit.Log(connection, transaction,
                isNew ? "SCHEDULE_ADDED" : "SCHEDULE_UPDATED", "schedule", id.ToString(), description);

            transaction.Commit();
            return id;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }


    public void Delete(int scheduleId)
    {
        DeleteMany(new[] { scheduleId });
    }

    public void DeleteMany(IEnumerable<int> scheduleIds)
    {
        Session.RequireAdmin();

        int[] ids = scheduleIds.Distinct().ToArray();

        if (ids.Length == 0)
            throw new BusinessRuleException("No schedule meetings were selected.");

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            foreach (int id in ids)
            {
                ScheduleEntry? entry = ReadEntry(connection, transaction, id);

                if (entry == null)
                    throw new BusinessRuleException(
                        $"Schedule meeting ID {id} no longer exists.");

                Sql.Exec(connection, transaction,
                    "DELETE FROM schedules WHERE schedule_id = @id;",
                    ("@id", id));

                NotifyAffected(
                    connection, transaction,
                    entry.SectionId, entry.SubjectId,
                    "Schedule changed",
                    $"A class meeting on {entry.Day} " +
                    $"{Academic.FormatTime(entry.Start)} was removed. " +
                    "Please review your timetable.");

                _audit.Log(
                    connection, transaction,
                    "SCHEDULE_DELETED", "schedule", id.ToString());
            }

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }


    // ---------------------------------------------------------------
    // Conflict detection
    // ---------------------------------------------------------------

    private static void CheckResourceConflicts(
        MySqlConnection connection,
        MySqlTransaction transaction,
        ScheduleEntry e,
        DataRow section)
    {
        DataTable clashes = Sql.Table(connection, transaction, """
            SELECT sec.section_code, sub.subject_code, sc.day, sc.start_time, sc.end_time,
                   sc.room, sc.instructor, sc.section_id
            FROM schedules sc
            JOIN sections sec ON sec.section_id = sc.section_id
            JOIN subjects sub ON sub.subject_id = sc.subject_id
            WHERE sc.schedule_id <> @id
              AND sc.day = @day
              AND sc.start_time < @end AND @start < sc.end_time
              AND sec.school_year = @sy AND sec.semester = @sem
              AND (sc.section_id = @section
                   OR (@room <> '' AND sc.room = @room)
                   OR (@instructor <> '' AND sc.instructor = @instructor))
            LIMIT 5;
            """,
            ("@id", e.ScheduleId), ("@day", e.Day), ("@start", e.Start), ("@end", e.End),
            ("@sy", section["school_year"]), ("@sem", section["semester"]),
            ("@section", e.SectionId), ("@room", e.Room ?? ""), ("@instructor", e.Instructor ?? ""));

        if (clashes.Rows.Count == 0)
        {
            return;
        }

        var reasons = new List<string>();

        foreach (DataRow row in clashes.Rows)
        {
            string when = $"{row["section_code"]} {row["subject_code"]} " +
                $"({Academic.FormatTime((TimeSpan)row["start_time"])}-{Academic.FormatTime((TimeSpan)row["end_time"])})";

            if (Convert.ToInt32(row["section_id"]) == e.SectionId)
            {
                reasons.Add($"This section already has a class at that time: {when}.");
            }

            if (e.Room != null && string.Equals(row["room"] as string, e.Room, StringComparison.OrdinalIgnoreCase))
            {
                reasons.Add($"Room {e.Room} is already used by {when}.");
            }

            if (e.Instructor != null &&
                string.Equals(row["instructor"] as string, e.Instructor, StringComparison.OrdinalIgnoreCase))
            {
                reasons.Add($"{e.Instructor} is already teaching {when}.");
            }
        }

        throw new BusinessRuleException(
            "Schedule conflict on " + e.Day + ":\n- " + string.Join("\n- ", reasons.Distinct()));
    }

    private static void CheckEnrolledStudentConflicts(
        MySqlConnection connection,
        MySqlTransaction transaction,
        ScheduleEntry e)
    {
        int affected = Sql.Int(connection, transaction, """
            SELECT COUNT(DISTINCT en.student_id)
            FROM enrollment_details d
            JOIN enrollments en ON en.enrollment_id = d.enrollment_id
                               AND en.status IN ('Pending', 'Approved')
            JOIN enrollment_details d2 ON d2.enrollment_id = en.enrollment_id
                                      AND d2.enrollment_detail_id <> d.enrollment_detail_id
            JOIN schedules sc2 ON sc2.section_id = d2.section_id AND sc2.subject_id = d2.subject_id
            WHERE d.section_id = @sec AND d.subject_id = @sub
              AND sc2.day = @day AND sc2.start_time < @end AND @start < sc2.end_time;
            """,
            ("@sec", e.SectionId), ("@sub", e.SubjectId),
            ("@day", e.Day), ("@start", e.Start), ("@end", e.End));

        if (affected > 0)
        {
            throw new BusinessRuleException(
                $"This time would overlap another subject already enrolled by {affected} student(s). " +
                "Choose a different time, or ask those students to re-enroll first.");
        }
    }

    private static ScheduleEntry? ReadEntry(
        MySqlConnection connection,
        MySqlTransaction transaction,
        int scheduleId)
    {
        DataTable t = Sql.Table(connection, transaction,
            "SELECT * FROM schedules WHERE schedule_id = @id;", ("@id", scheduleId));

        if (t.Rows.Count == 0)
        {
            return null;
        }

        DataRow r = t.Rows[0];

        return new ScheduleEntry(
            Convert.ToInt32(r["schedule_id"]),
            Convert.ToInt32(r["section_id"]),
            Convert.ToInt32(r["subject_id"]),
            r["instructor"] as string,
            r["room"] as string,
            Convert.ToString(r["day"]) ?? "",
            (TimeSpan)r["start_time"],
            (TimeSpan)r["end_time"]);
    }

    private void NotifyAffected(
        MySqlConnection connection,
        MySqlTransaction transaction,
        int sectionId,
        int subjectId,
        string title,
        string message)
    {
        DataTable users = Sql.Table(connection, transaction, """
            SELECT DISTINCT u.user_id
            FROM enrollment_details d
            JOIN enrollments e ON e.enrollment_id = d.enrollment_id AND e.status IN ('Pending', 'Approved')
            JOIN users u ON u.student_id = e.student_id AND u.role = 'Student'
            WHERE d.section_id = @sec AND d.subject_id = @sub;
            """, ("@sec", sectionId), ("@sub", subjectId));

        foreach (DataRow row in users.Rows)
        {
            _notifications.Create(connection, transaction, Convert.ToInt32(row["user_id"]),
                title, message, "schedule");
        }
    }


    public void SavePattern(
        int sectionId,
        int subjectId,
        string? instructor,
        string? room,
        IEnumerable<string> selectedDays,
        TimeSpan start,
        TimeSpan end)
    {
        Session.RequireAdmin();

        string[] days = selectedDays
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToArray();

        if (days.Length == 0 || days.Any(day => !Academic.Days.Contains(day)))
        {
            throw new BusinessRuleException("Please choose valid schedule days.");
        }

        if (end <= start)
        {
            throw new BusinessRuleException("The end time must be after the start time.");
        }

        instructor = string.IsNullOrWhiteSpace(instructor) ? null : instructor.Trim();
        room = string.IsNullOrWhiteSpace(room) ? null : room.Trim();

        using var connection = _database.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            DataTable sectionTable = Sql.Table(connection, transaction, """
            SELECT section_id, section_code, program_id, year_level,
                   semester, school_year, status
            FROM sections
            WHERE section_id = @id
            FOR UPDATE;
            """, ("@id", sectionId));

            if (sectionTable.Rows.Count == 0)
            {
                throw new BusinessRuleException("That section no longer exists.");
            }

            DataRow section = sectionTable.Rows[0];

            int inCurriculum = Sql.Int(connection, transaction, """
            SELECT COUNT(*)
            FROM curriculum
            WHERE program_id = @p
              AND subject_id = @s
              AND year_level = @y
              AND semester = @sem;
            """,
                ("@p", section["program_id"]),
                ("@s", subjectId),
                ("@y", section["year_level"]),
                ("@sem", section["semester"]));

            if (inCurriculum == 0)
            {
                throw new BusinessRuleException(
                    "That subject is not in this section's curriculum.");
            }

            foreach (string day in days)
            {
                var entry = new ScheduleEntry(
                    0,
                    sectionId,
                    subjectId,
                    instructor,
                    room,
                    day,
                    start,
                    end);

                // Reuse the existing conflict-checking logic.
                CheckResourceConflicts(connection, transaction, entry, section);
                CheckEnrolledStudentConflicts(connection, transaction, entry);

                int id = (int)Sql.Insert(connection, transaction, """
                INSERT INTO schedules
                    (section_id, subject_id, instructor, room, day,
                     start_time, end_time)
                VALUES
                    (@sec, @sub, @ins, @room, @day, @start, @end);
                """,
                    ("@sec", sectionId),
                    ("@sub", subjectId),
                    ("@ins", instructor),
                    ("@room", room),
                    ("@day", day),
                    ("@start", start),
                    ("@end", end));

                string description =
                    $"{section["section_code"]}: {day} " +
                    $"{Academic.FormatTime(start)}-{Academic.FormatTime(end)}" +
                    (room == null ? "" : " @ " + room);

                NotifyAffected(
                    connection, transaction, sectionId, subjectId,
                    "Schedule changed",
                    "A class meeting was added: " + description +
                    ". Please review your timetable.");

                _audit.Log(
                    connection, transaction,
                    "SCHEDULE_ADDED", "schedule", id.ToString(), description);
            }

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

}
