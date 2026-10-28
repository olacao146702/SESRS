using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

public partial class ProgramEditDialog : Form
{
    private readonly ProgramService _service = new();
    private readonly DataRow? _existing;

    public ProgramEditDialog(DataRow? existing = null)
    {
        InitializeComponent();
        _existing = existing;
        Text = existing == null ? "Add Program" : "Edit Program";

        if (existing != null)
        {
            txtCode.Text = existing["program_code"] as string ?? "";
            txtName.Text = existing["program_name"] as string ?? "";
            nudYears.Value = Convert.ToInt32(existing["duration_years"]);
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            string code = txtCode.Text.Trim(), name = txtName.Text.Trim();
            int years = (int)nudYears.Value;

            if (_existing == null)
            {
                _service.AddProgram(code, name, years);
            }
            else
            {
                _service.UpdateProgram(Convert.ToInt32(_existing["program_id"]), code, name, years);
            }
        });
    }
}
