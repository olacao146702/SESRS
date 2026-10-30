using System;
using System.Windows.Forms;
using SESRS.Helpers;
using SESRS.Models;
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

            btnLogin.Enabled = false;
            UseWaitCursor = true;

            try
            {
                LoginResult result = new UserService().Login(username, password);

                switch (result.Status)
                {
                    case LoginStatus.Success:
                        OpenPortal(result.User!);
                        break;

                    case LoginStatus.Locked:
                        ShowLoginError(
                            "Too many failed attempts. This account is locked until " +
                            (result.LockedUntil?.ToString("h:mm tt") ?? "later") +
                            ".\n\nPlease try again then, or ask the registrar's office to reset your password."
                        );
                        break;

                    case LoginStatus.AccountInactive:
                        ShowLoginError(
                            "This account has been deactivated.\n\nPlease contact the registrar's office."
                        );
                        break;

                    default:
                        ShowLoginError("Invalid username or password.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to sign in.\n\n" + ErrorHandler.Friendly(ex),
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                UseWaitCursor = false;
                btnLogin.Enabled = true;
                txtPassword.Clear();
            }
        }

        private void OpenPortal(User user)
        {
            Session.Start(user);

            // Accounts created or reset by an administrator use a temporary
            // password that must be replaced before anything else.
            if (user.MustChangePassword)
            {
                using var changePassword = new ChangePasswordForm(forced: true);

                if (changePassword.ShowDialog(this) != DialogResult.OK)
                {
                    Session.End();
                    return;
                }
            }

            if (user.Role == "Admin")
            {
                new DashboardForm().Show();
                Hide();
            }
            else if (user.Role == "Student")
            {
                new StudentDashboardForm(user).Show();
                Hide();
            }
            else
            {
                Session.End();
                ShowLoginError("Your account does not have a valid role.");
            }
        }

        private static void ShowLoginError(string message)
        {
            MessageBox.Show(
                message,
                "Login Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
