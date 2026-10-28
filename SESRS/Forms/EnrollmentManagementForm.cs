using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Administrator review of student enrollment requests.</summary>
public partial class EnrollmentManagementForm : Form
{
    private readonly EnrollmentService _service = new();
    private readonly PeriodService _periods = new();
    private readonly ListGrid _list;
    private bool _ready;

    public EnrollmentManagementForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "No enrollment requests match these filters."
        };
        _list.RowActivated += (_, _) => _list.Run(ShowDetails);
    }

    private void EnrollmentManagementForm_Load(object? sender, EventArgs e)
    {
        _list.Run(() =>
        {
            cmbStatus.SelectedItem = "Pending";

            DialogHelper.Fill(cmbTerm, new[] { new ChoiceItem("", "All terms") }
                .Concat(_periods.GetAll().Rows.Cast<DataRow>().Select(r =>
                {
                    string label = $"{r["school_year"]}, {r["semester"]}";
                    return new ChoiceItem(label, label);
                })));

            cmbTerm.SelectedIndex = 0;
        });

        _ready = true;
        ReloadData();
    }

    private void cmbStatus_SelectedIndexChanged(object? sender, EventArgs e) { if (_ready) ReloadData(); }
    private void cmbTerm_SelectedIndexChanged(object? sender, EventArgs e) { if (_ready) ReloadData(); }

    private void ReloadData()
    {
        _list.Run(() =>
        {
            string? schoolYear = null, semester = null;

            if (cmbTerm.SelectedItem is ChoiceItem { Value: string chosen } && chosen.Length > 0)
            {
                string[] parts = chosen.Split(new[] { ", " }, 2, StringSplitOptions.None);
                schoolYear = parts[0];
                semester = parts.Length > 1 ? parts[1] : null;
            }

            _list.SetData(_service.GetEnrollments(cmbStatus.SelectedItem?.ToString() ?? "All", schoolYear, semester),
                "enrollment_id");
        });
    }

    private void btnDetails_Click(object? sender, EventArgs e) => _list.Run(ShowDetails);
    private void btnApprove_Click(object? sender, EventArgs e) =>
        _list.Run(() => Decide("Approve", false, (id, r) => _service.Approve(id, r)));
    private void btnReturn_Click(object? sender, EventArgs e) =>
        _list.Run(() => Decide("Return for correction", true, (id, r) => _service.ReturnForCorrection(id, r!)));
    private void btnReject_Click(object? sender, EventArgs e) =>
        _list.Run(() => Decide("Reject", true, (id, r) => _service.Reject(id, r!)));
    private void btnCancelEnrollment_Click(object? sender, EventArgs e) => _list.Run(CancelEnrollment);
    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("enrollments"));

    private void ShowDetails()
    {
        DataRow? row = _list.RequireRow("enrollment");

        if (row == null)
        {
            return;
        }

        int id = Convert.ToInt32(row["enrollment_id"]);
        var summary = _service.GetSummary(id);
        DataTable lines = _service.GetEnrollmentLines(id);

        string text = $"{summary.Student}   |   {summary.Term}   |   {summary.Units} units   |   {summary.Status}";

        if (summary.Remarks.Length > 0)
        {
            text += "\nRemarks: " + summary.Remarks;
        }

        using var dialog = new TableDialog("Enrollment Details", text, lines, "enrollment_" + id, "enrollment_detail_id");
        dialog.ShowDialog(this);
    }

    private void Decide(string verb, bool requireRemarks, Action<int, string?> action)
    {
        DataRow? row = _list.RequireRow("enrollment");

        if (row == null)
        {
            return;
        }

        int id = Convert.ToInt32(row["enrollment_id"]);

        using var dialog = new ReasonDialog(
            verb + " - " + row["student_name"],
            requireRemarks
                ? "The student will be notified and will see these remarks."
                : "Remarks are optional. The student will be notified of your decision.",
            verb.ToUpper(), requireRemarks, remarks => action(id, remarks));

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success("Done: " + verb.ToLower() + ".");
            ReloadData();
        }
    }

    private void CancelEnrollment()
    {
        DataRow? row = _list.RequireRow("enrollment");

        if (row == null || !_list.Confirm($"Cancel the enrollment of {row["student_name"]}?\n\n" +
                                          "Their slots are released and the student is notified."))
        {
            return;
        }

        _service.Cancel(Convert.ToInt32(row["enrollment_id"]));
        _list.Success("Enrollment cancelled.");
        ReloadData();
    }
}
