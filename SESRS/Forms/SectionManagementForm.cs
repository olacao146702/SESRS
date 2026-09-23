using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class SectionManagementForm : Form
    {
        private readonly SectionService _sectionService = new();

        public SectionManagementForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        private void SectionManagementForm_Load(object sender, EventArgs e)
        {
            LoadSections();
        }

        private void LoadSections()
        {
            try
            {
                DataTable table =
                    _sectionService.GetAllSections();

                dgvSections.AutoGenerateColumns = true;
                dgvSections.DataSource = table;

                dgvSections.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvSections.ReadOnly = true;

                dgvSections.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvSections.MultiSelect = false;

                // Hide internal database ID.
                DataGridViewColumn? sectionIdColumn =
                    dgvSections.Columns["section_id"];

                if (sectionIdColumn != null)
                {
                    sectionIdColumn.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load sections.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSections();
        }
    }
}