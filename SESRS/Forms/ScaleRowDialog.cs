using System.Globalization;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class ScaleRowDialog : Form
{
    private readonly GradeService _service = new();
    private readonly ScaleRow? _existing;

    public ScaleRowDialog(ScaleRow? existing = null)
    {
        InitializeComponent();
        _existing = existing;
        Text = existing == null ? "Add Scale Row" : "Edit Scale Row";

        txtMin.Text = existing?.MinPercent.ToString("0.##") ?? "";
        txtPoint.Text = existing?.GradePoint.ToString("0.00") ?? "";
        cmbResult.SelectedItem = existing?.Result ?? "Passed";
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            if (!decimal.TryParse(txtMin.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal min) ||
                !decimal.TryParse(txtPoint.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal point))
            {
                return "Enter the minimum percent and grade point as numbers.";
            }

            if (cmbResult.SelectedItem is not string result)
            {
                return "Please choose a result.";
            }

            _service.SaveScaleRow(new ScaleRow(_existing?.ScaleId ?? 0, min, point, result));
            return null;
        });
    }
}
