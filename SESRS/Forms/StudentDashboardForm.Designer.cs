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
            pnlSidebar.SuspendLayout();
            panel1.SuspendLayout();
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
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 644);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.ForeColor = SystemColors.ControlText;
            btnLogout.Location = new Point(0, 599);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 45);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = Color.White;
            btnNotifications.Dock = DockStyle.Top;
            btnNotifications.ForeColor = SystemColors.ControlText;
            btnNotifications.Location = new Point(0, 298);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(220, 45);
            btnNotifications.TabIndex = 6;
            btnNotifications.Text = "NOTIFICATIONS";
            btnNotifications.UseVisualStyleBackColor = false;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.White;
            btnHistory.Dock = DockStyle.Top;
            btnHistory.ForeColor = SystemColors.ControlText;
            btnHistory.Location = new Point(0, 253);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(220, 45);
            btnHistory.TabIndex = 5;
            btnHistory.Text = "HISTORY";
            btnHistory.UseVisualStyleBackColor = false;
            // 
            // btnSchedule
            // 
            btnSchedule.BackColor = Color.White;
            btnSchedule.Dock = DockStyle.Top;
            btnSchedule.ForeColor = SystemColors.ControlText;
            btnSchedule.Location = new Point(0, 208);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(220, 45);
            btnSchedule.TabIndex = 4;
            btnSchedule.Text = "SCHEDULE";
            btnSchedule.UseVisualStyleBackColor = false;
            // 
            // btnSubjects
            // 
            btnSubjects.BackColor = Color.White;
            btnSubjects.Dock = DockStyle.Top;
            btnSubjects.ForeColor = SystemColors.ControlText;
            btnSubjects.Location = new Point(0, 163);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Size = new Size(220, 45);
            btnSubjects.TabIndex = 3;
            btnSubjects.Text = "SUBJECTS";
            btnSubjects.UseVisualStyleBackColor = false;
            // 
            // btnEnrollment
            // 
            btnEnrollment.BackColor = Color.White;
            btnEnrollment.Dock = DockStyle.Top;
            btnEnrollment.ForeColor = SystemColors.ControlText;
            btnEnrollment.Location = new Point(0, 118);
            btnEnrollment.Name = "btnEnrollment";
            btnEnrollment.Size = new Size(220, 45);
            btnEnrollment.TabIndex = 2;
            btnEnrollment.Text = "ENROLLMENT";
            btnEnrollment.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.White;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.ForeColor = SystemColors.ControlText;
            btnDashboard.Location = new Point(0, 73);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(220, 45);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "DASHBOARD";
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // lblStudentPortal
            // 
            lblStudentPortal.AutoSize = true;
            lblStudentPortal.BackColor = Color.DarkGreen;
            lblStudentPortal.Dock = DockStyle.Top;
            lblStudentPortal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentPortal.ForeColor = Color.White;
            lblStudentPortal.Location = new Point(0, 48);
            lblStudentPortal.Name = "lblStudentPortal";
            lblStudentPortal.Size = new Size(135, 25);
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
            lblSystemTitle.Name = "lblSystemTitle";
            lblSystemTitle.Size = new Size(123, 48);
            lblSystemTitle.TabIndex = 1;
            lblSystemTitle.Text = "SESRS";
            lblSystemTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblYearLevel);
            panel1.Controls.Add(lblProgram);
            panel1.Controls.Add(lblStudentNumber);
            panel1.Controls.Add(lblWelcome);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(220, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(958, 644);
            panel1.TabIndex = 1;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(108, 253);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(104, 25);
            lblYearLevel.TabIndex = 3;
            lblYearLevel.Text = "Year Level: -";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Location = new Point(475, 128);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(97, 25);
            lblProgram.TabIndex = 2;
            lblProgram.Text = "Program: -";
            // 
            // lblStudentNumber
            // 
            lblStudentNumber.AutoSize = true;
            lblStudentNumber.Location = new Point(99, 128);
            lblStudentNumber.Name = "lblStudentNumber";
            lblStudentNumber.Size = new Size(159, 25);
            lblStudentNumber.TabIndex = 1;
            lblStudentNumber.Text = "Student Number: -";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(27, 19);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(380, 54);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Student!";
            // 
            // StudentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 644);
            Controls.Add(panel1);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Dashboard";
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
    }
}