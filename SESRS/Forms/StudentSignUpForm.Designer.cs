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
            lblUsername = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            blPassword = new Label();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtStudentNumber = new TextBox();
            lblStudentNumber = new Label();
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
            groupBoxStudentinfo = new GroupBox();
            groupBoxAccountinfo = new GroupBox();
            groupBox3 = new GroupBox();
            groupBoxStudentinfo.SuspendLayout();
            groupBoxAccountinfo.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(318, 23);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Student Sign Up";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.Black;
            lblUsername.Location = new Point(16, 50);
            lblUsername.Margin = new Padding(2, 0, 2, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(87, 23);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(224, 224, 224);
            txtUsername.Location = new Point(170, 50);
            txtUsername.Margin = new Padding(2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(205, 27);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(224, 224, 224);
            txtPassword.Location = new Point(170, 97);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(205, 27);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // blPassword
            // 
            blPassword.AutoSize = true;
            blPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            blPassword.ForeColor = Color.Black;
            blPassword.Location = new Point(16, 101);
            blPassword.Margin = new Padding(2, 0, 2, 0);
            blPassword.Name = "blPassword";
            blPassword.Size = new Size(80, 23);
            blPassword.TabIndex = 4;
            blPassword.Text = "Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(224, 224, 224);
            txtConfirmPassword.Location = new Point(170, 147);
            txtConfirmPassword.Margin = new Padding(2);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(205, 27);
            txtConfirmPassword.TabIndex = 7;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmPassword.ForeColor = Color.Black;
            lblConfirmPassword.Location = new Point(16, 148);
            lblConfirmPassword.Margin = new Padding(2, 0, 2, 0);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(146, 23);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Confirm Password";
            lblConfirmPassword.Click += lblConfirmPassword_Click;
            // 
            // txtStudentNumber
            // 
            txtStudentNumber.BackColor = Color.FromArgb(224, 224, 224);
            txtStudentNumber.Location = new Point(170, 196);
            txtStudentNumber.Margin = new Padding(2);
            txtStudentNumber.Name = "txtStudentNumber";
            txtStudentNumber.Size = new Size(205, 27);
            txtStudentNumber.TabIndex = 9;
            // 
            // lblStudentNumber
            // 
            lblStudentNumber.AutoSize = true;
            lblStudentNumber.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStudentNumber.ForeColor = Color.Black;
            lblStudentNumber.Location = new Point(16, 200);
            lblStudentNumber.Margin = new Padding(2, 0, 2, 0);
            lblStudentNumber.Name = "lblStudentNumber";
            lblStudentNumber.Size = new Size(137, 23);
            lblStudentNumber.TabIndex = 8;
            lblStudentNumber.Text = "Student Number";
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.FromArgb(224, 224, 224);
            txtFirstName.Location = new Point(127, 47);
            txtFirstName.Margin = new Padding(2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(134, 27);
            txtFirstName.TabIndex = 12;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirstName.ForeColor = SystemColors.ActiveCaptionText;
            lblFirstName.Location = new Point(15, 51);
            lblFirstName.Margin = new Padding(2, 0, 2, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(92, 23);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "First Name";
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.FromArgb(224, 224, 224);
            txtLastName.Location = new Point(127, 141);
            txtLastName.Margin = new Padding(2);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(134, 27);
            txtLastName.TabIndex = 14;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLastName.ForeColor = Color.Black;
            lblLastName.Location = new Point(15, 145);
            lblLastName.Margin = new Padding(2, 0, 2, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(91, 23);
            lblLastName.TabIndex = 13;
            lblLastName.Text = "Last Name";
            // 
            // txtMiddleName
            // 
            txtMiddleName.BackColor = Color.FromArgb(224, 224, 224);
            txtMiddleName.Location = new Point(127, 94);
            txtMiddleName.Margin = new Padding(2);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(134, 27);
            txtMiddleName.TabIndex = 16;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMiddleName.ForeColor = Color.Black;
            lblMiddleName.Location = new Point(15, 98);
            lblMiddleName.Margin = new Padding(2, 0, 2, 0);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(113, 23);
            lblMiddleName.TabIndex = 15;
            lblMiddleName.Text = "Middle Name";
            // 
            // cmbGender
            // 
            cmbGender.BackColor = Color.FromArgb(224, 224, 224);
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(127, 190);
            cmbGender.Margin = new Padding(2);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(146, 28);
            cmbGender.TabIndex = 17;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGender.ForeColor = Color.Black;
            lblGender.Location = new Point(15, 191);
            lblGender.Margin = new Padding(2, 0, 2, 0);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(66, 23);
            lblGender.TabIndex = 18;
            lblGender.Text = "Gender";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBirthDate.ForeColor = Color.Black;
            lblBirthDate.Location = new Point(15, 244);
            lblBirthDate.Margin = new Padding(2, 0, 2, 0);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(87, 23);
            lblBirthDate.TabIndex = 19;
            lblBirthDate.Text = "Birth Date";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpBirthDate.CalendarForeColor = SystemColors.Control;
            dtpBirthDate.CalendarMonthBackground = Color.Wheat;
            dtpBirthDate.CalendarTitleBackColor = SystemColors.ButtonFace;
            dtpBirthDate.Location = new Point(127, 241);
            dtpBirthDate.Margin = new Padding(2);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(241, 27);
            dtpBirthDate.TabIndex = 20;
            dtpBirthDate.ValueChanged += dtpBirthDate_ValueChanged;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(224, 224, 224);
            txtEmail.Location = new Point(127, 290);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(205, 27);
            txtEmail.TabIndex = 22;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(15, 291);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 23);
            lblEmail.TabIndex = 21;
            lblEmail.Text = "Email";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.FromArgb(224, 224, 224);
            txtPhone.Location = new Point(127, 342);
            txtPhone.Margin = new Padding(2);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(205, 27);
            txtPhone.TabIndex = 24;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhone.ForeColor = Color.Black;
            lblPhone.Location = new Point(15, 346);
            lblPhone.Margin = new Padding(2, 0, 2, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(59, 23);
            lblPhone.TabIndex = 23;
            lblPhone.Text = "Phone";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.FromArgb(224, 224, 224);
            txtAddress.Location = new Point(127, 390);
            txtAddress.Margin = new Padding(2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(241, 27);
            txtAddress.TabIndex = 26;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddress.ForeColor = Color.Black;
            lblAddress.Location = new Point(15, 394);
            lblAddress.Margin = new Padding(2, 0, 2, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(70, 23);
            lblAddress.TabIndex = 25;
            lblAddress.Text = "Address";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProgram.ForeColor = Color.Black;
            lblProgram.Location = new Point(15, 444);
            lblProgram.Margin = new Padding(2, 0, 2, 0);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(76, 23);
            lblProgram.TabIndex = 27;
            lblProgram.Text = "Program";
            // 
            // cmbProgram
            // 
            cmbProgram.BackColor = Color.FromArgb(224, 224, 224);
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Location = new Point(127, 439);
            cmbProgram.Margin = new Padding(2);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(241, 28);
            cmbProgram.TabIndex = 29;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.BackColor = Color.FromArgb(224, 224, 224);
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(127, 489);
            cmbYearLevel.Margin = new Padding(2);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(146, 28);
            cmbYearLevel.TabIndex = 31;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYearLevel.ForeColor = Color.Black;
            lblYearLevel.Location = new Point(15, 494);
            lblYearLevel.Margin = new Padding(2, 0, 2, 0);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(85, 23);
            lblYearLevel.TabIndex = 30;
            lblYearLevel.Text = "Year Level";
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.BackColor = Color.DarkGreen;
            btnCreateAccount.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Location = new Point(399, 697);
            btnCreateAccount.Margin = new Padding(2);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(159, 46);
            btnCreateAccount.TabIndex = 32;
            btnCreateAccount.Text = "CREATE ACCOUNT";
            btnCreateAccount.UseVisualStyleBackColor = false;
            // 
            // btnBackToLogin
            // 
            btnBackToLogin.ForeColor = Color.DarkGreen;
            btnBackToLogin.Location = new Point(418, 760);
            btnBackToLogin.Margin = new Padding(2);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(119, 27);
            btnBackToLogin.TabIndex = 33;
            btnBackToLogin.Text = "Back to Login";
            btnBackToLogin.UseVisualStyleBackColor = true;
            // 
            // groupBoxStudentinfo
            // 
            groupBoxStudentinfo.Controls.Add(txtFirstName);
            groupBoxStudentinfo.Controls.Add(lblFirstName);
            groupBoxStudentinfo.Controls.Add(lblGender);
            groupBoxStudentinfo.Controls.Add(lblProgram);
            groupBoxStudentinfo.Controls.Add(lblLastName);
            groupBoxStudentinfo.Controls.Add(txtAddress);
            groupBoxStudentinfo.Controls.Add(txtEmail);
            groupBoxStudentinfo.Controls.Add(cmbGender);
            groupBoxStudentinfo.Controls.Add(txtLastName);
            groupBoxStudentinfo.Controls.Add(lblBirthDate);
            groupBoxStudentinfo.Controls.Add(lblPhone);
            groupBoxStudentinfo.Controls.Add(cmbProgram);
            groupBoxStudentinfo.Controls.Add(cmbYearLevel);
            groupBoxStudentinfo.Controls.Add(lblAddress);
            groupBoxStudentinfo.Controls.Add(lblEmail);
            groupBoxStudentinfo.Controls.Add(txtMiddleName);
            groupBoxStudentinfo.Controls.Add(lblMiddleName);
            groupBoxStudentinfo.Controls.Add(dtpBirthDate);
            groupBoxStudentinfo.Controls.Add(txtPhone);
            groupBoxStudentinfo.Controls.Add(lblYearLevel);
            groupBoxStudentinfo.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxStudentinfo.ForeColor = Color.DarkGreen;
            groupBoxStudentinfo.Location = new Point(61, 123);
            groupBoxStudentinfo.Name = "groupBoxStudentinfo";
            groupBoxStudentinfo.Size = new Size(390, 547);
            groupBoxStudentinfo.TabIndex = 34;
            groupBoxStudentinfo.TabStop = false;
            groupBoxStudentinfo.Text = "Student Information";
            groupBoxStudentinfo.Enter += groupBoxStudentinfo_Enter;
            // 
            // groupBoxAccountinfo
            // 
            groupBoxAccountinfo.Controls.Add(txtUsername);
            groupBoxAccountinfo.Controls.Add(lblUsername);
            groupBoxAccountinfo.Controls.Add(blPassword);
            groupBoxAccountinfo.Controls.Add(txtPassword);
            groupBoxAccountinfo.Controls.Add(lblConfirmPassword);
            groupBoxAccountinfo.Controls.Add(txtStudentNumber);
            groupBoxAccountinfo.Controls.Add(txtConfirmPassword);
            groupBoxAccountinfo.Controls.Add(lblStudentNumber);
            groupBoxAccountinfo.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxAccountinfo.ForeColor = Color.DarkGreen;
            groupBoxAccountinfo.Location = new Point(488, 123);
            groupBoxAccountinfo.Name = "groupBoxAccountinfo";
            groupBoxAccountinfo.Size = new Size(390, 547);
            groupBoxAccountinfo.TabIndex = 35;
            groupBoxAccountinfo.TabStop = false;
            groupBoxAccountinfo.Text = "Account Information";
            groupBoxAccountinfo.Enter += groupBoxAccountinfo_Enter;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.White;
            groupBox3.Controls.Add(groupBoxAccountinfo);
            groupBox3.Controls.Add(btnBackToLogin);
            groupBox3.Controls.Add(groupBoxStudentinfo);
            groupBox3.Controls.Add(lblTitle);
            groupBox3.Controls.Add(btnCreateAccount);
            groupBox3.Location = new Point(84, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(930, 826);
            groupBox3.TabIndex = 37;
            groupBox3.TabStop = false;
            // 
            // StudentSignUpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 860);
            Controls.Add(groupBox3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentSignUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Sign Up";
            Load += StudentSignUpForm_Load;
            groupBoxStudentinfo.ResumeLayout(false);
            groupBoxStudentinfo.PerformLayout();
            groupBoxAccountinfo.ResumeLayout(false);
            groupBoxAccountinfo.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label blPassword;
        private TextBox txtConfirmPassword;
        private Label lblConfirmPassword;
        private TextBox txtStudentNumber;
        private Label lblStudentNumber;
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
        private GroupBox groupBoxStudentinfo;
        private GroupBox groupBoxAccountinfo;
        private GroupBox groupBox3;
    }
}