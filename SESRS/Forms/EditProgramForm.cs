using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class EditProgramForm : Form
    {
        private readonly ProgramService _programService = new();
        private readonly int _programId;

        public EditProgramForm(int programId)
        {
            InitializeComponent();

            _programId = programId;

            LoadProgram();
        }

        private void LoadProgram()
        {
            try
            {
                DataTable table =
                    _programService.GetProgramById(_programId);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Program not found.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    Close();
                    return;
                }

                DataRow row = table.Rows[0];

                txtProgramCode.Text =
                    row["program_code"].ToString();

                txtProgramName.Text =
                    row["program_name"].ToString();

                numDuration.Value =
                    Convert.ToDecimal(row["duration_years"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load program.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string programCode =
                txtProgramCode.Text.Trim().ToUpper();

            string programName =
                txtProgramName.Text.Trim();

            int durationYears =
                (int)numDuration.Value;

            if (string.IsNullOrWhiteSpace(programCode))
            {
                MessageBox.Show(
                    "Please enter the program code.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtProgramCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(programName))
            {
                MessageBox.Show(
                    "Please enter the program name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtProgramName.Focus();
                return;
            }

            try
            {
                bool success =
                    _programService.UpdateProgram(
                        _programId,
                        programCode,
                        programName,
                        durationYears
                    );

                if (success)
                {
                    MessageBox.Show(
                        "Program updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "Program could not be updated.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (MySqlConnector.MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show(
                        "That program code already exists.\n\n" +
                        "Please use a different program code.",
                        "Duplicate Program Code",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtProgramCode.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "Failed to update program.\n\n" +
                        ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred.\n\n" +
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
    }
}