using System;
using System.Drawing;
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

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            CollapseAcademics();
            RefreshNotificationBadge();
            ShowDashboard();
            LoadDashboardCounts();

            SetActiveMainButton(btnDashboard);
        }

        // =========================================================
        // DASHBOARD COUNTS
        // =========================================================

        private void LoadDashboardCounts()
        {
            try
            {
                lblStudentsCount.Text =
                    _studentService.GetTotalStudents().ToString();

                lblSubjectsCount.Text =
                    _subjectService.GetTotalSubjects().ToString();

                lblActiveStudentsCount.Text =
                    _studentService.GetTotalActiveStudents().ToString();

                lblSectionsCount.Text =
                    _sectionService.GetTotalSections().ToString();

                lblEnrollmentCount.Text =
                    new EnrollmentService().GetTotalEnrollments().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load dashboard information.\n\n" +
                    SESRS.Helpers.ErrorHandler.Friendly(ex),
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // SHOW DASHBOARD
        // =========================================================

        private void ShowDashboard()
        {
            pnlContent.Controls.Clear();

            pnlContent.Controls.Add(pnlStats);
            pnlContent.Controls.Add(pnlHeader);

            pnlHeader.BringToFront();
            pnlStats.BringToFront();
        }

        // =========================================================
        // SHOW PAGE
        // =========================================================

        private void ShowPage(Form page)
        {
            pnlContent.Controls.Clear();

            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(page);

            page.Show();
        }

        // =========================================================
        // ACTIVE MAIN NAVIGATION
        // =========================================================

        private void SetActiveMainButton(Button activeButton)
        {
            Color normalColor = Color.FromArgb(24, 82, 58);
            Color activeColor = Color.FromArgb(42, 112, 80);

            // Reset main buttons
            btnDashboard.BackColor = normalColor;
            btnStudents.BackColor = normalColor;
            btnEnrollment.BackColor = normalColor;
            btnReports.BackColor = normalColor;
            btnNotifications.BackColor = normalColor;
            btnAnnouncements.BackColor = normalColor;
            btnAccounts.BackColor = normalColor;
            btnAuditLog.BackColor = normalColor;

            // Reset fonts
            btnDashboard.Font =
                new Font("Segoe UI", 10F);

            btnStudents.Font =
                new Font("Segoe UI", 10F);

            btnEnrollment.Font =
                new Font("Segoe UI", 10F);

            btnReports.Font =
                new Font("Segoe UI", 10F);

            btnNotifications.Font =
                new Font("Segoe UI", 10F);

            btnAnnouncements.Font = new Font("Segoe UI", 10F);
            btnAccounts.Font = new Font("Segoe UI", 10F);
            btnAuditLog.Font = new Font("Segoe UI", 10F);

            // Highlight selected button
            activeButton.BackColor = activeColor;

            activeButton.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        // =========================================================
        // ACTIVE ACADEMIC NAVIGATION
        // =========================================================

        private void SetActiveAcademicButton(Button activeButton)
        {
            Color normalColor = Color.FromArgb(31, 96, 68);
            Color activeColor = Color.FromArgb(48, 119, 84);

            // Reset academic buttons
            btnPrograms.BackColor = normalColor;
            btnSubjects.BackColor = normalColor;
            btnSections.BackColor = normalColor;
            btnCurriculum.BackColor = normalColor;
            btnSchedules.BackColor = normalColor;
            btnPeriods.BackColor = normalColor;

            // Reset fonts
            btnPrograms.Font =
                new Font("Segoe UI", 9F);

            btnSubjects.Font =
                new Font("Segoe UI", 9F);

            btnSections.Font =
                new Font("Segoe UI", 9F);

            btnCurriculum.Font = new Font("Segoe UI", 9F);
            btnSchedules.Font = new Font("Segoe UI", 9F);
            btnPeriods.Font = new Font("Segoe UI", 9F);

            // Highlight selected academic button
            activeButton.BackColor = activeColor;

            activeButton.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        // =========================================================
        // DASHBOARD BUTTON
        // =========================================================

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
            LoadDashboardCounts();

            SetActiveMainButton(btnDashboard);
        }

        // =========================================================
        // STUDENTS
        // =========================================================

        private void btnStudents_Click(object sender, EventArgs e)
        {
            ShowPage(new StudentManagementForm());

            SetActiveMainButton(btnStudents);
        }

        // =========================================================
        // ACADEMICS DROPDOWN
        // =========================================================

        private void btnAcademics_Click(object sender, EventArgs e)
        {
            academicsExpanded = !academicsExpanded;

            btnPrograms.Visible = academicsExpanded;
            btnSubjects.Visible = academicsExpanded;
            btnSections.Visible = academicsExpanded;
            btnCurriculum.Visible = academicsExpanded;
            btnSchedules.Visible = academicsExpanded;
            btnPeriods.Visible = academicsExpanded;

            if (academicsExpanded)
            {
                btnAcademics.Text = "  Academics    ▲";

                pnlAcademics.Height = 384;
            }
            else
            {
                btnAcademics.Text = "  Academics    ▼";

                pnlAcademics.Height = 48;
            }
        }

        private void CollapseAcademics()
        {
            academicsExpanded = false;

            btnPrograms.Visible = false;
            btnSubjects.Visible = false;
            btnSections.Visible = false;
            btnCurriculum.Visible = false;
            btnSchedules.Visible = false;
            btnPeriods.Visible = false;

            btnAcademics.Text = "  Academics    ▼";

            pnlAcademics.Height = 48;
        }

        // =========================================================
        // PROGRAMS
        // =========================================================

        private void btnPrograms_Click(object sender, EventArgs e)
        {
            ShowPage(new ProgramManagementForm());

            SetActiveAcademicButton(btnPrograms);
        }

        // =========================================================
        // SUBJECTS
        // =========================================================

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            ShowPage(new SubjectManagementForm());

            SetActiveAcademicButton(btnSubjects);
        }

        // =========================================================
        // SECTIONS
        // =========================================================

        private void btnSections_Click(object sender, EventArgs e)
        {
            ShowPage(new SectionManagementForm());

            SetActiveAcademicButton(btnSections);
        }

        private void btnCurriculum_Click(object? sender, EventArgs e)
        {
            ShowPage(new CurriculumManagementForm());

            SetActiveAcademicButton(btnCurriculum);
        }

        private void btnSchedules_Click(object? sender, EventArgs e)
        {
            ShowPage(new ScheduleManagementForm());

            SetActiveAcademicButton(btnSchedules);
        }

        private void btnPeriods_Click(object? sender, EventArgs e)
        {
            ShowPage(new PeriodManagementForm());

            SetActiveAcademicButton(btnPeriods);
        }

        // =========================================================
        // ENROLLMENT
        // =========================================================

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            ShowPage(new EnrollmentManagementForm());

            SetActiveMainButton(btnEnrollment);
        }

        // =========================================================
        // REPORTS
        // =========================================================

        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowPage(new ReportCenterForm());

            SetActiveMainButton(btnReports);
        }

        private void btnNotifications_Click(object? sender, EventArgs e)
        {
            ShowPage(new NotificationsForm(NavigateFromNotification, RefreshNotificationBadge));

            SetActiveMainButton(btnNotifications);
        }

        /// <summary>Follows the link stored in a notification.</summary>
        private void NavigateFromNotification(string link)
        {
            switch (link)
            {
                case "enrollment_review":
                case "enrollment":
                    btnEnrollment_Click(btnEnrollment, EventArgs.Empty);
                    break;

                case "students":
                    btnStudents_Click(btnStudents, EventArgs.Empty);
                    break;

                case "reports":
                    btnReports_Click(btnReports, EventArgs.Empty);
                    break;
            }
        }

        private void RefreshNotificationBadge()
        {
            try
            {
                int unread = new NotificationService().CountUnread();
                btnNotifications.Text = unread > 0 ? $"  Notifications ({unread})" : "  Notifications";
            }
            catch
            {
                // The badge is a convenience; never interrupt the user for it.
            }
        }

        private void btnAnnouncements_Click(object? sender, EventArgs e)
        {
            ShowPage(new AnnouncementManagementForm());

            SetActiveMainButton(btnAnnouncements);
        }

        private void btnAccounts_Click(object? sender, EventArgs e)
        {
            ShowPage(new AccountsForm());

            SetActiveMainButton(btnAccounts);
        }

        private void btnAuditLog_Click(object? sender, EventArgs e)
        {
            ShowPage(new AuditLogForm());

            SetActiveMainButton(btnAuditLog);
        }

        private void btnChangePassword_Click(object? sender, EventArgs e)
        {
            using var form = new ChangePasswordForm(forced: false);
            form.ShowDialog(this);
        }

        // =========================================================
        // LOGOUT
        // =========================================================

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
                SESRS.Helpers.Session.End();

                LoginForm loginForm = new LoginForm();

                loginForm.Show();

                this.Close();
            }
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}