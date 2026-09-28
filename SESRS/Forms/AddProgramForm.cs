using System;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class AddProgramForm : Form
    {
        private readonly ProgramService _programService = new();

        public AddProgramForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string programCode =
                txtProgramCode.Text.Trim().ToUpper();

            string programName =
                txtProgramName.Text.Trim();

            int durationYears =
                (int)numDuration.Value;

            // Validation
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
                    _programService.AddProgram(
                        programCode,
                        programName,
                        durationYears
                    );

                if (success)
                {
                    MessageBox.Show(
                        "Program added successfully!",
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
                        "Program could not be added.",
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
                        "Failed to add program.\n\n" +
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