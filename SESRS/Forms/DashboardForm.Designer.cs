namespace SESRS.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnLogout = new Button();
            btnChangePassword = new Button();
            btnReports = new Button();
            btnAnnouncements = new Button();
            btnAccounts = new Button();
            btnAuditLog = new Button();
            btnGrades = new Button();
            btnNotifications = new Button();
            btnEnrollment = new Button();
            pnlAcademics = new Panel();
            btnSections = new Button();
            btnGradingSetup = new Button();
            btnCurriculum = new Button();
            btnSchedules = new Button();
            btnPeriods = new Button();
            btnSubjects = new Button();
            btnPrograms = new Button();
            btnAcademics = new Button();
            btnStudents = new Button();
            btnDashboard = new Button();
            pnlBrand = new Panel();
            lblSystemName = new Label();
            lblLogo = new Label();
            pnlContent = new Panel();
            pnlStats = new Panel();
            pnlEnrollmentCard = new Panel();
            lblEnrollmentSubtitle = new Label();
            lblEnrollmentCount = new Label();
            lblEnrollmentTitle = new Label();
            pnlSectionsCard = new Panel();
            lblSectionsSubtitle = new Label();
            lblSectionsCount = new Label();
            lblSectionsTitle = new Label();
            pnlSubjectsCard = new Panel();
            lblSubjectsSubtitle = new Label();
            lblSubjectsCount = new Label();
            lblSubjectsTitle = new Label();
            pnlActiveStudentsCard = new Panel();
            lblActiveStudentsSubtitle = new Label();
            lblActiveStudentsCount = new Label();
            lblActiveStudentsTitle = new Label();
            pnlStudentsCard = new Panel();
            lblStudentsSubtitle = new Label();
            lblStudentsCount = new Label();
            lblStudentsTitle = new Label();
            pnlHeader = new Panel();
            lblHeaderLine = new Panel();
            lblWelcome = new Label();
            lblDashboardTitle = new Label();
            pnlSidebar.SuspendLayout();
            pnlAcademics.SuspendLayout();
            pnlBrand.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlStats.SuspendLayout();
            pnlEnrollmentCard.SuspendLayout();
            pnlSectionsCard.SuspendLayout();
            pnlSubjectsCard.SuspendLayout();
            pnlActiveStudentsCard.SuspendLayout();
            pnlStudentsCard.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(24, 82, 58);
            pnlSidebar.Controls.Add(btnChangePassword);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnAuditLog);
            pnlSidebar.Controls.Add(btnAccounts);
            pnlSidebar.Controls.Add(btnAnnouncements);
            pnlSidebar.Controls.Add(btnNotifications);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnGrades);
            pnlSidebar.Controls.Add(btnEnrollment);
            pnlSidebar.Controls.Add(pnlAcademics);
            pnlSidebar.Controls.Add(btnStudents);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(pnlBrand);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(2);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(245, 720);
            pnlSidebar.TabIndex = 0;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(24, 82, 58);
            btnChangePassword.Dock = DockStyle.Bottom;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 10F);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(0, 624);
            btnChangePassword.Margin = new Padding(2);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Padding = new Padding(20, 0, 0, 0);
            btnChangePassword.Size = new Size(245, 48);
            btnChangePassword.TabIndex = 8;
            btnChangePassword.Text = "  Change Password";
            btnChangePassword.TextAlign = ContentAlignment.MiddleLeft;
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(19, 68, 48);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 55, 55);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 672);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Size = new Size(245, 48);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "  Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(24, 82, 58);
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 112, 80);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 10F);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(0, 489);
            btnReports.Margin = new Padding(2);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(20, 0, 0, 0);
            btnReports.Size = new Size(245, 48);
            btnReports.TabIndex = 5;
            btnReports.Text = "  Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // btnAuditLog
            // 
            btnAuditLog.BackColor = Color.FromArgb(24, 82, 58);
            btnAuditLog.Dock = DockStyle.Top;
            btnAuditLog.FlatAppearance.BorderSize = 0;
            btnAuditLog.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 112, 80);
            btnAuditLog.FlatStyle = FlatStyle.Flat;
            btnAuditLog.Font = new Font("Segoe UI", 10F);
            btnAuditLog.ForeColor = Color.White;
            btnAuditLog.Location = new Point(0, 489);
            btnAuditLog.Margin = new Padding(2);
            btnAuditLog.Name = "btnAuditLog";
            btnAuditLog.Padding = new Padding(20, 0, 0, 0);
            btnAuditLog.Size = new Size(245, 48);
            btnAuditLog.TabIndex = 16;
            btnAuditLog.Text = "  Audit Log";
            btnAuditLog.TextAlign = ContentAlignment.MiddleLeft;
            btnAuditLog.UseVisualStyleBackColor = false;
            btnAuditLog.Click += btnAuditLog_Click;
            // 
            // btnAccounts
            // 
            btnAccounts.BackColor = Color.FromArgb(24, 82, 58);
            btnAccounts.Dock = DockStyle.Top;
            btnAccounts.FlatAppearance.BorderSize = 0;
            btnAccounts.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 112, 80);
            btnAccounts.FlatStyle = FlatStyle.Flat;
            btnAccounts.Font = new Font("Segoe UI", 10F);
            btnAccounts.ForeColor = Color.White;
            btnAccounts.Location = new Point(0, 489);
            btnAccounts.Margin = new Padding(2);
            btnAccounts.Name = "btnAccounts";
            btnAccounts.Padding = new Padding(20, 0, 0, 0);
            btnAccounts.Size = new Size(245, 48);
            btnAccounts.TabIndex = 15;
            btnAccounts.Text = "  Accounts";
            btnAccounts.TextAlign = ContentAlignment.MiddleLeft;
            btnAccounts.UseVisualStyleBackColor = false;
            btnAccounts.Click += btnAccounts_Click;
            // 
            // btnAnnouncements
            // 
            btnAnnouncements.BackColor = Color.FromArgb(24, 82, 58);
            btnAnnouncements.Dock = DockStyle.Top;
            btnAnnouncements.FlatAppearance.BorderSize = 0;
            btnAnnouncements.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 112, 80);
            btnAnnouncements.FlatStyle = FlatStyle.Flat;
            btnAnnouncements.Font = new Font("Segoe UI", 10F);
            btnAnnouncements.ForeColor = Color.White;
            btnAnnouncements.Location = new Point(0, 489);
            btnAnnouncements.Margin = new Padding(2);
            btnAnnouncements.Name = "btnAnnouncements";
            btnAnnouncements.Padding = new Padding(20, 0, 0, 0);
            btnAnnouncements.Size = new Size(245, 48);
            btnAnnouncements.TabIndex = 14;
            btnAnnouncements.Text = "  Announcements";
            btnAnnouncements.TextAlign = ContentAlignment.MiddleLeft;
            btnAnnouncements.UseVisualStyleBackColor = false;
            btnAnnouncements.Click += btnAnnouncements_Click;
            // 
            // btnGrades
            // 
            btnGrades.BackColor = Color.FromArgb(24, 82, 58);
            btnGrades.Dock = DockStyle.Top;
            btnGrades.FlatAppearance.BorderSize = 0;
            btnGrades.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 112, 80);
            btnGrades.FlatStyle = FlatStyle.Flat;
            btnGrades.Font = new Font("Segoe UI", 10F);
            btnGrades.ForeColor = Color.White;
            btnGrades.Location = new Point(0, 489);
            btnGrades.Margin = new Padding(2);
            btnGrades.Name = "btnGrades";
            btnGrades.Padding = new Padding(20, 0, 0, 0);
            btnGrades.Size = new Size(245, 48);
            btnGrades.TabIndex = 13;
            btnGrades.Text = "  Grades";
            btnGrades.TextAlign = ContentAlignment.MiddleLeft;
            btnGrades.UseVisualStyleBackColor = false;
            btnGrades.Click += btnGrades_Click;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = Color.FromArgb(24, 82, 58);
            btnNotifications.Dock = DockStyle.Top;
            btnNotifications.FlatAppearance.BorderSize = 0;
            btnNotifications.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 112, 80);
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.Font = new Font("Segoe UI", 10F);
            btnNotifications.ForeColor = Color.White;
            btnNotifications.Location = new Point(0, 489);
            btnNotifications.Margin = new Padding(2);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Padding = new Padding(20, 0, 0, 0);
            btnNotifications.Size = new Size(245, 48);
            btnNotifications.TabIndex = 12;
            btnNotifications.Text = "  Notifications";
            btnNotifications.TextAlign = ContentAlignment.MiddleLeft;
            btnNotifications.UseVisualStyleBackColor = false;
            btnNotifications.Click += btnNotifications_Click;
            // 
            // btnEnrollment
            // 
            btnEnrollment.BackColor = Color.FromArgb(24, 82, 58);
            btnEnrollment.Dock = DockStyle.Top;
            btnEnrollment.FlatAppearance.BorderSize = 0;
            btnEnrollment.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 112, 80);
            btnEnrollment.FlatStyle = FlatStyle.Flat;
            btnEnrollment.Font = new Font("Segoe UI", 10F);
            btnEnrollment.ForeColor = Color.White;
            btnEnrollment.Location = new Point(0, 441);
            btnEnrollment.Margin = new Padding(2);
            btnEnrollment.Name = "btnEnrollment";
            btnEnrollment.Padding = new Padding(20, 0, 0, 0);
            btnEnrollment.Size = new Size(245, 48);
            btnEnrollment.TabIndex = 4;
            btnEnrollment.Text = "  Enrollment";
            btnEnrollment.TextAlign = ContentAlignment.MiddleLeft;
            btnEnrollment.UseVisualStyleBackColor = false;
            btnEnrollment.Click += btnEnrollment_Click;
            // 
            // pnlAcademics
            // 
            pnlAcademics.BackColor = Color.FromArgb(24, 82, 58);
            pnlAcademics.Controls.Add(btnGradingSetup);
            pnlAcademics.Controls.Add(btnPeriods);
            pnlAcademics.Controls.Add(btnSchedules);
            pnlAcademics.Controls.Add(btnCurriculum);
            pnlAcademics.Controls.Add(btnSections);
            pnlAcademics.Controls.Add(btnSubjects);
            pnlAcademics.Controls.Add(btnPrograms);
            pnlAcademics.Controls.Add(btnAcademics);
            pnlAcademics.Dock = DockStyle.Top;
            pnlAcademics.Location = new Point(0, 249);
            pnlAcademics.Margin = new Padding(2);
            pnlAcademics.Name = "pnlAcademics";
            pnlAcademics.Size = new Size(245, 384);
            pnlAcademics.TabIndex = 3;
            // 
            // btnSections
            // 
            btnSections.BackColor = Color.FromArgb(31, 96, 68);
            btnSections.Dock = DockStyle.Top;
            btnSections.FlatAppearance.BorderSize = 0;
            btnSections.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 119, 84);
            btnSections.FlatStyle = FlatStyle.Flat;
            btnSections.Font = new Font("Segoe UI", 9F);
            btnSections.ForeColor = Color.FromArgb(225, 240, 232);
            btnSections.Location = new Point(0, 144);
            btnSections.Margin = new Padding(2);
            btnSections.Name = "btnSections";
            btnSections.Padding = new Padding(42, 0, 0, 0);
            btnSections.Size = new Size(245, 48);
            btnSections.TabIndex = 3;
            btnSections.Text = "Sections";
            btnSections.TextAlign = ContentAlignment.MiddleLeft;
            btnSections.UseVisualStyleBackColor = false;
            btnSections.Click += btnSections_Click;
            // 
            // btnGradingSetup
            // 
            btnGradingSetup.BackColor = Color.FromArgb(31, 96, 68);
            btnGradingSetup.Dock = DockStyle.Top;
            btnGradingSetup.FlatAppearance.BorderSize = 0;
            btnGradingSetup.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 119, 84);
            btnGradingSetup.FlatStyle = FlatStyle.Flat;
            btnGradingSetup.Font = new Font("Segoe UI", 9F);
            btnGradingSetup.ForeColor = Color.FromArgb(225, 240, 232);
            btnGradingSetup.Location = new Point(0, 144);
            btnGradingSetup.Margin = new Padding(2);
            btnGradingSetup.Name = "btnGradingSetup";
            btnGradingSetup.Padding = new Padding(42, 0, 0, 0);
            btnGradingSetup.Size = new Size(245, 48);
            btnGradingSetup.TabIndex = 9;
            btnGradingSetup.Text = "Grading Setup";
            btnGradingSetup.TextAlign = ContentAlignment.MiddleLeft;
            btnGradingSetup.UseVisualStyleBackColor = false;
            btnGradingSetup.Click += btnGradingSetup_Click;
            // 
            // btnCurriculum
            // 
            btnCurriculum.BackColor = Color.FromArgb(31, 96, 68);
            btnCurriculum.Dock = DockStyle.Top;
            btnCurriculum.FlatAppearance.BorderSize = 0;
            btnCurriculum.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 119, 84);
            btnCurriculum.FlatStyle = FlatStyle.Flat;
            btnCurriculum.Font = new Font("Segoe UI", 9F);
            btnCurriculum.ForeColor = Color.FromArgb(225, 240, 232);
            btnCurriculum.Location = new Point(0, 144);
            btnCurriculum.Margin = new Padding(2);
            btnCurriculum.Name = "btnCurriculum";
            btnCurriculum.Padding = new Padding(42, 0, 0, 0);
            btnCurriculum.Size = new Size(245, 48);
            btnCurriculum.TabIndex = 6;
            btnCurriculum.Text = "Curriculum";
            btnCurriculum.TextAlign = ContentAlignment.MiddleLeft;
            btnCurriculum.UseVisualStyleBackColor = false;
            btnCurriculum.Click += btnCurriculum_Click;
            // 
            // btnSchedules
            // 
            btnSchedules.BackColor = Color.FromArgb(31, 96, 68);
            btnSchedules.Dock = DockStyle.Top;
            btnSchedules.FlatAppearance.BorderSize = 0;
            btnSchedules.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 119, 84);
            btnSchedules.FlatStyle = FlatStyle.Flat;
            btnSchedules.Font = new Font("Segoe UI", 9F);
            btnSchedules.ForeColor = Color.FromArgb(225, 240, 232);
            btnSchedules.Location = new Point(0, 144);
            btnSchedules.Margin = new Padding(2);
            btnSchedules.Name = "btnSchedules";
            btnSchedules.Padding = new Padding(42, 0, 0, 0);
            btnSchedules.Size = new Size(245, 48);
            btnSchedules.TabIndex = 7;
            btnSchedules.Text = "Schedules";
            btnSchedules.TextAlign = ContentAlignment.MiddleLeft;
            btnSchedules.UseVisualStyleBackColor = false;
            btnSchedules.Click += btnSchedules_Click;
            // 
            // btnPeriods
            // 
            btnPeriods.BackColor = Color.FromArgb(31, 96, 68);
            btnPeriods.Dock = DockStyle.Top;
            btnPeriods.FlatAppearance.BorderSize = 0;
            btnPeriods.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 119, 84);
            btnPeriods.FlatStyle = FlatStyle.Flat;
            btnPeriods.Font = new Font("Segoe UI", 9F);
            btnPeriods.ForeColor = Color.FromArgb(225, 240, 232);
            btnPeriods.Location = new Point(0, 144);
            btnPeriods.Margin = new Padding(2);
            btnPeriods.Name = "btnPeriods";
            btnPeriods.Padding = new Padding(42, 0, 0, 0);
            btnPeriods.Size = new Size(245, 48);
            btnPeriods.TabIndex = 8;
            btnPeriods.Text = "Academic Periods";
            btnPeriods.TextAlign = ContentAlignment.MiddleLeft;
            btnPeriods.UseVisualStyleBackColor = false;
            btnPeriods.Click += btnPeriods_Click;
            // 
            // btnSubjects
            // 
            btnSubjects.BackColor = Color.FromArgb(31, 96, 68);
            btnSubjects.Dock = DockStyle.Top;
            btnSubjects.FlatAppearance.BorderSize = 0;
            btnSubjects.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 119, 84);
            btnSubjects.FlatStyle = FlatStyle.Flat;
            btnSubjects.Font = new Font("Segoe UI", 9F);
            btnSubjects.ForeColor = Color.FromArgb(225, 240, 232);
            btnSubjects.Location = new Point(0, 96);
            btnSubjects.Margin = new Padding(2);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Padding = new Padding(42, 0, 0, 0);
            btnSubjects.Size = new Size(245, 48);
            btnSubjects.TabIndex = 2;
            btnSubjects.Text = "Subjects";
            btnSubjects.TextAlign = ContentAlignment.MiddleLeft;
            btnSubjects.UseVisualStyleBackColor = false;
            btnSubjects.Click += btnSubjects_Click;
            // 
            // btnPrograms
            // 
            btnPrograms.BackColor = Color.FromArgb(31, 96, 68);
            btnPrograms.Dock = DockStyle.Top;
            btnPrograms.FlatAppearance.BorderSize = 0;
            btnPrograms.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 119, 84);
            btnPrograms.FlatStyle = FlatStyle.Flat;
            btnPrograms.Font = new Font("Segoe UI", 9F);
            btnPrograms.ForeColor = Color.FromArgb(225, 240, 232);
            btnPrograms.Location = new Point(0, 48);
            btnPrograms.Margin = new Padding(2);
            btnPrograms.Name = "btnPrograms";
            btnPrograms.Padding = new Padding(42, 0, 0, 0);
            btnPrograms.Size = new Size(245, 48);
            btnPrograms.TabIndex = 1;
            btnPrograms.Text = "Programs";
            btnPrograms.TextAlign = ContentAlignment.MiddleLeft;
            btnPrograms.UseVisualStyleBackColor = false;
            btnPrograms.Click += btnPrograms_Click;
            // 
            // btnAcademics
            // 
            btnAcademics.BackColor = Color.FromArgb(24, 82, 58);
            btnAcademics.Dock = DockStyle.Top;
            btnAcademics.FlatAppearance.BorderSize = 0;
            btnAcademics.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 112, 80);
            btnAcademics.FlatStyle = FlatStyle.Flat;
            btnAcademics.Font = new Font("Segoe UI", 10F);
            btnAcademics.ForeColor = Color.White;
            btnAcademics.Location = new Point(0, 0);
            btnAcademics.Margin = new Padding(2);
            btnAcademics.Name = "btnAcademics";
            btnAcademics.Padding = new Padding(20, 0, 0, 0);
            btnAcademics.Size = new Size(245, 48);
            btnAcademics.TabIndex = 0;
            btnAcademics.Text = "  Academics    ▼";
            btnAcademics.TextAlign = ContentAlignment.MiddleLeft;
            btnAcademics.UseVisualStyleBackColor = false;
            btnAcademics.Click += btnAcademics_Click;
            // 
            // btnStudents
            // 
            btnStudents.BackColor = Color.FromArgb(24, 82, 58);
            btnStudents.Dock = DockStyle.Top;
            btnStudents.FlatAppearance.BorderSize = 0;
            btnStudents.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 112, 80);
            btnStudents.FlatStyle = FlatStyle.Flat;
            btnStudents.Font = new Font("Segoe UI", 10F);
            btnStudents.ForeColor = Color.White;
            btnStudents.Location = new Point(0, 201);
            btnStudents.Margin = new Padding(2);
            btnStudents.Name = "btnStudents";
            btnStudents.Padding = new Padding(20, 0, 0, 0);
            btnStudents.Size = new Size(245, 48);
            btnStudents.TabIndex = 2;
            btnStudents.Text = "  Students";
            btnStudents.TextAlign = ContentAlignment.MiddleLeft;
            btnStudents.UseVisualStyleBackColor = false;
            btnStudents.Click += btnStudents_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(42, 112, 80);
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 128, 91);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 105);
            btnDashboard.Margin = new Padding(2);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(20, 0, 0, 0);
            btnDashboard.Size = new Size(245, 48);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "  Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlBrand
            // 
            pnlBrand.BackColor = Color.FromArgb(19, 68, 48);
            pnlBrand.Controls.Add(lblSystemName);
            pnlBrand.Controls.Add(lblLogo);
            pnlBrand.Dock = DockStyle.Top;
            pnlBrand.Location = new Point(0, 0);
            pnlBrand.Margin = new Padding(2);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(245, 105);
            pnlBrand.TabIndex = 0;
            // 
            // lblSystemName
            // 
            lblSystemName.Dock = DockStyle.Bottom;
            lblSystemName.Font = new Font("Segoe UI", 8.5F);
            lblSystemName.ForeColor = Color.FromArgb(210, 230, 220);
            lblSystemName.Location = new Point(0, 74);
            lblSystemName.Margin = new Padding(2, 0, 2, 0);
            lblSystemName.Name = "lblSystemName";
            lblSystemName.Size = new Size(245, 31);
            lblSystemName.TabIndex = 1;
            lblSystemName.Text = "SCHOOL ENROLLMENT &\r\nSTUDENT REGISTRATION SYSTEM";
            lblSystemName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Margin = new Padding(2, 0, 2, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(245, 63);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "SESRS";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(245, 247, 246);
            pnlContent.Controls.Add(pnlStats);
            pnlContent.Controls.Add(pnlHeader);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(245, 0);
            pnlContent.Margin = new Padding(2);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(35);
            pnlContent.Size = new Size(1445, 720);
            pnlContent.TabIndex = 1;
            // 
            // pnlStats
            // 
            pnlStats.BackColor = Color.Transparent;
            pnlStats.Controls.Add(pnlEnrollmentCard);
            pnlStats.Controls.Add(pnlSectionsCard);
            pnlStats.Controls.Add(pnlSubjectsCard);
            pnlStats.Controls.Add(pnlActiveStudentsCard);
            pnlStats.Controls.Add(pnlStudentsCard);
            pnlStats.Dock = DockStyle.Fill;
            pnlStats.Location = new Point(35, 160);
            pnlStats.Margin = new Padding(2);
            pnlStats.Name = "pnlStats";
            pnlStats.Padding = new Padding(10, 25, 10, 25);
            pnlStats.Size = new Size(1375, 525);
            pnlStats.TabIndex = 1;
            // 
            // pnlEnrollmentCard
            // 
            pnlEnrollmentCard.BackColor = Color.White;
            pnlEnrollmentCard.BorderStyle = BorderStyle.FixedSingle;
            pnlEnrollmentCard.Controls.Add(lblEnrollmentSubtitle);
            pnlEnrollmentCard.Controls.Add(lblEnrollmentCount);
            pnlEnrollmentCard.Controls.Add(lblEnrollmentTitle);
            pnlEnrollmentCard.Location = new Point(1030, 25);
            pnlEnrollmentCard.Margin = new Padding(2);
            pnlEnrollmentCard.Name = "pnlEnrollmentCard";
            pnlEnrollmentCard.Size = new Size(256, 200);
            pnlEnrollmentCard.TabIndex = 4;
            // 
            // lblEnrollmentSubtitle
            // 
            lblEnrollmentSubtitle.AutoSize = true;
            lblEnrollmentSubtitle.Font = new Font("Segoe UI", 9F);
            lblEnrollmentSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblEnrollmentSubtitle.Location = new Point(20, 155);
            lblEnrollmentSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblEnrollmentSubtitle.Name = "lblEnrollmentSubtitle";
            lblEnrollmentSubtitle.Size = new Size(185, 25);
            lblEnrollmentSubtitle.TabIndex = 2;
            lblEnrollmentSubtitle.Text = "Recorded enrollments";
            // 
            // lblEnrollmentCount
            // 
            lblEnrollmentCount.AutoSize = true;
            lblEnrollmentCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblEnrollmentCount.ForeColor = Color.FromArgb(145, 72, 72);
            lblEnrollmentCount.Location = new Point(18, 58);
            lblEnrollmentCount.Margin = new Padding(2, 0, 2, 0);
            lblEnrollmentCount.Name = "lblEnrollmentCount";
            lblEnrollmentCount.Size = new Size(91, 106);
            lblEnrollmentCount.TabIndex = 1;
            lblEnrollmentCount.Text = "0";
            // 
            // lblEnrollmentTitle
            // 
            lblEnrollmentTitle.AutoSize = true;
            lblEnrollmentTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEnrollmentTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblEnrollmentTitle.Location = new Point(18, 20);
            lblEnrollmentTitle.Margin = new Padding(2, 0, 2, 0);
            lblEnrollmentTitle.Name = "lblEnrollmentTitle";
            lblEnrollmentTitle.Size = new Size(222, 28);
            lblEnrollmentTitle.TabIndex = 0;
            lblEnrollmentTitle.Text = "TOTAL ENROLLMENTS";
            // 
            // pnlSectionsCard
            // 
            pnlSectionsCard.BackColor = Color.White;
            pnlSectionsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSectionsCard.Controls.Add(lblSectionsSubtitle);
            pnlSectionsCard.Controls.Add(lblSectionsCount);
            pnlSectionsCard.Controls.Add(lblSectionsTitle);
            pnlSectionsCard.Location = new Point(775, 25);
            pnlSectionsCard.Margin = new Padding(2);
            pnlSectionsCard.Name = "pnlSectionsCard";
            pnlSectionsCard.Size = new Size(250, 200);
            pnlSectionsCard.TabIndex = 3;
            // 
            // lblSectionsSubtitle
            // 
            lblSectionsSubtitle.AutoSize = true;
            lblSectionsSubtitle.Font = new Font("Segoe UI", 9F);
            lblSectionsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblSectionsSubtitle.Location = new Point(20, 155);
            lblSectionsSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSectionsSubtitle.Name = "lblSectionsSubtitle";
            lblSectionsSubtitle.Size = new Size(129, 25);
            lblSectionsSubtitle.TabIndex = 2;
            lblSectionsSubtitle.Text = "Active sections";
            // 
            // lblSectionsCount
            // 
            lblSectionsCount.AutoSize = true;
            lblSectionsCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblSectionsCount.ForeColor = Color.FromArgb(117, 86, 40);
            lblSectionsCount.Location = new Point(18, 58);
            lblSectionsCount.Margin = new Padding(2, 0, 2, 0);
            lblSectionsCount.Name = "lblSectionsCount";
            lblSectionsCount.Size = new Size(91, 106);
            lblSectionsCount.TabIndex = 1;
            lblSectionsCount.Text = "0";
            // 
            // lblSectionsTitle
            // 
            lblSectionsTitle.AutoSize = true;
            lblSectionsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSectionsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblSectionsTitle.Location = new Point(18, 20);
            lblSectionsTitle.Margin = new Padding(2, 0, 2, 0);
            lblSectionsTitle.Name = "lblSectionsTitle";
            lblSectionsTitle.Size = new Size(172, 28);
            lblSectionsTitle.TabIndex = 0;
            lblSectionsTitle.Text = "TOTAL SECTIONS";
            // 
            // pnlSubjectsCard
            // 
            pnlSubjectsCard.BackColor = Color.White;
            pnlSubjectsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSubjectsCard.Controls.Add(lblSubjectsSubtitle);
            pnlSubjectsCard.Controls.Add(lblSubjectsCount);
            pnlSubjectsCard.Controls.Add(lblSubjectsTitle);
            pnlSubjectsCard.Location = new Point(520, 25);
            pnlSubjectsCard.Margin = new Padding(2);
            pnlSubjectsCard.Name = "pnlSubjectsCard";
            pnlSubjectsCard.Size = new Size(250, 200);
            pnlSubjectsCard.TabIndex = 2;
            // 
            // lblSubjectsSubtitle
            // 
            lblSubjectsSubtitle.AutoSize = true;
            lblSubjectsSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubjectsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblSubjectsSubtitle.Location = new Point(20, 155);
            lblSubjectsSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSubjectsSubtitle.Name = "lblSubjectsSubtitle";
            lblSubjectsSubtitle.Size = new Size(152, 25);
            lblSubjectsSubtitle.TabIndex = 2;
            lblSubjectsSubtitle.Text = "Available subjects";
            // 
            // lblSubjectsCount
            // 
            lblSubjectsCount.AutoSize = true;
            lblSubjectsCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblSubjectsCount.ForeColor = Color.FromArgb(53, 91, 125);
            lblSubjectsCount.Location = new Point(18, 58);
            lblSubjectsCount.Margin = new Padding(2, 0, 2, 0);
            lblSubjectsCount.Name = "lblSubjectsCount";
            lblSubjectsCount.Size = new Size(91, 106);
            lblSubjectsCount.TabIndex = 1;
            lblSubjectsCount.Text = "0";
            // 
            // lblSubjectsTitle
            // 
            lblSubjectsTitle.AutoSize = true;
            lblSubjectsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubjectsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblSubjectsTitle.Location = new Point(18, 20);
            lblSubjectsTitle.Margin = new Padding(2, 0, 2, 0);
            lblSubjectsTitle.Name = "lblSubjectsTitle";
            lblSubjectsTitle.Size = new Size(171, 28);
            lblSubjectsTitle.TabIndex = 0;
            lblSubjectsTitle.Text = "TOTAL SUBJECTS";
            // 
            // pnlActiveStudentsCard
            // 
            pnlActiveStudentsCard.BackColor = Color.White;
            pnlActiveStudentsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlActiveStudentsCard.Controls.Add(lblActiveStudentsSubtitle);
            pnlActiveStudentsCard.Controls.Add(lblActiveStudentsCount);
            pnlActiveStudentsCard.Controls.Add(lblActiveStudentsTitle);
            pnlActiveStudentsCard.Location = new Point(265, 25);
            pnlActiveStudentsCard.Margin = new Padding(2);
            pnlActiveStudentsCard.Name = "pnlActiveStudentsCard";
            pnlActiveStudentsCard.Size = new Size(250, 200);
            pnlActiveStudentsCard.TabIndex = 1;
            // 
            // lblActiveStudentsSubtitle
            // 
            lblActiveStudentsSubtitle.AutoSize = true;
            lblActiveStudentsSubtitle.Font = new Font("Segoe UI", 9F);
            lblActiveStudentsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblActiveStudentsSubtitle.Location = new Point(20, 155);
            lblActiveStudentsSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblActiveStudentsSubtitle.Name = "lblActiveStudentsSubtitle";
            lblActiveStudentsSubtitle.Size = new Size(133, 25);
            lblActiveStudentsSubtitle.TabIndex = 2;
            lblActiveStudentsSubtitle.Text = "Currently active";
            // 
            // lblActiveStudentsCount
            // 
            lblActiveStudentsCount.AutoSize = true;
            lblActiveStudentsCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblActiveStudentsCount.ForeColor = Color.FromArgb(42, 112, 80);
            lblActiveStudentsCount.Location = new Point(18, 58);
            lblActiveStudentsCount.Margin = new Padding(2, 0, 2, 0);
            lblActiveStudentsCount.Name = "lblActiveStudentsCount";
            lblActiveStudentsCount.Size = new Size(91, 106);
            lblActiveStudentsCount.TabIndex = 1;
            lblActiveStudentsCount.Text = "0";
            // 
            // lblActiveStudentsTitle
            // 
            lblActiveStudentsTitle.AutoSize = true;
            lblActiveStudentsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblActiveStudentsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblActiveStudentsTitle.Location = new Point(18, 20);
            lblActiveStudentsTitle.Margin = new Padding(2, 0, 2, 0);
            lblActiveStudentsTitle.Name = "lblActiveStudentsTitle";
            lblActiveStudentsTitle.Size = new Size(188, 28);
            lblActiveStudentsTitle.TabIndex = 0;
            lblActiveStudentsTitle.Text = "ACTIVE STUDENTS";
            // 
            // pnlStudentsCard
            // 
            pnlStudentsCard.BackColor = Color.White;
            pnlStudentsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlStudentsCard.Controls.Add(lblStudentsSubtitle);
            pnlStudentsCard.Controls.Add(lblStudentsCount);
            pnlStudentsCard.Controls.Add(lblStudentsTitle);
            pnlStudentsCard.Location = new Point(10, 25);
            pnlStudentsCard.Margin = new Padding(2);
            pnlStudentsCard.Name = "pnlStudentsCard";
            pnlStudentsCard.Size = new Size(250, 200);
            pnlStudentsCard.TabIndex = 0;
            // 
            // lblStudentsSubtitle
            // 
            lblStudentsSubtitle.AutoSize = true;
            lblStudentsSubtitle.Font = new Font("Segoe UI", 9F);
            lblStudentsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblStudentsSubtitle.Location = new Point(20, 155);
            lblStudentsSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblStudentsSubtitle.Name = "lblStudentsSubtitle";
            lblStudentsSubtitle.Size = new Size(168, 25);
            lblStudentsSubtitle.TabIndex = 2;
            lblStudentsSubtitle.Text = "Registered students";
            // 
            // lblStudentsCount
            // 
            lblStudentsCount.AutoSize = true;
            lblStudentsCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblStudentsCount.ForeColor = Color.FromArgb(24, 82, 58);
            lblStudentsCount.Location = new Point(18, 58);
            lblStudentsCount.Margin = new Padding(2, 0, 2, 0);
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Size = new Size(91, 106);
            lblStudentsCount.TabIndex = 1;
            lblStudentsCount.Text = "0";
            // 
            // lblStudentsTitle
            // 
            lblStudentsTitle.AutoSize = true;
            lblStudentsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStudentsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblStudentsTitle.Location = new Point(18, 20);
            lblStudentsTitle.Margin = new Padding(2, 0, 2, 0);
            lblStudentsTitle.Name = "lblStudentsTitle";
            lblStudentsTitle.Size = new Size(180, 28);
            lblStudentsTitle.TabIndex = 0;
            lblStudentsTitle.Text = "TOTAL STUDENTS";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Transparent;
            pnlHeader.Controls.Add(lblHeaderLine);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblDashboardTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(35, 35);
            pnlHeader.Margin = new Padding(2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1375, 125);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderLine
            // 
            lblHeaderLine.BackColor = Color.FromArgb(42, 112, 80);
            lblHeaderLine.Location = new Point(0, 102);
            lblHeaderLine.Margin = new Padding(2);
            lblHeaderLine.Name = "lblHeaderLine";
            lblHeaderLine.Size = new Size(65, 5);
            lblHeaderLine.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 12F);
            lblWelcome.ForeColor = Color.FromArgb(105, 115, 110);
            lblWelcome.Location = new Point(70, 82);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(330, 32);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome back, Administrator.";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 28.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardTitle.ForeColor = Color.FromArgb(35, 45, 40);
            lblDashboardTitle.Location = new Point(2, 0);
            lblDashboardTitle.Margin = new Padding(2, 0, 2, 0);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(328, 77);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Dashboard";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 246);
            ClientSize = new Size(1690, 720);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(2);
            MinimumSize = new Size(1100, 647);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SESRS - Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += DashboardForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlAcademics.ResumeLayout(false);
            pnlBrand.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlStats.ResumeLayout(false);
            pnlEnrollmentCard.ResumeLayout(false);
            pnlEnrollmentCard.PerformLayout();
            pnlSectionsCard.ResumeLayout(false);
            pnlSectionsCard.PerformLayout();
            pnlSubjectsCard.ResumeLayout(false);
            pnlSubjectsCard.PerformLayout();
            pnlActiveStudentsCard.ResumeLayout(false);
            pnlActiveStudentsCard.PerformLayout();
            pnlStudentsCard.ResumeLayout(false);
            pnlStudentsCard.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // =========================================================
        // SIDEBAR
        // =========================================================

        private Panel pnlSidebar;
        private Panel pnlBrand;

        private Label lblLogo;
        private Label lblSystemName;

        private Button btnDashboard;
        private Button btnStudents;

        private Panel pnlAcademics;
        private Button btnAcademics;
        private Button btnPrograms;
        private Button btnSubjects;
        private Button btnSections;
        private Button btnGradingSetup;
        private Button btnCurriculum;
        private Button btnSchedules;
        private Button btnPeriods;

        private Button btnEnrollment;
        private Button btnReports;
        private Button btnAnnouncements;
        private Button btnAccounts;
        private Button btnAuditLog;
        private Button btnGrades;
        private Button btnNotifications;
        private Button btnLogout;
        private Button btnChangePassword;

        // =========================================================
        // CONTENT
        // =========================================================

        private Panel pnlContent;

        private Panel pnlHeader;
        private Label lblDashboardTitle;
        private Label lblWelcome;
        private Panel lblHeaderLine;

        // =========================================================
        // STATISTICS
        // =========================================================

        private Panel pnlStats;

        private Panel pnlStudentsCard;
        private Label lblStudentsTitle;
        private Label lblStudentsCount;
        private Label lblStudentsSubtitle;

        private Panel pnlActiveStudentsCard;
        private Label lblActiveStudentsTitle;
        private Label lblActiveStudentsCount;
        private Label lblActiveStudentsSubtitle;

        private Panel pnlSubjectsCard;
        private Label lblSubjectsTitle;
        private Label lblSubjectsCount;
        private Label lblSubjectsSubtitle;

        private Panel pnlSectionsCard;
        private Label lblSectionsTitle;
        private Label lblSectionsCount;
        private Label lblSectionsSubtitle;

        private Panel pnlEnrollmentCard;
        private Label lblEnrollmentTitle;
        private Label lblEnrollmentCount;
        private Label lblEnrollmentSubtitle;
    }
}