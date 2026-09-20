namespace SESRS.Forms
{
    partial class LoginForm
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
            pnlLogin = new Panel();
            btnLogin = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.White;
            pnlLogin.BorderStyle = BorderStyle.FixedSingle;
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(lblUsername);
            pnlLogin.Controls.Add(lblSubtitle);
            pnlLogin.Controls.Add(lblTitle);
            pnlLogin.Location = new Point(117, 62);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(495, 494);
            pnlLogin.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DarkGreen;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(179, 387);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(128, 50);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(55, 310);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(338, 37);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.ForeColor = Color.DimGray;
            lblPassword.Location = new Point(55, 269);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(104, 38);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(55, 196);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(338, 37);
            txtUsername.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.ForeColor = Color.DimGray;
            lblUsername.Location = new Point(55, 155);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(104, 38);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            // 
            // lblSubtitle
            // 
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(39, 86);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 40);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Student Enrollment & Registration System";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(26, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(440, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SESRS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(752, 651);
            Controls.Add(pnlLogin);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(225, 30);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SESRS - Login";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLogin;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblPassword;
        private TextBox txtUsername;
        private Label lblUsername;
        private Button btnLogin;
        private TextBox txtPassword;
    }
}