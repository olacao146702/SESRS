namespace SESRS.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
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
            lblLogo = new Label();
            btnLogout = new Button();
            pnlContent = new Panel();
            pnlSectionsCard = new Panel();
            lblSectionsCount = new Label();
            lblSectionsTitle = new Label();
            pnlEnrollmentCard = new Panel();
            lblEnrollmentCount = new Label();
            lblEnrollmentTitle = new Label();
            pnlSubjectsCard = new Panel();
            lblSubjectsCount = new Label();
            lblSubjectsTitle = new Label();
            pnlStudentsCard = new Panel();
            pnlActiveStudentsCard = new Panel();
            lblActiveStudentsCount = new Label();
            lblActiveStudentsTitle = new Label();
            lblStudentsCount = new Label();
            lblStudentsTitle = new Label();
            lblWelcome = new Label();
            lblDashboardTitle = new Label();
            pnlSidebar.SuspendLayout();
            pnlAcademics.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlSectionsCard.SuspendLayout();
            pnlEnrollmentCard.SuspendLayout();
            pnlSubjectsCard.SuspendLayout();
            pnlStudentsCard.SuspendLayout();
            pnlActiveStudentsCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.DarkGreen;
            pnlSidebar.Controls.Add(btnPendingStudents);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnEnrollment);
            pnlSidebar.Controls.Add(pnlAcademics);
            pnlSidebar.Controls.Add(btnStudents);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 644);
            pnlSidebar.TabIndex = 0;
            // 
            // btnPendingStudents
            // 
            btnPendingStudents.Dock = DockStyle.Top;
            btnPendingStudents.Location = new Point(0, 420);
            btnPendingStudents.Name = "btnPendingStudents";
            btnPendingStudents.Size = new Size(220, 45);
            btnPendingStudents.TabIndex = 7;
            btnPendingStudents.Text = "PENDING STUDENTS";
            btnPendingStudents.UseVisualStyleBackColor = true;
            btnPendingStudents.Click += btnPendingStudents_Click;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.Location = new Point(0, 375);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(220, 45);
            btnReports.TabIndex = 6;
            btnReports.Text = "REPORTS";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnEnrollment
            // 
            btnEnrollment.Dock = DockStyle.Top;
            btnEnrollment.Location = new Point(0, 330);
            btnEnrollment.Name = "btnEnrollment";
            btnEnrollment.Size = new Size(220, 45);
            btnEnrollment.TabIndex = 5;
            btnEnrollment.Text = "ENROLLMENT";
            btnEnrollment.UseVisualStyleBackColor = true;
            btnEnrollment.Click += btnEnrollment_Click;
            // 
            // pnlAcademics
            // 
            pnlAcademics.AutoSize = true;
            pnlAcademics.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlAcademics.Controls.Add(btnSections);
            pnlAcademics.Controls.Add(btnSubjects);
            pnlAcademics.Controls.Add(btnPrograms);
            pnlAcademics.Controls.Add(btnAcademics);
            pnlAcademics.Dock = DockStyle.Top;
            pnlAcademics.Location = new Point(0, 150);
            pnlAcademics.Name = "pnlAcademics";
            pnlAcademics.Size = new Size(220, 180);
            pnlAcademics.TabIndex = 10;
            // 
            // btnSections
            // 
            btnSections.Dock = DockStyle.Top;
            btnSections.Location = new Point(0, 135);
            btnSections.Name = "btnSections";
            btnSections.Size = new Size(220, 45);
            btnSections.TabIndex = 4;
            btnSections.Text = "SECTIONS";
            btnSections.UseVisualStyleBackColor = true;
            btnSections.Click += btnSections_Click;
            // 
            // btnSubjects
            // 
            btnSubjects.Dock = DockStyle.Top;
            btnSubjects.Location = new Point(0, 90);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Size = new Size(220, 45);
            btnSubjects.TabIndex = 3;
            btnSubjects.Text = "SUBJECTS";
            btnSubjects.UseVisualStyleBackColor = true;
            btnSubjects.Click += btnSubjects_Click;
            // 
            // btnPrograms
            // 
            btnPrograms.Dock = DockStyle.Top;
            btnPrograms.Location = new Point(0, 45);
            btnPrograms.Name = "btnPrograms";
            btnPrograms.Size = new Size(220, 45);
            btnPrograms.TabIndex = 8;
            btnPrograms.Text = "PROGRAMS";
            btnPrograms.UseVisualStyleBackColor = true;
            btnPrograms.Click += btnPrograms_Click;
            // 
            // btnAcademics
            // 
            btnAcademics.Dock = DockStyle.Top;
            btnAcademics.Location = new Point(0, 0);
            btnAcademics.Name = "btnAcademics";
            btnAcademics.Size = new Size(220, 45);
            btnAcademics.TabIndex = 9;
            btnAcademics.Text = "ACADEMICS ▼";
            btnAcademics.UseVisualStyleBackColor = true;
            btnAcademics.Click += btnAcademics_Click;
            // 
            // btnStudents
            // 
            btnStudents.Dock = DockStyle.Top;
            btnStudents.Location = new Point(0, 105);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(220, 45);
            btnStudents.TabIndex = 2;
            btnStudents.Text = "STUDENTS";
            btnStudents.UseVisualStyleBackColor = true;
            btnStudents.Click += btnStudents_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.Location = new Point(0, 60);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(220, 45);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "DASHBOARD";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(152, 60);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "SESRS";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Location = new Point(0, 599);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 45);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Controls.Add(pnlSectionsCard);
            pnlContent.Controls.Add(pnlEnrollmentCard);
            pnlContent.Controls.Add(pnlSubjectsCard);
            pnlContent.Controls.Add(pnlStudentsCard);
            pnlContent.Controls.Add(lblWelcome);
            pnlContent.Controls.Add(lblDashboardTitle);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(958, 644);
            pnlContent.TabIndex = 1;
            // 
            // pnlSectionsCard
            // 
            pnlSectionsCard.BackColor = Color.White;
            pnlSectionsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSectionsCard.Controls.Add(lblSectionsCount);
            pnlSectionsCard.Controls.Add(lblSectionsTitle);
            pnlSectionsCard.Location = new Point(337, 385);
            pnlSectionsCard.Name = "pnlSectionsCard";
            pnlSectionsCard.Size = new Size(250, 130);
            pnlSectionsCard.TabIndex = 5;
            // 
            // lblSectionsCount
            // 
            lblSectionsCount.AutoSize = true;
            lblSectionsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSectionsCount.Location = new Point(95, 50);
            lblSectionsCount.Name = "lblSectionsCount";
            lblSectionsCount.Size = new Size(56, 65);
            lblSectionsCount.TabIndex = 1;
            lblSectionsCount.Text = "0";
            // 
            // lblSectionsTitle
            // 
            lblSectionsTitle.AutoSize = true;
            lblSectionsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSectionsTitle.Location = new Point(33, 20);
            lblSectionsTitle.Name = "lblSectionsTitle";
            lblSectionsTitle.Size = new Size(172, 28);
            lblSectionsTitle.TabIndex = 0;
            lblSectionsTitle.Text = "TOTAL SECTIONS";
            // 
            // pnlEnrollmentCard
            // 
            pnlEnrollmentCard.BackColor = Color.White;
            pnlEnrollmentCard.BorderStyle = BorderStyle.FixedSingle;
            pnlEnrollmentCard.Controls.Add(lblEnrollmentCount);
            pnlEnrollmentCard.Controls.Add(lblEnrollmentTitle);
            pnlEnrollmentCard.Location = new Point(45, 385);
            pnlEnrollmentCard.Name = "pnlEnrollmentCard";
            pnlEnrollmentCard.Size = new Size(250, 130);
            pnlEnrollmentCard.TabIndex = 4;
            // 
            // lblEnrollmentCount
            // 
            lblEnrollmentCount.AutoSize = true;
            lblEnrollmentCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnrollmentCount.Location = new Point(95, 50);
            lblEnrollmentCount.Name = "lblEnrollmentCount";
            lblEnrollmentCount.Size = new Size(56, 65);
            lblEnrollmentCount.TabIndex = 1;
            lblEnrollmentCount.Text = "0";
            // 
            // lblEnrollmentTitle
            // 
            lblEnrollmentTitle.AutoSize = true;
            lblEnrollmentTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnrollmentTitle.Location = new Point(13, 20);
            lblEnrollmentTitle.Name = "lblEnrollmentTitle";
            lblEnrollmentTitle.Size = new Size(222, 28);
            lblEnrollmentTitle.TabIndex = 0;
            lblEnrollmentTitle.Text = "TOTAL ENROLLMENTS";
            // 
            // pnlSubjectsCard
            // 
            pnlSubjectsCard.BackColor = Color.White;
            pnlSubjectsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSubjectsCard.Controls.Add(lblSubjectsCount);
            pnlSubjectsCard.Controls.Add(lblSubjectsTitle);
            pnlSubjectsCard.Location = new Point(337, 135);
            pnlSubjectsCard.Name = "pnlSubjectsCard";
            pnlSubjectsCard.Size = new Size(250, 220);
            pnlSubjectsCard.TabIndex = 3;
            // 
            // lblSubjectsCount
            // 
            lblSubjectsCount.AutoSize = true;
            lblSubjectsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubjectsCount.Location = new Point(95, 75);
            lblSubjectsCount.Name = "lblSubjectsCount";
            lblSubjectsCount.Size = new Size(56, 65);
            lblSubjectsCount.TabIndex = 1;
            lblSubjectsCount.Text = "0";
            // 
            // lblSubjectsTitle
            // 
            lblSubjectsTitle.AutoSize = true;
            lblSubjectsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubjectsTitle.Location = new Point(33, 25);
            lblSubjectsTitle.Name = "lblSubjectsTitle";
            lblSubjectsTitle.Size = new Size(171, 28);
            lblSubjectsTitle.TabIndex = 0;
            lblSubjectsTitle.Text = "TOTAL SUBJECTS";
            // 
            // pnlStudentsCard
            // 
            pnlStudentsCard.BackColor = Color.White;
            pnlStudentsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlStudentsCard.Controls.Add(pnlActiveStudentsCard);
            pnlStudentsCard.Controls.Add(lblStudentsCount);
            pnlStudentsCard.Controls.Add(lblStudentsTitle);
            pnlStudentsCard.Location = new Point(45, 135);
            pnlStudentsCard.Name = "pnlStudentsCard";
            pnlStudentsCard.Size = new Size(250, 220);
            pnlStudentsCard.TabIndex = 2;
            // 
            // pnlActiveStudentsCard
            // 
            pnlActiveStudentsCard.BackColor = Color.WhiteSmoke;
            pnlActiveStudentsCard.Controls.Add(lblActiveStudentsCount);
            pnlActiveStudentsCard.Controls.Add(lblActiveStudentsTitle);
            pnlActiveStudentsCard.Location = new Point(1, 120);
            pnlActiveStudentsCard.Name = "pnlActiveStudentsCard";
            pnlActiveStudentsCard.Size = new Size(246, 98);
            pnlActiveStudentsCard.TabIndex = 6;
            // 
            // lblActiveStudentsCount
            // 
            lblActiveStudentsCount.AutoSize = true;
            lblActiveStudentsCount.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveStudentsCount.Location = new Point(105, 45);
            lblActiveStudentsCount.Name = "lblActiveStudentsCount";
            lblActiveStudentsCount.Size = new Size(38, 45);
            lblActiveStudentsCount.TabIndex = 1;
            lblActiveStudentsCount.Text = "0";
            // 
            // lblActiveStudentsTitle
            // 
            lblActiveStudentsTitle.AutoSize = true;
            lblActiveStudentsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveStudentsTitle.Location = new Point(15, 15);
            lblActiveStudentsTitle.Name = "lblActiveStudentsTitle";
            lblActiveStudentsTitle.Size = new Size(172, 25);
            lblActiveStudentsTitle.TabIndex = 0;
            lblActiveStudentsTitle.Text = "ACTIVE STUDENTS";
            // 
            // lblStudentsCount
            // 
            lblStudentsCount.AutoSize = true;
            lblStudentsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentsCount.Location = new Point(95, 45);
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Size = new Size(56, 65);
            lblStudentsCount.TabIndex = 1;
            lblStudentsCount.Text = "0";
            // 
            // lblStudentsTitle
            // 
            lblStudentsTitle.AutoSize = true;
            lblStudentsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentsTitle.Location = new Point(33, 15);
            lblStudentsTitle.Name = "lblStudentsTitle";
            lblStudentsTitle.Size = new Size(180, 28);
            lblStudentsTitle.TabIndex = 0;
            lblStudentsTitle.Text = "TOTAL STUDENTS";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 11F);
            lblWelcome.Location = new Point(45, 90);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(196, 30);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome to SESRS";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardTitle.Location = new Point(30, 25);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(273, 65);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Dashboard";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 644);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SESRS - Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += DashboardForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            pnlAcademics.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlSectionsCard.ResumeLayout(false);
            pnlSectionsCard.PerformLayout();
            pnlEnrollmentCard.ResumeLayout(false);
            pnlEnrollmentCard.PerformLayout();
            pnlSubjectsCard.ResumeLayout(false);
            pnlSubjectsCard.PerformLayout();
            pnlStudentsCard.ResumeLayout(false);
            pnlStudentsCard.PerformLayout();
            pnlActiveStudentsCard.ResumeLayout(false);
            pnlActiveStudentsCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlAcademics;
        private Button btnAcademics;
        private Button btnPrograms;
        private Button btnDashboard;
        private Button btnStudents;
        private Button btnSubjects;
        private Button btnSections;
        private Button btnEnrollment;
        private Button btnReports;
        private Button btnPendingStudents;
        private Button btnLogout;
        private Label lblLogo;

        private Panel pnlContent;
        private Label lblDashboardTitle;
        private Label lblWelcome;

        private Panel pnlStudentsCard;
        private Label lblStudentsTitle;
        private Label lblStudentsCount;

        private Panel pnlSubjectsCard;
        private Label lblSubjectsTitle;
        private Label lblSubjectsCount;

        private Panel pnlActiveStudentsCard;
        private Label lblActiveStudentsTitle;
        private Label lblActiveStudentsCount;

        private Panel pnlSectionsCard;
        private Label lblSectionsTitle;
        private Label lblSectionsCount;

        private Panel pnlEnrollmentCard;
        private Label lblEnrollmentTitle;
        private Label lblEnrollmentCount;
    }
}