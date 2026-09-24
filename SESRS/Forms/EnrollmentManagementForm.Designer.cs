namespace SESRS.Forms
{
    partial class EnrollmentManagementForm
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
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            dgvEnrollments = new DataGridView();
            btnViewDetails = new Button();
            btnEnroll = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEnrollments).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(31, 9);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(418, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Enrollment Management";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(43, 92);
            lblSearch.Margin = new Padding(2, 0, 2, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(116, 20);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search Student:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(166, 87);
            txtSearch.Margin = new Padding(2, 2, 2, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(344, 27);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DarkGreen;
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(702, 86);
            btnSearch.Margin = new Padding(2, 2, 2, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 35);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.DarkGreen;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(796, 86);
            btnRefresh.Margin = new Padding(2, 2, 2, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 35);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvEnrollments
            // 
            dgvEnrollments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnrollments.Location = new Point(31, 148);
            dgvEnrollments.Margin = new Padding(2, 2, 2, 2);
            dgvEnrollments.Name = "dgvEnrollments";
            dgvEnrollments.RowHeadersWidth = 62;
            dgvEnrollments.Size = new Size(854, 334);
            dgvEnrollments.TabIndex = 5;
            // 
            // btnViewDetails
            // 
            btnViewDetails.BackColor = Color.DarkGreen;
            btnViewDetails.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewDetails.ForeColor = Color.White;
            btnViewDetails.Location = new Point(31, 500);
            btnViewDetails.Margin = new Padding(2, 2, 2, 2);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(145, 35);
            btnViewDetails.TabIndex = 6;
            btnViewDetails.Text = "View Details";
            btnViewDetails.UseVisualStyleBackColor = false;
            // 
            // btnEnroll
            // 
            btnEnroll.BackColor = Color.DarkGreen;
            btnEnroll.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnroll.ForeColor = Color.White;
            btnEnroll.Location = new Point(175, 500);
            btnEnroll.Margin = new Padding(2, 2, 2, 2);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(145, 35);
            btnEnroll.TabIndex = 7;
            btnEnroll.Text = "Enroll Student";
            btnEnroll.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkGreen;
            btnCancel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(319, 500);
            btnCancel.Margin = new Padding(2, 2, 2, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(145, 35);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel Enrollment";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // EnrollmentManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 595);
            Controls.Add(btnCancel);
            Controls.Add(btnEnroll);
            Controls.Add(btnViewDetails);
            Controls.Add(dgvEnrollments);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblTitle);
            Margin = new Padding(2, 2, 2, 2);
            Name = "EnrollmentManagementForm";
            Text = "Enrollment Management";
            Load += EnrollmentManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEnrollments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvEnrollments;
        private Button btnViewDetails;
        private Button btnEnroll;
        private Button btnCancel;
    }
}