namespace SESRS.Forms
{
    partial class ProgramManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvPrograms;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDeactivate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            dgvPrograms = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDeactivate = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvPrograms).BeginInit();
            SuspendLayout();

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(260, 32);
            lblTitle.Text = "Program Management";

            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(30, 80);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 27);
            txtSearch.KeyDown += txtSearch_KeyDown;

            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(345, 78);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 32);
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;

            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(455, 78);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 32);
            btnRefresh.Text = "REFRESH";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;

            // 
            // dgvPrograms
            // 
            dgvPrograms.AllowUserToAddRows = false;
            dgvPrograms.AllowUserToDeleteRows = false;
            dgvPrograms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrograms.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrograms.Location = new Point(30, 125);
            dgvPrograms.Name = "dgvPrograms";
            dgvPrograms.ReadOnly = true;
            dgvPrograms.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvPrograms.MultiSelect = false;
            dgvPrograms.Size = new Size(920, 450);

            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(580, 78);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 32);
            btnAdd.Text = "ADD PROGRAM";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(720, 78);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 32);
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDeactivate
            // 
            btnDeactivate.Location = new Point(830, 78);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(120, 32);
            btnDeactivate.Text = "DEACTIVATE";
            btnDeactivate.UseVisualStyleBackColor = true;
            btnDeactivate.Click += btnDeactivate_Click;

            // 
            // ProgramManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 620);
            Controls.Add(btnDeactivate);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvPrograms);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblTitle);
            Name = "ProgramManagementForm";
            Text = "Program Management";
            Load += ProgramManagementForm_Load;

            ((System.ComponentModel.ISupportInitialize)dgvPrograms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}