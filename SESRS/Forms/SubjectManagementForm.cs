using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class SubjectManagementForm : Form
    {
        private readonly SubjectService _subjectService = new();

        public SubjectManagementForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        private void SubjectManagementForm_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            try
            {
                DataTable table =
                    _subjectService.GetAllSubjects();

                dgvSubjects.AutoGenerateColumns = true;
                dgvSubjects.DataSource = table;

                dgvSubjects.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvSubjects.ReadOnly = true;

                dgvSubjects.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvSubjects.MultiSelect = false;

                // Hide internal database ID.
                DataGridViewColumn? subjectIdColumn =
                    dgvSubjects.Columns["subject_id"];

                if (subjectIdColumn != null)
                {
                    subjectIdColumn.Visible = false;
                }

                // Hide description for now because it is not
                // part of our current DataGridView design.
                DataGridViewColumn? descriptionColumn =
                    dgvSubjects.Columns["description"];

                if (descriptionColumn != null)
                {
                    descriptionColumn.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load subjects.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSubjects();
        }
    }
}