using System.Data;

namespace SESRS.Models;

public sealed record GradeComponent(int ComponentId, int? SubjectId, string Name, decimal Weight, int SortOrder);

public sealed record ScaleRow(int ScaleId, decimal MinPercent, decimal GradePoint, string Result);

/// <summary>Scores for one student (null = not graded yet). Special is null, "Incomplete" or "Dropped".</summary>
public sealed record GradeEntry(int StudentId, IReadOnlyDictionary<int, decimal?> Scores, string? Special);

public sealed record GradeComputation(decimal? Percent, decimal? GradePoint, string Result);

public sealed class GradeSheet
{
    public int SectionId { get; init; }
    public int SubjectId { get; init; }
    public string ClassLabel { get; init; } = "";
    public string SchoolYear { get; init; } = "";
    public string Semester { get; init; } = "";
    public List<GradeComponent> Components { get; init; } = new();
    public List<ScaleRow> Scale { get; init; } = new();
    public DataTable Rows { get; init; } = new();
}

public sealed record GradeSummary(decimal? Gpa, int UnitsEarned, int UnitsAttempted);
