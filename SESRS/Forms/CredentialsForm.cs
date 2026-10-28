using SESRS.Helpers;

namespace SESRS.Forms;

/// <summary>Shows a username and temporary password once, with a copy button.</summary>
public partial class CredentialsForm : Form
{
    public CredentialsForm(string title, string fullName, string username, string temporaryPassword)
    {
        InitializeComponent();

        Text = title;
        lblTitle.Text = title;
        lblStudent.Text = "Account holder: " + fullName;
        txtUsername.Text = username;
        txtPassword.Text = temporaryPassword;
    }

    private void btnCopy_Click(object? sender, EventArgs e)
    {
        try
        {
            Clipboard.SetText($"Username: {txtUsername.Text}{Environment.NewLine}Temporary password: {txtPassword.Text}");
            btnCopy.Text = "COPIED";
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, "The clipboard is not available. Please copy the details manually.\n\n" +
                ErrorHandler.Friendly(ex), "Copy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
