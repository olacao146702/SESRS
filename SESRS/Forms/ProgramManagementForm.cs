using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

public partial class ProgramManagementForm : Form
{
    private readonly ProgramService _service = new();
    private readonly ListGrid _list;

    public ProgramManagementForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "No programs yet. Click ADD PROGRAM to create the first one."
        };
        _list.RowActivated += (_, _) => _list.Run(Edit);
    }

    private void ProgramManagementForm_Load(object? sender, EventArgs e) => ReloadData();

    private void ReloadData() => _list.Run(() => _list.SetData(_service.GetAllPrograms(), "program_id"));

    private void btnAdd_Click(object? sender, EventArgs e) => _list.Run(() => ShowEditor(null));
    private void btnEdit_Click(object? sender, EventArgs e) => _list.Run(Edit);
    private void btnToggle_Click(object? sender, EventArgs e) => _list.Run(Toggle);
    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("programs"));

    private void Edit()
    {
        DataRow? row = _list.RequireRow("program");

        if (row == null)
        {
            return;
        }

        DataTable t = _service.GetProgramById(Convert.ToInt32(row["program_id"]));

        if (t.Rows.Count == 0)
        {
            ReloadData();
            return;
        }

        ShowEditor(t.Rows[0]);
    }

    private void Toggle()
    {
        DataRow? row = _list.RequireRow("program");

        if (row == null)
        {
            return;
        }

        bool active = Convert.ToString(row["status"]) == "Active";

        if (!_list.Confirm($"{(active ? "Deactivate" : "Activate")} {row["program_code"]}?"))
        {
            return;
        }

        _service.ToggleProgramStatus(Convert.ToInt32(row["program_id"]));
        _list.Success("Status updated.");
        ReloadData();
    }

    private void ShowEditor(DataRow? existing)
    {
        using var dialog = new ProgramEditDialog(existing);

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success(existing == null ? "Program added." : "Program updated.");
            ReloadData();
        }
    }
}
