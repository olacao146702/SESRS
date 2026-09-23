using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class EnrollmentManagementForm : Form
    {
        private readonly EnrollmentService _enrollmentService = new();

        public EnrollmentManagementForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        private void EnrollmentManagementForm_Load(object sender, EventArgs e)
        {
            LoadEnrollments();
        }

        private void LoadEnrollments()
        {
            try
            {
                DataTable table =
                    _enrollmentService.GetAllEnrollments();

                dgvEnrollments.AutoGenerateColumns = true;
                dgvEnrollments.DataSource = table;

                dgvEnrollments.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvEnrollments.ReadOnly = true;

                dgvEnrollments.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvEnrollments.MultiSelect = false;

                // Hide internal database ID.
                DataGridViewColumn? enrollmentIdColumn =
                    dgvEnrollments.Columns["enrollment_id"];

                if (enrollmentIdColumn != null)
                {
                    enrollmentIdColumn.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load enrollments.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEnrollments();
        }

    }
}