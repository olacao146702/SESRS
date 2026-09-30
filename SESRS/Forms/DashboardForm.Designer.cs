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
            btnPendingStudents = new Button();
            btnReports = new Button();
            btnEnrollment = new Button();
            pnlAcademics = new Panel();
            btnSections = new Button();
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
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnPendingStudents);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnEnrollment);
            pnlSidebar.Controls.Add(pnlAcademics);
            pnlSidebar.Controls.Add(btnStudents);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(pnlBrand);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(2, 2, 2, 2);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(196, 576);
            pnlSidebar.TabIndex = 0;
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
            btnLogout.Location = new Point(0, 538);
            btnLogout.Margin = new Padding(2, 2, 2, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(16, 0, 0, 0);
            btnLogout.Size = new Size(196, 38);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "  Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnPendingStudents
            // 
            btnPendingStudents.BackColor = Color.FromArgb(24, 82, 58);
            btnPendingStudents.Dock = DockStyle.Top;
            btnPendingStudents.FlatAppearance.BorderSize = 0;
            btnPendingStudents.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 112, 80);
            btnPendingStudents.FlatStyle = FlatStyle.Flat;
            btnPendingStudents.Font = new Font("Segoe UI", 10F);
            btnPendingStudents.ForeColor = Color.White;
            btnPendingStudents.Location = new Point(0, 390);
            btnPendingStudents.Margin = new Padding(2, 2, 2, 2);
            btnPendingStudents.Name = "btnPendingStudents";
            btnPendingStudents.Padding = new Padding(16, 0, 0, 0);
            btnPendingStudents.Size = new Size(196, 38);
            btnPendingStudents.TabIndex = 6;
            btnPendingStudents.Text = "  Pending Students";
            btnPendingStudents.TextAlign = ContentAlignment.MiddleLeft;
            btnPendingStudents.UseVisualStyleBackColor = false;
            btnPendingStudents.Click += btnPendingStudents_Click;
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
            btnReports.Location = new Point(0, 352);
            btnReports.Margin = new Padding(2, 2, 2, 2);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(16, 0, 0, 0);
            btnReports.Size = new Size(196, 38);
            btnReports.TabIndex = 5;
            btnReports.Text = "  Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
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
            btnEnrollment.Location = new Point(0, 314);
            btnEnrollment.Margin = new Padding(2, 2, 2, 2);
            btnEnrollment.Name = "btnEnrollment";
            btnEnrollment.Padding = new Padding(16, 0, 0, 0);
            btnEnrollment.Size = new Size(196, 38);
            btnEnrollment.TabIndex = 4;
            btnEnrollment.Text = "  Enrollment";
            btnEnrollment.TextAlign = ContentAlignment.MiddleLeft;
            btnEnrollment.UseVisualStyleBackColor = false;
            btnEnrollment.Click += btnEnrollment_Click;
            // 
            // pnlAcademics
            // 
            pnlAcademics.BackColor = Color.FromArgb(24, 82, 58);
            pnlAcademics.Controls.Add(btnSections);
            pnlAcademics.Controls.Add(btnSubjects);
            pnlAcademics.Controls.Add(btnPrograms);
            pnlAcademics.Controls.Add(btnAcademics);
            pnlAcademics.Dock = DockStyle.Top;
            pnlAcademics.Location = new Point(0, 160);
            pnlAcademics.Margin = new Padding(2, 2, 2, 2);
            pnlAcademics.Name = "pnlAcademics";
            pnlAcademics.Size = new Size(196, 154);
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
            btnSections.Location = new Point(0, 114);
            btnSections.Margin = new Padding(2, 2, 2, 2);
            btnSections.Name = "btnSections";
            btnSections.Padding = new Padding(34, 0, 0, 0);
            btnSections.Size = new Size(196, 38);
            btnSections.TabIndex = 3;
            btnSections.Text = "Sections";
            btnSections.TextAlign = ContentAlignment.MiddleLeft;
            btnSections.UseVisualStyleBackColor = false;
            btnSections.Click += btnSections_Click;
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
            btnSubjects.Location = new Point(0, 76);
            btnSubjects.Margin = new Padding(2, 2, 2, 2);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Padding = new Padding(34, 0, 0, 0);
            btnSubjects.Size = new Size(196, 38);
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
            btnPrograms.Location = new Point(0, 38);
            btnPrograms.Margin = new Padding(2, 2, 2, 2);
            btnPrograms.Name = "btnPrograms";
            btnPrograms.Padding = new Padding(34, 0, 0, 0);
            btnPrograms.Size = new Size(196, 38);
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
            btnAcademics.Margin = new Padding(2, 2, 2, 2);
            btnAcademics.Name = "btnAcademics";
            btnAcademics.Padding = new Padding(16, 0, 0, 0);
            btnAcademics.Size = new Size(196, 38);
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
            btnStudents.Location = new Point(0, 122);
            btnStudents.Margin = new Padding(2, 2, 2, 2);
            btnStudents.Name = "btnStudents";
            btnStudents.Padding = new Padding(16, 0, 0, 0);
            btnStudents.Size = new Size(196, 38);
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
            btnDashboard.Location = new Point(0, 84);
            btnDashboard.Margin = new Padding(2, 2, 2, 2);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(16, 0, 0, 0);
            btnDashboard.Size = new Size(196, 38);
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
            pnlBrand.Margin = new Padding(2, 2, 2, 2);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(196, 84);
            pnlBrand.TabIndex = 0;
            // 
            // lblSystemName
            // 
            lblSystemName.Dock = DockStyle.Bottom;
            lblSystemName.Font = new Font("Segoe UI", 8.5F);
            lblSystemName.ForeColor = Color.FromArgb(210, 230, 220);
            lblSystemName.Location = new Point(0, 50);
            lblSystemName.Margin = new Padding(2, 0, 2, 0);
            lblSystemName.Name = "lblSystemName";
            lblSystemName.Size = new Size(196, 34);
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
            lblLogo.Size = new Size(196, 40);
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
            pnlContent.Location = new Point(196, 0);
            pnlContent.Margin = new Padding(2, 2, 2, 2);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(28, 28, 28, 28);
            pnlContent.Size = new Size(1156, 576);
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
            pnlStats.Location = new Point(28, 128);
            pnlStats.Margin = new Padding(2, 2, 2, 2);
            pnlStats.Name = "pnlStats";
            pnlStats.Padding = new Padding(8, 20, 8, 20);
            pnlStats.Size = new Size(1100, 420);
            pnlStats.TabIndex = 1;
            // 
            // pnlEnrollmentCard
            // 
            pnlEnrollmentCard.BackColor = Color.White;
            pnlEnrollmentCard.BorderStyle = BorderStyle.FixedSingle;
            pnlEnrollmentCard.Controls.Add(lblEnrollmentSubtitle);
            pnlEnrollmentCard.Controls.Add(lblEnrollmentCount);
            pnlEnrollmentCard.Controls.Add(lblEnrollmentTitle);
            pnlEnrollmentCard.Location = new Point(824, 20);
            pnlEnrollmentCard.Margin = new Padding(2, 2, 2, 2);
            pnlEnrollmentCard.Name = "pnlEnrollmentCard";
            pnlEnrollmentCard.Size = new Size(205, 160);
            pnlEnrollmentCard.TabIndex = 4;
            // 
            // lblEnrollmentSubtitle
            // 
            lblEnrollmentSubtitle.AutoSize = true;
            lblEnrollmentSubtitle.Font = new Font("Segoe UI", 9F);
            lblEnrollmentSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblEnrollmentSubtitle.Location = new Point(16, 124);
            lblEnrollmentSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblEnrollmentSubtitle.Name = "lblEnrollmentSubtitle";
            lblEnrollmentSubtitle.Size = new Size(155, 20);
            lblEnrollmentSubtitle.TabIndex = 2;
            lblEnrollmentSubtitle.Text = "Recorded enrollments";
            // 
            // lblEnrollmentCount
            // 
            lblEnrollmentCount.AutoSize = true;
            lblEnrollmentCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblEnrollmentCount.ForeColor = Color.FromArgb(145, 72, 72);
            lblEnrollmentCount.Location = new Point(14, 46);
            lblEnrollmentCount.Margin = new Padding(2, 0, 2, 0);
            lblEnrollmentCount.Name = "lblEnrollmentCount";
            lblEnrollmentCount.Size = new Size(77, 89);
            lblEnrollmentCount.TabIndex = 1;
            lblEnrollmentCount.Text = "0";
            // 
            // lblEnrollmentTitle
            // 
            lblEnrollmentTitle.AutoSize = true;
            lblEnrollmentTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEnrollmentTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblEnrollmentTitle.Location = new Point(14, 16);
            lblEnrollmentTitle.Margin = new Padding(2, 0, 2, 0);
            lblEnrollmentTitle.Name = "lblEnrollmentTitle";
            lblEnrollmentTitle.Size = new Size(188, 23);
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
            pnlSectionsCard.Location = new Point(620, 20);
            pnlSectionsCard.Margin = new Padding(2, 2, 2, 2);
            pnlSectionsCard.Name = "pnlSectionsCard";
            pnlSectionsCard.Size = new Size(200, 160);
            pnlSectionsCard.TabIndex = 3;
            // 
            // lblSectionsSubtitle
            // 
            lblSectionsSubtitle.AutoSize = true;
            lblSectionsSubtitle.Font = new Font("Segoe UI", 9F);
            lblSectionsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblSectionsSubtitle.Location = new Point(16, 124);
            lblSectionsSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSectionsSubtitle.Name = "lblSectionsSubtitle";
            lblSectionsSubtitle.Size = new Size(107, 20);
            lblSectionsSubtitle.TabIndex = 2;
            lblSectionsSubtitle.Text = "Active sections";
            // 
            // lblSectionsCount
            // 
            lblSectionsCount.AutoSize = true;
            lblSectionsCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblSectionsCount.ForeColor = Color.FromArgb(117, 86, 40);
            lblSectionsCount.Location = new Point(14, 46);
            lblSectionsCount.Margin = new Padding(2, 0, 2, 0);
            lblSectionsCount.Name = "lblSectionsCount";
            lblSectionsCount.Size = new Size(77, 89);
            lblSectionsCount.TabIndex = 1;
            lblSectionsCount.Text = "0";
            // 
            // lblSectionsTitle
            // 
            lblSectionsTitle.AutoSize = true;
            lblSectionsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSectionsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblSectionsTitle.Location = new Point(14, 16);
            lblSectionsTitle.Margin = new Padding(2, 0, 2, 0);
            lblSectionsTitle.Name = "lblSectionsTitle";
            lblSectionsTitle.Size = new Size(147, 23);
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
            pnlSubjectsCard.Location = new Point(416, 20);
            pnlSubjectsCard.Margin = new Padding(2, 2, 2, 2);
            pnlSubjectsCard.Name = "pnlSubjectsCard";
            pnlSubjectsCard.Size = new Size(200, 160);
            pnlSubjectsCard.TabIndex = 2;
            // 
            // lblSubjectsSubtitle
            // 
            lblSubjectsSubtitle.AutoSize = true;
            lblSubjectsSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubjectsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblSubjectsSubtitle.Location = new Point(16, 124);
            lblSubjectsSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSubjectsSubtitle.Name = "lblSubjectsSubtitle";
            lblSubjectsSubtitle.Size = new Size(128, 20);
            lblSubjectsSubtitle.TabIndex = 2;
            lblSubjectsSubtitle.Text = "Available subjects";
            // 
            // lblSubjectsCount
            // 
            lblSubjectsCount.AutoSize = true;
            lblSubjectsCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblSubjectsCount.ForeColor = Color.FromArgb(53, 91, 125);
            lblSubjectsCount.Location = new Point(14, 46);
            lblSubjectsCount.Margin = new Padding(2, 0, 2, 0);
            lblSubjectsCount.Name = "lblSubjectsCount";
            lblSubjectsCount.Size = new Size(77, 89);
            lblSubjectsCount.TabIndex = 1;
            lblSubjectsCount.Text = "0";
            // 
            // lblSubjectsTitle
            // 
            lblSubjectsTitle.AutoSize = true;
            lblSubjectsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubjectsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblSubjectsTitle.Location = new Point(14, 16);
            lblSubjectsTitle.Margin = new Padding(2, 0, 2, 0);
            lblSubjectsTitle.Name = "lblSubjectsTitle";
            lblSubjectsTitle.Size = new Size(147, 23);
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
            pnlActiveStudentsCard.Location = new Point(212, 20);
            pnlActiveStudentsCard.Margin = new Padding(2, 2, 2, 2);
            pnlActiveStudentsCard.Name = "pnlActiveStudentsCard";
            pnlActiveStudentsCard.Size = new Size(200, 160);
            pnlActiveStudentsCard.TabIndex = 1;
            // 
            // lblActiveStudentsSubtitle
            // 
            lblActiveStudentsSubtitle.AutoSize = true;
            lblActiveStudentsSubtitle.Font = new Font("Segoe UI", 9F);
            lblActiveStudentsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblActiveStudentsSubtitle.Location = new Point(16, 124);
            lblActiveStudentsSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblActiveStudentsSubtitle.Name = "lblActiveStudentsSubtitle";
            lblActiveStudentsSubtitle.Size = new Size(111, 20);
            lblActiveStudentsSubtitle.TabIndex = 2;
            lblActiveStudentsSubtitle.Text = "Currently active";
            // 
            // lblActiveStudentsCount
            // 
            lblActiveStudentsCount.AutoSize = true;
            lblActiveStudentsCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblActiveStudentsCount.ForeColor = Color.FromArgb(42, 112, 80);
            lblActiveStudentsCount.Location = new Point(14, 46);
            lblActiveStudentsCount.Margin = new Padding(2, 0, 2, 0);
            lblActiveStudentsCount.Name = "lblActiveStudentsCount";
            lblActiveStudentsCount.Size = new Size(77, 89);
            lblActiveStudentsCount.TabIndex = 1;
            lblActiveStudentsCount.Text = "0";
            // 
            // lblActiveStudentsTitle
            // 
            lblActiveStudentsTitle.AutoSize = true;
            lblActiveStudentsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblActiveStudentsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblActiveStudentsTitle.Location = new Point(14, 16);
            lblActiveStudentsTitle.Margin = new Padding(2, 0, 2, 0);
            lblActiveStudentsTitle.Name = "lblActiveStudentsTitle";
            lblActiveStudentsTitle.Size = new Size(160, 23);
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
            pnlStudentsCard.Location = new Point(8, 20);
            pnlStudentsCard.Margin = new Padding(2, 2, 2, 2);
            pnlStudentsCard.Name = "pnlStudentsCard";
            pnlStudentsCard.Size = new Size(200, 160);
            pnlStudentsCard.TabIndex = 0;
            // 
            // lblStudentsSubtitle
            // 
            lblStudentsSubtitle.AutoSize = true;
            lblStudentsSubtitle.Font = new Font("Segoe UI", 9F);
            lblStudentsSubtitle.ForeColor = Color.FromArgb(125, 135, 130);
            lblStudentsSubtitle.Location = new Point(16, 124);
            lblStudentsSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblStudentsSubtitle.Name = "lblStudentsSubtitle";
            lblStudentsSubtitle.Size = new Size(139, 20);
            lblStudentsSubtitle.TabIndex = 2;
            lblStudentsSubtitle.Text = "Registered students";
            // 
            // lblStudentsCount
            // 
            lblStudentsCount.AutoSize = true;
            lblStudentsCount.Font = new Font("Segoe UI", 40F, FontStyle.Bold);
            lblStudentsCount.ForeColor = Color.FromArgb(24, 82, 58);
            lblStudentsCount.Location = new Point(14, 46);
            lblStudentsCount.Margin = new Padding(2, 0, 2, 0);
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Size = new Size(77, 89);
            lblStudentsCount.TabIndex = 1;
            lblStudentsCount.Text = "0";
            // 
            // lblStudentsTitle
            // 
            lblStudentsTitle.AutoSize = true;
            lblStudentsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStudentsTitle.ForeColor = Color.FromArgb(90, 100, 95);
            lblStudentsTitle.Location = new Point(14, 16);
            lblStudentsTitle.Margin = new Padding(2, 0, 2, 0);
            lblStudentsTitle.Name = "lblStudentsTitle";
            lblStudentsTitle.Size = new Size(153, 23);
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
            pnlHeader.Location = new Point(28, 28);
            pnlHeader.Margin = new Padding(2, 2, 2, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderLine
            // 
            lblHeaderLine.BackColor = Color.FromArgb(42, 112, 80);
            lblHeaderLine.Location = new Point(0, 82);
            lblHeaderLine.Margin = new Padding(2, 2, 2, 2);
            lblHeaderLine.Name = "lblHeaderLine";
            lblHeaderLine.Size = new Size(52, 4);
            lblHeaderLine.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 12F);
            lblWelcome.ForeColor = Color.FromArgb(105, 115, 110);
            lblWelcome.Location = new Point(56, 66);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(273, 28);
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
            lblDashboardTitle.Size = new Size(278, 66);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Dashboard";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 246);
            ClientSize = new Size(1352, 576);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(2, 2, 2, 2);
            MinimumSize = new Size(884, 529);
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