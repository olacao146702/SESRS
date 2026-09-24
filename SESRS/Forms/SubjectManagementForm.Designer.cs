namespace SESRS.Forms
{
    partial class SubjectManagementForm
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
            dgvSubjects = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDeactivate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
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
            lblTitle.Size = new Size(359, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Subject Management";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.Location = new Point(43, 92);
            lblSearch.Margin = new Padding(2, 0, 2, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(113, 20);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search Subject:";
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
            // dgvSubjects
            // 
            dgvSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubjects.Location = new Point(31, 148);
            dgvSubjects.Margin = new Padding(2, 2, 2, 2);
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.RowHeadersWidth = 62;
            dgvSubjects.Size = new Size(854, 334);
            dgvSubjects.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DarkGreen;
            btnAdd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(31, 500);
            btnAdd.Margin = new Padding(2, 2, 2, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(139, 35);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add Subject";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.DarkGreen;
            btnEdit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(175, 500);
            btnEdit.Margin = new Padding(2, 2, 2, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(139, 35);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit Subject";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDeactivate
            // 
            btnDeactivate.BackColor = Color.DarkGreen;
            btnDeactivate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeactivate.ForeColor = Color.White;
            btnDeactivate.Location = new Point(319, 500);
            btnDeactivate.Margin = new Padding(2, 2, 2, 2);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(139, 35);
            btnDeactivate.TabIndex = 8;
            btnDeactivate.Text = "Deactivate";
            btnDeactivate.UseVisualStyleBackColor = false;
            // 
            // SubjectManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 595);
            Controls.Add(btnDeactivate);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvSubjects);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblTitle);
            Margin = new Padding(2, 2, 2, 2);
            Name = "SubjectManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Subject Management";
            Load += SubjectManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvSubjects;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDeactivate;
    }
}