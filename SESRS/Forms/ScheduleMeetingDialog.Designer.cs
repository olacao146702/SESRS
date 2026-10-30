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
            lblIntro = new Label();
            lblSubject = new Label();
            cmbSubject = new ComboBox();
            lblDay = new Label();
            cmbDay = new ComboBox();
            lblStart = new Label();
            dtpStart = new DateTimePicker();
            lblEnd = new Label();
            dtpEnd = new DateTimePicker();
            lblRoom = new Label();
            txtRoom = new TextBox();
            lblInstructor = new Label();
            txtInstructor = new TextBox();
            lblError = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblIntro
            // 
            lblIntro.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIntro.ForeColor = Color.DimGray;
            lblIntro.Location = new Point(34, 33);
            lblIntro.Margin = new Padding(4, 0, 4, 0);
            lblIntro.Name = "lblIntro";
            lblIntro.Size = new Size(560, 60);
            lblIntro.TabIndex = 0;
            lblIntro.Text = "Conflicts with this section, the room, or the instructor are detected automatically.";
            // 
            // lblSubject
            // 
            lblSubject.Location = new Point(34, 110);
            lblSubject.Margin = new Padding(4, 0, 4, 0);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(560, 33);
            lblSubject.TabIndex = 1;
            lblSubject.Text = "Subject *";
            // 
            // cmbSubject
            // 
            cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(34, 147);
            cmbSubject.Margin = new Padding(4, 5, 4, 5);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(558, 33);
            cmbSubject.TabIndex = 2;
            // 
            // lblDay
            // 
            lblDay.Location = new Point(34, 208);
            lblDay.Margin = new Padding(4, 0, 4, 0);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(560, 33);
            lblDay.TabIndex = 3;
            lblDay.Text = "Day *";
            // 
            // cmbDay
            // 
            cmbDay.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDay.FormattingEnabled = true;
            cmbDay.Items.AddRange(new object[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "MWF", "Monday-Friday", "MSAT1", "MSAT2" });
            cmbDay.Location = new Point(34, 245);
            cmbDay.Margin = new Padding(4, 5, 4, 5);
            cmbDay.Name = "cmbDay";
            cmbDay.Size = new Size(558, 33);
            cmbDay.TabIndex = 4;
            // 
            // lblStart
            // 
            lblStart.Location = new Point(34, 307);
            lblStart.Margin = new Padding(4, 0, 4, 0);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(271, 33);
            lblStart.TabIndex = 5;
            lblStart.Text = "Start time";
            // 
            // dtpStart
            // 
            dtpStart.CustomFormat = "h:mm tt";
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(34, 343);
            dtpStart.Margin = new Padding(4, 5, 4, 5);
            dtpStart.Name = "dtpStart";
            dtpStart.ShowUpDown = true;
            dtpStart.Size = new Size(270, 31);
            dtpStart.TabIndex = 6;
            // 
            // lblEnd
            // 
            lblEnd.Location = new Point(323, 307);
            lblEnd.Margin = new Padding(4, 0, 4, 0);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(271, 33);
            lblEnd.TabIndex = 7;
            lblEnd.Text = "End time";
            // 
            // dtpEnd
            // 
            dtpEnd.CustomFormat = "h:mm tt";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(323, 343);
            dtpEnd.Margin = new Padding(4, 5, 4, 5);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.ShowUpDown = true;
            dtpEnd.Size = new Size(270, 31);
            dtpEnd.TabIndex = 8;
            // 
            // lblRoom
            // 
            lblRoom.Location = new Point(34, 405);
            lblRoom.Margin = new Padding(4, 0, 4, 0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(271, 33);
            lblRoom.TabIndex = 9;
            lblRoom.Text = "Room";
            // 
            // txtRoom
            // 
            txtRoom.Location = new Point(34, 442);
            txtRoom.Margin = new Padding(4, 5, 4, 5);
            txtRoom.MaxLength = 50;
            txtRoom.Name = "txtRoom";
            txtRoom.Size = new Size(270, 31);
            txtRoom.TabIndex = 10;
            // 
            // lblInstructor
            // 
            lblInstructor.Location = new Point(323, 405);
            lblInstructor.Margin = new Padding(4, 0, 4, 0);
            lblInstructor.Name = "lblInstructor";
            lblInstructor.Size = new Size(271, 33);
            lblInstructor.TabIndex = 11;
            lblInstructor.Text = "Instructor";
            // 
            // txtInstructor
            // 
            txtInstructor.Location = new Point(323, 442);
            txtInstructor.Margin = new Padding(4, 5, 4, 5);
            txtInstructor.MaxLength = 100;
            txtInstructor.Name = "txtInstructor";
            txtInstructor.Size = new Size(270, 31);
            txtInstructor.TabIndex = 12;
            // 
            // lblError
            // 
            lblError.ForeColor = Color.Firebrick;
            lblError.Location = new Point(34, 503);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(560, 60);
            lblError.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkGreen;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(34, 570);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(271, 63);
            btnSave.TabIndex = 14;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderColor = Color.DarkGreen;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.DarkGreen;
            btnCancel.Location = new Point(323, 570);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(271, 63);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // ScheduleMeetingDialog
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(629, 670);
            Controls.Add(lblIntro);
            Controls.Add(lblSubject);
            Controls.Add(cmbSubject);
            Controls.Add(lblDay);
            Controls.Add(cmbDay);
            Controls.Add(lblStart);
            Controls.Add(dtpStart);
            Controls.Add(lblEnd);
            Controls.Add(dtpEnd);
            Controls.Add(lblRoom);
            Controls.Add(txtRoom);
            Controls.Add(lblInstructor);
            Controls.Add(txtInstructor);
            Controls.Add(lblError);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScheduleMeetingDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Class Meeting";
            ResumeLayout(false);
            PerformLayout();
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
