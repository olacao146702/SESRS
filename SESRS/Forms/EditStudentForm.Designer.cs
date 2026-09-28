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
            txtFirstName.Location = new Point(189, 56);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(150, 31);
            txtFirstName.TabIndex = 0;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(189, 93);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(150, 31);
            txtMiddleName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(189, 130);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(150, 31);
            txtLastName.TabIndex = 2;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(189, 167);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(150, 33);
            cmbGender.TabIndex = 3;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(189, 206);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(300, 31);
            dtpBirthDate.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(189, 243);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(197, 31);
            txtEmail.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(189, 280);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(150, 31);
            txtPhone.TabIndex = 6;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(189, 317);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(197, 31);
            txtAddress.TabIndex = 7;
            // 
            // cmbProgram
            // 
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Location = new Point(189, 354);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(150, 33);
            cmbProgram.TabIndex = 8;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(189, 393);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(150, 33);
            cmbYearLevel.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(71, 461);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 10;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(189, 461);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblEditstudent
            // 
            lblEditstudent.AutoSize = true;
            lblEditstudent.Location = new Point(143, 18);
            lblEditstudent.Name = "lblEditstudent";
            lblEditstudent.Size = new Size(128, 25);
            lblEditstudent.TabIndex = 12;
            lblEditstudent.Text = "EDIT STUDENT";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(82, 62);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(101, 25);
            lblFirstName.TabIndex = 13;
            lblFirstName.Text = "First Name:";
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Location = new Point(60, 99);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(123, 25);
            lblMiddleName.TabIndex = 14;
            lblMiddleName.Text = "Middle Name:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(84, 136);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(99, 25);
            lblLastName.TabIndex = 15;
            lblLastName.Text = "Last Name:";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(110, 175);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(73, 25);
            lblGender.TabIndex = 16;
            lblGender.Text = "Gender:";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Location = new Point(89, 212);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(94, 25);
            lblBirthDate.TabIndex = 17;
            lblBirthDate.Text = "Birth Date:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(125, 249);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 18;
            lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(117, 286);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(66, 25);
            lblPhone.TabIndex = 19;
            lblPhone.Text = "Phone:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(102, 323);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(81, 25);
            lblAddress.TabIndex = 20;
            lblAddress.Text = "Address:";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Location = new Point(98, 362);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(85, 25);
            lblProgram.TabIndex = 21;
            lblProgram.Text = "Program:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(91, 401);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(92, 25);
            lblYearLevel.TabIndex = 22;
            lblYearLevel.Text = "Year Level:";
            // 
            // EditStudentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 538);
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