namespace SESRS.Forms
{
    partial class CurriculumAddDialog
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
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Location = new System.Drawing.Point(24, 20);
            this.lblIntro.Size = new System.Drawing.Size(392, 36);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "The subject becomes available to students of this program in the chosen year and semester.";
            this.lblIntro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.ForeColor = System.Drawing.Color.DimGray;
            // 
            // lblSubject
            // 
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Location = new System.Drawing.Point(24, 66);
            this.lblSubject.Size = new System.Drawing.Size(392, 20);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "Subject *";
            // 
            // cmbSubject
            // 
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(24, 88);
            this.cmbSubject.Size = new System.Drawing.Size(392, 23);
            this.cmbSubject.TabIndex = 2;
            // 
            // lblYear
            // 
            this.lblYear.Name = "lblYear";
            this.lblYear.Location = new System.Drawing.Point(24, 125);
            this.lblYear.Size = new System.Drawing.Size(392, 20);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Year level *";
            // 
            // cmbYear
            // 
            this.cmbYear.Items.AddRange(new object[] { "1st Year", "2nd Year", "3rd Year", "4th Year", "5th Year", "6th Year" });
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(24, 147);
            this.cmbYear.Size = new System.Drawing.Size(392, 23);
            this.cmbYear.TabIndex = 4;
            // 
            // lblSemester
            // 
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Location = new System.Drawing.Point(24, 184);
            this.lblSemester.Size = new System.Drawing.Size(392, 20);
            this.lblSemester.TabIndex = 5;
            this.lblSemester.Text = "Semester *";
            // 
            // cmbSemester
            // 
            this.cmbSemester.Items.AddRange(new object[] { "1st Semester", "2nd Semester", "Summer" });
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(24, 206);
            this.cmbSemester.Size = new System.Drawing.Size(392, 23);
            this.cmbSemester.TabIndex = 6;
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 243);
            this.lblError.Size = new System.Drawing.Size(392, 36);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 283);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 8;
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
            this.btnCancel.Location = new System.Drawing.Point(226, 283);
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.TabIndex = 9;
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
            // CurriculumAddDialog
            // 
            this.Name = "CurriculumAddDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 343);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Subject to Curriculum";
            this.CancelButton = this.btnCancel;
            this.AcceptButton = this.btnSave;
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
