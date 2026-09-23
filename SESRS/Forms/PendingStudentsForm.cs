using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class PendingStudentsForm : Form
    {
        private readonly StudentService _studentService = new();

        public PendingStudentsForm()
        {
            InitializeComponent();

            // Make this form suitable for embedding inside the dashboard.
            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        private void PendingStudentsForm_Load(object sender, EventArgs e)
        {
            LoadPendingStudents();
        }

        private void LoadPendingStudents()
        {
            try
            {
                DataTable table =
                    _studentService.GetPendingStudents();

                dgvPendingStudents.AutoGenerateColumns = true;
                dgvPendingStudents.DataSource = table;

                dgvPendingStudents.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvPendingStudents.ReadOnly = true;

                dgvPendingStudents.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvPendingStudents.MultiSelect = false;

                // Hide internal database ID.
                DataGridViewColumn? studentIdColumn =
                    dgvPendingStudents.Columns["student_id"];

                if (studentIdColumn != null)
                {
                    studentIdColumn.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load pending students.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPendingStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a student first.",
                    "Approve Student",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvPendingStudents.SelectedRows[0];

            try
            {
                if (dgvPendingStudents.DataSource is not DataTable table)
                {
                    MessageBox.Show(
                        "Unable to read the student data.",
                        "Approve Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                if (row.Index < 0 || row.Index >= table.Rows.Count)
                {
                    MessageBox.Show(
                        "Unable to identify the selected student.",
                        "Approve Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                int studentId =
                    Convert.ToInt32(
                        table.Rows[row.Index]["student_id"]
                    );

                string studentName =
                    row.Cells["student_name"].Value?.ToString() ?? "";

                DialogResult result = MessageBox.Show(
                    "Approve this student?\n\n" +
                    "Student: " + studentName + "\n\n" +
                    "The system will automatically generate a Student Number.",
                    "Approve Student",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }

                bool approved =
                    _studentService.ApproveStudent(studentId);

                if (approved)
                {
                    MessageBox.Show(
                        "Student approved successfully!\n\n" +
                        "A Student Number has been automatically assigned.",
                        "Approval Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadPendingStudents();
                }
                else
                {
                    MessageBox.Show(
                        "The student could not be approved.",
                        "Approval Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Approval failed.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}