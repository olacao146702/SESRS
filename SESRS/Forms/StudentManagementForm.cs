using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class StudentManagementForm : Form
    {
        private readonly StudentService _studentService = new();

        public StudentManagementForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
            Dock = DockStyle.Fill;

            dgvStudents.SelectionChanged += dgvStudents_SelectionChanged;
        }

        private void dgvStudents_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateDeactivateButtonText();
        }

        private void StudentManagementForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents(int? selectedStudentId = null)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();

                DataTable table;

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    table = _studentService.GetAllStudents();
                }
                else
                {
                    table = _studentService.SearchStudents(keyword);
                }

                dgvStudents.AutoGenerateColumns = true;
                dgvStudents.DataSource = table;

                dgvStudents.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvStudents.ReadOnly = true;

                dgvStudents.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvStudents.MultiSelect = false;

                DataGridViewColumn? studentIdColumn =
                    dgvStudents.Columns["student_id"];

                if (studentIdColumn != null)
                {
                    studentIdColumn.Visible = false;
                }

                UpdateDeactivateButtonText();

                if (selectedStudentId.HasValue)
                {
                    BeginInvoke(new Action(() =>
                    {
                        foreach (DataGridViewRow row in dgvStudents.Rows)
                        {
                            if (row.Cells["student_id"].Value != null &&
                                Convert.ToInt32(
                                    row.Cells["student_id"].Value
                                ) == selectedStudentId.Value)
                            {
                                dgvStudents.ClearSelection();

                                row.Selected = true;

                                dgvStudents.CurrentCell =
                                    row.Cells["student_number"];

                                UpdateDeactivateButtonText();

                                break;
                            }
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load students.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void UpdateDeactivateButtonText()
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                btnDeactivate.Text = "DEACTIVATE";
                return;
            }

            DataGridViewRow row =
                dgvStudents.SelectedRows[0];

            string status =
                row.Cells["status"].Value?.ToString() ?? "";

            if (status.Equals(
                "Active",
                StringComparison.OrdinalIgnoreCase))
            {
                btnDeactivate.Text = "DEACTIVATE";
            }
            else
            {
                btnDeactivate.Text = "ACTIVATE";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            LoadStudents();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a student first.",
                    "Edit Student",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvStudents.SelectedRows[0];

            int studentId =
                Convert.ToInt32(
                    row.Cells["student_id"].Value
                );

            EditStudentForm editForm =
                new EditStudentForm(studentId);

            DialogResult result =
                editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadStudents(studentId);
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a student first.",
                    "Student Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvStudents.SelectedRows[0];

            int studentId =
                Convert.ToInt32(
                    row.Cells["student_id"].Value
                );

            string status =
                row.Cells["status"].Value?.ToString() ?? "";

            bool isActive =
                status.Equals(
                    "Active",
                    StringComparison.OrdinalIgnoreCase
                );

            string action =
                isActive ? "deactivate" : "activate";

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to {action} this student?",
                $"{(isActive ? "Deactivate" : "Activate")} Student",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                bool success =
                    _studentService.ToggleStudentStatus(studentId);

                if (success)
                {
                    MessageBox.Show(
                        $"Student has been {action}d successfully.",
                        "Student Status",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadStudents(studentId);
                }
                else
                {
                    MessageBox.Show(
                        $"Student could not be {action}d.",
                        "Student Status",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to {action} student.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}