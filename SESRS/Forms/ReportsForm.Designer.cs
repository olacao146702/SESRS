namespace SESRS.Forms
{
    partial class ReportsForm
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
            lblTitle = new Label();
            btnStudentReport = new Button();
            btnEnrollmentReport = new Button();
            btnProgramReport = new Button();
            dgvReports = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(43, 26);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(144, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reports";
            // 
            // btnStudentReport
            // 
            btnStudentReport.BackColor = Color.DarkGreen;
            btnStudentReport.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStudentReport.ForeColor = Color.White;
            btnStudentReport.Location = new Point(69, 86);
            btnStudentReport.Margin = new Padding(2, 2, 2, 2);
            btnStudentReport.Name = "btnStudentReport";
            btnStudentReport.Size = new Size(190, 40);
            btnStudentReport.TabIndex = 1;
            btnStudentReport.Text = "STUDENT REPORT";
            btnStudentReport.UseVisualStyleBackColor = false;
            btnStudentReport.Click += btnStudentReport_Click;
            // 
            // btnEnrollmentReport
            // 
            btnEnrollmentReport.BackColor = Color.DarkGreen;
            btnEnrollmentReport.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnrollmentReport.ForeColor = Color.White;
            btnEnrollmentReport.Location = new Point(304, 86);
            btnEnrollmentReport.Margin = new Padding(2, 2, 2, 2);
            btnEnrollmentReport.Name = "btnEnrollmentReport";
            btnEnrollmentReport.Size = new Size(190, 40);
            btnEnrollmentReport.TabIndex = 2;
            btnEnrollmentReport.Text = "ENROLLMENT REPORT";
            btnEnrollmentReport.UseVisualStyleBackColor = false;
            btnEnrollmentReport.Click += btnEnrollmentReport_Click;
            // 
            // btnProgramReport
            // 
            btnProgramReport.BackColor = Color.DarkGreen;
            btnProgramReport.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProgramReport.ForeColor = Color.White;
            btnProgramReport.Location = new Point(541, 86);
            btnProgramReport.Margin = new Padding(2, 2, 2, 2);
            btnProgramReport.Name = "btnProgramReport";
            btnProgramReport.Size = new Size(190, 40);
            btnProgramReport.TabIndex = 3;
            btnProgramReport.Text = "PROGRAM REPORT";
            btnProgramReport.UseVisualStyleBackColor = false;
            btnProgramReport.Click += btnProgramReport_Click;
            // 
            // dgvReports
            // 
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(31, 148);
            dgvReports.Margin = new Padding(2, 2, 2, 2);
            dgvReports.Name = "dgvReports";
            dgvReports.RowHeadersWidth = 62;
            dgvReports.Size = new Size(854, 334);
            dgvReports.TabIndex = 4;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 595);
            Controls.Add(dgvReports);
            Controls.Add(btnProgramReport);
            Controls.Add(btnEnrollmentReport);
            Controls.Add(btnStudentReport);
            Controls.Add(lblTitle);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnStudentReport;
        private Button btnEnrollmentReport;
        private Button btnProgramReport;
        private DataGridView dgvReports;
    }
}