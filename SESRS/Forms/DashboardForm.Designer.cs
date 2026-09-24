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
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            btnLogout = new Button();
            btnReports = new Button();
            btnEnrollment = new Button();
            btnSections = new Button();
            btnSubjects = new Button();
            btnStudents = new Button();
            btnDashboard = new Button();
            lblLogo = new Label();
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
            lblStudentsCount = new Label();
            lblStudentsTitle = new Label();
            lblWelcome = new Label();
            lblDashboardTitle = new Label();
            pnlSidebar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlSectionsCard.SuspendLayout();
            pnlEnrollmentCard.SuspendLayout();
            pnlSubjectsCard.SuspendLayout();
            pnlStudentsCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.DarkGreen;
            pnlSidebar.Controls.Add(btnPendingStudents);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnEnrollment);
            pnlSidebar.Controls.Add(btnSections);
            pnlSidebar.Controls.Add(btnSubjects);
            pnlSidebar.Controls.Add(btnStudents);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(2);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(176, 515);
            pnlSidebar.TabIndex = 0;
            // 
            // btnPendingStudents
            // 
            btnPendingStudents.Dock = DockStyle.Top;
            btnPendingStudents.FlatStyle = FlatStyle.Flat;
            btnPendingStudents.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPendingStudents.ForeColor = Color.White;
            btnPendingStudents.Location = new Point(0, 320);
            btnPendingStudents.Margin = new Padding(2);
            btnPendingStudents.Name = "btnPendingStudents";
            btnPendingStudents.Size = new Size(176, 45);
            btnPendingStudents.TabIndex = 7;
            btnPendingStudents.Text = "Pending Students";
            btnPendingStudents.TextAlign = ContentAlignment.MiddleLeft;
            btnPendingStudents.UseVisualStyleBackColor = true;
            btnPendingStudents.Click += btnPendingStudents_Click;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 470);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(176, 45);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(0, 275);
            btnReports.Margin = new Padding(2);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(176, 45);
            btnReports.TabIndex = 6;
            btnReports.Text = "Reports";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnEnrollment
            // 
            btnEnrollment.Dock = DockStyle.Top;
            btnEnrollment.FlatStyle = FlatStyle.Flat;
            btnEnrollment.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnrollment.ForeColor = Color.White;
            btnEnrollment.Location = new Point(0, 230);
            btnEnrollment.Margin = new Padding(2);
            btnEnrollment.Name = "btnEnrollment";
            btnEnrollment.Size = new Size(176, 45);
            btnEnrollment.TabIndex = 5;
            btnEnrollment.Text = "Enrollment";
            btnEnrollment.TextAlign = ContentAlignment.MiddleLeft;
            btnEnrollment.UseVisualStyleBackColor = true;
            btnEnrollment.Click += btnEnrollment_Click;
            // 
            // btnSections
            // 
            btnSections.Dock = DockStyle.Top;
            btnSections.FlatStyle = FlatStyle.Flat;
            btnSections.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSections.ForeColor = Color.White;
            btnSections.Location = new Point(0, 185);
            btnSections.Margin = new Padding(2);
            btnSections.Name = "btnSections";
            btnSections.Size = new Size(176, 45);
            btnSections.TabIndex = 4;
            btnSections.Text = "Sections";
            btnSections.TextAlign = ContentAlignment.MiddleLeft;
            btnSections.UseVisualStyleBackColor = true;
            btnSections.Click += btnSections_Click;
            // 
            // btnSubjects
            // 
            btnSubjects.Dock = DockStyle.Top;
            btnSubjects.FlatStyle = FlatStyle.Flat;
            btnSubjects.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubjects.ForeColor = Color.White;
            btnSubjects.ImageAlign = ContentAlignment.MiddleLeft;
            btnSubjects.Location = new Point(0, 140);
            btnSubjects.Margin = new Padding(2);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Size = new Size(176, 45);
            btnSubjects.TabIndex = 3;
            btnSubjects.Text = "Subjects";
            btnSubjects.TextAlign = ContentAlignment.MiddleLeft;
            btnSubjects.UseVisualStyleBackColor = true;
            btnSubjects.Click += btnSubjects_Click;
            // 
            // btnStudents
            // 
            btnStudents.Dock = DockStyle.Top;
            btnStudents.FlatStyle = FlatStyle.Flat;
            btnStudents.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStudents.ForeColor = Color.White;
            btnStudents.Location = new Point(0, 95);
            btnStudents.Margin = new Padding(2);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(176, 45);
            btnStudents.TabIndex = 2;
            btnStudents.Text = "Students";
            btnStudents.TextAlign = ContentAlignment.MiddleLeft;
            btnStudents.UseVisualStyleBackColor = true;
            btnStudents.Click += btnStudents_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 50);
            btnDashboard.Margin = new Padding(2);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(176, 45);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
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
            lblLogo.Margin = new Padding(2, 0, 2, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(129, 50);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "SESRS";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
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
            pnlContent.Location = new Point(176, 0);
            pnlContent.Margin = new Padding(2);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(766, 515);
            pnlContent.TabIndex = 1;
            // 
            // pnlSectionsCard
            // 
            pnlSectionsCard.BackColor = Color.White;
            pnlSectionsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSectionsCard.Controls.Add(lblSectionsCount);
            pnlSectionsCard.Controls.Add(lblSectionsTitle);
            pnlSectionsCard.Location = new Point(270, 236);
            pnlSectionsCard.Margin = new Padding(2);
            pnlSectionsCard.Name = "pnlSectionsCard";
            pnlSectionsCard.Size = new Size(200, 104);
            pnlSectionsCard.TabIndex = 5;
            // 
            // lblSectionsCount
            // 
            lblSectionsCount.AutoSize = true;
            lblSectionsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSectionsCount.Location = new Point(76, 40);
            lblSectionsCount.Margin = new Padding(2, 0, 2, 0);
            lblSectionsCount.Name = "lblSectionsCount";
            lblSectionsCount.Size = new Size(46, 54);
            lblSectionsCount.TabIndex = 1;
            lblSectionsCount.Text = "0";
            // 
            // lblSectionsTitle
            // 
            lblSectionsTitle.AutoSize = true;
            lblSectionsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSectionsTitle.ForeColor = Color.DarkGreen;
            lblSectionsTitle.Location = new Point(26, 16);
            lblSectionsTitle.Margin = new Padding(2, 0, 2, 0);
            lblSectionsTitle.Name = "lblSectionsTitle";
            lblSectionsTitle.Size = new Size(147, 23);
            lblSectionsTitle.TabIndex = 0;
            lblSectionsTitle.Text = "TOTAL SECTIONS";
            // 
            // pnlEnrollmentCard
            // 
            pnlEnrollmentCard.BackColor = Color.White;
            pnlEnrollmentCard.BorderStyle = BorderStyle.FixedSingle;
            pnlEnrollmentCard.Controls.Add(lblEnrollmentCount);
            pnlEnrollmentCard.Controls.Add(lblEnrollmentTitle);
            pnlEnrollmentCard.Location = new Point(36, 236);
            pnlEnrollmentCard.Margin = new Padding(2);
            pnlEnrollmentCard.Name = "pnlEnrollmentCard";
            pnlEnrollmentCard.Size = new Size(200, 104);
            pnlEnrollmentCard.TabIndex = 4;
            // 
            // lblEnrollmentCount
            // 
            lblEnrollmentCount.AutoSize = true;
            lblEnrollmentCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnrollmentCount.Location = new Point(76, 40);
            lblEnrollmentCount.Margin = new Padding(2, 0, 2, 0);
            lblEnrollmentCount.Name = "lblEnrollmentCount";
            lblEnrollmentCount.Size = new Size(46, 54);
            lblEnrollmentCount.TabIndex = 1;
            lblEnrollmentCount.Text = "0";
            // 
            // lblEnrollmentTitle
            // 
            lblEnrollmentTitle.AutoSize = true;
            lblEnrollmentTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnrollmentTitle.ForeColor = Color.DarkGreen;
            lblEnrollmentTitle.Location = new Point(10, 16);
            lblEnrollmentTitle.Margin = new Padding(2, 0, 2, 0);
            lblEnrollmentTitle.Name = "lblEnrollmentTitle";
            lblEnrollmentTitle.Size = new Size(188, 23);
            lblEnrollmentTitle.TabIndex = 0;
            lblEnrollmentTitle.Text = "TOTAL ENROLLMENTS";
            // 
            // pnlSubjectsCard
            // 
            pnlSubjectsCard.BackColor = Color.White;
            pnlSubjectsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSubjectsCard.Controls.Add(lblSubjectsCount);
            pnlSubjectsCard.Controls.Add(lblSubjectsTitle);
            pnlSubjectsCard.Location = new Point(270, 108);
            pnlSubjectsCard.Margin = new Padding(2);
            pnlSubjectsCard.Name = "pnlSubjectsCard";
            pnlSubjectsCard.Size = new Size(200, 104);
            pnlSubjectsCard.TabIndex = 3;
            // 
            // lblSubjectsCount
            // 
            lblSubjectsCount.AutoSize = true;
            lblSubjectsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubjectsCount.Location = new Point(76, 40);
            lblSubjectsCount.Margin = new Padding(2, 0, 2, 0);
            lblSubjectsCount.Name = "lblSubjectsCount";
            lblSubjectsCount.Size = new Size(46, 54);
            lblSubjectsCount.TabIndex = 1;
            lblSubjectsCount.Text = "0";
            // 
            // lblSubjectsTitle
            // 
            lblSubjectsTitle.AutoSize = true;
            lblSubjectsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubjectsTitle.ForeColor = Color.DarkGreen;
            lblSubjectsTitle.Location = new Point(26, 16);
            lblSubjectsTitle.Margin = new Padding(2, 0, 2, 0);
            lblSubjectsTitle.Name = "lblSubjectsTitle";
            lblSubjectsTitle.Size = new Size(147, 23);
            lblSubjectsTitle.TabIndex = 0;
            lblSubjectsTitle.Text = "TOTAL SUBJECTS";
            // 
            // pnlStudentsCard
            // 
            pnlStudentsCard.BackColor = Color.White;
            pnlStudentsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlStudentsCard.Controls.Add(lblStudentsCount);
            pnlStudentsCard.Controls.Add(lblStudentsTitle);
            pnlStudentsCard.Location = new Point(36, 108);
            pnlStudentsCard.Margin = new Padding(2);
            pnlStudentsCard.Name = "pnlStudentsCard";
            pnlStudentsCard.Size = new Size(200, 104);
            pnlStudentsCard.TabIndex = 2;
            // 
            // lblStudentsCount
            // 
            lblStudentsCount.AutoSize = true;
            lblStudentsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentsCount.Location = new Point(76, 40);
            lblStudentsCount.Margin = new Padding(2, 0, 2, 0);
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Size = new Size(46, 54);
            lblStudentsCount.TabIndex = 1;
            lblStudentsCount.Text = "0";
            // 
            // lblStudentsTitle
            // 
            lblStudentsTitle.AutoSize = true;
            lblStudentsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentsTitle.ForeColor = Color.DarkGreen;
            lblStudentsTitle.Location = new Point(26, 16);
            lblStudentsTitle.Margin = new Padding(2, 0, 2, 0);
            lblStudentsTitle.Name = "lblStudentsTitle";
            lblStudentsTitle.Size = new Size(153, 23);
            lblStudentsTitle.TabIndex = 0;
            lblStudentsTitle.Text = "TOTAL STUDENTS";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 11F);
            lblWelcome.Location = new Point(36, 72);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(168, 25);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome to SESRS";
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardTitle.ForeColor = Color.DarkGreen;
            lblDashboardTitle.Location = new Point(24, 20);
            lblDashboardTitle.Margin = new Padding(2, 0, 2, 0);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(229, 54);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Dashboard";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 515);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Margin = new Padding(2);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SESRS - Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += DashboardForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
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
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Label lblLogo;
        private Button btnDashboard;
        private Button btnStudents;
        private Button btnSubjects;
        private Button btnSections;
        private Button btnEnrollment;
        private Button btnReports;
        private Button btnLogout;
        private Panel pnlContent;
        private Label lblDashboardTitle;
        private Label lblWelcome;
        private Panel pnlStudentsCard;
        private Label lblStudentsTitle;
        private Label lblStudentsCount;
        private Panel pnlSectionsCard;
        private Label lblSectionsCount;
        private Label lblSectionsTitle;
        private Panel pnlEnrollmentCard;
        private Label lblEnrollmentCount;
        private Label lblEnrollmentTitle;
        private Panel pnlSubjectsCard;
        private Label lblSubjectsCount;
        private Label lblSubjectsTitle;
        private Button btnPendingStudents;
    }
}