using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class AddSectionForm : Form
    {
        private readonly SectionService _sectionService = new();

        public AddSectionForm()
        {
            InitializeComponent();

            LoadPrograms();

            cmbYearLevel.Items.Add("1st Year");
            cmbYearLevel.Items.Add("2nd Year");
            cmbYearLevel.Items.Add("3rd Year");
            cmbYearLevel.Items.Add("4th Year");

            cmbSemester.Items.Add("1st Semester");
            cmbSemester.Items.Add("2nd Semester");

            cmbYearLevel.SelectedIndex = 0;
            cmbSemester.SelectedIndex = 0;
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

                if (table.Rows.Count > 0)
                {
                    cmbProgram.SelectedIndex = 0;
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
                    _sectionService.AddSection(
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
                        "Section added successfully!",
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
                        "Section could not be added.",
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
                        "Failed to add section.\n\n" +
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