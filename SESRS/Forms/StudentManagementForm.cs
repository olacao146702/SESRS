using System.Data;
using SESRS.Helpers;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms;

public partial class StudentManagementForm : Form
{
    private readonly StudentService _service = new();
    private readonly StudentPortalService _portal = new();
    private readonly ListGrid _list;

    public StudentManagementForm()
    {
        InitializeComponent();

        _list = new ListGrid(this, dgv, txtSearch, lblEmpty, lblPageInfo, btnPrev, btnNext, lblStatus, lblSubtitle)
        {
            EmptyMessage = "No students yet. Click NEW STUDENT to create the first account."
        };
        _list.RowActivated += (_, _) => _list.Run(Edit);
    }

    private bool _ready;

    private void StudentManagementForm_Load(object? sender, EventArgs e)
    {
        cmbStatus.SelectedIndex = 0;
        _ready = true;
        ReloadData();
    }

    private void cmbStatus_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_ready)
        {
            ReloadData();
        }
    }

    private void ReloadData()
    {
        _list.Run(() =>
        {
            DataTable table = _service.GetAllStudents();
            string filter = cmbStatus.SelectedItem?.ToString() ?? "All";

            if (filter != "All")
            {
                DataView view = table.DefaultView;
                view.RowFilter = $"status = '{filter}'";
                table = view.ToTable();
            }

            _list.SetData(table, "student_id", "program_name");
        });
    }

    private void btnNew_Click(object? sender, EventArgs e) => _list.Run(NewStudent);
    private void btnEdit_Click(object? sender, EventArgs e) => _list.Run(Edit);
    private void btnToggle_Click(object? sender, EventArgs e) => _list.Run(Toggle);
    private void btnReset_Click(object? sender, EventArgs e) => _list.Run(ResetPassword);
    private void btnTranscript_Click(object? sender, EventArgs e) => _list.Run(PrintTranscript);
    private void btnExport_Click(object? sender, EventArgs e) => _list.Run(() => _list.ExportCsv("students"));

    private void NewStudent()
    {
        using var form = new CreateStudentForm();

        if (form.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success("Student account created.");
            ReloadData();
        }
    }

    private void Edit()
    {
        DataRow? row = _list.RequireRow("student");

        if (row == null)
        {
            return;
        }

        DataTable t = _service.GetStudentById(Convert.ToInt32(row["student_id"]));

        if (t.Rows.Count == 0)
        {
            ReloadData();
            return;
        }

        using var dialog = new StudentEditDialog(t.Rows[0]);

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            _list.Success("Student updated.");
            ReloadData();
        }
    }

    private void Toggle()
    {
        DataRow? row = _list.RequireRow("student");

        if (row == null)
        {
            return;
        }

        bool active = Convert.ToString(row["status"]) == "Active";
        bool lacksNumber = string.IsNullOrWhiteSpace(Convert.ToString(row["student_number"]));

        string consequence = active
            ? "\n\nThe student will no longer be able to sign in."
            : "\n\nThe student will be able to sign in again." +
              (lacksNumber ? " An official student number will be assigned automatically." : "");

        if (!_list.Confirm($"{(active ? "Deactivate" : "Activate")} {row["student_name"]}?{consequence}"))
        {
            return;
        }

        _service.ToggleStudentStatus(Convert.ToInt32(row["student_id"]));
        _list.Success("Status updated.");
        ReloadData();
    }

    private void ResetPassword()
    {
        DataRow? row = _list.RequireRow("student");

        if (row == null)
        {
            return;
        }

        if (!_list.Confirm(
            $"Reset the password for {row["student_name"]}?\n\n" +
            "A new temporary password is generated and the current one stops working. " +
            "The student must choose a new password at next sign-in.", "Reset Password"))
        {
            return;
        }

        IssuedCredentials credentials = _service.ResetStudentPassword(Convert.ToInt32(row["student_id"]));

        using var form = new CredentialsForm("Password Reset", credentials.FullName,
            credentials.Username, credentials.TemporaryPassword);

        form.ShowDialog(this);
    }


    private void PrintTranscript()
    {
        DataRow? row = _list.RequireRow("student");

        if (row == null)
        {
            return;
        }

        int id = Convert.ToInt32(row["student_id"]);
        StudentProfile profile = _portal.GetProfile(id);

        var document = new ReportDocument { Title = "Transcript of Records", Subtitle = "Published grades only" };

        document.Header.Add(("Student No.", profile.StudentNumber));
        document.Header.Add(("Name", profile.FullName));
        document.Header.Add(("Program", $"{profile.ProgramCode} - {profile.ProgramName}"));
        document.Header.Add(("Year level", Academic.YearLabel(profile.YearLevel)));

        document.AddColumn("School year", 1f);
        document.AddColumn("Semester", 1.1f);
        document.AddColumn("Code", 0.9f);
        document.AddColumn("Subject", 2.6f);
        document.AddColumn("Units", 0.55f);
        document.AddColumn("Grade", 0.7f);
        document.AddColumn("Result", 0.9f);


        PrintReport.Preview(this, document);
    }
}
