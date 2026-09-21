using System;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter your username and password.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                UserService userService = new UserService();

                var user = userService.Login(username, password);

                if (user != null)
                {
                    if (user.Role == "Admin")
                    {
                        DashboardForm dashboard = new DashboardForm();

                        dashboard.Show();
                        this.Hide();
                    }
                    else if (user.Role == "Student")
                    {
                        StudentDashboardForm studentDashboard =
                            new StudentDashboardForm(user);

                        studentDashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid user role.",
                            "Login Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Invalid username or password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to connect to the database.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCreateAccount_Click(object? sender, EventArgs e)
        {
            this.Hide();

            StudentSignUpForm signUpForm = new StudentSignUpForm();

            signUpForm.ShowDialog();

            this.Show();
        }
    }
}