namespace SESRS.Forms
{
    partial class EnrollStudentForm
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
            lblStudent = new Label();
            cmbStudent = new ComboBox();
            lblSchoolYear = new Label();
            txtSchoolYear = new TextBox();
            lblSemester = new Label();
            cmbSemester = new ComboBox();
            btnEnroll = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(279, 46);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(142, 27);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Enroll Student";
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(55, 120);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(63, 20);
            lblStudent.TabIndex = 1;
            lblStudent.Text = "Student:";
            // 
            // cmbStudent
            // 
            cmbStudent.FormattingEnabled = true;
            cmbStudent.Location = new Point(177, 112);
            cmbStudent.Name = "cmbStudent";
            cmbStudent.Size = new Size(280, 28);
            cmbStudent.TabIndex = 2;
            // 
            // lblSchoolYear
            // 
            lblSchoolYear.AutoSize = true;
            lblSchoolYear.Location = new Point(55, 183);
            lblSchoolYear.Name = "lblSchoolYear";
            lblSchoolYear.Size = new Size(89, 20);
            lblSchoolYear.TabIndex = 3;
            lblSchoolYear.Text = "School Year:";
            // 
            // txtSchoolYear
            // 
            txtSchoolYear.Location = new Point(177, 183);
            txtSchoolYear.Name = "txtSchoolYear";
            txtSchoolYear.Size = new Size(280, 27);
            txtSchoolYear.TabIndex = 4;
            // 
            // lblSemester
            // 
            lblSemester.AutoSize = true;
            lblSemester.Location = new Point(55, 256);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(73, 20);
            lblSemester.TabIndex = 5;
            lblSemester.Text = "Semester:";
            // 
            // cmbSemester
            // 
            cmbSemester.FormattingEnabled = true;
            cmbSemester.Items.AddRange(new object[] { "1st Semester", "2nd Semester", "Summer" });
            cmbSemester.Location = new Point(177, 248);
            cmbSemester.Name = "cmbSemester";
            cmbSemester.Size = new Size(280, 28);
            cmbSemester.TabIndex = 6;
            // 
            // btnEnroll
            // 
            btnEnroll.Location = new Point(257, 339);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(94, 29);
            btnEnroll.TabIndex = 7;
            btnEnroll.Text = "ENROLL";
            btnEnroll.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(391, 339);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // EnrollStudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnEnroll);
            Controls.Add(cmbSemester);
            Controls.Add(lblSemester);
            Controls.Add(txtSchoolYear);
            Controls.Add(lblSchoolYear);
            Controls.Add(cmbStudent);
            Controls.Add(lblStudent);
            Controls.Add(lblTitle);
            Name = "EnrollStudentForm";
            Text = "EnrollStudentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblStudent;
        private ComboBox cmbStudent;
        private Label lblSchoolYear;
        private TextBox txtSchoolYear;
        private Label lblSemester;
        private ComboBox cmbSemester;
        private Button btnEnroll;
        private Button btnCancel;
    }
}