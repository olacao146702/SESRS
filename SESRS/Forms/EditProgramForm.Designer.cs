namespace SESRS.Forms
{
    partial class EditProgramForm
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
            lblTitle.Font = new Font(
                "Segoe UI",
                20F,
                FontStyle.Bold
            );
            lblTitle.Location = new Point(35, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Edit Program";

            // 
            // lblProgramCode
            // 
            lblProgramCode.AutoSize = true;
            lblProgramCode.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            lblProgramCode.Location = new Point(40, 95);
            lblProgramCode.Name = "lblProgramCode";
            lblProgramCode.Size = new Size(108, 19);
            lblProgramCode.TabIndex = 1;
            lblProgramCode.Text = "Program Code";

            // 
            // txtProgramCode
            // 
            txtProgramCode.Font = new Font(
                "Segoe UI",
                10F
            );
            txtProgramCode.Location = new Point(40, 120);
            txtProgramCode.Name = "txtProgramCode";
            txtProgramCode.Size = new Size(420, 25);
            txtProgramCode.TabIndex = 2;

            // 
            // lblProgramName
            // 
            lblProgramName.AutoSize = true;
            lblProgramName.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            lblProgramName.Location = new Point(40, 165);
            lblProgramName.Name = "lblProgramName";
            lblProgramName.Size = new Size(110, 19);
            lblProgramName.TabIndex = 3;
            lblProgramName.Text = "Program Name";

            // 
            // txtProgramName
            // 
            txtProgramName.Font = new Font(
                "Segoe UI",
                10F
            );
            txtProgramName.Location = new Point(40, 190);
            txtProgramName.Name = "txtProgramName";
            txtProgramName.Size = new Size(420, 25);
            txtProgramName.TabIndex = 4;

            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            lblDuration.Location = new Point(40, 235);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(117, 19);
            lblDuration.TabIndex = 5;
            lblDuration.Text = "Duration (Years)";

            // 
            // numDuration
            // 
            numDuration.Font = new Font(
                "Segoe UI",
                10F
            );
            numDuration.Location = new Point(40, 260);
            numDuration.Maximum = new decimal(
                new int[] { 10, 0, 0, 0 }
            );
            numDuration.Minimum = new decimal(
                new int[] { 1, 0, 0, 0 }
            );
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(150, 25);
            numDuration.TabIndex = 6;
            numDuration.Value = new decimal(
                new int[] { 4, 0, 0, 0 }
            );

            // 
            // btnSave
            // 
            btnSave.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnSave.Location = new Point(250, 330);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 7;
            btnSave.Text = "SAVE CHANGES";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // 
            // btnCancel
            // 
            btnCancel.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold
            );
            btnCancel.Location = new Point(385, 330);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // 
            // EditProgramForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 410);
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
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditProgramForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Program";

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