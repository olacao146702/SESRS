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
            lblTitle.Font = new Font(
                "Segoe UI",
                20F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblTitle.Location = new Point(35, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(205, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Program";

            // 
            // lblProgramCode
            // 
            lblProgramCode.AutoSize = true;
            lblProgramCode.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblProgramCode.Location = new Point(40, 105);
            lblProgramCode.Name = "lblProgramCode";
            lblProgramCode.Size = new Size(119, 23);
            lblProgramCode.TabIndex = 1;
            lblProgramCode.Text = "Program Code";

            // 
            // txtProgramCode
            // 
            txtProgramCode.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            txtProgramCode.Location = new Point(40, 135);
            txtProgramCode.Name = "txtProgramCode";
            txtProgramCode.Size = new Size(420, 30);
            txtProgramCode.TabIndex = 2;

            // 
            // lblProgramName
            // 
            lblProgramName.AutoSize = true;
            lblProgramName.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblProgramName.Location = new Point(40, 190);
            lblProgramName.Name = "lblProgramName";
            lblProgramName.Size = new Size(123, 23);
            lblProgramName.TabIndex = 3;
            lblProgramName.Text = "Program Name";

            // 
            // txtProgramName
            // 
            txtProgramName.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            txtProgramName.Location = new Point(40, 220);
            txtProgramName.Name = "txtProgramName";
            txtProgramName.Size = new Size(420, 30);
            txtProgramName.TabIndex = 4;

            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblDuration.Location = new Point(40, 275);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(142, 23);
            lblDuration.TabIndex = 5;
            lblDuration.Text = "Duration (Years)";

            // 
            // numDuration
            // 
            numDuration.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            numDuration.Location = new Point(40, 305);
            numDuration.Maximum = new decimal(
                new int[] { 10, 0, 0, 0 }
            );
            numDuration.Minimum = new decimal(
                new int[] { 1, 0, 0, 0 }
            );
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(150, 30);
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
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            btnSave.Location = new Point(250, 375);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 7;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // 
            // btnCancel
            // 
            btnCancel.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            btnCancel.Location = new Point(365, 375);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // 
            // AddProgramForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 450);
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