using System;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class DashboardForm : Form
    {
        private bool academicsExpanded = false;

        private readonly StudentService _studentService = new();
        private readonly SubjectService _subjectService = new();
        private readonly SectionService _sectionService = new();

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            CollapseAcademics();
            ShowDashboard();
            LoadDashboardCounts();
        }

        private void LoadDashboardCounts()
        {
            lblStudentsCount.Text =
                _studentService.GetTotalStudents().ToString();

            lblSubjectsCount.Text =
                _subjectService.GetTotalSubjects().ToString();

            lblActiveStudentsCount.Text =
                _studentService.GetTotalActiveStudents().ToString();

            lblSectionsCount.Text =
                _sectionService.GetTotalSections().ToString();
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
            LoadDashboardCounts();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            ShowPage(new StudentManagementForm());
        }

        // =========================
        // ACADEMICS
        // =========================

        private void btnAcademics_Click(object sender, EventArgs e)
        {
            academicsExpanded = !academicsExpanded;

            btnPrograms.Visible = academicsExpanded;
            btnSubjects.Visible = academicsExpanded;
            btnSections.Visible = academicsExpanded;

            if (academicsExpanded)
            {
                btnAcademics.Text = "ACADEMICS ▲";
                pnlAcademics.Height = 180;
            }
            else
            {
                btnAcademics.Text = "ACADEMICS ▼";
                pnlAcademics.Height = 45;
            }
        }

        private void CollapseAcademics()
        {
            academicsExpanded = false;

            btnPrograms.Visible = false;
            btnSubjects.Visible = false;
            btnSections.Visible = false;

            btnAcademics.Text = "ACADEMICS ▼";

            pnlAcademics.Height = 45;
        }

        private void btnPrograms_Click(object sender, EventArgs e)
        {
            ShowPage(new ProgramManagementForm());
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            ShowPage(new SubjectManagementForm());
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            ShowPage(new SectionManagementForm());
        }

        // =========================
        // OTHER MODULES
        // =========================

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            ShowPage(new EnrollmentManagementForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowPage(new ReportsForm());
        }

        private void btnPendingStudents_Click(object sender, EventArgs e)
        {
            ShowPage(new PendingStudentsForm());
        }

        // =========================
        // LOGOUT
        // =========================

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
