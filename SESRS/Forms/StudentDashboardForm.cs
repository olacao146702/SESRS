using System;
using System.Windows.Forms;
using SESRS.Models;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class StudentDashboardForm : Form
    {
        private readonly User _user;
        private readonly StudentService _studentService = new();

        public StudentDashboardForm(User user)
        {
            InitializeComponent();

            _user = user;

            btnLogout.Click += btnLogout_Click;

            LoadStudentInformation();
        }

        private void LoadStudentInformation()
        {
            if (_user.StudentId == null)
            {
                MessageBox.Show(
                    "Student information could not be found.",
                    "Student Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                var studentInfo =
                    _studentService.GetStudentDashboardInfo(
                        _user.StudentId.Value
                    );

                if (studentInfo == null)
                {
                    MessageBox.Show(
                        "Student information could not be found.",
                        "Student Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                lblDashboardTitleStudent.Text =
                    "Welcome, " + _user.FullName + "!";

                lblStudentNumber.Text =
                    "Student Number: " +
                    studentInfo.Value.StudentNumber;

                lblProgram.Text =
                    "Program: " +
                    studentInfo.Value.ProgramName;

                lblYearLevel.Text =
                    "Year Level: " +
                    studentInfo.Value.YearLevel + " Year";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load student information.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();

                loginForm.Show();

                this.Close();
            }
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void pnlStudent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlStudentNumber_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlYearLevel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlProgram_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlStatus_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}