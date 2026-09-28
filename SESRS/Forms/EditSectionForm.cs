using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class EditSectionForm : Form
    {
        private readonly SectionService _sectionService = new();

        private readonly int _sectionId;

        public EditSectionForm(int sectionId)
        {
            InitializeComponent();

            _sectionId = sectionId;

            SetupDropdowns();
            LoadPrograms();
            LoadSection();
        }

        private void SetupDropdowns()
        {
            cmbYearLevel.Items.Clear();

            cmbYearLevel.Items.Add("1st Year");
            cmbYearLevel.Items.Add("2nd Year");
            cmbYearLevel.Items.Add("3rd Year");
            cmbYearLevel.Items.Add("4th Year");

            cmbSemester.Items.Clear();

            cmbSemester.Items.Add("1st Semester");
            cmbSemester.Items.Add("2nd Semester");
        }

        private void LoadPrograms()
        {
            try
            {
                DataTable table =
                    _sectionService.GetActivePrograms();

                cmbProgram.DataSource = table;
                cmbProgram.DisplayMember = "program_name";
                cmbProgram.ValueMember = "program_id";
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

        private void LoadSection()
        {
            try
            {
                DataTable table =
                    _sectionService.GetSectionById(_sectionId);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Section record not found.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    Close();
                    return;
                }

                DataRow row = table.Rows[0];

                txtSectionCode.Text =
                    row["section_code"].ToString();

                txtSectionName.Text =
                    row["section_name"].ToString();

                int programId =
                    Convert.ToInt32(row["program_id"]);

                if (cmbProgram.Items.Count > 0)
                {
                    cmbProgram.SelectedValue = programId;
                }

                int yearLevel =
                    Convert.ToInt32(row["year_level"]);

                if (yearLevel >= 1 &&
                    yearLevel <= 4)
                {
                    cmbYearLevel.SelectedIndex =
                        yearLevel - 1;
                }

                string semester =
                    row["semester"].ToString() ?? "";

                if (cmbSemester.Items.Contains(semester))
                {
                    cmbSemester.SelectedItem = semester;
                }

                txtSchoolYear.Text =
                    row["school_year"].ToString();

                decimal capacity =
                    Convert.ToDecimal(row["capacity"]);

                if (capacity >= numCapacity.Minimum &&
                    capacity <= numCapacity.Maximum)
                {
                    numCapacity.Value = capacity;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load section.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sectionCode =
                txtSectionCode.Text.Trim().ToUpper();

            string sectionName =
                txtSectionName.Text.Trim();

            string schoolYear =
                txtSchoolYear.Text.Trim();

            if (string.IsNullOrWhiteSpace(sectionCode))
            {
                MessageBox.Show(
                    "Please enter the section code.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSectionCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(sectionName))
            {
                MessageBox.Show(
                    "Please enter the section name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSectionName.Focus();
                return;
            }

            if (cmbProgram.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a program.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbProgram.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(schoolYear))
            {
                MessageBox.Show(
                    "Please enter the school year.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSchoolYear.Focus();
                return;
            }

            int programId =
                Convert.ToInt32(cmbProgram.SelectedValue);

            int yearLevel =
                cmbYearLevel.SelectedIndex + 1;

            string semester =
                cmbSemester.SelectedItem?.ToString() ?? "";

            int capacity =
                (int)numCapacity.Value;

            try
            {
                bool success =
                    _sectionService.UpdateSection(
                        _sectionId,
                        sectionCode,
                        sectionName,
                        programId,
                        yearLevel,
                        semester,
                        schoolYear,
                        capacity
                    );

                if (success)
                {
                    MessageBox.Show(
                        "Section updated successfully!",
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
                        "Section could not be updated.",
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
                        "That section code already exists.\n\n" +
                        "Please use a different section code.",
                        "Duplicate Section Code",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtSectionCode.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "Failed to update section.\n\n" +
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