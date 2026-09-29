using System;
using System.Data;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class EnrollStudentForm : Form
    {
        private readonly EnrollmentService _enrollmentService = new();

        public EnrollStudentForm()
        {
            InitializeComponent();

            LoadStudents();
            LoadSemesters();

            txtSchoolYear.Text = GetCurrentSchoolYear();

            btnEnroll.Click += btnEnroll_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void LoadStudents()
        {
            try
            {
                DataTable students =
                    _enrollmentService.GetActiveStudents();

                cmbStudent.DataSource = students;
                cmbStudent.DisplayMember = "student_name";
                cmbStudent.ValueMember = "student_id";

                cmbStudent.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load students.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadSemesters()
        {
            cmbSemester.Items.Clear();

            cmbSemester.Items.Add("1st Semester");
            cmbSemester.Items.Add("2nd Semester");
            cmbSemester.Items.Add("Summer");

            cmbSemester.SelectedIndex = -1;
        }

        private string GetCurrentSchoolYear()
        {
            int year = DateTime.Now.Year;

            return year + "-" + (year + 1);
        }

        private void btnEnroll_Click(object? sender, EventArgs e)
        {
            if (cmbStudent.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a student.",
                    "Enrollment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(txtSchoolYear.Text))
            {
                MessageBox.Show(
                    "Please enter the school year.",
                    "Enrollment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSchoolYear.Focus();
                return;
            }

            if (cmbSemester.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a semester.",
                    "Enrollment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int studentId =
                Convert.ToInt32(cmbStudent.SelectedValue);

            string schoolYear =
                txtSchoolYear.Text.Trim();

            string semester =
                cmbSemester.Text;

            try
            {
                bool success =
                    _enrollmentService.CreateEnrollment(
                        studentId,
                        schoolYear,
                        semester
                    );

                if (!success)
                {
                    MessageBox.Show(
                        "This student is already enrolled for this school year and semester.",
                        "Enrollment",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                MessageBox.Show(
                    "Student enrolled successfully!",
                    "Enrollment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to enroll student.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}