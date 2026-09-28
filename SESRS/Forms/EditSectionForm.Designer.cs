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

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font(
                "Segoe UI",
                16F,
                FontStyle.Bold
            );
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(165, 30);
            lblTitle.Text = "Edit Section";

            // lblSectionCode
            lblSectionCode.AutoSize = true;
            lblSectionCode.Location = new Point(30, 80);
            lblSectionCode.Text = "Section Code:";

            // txtSectionCode
            txtSectionCode.Location = new Point(160, 76);
            txtSectionCode.Size = new Size(310, 27);

            // lblSectionName
            lblSectionName.AutoSize = true;
            lblSectionName.Location = new Point(30, 120);
            lblSectionName.Text = "Section Name:";

            // txtSectionName
            txtSectionName.Location = new Point(160, 116);
            txtSectionName.Size = new Size(310, 27);

            // lblProgram
            lblProgram.AutoSize = true;
            lblProgram.Location = new Point(30, 160);
            lblProgram.Text = "Program:";

            // cmbProgram
            cmbProgram.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Location = new Point(160, 156);
            cmbProgram.Size = new Size(310, 28);

            // lblYearLevel
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(30, 200);
            lblYearLevel.Text = "Year Level:";

            // cmbYearLevel
            cmbYearLevel.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(160, 196);
            cmbYearLevel.Size = new Size(310, 28);

            // lblSemester
            lblSemester.AutoSize = true;
            lblSemester.Location = new Point(30, 240);
            lblSemester.Text = "Semester:";

            // cmbSemester
            cmbSemester.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cmbSemester.FormattingEnabled = true;
            cmbSemester.Location = new Point(160, 236);
            cmbSemester.Size = new Size(310, 28);

            // lblSchoolYear
            lblSchoolYear.AutoSize = true;
            lblSchoolYear.Location = new Point(30, 280);
            lblSchoolYear.Text = "School Year:";

            // txtSchoolYear
            txtSchoolYear.Location = new Point(160, 276);
            txtSchoolYear.Size = new Size(310, 27);

            // lblCapacity
            lblCapacity.AutoSize = true;
            lblCapacity.Location = new Point(30, 320);
            lblCapacity.Text = "Capacity:";

            // numCapacity
            numCapacity.Location = new Point(160, 316);
            numCapacity.Minimum = 1;
            numCapacity.Maximum = 200;
            numCapacity.Value = 40;
            numCapacity.Size = new Size(120, 27);

            // btnSave
            btnSave.Location = new Point(160, 375);
            btnSave.Size = new Size(120, 35);
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // btnCancel
            btnCancel.Location = new Point(300, 375);
            btnCancel.Size = new Size(120, 35);
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // EditSectionForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 450);
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
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Section";

            ((System.ComponentModel.ISupportInitialize)numCapacity).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}