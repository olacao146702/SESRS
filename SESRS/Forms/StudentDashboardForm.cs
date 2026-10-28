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

            LoadStudentInformation();
            InitializePortalHost();
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

                lblWelcome.Text =
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
                    SESRS.Helpers.ErrorHandler.Friendly(ex),
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // PORTAL PAGES (hosted over the original home cards)
        // =========================================================

        private readonly Panel _portalHost = new()
        {
            Dock = DockStyle.Fill,
            BackColor = Color.WhiteSmoke,
            Visible = false
        };

        private readonly NotificationService _notificationService = new();

        private void InitializePortalHost()
        {
            Controls.Add(_portalHost);

            // Front-most control is docked last, so it fills the space beside the sidebar.
            Controls.SetChildIndex(_portalHost, 0);

            Load += (_, _) => Navigate("home");
        }

        private int RequireStudentId()
        {
            return _user.StudentId
                ?? throw new SESRS.Helpers.BusinessRuleException("This account is not linked to a student record.");
        }

        /// <summary>Opens a portal page by key (also used by links inside notifications).</summary>
        private void Navigate(string key)
        {
            OpenPage(() => key switch
            {
                "home" => new StudentHomeForm(RequireStudentId(), Navigate),
                "enrollment" => new StudentEnrollmentForm(RequireStudentId()),
                "subjects" => new MyCurriculumForm(RequireStudentId()),
                "schedule" => new MyScheduleForm(RequireStudentId()),
                "history" => new EnrollmentHistoryForm(RequireStudentId()),
                "grades" => new MyGradesForm(RequireStudentId()),
                "notifications" => new NotificationsForm(Navigate, RefreshNotificationBadge),
                "announcements" => new StudentAnnouncementsForm(RequireStudentId()),
                "profile" => new ProfileForm(RequireStudentId()),
                _ => new StudentHomeForm(RequireStudentId(), Navigate)
            });

            RefreshNotificationBadge();
        }

        private void RefreshNotificationBadge()
        {
            try
            {
                int unread = _notificationService.CountUnread();
                btnNotifications.Text = unread > 0 ? $"Notifications ({unread})" : "Notifications";
            }
            catch
            {
                // The badge is a convenience; never interrupt the user for it.
            }
        }

        private void ClearHost()
        {
            foreach (Control control in _portalHost.Controls.Cast<Control>().ToList())
            {
                control.Dispose();
            }

            _portalHost.Controls.Clear();
        }

        private void OpenPage(Func<Form> create)
        {
            try
            {
                Form page = create();

                ClearHost();
                page.TopLevel = false;
                page.FormBorderStyle = FormBorderStyle.None;
                page.Dock = DockStyle.Fill;

                _portalHost.Controls.Add(page);
                _portalHost.Visible = true;
                _portalHost.BringToFront();

                page.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    SESRS.Helpers.ErrorHandler.Friendly(ex),
                    "SESRS",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnDashboard_Click(object? sender, EventArgs e)
        {
            Navigate("home");
        }

        private void btnEnrollment_Click(object? sender, EventArgs e)
        {
            Navigate("enrollment");
        }

        private void btnSubjects_Click(object? sender, EventArgs e)
        {
            Navigate("subjects");
        }

        private void btnSchedule_Click(object? sender, EventArgs e)
        {
            Navigate("schedule");
        }

        private void btnHistory_Click(object? sender, EventArgs e)
        {
            Navigate("history");
        }

        private void btnGrades_Click(object? sender, EventArgs e)
        {
            Navigate("grades");
        }

        private void btnNotifications_Click(object? sender, EventArgs e)
        {
            Navigate("notifications");
        }

        private void btnAnnouncements_Click(object? sender, EventArgs e)
        {
            Navigate("announcements");
        }

        private void btnProfile_Click(object? sender, EventArgs e)
        {
            Navigate("profile");
        }

        private void btnChangePassword_Click(object? sender, EventArgs e)
        {
            using var form = new ChangePasswordForm(forced: false);
            form.ShowDialog(this);
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
                SESRS.Helpers.Session.End();

                LoginForm loginForm = new LoginForm();

                loginForm.Show();

                this.Close();
            }
        }

    }
}