using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class EditSubjectForm : Form
    {
        private readonly SubjectService _subjectService = new();
        private readonly int _subjectId;

        public EditSubjectForm(int subjectId)
        {
            InitializeComponent();

            _subjectId = subjectId;

            LoadSubject();
        }

        private void LoadSubject()
        {
            try
            {
                DataTable table =
                    _subjectService.GetSubjectById(_subjectId);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Subject not found.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    Close();
                    return;
                }

                DataRow row = table.Rows[0];

                txtSubjectCode.Text =
                    row["subject_code"].ToString();

                txtSubjectName.Text =
                    row["subject_name"].ToString();

                txtDescription.Text =
                    row["description"] == DBNull.Value
                        ? ""
                        : row["description"].ToString();

                numUnits.Value =
                    Convert.ToDecimal(row["units"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load subject.\n\n" +
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
            string subjectCode =
                txtSubjectCode.Text.Trim().ToUpper();

            string subjectName =
                txtSubjectName.Text.Trim();

            string description =
                txtDescription.Text.Trim();

            int units =
                (int)numUnits.Value;

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
                    _subjectService.UpdateSubject(
                        _subjectId,
                        subjectCode,
                        subjectName,
                        description,
                        units
                    );

                if (success)
                {
                    MessageBox.Show(
                        "Subject updated successfully!",
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
                        "Subject could not be updated.",
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
                        "Failed to update subject.\n\n" +
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