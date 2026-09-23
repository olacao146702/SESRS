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
            lblTitle.Location = new Point(54, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(73, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reports";
            // 
            // btnStudentReport
            // 
            btnStudentReport.Location = new Point(54, 107);
            btnStudentReport.Name = "btnStudentReport";
            btnStudentReport.Size = new Size(198, 34);
            btnStudentReport.TabIndex = 1;
            btnStudentReport.Text = "STUDENT REPORT";
            btnStudentReport.UseVisualStyleBackColor = true;
            btnStudentReport.Click += btnStudentReport_Click;
            // 
            // btnEnrollmentReport
            // 
            btnEnrollmentReport.Location = new Point(258, 107);
            btnEnrollmentReport.Name = "btnEnrollmentReport";
            btnEnrollmentReport.Size = new Size(198, 34);
            btnEnrollmentReport.TabIndex = 2;
            btnEnrollmentReport.Text = "ENROLLMENT REPORT";
            btnEnrollmentReport.UseVisualStyleBackColor = true;
            btnEnrollmentReport.Click += btnEnrollmentReport_Click;
            // 
            // btnProgramReport
            // 
            btnProgramReport.Location = new Point(462, 107);
            btnProgramReport.Name = "btnProgramReport";
            btnProgramReport.Size = new Size(198, 34);
            btnProgramReport.TabIndex = 3;
            btnProgramReport.Text = "PROGRAM REPORT";
            btnProgramReport.UseVisualStyleBackColor = true;
            btnProgramReport.Click += btnProgramReport_Click;
            // 
            // dgvReports
            // 
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(39, 185);
            dgvReports.Name = "dgvReports";
            dgvReports.RowHeadersWidth = 62;
            dgvReports.Size = new Size(1068, 417);
            dgvReports.TabIndex = 4;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 744);
            Controls.Add(dgvReports);
            Controls.Add(btnProgramReport);
            Controls.Add(btnEnrollmentReport);
            Controls.Add(btnStudentReport);
            Controls.Add(lblTitle);
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