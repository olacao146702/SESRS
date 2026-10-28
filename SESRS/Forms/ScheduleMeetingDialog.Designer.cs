namespace SESRS.Forms
{
    partial class ScheduleMeetingDialog
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
            this.lblDay = new System.Windows.Forms.Label();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblRoom = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.lblInstructor = new System.Windows.Forms.Label();
            this.txtInstructor = new System.Windows.Forms.TextBox();
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
            this.lblIntro.Text = "Conflicts with this section, the room, or the instructor are detected automatically.";
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
            // lblDay
            // 
            this.lblDay.Name = "lblDay";
            this.lblDay.Location = new System.Drawing.Point(24, 125);
            this.lblDay.Size = new System.Drawing.Size(392, 20);
            this.lblDay.TabIndex = 3;
            this.lblDay.Text = "Day *";
            // 
            // cmbDay
            // 
            this.cmbDay.Items.AddRange(new object[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new System.Drawing.Point(24, 147);
            this.cmbDay.Size = new System.Drawing.Size(392, 23);
            this.cmbDay.TabIndex = 4;
            // 
            // lblStart
            // 
            this.lblStart.Name = "lblStart";
            this.lblStart.Location = new System.Drawing.Point(24, 184);
            this.lblStart.Size = new System.Drawing.Size(190, 20);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "Start time";
            // 
            // dtpStart
            // 
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.CustomFormat = "h:mm tt";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(24, 206);
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(190, 23);
            this.dtpStart.TabIndex = 6;
            // 
            // lblEnd
            // 
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Location = new System.Drawing.Point(226, 184);
            this.lblEnd.Size = new System.Drawing.Size(190, 20);
            this.lblEnd.TabIndex = 7;
            this.lblEnd.Text = "End time";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.CustomFormat = "h:mm tt";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(226, 206);
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(190, 23);
            this.dtpEnd.TabIndex = 8;
            // 
            // lblRoom
            // 
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Location = new System.Drawing.Point(24, 243);
            this.lblRoom.Size = new System.Drawing.Size(190, 20);
            this.lblRoom.TabIndex = 9;
            this.lblRoom.Text = "Room";
            // 
            // txtRoom
            // 
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Location = new System.Drawing.Point(24, 265);
            this.txtRoom.Size = new System.Drawing.Size(190, 23);
            this.txtRoom.TabIndex = 10;
            this.txtRoom.MaxLength = 50;
            // 
            // lblInstructor
            // 
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Location = new System.Drawing.Point(226, 243);
            this.lblInstructor.Size = new System.Drawing.Size(190, 20);
            this.lblInstructor.TabIndex = 11;
            this.lblInstructor.Text = "Instructor";
            // 
            // txtInstructor
            // 
            this.txtInstructor.Name = "txtInstructor";
            this.txtInstructor.Location = new System.Drawing.Point(226, 265);
            this.txtInstructor.Size = new System.Drawing.Size(190, 23);
            this.txtInstructor.TabIndex = 12;
            this.txtInstructor.MaxLength = 100;
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
            // ScheduleMeetingDialog
            // 
            this.Name = "ScheduleMeetingDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 402);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Class Meeting";
            this.CancelButton = this.btnCancel;
            this.AcceptButton = this.btnSave;
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.cmbDay);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.lblInstructor);
            this.Controls.Add(this.txtInstructor);
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
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label lblInstructor;
        private System.Windows.Forms.TextBox txtInstructor;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
