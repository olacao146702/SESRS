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
            lblTitle.Location = new Point(54, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(207, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Enrollment Management";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(54, 115);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(134, 25);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search Student:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(208, 109);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(429, 31);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(877, 107);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(995, 107);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 34);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "REFRESH";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvEnrollments
            // 
            dgvEnrollments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnrollments.Location = new Point(39, 185);
            dgvEnrollments.Name = "dgvEnrollments";
            dgvEnrollments.RowHeadersWidth = 62;
            dgvEnrollments.Size = new Size(1068, 417);
            dgvEnrollments.TabIndex = 5;
            // 
            // btnViewDetails
            // 
            btnViewDetails.Location = new Point(39, 625);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(174, 34);
            btnViewDetails.TabIndex = 6;
            btnViewDetails.Text = "VIEW DETAILS";
            btnViewDetails.UseVisualStyleBackColor = true;
            // 
            // btnEnroll
            // 
            btnEnroll.Location = new Point(219, 625);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(174, 34);
            btnEnroll.TabIndex = 7;
            btnEnroll.Text = "ENROLL STUDENT";
            btnEnroll.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(399, 625);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(174, 34);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "CANCEL ENROLLMENT";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // EnrollmentManagementForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 744);
            Controls.Add(btnCancel);
            Controls.Add(btnEnroll);
            Controls.Add(btnViewDetails);
            Controls.Add(dgvEnrollments);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblTitle);
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