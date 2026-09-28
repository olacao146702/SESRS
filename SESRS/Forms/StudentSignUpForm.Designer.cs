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
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(342, 9);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Student Sign Up";
            // 
            // lblAccountInfo
            // 
            lblAccountInfo.AutoSize = true;
            lblAccountInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccountInfo.ForeColor = Color.DarkGreen;
            lblAccountInfo.Location = new Point(665, 59);
            lblAccountInfo.Margin = new Padding(2, 0, 2, 0);
            lblAccountInfo.Name = "lblAccountInfo";
            lblAccountInfo.Size = new Size(209, 28);
            lblAccountInfo.TabIndex = 1;
            lblAccountInfo.Text = "Account Information";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(20, 21);
            lblUsername.Margin = new Padding(2, 0, 2, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(87, 23);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(178, 19);
            txtUsername.Margin = new Padding(2, 2, 2, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(205, 27);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(178, 66);
            txtPassword.Margin = new Padding(2, 2, 2, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(205, 27);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // blPassword
            // 
            blPassword.AutoSize = true;
            blPassword.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            blPassword.Location = new Point(20, 68);
            blPassword.Margin = new Padding(2, 0, 2, 0);
            blPassword.Name = "blPassword";
            blPassword.Size = new Size(82, 23);
            blPassword.TabIndex = 4;
            blPassword.Text = "Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Location = new Point(178, 116);
            txtConfirmPassword.Margin = new Padding(2, 2, 2, 2);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(205, 27);
            txtConfirmPassword.TabIndex = 7;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfirmPassword.Location = new Point(20, 116);
            lblConfirmPassword.Margin = new Padding(2, 0, 2, 0);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(149, 23);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudentInfo.ForeColor = Color.DarkGreen;
            lblStudentInfo.Location = new Point(83, 59);
            lblStudentInfo.Margin = new Padding(2, 0, 2, 0);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(205, 28);
            lblStudentInfo.TabIndex = 10;
            lblStudentInfo.Text = "Student Information";
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.White;
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Location = new Point(147, 17);
            txtFirstName.Margin = new Padding(2, 2, 2, 2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(205, 27);
            txtFirstName.TabIndex = 12;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFirstName.Location = new Point(30, 21);
            lblFirstName.Margin = new Padding(2, 0, 2, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(93, 23);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "First Name";
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.White;
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Location = new Point(147, 111);
            txtLastName.Margin = new Padding(2, 2, 2, 2);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(205, 27);
            txtLastName.TabIndex = 14;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLastName.Location = new Point(32, 112);
            lblLastName.Margin = new Padding(2, 0, 2, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(91, 23);
            lblLastName.TabIndex = 13;
            lblLastName.Text = "Last Name";
            // 
            // txtMiddleName
            // 
            txtMiddleName.BackColor = Color.White;
            txtMiddleName.BorderStyle = BorderStyle.FixedSingle;
            txtMiddleName.Location = new Point(147, 64);
            txtMiddleName.Margin = new Padding(2, 2, 2, 2);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(205, 27);
            txtMiddleName.TabIndex = 16;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMiddleName.Location = new Point(30, 66);
            lblMiddleName.Margin = new Padding(2, 0, 2, 0);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(114, 23);
            lblMiddleName.TabIndex = 15;
            lblMiddleName.Text = "Middle Name";
            // 
            // cmbGender
            // 
            cmbGender.BackColor = Color.White;
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(147, 160);
            cmbGender.Margin = new Padding(2, 2, 2, 2);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(146, 28);
            cmbGender.TabIndex = 17;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGender.Location = new Point(32, 165);
            lblGender.Margin = new Padding(2, 0, 2, 0);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(66, 23);
            lblGender.TabIndex = 18;
            lblGender.Text = "Gender";
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBirthDate.Location = new Point(32, 215);
            lblBirthDate.Margin = new Padding(2, 0, 2, 0);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(87, 23);
            lblBirthDate.TabIndex = 19;
            lblBirthDate.Text = "Birth Date";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.CalendarMonthBackground = Color.White;
            dtpBirthDate.Location = new Point(147, 211);
            dtpBirthDate.Margin = new Padding(2, 2, 2, 2);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(241, 27);
            dtpBirthDate.TabIndex = 20;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(147, 260);
            txtEmail.Margin = new Padding(2, 2, 2, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(205, 27);
            txtEmail.TabIndex = 22;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(32, 264);
            lblEmail.Margin = new Padding(2, 0, 2, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 23);
            lblEmail.TabIndex = 21;
            lblEmail.Text = "Email";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.White;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Location = new Point(147, 312);
            txtPhone.Margin = new Padding(2, 2, 2, 2);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(205, 27);
            txtPhone.TabIndex = 24;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhone.Location = new Point(32, 316);
            lblPhone.Margin = new Padding(2, 0, 2, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(59, 23);
            lblPhone.TabIndex = 23;
            lblPhone.Text = "Phone";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.White;
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Location = new Point(147, 360);
            txtAddress.Margin = new Padding(2, 2, 2, 2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(241, 27);
            txtAddress.TabIndex = 26;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddress.Location = new Point(32, 364);
            lblAddress.Margin = new Padding(2, 0, 2, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(70, 23);
            lblAddress.TabIndex = 25;
            lblAddress.Text = "Address";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgram.Location = new Point(32, 414);
            lblProgram.Margin = new Padding(2, 0, 2, 0);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(76, 23);
            lblProgram.TabIndex = 27;
            lblProgram.Text = "Program";
            // 
            // cmbProgram
            // 
            cmbProgram.BackColor = Color.White;
            cmbProgram.ForeColor = SystemColors.WindowText;
            cmbProgram.FormattingEnabled = true;
            cmbProgram.Location = new Point(147, 409);
            cmbProgram.Margin = new Padding(2, 2, 2, 2);
            cmbProgram.Name = "cmbProgram";
            cmbProgram.Size = new Size(241, 28);
            cmbProgram.TabIndex = 29;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.BackColor = Color.White;
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(147, 459);
            cmbYearLevel.Margin = new Padding(2, 2, 2, 2);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(146, 28);
            cmbYearLevel.TabIndex = 31;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYearLevel.Location = new Point(32, 464);
            lblYearLevel.Margin = new Padding(2, 0, 2, 0);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(86, 23);
            lblYearLevel.TabIndex = 30;
            lblYearLevel.Text = "Year Level";
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.BackColor = Color.DarkGreen;
            btnCreateAccount.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Location = new Point(379, 624);
            btnCreateAccount.Margin = new Padding(2, 2, 2, 2);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(188, 46);
            btnCreateAccount.TabIndex = 32;
            btnCreateAccount.Text = "CREATE ACCOUNT";
            btnCreateAccount.UseVisualStyleBackColor = false;
            // 
            // btnBackToLogin
            // 
            btnBackToLogin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackToLogin.ForeColor = Color.DarkGreen;
            btnBackToLogin.Location = new Point(412, 674);
            btnBackToLogin.Margin = new Padding(2, 2, 2, 2);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(119, 27);
            btnBackToLogin.TabIndex = 33;
            btnBackToLogin.Text = "Back to Login";
            btnBackToLogin.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(txtConfirmPassword);
            panel1.Controls.Add(blPassword);
            panel1.Controls.Add(lblConfirmPassword);
            panel1.Controls.Add(txtPassword);
            panel1.Location = new Point(544, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(407, 162);
            panel1.TabIndex = 36;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtFirstName);
            panel2.Controls.Add(lblFirstName);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(lblLastName);
            panel2.Controls.Add(lblPhone);
            panel2.Controls.Add(txtLastName);
            panel2.Controls.Add(lblEmail);
            panel2.Controls.Add(cmbYearLevel);
            panel2.Controls.Add(txtPhone);
            panel2.Controls.Add(lblMiddleName);
            panel2.Controls.Add(dtpBirthDate);
            panel2.Controls.Add(lblYearLevel);
            panel2.Controls.Add(lblAddress);
            panel2.Controls.Add(txtMiddleName);
            panel2.Controls.Add(lblBirthDate);
            panel2.Controls.Add(cmbProgram);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(cmbGender);
            panel2.Controls.Add(lblGender);
            panel2.Controls.Add(lblProgram);
            panel2.Location = new Point(12, 90);
            panel2.Name = "panel2";
            panel2.Size = new Size(407, 512);
            panel2.TabIndex = 37;
            // 
            // StudentSignUpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(963, 840);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnBackToLogin);
            Controls.Add(btnCreateAccount);
            Controls.Add(lblStudentInfo);
            Controls.Add(lblAccountInfo);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentSignUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Sign Up";
            Load += StudentSignUpForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Panel panel1;
        private Panel panel2;
    }
}