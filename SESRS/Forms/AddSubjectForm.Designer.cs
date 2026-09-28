namespace SESRS.Forms
{
    partial class AddSubjectForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubjectCode;
        private Label lblSubjectName;
        private Label lblDescription;
        private Label lblUnits;

        private TextBox txtSubjectCode;
        private TextBox txtSubjectName;
        private TextBox txtDescription;
        private NumericUpDown numUnits;

        private Button btnSave;
        private Button btnCancel;

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
            lblSubjectCode = new Label();
            lblSubjectName = new Label();
            lblDescription = new Label();
            lblUnits = new Label();

            txtSubjectCode = new TextBox();
            txtSubjectName = new TextBox();
            txtDescription = new TextBox();
            numUnits = new NumericUpDown();

            btnSave = new Button();
            btnCancel = new Button();

            ((System.ComponentModel.ISupportInitialize)numUnits).BeginInit();
            SuspendLayout();

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font(
                "Segoe UI",
                18F,
                FontStyle.Bold
            );
            lblTitle.Location = new Point(40, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 32);
            lblTitle.Text = "Add Subject";

            // 
            // lblSubjectCode
            // 
            lblSubjectCode.AutoSize = true;
            lblSubjectCode.Location = new Point(40, 95);
            lblSubjectCode.Name = "lblSubjectCode";
            lblSubjectCode.Size = new Size(100, 15);
            lblSubjectCode.Text = "Subject Code:";

            // 
            // txtSubjectCode
            // 
            txtSubjectCode.Location = new Point(40, 115);
            txtSubjectCode.Name = "txtSubjectCode";
            txtSubjectCode.Size = new Size(420, 27);
            txtSubjectCode.TabIndex = 0;

            // 
            // lblSubjectName
            // 
            lblSubjectName.AutoSize = true;
            lblSubjectName.Location = new Point(40, 165);
            lblSubjectName.Name = "lblSubjectName";
            lblSubjectName.Size = new Size(90, 15);
            lblSubjectName.Text = "Subject Name:";

            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(40, 185);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(420, 27);
            txtSubjectName.TabIndex = 1;

            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(40, 235);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(75, 15);
            lblDescription.Text = "Description:";

            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(40, 255);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(420, 70);
            txtDescription.TabIndex = 2;

            // 
            // lblUnits
            // 
            lblUnits.AutoSize = true;
            lblUnits.Location = new Point(40, 350);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new Size(38, 15);
            lblUnits.Text = "Units:";

            // 
            // numUnits
            // 
            numUnits.Location = new Point(40, 370);
            numUnits.Maximum = new decimal(new int[] {
                6,
                0,
                0,
                0
            });
            numUnits.Minimum = new decimal(new int[] {
                1,
                0,
                0,
                0
            });
            numUnits.Name = "numUnits";
            numUnits.Size = new Size(120, 27);
            numUnits.TabIndex = 3;
            numUnits.Value = new decimal(new int[] {
                3,
                0,
                0,
                0
            });

            // 
            // btnSave
            // 
            btnSave.Location = new Point(250, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 4;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(360, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // 
            // AddSubjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 450);

            Controls.Add(btnCancel);
            Controls.Add(btnSave);

            Controls.Add(numUnits);
            Controls.Add(lblUnits);

            Controls.Add(txtDescription);
            Controls.Add(lblDescription);

            Controls.Add(txtSubjectName);
            Controls.Add(lblSubjectName);

            Controls.Add(txtSubjectCode);
            Controls.Add(lblSubjectCode);

            Controls.Add(lblTitle);

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "AddSubjectForm";
            Text = "Add Subject";

            ((System.ComponentModel.ISupportInitialize)numUnits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}