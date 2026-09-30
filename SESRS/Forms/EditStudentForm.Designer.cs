namespace SESRS.Forms
{
    partial class EditStudentForm
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
            txtFirstName = new TextBox();
            txtMiddleName = new TextBox();
            txtLastName = new TextBox();
            cmbGender = new ComboBox();
            dtpBirthDate = new DateTimePicker();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            cmbProgram = new ComboBox();
            cmbYearLevel = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblEditstudent = new Label();
            lblFirstName = new Label();
            lblMiddleName = new Label();
            lblLastName = new Label();
            lblGender = new Label();
            lblBirthDate = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            lblProgram = new Label();
            lblYearLevel = new Label();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(150, 113);
            txtFirstName.Margin = new Padding(2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(241, 27);
            txtFirstName.TabIndex = 0;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(150, 158);
            txtMiddleName.Margin = new Padding(2);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(241, 27);
            txtMiddleName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(150, 198);
            txtLastName.Margin = new Padding(2);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(241, 27);
            txtLastName.TabIndex = 2;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(150, 256);
            cmbGender.Margin = new Padding(2);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(135, 28);
            cmbGender.TabIndex = 3;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(150, 297);
            dtpBirthDate.Margin = new Padding(2);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(241, 27);
            dtpBirthDate.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(150, 339);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(241, 27);
            txtEmail.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(150, 382);
            txtPhone.Margin = new Padding(2);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(241, 27);
            txtPhone.TabIndex = 6;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(150, 423);
            txtAddress.Margin = new Padding(2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(158, 27);
            txtAddress.TabIndex = 7;
            // 
            // cmbProgram
            // 
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Location = new Point(150, 479);
            cmbProgram.Margin = new Padding(2);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(135, 28);
            cmbProgram.TabIndex = 8;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(150, 520);
            cmbYearLevel.Margin = new Padding(2);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(135, 28);
            cmbYearLevel.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(24, 82, 58);
            btnSave.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(338, 562);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 47);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(24, 82, 58);
            btnCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(469, 562);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 47);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblEditstudent
            // 
            lblEditstudent.AutoSize = true;
            lblEditstudent.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditstudent.ForeColor = Color.FromArgb(24, 82, 58);
            lblEditstudent.Location = new Point(44, 39);
            lblEditstudent.Margin = new Padding(2, 0, 2, 0);
            lblEditstudent.Name = "lblEditstudent";
            lblEditstudent.Size = new Size(193, 41);
            lblEditstudent.TabIndex = 12;
            lblEditstudent.Text = "Edit Student";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(90, 100, 95);
            lblFirstName.Location = new Point(27, 117);
            lblFirstName.Margin = new Padding(2, 0, 2, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(97, 23);
            lblFirstName.TabIndex = 13;
            lblFirstName.Text = "First Name:";
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblMiddleName.ForeColor = Color.FromArgb(90, 100, 95);
            lblMiddleName.Location = new Point(27, 160);
            lblMiddleName.Margin = new Padding(2, 0, 2, 0);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(118, 23);
            lblMiddleName.TabIndex = 14;
            lblMiddleName.Text = "Middle Name:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(90, 100, 95);
            lblLastName.Location = new Point(27, 202);
            lblLastName.Margin = new Padding(2, 0, 2, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(95, 23);
            lblLastName.TabIndex = 15;
            lblLastName.Text = "Last Name:";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(90, 100, 95);
            lblGender.Location = new Point(27, 261);
            lblGender.Margin = new Padding(2, 0, 2, 0);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(71, 23);
            lblGender.TabIndex = 16;
            lblGender.Text = "Gender:";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblBirthDate.ForeColor = Color.FromArgb(90, 100, 95);
            lblBirthDate.Location = new Point(27, 299);
            lblBirthDate.Margin = new Padding(2, 0, 2, 0);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(91, 23);
            lblBirthDate.TabIndex = 17;
            lblBirthDate.Text = "Birth Date:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(90, 100, 95);
            lblEmail.Location = new Point(27, 343);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 23);
            lblEmail.TabIndex = 18;
            lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(90, 100, 95);
            lblPhone.Location = new Point(27, 386);
            lblPhone.Margin = new Padding(2, 0, 2, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(63, 23);
            lblPhone.TabIndex = 19;
            lblPhone.Text = "Phone:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(90, 100, 95);
            lblAddress.Location = new Point(27, 427);
            lblAddress.Margin = new Padding(2, 0, 2, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(74, 23);
            lblAddress.TabIndex = 20;
            lblAddress.Text = "Address:";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblProgram.ForeColor = Color.FromArgb(90, 100, 95);
            lblProgram.Location = new Point(27, 484);
            lblProgram.Margin = new Padding(2, 0, 2, 0);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(80, 23);
            lblProgram.TabIndex = 21;
            lblProgram.Text = "Program:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblYearLevel.ForeColor = Color.FromArgb(90, 100, 95);
            lblYearLevel.Location = new Point(27, 525);
            lblYearLevel.Margin = new Padding(2, 0, 2, 0);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(90, 23);
            lblYearLevel.TabIndex = 22;
            lblYearLevel.Text = "Year Level:";
            // 
            // EditStudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 640);
            Controls.Add(lblYearLevel);
            Controls.Add(lblProgram);
            Controls.Add(lblAddress);
            Controls.Add(lblPhone);
            Controls.Add(lblEmail);
            Controls.Add(lblBirthDate);
            Controls.Add(lblGender);
            Controls.Add(lblLastName);
            Controls.Add(lblMiddleName);
            Controls.Add(lblFirstName);
            Controls.Add(lblEditstudent);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbYearLevel);
            Controls.Add(cmbProgram);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(dtpBirthDate);
            Controls.Add(cmbGender);
            Controls.Add(txtLastName);
            Controls.Add(txtMiddleName);
            Controls.Add(txtFirstName);
            Margin = new Padding(2);
            Name = "EditStudentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Student";
            Load += EditStudentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtLastName;
        private ComboBox cmbGender;
        private DateTimePicker dtpBirthDate;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private ComboBox cmbProgram;
        private ComboBox cmbYearLevel;
        private Button btnSave;
        private Button btnCancel;
        private Label lblEditstudent;
        private Label lblFirstName;
        private Label lblMiddleName;
        private Label lblLastName;
        private Label lblGender;
        private Label lblBirthDate;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblAddress;
        private Label lblProgram;
        private Label lblYearLevel;
    }
}