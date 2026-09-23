using System;
using System.Windows.Forms;

namespace SESRS.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void ShowDashboard()
        {
            pnlContent.Controls.Clear();

            pnlContent.Controls.Add(lblDashboardTitle);
            pnlContent.Controls.Add(lblWelcome);

            pnlContent.Controls.Add(pnlStudentsCard);
            pnlContent.Controls.Add(pnlSubjectsCard);
            pnlContent.Controls.Add(pnlEnrollmentCard);
            pnlContent.Controls.Add(pnlSectionsCard);

            lblDashboardTitle.BringToFront();
            lblWelcome.BringToFront();
        }

        private void ShowPage(Form page)
        {
            pnlContent.Controls.Clear();

            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(page);

            page.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void btnPendingStudents_Click(object sender, EventArgs e)
        {
            ShowPage(new PendingStudentsForm());

        }
        private void btnStudents_Click(object sender, EventArgs e)
        {
            ShowPage(new StudentManagementForm());
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            ShowPage(new SubjectManagementForm());
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            ShowPage(new SectionManagementForm());
        }

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            ShowPage(new EnrollmentManagementForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowPage(new ReportsForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
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
    }
}