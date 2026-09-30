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

            pnlBrand = new Panel();
            lblLogo = new Label();
            lblSystemName = new Label();

            btnDashboard = new Button();
            btnStudents = new Button();

            pnlAcademics = new Panel();
            btnAcademics = new Button();
            btnPrograms = new Button();
            btnSubjects = new Button();
            btnSections = new Button();

            btnEnrollment = new Button();
            btnReports = new Button();
            btnPendingStudents = new Button();
            btnLogout = new Button();

            pnlContent = new Panel();

            pnlHeader = new Panel();
            lblDashboardTitle = new Label();
            lblWelcome = new Label();
            lblHeaderLine = new Panel();

            pnlStats = new Panel();

            pnlStudentsCard = new Panel();
            lblStudentsTitle = new Label();
            lblStudentsCount = new Label();
            lblStudentsSubtitle = new Label();

            pnlActiveStudentsCard = new Panel();
            lblActiveStudentsTitle = new Label();
            lblActiveStudentsCount = new Label();
            lblActiveStudentsSubtitle = new Label();

            pnlSubjectsCard = new Panel();
            lblSubjectsTitle = new Label();
            lblSubjectsCount = new Label();
            lblSubjectsSubtitle = new Label();

            pnlSectionsCard = new Panel();
            lblSectionsTitle = new Label();
            lblSectionsCount = new Label();
            lblSectionsSubtitle = new Label();

            pnlEnrollmentCard = new Panel();
            lblEnrollmentTitle = new Label();
            lblEnrollmentCount = new Label();
            lblEnrollmentSubtitle = new Label();

            // =========================================================
            // SUSPEND LAYOUT
            // =========================================================

            pnlSidebar.SuspendLayout();
            pnlBrand.SuspendLayout();
            pnlAcademics.SuspendLayout();

            pnlContent.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlStats.SuspendLayout();

            pnlStudentsCard.SuspendLayout();
            pnlActiveStudentsCard.SuspendLayout();
            pnlSubjectsCard.SuspendLayout();
            pnlSectionsCard.SuspendLayout();
            pnlEnrollmentCard.SuspendLayout();

            SuspendLayout();

            // =========================================================
            // SIDEBAR
            // =========================================================

            pnlSidebar.BackColor = Color.FromArgb(24, 82, 58);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(245, 720);
            pnlSidebar.TabIndex = 0;

            // =========================================================
            // BRAND
            // =========================================================

            pnlBrand.BackColor = Color.FromArgb(19, 68, 48);
            pnlBrand.Dock = DockStyle.Top;
            pnlBrand.Location = new Point(0, 0);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(245, 105);
            pnlBrand.TabIndex = 0;

            lblLogo.AutoSize = false;
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font(
                "Segoe UI",
                25F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 8);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(245, 50);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "SESRS";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;

            lblSystemName.AutoSize = false;
            lblSystemName.Dock = DockStyle.Bottom;
            lblSystemName.Font = new Font(
                "Segoe UI",
                8.5F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lblSystemName.ForeColor = Color.FromArgb(210, 230, 220);
            lblSystemName.Location = new Point(0, 63);
            lblSystemName.Name = "lblSystemName";
            lblSystemName.Size = new Size(245, 42);
            lblSystemName.TabIndex = 1;
            lblSystemName.Text =
                "SCHOOL ENROLLMENT &\r\nSTUDENT REGISTRATION SYSTEM";
            lblSystemName.TextAlign = ContentAlignment.MiddleCenter;

            pnlBrand.Controls.Add(lblSystemName);
            pnlBrand.Controls.Add(lblLogo);

            // =========================================================
            // DASHBOARD
            // =========================================================

            btnDashboard.BackColor = Color.FromArgb(42, 112, 80);
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(51, 128, 91);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 105);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(20, 0, 0, 0);
            btnDashboard.Size = new Size(245, 48);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "  Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;

            // =========================================================
            // STUDENTS
            // =========================================================

            btnStudents.BackColor = Color.FromArgb(24, 82, 58);
            btnStudents.Dock = DockStyle.Top;
            btnStudents.FlatAppearance.BorderSize = 0;
            btnStudents.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(42, 112, 80);
            btnStudents.FlatStyle = FlatStyle.Flat;
            btnStudents.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            btnStudents.ForeColor = Color.White;
            btnStudents.Location = new Point(0, 153);
            btnStudents.Name = "btnStudents";
            btnStudents.Padding = new Padding(20, 0, 0, 0);
            btnStudents.Size = new Size(245, 48);
            btnStudents.TabIndex = 2;
            btnStudents.Text = "  Students";
            btnStudents.TextAlign = ContentAlignment.MiddleLeft;
            btnStudents.UseVisualStyleBackColor = false;
            btnStudents.Click += btnStudents_Click;

            // =========================================================
            // ACADEMICS
            // =========================================================

            pnlAcademics.BackColor = Color.FromArgb(24, 82, 58);
            pnlAcademics.Controls.Add(btnSections);
            pnlAcademics.Controls.Add(btnSubjects);
            pnlAcademics.Controls.Add(btnPrograms);
            pnlAcademics.Controls.Add(btnAcademics);
            pnlAcademics.Dock = DockStyle.Top;
            pnlAcademics.Location = new Point(0, 201);
            pnlAcademics.Name = "pnlAcademics";
            pnlAcademics.Size = new Size(245, 192);
            pnlAcademics.TabIndex = 3;

            btnAcademics.BackColor = Color.FromArgb(24, 82, 58);
            btnAcademics.Dock = DockStyle.Top;
            btnAcademics.FlatAppearance.BorderSize = 0;
            btnAcademics.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(42, 112, 80);
            btnAcademics.FlatStyle = FlatStyle.Flat;
            btnAcademics.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            btnAcademics.ForeColor = Color.White;
            btnAcademics.Location = new Point(0, 0);
            btnAcademics.Name = "btnAcademics";
            btnAcademics.Padding = new Padding(20, 0, 0, 0);
            btnAcademics.Size = new Size(245, 48);
            btnAcademics.TabIndex = 0;
            btnAcademics.Text = "  Academics    ▼";
            btnAcademics.TextAlign = ContentAlignment.MiddleLeft;
            btnAcademics.UseVisualStyleBackColor = false;
            btnAcademics.Click += btnAcademics_Click;

            btnPrograms.BackColor = Color.FromArgb(31, 96, 68);
            btnPrograms.Dock = DockStyle.Top;
            btnPrograms.FlatAppearance.BorderSize = 0;
            btnPrograms.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(48, 119, 84);
            btnPrograms.FlatStyle = FlatStyle.Flat;
            btnPrograms.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            btnPrograms.ForeColor = Color.FromArgb(225, 240, 232);
            btnPrograms.Location = new Point(0, 48);
            btnPrograms.Name = "btnPrograms";
            btnPrograms.Padding = new Padding(42, 0, 0, 0);
            btnPrograms.Size = new Size(245, 48);
            btnPrograms.TabIndex = 1;
            btnPrograms.Text = "Programs";
            btnPrograms.TextAlign = ContentAlignment.MiddleLeft;
            btnPrograms.UseVisualStyleBackColor = false;
            btnPrograms.Click += btnPrograms_Click;

            btnSubjects.BackColor = Color.FromArgb(31, 96, 68);
            btnSubjects.Dock = DockStyle.Top;
            btnSubjects.FlatAppearance.BorderSize = 0;
            btnSubjects.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(48, 119, 84);
            btnSubjects.FlatStyle = FlatStyle.Flat;
            btnSubjects.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            btnSubjects.ForeColor = Color.FromArgb(225, 240, 232);
            btnSubjects.Location = new Point(0, 96);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Padding = new Padding(42, 0, 0, 0);
            btnSubjects.Size = new Size(245, 48);
            btnSubjects.TabIndex = 2;
            btnSubjects.Text = "Subjects";
            btnSubjects.TextAlign = ContentAlignment.MiddleLeft;
            btnSubjects.UseVisualStyleBackColor = false;
            btnSubjects.Click += btnSubjects_Click;

            btnSections.BackColor = Color.FromArgb(31, 96, 68);
            btnSections.Dock = DockStyle.Top;
            btnSections.FlatAppearance.BorderSize = 0;
            btnSections.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(48, 119, 84);
            btnSections.FlatStyle = FlatStyle.Flat;
            btnSections.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            btnSections.ForeColor = Color.FromArgb(225, 240, 232);
            btnSections.Location = new Point(0, 144);
            btnSections.Name = "btnSections";
            btnSections.Padding = new Padding(42, 0, 0, 0);
            btnSections.Size = new Size(245, 48);
            btnSections.TabIndex = 3;
            btnSections.Text = "Sections";
            btnSections.TextAlign = ContentAlignment.MiddleLeft;
            btnSections.UseVisualStyleBackColor = false;
            btnSections.Click += btnSections_Click;

            // =========================================================
            // ENROLLMENT
            // =========================================================

            btnEnrollment.BackColor = Color.FromArgb(24, 82, 58);
            btnEnrollment.Dock = DockStyle.Top;
            btnEnrollment.FlatAppearance.BorderSize = 0;
            btnEnrollment.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(42, 112, 80);
            btnEnrollment.FlatStyle = FlatStyle.Flat;
            btnEnrollment.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            btnEnrollment.ForeColor = Color.White;
            btnEnrollment.Location = new Point(0, 393);
            btnEnrollment.Name = "btnEnrollment";
            btnEnrollment.Padding = new Padding(20, 0, 0, 0);
            btnEnrollment.Size = new Size(245, 48);
            btnEnrollment.TabIndex = 4;
            btnEnrollment.Text = "  Enrollment";
            btnEnrollment.TextAlign = ContentAlignment.MiddleLeft;
            btnEnrollment.UseVisualStyleBackColor = false;
            btnEnrollment.Click += btnEnrollment_Click;

            // =========================================================
            // REPORTS
            // =========================================================

            btnReports.BackColor = Color.FromArgb(24, 82, 58);
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(42, 112, 80);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(0, 441);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(20, 0, 0, 0);
            btnReports.Size = new Size(245, 48);
            btnReports.TabIndex = 5;
            btnReports.Text = "  Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;

            // =========================================================
            // PENDING STUDENTS
            // =========================================================

            btnPendingStudents.BackColor = Color.FromArgb(24, 82, 58);
            btnPendingStudents.Dock = DockStyle.Top;
            btnPendingStudents.FlatAppearance.BorderSize = 0;
            btnPendingStudents.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(42, 112, 80);
            btnPendingStudents.FlatStyle = FlatStyle.Flat;
            btnPendingStudents.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            btnPendingStudents.ForeColor = Color.White;
            btnPendingStudents.Location = new Point(0, 489);
            btnPendingStudents.Name = "btnPendingStudents";
            btnPendingStudents.Padding = new Padding(20, 0, 0, 0);
            btnPendingStudents.Size = new Size(245, 48);
            btnPendingStudents.TabIndex = 6;
            btnPendingStudents.Text = "  Pending Students";
            btnPendingStudents.TextAlign = ContentAlignment.MiddleLeft;
            btnPendingStudents.UseVisualStyleBackColor = false;
            btnPendingStudents.Click += btnPendingStudents_Click;

            // =========================================================
            // LOGOUT
            // =========================================================

            btnLogout.BackColor = Color.FromArgb(19, 68, 48);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(150, 55, 55);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 672);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Size = new Size(245, 48);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "  Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;

            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnPendingStudents);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnEnrollment);
            pnlSidebar.Controls.Add(pnlAcademics);
            pnlSidebar.Controls.Add(btnStudents);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(pnlBrand);

            // =========================================================
            // MAIN CONTENT
            // =========================================================

            pnlContent.BackColor = Color.FromArgb(245, 247, 246);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(245, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(35);
            pnlContent.TabIndex = 1;

            // =========================================================
            // HEADER
            // =========================================================

            pnlHeader.BackColor = Color.Transparent;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(35, 35);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 125);
            pnlHeader.TabIndex = 0;

            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font(
                "Segoe UI",
                30F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblDashboardTitle.ForeColor = Color.FromArgb(35, 45, 40);
            lblDashboardTitle.Location = new Point(0, 0);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(230, 54);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Dashboard";

            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lblWelcome.ForeColor = Color.FromArgb(105, 115, 110);
            lblWelcome.Location = new Point(3, 65);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(280, 21);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome back, Administrator.";

            lblHeaderLine.BackColor = Color.FromArgb(42, 112, 80);
            lblHeaderLine.Location = new Point(0, 103);
            lblHeaderLine.Name = "lblHeaderLine";
            lblHeaderLine.Size = new Size(65, 5);
            lblHeaderLine.TabIndex = 2;

            pnlHeader.Controls.Add(lblHeaderLine);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblDashboardTitle);

            // =========================================================
            // STATISTICS CONTAINER
            // =========================================================

            pnlStats.BackColor = Color.Transparent;
            pnlStats.Dock = DockStyle.Fill;
            pnlStats.Location = new Point(35, 160);
            pnlStats.Name = "pnlStats";
            pnlStats.Padding = new Padding(10, 25, 10, 25);
            pnlStats.TabIndex = 1;

            // =========================================================
            // TOTAL STUDENTS CARD
            // =========================================================

            pnlStudentsCard.BackColor = Color.White;
            pnlStudentsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlStudentsCard.Controls.Add(lblStudentsSubtitle);
            pnlStudentsCard.Controls.Add(lblStudentsCount);
            pnlStudentsCard.Controls.Add(lblStudentsTitle);
            pnlStudentsCard.Location = new Point(10, 25);
            pnlStudentsCard.Name = "pnlStudentsCard";
            pnlStudentsCard.Size = new Size(185, 200);
            pnlStudentsCard.TabIndex = 0;

            lblStudentsTitle.AutoSize = true;
            lblStudentsTitle.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblStudentsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblStudentsTitle.Location = new Point(18, 20);
            lblStudentsTitle.Name = "lblStudentsTitle";
            lblStudentsTitle.Size = new Size(127, 19);
            lblStudentsTitle.TabIndex = 0;
            lblStudentsTitle.Text = "TOTAL STUDENTS";

            lblStudentsCount.AutoSize = true;
            lblStudentsCount.Font = new Font(
                "Segoe UI",
                40F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblStudentsCount.ForeColor = Color.FromArgb(24, 82, 58);
            lblStudentsCount.Location = new Point(18, 58);
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Size = new Size(63, 72);
            lblStudentsCount.TabIndex = 1;
            lblStudentsCount.Text = "0";

            lblStudentsSubtitle.AutoSize = true;
            lblStudentsSubtitle.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lblStudentsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblStudentsSubtitle.Location = new Point(20, 155);
            lblStudentsSubtitle.Name = "lblStudentsSubtitle";
            lblStudentsSubtitle.Size = new Size(125, 15);
            lblStudentsSubtitle.TabIndex = 2;
            lblStudentsSubtitle.Text = "Registered students";

            // =========================================================
            // ACTIVE STUDENTS CARD
            // =========================================================

            pnlActiveStudentsCard.BackColor = Color.White;
            pnlActiveStudentsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlActiveStudentsCard.Controls.Add(lblActiveStudentsSubtitle);
            pnlActiveStudentsCard.Controls.Add(lblActiveStudentsCount);
            pnlActiveStudentsCard.Controls.Add(lblActiveStudentsTitle);
            pnlActiveStudentsCard.Location = new Point(205, 25);
            pnlActiveStudentsCard.Name = "pnlActiveStudentsCard";
            pnlActiveStudentsCard.Size = new Size(185, 200);
            pnlActiveStudentsCard.TabIndex = 1;

            lblActiveStudentsTitle.AutoSize = true;
            lblActiveStudentsTitle.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblActiveStudentsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblActiveStudentsTitle.Location = new Point(18, 20);
            lblActiveStudentsTitle.Name = "lblActiveStudentsTitle";
            lblActiveStudentsTitle.Size = new Size(141, 19);
            lblActiveStudentsTitle.TabIndex = 0;
            lblActiveStudentsTitle.Text = "ACTIVE STUDENTS";

            lblActiveStudentsCount.AutoSize = true;
            lblActiveStudentsCount.Font = new Font(
                "Segoe UI",
                40F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblActiveStudentsCount.ForeColor = Color.FromArgb(42, 112, 80);
            lblActiveStudentsCount.Location = new Point(18, 58);
            lblActiveStudentsCount.Name = "lblActiveStudentsCount";
            lblActiveStudentsCount.Size = new Size(63, 72);
            lblActiveStudentsCount.TabIndex = 1;
            lblActiveStudentsCount.Text = "0";

            lblActiveStudentsSubtitle.AutoSize = true;
            lblActiveStudentsSubtitle.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lblActiveStudentsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblActiveStudentsSubtitle.Location = new Point(20, 155);
            lblActiveStudentsSubtitle.Name = "lblActiveStudentsSubtitle";
            lblActiveStudentsSubtitle.Size = new Size(105, 15);
            lblActiveStudentsSubtitle.TabIndex = 2;
            lblActiveStudentsSubtitle.Text = "Currently active";

            // =========================================================
            // SUBJECTS CARD
            // =========================================================

            pnlSubjectsCard.BackColor = Color.White;
            pnlSubjectsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSubjectsCard.Controls.Add(lblSubjectsSubtitle);
            pnlSubjectsCard.Controls.Add(lblSubjectsCount);
            pnlSubjectsCard.Controls.Add(lblSubjectsTitle);
            pnlSubjectsCard.Location = new Point(400, 25);
            pnlSubjectsCard.Name = "pnlSubjectsCard";
            pnlSubjectsCard.Size = new Size(185, 200);
            pnlSubjectsCard.TabIndex = 2;

            lblSubjectsTitle.AutoSize = true;
            lblSubjectsTitle.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblSubjectsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblSubjectsTitle.Location = new Point(18, 20);
            lblSubjectsTitle.Name = "lblSubjectsTitle";
            lblSubjectsTitle.Size = new Size(122, 19);
            lblSubjectsTitle.TabIndex = 0;
            lblSubjectsTitle.Text = "TOTAL SUBJECTS";

            lblSubjectsCount.AutoSize = true;
            lblSubjectsCount.Font = new Font(
                "Segoe UI",
                40F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblSubjectsCount.ForeColor = Color.FromArgb(53, 91, 125);
            lblSubjectsCount.Location = new Point(18, 58);
            lblSubjectsCount.Name = "lblSubjectsCount";
            lblSubjectsCount.Size = new Size(63, 72);
            lblSubjectsCount.TabIndex = 1;
            lblSubjectsCount.Text = "0";

            lblSubjectsSubtitle.AutoSize = true;
            lblSubjectsSubtitle.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lblSubjectsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblSubjectsSubtitle.Location = new Point(20, 155);
            lblSubjectsSubtitle.Name = "lblSubjectsSubtitle";
            lblSubjectsSubtitle.Size = new Size(114, 15);
            lblSubjectsSubtitle.TabIndex = 2;
            lblSubjectsSubtitle.Text = "Available subjects";

            // =========================================================
            // SECTIONS CARD
            // =========================================================

            pnlSectionsCard.BackColor = Color.White;
            pnlSectionsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSectionsCard.Controls.Add(lblSectionsSubtitle);
            pnlSectionsCard.Controls.Add(lblSectionsCount);
            pnlSectionsCard.Controls.Add(lblSectionsTitle);
            pnlSectionsCard.Location = new Point(595, 25);
            pnlSectionsCard.Name = "pnlSectionsCard";
            pnlSectionsCard.Size = new Size(185, 200);
            pnlSectionsCard.TabIndex = 3;

            lblSectionsTitle.AutoSize = true;
            lblSectionsTitle.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblSectionsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblSectionsTitle.Location = new Point(18, 20);
            lblSectionsTitle.Name = "lblSectionsTitle";
            lblSectionsTitle.Size = new Size(122, 19);
            lblSectionsTitle.TabIndex = 0;
            lblSectionsTitle.Text = "TOTAL SECTIONS";

            lblSectionsCount.AutoSize = true;
            lblSectionsCount.Font = new Font(
                "Segoe UI",
                40F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblSectionsCount.ForeColor = Color.FromArgb(117, 86, 40);
            lblSectionsCount.Location = new Point(18, 58);
            lblSectionsCount.Name = "lblSectionsCount";
            lblSectionsCount.Size = new Size(63, 72);
            lblSectionsCount.TabIndex = 1;
            lblSectionsCount.Text = "0";

            lblSectionsSubtitle.AutoSize = true;
            lblSectionsSubtitle.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lblSectionsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblSectionsSubtitle.Location = new Point(20, 155);
            lblSectionsSubtitle.Name = "lblSectionsSubtitle";
            lblSectionsSubtitle.Size = new Size(101, 15);
            lblSectionsSubtitle.TabIndex = 2;
            lblSectionsSubtitle.Text = "Active sections";

            // =========================================================
            // ENROLLMENT CARD
            // =========================================================

            pnlEnrollmentCard.BackColor = Color.White;
            pnlEnrollmentCard.BorderStyle = BorderStyle.FixedSingle;
            pnlEnrollmentCard.Controls.Add(lblEnrollmentSubtitle);
            pnlEnrollmentCard.Controls.Add(lblEnrollmentCount);
            pnlEnrollmentCard.Controls.Add(lblEnrollmentTitle);
            pnlEnrollmentCard.Location = new Point(790, 25);
            pnlEnrollmentCard.Name = "pnlEnrollmentCard";
            pnlEnrollmentCard.Size = new Size(185, 200);
            pnlEnrollmentCard.TabIndex = 4;

            lblEnrollmentTitle.AutoSize = true;
            lblEnrollmentTitle.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblEnrollmentTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblEnrollmentTitle.Location = new Point(18, 20);
            lblEnrollmentTitle.Name = "lblEnrollmentTitle";
            lblEnrollmentTitle.Size = new Size(159, 19);
            lblEnrollmentTitle.TabIndex = 0;
            lblEnrollmentTitle.Text = "TOTAL ENROLLMENTS";

            lblEnrollmentCount.AutoSize = true;
            lblEnrollmentCount.Font = new Font(
                "Segoe UI",
                40F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblEnrollmentCount.ForeColor = Color.FromArgb(145, 72, 72);
            lblEnrollmentCount.Location = new Point(18, 58);
            lblEnrollmentCount.Name = "lblEnrollmentCount";
            lblEnrollmentCount.Size = new Size(63, 72);
            lblEnrollmentCount.TabIndex = 1;
            lblEnrollmentCount.Text = "0";

            lblEnrollmentSubtitle.AutoSize = true;
            lblEnrollmentSubtitle.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lblEnrollmentSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblEnrollmentSubtitle.Location = new Point(20, 155);
            lblEnrollmentSubtitle.Name = "lblEnrollmentSubtitle";
            lblEnrollmentSubtitle.Size = new Size(139, 15);
            lblEnrollmentSubtitle.TabIndex = 2;
            lblEnrollmentSubtitle.Text = "Recorded enrollments";

            // =========================================================
            // ADD STATISTICS
            // =========================================================

            pnlStats.Controls.Add(pnlEnrollmentCard);
            pnlStats.Controls.Add(pnlSectionsCard);
            pnlStats.Controls.Add(pnlSubjectsCard);
            pnlStats.Controls.Add(pnlActiveStudentsCard);
            pnlStats.Controls.Add(pnlStudentsCard);

            // =========================================================
            // ADD CONTENT
            // =========================================================

            pnlContent.Controls.Add(pnlStats);
            pnlContent.Controls.Add(pnlHeader);

            // =========================================================
            // FORM
            // =========================================================

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;

            BackColor = Color.FromArgb(245, 247, 246);

            ClientSize = new Size(1280, 720);

            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);

            Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            MinimumSize = new Size(1100, 650);

            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SESRS - Dashboard";
            WindowState = FormWindowState.Maximized;

            Load += DashboardForm_Load;

            // =========================================================
            // RESUME LAYOUT
            // =========================================================

            pnlSidebar.ResumeLayout(false);
            pnlBrand.ResumeLayout(false);
            pnlAcademics.ResumeLayout(false);

            pnlContent.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlStats.ResumeLayout(false);

            pnlStudentsCard.ResumeLayout(false);
            pnlStudentsCard.PerformLayout();

            pnlActiveStudentsCard.ResumeLayout(false);
            pnlActiveStudentsCard.PerformLayout();

            pnlSubjectsCard.ResumeLayout(false);
            pnlSubjectsCard.PerformLayout();

            pnlSectionsCard.ResumeLayout(false);
            pnlSectionsCard.PerformLayout();

            pnlEnrollmentCard.ResumeLayout(false);
            pnlEnrollmentCard.PerformLayout();

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

        private Button btnEnrollment;
        private Button btnReports;
        private Button btnPendingStudents;
        private Button btnLogout;

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