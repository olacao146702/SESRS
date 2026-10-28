using SESRS.Services;

namespace SESRS.Forms;

/// <summary>
/// Lets the signed-in user change their own password. In "forced" mode (temporary password)
/// the user must complete it before using the portal.
/// </summary>
public partial class ChangePasswordForm : Form
{
    private readonly UserService _userService = new();

    public ChangePasswordForm(bool forced = false)
    {
        InitializeComponent();

        Text = forced ? "Change Temporary Password" : "Change Password";
        lblTitle.Text = forced ? "Set a New Password" : "Change Password";
        lblMessage.Text = forced
            ? "For your security, you must replace your temporary password before continuing."
            : "Enter your current password, then choose a new one.";
    }

    private void chkShow_CheckedChanged(object? sender, EventArgs e)
    {
        bool hide = !chkShow.Checked;
        txtCurrent.UseSystemPasswordChar = hide;
        txtNew.UseSystemPasswordChar = hide;
        txtConfirm.UseSystemPasswordChar = hide;
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            _userService.ChangePassword(txtCurrent.Text, txtNew.Text, txtConfirm.Text);

            MessageBox.Show(this, "Your password was changed successfully.", "Change Password",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        });
    }
}
