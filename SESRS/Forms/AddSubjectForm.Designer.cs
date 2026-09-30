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
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(24, 82, 58);
            lblTitle.Location = new Point(46, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(190, 41);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "Add Subject";
            // 
            // lblSubjectCode
            // 
            lblSubjectCode.AutoSize = true;
            lblSubjectCode.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubjectCode.ForeColor = Color.FromArgb(90, 100, 95);
            lblSubjectCode.Location = new Point(46, 127);
            lblSubjectCode.Name = "lblSubjectCode";
            lblSubjectCode.Size = new Size(115, 23);
            lblSubjectCode.TabIndex = 9;
            lblSubjectCode.Text = "Subject Code:";
            // 
            // lblSubjectName
            // 
            lblSubjectName.AutoSize = true;
            lblSubjectName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubjectName.ForeColor = Color.FromArgb(90, 100, 95);
            lblSubjectName.Location = new Point(46, 220);
            lblSubjectName.Name = "lblSubjectName";
            lblSubjectName.Size = new Size(121, 23);
            lblSubjectName.TabIndex = 8;
            lblSubjectName.Text = "Subject Name:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescription.ForeColor = Color.FromArgb(90, 100, 95);
            lblDescription.Location = new Point(46, 313);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 23);
            lblDescription.TabIndex = 7;
            lblDescription.Text = "Description:";
            // 
            // lblUnits
            // 
            lblUnits.AutoSize = true;
            lblUnits.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnits.ForeColor = Color.FromArgb(90, 100, 95);
            lblUnits.Location = new Point(46, 467);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new Size(53, 23);
            lblUnits.TabIndex = 6;
            lblUnits.Text = "Units:";
            // 
            // txtSubjectCode
            // 
            txtSubjectCode.Location = new Point(46, 153);
            txtSubjectCode.Margin = new Padding(3, 4, 3, 4);
            txtSubjectCode.Name = "txtSubjectCode";
            txtSubjectCode.Size = new Size(479, 27);
            txtSubjectCode.TabIndex = 0;
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(46, 247);
            txtSubjectName.Margin = new Padding(3, 4, 3, 4);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(479, 27);
            txtSubjectName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(46, 340);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(479, 92);
            txtDescription.TabIndex = 2;
            // 
            // numUnits
            // 
            numUnits.Location = new Point(46, 493);
            numUnits.Margin = new Padding(3, 4, 3, 4);
            numUnits.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numUnits.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numUnits.Name = "numUnits";
            numUnits.Size = new Size(137, 27);
            numUnits.TabIndex = 3;
            numUnits.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(24, 82, 58);
            btnSave.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(286, 493);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 47);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(24, 82, 58);
            btnCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(411, 493);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 47);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddSubjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 600);
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
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddSubjectForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Subject";
            ((System.ComponentModel.ISupportInitialize)numUnits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}