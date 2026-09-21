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
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 644);
            pnlSidebar.TabIndex = 0;
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
            // 
            // btnReports
            // 
            btnReports.Dock = DockStyle.Top;
            btnReports.Location = new Point(0, 285);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(220, 45);
            btnReports.TabIndex = 6;
            btnReports.Text = "REPORTS";
            btnReports.UseVisualStyleBackColor = true;
            // 
            // btnEnrollment
            // 
            btnEnrollment.Dock = DockStyle.Top;
            btnEnrollment.Location = new Point(0, 240);
            btnEnrollment.Name = "btnEnrollment";
            btnEnrollment.Size = new Size(220, 45);
            btnEnrollment.TabIndex = 5;
            btnEnrollment.Text = "ENROLLMENT";
            btnEnrollment.UseVisualStyleBackColor = true;
            // 
            // btnSections
            // 
            btnSections.Dock = DockStyle.Top;
            btnSections.Location = new Point(0, 195);
            btnSections.Name = "btnSections";
            btnSections.Size = new Size(220, 45);
            btnSections.TabIndex = 4;
            btnSections.Text = "SECTIONS";
            btnSections.UseVisualStyleBackColor = true;
            // 
            // btnSubjects
            // 
            btnSubjects.Dock = DockStyle.Top;
            btnSubjects.Location = new Point(0, 150);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Size = new Size(220, 45);
            btnSubjects.TabIndex = 3;
            btnSubjects.Text = "SUBJECTS";
            btnSubjects.UseVisualStyleBackColor = true;
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
            pnlSectionsCard.Location = new Point(337, 295);
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
            pnlEnrollmentCard.Location = new Point(45, 295);
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
            pnlSubjectsCard.Size = new Size(250, 130);
            pnlSubjectsCard.TabIndex = 3;
            // 
            // lblSubjectsCount
            // 
            lblSubjectsCount.AutoSize = true;
            lblSubjectsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubjectsCount.Location = new Point(95, 50);
            lblSubjectsCount.Name = "lblSubjectsCount";
            lblSubjectsCount.Size = new Size(56, 65);
            lblSubjectsCount.TabIndex = 1;
            lblSubjectsCount.Text = "0";
            // 
            // lblSubjectsTitle
            // 
            lblSubjectsTitle.AutoSize = true;
            lblSubjectsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubjectsTitle.Location = new Point(33, 20);
            lblSubjectsTitle.Name = "lblSubjectsTitle";
            lblSubjectsTitle.Size = new Size(171, 28);
            lblSubjectsTitle.TabIndex = 0;
            lblSubjectsTitle.Text = "TOTAL SUBJECTS";
            // 
            // pnlStudentsCard
            // 
            pnlStudentsCard.BackColor = Color.White;
            pnlStudentsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlStudentsCard.Controls.Add(lblStudentsCount);
            pnlStudentsCard.Controls.Add(lblStudentsTitle);
            pnlStudentsCard.Location = new Point(45, 135);
            pnlStudentsCard.Name = "pnlStudentsCard";
            pnlStudentsCard.Size = new Size(250, 130);
            pnlStudentsCard.TabIndex = 2;
            // 
            // lblStudentsCount
            // 
            lblStudentsCount.AutoSize = true;
            lblStudentsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentsCount.Location = new Point(95, 50);
            lblStudentsCount.Name = "lblStudentsCount";
            lblStudentsCount.Size = new Size(56, 65);
            lblStudentsCount.TabIndex = 1;
            lblStudentsCount.Text = "0";
            // 
            // lblStudentsTitle
            // 
            lblStudentsTitle.AutoSize = true;
            lblStudentsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentsTitle.Location = new Point(33, 20);
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
    }
}