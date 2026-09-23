namespace SESRS.Forms
{
    partial class StudentManagementForm
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
            dgvStudents = new DataGridView();
            btnEdit = new Button();
            btnDeactivate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(54, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(183, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Student Management";
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
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(39, 185);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 62;
            dgvStudents.Size = new Size(1068, 417);
            dgvStudents.TabIndex = 5;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(753, 625);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(174, 34);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "EDIT STUDENT";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDeactivate
            // 
            btnDeactivate.Location = new Point(933, 625);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(174, 34);
            btnDeactivate.TabIndex = 7;
            btnDeactivate.Text = "DEACTIVATE";
            btnDeactivate.UseVisualStyleBackColor = true;
            // 
            // StudentManagementForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 744);
            Controls.Add(btnDeactivate);
            Controls.Add(btnEdit);
            Controls.Add(dgvStudents);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblTitle);
            Name = "StudentManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Management";
            Load += StudentManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvStudents;
        private Button btnEdit;
        private Button btnDeactivate;
    }
}