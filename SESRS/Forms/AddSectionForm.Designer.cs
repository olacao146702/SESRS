namespace SESRS.Forms
{
    partial class AddSectionForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSectionCode;
        private Label lblSectionName;
        private Label lblProgram;
        private Label lblYearLevel;
        private Label lblSemester;
        private Label lblSchoolYear;
        private Label lblCapacity;

        private TextBox txtSectionCode;
        private TextBox txtSectionName;
        private ComboBox cmbProgram;
        private ComboBox cmbYearLevel;
        private ComboBox cmbSemester;
        private TextBox txtSchoolYear;
        private NumericUpDown numCapacity;

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

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSectionCode = new Label();
            lblSectionName = new Label();
            lblProgram = new Label();
            lblYearLevel = new Label();
            lblSemester = new Label();
            lblSchoolYear = new Label();
            lblCapacity = new Label();
            txtSectionCode = new TextBox();
            txtSectionName = new TextBox();
            cmbProgram = new ComboBox();
            cmbYearLevel = new ComboBox();
            cmbSemester = new ComboBox();
            txtSchoolYear = new TextBox();
            numCapacity = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numCapacity).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(24, 82, 58);
            lblTitle.Location = new Point(46, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(189, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Section";
            // 
            // lblSectionCode
            // 
            lblSectionCode.AutoSize = true;
            lblSectionCode.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSectionCode.ForeColor = Color.FromArgb(90, 100, 95);
            lblSectionCode.Location = new Point(46, 107);
            lblSectionCode.Name = "lblSectionCode";
            lblSectionCode.Size = new Size(115, 23);
            lblSectionCode.TabIndex = 1;
            lblSectionCode.Text = "Section Code:";
            // 
            // lblSectionName
            // 
            lblSectionName.AutoSize = true;
            lblSectionName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSectionName.ForeColor = Color.FromArgb(90, 100, 95);
            lblSectionName.Location = new Point(46, 193);
            lblSectionName.Name = "lblSectionName";
            lblSectionName.Size = new Size(121, 23);
            lblSectionName.TabIndex = 2;
            lblSectionName.Text = "Section Name:";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgram.ForeColor = Color.FromArgb(90, 100, 95);
            lblProgram.Location = new Point(46, 280);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(80, 23);
            lblProgram.TabIndex = 3;
            lblProgram.Text = "Program:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYearLevel.ForeColor = Color.FromArgb(90, 100, 95);
            lblYearLevel.Location = new Point(46, 367);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(90, 23);
            lblYearLevel.TabIndex = 4;
            lblYearLevel.Text = "Year Level:";
            // 
            // lblSemester
            // 
            lblSemester.AutoSize = true;
            lblSemester.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSemester.ForeColor = Color.FromArgb(90, 100, 95);
            lblSemester.Location = new Point(309, 367);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(85, 23);
            lblSemester.TabIndex = 5;
            lblSemester.Text = "Semester:";
            // 
            // lblSchoolYear
            // 
            lblSchoolYear.AutoSize = true;
            lblSchoolYear.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSchoolYear.ForeColor = Color.FromArgb(90, 100, 95);
            lblSchoolYear.Location = new Point(46, 453);
            lblSchoolYear.Name = "lblSchoolYear";
            lblSchoolYear.Size = new Size(103, 23);
            lblSchoolYear.TabIndex = 6;
            lblSchoolYear.Text = "School Year:";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCapacity.ForeColor = Color.FromArgb(90, 100, 95);
            lblCapacity.Location = new Point(309, 453);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(80, 23);
            lblCapacity.TabIndex = 7;
            lblCapacity.Text = "Capacity:";
            // 
            // txtSectionCode
            // 
            txtSectionCode.Location = new Point(46, 133);
            txtSectionCode.Margin = new Padding(3, 4, 3, 4);
            txtSectionCode.Name = "txtSectionCode";
            txtSectionCode.Size = new Size(479, 27);
            txtSectionCode.TabIndex = 0;
            // 
            // txtSectionName
            // 
            txtSectionName.Location = new Point(46, 220);
            txtSectionName.Margin = new Padding(3, 4, 3, 4);
            txtSectionName.Name = "txtSectionName";
            txtSectionName.Size = new Size(479, 27);
            txtSectionName.TabIndex = 1;
            // 
            // cmbProgram
            // 
            cmbProgram.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Location = new Point(46, 307);
            cmbProgram.Margin = new Padding(3, 4, 3, 4);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(479, 28);
            cmbProgram.TabIndex = 2;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(46, 393);
            cmbYearLevel.Margin = new Padding(3, 4, 3, 4);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(217, 28);
            cmbYearLevel.TabIndex = 3;
            // 
            // cmbSemester
            // 
            cmbSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSemester.FormattingEnabled = true;
            cmbSemester.Location = new Point(309, 393);
            cmbSemester.Margin = new Padding(3, 4, 3, 4);
            cmbSemester.Name = "cmbSemester";
            cmbSemester.Size = new Size(217, 28);
            cmbSemester.TabIndex = 4;
            // 
            // txtSchoolYear
            // 
            txtSchoolYear.Location = new Point(46, 480);
            txtSchoolYear.Margin = new Padding(3, 4, 3, 4);
            txtSchoolYear.Name = "txtSchoolYear";
            txtSchoolYear.Size = new Size(217, 27);
            txtSchoolYear.TabIndex = 5;
            // 
            // numCapacity
            // 
            numCapacity.Location = new Point(309, 480);
            numCapacity.Margin = new Padding(3, 4, 3, 4);
            numCapacity.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCapacity.Name = "numCapacity";
            numCapacity.Size = new Size(217, 27);
            numCapacity.TabIndex = 6;
            numCapacity.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(24, 82, 58);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(286, 547);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 47);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(24, 82, 58);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(411, 547);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 47);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddSectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 640);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numCapacity);
            Controls.Add(lblCapacity);
            Controls.Add(txtSchoolYear);
            Controls.Add(lblSchoolYear);
            Controls.Add(cmbSemester);
            Controls.Add(lblSemester);
            Controls.Add(cmbYearLevel);
            Controls.Add(lblYearLevel);
            Controls.Add(cmbProgram);
            Controls.Add(lblProgram);
            Controls.Add(txtSectionName);
            Controls.Add(lblSectionName);
            Controls.Add(txtSectionCode);
            Controls.Add(lblSectionCode);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddSectionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Section";
            ((System.ComponentModel.ISupportInitialize)numCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}