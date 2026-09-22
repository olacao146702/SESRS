using System;
using System.Windows.Forms;
using SESRS.Services;

namespace SESRS.Forms
{
    public partial class StudentSignUpForm : Form
    {
        private readonly StudentService _studentService = new();

        public StudentSignUpForm()
        {
            InitializeComponent();

            LoadGenderOptions();
            LoadYearLevelOptions();
            LoadProgramOptions();

            btnCreateAccount.Click += btnCreateAccount_Click;
            btnBackToLogin.Click += btnBackToLogin_Click;
        }

        private void StudentSignUpForm_Load(object sender, EventArgs e)
        {
        }

        private void LoadGenderOptions()
        {
            cmbGender.Items.Clear();

            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");

            cmbGender.SelectedIndex = -1;
        }

        private void LoadYearLevelOptions()
        {
            cmbYearLevel.Items.Clear();

            cmbYearLevel.Items.Add("1st Year");
            cmbYearLevel.Items.Add("2nd Year");
            cmbYearLevel.Items.Add("3rd Year");
            cmbYearLevel.Items.Add("4th Year");

            cmbYearLevel.SelectedIndex = -1;
        }

        private void LoadProgramOptions()
        {
            cmbProgram.Items.Clear();

            try
            {
                var programs = _studentService.GetActivePrograms();

                foreach (var program in programs)
                {
                    cmbProgram.Items.Add(
                        new ProgramItem(program.Id, program.Name)
                    );
                }

                cmbProgram.DisplayMember = "Name";
                cmbProgram.ValueMember = "Id";
                cmbProgram.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load programs.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCreateAccount_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            string studentNumber = txtStudentNumber.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string middleName = txtMiddleName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            string gender = cmbGender.Text;
            DateTime birthDate = dtpBirthDate.Value;

            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(studentNumber) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show(
                    "Please fill in all required fields.",
                    "Incomplete Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Passwords do not match.",
                    "Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtConfirmPassword.Focus();
                return;
            }

            if (cmbProgram.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a program.",
                    "Program Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbProgram.Focus();
                return;
            }

            if (cmbYearLevel.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a year level.",
                    "Year Level Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbYearLevel.Focus();
                return;
            }

            if (_studentService.StudentNumberExists(studentNumber))
            {
                MessageBox.Show(
                    "The student number is already registered.",
                    "Duplicate Student Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtStudentNumber.Focus();
                return;
            }

            if (_studentService.UsernameExists(username))
            {
                MessageBox.Show(
                    "The username is already taken.",
                    "Duplicate Username",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtUsername.Focus();
                return;
            }

            ProgramItem selectedProgram =
                (ProgramItem)cmbProgram.SelectedItem;

            int programId = selectedProgram.Id;

            int yearLevel = cmbYearLevel.SelectedIndex + 1;

            string passwordHash =
                BCrypt.Net.BCrypt.HashPassword(password);

            bool registered = _studentService.RegisterStudent(
                username,
                passwordHash,
                firstName,
                middleName,
                lastName,
                gender,
                birthDate,
                email,
                phone,
                address,
                programId,
                yearLevel,
                studentNumber
            );

            if (registered)
            {
                MessageBox.Show(
                    "Student account created successfully!\n\n" +
                    "You can now log in using your username and password.",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearForm();

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Unable to create the student account.\n\n" +
                    "Please check your information and try again.",
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBackToLogin_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            txtStudentNumber.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();

            cmbGender.SelectedIndex = -1;

            dtpBirthDate.Value = DateTime.Today;

            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();

            cmbProgram.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;
        }

        private class ProgramItem
        {
            public int Id { get; }
            public string Name { get; }

            public ProgramItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblConfirmPassword_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxStudentinfo_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxAccountinfo_Enter(object sender, EventArgs e)
        {

        }
    }
}