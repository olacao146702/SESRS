using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class ProgramManagementForm : Form
    {
        private readonly ProgramService _programService = new();

        public ProgramManagementForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
            Dock = DockStyle.Fill;

            dgvPrograms.SelectionChanged += dgvPrograms_SelectionChanged;
        }

        private void ProgramManagementForm_Load(object sender, EventArgs e)
        {
            LoadPrograms();
        }

        private void LoadPrograms(int? selectedProgramId = null)
        {
            try
            {
                string keyword =
                    txtSearch.Text.Trim();

                DataTable table;

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    table =
                        _programService.GetAllPrograms();
                }
                else
                {
                    table =
                        _programService.SearchPrograms(keyword);
                }

                dgvPrograms.AutoGenerateColumns = true;
                dgvPrograms.DataSource = table;

                dgvPrograms.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvPrograms.ReadOnly = true;

                dgvPrograms.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvPrograms.MultiSelect = false;

                DataGridViewColumn? programIdColumn =
                    dgvPrograms.Columns["program_id"];

                if (programIdColumn != null)
                {
                    programIdColumn.Visible = false;
                }

                UpdateDeactivateButtonText();

                if (selectedProgramId.HasValue)
                {
                    BeginInvoke(new Action(() =>
                    {
                        foreach (DataGridViewRow row in dgvPrograms.Rows)
                        {
                            if (row.Cells["program_id"].Value != null &&
                                Convert.ToInt32(
                                    row.Cells["program_id"].Value
                                ) == selectedProgramId.Value)
                            {
                                dgvPrograms.ClearSelection();

                                row.Selected = true;

                                dgvPrograms.CurrentCell =
                                    row.Cells["program_code"];

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
                    "Failed to load programs.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void UpdateDeactivateButtonText()
        {
            if (dgvPrograms.SelectedRows.Count == 0)
            {
                btnDeactivate.Text = "DEACTIVATE";
                return;
            }

            DataGridViewRow row =
                dgvPrograms.SelectedRows[0];

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProgramForm addForm =
                new AddProgramForm();

            DialogResult result =
                addForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadPrograms();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPrograms.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a program first.",
                    "Edit Program",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvPrograms.SelectedRows[0];

            int programId =
                Convert.ToInt32(
                    row.Cells["program_id"].Value
                );

            EditProgramForm editForm =
                new EditProgramForm(programId);

            DialogResult result =
                editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadPrograms(programId);
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvPrograms.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a program first.",
                    "Program Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow row =
                dgvPrograms.SelectedRows[0];

            int programId =
                Convert.ToInt32(
                    row.Cells["program_id"].Value
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
                $"Are you sure you want to {action} this program?",
                $"{(isActive ? "Deactivate" : "Activate")} Program",
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
                    _programService.ToggleProgramStatus(programId);

                if (success)
                {
                    MessageBox.Show(
                        $"Program has been {action}d successfully.",
                        "Program Status",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadPrograms(programId);
                }
                else
                {
                    MessageBox.Show(
                        $"Program could not be {action}d.",
                        "Program Status",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to {action} program.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPrograms();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            LoadPrograms();
        }

        private void dgvPrograms_SelectionChanged(object? sender,EventArgs e)
        {
            UpdateDeactivateButtonText();
        }
    }
}