namespace SESRS.Models;

public class AcademicProgram
{
    public int ProgramId { get; set; }

    public string ProgramCode { get; set; } = string.Empty;

    public string ProgramName { get; set; } = string.Empty;

    public int DurationYears { get; set; }

    public string Status { get; set; } = "Active";
}