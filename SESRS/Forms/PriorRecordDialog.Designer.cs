namespace SESRS.Forms
{
    partial class PriorRecordDialog
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
            this.lblStudent = new System.Windows.Forms.Label();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbResult = new System.Windows.Forms.ComboBox();
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
            this.lblIntro.Text = "Credit a result earned before the system was used. It is published right away and counts toward prerequisites.";
            this.lblIntro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.ForeColor = System.Drawing.Color.DimGray;
            // 
            // lblStudent
            // 
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Location = new System.Drawing.Point(24, 66);
            this.lblStudent.Size = new System.Drawing.Size(392, 20);
            this.lblStudent.TabIndex = 1;
            this.lblStudent.Text = "Student *";
            // 
            // cmbStudent
            // 
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(24, 88);
            this.cmbStudent.Size = new System.Drawing.Size(392, 23);
            this.cmbStudent.TabIndex = 2;
            // 
            // lblSubject
            // 
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Location = new System.Drawing.Point(24, 125);
            this.lblSubject.Size = new System.Drawing.Size(392, 20);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "Subject *";
            // 
            // cmbSubject
            // 
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(24, 147);
            this.cmbSubject.Size = new System.Drawing.Size(392, 23);
            this.cmbSubject.TabIndex = 4;
            // 
            // lblYear
            // 
            this.lblYear.Name = "lblYear";
            this.lblYear.Location = new System.Drawing.Point(24, 184);
            this.lblYear.Size = new System.Drawing.Size(190, 20);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "School year (e.g. 2025-2026) *";
            // 
            // txtYear
            // 
            this.txtYear.Name = "txtYear";
            this.txtYear.Location = new System.Drawing.Point(24, 206);
            this.txtYear.Size = new System.Drawing.Size(190, 23);
            this.txtYear.TabIndex = 6;
            this.txtYear.MaxLength = 9;
            // 
            // lblSemester
            // 
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Location = new System.Drawing.Point(226, 184);
            this.lblSemester.Size = new System.Drawing.Size(190, 20);
            this.lblSemester.TabIndex = 7;
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
            this.cmbSemester.TabIndex = 8;
            // 
            // lblGrade
            // 
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Location = new System.Drawing.Point(24, 243);
            this.lblGrade.Size = new System.Drawing.Size(190, 20);
            this.lblGrade.TabIndex = 9;
            this.lblGrade.Text = "Final grade (1.00 - 5.00) *";
            // 
            // txtGrade
            // 
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Location = new System.Drawing.Point(24, 265);
            this.txtGrade.Size = new System.Drawing.Size(190, 23);
            this.txtGrade.TabIndex = 10;
            this.txtGrade.MaxLength = 5;
            // 
            // lblResult
            // 
            this.lblResult.Name = "lblResult";
            this.lblResult.Location = new System.Drawing.Point(226, 243);
            this.lblResult.Size = new System.Drawing.Size(190, 20);
            this.lblResult.TabIndex = 11;
            this.lblResult.Text = "Result *";
            // 
            // cmbResult
            // 
            this.cmbResult.Items.AddRange(new object[] { "Passed", "Failed" });
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Location = new System.Drawing.Point(226, 265);
            this.cmbResult.Size = new System.Drawing.Size(190, 23);
            this.cmbResult.TabIndex = 12;
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 302);
            this.lblError.Size = new System.Drawing.Size(392, 36);
            this.lblError.TabIndex = 13;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 342);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 14;
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
            this.btnCancel.TabIndex = 15;
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
            // PriorRecordDialog
            // 
            this.Name = "PriorRecordDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 402);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Prior Record";
            this.CancelButton = this.btnCancel;
            this.AcceptButton = this.btnSave;
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.cmbStudent);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cmbResult);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
