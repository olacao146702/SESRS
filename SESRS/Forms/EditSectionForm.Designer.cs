namespace SESRS.Forms
{
    partial class EditSectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSectionCode;
        private System.Windows.Forms.Label lblSectionName;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.Label lblYearLevel;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.Label lblCapacity;

        private System.Windows.Forms.TextBox txtSectionCode;
        private System.Windows.Forms.TextBox txtSectionName;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.TextBox txtSchoolYear;
        private System.Windows.Forms.NumericUpDown numCapacity;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(24, 82, 58);
            lblTitle.Location = new Point(34, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(169, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Edit Section";
            // 
            // lblSectionCode
            // 
            lblSectionCode.AutoSize = true;
            lblSectionCode.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSectionCode.ForeColor = Color.FromArgb(90, 100, 95);
            lblSectionCode.Location = new Point(34, 107);
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
            lblSectionName.Location = new Point(34, 160);
            lblSectionName.Name = "lblSectionName";
            lblSectionName.Size = new Size(121, 23);
            lblSectionName.TabIndex = 3;
            lblSectionName.Text = "Section Name:";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgram.ForeColor = Color.FromArgb(90, 100, 95);
            lblProgram.Location = new Point(34, 213);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(80, 23);
            lblProgram.TabIndex = 5;
            lblProgram.Text = "Program:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYearLevel.ForeColor = Color.FromArgb(90, 100, 95);
            lblYearLevel.Location = new Point(34, 267);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(90, 23);
            lblYearLevel.TabIndex = 7;
            lblYearLevel.Text = "Year Level:";
            // 
            // lblSemester
            // 
            lblSemester.AutoSize = true;
            lblSemester.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSemester.ForeColor = Color.FromArgb(90, 100, 95);
            lblSemester.Location = new Point(34, 320);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(85, 23);
            lblSemester.TabIndex = 9;
            lblSemester.Text = "Semester:";
            // 
            // lblSchoolYear
            // 
            lblSchoolYear.AutoSize = true;
            lblSchoolYear.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSchoolYear.ForeColor = Color.FromArgb(90, 100, 95);
            lblSchoolYear.Location = new Point(34, 373);
            lblSchoolYear.Name = "lblSchoolYear";
            lblSchoolYear.Size = new Size(103, 23);
            lblSchoolYear.TabIndex = 11;
            lblSchoolYear.Text = "School Year:";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCapacity.ForeColor = Color.FromArgb(90, 100, 95);
            lblCapacity.Location = new Point(34, 427);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(80, 23);
            lblCapacity.TabIndex = 13;
            lblCapacity.Text = "Capacity:";
            // 
            // txtSectionCode
            // 
            txtSectionCode.Location = new Point(183, 101);
            txtSectionCode.Margin = new Padding(3, 4, 3, 4);
            txtSectionCode.Name = "txtSectionCode";
            txtSectionCode.Size = new Size(354, 27);
            txtSectionCode.TabIndex = 2;
            // 
            // txtSectionName
            // 
            txtSectionName.Location = new Point(183, 155);
            txtSectionName.Margin = new Padding(3, 4, 3, 4);
            txtSectionName.Name = "txtSectionName";
            txtSectionName.Size = new Size(354, 27);
            txtSectionName.TabIndex = 4;
            // 
            // cmbProgram
            // 
            cmbProgram.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Location = new Point(183, 208);
            cmbProgram.Margin = new Padding(3, 4, 3, 4);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(354, 28);
            cmbProgram.TabIndex = 6;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(183, 261);
            cmbYearLevel.Margin = new Padding(3, 4, 3, 4);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(354, 28);
            cmbYearLevel.TabIndex = 8;
            // 
            // cmbSemester
            // 
            cmbSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSemester.FormattingEnabled = true;
            cmbSemester.Location = new Point(183, 315);
            cmbSemester.Margin = new Padding(3, 4, 3, 4);
            cmbSemester.Name = "cmbSemester";
            cmbSemester.Size = new Size(354, 28);
            cmbSemester.TabIndex = 10;
            // 
            // txtSchoolYear
            // 
            txtSchoolYear.Location = new Point(183, 368);
            txtSchoolYear.Margin = new Padding(3, 4, 3, 4);
            txtSchoolYear.Name = "txtSchoolYear";
            txtSchoolYear.Size = new Size(354, 27);
            txtSchoolYear.TabIndex = 12;
            // 
            // numCapacity
            // 
            numCapacity.Location = new Point(183, 421);
            numCapacity.Margin = new Padding(3, 4, 3, 4);
            numCapacity.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCapacity.Name = "numCapacity";
            numCapacity.Size = new Size(137, 27);
            numCapacity.TabIndex = 14;
            numCapacity.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(24, 82, 58);
            btnSave.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(183, 500);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 47);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(24, 82, 58);
            btnCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(343, 500);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(137, 47);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // EditSectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 600);
            Controls.Add(lblTitle);
            Controls.Add(lblSectionCode);
            Controls.Add(txtSectionCode);
            Controls.Add(lblSectionName);
            Controls.Add(txtSectionName);
            Controls.Add(lblProgram);
            Controls.Add(cmbProgram);
            Controls.Add(lblYearLevel);
            Controls.Add(cmbYearLevel);
            Controls.Add(lblSemester);
            Controls.Add(cmbSemester);
            Controls.Add(lblSchoolYear);
            Controls.Add(txtSchoolYear);
            Controls.Add(lblCapacity);
            Controls.Add(numCapacity);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditSectionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Section";
            ((System.ComponentModel.ISupportInitialize)numCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}