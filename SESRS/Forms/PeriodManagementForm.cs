using System.Data;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class PeriodManagementForm : Form
{
    private readonly PeriodService _service = new();
    private readonly ListGrid _list;

    public PeriodManagementForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "No academic periods yet. Click ADD PERIOD to create the first one."
        };
        _list.RowActivated += (_, _) => _list.Run(Edit);
    }

    private void PeriodManagementForm_Load(object? sender, EventArgs e) => ReloadData();

    private void ReloadData() => _list.Run(() => _list.SetData(_service.GetAll(), "period_id"));

    private void btnAdd_Click(object? sender, EventArgs e) => _list.Run(() => ShowEditor(null));
    private void btnEdit_Click(object? sender, EventArgs e) => _list.Run(Edit);
    private void btnSetCurrent_Click(object? sender, EventArgs e) => _list.Run(SetCurrent);
    private void btnDelete_Click(object? sender, EventArgs e) => _list.Run(Delete);

    private void Edit()
    {
        DataRow? row = _list.RequireRow("period");

        if (row == null)
        {
            return;
        }

        AcademicPeriod? period = _service.Get(Convert.ToInt32(row["period_id"]));

        if (period == null)
        {
            ReloadData();
            return;
        }

        ShowEditor(period);
    }

    private void SetCurrent()
    {
        DataRow? row = _list.RequireRow("period");

        if (row == null)
        {
            return;
        }

        if (!_list.Confirm(
            $"Make {row["school_year"]}, {row["semester"]} the current term?\n\n" +
            "Students will enroll for this term, and the sections they see come from it."))
        {
            return;
        }

        _service.SetCurrent(Convert.ToInt32(row["period_id"]));
        _list.Success("Current term updated.");
        ReloadData();
    }

    private void Delete()
    {
        DataRow? row = _list.RequireRow("period");

        if (row == null || !_list.Confirm($"Delete {row["school_year"]}, {row["semester"]}? This cannot be undone."))
        {
            return;
        }

        _service.Delete(Convert.ToInt32(row["period_id"]));
        _list.Success("Period deleted.");
        ReloadData();
    }

    private void ShowEditor(AcademicPeriod? existing)
    {
        using var dialog = new PeriodEditDialog(existing);

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success(existing == null ? "Period added." : "Period updated.");
            ReloadData();
        }
    }
}
