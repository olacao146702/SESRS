namespace SESRS.Forms
{
    partial class SectionEditDialog
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
            this.lblIntro = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.txtSchoolYear = new System.Windows.Forms.TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.nudCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Location = new System.Drawing.Point(24, 20);
            this.lblIntro.Size = new System.Drawing.Size(392, 36);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "Capacity is the number of students allowed in each subject of the section.";
            this.lblIntro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.ForeColor = System.Drawing.Color.DimGray;
            // 
            // lblCode
            // 
            this.lblCode.Name = "lblCode";
            this.lblCode.Location = new System.Drawing.Point(24, 66);
            this.lblCode.Size = new System.Drawing.Size(190, 20);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Section code (e.g. BSIT-1A) *";
            // 
            // txtCode
            // 
            this.txtCode.Name = "txtCode";
            this.txtCode.Location = new System.Drawing.Point(24, 88);
            this.txtCode.Size = new System.Drawing.Size(190, 23);
            this.txtCode.TabIndex = 2;
            this.txtCode.MaxLength = 30;
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.Location = new System.Drawing.Point(226, 66);
            this.lblName.Size = new System.Drawing.Size(190, 20);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Section name *";
            // 
            // txtName
            // 
            this.txtName.Name = "txtName";
            this.txtName.Location = new System.Drawing.Point(226, 88);
            this.txtName.Size = new System.Drawing.Size(190, 23);
            this.txtName.TabIndex = 4;
            this.txtName.MaxLength = 100;
            // 
            // lblProgram
            // 
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Location = new System.Drawing.Point(24, 125);
            this.lblProgram.Size = new System.Drawing.Size(392, 20);
            this.lblProgram.TabIndex = 5;
            this.lblProgram.Text = "Program *";
            // 
            // cmbProgram
            // 
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(24, 147);
            this.cmbProgram.Size = new System.Drawing.Size(392, 23);
            this.cmbProgram.TabIndex = 6;
            // 
            // lblYear
            // 
            this.lblYear.Name = "lblYear";
            this.lblYear.Location = new System.Drawing.Point(24, 184);
            this.lblYear.Size = new System.Drawing.Size(190, 20);
            this.lblYear.TabIndex = 7;
            this.lblYear.Text = "Year level *";
            // 
            // cmbYear
            // 
            this.cmbYear.Items.AddRange(new object[] { "1st Year", "2nd Year", "3rd Year", "4th Year", "5th Year", "6th Year" });
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(24, 206);
            this.cmbYear.Size = new System.Drawing.Size(190, 23);
            this.cmbYear.TabIndex = 8;
            // 
            // lblSemester
            // 
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Location = new System.Drawing.Point(226, 184);
            this.lblSemester.Size = new System.Drawing.Size(190, 20);
            this.lblSemester.TabIndex = 9;
            this.lblSemester.Text = "Semester *";
            // 
            // cmbSemester
            // 
            this.cmbSemester.Items.AddRange(new object[] { "1st Semester", "2nd Semester", "Summer" });
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(226, 206);
            this.cmbSemester.Size = new System.Drawing.Size(190, 23);
            this.cmbSemester.TabIndex = 10;
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Location = new System.Drawing.Point(24, 243);
            this.lblSchoolYear.Size = new System.Drawing.Size(190, 20);
            this.lblSchoolYear.TabIndex = 11;
            this.lblSchoolYear.Text = "School year (e.g. 2026-2027) *";
            // 
            // txtSchoolYear
            // 
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.Location = new System.Drawing.Point(24, 265);
            this.txtSchoolYear.Size = new System.Drawing.Size(190, 23);
            this.txtSchoolYear.TabIndex = 12;
            this.txtSchoolYear.MaxLength = 9;
            // 
            // lblCapacity
            // 
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Location = new System.Drawing.Point(226, 243);
            this.lblCapacity.Size = new System.Drawing.Size(190, 20);
            this.lblCapacity.TabIndex = 13;
            this.lblCapacity.Text = "Capacity per subject";
            // 
            // nudCapacity
            // 
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Location = new System.Drawing.Point(226, 265);
            this.nudCapacity.Maximum = new decimal(new int[] {200, 0, 0, 0});
            this.nudCapacity.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudCapacity.Size = new System.Drawing.Size(190, 23);
            this.nudCapacity.TabIndex = 14;
            this.nudCapacity.Value = new decimal(new int[] {40, 0, 0, 0});
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 302);
            this.lblError.Size = new System.Drawing.Size(392, 36);
            this.lblError.TabIndex = 15;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 342);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "SAVE";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Location = new System.Drawing.Point(226, 342);
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // SectionEditDialog
            // 
            this.Name = "SectionEditDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 402);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Section";
            this.CancelButton = this.btnCancel;
            this.AcceptButton = this.btnSave;
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblProgram);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.lblSchoolYear);
            this.Controls.Add(this.txtSchoolYear);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.nudCapacity);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.TextBox txtSchoolYear;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
