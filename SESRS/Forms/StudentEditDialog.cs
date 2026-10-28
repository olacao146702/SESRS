using System.Data;
using SESRS.Services;

namespace SESRS.Forms;

/// <summary>Edit a student's personal details. The official number and username are never editable.</summary>
public partial class StudentEditDialog : Form
{
    private readonly StudentService _service = new();
    private readonly DataRow _student;

    public StudentEditDialog(DataRow student)
    {
        InitializeComponent();
        _student = student;

        string number = student["student_number"] as string ?? "not assigned yet";
        lblIntro.Text = $"Student number: {number}. The official number and username cannot be changed here.";

        txtFirst.Text = student["first_name"] as string ?? "";
        txtMiddle.Text = student["middle_name"] as string ?? "";
        txtLast.Text = student["last_name"] as string ?? "";
        cmbGender.SelectedItem = student["gender"] as string;
        dtpBirth.Value = student["birth_date"] == DBNull.Value
            ? DateTime.Today.AddYears(-18)
            : Convert.ToDateTime(student["birth_date"]);
        txtEmail.Text = student["email"] as string ?? "";
        txtPhone.Text = student["phone"] as string ?? "";
        txtAddress.Text = student["address"] as string ?? "";

        DialogHelper.Fill(cmbProgram,
            _service.GetActivePrograms().Select(p => new ChoiceItem(p.Id, p.Name)),
            Convert.ToInt32(student["program_id"]));

        cmbYear.SelectedIndex = Convert.ToInt32(student["year_level"]) - 1;
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

            _service.UpdateStudent(Convert.ToInt32(_student["student_id"]), txtFirst.Text.Trim(),
                txtMiddle.Text.Trim(), txtLast.Text.Trim(), gender, dtpBirth.Value.Date, txtEmail.Text.Trim(),
                txtPhone.Text.Trim(), txtAddress.Text.Trim(), DialogHelper.Value<int>(cmbProgram),
                cmbYear.SelectedIndex + 1);

            return null;
        });
    }
}
