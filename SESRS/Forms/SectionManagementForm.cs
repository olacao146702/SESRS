using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

public partial class SectionManagementForm : Form
{
    private readonly SectionService _service = new();
    private readonly ListGrid _list;

    public SectionManagementForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "No sections yet. Click ADD SECTION to create the first one."
        };
        _list.RowActivated += (_, _) => _list.Run(Edit);
    }

    private void SectionManagementForm_Load(object? sender, EventArgs e) => ReloadData();

    private void ReloadData() => _list.Run(() => _list.SetData(_service.GetAllSections(), "section_id", "program_name"));

    private void btnAdd_Click(object? sender, EventArgs e) => _list.Run(() => ShowEditor(null));
    private void btnEdit_Click(object? sender, EventArgs e) => _list.Run(Edit);
    private void btnToggle_Click(object? sender, EventArgs e) => _list.Run(Toggle);
    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("sections"));

    private void Edit()
    {
        DataRow? row = _list.RequireRow("section");

        if (row == null)
        {
            return;
        }

        DataTable t = _service.GetSectionById(Convert.ToInt32(row["section_id"]));

        if (t.Rows.Count == 0)
        {
            ReloadData();
            return;
        }

        ShowEditor(t.Rows[0]);
    }

    private void Toggle()
    {
        DataRow? row = _list.RequireRow("section");

        if (row == null)
        {
            return;
        }

        bool active = Convert.ToString(row["status"]) == "Active";

        if (!_list.Confirm($"{(active ? "Deactivate" : "Activate")} section {row["section_code"]}?"))
        {
            return;
        }

        _service.ToggleSectionStatus(Convert.ToInt32(row["section_id"]));
        _list.Success("Status updated.");
        ReloadData();
    }

    private void ShowEditor(DataRow? existing)
    {
        if (_service.GetActivePrograms().Rows.Count == 0)
        {
            MessageBox.Show("There are no active programs. Add a program first.", "Add Section",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new SectionEditDialog(existing);

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success(existing == null ? "Section added." : "Section updated.");
            ReloadData();
        }
    }
}
