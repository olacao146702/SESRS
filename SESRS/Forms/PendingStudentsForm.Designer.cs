namespace SESRS.Forms
{
    partial class PendingStudentsForm
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
            dgvPendingStudents = new DataGridView();
            btnApprove = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPendingStudents).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(342, 24);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(261, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Pending Student Accounts";
            // 
            // dgvPendingStudents
            // 
            dgvPendingStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendingStudents.Location = new Point(1, 67);
            dgvPendingStudents.Margin = new Padding(2, 2, 2, 2);
            dgvPendingStudents.Name = "dgvPendingStudents";
            dgvPendingStudents.RowHeadersWidth = 62;
            dgvPendingStudents.Size = new Size(942, 515);
            dgvPendingStudents.TabIndex = 1;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.DarkGreen;
            btnApprove.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(370, 410);
            btnApprove.Margin = new Padding(2, 2, 2, 2);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(182, 49);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "Approve Student";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // PendingStudentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 515);
            Controls.Add(btnApprove);
            Controls.Add(lblTitle);
            Controls.Add(dgvPendingStudents);
            Margin = new Padding(2, 2, 2, 2);
            Name = "PendingStudentsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pending Student Accounts";
            Load += PendingStudentsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPendingStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvPendingStudents;
        private Button btnApprove;
    }
}