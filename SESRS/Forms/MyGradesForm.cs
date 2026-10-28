using System.Data;
using SESRS.Helpers;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Published grades of the signed-in student, with the weighted average and a printable report.</summary>
public partial class MyGradesForm : Form
{
    private readonly GradeService _service = new();
    private readonly StudentPortalService _portal = new();
    private readonly int _studentId;
    private readonly ListGrid _list;

    public MyGradesForm(int studentId)
    {
        InitializeComponent();
        _studentId = studentId;

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "No grades have been published for you yet."
        };
    }

    private void MyGradesForm_Load(object? sender, EventArgs e)
    {
        _list.Run(() =>
        {
            GradeSummary summary = _service.GetSummary(_studentId);

            _list.SetSubtitle(summary.Gpa == null
                ? "Official grades published by the registrar"
                : $"General weighted average: {summary.Gpa:0.00}   |   Units earned: {summary.UnitsEarned}   |   Units graded: {summary.UnitsAttempted}");

            _list.SetData(_service.GetMyGrades(_studentId));
        });
    }

    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("my_grades"));
    private void btnPrintReport_Click(object? sender, EventArgs e) => _list.Run(PrintGradeReport);

    private void PrintGradeReport()
    {
        DataTable grades = _service.GetMyGrades(_studentId);

        if (grades.Rows.Count == 0)
        {
            MessageBox.Show("There are no published grades to print yet.", "Grade Report",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        StudentProfile profile = _portal.GetProfile(_studentId);
        GradeSummary summary = _service.GetSummary(_studentId);

        var document = new ReportDocument { Title = "Grade Report", Subtitle = "Published grades only" };

        document.Header.Add(("Student No.", profile.StudentNumber));
        document.Header.Add(("Name", profile.FullName));
        document.Header.Add(("Program", $"{profile.ProgramCode} - {profile.ProgramName}"));
        document.Header.Add(("Year level", Academic.YearLabel(profile.YearLevel)));

        document.AddColumn("School year", 1f);
        document.AddColumn("Semester", 1.1f);
        document.AddColumn("Code", 0.9f);
        document.AddColumn("Subject", 2.6f);
        document.AddColumn("Units", 0.55f);
        document.AddColumn("Grade", 0.7f);
        document.AddColumn("Result", 0.9f);

        foreach (DataRow r in grades.Rows)
        {
            document.Rows.Add(new[]
            {
                Convert.ToString(r["school_year"]) ?? "", Convert.ToString(r["semester"]) ?? "",
                Convert.ToString(r["subject_code"]) ?? "", Convert.ToString(r["subject_name"]) ?? "",
                Convert.ToString(r["units"]) ?? "",
                r["final_grade"] == DBNull.Value ? "-" : Convert.ToDecimal(r["final_grade"]).ToString("0.00"),
                Convert.ToString(r["result"]) ?? ""
            });
        }

        document.Footer.Add(
            $"General weighted average: {(summary.Gpa?.ToString("0.00") ?? "-")}     " +
            $"Units earned: {summary.UnitsEarned}     Units graded: {summary.UnitsAttempted}");
        document.Footer.Add("This report lists only grades officially published by the registrar.");

        PrintReport.Preview(this, document);
    }
}
