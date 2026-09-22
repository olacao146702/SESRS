namespace SESRS.Forms
{
    partial class StudentSignUpForm
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
            lblTitle = new Label();
            lblAccountInfo = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            blPassword = new Label();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            lblStudentInfo = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtMiddleName = new TextBox();
            lblMiddleName = new Label();
            cmbGender = new ComboBox();
            lblGender = new Label();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            lblProgram = new Label();
            cmbProgram = new ComboBox();
            cmbYearLevel = new ComboBox();
            lblYearLevel = new Label();
            btnCreateAccount = new Button();
            btnBackToLogin = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(383, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(329, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Student Sign Up";
            // 
            // lblAccountInfo
            // 
            lblAccountInfo.AutoSize = true;
            lblAccountInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccountInfo.Location = new Point(706, 71);
            lblAccountInfo.Name = "lblAccountInfo";
            lblAccountInfo.Size = new Size(254, 32);
            lblAccountInfo.TabIndex = 1;
            lblAccountInfo.Text = "Account Information";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(626, 133);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(99, 28);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(740, 130);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(255, 31);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(740, 189);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(255, 31);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // blPassword
            // 
            blPassword.AutoSize = true;
            blPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            blPassword.Location = new Point(632, 192);
            blPassword.Name = "blPassword";
            blPassword.Size = new Size(93, 28);
            blPassword.TabIndex = 4;
            blPassword.Text = "Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(740, 251);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(255, 31);
            txtConfirmPassword.TabIndex = 7;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmPassword.Location = new Point(557, 254);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(168, 28);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentInfo.Location = new Point(150, 71);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(247, 32);
            lblStudentInfo.TabIndex = 10;
            lblStudentInfo.Text = "Student Information";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(186, 134);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(167, 31);
            txtFirstName.TabIndex = 12;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstName.Location = new Point(65, 137);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(106, 28);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "First Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(186, 251);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(167, 31);
            txtLastName.TabIndex = 14;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastName.Location = new Point(68, 254);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(103, 28);
            lblLastName.TabIndex = 13;
            lblLastName.Text = "Last Name";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(186, 192);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(167, 31);
            txtMiddleName.TabIndex = 16;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMiddleName.Location = new Point(40, 195);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(131, 28);
            lblMiddleName.TabIndex = 15;
            lblMiddleName.Text = "Middle Name";
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(186, 313);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(182, 33);
            cmbGender.TabIndex = 17;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGender.Location = new Point(95, 318);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(76, 28);
            lblGender.TabIndex = 18;
            lblGender.Text = "Gender";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBirthDate.Location = new Point(72, 379);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(99, 28);
            lblBirthDate.TabIndex = 19;
            lblBirthDate.Text = "Birth Date";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(186, 376);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(300, 31);
            dtpBirthDate.TabIndex = 20;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(186, 438);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(255, 31);
            txtEmail.TabIndex = 22;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(112, 441);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 28);
            lblEmail.TabIndex = 21;
            lblEmail.Text = "Email";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(186, 502);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(255, 31);
            txtPhone.TabIndex = 24;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhone.Location = new Point(104, 505);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(67, 28);
            lblPhone.TabIndex = 23;
            lblPhone.Text = "Phone";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(186, 563);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(300, 31);
            txtAddress.TabIndex = 26;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddress.Location = new Point(89, 566);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(82, 28);
            lblAddress.TabIndex = 25;
            lblAddress.Text = "Address";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProgram.Location = new Point(83, 629);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(88, 28);
            lblProgram.TabIndex = 27;
            lblProgram.Text = "Program";
            // 
            // cmbProgram
            // 
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Location = new Point(186, 624);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(300, 33);
            cmbProgram.TabIndex = 29;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(186, 686);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(182, 33);
            cmbYearLevel.TabIndex = 31;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYearLevel.Location = new Point(74, 691);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(97, 28);
            lblYearLevel.TabIndex = 30;
            lblYearLevel.Text = "Year Level";
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(449, 750);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(199, 58);
            btnCreateAccount.TabIndex = 32;
            btnCreateAccount.Text = "CREATE ACCOUNT";
            btnCreateAccount.UseVisualStyleBackColor = true;
            // 
            // btnBackToLogin
            // 
            btnBackToLogin.Location = new Point(475, 814);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(149, 34);
            btnBackToLogin.TabIndex = 33;
            btnBackToLogin.Text = "Back to Login";
            btnBackToLogin.UseVisualStyleBackColor = true;
            // 
            // StudentSignUpForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 1050);
            Controls.Add(btnBackToLogin);
            Controls.Add(btnCreateAccount);
            Controls.Add(cmbYearLevel);
            Controls.Add(lblYearLevel);
            Controls.Add(cmbProgram);
            Controls.Add(lblProgram);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(dtpBirthDate);
            Controls.Add(lblBirthDate);
            Controls.Add(lblGender);
            Controls.Add(cmbGender);
            Controls.Add(txtMiddleName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(lblStudentInfo);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(blPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblAccountInfo);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentSignUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Sign Up";
            Load += StudentSignUpForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblAccountInfo;
        private Label lblUsername;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label blPassword;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private Label lblStudentInfo;
        private TextBox txtFirstName;
        private Label lblFirstName;
        private TextBox txtLastName;
        private Label lblLastName;
        private TextBox txtMiddleName;
        private Label lblMiddleName;
        private ComboBox cmbGender;
        private Label lblGender;
        private Label lblBirthDate;
        private DateTimePicker dtpBirthDate;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtAddress;
        private Label lblAddress;
        private Label lblProgram;
        private ComboBox cmbProgram;
        private ComboBox cmbYearLevel;
        private Label lblYearLevel;
        private Button btnCreateAccount;
        private Button btnBackToLogin;
    }
}