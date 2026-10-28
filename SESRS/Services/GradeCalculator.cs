using SESRS.Helpers;
using SESRS.Models;

namespace SESRS.Services;

/// <summary>Pure grade math: weighted percent, then percent to grade point through the scale.</summary>
public static class GradeCalculator
{
    public static GradeComputation Compute(
        IReadOnlyList<GradeComponent> components,
        IReadOnlyList<ScaleRow> scale,
        IReadOnlyDictionary<int, decimal?> scores,
        string? special)
    {
        if (special == "Incomplete")
        {
            return new GradeComputation(null, null, "Incomplete");
        }

        if (special == "Dropped")
        {
            return new GradeComputation(null, null, "Dropped");
        }

        decimal total = 0;

        foreach (GradeComponent component in components)
        {
            if (!scores.TryGetValue(component.ComponentId, out decimal? score) || score == null)
            {
                return new GradeComputation(null, null, "Pending");
            }

            if (score < 0 || score > 100)
            {
                throw new BusinessRuleException(
                    $"Scores must be between 0 and 100 ({component.Name}: {score}).");
            }

            total += score.Value * component.Weight / 100m;
        }

        decimal percent = Math.Round(total, 2, MidpointRounding.AwayFromZero);

        ScaleRow? row = scale
            .Where(s => s.MinPercent <= percent)
            .OrderByDescending(s => s.MinPercent)
            .FirstOrDefault();

        // With no matching row (a scale that does not start at 0) the student does not pass.
        return row == null
            ? new GradeComputation(percent, 5.00m, "Failed")
            : new GradeComputation(percent, row.GradePoint, row.Result);
    }

    /// <summary>Returns an error when the weights do not add up to exactly 100.</summary>
    public static string? ValidateWeights(IReadOnlyList<GradeComponent> components)
    {
        if (components.Count == 0)
        {
            return "No grading components are set up for this subject.";
        }

        decimal sum = components.Sum(c => c.Weight);

        return Math.Abs(sum - 100m) < 0.005m
            ? null
            : $"The grading components add up to {sum:0.##}%. They must add up to exactly 100%.";
    }
}
