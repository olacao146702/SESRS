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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblStudentNumber = new Label();
            lblYearLevel = new Label();
            lblProgram = new Label();
            lblWelcome = new Label();
            pnlSidebar.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(lblWelcome);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(194, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(748, 515);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.8F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.2F));
            tableLayoutPanel1.Controls.Add(lblStudentNumber, 0, 0);
            tableLayoutPanel1.Controls.Add(lblYearLevel, 0, 1);
            tableLayoutPanel1.Controls.Add(lblProgram, 1, 0);
            tableLayoutPanel1.Location = new Point(58, 111);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(405, 257);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // lblStudentNumber
            // 
            lblStudentNumber.AutoSize = true;
            lblStudentNumber.Location = new Point(2, 0);
            lblStudentNumber.Margin = new Padding(2, 0, 2, 0);
            lblStudentNumber.Name = "lblStudentNumber";
            lblStudentNumber.Size = new Size(131, 20);
            lblStudentNumber.TabIndex = 1;
            lblStudentNumber.Text = "Student Number: -";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(2, 128);
            lblYearLevel.Margin = new Padding(2, 0, 2, 0);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(88, 20);
            lblYearLevel.TabIndex = 3;
            lblYearLevel.Text = "Year Level: -";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Location = new Point(207, 0);
            lblProgram.Margin = new Padding(2, 0, 2, 0);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(79, 20);
            lblProgram.TabIndex = 2;
            lblProgram.Text = "Program: -";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(22, 15);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(321, 46);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Student!";
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
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel1;
    }
}