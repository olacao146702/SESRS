using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class NewAdministratorDialog : Form
{
    private readonly UserAdminService _service = new();

    /// <summary>The generated login, available after a successful save.</summary>
    public IssuedCredentials? Credentials { get; private set; }

    public NewAdministratorDialog()
    {
        InitializeComponent();
        Text = "New Administrator";
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            Credentials = _service.CreateAdministrator(txtUsername.Text.Trim(), txtName.Text.Trim());
        });
    }
}
