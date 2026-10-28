using SESRS.Helpers;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>The student's profile. Only email, phone and address can be changed here.</summary>
public partial class ProfileForm : Form
{
    private readonly int _studentId;
    private readonly StudentPortalService _portal = new();

    public ProfileForm(int studentId)
    {
        InitializeComponent();
        _studentId = studentId;
    }

    private void ProfileForm_Load(object? sender, EventArgs e) => LoadProfile();

    private static string Show(string value) => value.Length == 0 ? "-" : value;

    private void LoadProfile()
    {
        try
        {
            StudentProfile p = _portal.GetProfile(_studentId);

            lblNumberValue.Text = p.StudentNumber.Length == 0 ? "Not yet assigned" : p.StudentNumber;
            lblNameValue.Text = Show(p.FullName);
            lblProgramValue.Text = $"{p.ProgramCode} - {p.ProgramName}";
            lblYearValue.Text = Academic.YearLabel(p.YearLevel);
            lblStatusValue.Text = p.Status;
            lblGenderValue.Text = Show(p.Gender);
            lblBirthValue.Text = p.BirthDate?.ToString("MMMM d, yyyy") ?? "-";
            lblEmailValue.Text = Show(p.Email);
            lblPhoneValue.Text = Show(p.Phone);
            lblAddressValue.Text = Show(p.Address);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorHandler.Friendly(ex), "Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnEdit_Click(object? sender, EventArgs e)
    {
        try
        {
            using var dialog = new ContactEditDialog(_portal.GetProfile(_studentId));

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadProfile();
                MessageBox.Show("Your contact details were updated.", "Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorHandler.Friendly(ex), "Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
