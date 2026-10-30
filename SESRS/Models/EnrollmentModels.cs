namespace SESRS.Models;

public static class Academic
{
    public static readonly string[] Semesters = { "1st Semester", "2nd Semester", "Summer" };

    public static readonly string[] Days =
        { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    public static string FormatTime(TimeSpan time)
    {
        return DateTime.Today.Add(time).ToString("h:mm tt");
    }

    public static string YearLabel(int year)
    {
        return year switch
        {
            1 => "1st Year",
            2 => "2nd Year",
            3 => "3rd Year",
            _ => year + "th Year"
        };
    }
}

public sealed record AcademicPeriod(
    int PeriodId,
    string SchoolYear,
    string Semester,
    DateTime EnrollmentStart,
    DateTime EnrollmentEnd,
    int MinUnits,
    int MaxUnits,
    bool IsCurrent)
{
    public string Label => $"{SchoolYear}, {Semester}";

    public bool IsOpenOn(DateTime date)
    {
        return date.Date >= EnrollmentStart.Date && date.Date <= EnrollmentEnd.Date;
    }
}

public sealed record MeetingTime(
    string Day,
    TimeSpan Start,
    TimeSpan End,
    string? Room,
    string? Instructor)
{
    public string Text =>
        $"{Day[..3]} {Academic.FormatTime(Start)}-{Academic.FormatTime(End)}";

    public bool Overlaps(MeetingTime other)
    {
        return Day == other.Day && Start < other.End && other.Start < End;
    }
}

public sealed class SectionOffer
{
    public int SectionId { get; init; }
    public string SectionCode { get; init; } = "";
    public string SectionName { get; init; } = "";
    public int Capacity { get; init; }
    public int Taken { get; init; }
    public List<MeetingTime> Meetings { get; init; } = new();

    public int Available => Math.Max(0, Capacity - Taken);


    public string ScheduleText => Meetings.Count == 0
        ? "No schedule"
        : string.Join("; ", Meetings
            .GroupBy(m => new
            {
                m.Start,
                m.End,
                m.Room,
                m.Instructor
            })
            .Select(group =>
            {
                var days = group
                    .Select(m => m.Day)
                    .Distinct()
                    .OrderBy(day => Array.IndexOf(Academic.Days, day))
                    .ToList();

                string dayText = FormatDays(days);

                string timeText =
                    $"{Academic.FormatTime(group.Key.Start)}-" +
                    $"{Academic.FormatTime(group.Key.End)}";

                string roomText = string.IsNullOrWhiteSpace(group.Key.Room)
                    ? ""
                    : $" @ {group.Key.Room}";

                return $"{dayText} {timeText}{roomText}";
            }));

    private static string FormatDays(List<string> days)
    {
        var abbreviations = days.Select(day => day switch
        {
            "Monday" => "M",
            "Tuesday" => "T",
            "Wednesday" => "W",
            "Thursday" => "TH",
            "Friday" => "F",
            "Saturday" => "SAT",
            "Sunday" => "SUN",
            _ => day
        }).ToList();

        if (days.SequenceEqual(new[]
            { "Monday", "Wednesday", "Friday" }))
            return "MWF";

        if (days.SequenceEqual(new[]
            { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" }))
            return "Monday-Friday";

        if (days.SequenceEqual(new[]
            { "Monday", "Tuesday", "Wednesday" }))
            return "MSAT1";

        if (days.SequenceEqual(new[]
            { "Thursday", "Friday", "Saturday" }))
            return "MSAT2";

        return string.Join("", abbreviations);
    }


    public string InstructorText => string.Join(
        ", ",
        Meetings.Select(m => m.Instructor)
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Distinct()!);
}

public enum OfferingStatus
{
    Available,
    Completed,
    PrerequisiteMissing,
    NoSections
}

public sealed class SubjectOffering
{
    public int SubjectId { get; init; }
    public string SubjectCode { get; init; } = "";
    public string SubjectName { get; init; } = "";
    public int Units { get; init; }
    public int YearLevel { get; init; }
    public string Prerequisites { get; init; } = "";
    public OfferingStatus Status { get; set; } = OfferingStatus.Available;
    public string StatusMessage { get; set; } = "";
    public List<SectionOffer> Sections { get; init; } = new();
}

public sealed record Selection(int SubjectId, int SectionId);

public sealed record ValidationIssue(
    string Message,
    int? SubjectId = null,
    IReadOnlyList<string>? Suggestions = null);

public sealed class ValidationResult
{
    public List<ValidationIssue> Issues { get; } = new();
    public Dictionary<int, int> UnitsBySubject { get; } = new();
    public int TotalUnits => UnitsBySubject.Values.Sum();
    public bool IsValid => Issues.Count == 0;
}

public sealed record EnrollmentContext(
    AcademicPeriod? Period,
    bool IsOpen,
    string StatusMessage,
    int? EnrollmentId,
    string? EnrollmentStatus,
    string? ReviewRemarks);

public sealed record ScheduleEntry(
    int ScheduleId,
    int SectionId,
    int SubjectId,
    string? Instructor,
    string? Room,
    string Day,
    TimeSpan Start,
    TimeSpan End);
