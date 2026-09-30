namespace SESRS.Forms
{
    partial class AddProgramForm
    {
        private System.ComponentModel.IContainer components = null;

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
            lblProgramCode = new Label();
            txtProgramCode = new TextBox();
            lblProgramName = new Label();
            txtProgramName = new TextBox();
            lblDuration = new Label();
            numDuration = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(24, 82, 58);
            lblTitle.Location = new Point(28, 20);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(235, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Program";
            // 
            // lblProgramCode
            // 
            lblProgramCode.AutoSize = true;
            lblProgramCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProgramCode.ForeColor = Color.FromArgb(90, 100, 95);
            lblProgramCode.Location = new Point(32, 84);
            lblProgramCode.Margin = new Padding(2, 0, 2, 0);
            lblProgramCode.Name = "lblProgramCode";
            lblProgramCode.Size = new Size(126, 23);
            lblProgramCode.TabIndex = 1;
            lblProgramCode.Text = "Program Code";
            // 
            // txtProgramCode
            // 
            txtProgramCode.Font = new Font("Segoe UI", 10F);
            txtProgramCode.Location = new Point(32, 108);
            txtProgramCode.Margin = new Padding(2, 2, 2, 2);
            txtProgramCode.Name = "txtProgramCode";
            txtProgramCode.Size = new Size(337, 30);
            txtProgramCode.TabIndex = 2;
            // 
            // lblProgramName
            // 
            lblProgramName.AutoSize = true;
            lblProgramName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProgramName.ForeColor = Color.FromArgb(90, 100, 95);
            lblProgramName.Location = new Point(32, 152);
            lblProgramName.Margin = new Padding(2, 0, 2, 0);
            lblProgramName.Name = "lblProgramName";
            lblProgramName.Size = new Size(132, 23);
            lblProgramName.TabIndex = 3;
            lblProgramName.Text = "Program Name";
            // 
            // txtProgramName
            // 
            txtProgramName.Font = new Font("Segoe UI", 10F);
            txtProgramName.Location = new Point(32, 176);
            txtProgramName.Margin = new Padding(2, 2, 2, 2);
            txtProgramName.Name = "txtProgramName";
            txtProgramName.Size = new Size(337, 30);
            txtProgramName.TabIndex = 4;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDuration.ForeColor = Color.FromArgb(90, 100, 95);
            lblDuration.Location = new Point(32, 220);
            lblDuration.Margin = new Padding(2, 0, 2, 0);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(138, 23);
            lblDuration.TabIndex = 5;
            lblDuration.Text = "Duration (Years)";
            // 
            // numDuration
            // 
            numDuration.Font = new Font("Segoe UI", 10F);
            numDuration.Location = new Point(32, 244);
            numDuration.Margin = new Padding(2, 2, 2, 2);
            numDuration.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(120, 30);
            numDuration.TabIndex = 6;
            numDuration.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(24, 82, 58);
            btnSave.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(197, 300);
            btnSave.Margin = new Padding(2, 2, 2, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 40);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(24, 82, 58);
            btnCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(301, 300);
            btnCancel.Margin = new Padding(2, 2, 2, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 40);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddProgramForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 360);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numDuration);
            Controls.Add(lblDuration);
            Controls.Add(txtProgramName);
            Controls.Add(lblProgramName);
            Controls.Add(txtProgramCode);
            Controls.Add(lblProgramCode);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProgramForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Program";
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblProgramCode;
        private TextBox txtProgramCode;
        private Label lblProgramName;
        private TextBox txtProgramName;
        private Label lblDuration;
        private NumericUpDown numDuration;
        private Button btnSave;
        private Button btnCancel;
    }
}