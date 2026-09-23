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
        }

        private void StudentManagementForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                DataTable table =
                    _studentService.GetAllStudents();

                dgvStudents.AutoGenerateColumns = true;
                dgvStudents.DataSource = table;

                dgvStudents.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvStudents.ReadOnly = true;

                dgvStudents.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvStudents.MultiSelect = false;

                // Hide internal database ID.
                DataGridViewColumn? studentIdColumn =
                    dgvStudents.Columns["student_id"];

                if (studentIdColumn != null)
                {
                    studentIdColumn.Visible = false;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }
    }
}