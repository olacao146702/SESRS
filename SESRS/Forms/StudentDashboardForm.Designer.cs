namespace SESRS.Forms
{
    partial class StudentDashboardForm
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
            btnNotifications = new Button();
            btnHistory = new Button();
            btnSchedule = new Button();
            btnSubjects = new Button();
            btnEnrollment = new Button();
            btnDashboard = new Button();
            lblStudentPortal = new Label();
            lblSystemTitle = new Label();
            panel1 = new Panel();
            lblStudentNumber = new Label();
            lblYearLevel = new Label();
            lblProgram = new Label();
            lblDashboardTitleStudent = new Label();
            lblStatus = new Label();
            lblWelcome = new Label();
            pnlSubjectsCard = new Panel();
            lblSubjectsCount = new Label();
            lblSubjectsTitle = new Label();
            panel2 = new Panel();
            lblStatusstudent = new Label();
            label4 = new Label();
            lblYearLevelstudent = new Label();
            lblStudentNumberstudent = new Label();
            lblProgramstudent = new Label();
            label8 = new Label();
            pnlStudentNumber = new Panel();
            pnlProgram = new Panel();
            pnlYearLevel = new Panel();
            pnlStatus = new Panel();
            pnlSidebar.SuspendLayout();
            panel1.SuspendLayout();
            pnlSubjectsCard.SuspendLayout();
            panel2.SuspendLayout();
            pnlStudentNumber.SuspendLayout();
            pnlProgram.SuspendLayout();
            pnlYearLevel.SuspendLayout();
            pnlStatus.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.DarkGreen;
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnNotifications);
            pnlSidebar.Controls.Add(btnHistory);
            pnlSidebar.Controls.Add(btnSchedule);
            pnlSidebar.Controls.Add(btnSubjects);
            pnlSidebar.Controls.Add(btnEnrollment);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(lblStudentPortal);
            pnlSidebar.Controls.Add(lblSystemTitle);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(2);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(194, 515);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.DarkGreen;
            btnLogout.Location = new Point(0, 479);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(194, 36);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = Color.DarkGreen;
            btnNotifications.Dock = DockStyle.Top;
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNotifications.ForeColor = Color.White;
            btnNotifications.Location = new Point(0, 241);
            btnNotifications.Margin = new Padding(2);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(194, 35);
            btnNotifications.TabIndex = 6;
            btnNotifications.Text = "Notifications";
            btnNotifications.TextAlign = ContentAlignment.MiddleLeft;
            btnNotifications.UseVisualStyleBackColor = false;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.DarkGreen;
            btnHistory.Dock = DockStyle.Top;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHistory.ForeColor = Color.White;
            btnHistory.Location = new Point(0, 205);
            btnHistory.Margin = new Padding(2);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(194, 36);
            btnHistory.TabIndex = 5;
            btnHistory.Text = "History";
            btnHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnHistory.UseVisualStyleBackColor = false;
            // 
            // btnSchedule
            // 
            btnSchedule.BackColor = Color.DarkGreen;
            btnSchedule.Dock = DockStyle.Top;
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSchedule.ForeColor = Color.White;
            btnSchedule.Location = new Point(0, 169);
            btnSchedule.Margin = new Padding(2);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(194, 36);
            btnSchedule.TabIndex = 4;
            btnSchedule.Text = "Schedule";
            btnSchedule.TextAlign = ContentAlignment.MiddleLeft;
            btnSchedule.UseVisualStyleBackColor = false;
            // 
            // btnSubjects
            // 
            btnSubjects.BackColor = Color.DarkGreen;
            btnSubjects.Dock = DockStyle.Top;
            btnSubjects.FlatStyle = FlatStyle.Flat;
            btnSubjects.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubjects.ForeColor = Color.White;
            btnSubjects.Location = new Point(0, 133);
            btnSubjects.Margin = new Padding(2);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Size = new Size(194, 36);
            btnSubjects.TabIndex = 3;
            btnSubjects.Text = "Subjects";
            btnSubjects.TextAlign = ContentAlignment.MiddleLeft;
            btnSubjects.UseVisualStyleBackColor = false;
            // 
            // btnEnrollment
            // 
            btnEnrollment.BackColor = Color.DarkGreen;
            btnEnrollment.Dock = DockStyle.Top;
            btnEnrollment.FlatStyle = FlatStyle.Flat;
            btnEnrollment.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnrollment.ForeColor = Color.White;
            btnEnrollment.Location = new Point(0, 97);
            btnEnrollment.Margin = new Padding(2);
            btnEnrollment.Name = "btnEnrollment";
            btnEnrollment.Size = new Size(194, 36);
            btnEnrollment.TabIndex = 2;
            btnEnrollment.Text = "Enrollment";
            btnEnrollment.TextAlign = ContentAlignment.MiddleLeft;
            btnEnrollment.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.DarkGreen;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 61);
            btnDashboard.Margin = new Padding(2);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(194, 36);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // lblStudentPortal
            // 
            lblStudentPortal.AutoSize = true;
            lblStudentPortal.BackColor = Color.DarkGreen;
            lblStudentPortal.Dock = DockStyle.Top;
            lblStudentPortal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentPortal.ForeColor = Color.White;
            lblStudentPortal.Location = new Point(0, 41);
            lblStudentPortal.Margin = new Padding(2, 0, 2, 0);
            lblStudentPortal.Name = "lblStudentPortal";
            lblStudentPortal.Size = new Size(110, 20);
            lblStudentPortal.TabIndex = 1;
            lblStudentPortal.Text = "Student Portal";
            // 
            // lblSystemTitle
            // 
            lblSystemTitle.AutoSize = true;
            lblSystemTitle.Dock = DockStyle.Top;
            lblSystemTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSystemTitle.ForeColor = Color.White;
            lblSystemTitle.Location = new Point(0, 0);
            lblSystemTitle.Margin = new Padding(2, 0, 2, 0);
            lblSystemTitle.Name = "lblSystemTitle";
            lblSystemTitle.Size = new Size(105, 41);
            lblSystemTitle.TabIndex = 1;
            lblSystemTitle.Text = "SESRS";
            lblSystemTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pnlSubjectsCard);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(lblYearLevel);
            panel1.Controls.Add(lblStudentNumber);
            panel1.Controls.Add(lblProgram);
            panel1.Controls.Add(lblDashboardTitleStudent);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(194, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(748, 515);
            panel1.TabIndex = 1;
            // 
            // lblStudentNumber
            // 
            lblStudentNumber.AutoSize = true;
            lblStudentNumber.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentNumber.ForeColor = Color.Black;
            lblStudentNumber.Location = new Point(453, 58);
            lblStudentNumber.Margin = new Padding(2, 0, 2, 0);
            lblStudentNumber.Name = "lblStudentNumber";
            lblStudentNumber.Size = new Size(138, 23);
            lblStudentNumber.TabIndex = 1;
            lblStudentNumber.Text = "Student Number";
            lblStudentNumber.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYearLevel.ForeColor = Color.Black;
            lblYearLevel.Location = new Point(631, 61);
            lblYearLevel.Margin = new Padding(2, 0, 2, 0);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(86, 23);
            lblYearLevel.TabIndex = 3;
            lblYearLevel.Text = "Year Level";
            lblYearLevel.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgram.ForeColor = Color.Black;
            lblProgram.Location = new Point(588, 110);
            lblProgram.Margin = new Padding(2, 0, 2, 0);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(76, 23);
            lblProgram.TabIndex = 2;
            lblProgram.Text = "Program";
            lblProgram.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblDashboardTitleStudent
            // 
            lblDashboardTitleStudent.AutoSize = true;
            lblDashboardTitleStudent.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDashboardTitleStudent.Location = new Point(22, 27);
            lblDashboardTitleStudent.Margin = new Padding(2, 0, 2, 0);
            lblDashboardTitleStudent.Name = "lblDashboardTitleStudent";
            lblDashboardTitleStudent.Size = new Size(380, 54);
            lblDashboardTitleStudent.TabIndex = 0;
            lblDashboardTitleStudent.Text = "Welcome, Student!";
            lblDashboardTitleStudent.Click += lblWelcome_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Black;
            lblStatus.Location = new Point(631, 211);
            lblStatus.Margin = new Padding(2, 0, 2, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(57, 23);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status";
            lblStatus.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 11F);
            lblWelcome.Location = new Point(45, 81);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(168, 25);
            lblWelcome.TabIndex = 5;
            lblWelcome.Text = "Welcome to SESRS";
            // 
            // pnlSubjectsCard
            // 
            pnlSubjectsCard.BackColor = Color.White;
            pnlSubjectsCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSubjectsCard.Controls.Add(lblSubjectsCount);
            pnlSubjectsCard.Controls.Add(lblSubjectsTitle);
            pnlSubjectsCard.Location = new Point(45, 133);
            pnlSubjectsCard.Margin = new Padding(2);
            pnlSubjectsCard.Name = "pnlSubjectsCard";
            pnlSubjectsCard.Size = new Size(200, 104);
            pnlSubjectsCard.TabIndex = 6;
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
            lblSubjectsTitle.Location = new Point(26, 16);
            lblSubjectsTitle.Margin = new Padding(2, 0, 2, 0);
            lblSubjectsTitle.Name = "lblSubjectsTitle";
            lblSubjectsTitle.Size = new Size(147, 23);
            lblSubjectsTitle.TabIndex = 0;
            lblSubjectsTitle.Text = "TOTAL SUBJECTS";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(pnlStatus);
            panel2.Controls.Add(pnlYearLevel);
            panel2.Controls.Add(pnlProgram);
            panel2.Controls.Add(pnlStudentNumber);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(748, 515);
            panel2.TabIndex = 7;
            // 
            // lblStatusstudent
            // 
            lblStatusstudent.AutoSize = true;
            lblStatusstudent.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusstudent.ForeColor = Color.Black;
            lblStatusstudent.Location = new Point(25, 11);
            lblStatusstudent.Margin = new Padding(2, 0, 2, 0);
            lblStatusstudent.Name = "lblStatusstudent";
            lblStatusstudent.Size = new Size(56, 23);
            lblStatusstudent.TabIndex = 4;
            lblStatusstudent.Text = "Status";
            lblStatusstudent.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(45, 81);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(168, 25);
            label4.TabIndex = 5;
            label4.Text = "Welcome to SESRS";
            // 
            // lblYearLevelstudent
            // 
            lblYearLevelstudent.AutoSize = true;
            lblYearLevelstudent.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYearLevelstudent.ForeColor = Color.Black;
            lblYearLevelstudent.Location = new Point(25, 8);
            lblYearLevelstudent.Margin = new Padding(2, 0, 2, 0);
            lblYearLevelstudent.Name = "lblYearLevelstudent";
            lblYearLevelstudent.Size = new Size(85, 23);
            lblYearLevelstudent.TabIndex = 3;
            lblYearLevelstudent.Text = "Year Level";
            lblYearLevelstudent.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblStudentNumberstudent
            // 
            lblStudentNumberstudent.AutoSize = true;
            lblStudentNumberstudent.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStudentNumberstudent.ForeColor = Color.Black;
            lblStudentNumberstudent.Location = new Point(19, 8);
            lblStudentNumberstudent.Margin = new Padding(2, 0, 2, 0);
            lblStudentNumberstudent.Name = "lblStudentNumberstudent";
            lblStudentNumberstudent.Size = new Size(137, 23);
            lblStudentNumberstudent.TabIndex = 1;
            lblStudentNumberstudent.Text = "Student Number";
            lblStudentNumberstudent.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblProgramstudent
            // 
            lblProgramstudent.AutoSize = true;
            lblProgramstudent.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProgramstudent.ForeColor = Color.Black;
            lblProgramstudent.Location = new Point(19, 11);
            lblProgramstudent.Margin = new Padding(2, 0, 2, 0);
            lblProgramstudent.Name = "lblProgramstudent";
            lblProgramstudent.Size = new Size(76, 23);
            lblProgramstudent.TabIndex = 2;
            lblProgramstudent.Text = "Program";
            lblProgramstudent.TextAlign = ContentAlignment.TopCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(22, 27);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(380, 54);
            label8.TabIndex = 0;
            label8.Text = "Welcome, Student!";
            // 
            // pnlStudentNumber
            // 
            pnlStudentNumber.BackColor = Color.White;
            pnlStudentNumber.BorderStyle = BorderStyle.FixedSingle;
            pnlStudentNumber.Controls.Add(lblStudentNumberstudent);
            pnlStudentNumber.ForeColor = SystemColors.ControlText;
            pnlStudentNumber.Location = new Point(88, 174);
            pnlStudentNumber.Name = "pnlStudentNumber";
            pnlStudentNumber.Size = new Size(201, 73);
            pnlStudentNumber.TabIndex = 6;
            pnlStudentNumber.Paint += pnlStudentNumber_Paint;
            // 
            // pnlProgram
            // 
            pnlProgram.BackColor = Color.White;
            pnlProgram.BorderStyle = BorderStyle.FixedSingle;
            pnlProgram.Controls.Add(lblProgramstudent);
            pnlProgram.Location = new Point(88, 265);
            pnlProgram.Name = "pnlProgram";
            pnlProgram.Size = new Size(201, 73);
            pnlProgram.TabIndex = 7;
            pnlProgram.Paint += pnlProgram_Paint;
            // 
            // pnlYearLevel
            // 
            pnlYearLevel.BackColor = Color.White;
            pnlYearLevel.BorderStyle = BorderStyle.FixedSingle;
            pnlYearLevel.Controls.Add(lblYearLevelstudent);
            pnlYearLevel.Location = new Point(328, 174);
            pnlYearLevel.Name = "pnlYearLevel";
            pnlYearLevel.Size = new Size(201, 73);
            pnlYearLevel.TabIndex = 8;
            pnlYearLevel.Paint += pnlYearLevel_Paint;
            // 
            // pnlStatus
            // 
            pnlStatus.BackColor = Color.White;
            pnlStatus.BorderStyle = BorderStyle.FixedSingle;
            pnlStatus.Controls.Add(lblStatusstudent);
            pnlStatus.Location = new Point(328, 265);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(201, 73);
            pnlStatus.TabIndex = 9;
            pnlStatus.Paint += pnlStatus_Paint;
            // 
            // StudentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 515);
            Controls.Add(panel1);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Dashboard";
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlSubjectsCard.ResumeLayout(false);
            pnlSubjectsCard.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlStudentNumber.ResumeLayout(false);
            pnlStudentNumber.PerformLayout();
            pnlProgram.ResumeLayout(false);
            pnlProgram.PerformLayout();
            pnlYearLevel.ResumeLayout(false);
            pnlYearLevel.PerformLayout();
            pnlStatus.ResumeLayout(false);
            pnlStatus.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Label lblSystemTitle;
        private Label lblStudentPortal;
        private Button btnDashboard;
        private Button btnEnrollment;
        private Button btnSubjects;
        private Button btnSchedule;
        private Button btnHistory;
        private Button btnNotifications;
        private Button btnLogout;
        private Panel panel1;
        private Label lblDashboardTitleStudent;
        private Label lblStudentNumber;
        private Label lblYearLevel;
        private Label lblProgram;
        private Label lblStatus;
        private Label lblWelcome;
        private Panel pnlSubjectsCard;
        private Label lblSubjectsCount;
        private Label lblSubjectsTitle;
        private Panel panel2;
        private Label lblStatusstudent;
        private Label label4;
        private Label lblYearLevelstudent;
        private Label lblStudentNumberstudent;
        private Label lblProgramstudent;
        private Label label8;
        private Panel pnlStatus;
        private Panel pnlYearLevel;
        private Panel pnlProgram;
        private Panel pnlStudentNumber;
    }
}