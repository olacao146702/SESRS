using System;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class AddSubjectForm : Form
    {
        private readonly SubjectService _subjectService = new();

        public AddSubjectForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string subjectCode =
                txtSubjectCode.Text.Trim().ToUpper();

            string subjectName =
                txtSubjectName.Text.Trim();

            string description =
                txtDescription.Text.Trim();

            int units =
                (int)numUnits.Value;

            // Validate subject code
            if (string.IsNullOrWhiteSpace(subjectCode))
            {
                MessageBox.Show(
                    "Please enter the subject code.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSubjectCode.Focus();
                return;
            }

            // Validate subject name
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                MessageBox.Show(
                    "Please enter the subject name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSubjectName.Focus();
                return;
            }

            try
            {
                bool success =
                    _subjectService.AddSubject(
                        subjectCode,
                        subjectName,
                        description,
                        units
                    );

                if (success)
                {
                    MessageBox.Show(
                        "Subject added successfully!",
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
                        "Subject could not be added.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            catch (MySqlConnector.MySqlException ex)
            {
                // Duplicate subject code
                if (ex.Number == 1062)
                {
                    MessageBox.Show(
                        "That subject code already exists.\n\n" +
                        "Please use a different subject code.",
                        "Duplicate Subject Code",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtSubjectCode.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "Failed to add subject.\n\n" +
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