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
            lblTitle.Font = new Font(
                "Segoe UI",
                18F,
                FontStyle.Bold
            );
            lblTitle.Location = new Point(40, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(175, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Section";

            // 
            // lblSectionCode
            // 
            lblSectionCode.AutoSize = true;
            lblSectionCode.Location = new Point(40, 80);
            lblSectionCode.Name = "lblSectionCode";
            lblSectionCode.Size = new Size(82, 15);
            lblSectionCode.TabIndex = 1;
            lblSectionCode.Text = "Section Code:";

            // 
            // txtSectionCode
            // 
            txtSectionCode.Location = new Point(40, 100);
            txtSectionCode.Name = "txtSectionCode";
            txtSectionCode.Size = new Size(420, 27);
            txtSectionCode.TabIndex = 0;

            // 
            // lblSectionName
            // 
            lblSectionName.AutoSize = true;
            lblSectionName.Location = new Point(40, 145);
            lblSectionName.Name = "lblSectionName";
            lblSectionName.Size = new Size(86, 15);
            lblSectionName.TabIndex = 2;
            lblSectionName.Text = "Section Name:";

            // 
            // txtSectionName
            // 
            txtSectionName.Location = new Point(40, 165);
            txtSectionName.Name = "txtSectionName";
            txtSectionName.Size = new Size(420, 27);
            txtSectionName.TabIndex = 1;

            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Location = new Point(40, 210);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(56, 15);
            lblProgram.TabIndex = 3;
            lblProgram.Text = "Program:";

            // 
            // cmbProgram
            // 
            cmbProgram.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbProgram.FormattingEnabled = true;
            cmbProgram.Location = new Point(40, 230);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(420, 27);
            cmbProgram.TabIndex = 2;

            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(40, 275);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(68, 15);
            lblYearLevel.TabIndex = 4;
            lblYearLevel.Text = "Year Level:";

            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(40, 295);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(190, 27);
            cmbYearLevel.TabIndex = 3;

            // 
            // lblSemester
            // 
            lblSemester.AutoSize = true;
            lblSemester.Location = new Point(270, 275);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(61, 15);
            lblSemester.TabIndex = 5;
            lblSemester.Text = "Semester:";

            // 
            // cmbSemester
            // 
            cmbSemester.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbSemester.FormattingEnabled = true;
            cmbSemester.Location = new Point(270, 295);
            cmbSemester.Name = "cmbSemester";
            cmbSemester.Size = new Size(190, 27);
            cmbSemester.TabIndex = 4;

            // 
            // lblSchoolYear
            // 
            lblSchoolYear.AutoSize = true;
            lblSchoolYear.Location = new Point(40, 340);
            lblSchoolYear.Name = "lblSchoolYear";
            lblSchoolYear.Size = new Size(72, 15);
            lblSchoolYear.TabIndex = 6;
            lblSchoolYear.Text = "School Year:";

            // 
            // txtSchoolYear
            // 
            txtSchoolYear.Location = new Point(40, 360);
            txtSchoolYear.Name = "txtSchoolYear";
            txtSchoolYear.Size = new Size(190, 27);
            txtSchoolYear.TabIndex = 5;

            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Location = new Point(270, 340);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(57, 15);
            lblCapacity.TabIndex = 7;
            lblCapacity.Text = "Capacity:";

            // 
            // numCapacity
            // 
            numCapacity.Location = new Point(270, 360);
            numCapacity.Maximum =
                new decimal(new int[] { 200, 0, 0, 0 });

            numCapacity.Minimum =
                new decimal(new int[] { 1, 0, 0, 0 });

            numCapacity.Name = "numCapacity";
            numCapacity.Size = new Size(190, 27);
            numCapacity.TabIndex = 6;
            numCapacity.Value =
                new decimal(new int[] { 40, 0, 0, 0 });

            // 
            // btnSave
            // 
            btnSave.Location = new Point(250, 410);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 7;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(360, 410);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // 
            // AddSectionForm
            // 
            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(520, 480);

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

            FormBorderStyle =
                FormBorderStyle.FixedDialog;

            MaximizeBox = false;
            MinimizeBox = false;

            StartPosition =
                FormStartPosition.CenterParent;

            Name = "AddSectionForm";
            Text = "Add Section";

            ((System.ComponentModel.ISupportInitialize)numCapacity).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}