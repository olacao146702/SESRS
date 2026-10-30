
using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

public partial class SubjectManagementForm : Form
{
    private readonly SubjectService _service = new();
    private readonly ListGrid _list;

    public SubjectManagementForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "No subjects yet. Click ADD SUBJECT to create the first one."
        };

        _list.RowActivated += (_, _) => _list.Run(Edit);
    }

    private void SubjectManagementForm_Load(object? sender, EventArgs e) => ReloadData();

    private void ReloadData() => _list.Run(() => _list.SetData(_service.GetAllSubjects(), "subject_id"));

    private void btnAdd_Click(object? sender, EventArgs e) => _list.Run(() => ShowEditor(null));

    private void btnEdit_Click(object? sender, EventArgs e) => _list.Run(Edit);

    private void btnToggle_Click(object? sender, EventArgs e) => _list.Run(Toggle);

    private void btnDelete_Click(object? sender, EventArgs e) => _list.Run(Delete);

    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("subjects"));

    private void Edit()
    {
        DataRow? row = _list.RequireRow("subject");

        if (row == null)
        {
            return;
        }

        DataTable t = _service.GetSubjectById(Convert.ToInt32(row["subject_id"]));

        if (t.Rows.Count == 0)
        {
            ReloadData();
            return;
        }

        ShowEditor(t.Rows[0]);
    }

    private void Toggle()
    {
        DataRow? row = _list.RequireRow("subject");

        if (row == null)
        {
            return;
        }

        bool active = Convert.ToString(row["status"]) == "Active";

        string warning = active
            ? "\n\nIt will no longer be offered to students for new enrollments."
            : "";

        if (!_list.Confirm($"{(active ? "Deactivate" : "Activate")} {row["subject_code"]}?{warning}"))
        {
            return;
        }

        _service.ToggleSubjectStatus(Convert.ToInt32(row["subject_id"]));

        _list.Success("Status updated.");

        ReloadData();
    }

    private void Delete()
    {
        DataRow? row = _list.RequireRow("subject");

        if (row == null)
        {
            return;
        }

        int subjectId = Convert.ToInt32(row["subject_id"]);
        string subjectCode = Convert.ToString(row["subject_code"]) ?? "";

        if (!_list.Confirm(
            $"Permanently delete subject {subjectCode}?\n\n" +
            "This action cannot be undone. Subjects with existing records cannot be deleted."))
        {
            return;
        }

        if (_service.DeleteSubject(subjectId))
        {
            _list.Success("Subject permanently deleted.");
            ReloadData();
        }
    }

    private void ShowEditor(DataRow? existing)
    {
        using var dialog = new SubjectEditDialog(existing);

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success(existing == null ? "Subject added." : "Subject updated.");
            ReloadData();
        }
    }
}
