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

            dgvSections.SelectionChanged += dgvSections_SelectionChanged;
        }

        private void SectionManagementForm_Load(object sender, EventArgs e)
        {
            LoadSections();
        }

        private void LoadSections(int? selectedSectionId = null)
        {
            try
            {
                string keyword =
                    txtSearch.Text.Trim();

                DataTable table;

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    table =
                        _sectionService.GetAllSections();
                }
                else
                {
                    table =
                        _sectionService.SearchSections(keyword);
                }

                dgvSections.AutoGenerateColumns = true;
                dgvSections.DataSource = table;

                dgvSections.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvSections.ReadOnly = true;

                dgvSections.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvSections.MultiSelect = false;

                DataGridViewColumn? sectionIdColumn =
                    dgvSections.Columns["section_id"];

                if (sectionIdColumn != null)
                {
                    sectionIdColumn.Visible = false;
                }

                UpdateDeactivateButtonText();

                if (selectedSectionId.HasValue)
                {
                    BeginInvoke(new Action(() =>
                    {
                        foreach (DataGridViewRow row in dgvSections.Rows)
                        {
                            if (row.Cells["section_id"].Value != null &&
                                Convert.ToInt32(
                                    row.Cells["section_id"].Value
                                ) == selectedSectionId.Value)
                            {
                                dgvSections.ClearSelection();

                                row.Selected = true;

                                dgvSections.CurrentCell =
                                    row.Cells["section_code"];

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
            txtSearch.Clear();

            LoadSections();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSectionForm addForm =
                new AddSectionForm();

            DialogResult result =
                addForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadSections();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSections.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a section first.",
                    "Edit Section",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvSections.SelectedRows[0];

            int sectionId =
                Convert.ToInt32(
                    row.Cells["section_id"].Value
                );

            EditSectionForm editForm =
                new EditSectionForm(sectionId);

            DialogResult result =
                editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadSections(sectionId);
            }
        }

        private void dgvSections_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateDeactivateButtonText();
        }

        private void UpdateDeactivateButtonText()
        {
            if (dgvSections.SelectedRows.Count == 0)
            {
                btnDeactivate.Text = "DEACTIVATE";
                return;
            }

            DataGridViewRow row =
                dgvSections.SelectedRows[0];

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

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvSections.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a section first.",
                    "Section Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvSections.SelectedRows[0];

            int sectionId =
                Convert.ToInt32(
                    row.Cells["section_id"].Value
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

            DialogResult result =
                MessageBox.Show(
                    $"Are you sure you want to {action} this section?",
                    "Confirm Action",
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
                    _sectionService.ToggleSectionStatus(sectionId);

                if (success)
                {
                    MessageBox.Show(
                        $"Section {action}d successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadSections(sectionId);
                }
                else
                {
                    MessageBox.Show(
                        "Section status could not be changed.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to change section status.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSections();
        }

        private void txtSearch_KeyDown(
            object? sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(
                    btnSearch,
                    EventArgs.Empty
                );

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}