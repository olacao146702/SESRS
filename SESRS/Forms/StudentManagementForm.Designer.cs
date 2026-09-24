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
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(31, 9);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(366, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Student Management";
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
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(31, 148);
            dgvStudents.Margin = new Padding(2, 2, 2, 2);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 62;
            dgvStudents.Size = new Size(854, 334);
            dgvStudents.TabIndex = 5;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.DarkGreen;
            btnEdit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(602, 500);
            btnEdit.Margin = new Padding(2, 2, 2, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(139, 35);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Edit Student";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDeactivate
            // 
            btnDeactivate.BackColor = Color.DarkGreen;
            btnDeactivate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeactivate.ForeColor = Color.White;
            btnDeactivate.Location = new Point(746, 500);
            btnDeactivate.Margin = new Padding(2, 2, 2, 2);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(139, 35);
            btnDeactivate.TabIndex = 7;
            btnDeactivate.Text = "Deactivate";
            btnDeactivate.UseVisualStyleBackColor = false;
            // 
            // StudentManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 595);
            Controls.Add(btnDeactivate);
            Controls.Add(btnEdit);
            Controls.Add(dgvStudents);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblTitle);
            Margin = new Padding(2, 2, 2, 2);
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