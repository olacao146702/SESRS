using MySqlConnector;
using SESRS.Data;
using SESRS.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace SESRS.Forms
{
    public partial class EditStudentForm : Form
    {
        private readonly int _studentId;
        private readonly StudentService _studentService = new();

        public EditStudentForm(int studentId)
        {
            InitializeComponent();

            _studentId = studentId;

            cmbGender.Items.Clear();
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");

            cmbYearLevel.Items.Clear();
            cmbYearLevel.Items.Add("1st Year");
            cmbYearLevel.Items.Add("2nd Year");
            cmbYearLevel.Items.Add("3rd Year");
            cmbYearLevel.Items.Add("4th Year");

            LoadPrograms();
        }

        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            LoadStudent();
        }

        private void LoadStudent()
        {
            try
            {
                DataTable table =
                    _studentService.GetStudentById(_studentId);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Student record not found.",
                        "Edit Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    Close();
                    return;
                }

                DataRow row = table.Rows[0];

                int programId = Convert.ToInt32(row["program_id"]);

                txtFirstName.Text =
                    row["first_name"].ToString();

                txtMiddleName.Text =
                    row["middle_name"].ToString();

                txtLastName.Text =
                    row["last_name"].ToString();

                cmbGender.Text =
                    row["gender"].ToString();

                if (row["birth_date"] != DBNull.Value)
                {
                    dtpBirthDate.Value =
                        Convert.ToDateTime(row["birth_date"]);
                }

                txtEmail.Text =
                    row["email"].ToString();

                txtPhone.Text =
                    row["phone"].ToString();

                txtAddress.Text =
                    row["address"].ToString();

                int yearLevel =
                Convert.ToInt32(row["year_level"]);

                cmbYearLevel.SelectedIndex =
                    yearLevel - 1;

                for (int i = 0; i < cmbProgram.Items.Count; i++)
                {
                    if (cmbProgram.Items[i] is ProgramItem program &&
                        program.ProgramId == programId)
                    {
                        cmbProgram.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load student information.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadPrograms()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT program_id, program_code, program_name
                FROM programs
                WHERE status = 'Active'
                ORDER BY program_code";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbProgram.Items.Clear();

                        while (reader.Read())
                        {
                            cmbProgram.Items.Add(new ProgramItem
                            {
                                ProgramId = Convert.ToInt32(reader["program_id"]),
                                ProgramCode = reader["program_code"].ToString() ?? string.Empty,
                                ProgramName = reader["program_name"].ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load programs.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show(
                        "First name is required.",
                        "Edit Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtFirstName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show(
                        "Last name is required.",
                        "Edit Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtLastName.Focus();
                    return;
                }

                if (cmbGender.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Please select a gender.",
                        "Edit Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    cmbGender.Focus();
                    return;
                }

                if (cmbProgram.SelectedItem is not ProgramItem selectedProgram)
                {
                    MessageBox.Show(
                        "Please select a program.",
                        "Edit Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    cmbProgram.Focus();
                    return;
                }

                if (cmbYearLevel.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Please select a year level.",
                        "Edit Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    cmbYearLevel.Focus();
                    return;
                }

                int yearLevel =
                    cmbYearLevel.SelectedIndex + 1;

                bool success = _studentService.UpdateStudent(
                    _studentId,
                    txtFirstName.Text.Trim(),
                    txtMiddleName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    cmbGender.Text,
                    dtpBirthDate.Value,
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtAddress.Text.Trim(),
                    selectedProgram.ProgramId,
                    yearLevel
                );

                if (success)
                {
                    MessageBox.Show(
                        "Student information updated successfully.",
                        "Edit Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "No changes were saved.",
                        "Edit Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to update student information.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public class ProgramItem
        {
            public int ProgramId { get; set; }
            public string ProgramCode { get; set; } = string.Empty;
            public string ProgramName { get; set; } = string.Empty;

            public override string ToString()
            {
                return $"{ProgramCode} - {ProgramName}";
            }
        }
    }
}