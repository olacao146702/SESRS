using System.Data;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Grading components (weights) and the percent-to-grade scale.</summary>
public partial class GradingSetupForm : Form
{
    private readonly GradeService _service = new();
    private readonly ListGrid _list;
    private bool _ready;

    public GradingSetupForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "Nothing is set up yet. Click ADD."
        };
        _list.RowActivated += (_, _) => _list.Run(Edit);
    }

    private bool ShowingComponents => cmbSetting.SelectedIndex == 0;

    private void GradingSetupForm_Load(object? sender, EventArgs e)
    {
        cmbSetting.SelectedIndex = 0;
        _ready = true;
        ReloadData();
    }

    private void cmbSetting_SelectedIndexChanged(object? sender, EventArgs e)
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
            if (ShowingComponents)
            {
                DataTable table = _service.GetComponentsTable();

                var totals = table.Rows.Cast<DataRow>()
                    .GroupBy(r => Convert.ToString(r["applies_to"]) ?? "")
                    .Select(g => (Scope: g.Key, Total: g.Sum(r => Convert.ToDecimal(r["weight"]))))
                    .ToList();

                string summary = string.Join("   |   ", totals.Select(t =>
                    $"{t.Scope}: {t.Total:0.##}%" + (Math.Abs(t.Total - 100m) < 0.005m ? "" : "  (must be 100%)")));

                _list.SetSubtitle(summary.Length == 0
                    ? "Each subject's component weights must add up to exactly 100%."
                    : summary);

                _list.SetData(table, "component_id", "subject_id");
            }
            else
            {
                _list.SetSubtitle("Changes apply to grades saved afterwards. Grades already saved keep their values.");
                _list.SetData(_service.GetScaleTable(), "scale_id");
            }
        });
    }

    private void btnAdd_Click(object? sender, EventArgs e) => _list.Run(Add);
    private void btnEdit_Click(object? sender, EventArgs e) => _list.Run(Edit);
    private void btnDelete_Click(object? sender, EventArgs e) => _list.Run(Delete);

    private void Add()
    {
        if (ShowingComponents)
        {
            ShowComponent(null);
        }
        else
        {
            ShowScale(null);
        }
    }

    private void Edit()
    {
        DataRow? row = _list.RequireRow("row");

        if (row == null)
        {
            return;
        }

        if (ShowingComponents)
        {
            ShowComponent(_service.GetComponent(Convert.ToInt32(row["component_id"])));
        }
        else
        {
            ShowScale(_service.GetScaleRow(Convert.ToInt32(row["scale_id"])));
        }
    }

    private void Delete()
    {
        DataRow? row = _list.RequireRow("row");

        if (row == null || !_list.Confirm("Delete the selected row? This cannot be undone."))
        {
            return;
        }

        if (ShowingComponents)
        {
            _service.DeleteComponent(Convert.ToInt32(row["component_id"]));
        }
        else
        {
            _service.DeleteScaleRow(Convert.ToInt32(row["scale_id"]));
        }

        _list.Success("Deleted.");
        ReloadData();
    }

    private void ShowComponent(GradeComponent? existing)
    {
        using var dialog = new GradingComponentDialog(existing);

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success("Component saved.");
            ReloadData();
        }
    }

    private void ShowScale(ScaleRow? existing)
    {
        using var dialog = new ScaleRowDialog(existing);

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success("Scale row saved.");
            ReloadData();
        }
    }
}
