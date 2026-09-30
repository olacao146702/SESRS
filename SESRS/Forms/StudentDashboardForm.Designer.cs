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
            lblYearLevel = new Label();
            lblProgram = new Label();
            lblStudentNumber = new Label();
            lblWelcome = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            pnlSidebar.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(24, 82, 58);
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
            pnlSidebar.Margin = new Padding(2, 2, 2, 2);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(176, 515);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(19, 68, 48);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 479);
            btnLogout.Margin = new Padding(2, 2, 2, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(176, 36);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = Color.FromArgb(24, 82, 58);
            btnNotifications.Dock = DockStyle.Top;
            btnNotifications.FlatAppearance.BorderSize = 0;
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNotifications.ForeColor = Color.White;
            btnNotifications.Location = new Point(0, 241);
            btnNotifications.Margin = new Padding(2, 2, 2, 2);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(176, 36);
            btnNotifications.TabIndex = 6;
            btnNotifications.Text = "Notifications";
            btnNotifications.UseVisualStyleBackColor = false;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.FromArgb(24, 82, 58);
            btnHistory.Dock = DockStyle.Top;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHistory.ForeColor = Color.White;
            btnHistory.Location = new Point(0, 205);
            btnHistory.Margin = new Padding(2, 2, 2, 2);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(176, 36);
            btnHistory.TabIndex = 5;
            btnHistory.Text = "History";
            btnHistory.UseVisualStyleBackColor = false;
            // 
            // btnSchedule
            // 
            btnSchedule.BackColor = Color.FromArgb(24, 82, 58);
            btnSchedule.Dock = DockStyle.Top;
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSchedule.ForeColor = Color.White;
            btnSchedule.Location = new Point(0, 169);
            btnSchedule.Margin = new Padding(2, 2, 2, 2);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(176, 36);
            btnSchedule.TabIndex = 4;
            btnSchedule.Text = "Schedule";
            btnSchedule.UseVisualStyleBackColor = false;
            // 
            // btnSubjects
            // 
            btnSubjects.BackColor = Color.FromArgb(24, 82, 58);
            btnSubjects.Dock = DockStyle.Top;
            btnSubjects.FlatAppearance.BorderSize = 0;
            btnSubjects.FlatStyle = FlatStyle.Flat;
            btnSubjects.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubjects.ForeColor = Color.White;
            btnSubjects.Location = new Point(0, 133);
            btnSubjects.Margin = new Padding(2, 2, 2, 2);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Size = new Size(176, 36);
            btnSubjects.TabIndex = 3;
            btnSubjects.Text = "Subjects";
            btnSubjects.UseVisualStyleBackColor = false;
            // 
            // btnEnrollment
            // 
            btnEnrollment.BackColor = Color.FromArgb(24, 82, 58);
            btnEnrollment.Dock = DockStyle.Top;
            btnEnrollment.FlatAppearance.BorderSize = 0;
            btnEnrollment.FlatStyle = FlatStyle.Flat;
            btnEnrollment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEnrollment.ForeColor = Color.White;
            btnEnrollment.Location = new Point(0, 97);
            btnEnrollment.Margin = new Padding(2, 2, 2, 2);
            btnEnrollment.Name = "btnEnrollment";
            btnEnrollment.Size = new Size(176, 36);
            btnEnrollment.TabIndex = 2;
            btnEnrollment.Text = "Enrollment";
            btnEnrollment.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(42, 112, 80);
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 61);
            btnDashboard.Margin = new Padding(2, 2, 2, 2);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(176, 36);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // lblStudentPortal
            // 
            lblStudentPortal.AutoSize = true;
            lblStudentPortal.BackColor = Color.FromArgb(19, 68, 48);
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
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lblWelcome);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(176, 0);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(766, 515);
            panel1.TabIndex = 1;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYearLevel.ForeColor = Color.FromArgb(90, 100, 95);
            lblYearLevel.Location = new Point(12, 9);
            lblYearLevel.Margin = new Padding(2, 0, 2, 0);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(93, 20);
            lblYearLevel.TabIndex = 3;
            lblYearLevel.Text = "Year Level: -";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgram.ForeColor = Color.FromArgb(90, 100, 95);
            lblProgram.Location = new Point(13, 9);
            lblProgram.Margin = new Padding(2, 0, 2, 0);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(84, 20);
            lblProgram.TabIndex = 2;
            lblProgram.Text = "Program: -";
            // 
            // lblStudentNumber
            // 
            lblStudentNumber.AutoSize = true;
            lblStudentNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentNumber.ForeColor = Color.FromArgb(90, 100, 95);
            lblStudentNumber.Location = new Point(12, 9);
            lblStudentNumber.Margin = new Padding(2, 0, 2, 0);
            lblStudentNumber.Name = "lblStudentNumber";
            lblStudentNumber.Size = new Size(141, 20);
            lblStudentNumber.TabIndex = 1;
            lblStudentNumber.Text = "Student Number: -";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(22, 41);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(321, 46);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Student!";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblStudentNumber);
            panel2.Location = new Point(22, 145);
            panel2.Name = "panel2";
            panel2.Size = new Size(260, 60);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblYearLevel);
            panel3.Location = new Point(22, 234);
            panel3.Name = "panel3";
            panel3.Size = new Size(260, 60);
            panel3.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblProgram);
            panel4.Location = new Point(354, 145);
            panel4.Name = "panel4";
            panel4.Size = new Size(260, 60);
            panel4.TabIndex = 6;
            // 
            // StudentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 515);
            Controls.Add(panel1);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Dashboard";
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
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
        private Label lblWelcome;
        private Label lblStudentNumber;
        private Label lblYearLevel;
        private Label lblProgram;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
    }
}