using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>
/// Administrator-only registration of a student who applied in person. The system generates the official
/// student number (also the username) and a temporary password; the student must change it at first login.
/// </summary>
public partial class CreateStudentForm : Form
{
    private readonly StudentService _service = new();

    public CreateStudentForm()
    {
        InitializeComponent();

        dtpBirth.MaxDate = DateTime.Today.AddDays(-1);
        dtpBirth.Value = DateTime.Today.AddYears(-18);

        try
        {
            DialogHelper.Fill(cmbProgram, _service.GetActivePrograms().Select(p => new ChoiceItem(p.Id, p.Name)));

            if (cmbProgram.Items.Count == 0)
            {
                lblError.Text = "There are no active programs. Add a program first.";
                btnSave.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = SESRS.Helpers.ErrorHandler.Friendly(ex);
            btnSave.Enabled = false;
        }
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        DialogHelper.Submit(this, lblError, btnSave, btnCancel, () =>
        {
            if (cmbGender.SelectedItem is not string gender)
            {
                return "Please select a gender.";
            }

            if (!DialogHelper.HasSelection(cmbProgram) || cmbYear.SelectedIndex < 0)
            {
                return "Please select a program and year level.";
            }

            CreatedStudentAccount created = _service.CreateStudentAccount(new NewStudentRequest(
                txtFirst.Text, txtMiddle.Text, txtLast.Text, gender, dtpBirth.Value.Date, txtEmail.Text,
                txtPhone.Text, txtAddress.Text, DialogHelper.Value<int>(cmbProgram), cmbYear.SelectedIndex + 1));

            // The account exists now; show the credentials to hand to the student.
            using var shown = new CredentialsForm("Student Account Created", created.Credentials.FullName,
                created.Credentials.Username, created.Credentials.TemporaryPassword);

            shown.ShowDialog(this);
            return null;
        });
    }
}
