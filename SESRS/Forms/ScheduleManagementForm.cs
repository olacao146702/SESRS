using System.Data;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class ScheduleManagementForm : Form
{
    private readonly ScheduleService _service = new();
    private readonly EnrollmentService _enrollments = new();
    private readonly ListGrid _list;
    private bool _ready;

    public ScheduleManagementForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "This section has no class meetings yet. Click ADD MEETING."
        };
        _list.RowActivated += (_, _) => _list.Run(Edit);
    }

    private int? SectionId => (cmbSection.SelectedItem as ChoiceItem)?.Value as int?;

    private void ScheduleManagementForm_Load(object? sender, EventArgs e)
    {
        _list.Run(() =>
        {
            DialogHelper.Fill(cmbSection, _service.GetSectionChoices().Rows.Cast<DataRow>().Select(r =>
                new ChoiceItem(Convert.ToInt32(r["section_id"]), Convert.ToString(r["label"]) ?? "")));

            if (cmbSection.Items.Count > 0)
            {
                cmbSection.SelectedIndex = 0;
            }
        });

        _ready = true;
        ReloadData();
    }

    private void cmbSection_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_ready)
        {
            ReloadData();
        }
    }

    private void ReloadData()
    {
        _list.Run(() =>
        {
            if (SectionId is not int sectionId)
            {
                _list.EmptyMessage = "There are no sections yet. Create sections under Academics > Sections first.";
                _list.SetData(new DataTable());
                return;
            }

            _list.SetData(_service.GetForSection(sectionId), "schedule_id");
        });
    }

    private void btnAdd_Click(object? sender, EventArgs e) => _list.Run(() => ShowEditor(null));
    private void btnEdit_Click(object? sender, EventArgs e) => _list.Run(Edit);
    private void btnDelete_Click(object? sender, EventArgs e) => _list.Run(Delete);
    private void btnClassList_Click(object? sender, EventArgs e) => _list.Run(ShowClassList);
    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("schedule"));

    private void Edit()
    {
        DataRow? row = _list.RequireRow("meeting");

        if (row == null)
        {
            return;
        }

        ScheduleEntry? entry = _service.Get(Convert.ToInt32(row["schedule_id"]));

        if (entry == null)
        {
            ReloadData();
            return;
        }

        ShowEditor(entry);
    }

    private void Delete()
    {
        DataRow? row = _list.RequireRow("meeting");

        if (row == null || !_list.Confirm($"Delete the {row["day"]} meeting of {row["subject_code"]}?\n\n" +
                                          "Students enrolled in it will be notified."))
        {
            return;
        }

        _service.Delete(Convert.ToInt32(row["schedule_id"]));
        _list.Success("Meeting deleted.");
        ReloadData();
    }

    private void ShowClassList()
    {
        DataRow? row = _list.RequireRow("meeting");

        if (row == null || SectionId is not int sectionId)
        {
            return;
        }

        ScheduleEntry? entry = _service.Get(Convert.ToInt32(row["schedule_id"]));

        if (entry == null)
        {
            return;
        }

        DataTable list = _enrollments.GetClassList(sectionId, entry.SubjectId, true);

        using var dialog = new TableDialog("Class List",
            $"{row["subject_code"]} - {row["subject_name"]}   |   {cmbSection.Text}   |   {list.Rows.Count} student(s)",
            list, "class_list_" + row["subject_code"]);

        dialog.ShowDialog(this);
    }

    private void ShowEditor(ScheduleEntry? existing)
    {
        if (SectionId is not int sectionId)
        {
            return;
        }

        if (_service.GetSubjectChoices(sectionId).Count == 0)
        {
            MessageBox.Show(
                "This section's program, year level and semester has no subjects in the curriculum yet.\n\n" +
                "Add them under Academics > Curriculum first.", "Add Meeting",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new ScheduleMeetingDialog(sectionId, existing);

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success(existing == null ? "Meeting added." : "Meeting updated.");
            ReloadData();
        }
    }
}
