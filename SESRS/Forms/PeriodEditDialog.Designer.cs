namespace SESRS.Forms
{
    partial class PeriodEditDialog
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
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblMin = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.lblMax = new System.Windows.Forms.Label();
            this.nudMax = new System.Windows.Forms.NumericUpDown();
            this.chkCurrent = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Location = new System.Drawing.Point(24, 20);
            this.lblIntro.Size = new System.Drawing.Size(392, 36);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "Students can only submit enrollments between the opening and closing dates.";
            this.lblIntro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.ForeColor = System.Drawing.Color.DimGray;
            // 
            // lblYear
            // 
            this.lblYear.Name = "lblYear";
            this.lblYear.Location = new System.Drawing.Point(24, 66);
            this.lblYear.Size = new System.Drawing.Size(190, 20);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "School year (e.g. 2026-2027) *";
            // 
            // txtYear
            // 
            this.txtYear.Name = "txtYear";
            this.txtYear.Location = new System.Drawing.Point(24, 88);
            this.txtYear.Size = new System.Drawing.Size(190, 23);
            this.txtYear.TabIndex = 2;
            this.txtYear.MaxLength = 9;
            // 
            // lblSemester
            // 
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Location = new System.Drawing.Point(226, 66);
            this.lblSemester.Size = new System.Drawing.Size(190, 20);
            this.lblSemester.TabIndex = 3;
            this.lblSemester.Text = "Semester *";
            // 
            // cmbSemester
            // 
            this.cmbSemester.Items.AddRange(new object[] { "1st Semester", "2nd Semester", "Summer" });
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(226, 88);
            this.cmbSemester.Size = new System.Drawing.Size(190, 23);
            this.cmbSemester.TabIndex = 4;
            // 
            // lblStart
            // 
            this.lblStart.Name = "lblStart";
            this.lblStart.Location = new System.Drawing.Point(24, 125);
            this.lblStart.Size = new System.Drawing.Size(190, 20);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "Enrollment opens";
            // 
            // dtpStart
            // 
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(24, 147);
            this.dtpStart.Size = new System.Drawing.Size(190, 23);
            this.dtpStart.TabIndex = 6;
            // 
            // lblEnd
            // 
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Location = new System.Drawing.Point(226, 125);
            this.lblEnd.Size = new System.Drawing.Size(190, 20);
            this.lblEnd.TabIndex = 7;
            this.lblEnd.Text = "Enrollment closes";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(226, 147);
            this.dtpEnd.Size = new System.Drawing.Size(190, 23);
            this.dtpEnd.TabIndex = 8;
            // 
            // lblMin
            // 
            this.lblMin.Name = "lblMin";
            this.lblMin.Location = new System.Drawing.Point(24, 184);
            this.lblMin.Size = new System.Drawing.Size(190, 20);
            this.lblMin.TabIndex = 9;
            this.lblMin.Text = "Minimum units";
            // 
            // nudMin
            // 
            this.nudMin.Name = "nudMin";
            this.nudMin.Location = new System.Drawing.Point(24, 206);
            this.nudMin.Maximum = new decimal(new int[] {40, 0, 0, 0});
            this.nudMin.Minimum = new decimal(new int[] {0, 0, 0, 0});
            this.nudMin.Size = new System.Drawing.Size(190, 23);
            this.nudMin.TabIndex = 10;
            this.nudMin.Value = new decimal(new int[] {12, 0, 0, 0});
            // 
            // lblMax
            // 
            this.lblMax.Name = "lblMax";
            this.lblMax.Location = new System.Drawing.Point(226, 184);
            this.lblMax.Size = new System.Drawing.Size(190, 20);
            this.lblMax.TabIndex = 11;
            this.lblMax.Text = "Maximum units";
            // 
            // nudMax
            // 
            this.nudMax.Name = "nudMax";
            this.nudMax.Location = new System.Drawing.Point(226, 206);
            this.nudMax.Maximum = new decimal(new int[] {40, 0, 0, 0});
            this.nudMax.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudMax.Size = new System.Drawing.Size(190, 23);
            this.nudMax.TabIndex = 12;
            this.nudMax.Value = new decimal(new int[] {24, 0, 0, 0});
            // 
            // chkCurrent
            // 
            this.chkCurrent.Name = "chkCurrent";
            this.chkCurrent.AutoSize = false;
            this.chkCurrent.Location = new System.Drawing.Point(24, 243);
            this.chkCurrent.Size = new System.Drawing.Size(392, 24);
            this.chkCurrent.TabIndex = 13;
            this.chkCurrent.Text = "Make this the current term";
            this.chkCurrent.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 281);
            this.lblError.Size = new System.Drawing.Size(392, 36);
            this.lblError.TabIndex = 14;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 321);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 15;
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
            this.btnCancel.Location = new System.Drawing.Point(226, 321);
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.TabIndex = 16;
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
            // PeriodEditDialog
            // 
            this.Name = "PeriodEditDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 381);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Academic Period";
            this.CancelButton = this.btnCancel;
            this.AcceptButton = this.btnSave;
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.nudMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.nudMax);
            this.Controls.Add(this.chkCurrent);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.NumericUpDown nudMax;
        private System.Windows.Forms.CheckBox chkCurrent;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
