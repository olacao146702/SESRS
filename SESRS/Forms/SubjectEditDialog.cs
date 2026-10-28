using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

public partial class SubjectEditDialog : Form
{
    private readonly SubjectService _service = new();
    private readonly DataRow? _existing;

    public SubjectEditDialog(DataRow? existing = null)
    {
        InitializeComponent();
        _existing = existing;
        Text = existing == null ? "Add Subject" : "Edit Subject";

        if (existing != null)
        {
            txtCode.Text = existing["subject_code"] as string ?? "";
            txtName.Text = existing["subject_name"] as string ?? "";
            txtDescription.Text = existing["description"] as string ?? "";
            nudUnits.Value = Convert.ToInt32(existing["units"]);
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            string code = txtCode.Text.Trim(), name = txtName.Text.Trim(), description = txtDescription.Text.Trim();
            int units = (int)nudUnits.Value;

            if (_existing == null)
            {
                _service.AddSubject(code, name, description, units);
            }
            else
            {
                _service.UpdateSubject(Convert.ToInt32(_existing["subject_id"]), code, name, description, units);
            }
        });
    }
}
