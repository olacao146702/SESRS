namespace SESRS.Forms
{
    partial class ProgramManagementForm
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
            lblProgramCode = new Label();
            lblProgramName = new Label();
            lblDuration = new Label();
            txtProgramCode = new TextBox();
            txtProgramName = new TextBox();
            txtDuration = new TextBox();
            lblYears = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDeactivate = new Button();
            btnClear = new Button();
            dgvPrograms = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPrograms).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(239, 59);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(310, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "PROGRAM MANAGEMENT";
            // 
            // lblProgramCode
            // 
            lblProgramCode.AutoSize = true;
            lblProgramCode.Location = new Point(68, 149);
            lblProgramCode.Name = "lblProgramCode";
            lblProgramCode.Size = new Size(116, 20);
            lblProgramCode.TabIndex = 1;
            lblProgramCode.Text = "Program Code : ";
            // 
            // lblProgramName
            // 
            lblProgramName.AutoSize = true;
            lblProgramName.Location = new Point(68, 182);
            lblProgramName.Name = "lblProgramName";
            lblProgramName.Size = new Size(121, 20);
            lblProgramName.TabIndex = 2;
            lblProgramName.Text = "Program Name : ";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(68, 221);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(78, 20);
            lblDuration.TabIndex = 3;
            lblDuration.Text = "Duration : ";
            // 
            // txtProgramCode
            // 
            txtProgramCode.Location = new Point(205, 142);
            txtProgramCode.Name = "txtProgramCode";
            txtProgramCode.Size = new Size(324, 27);
            txtProgramCode.TabIndex = 4;
            // 
            // txtProgramName
            // 
            txtProgramName.Location = new Point(205, 179);
            txtProgramName.Name = "txtProgramName";
            txtProgramName.Size = new Size(324, 27);
            txtProgramName.TabIndex = 5;
            // 
            // txtDuration
            // 
            txtDuration.Location = new Point(205, 218);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new Size(164, 27);
            txtDuration.TabIndex = 6;
            // 
            // lblYears
            // 
            lblYears.AutoSize = true;
            lblYears.Location = new Point(395, 221);
            lblYears.Name = "lblYears";
            lblYears.Size = new Size(47, 20);
            lblYears.TabIndex = 7;
            lblYears.Text = "Years ";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(68, 281);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(99, 49);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(188, 281);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 49);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDeactivate
            // 
            btnDeactivate.Location = new Point(308, 281);
            btnDeactivate.Name = "btnDeactivate";
            btnDeactivate.Size = new Size(99, 49);
            btnDeactivate.TabIndex = 10;
            btnDeactivate.Text = "Deactivate";
            btnDeactivate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(430, 281);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(99, 49);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // dgvPrograms
            // 
            dgvPrograms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrograms.Location = new Point(90, 353);
            dgvPrograms.Name = "dgvPrograms";
            dgvPrograms.RowHeadersWidth = 51;
            dgvPrograms.Size = new Size(590, 188);
            dgvPrograms.TabIndex = 12;
            // 
            // ProgramManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(dgvPrograms);
            Controls.Add(btnClear);
            Controls.Add(btnDeactivate);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblYears);
            Controls.Add(txtDuration);
            Controls.Add(txtProgramName);
            Controls.Add(txtProgramCode);
            Controls.Add(lblDuration);
            Controls.Add(lblProgramName);
            Controls.Add(lblProgramCode);
            Controls.Add(lblTitle);
            Name = "ProgramManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Program Management";
            ((System.ComponentModel.ISupportInitialize)dgvPrograms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblProgramCode;
        private Label lblProgramName;
        private Label lblDuration;
        private TextBox txtProgramCode;
        private TextBox txtProgramName;
        private TextBox txtDuration;
        private Label lblYears;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDeactivate;
        private Button btnClear;
        private DataGridView dgvPrograms;
    }
}