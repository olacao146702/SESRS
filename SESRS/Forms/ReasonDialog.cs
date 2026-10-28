namespace SESRS.Forms;

/// <summary>
/// Asks for remarks, then runs the action with them. If the action fails the dialog stays open and shows
/// the problem, so nothing the person typed is lost.
/// </summary>
public partial class ReasonDialog : Form
{
    private readonly bool _required;
    private readonly Action<string?> _action;

    public ReasonDialog(string title, string intro, string saveText, bool required, Action<string?> action)
    {
        InitializeComponent();

        _required = required;
        _action = action;

        Text = title;
        lblIntro.Text = intro;
        btnSave.Text = saveText;
        lblRemarks.Text = required ? "Remarks *" : "Remarks (optional)";
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            string remarks = txtRemarks.Text.Trim();

            if (_required && remarks.Length == 0)
            {
                return "Please enter the remarks.";
            }

            _action(remarks.Length == 0 ? null : remarks);
            return null;
        });
    }
}
