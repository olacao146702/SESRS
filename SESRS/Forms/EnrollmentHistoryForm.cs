using System.Data;
using SESRS.Helpers;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>The student's enrollment history, details and printable enrollment slip.</summary>
public partial class EnrollmentHistoryForm : Form
{
    private readonly EnrollmentService _service = new();
    private readonly StudentPortalService _portal = new();
    private readonly int _studentId;
    private readonly ListGrid _list;

    public EnrollmentHistoryForm(int studentId)
    {
        InitializeComponent();
        _studentId = studentId;

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "You have not submitted any enrollment yet."
        };
        _list.RowActivated += (_, _) => _list.Run(ShowDetails);
    }

    private void EnrollmentHistoryForm_Load(object? sender, EventArgs e) =>
        _list.Run(() => _list.SetData(_service.GetMyEnrollments(_studentId), "enrollment_id"));

    private void btnDetails_Click(object? sender, EventArgs e) => _list.Run(ShowDetails);
    private void btnSlip_Click(object? sender, EventArgs e) => _list.Run(PrintSlip);

    private void ShowDetails()
    {
        DataRow? row = _list.RequireRow("enrollment");

        if (row == null)
        {
            return;
        }

        int id = Convert.ToInt32(row["enrollment_id"]);
        string summary = $"{row["school_year"]}, {row["semester"]}   |   {row["status"]}   |   {row["total_units"]} units";
        string remarks = Convert.ToString(row["remarks"]) ?? "";

        if (remarks.Length > 0)
        {
            summary += "\nRemarks: " + remarks;
        }

        using var dialog = new TableDialog("Enrollment Details", summary, _service.GetEnrollmentLines(id),
            "enrollment_" + id, "enrollment_detail_id");

        dialog.ShowDialog(this);
    }

    private void PrintSlip()
    {
        DataRow? row = _list.RequireRow("enrollment");

        if (row == null)
        {
            return;
        }

        if (Convert.ToString(row["status"]) != "Approved")
        {
            MessageBox.Show(
                "An enrollment slip can only be printed for an approved enrollment.\n\n" +
                "This enrollment is " + Convert.ToString(row["status"])!.ToLower() + ".",
                "Enrollment Slip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        StudentProfile profile = _portal.GetProfile(_studentId);
        DataTable lines = _service.GetEnrollmentLines(Convert.ToInt32(row["enrollment_id"]));

        var document = new ReportDocument
        {
            Title = "Enrollment Slip",
            Subtitle = $"{row["school_year"]}, {row["semester"]}",
            Landscape = true
        };

        document.Header.Add(("Student No.", profile.StudentNumber));
        document.Header.Add(("Name", profile.FullName));
        document.Header.Add(("Program", $"{profile.ProgramCode} - {profile.ProgramName}"));
        document.Header.Add(("Year level", Academic.YearLabel(profile.YearLevel)));
        document.Header.Add(("Status", "Approved"));
        document.Header.Add(("Approved on", row["reviewed_at"] is DateTime d ? d.ToString("MMM d, yyyy") : "-"));

        document.AddColumn("Code", 0.8f);
        document.AddColumn("Subject", 2.2f);
        document.AddColumn("Units", 0.5f);
        document.AddColumn("Section", 0.8f);
        document.AddColumn("Schedule", 2.4f);
        document.AddColumn("Room", 0.9f);
        document.AddColumn("Instructor", 1.4f);

        foreach (DataRow line in lines.Rows)
        {
            document.Rows.Add(new[]
            {
                Convert.ToString(line["subject_code"]) ?? "", Convert.ToString(line["subject_name"]) ?? "",
                Convert.ToString(line["units"]) ?? "", Convert.ToString(line["section_code"]) ?? "",
                Convert.ToString(line["schedule"]) ?? "", Convert.ToString(line["room"]) ?? "",
                Convert.ToString(line["instructor"]) ?? ""
            });
        }

        document.Footer.Add($"Total subjects: {lines.Rows.Count}     Total units: {row["total_units"]}");
        document.Footer.Add("This slip is valid only for an enrollment approved by the registrar.");

        PrintReport.Preview(this, document);
    }
}
