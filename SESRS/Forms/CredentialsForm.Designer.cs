namespace SESRS.Forms
{
    partial class CredentialsForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblUsernameCaption = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPasswordCaption = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Size = new System.Drawing.Size(412, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Account Credentials";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            // 
            // lblStudent
            // 
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Location = new System.Drawing.Point(24, 62);
            this.lblStudent.Size = new System.Drawing.Size(412, 22);
            this.lblStudent.TabIndex = 1;
            this.lblStudent.Text = "Student:";
            // 
            // lblUsernameCaption
            // 
            this.lblUsernameCaption.Name = "lblUsernameCaption";
            this.lblUsernameCaption.Location = new System.Drawing.Point(24, 98);
            this.lblUsernameCaption.Size = new System.Drawing.Size(412, 20);
            this.lblUsernameCaption.TabIndex = 2;
            this.lblUsernameCaption.Text = "Username (also the student number for students)";
            // 
            // txtUsername
            // 
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Location = new System.Drawing.Point(24, 122);
            this.txtUsername.Size = new System.Drawing.Size(412, 30);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.ReadOnly = true;
            this.txtUsername.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblPasswordCaption
            // 
            this.lblPasswordCaption.Name = "lblPasswordCaption";
            this.lblPasswordCaption.Location = new System.Drawing.Point(24, 164);
            this.lblPasswordCaption.Size = new System.Drawing.Size(412, 20);
            this.lblPasswordCaption.TabIndex = 4;
            this.lblPasswordCaption.Text = "Temporary password";
            // 
            // txtPassword
            // 
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Location = new System.Drawing.Point(24, 188);
            this.txtPassword.Size = new System.Drawing.Size(412, 30);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.ReadOnly = true;
            this.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblNote
            // 
            this.lblNote.Name = "lblNote";
            this.lblNote.Location = new System.Drawing.Point(24, 236);
            this.lblNote.Size = new System.Drawing.Size(412, 56);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "Give these credentials to the student. The password is shown only once and the student must choose a new one at first sign-in.";
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.DimGray;
            // 
            // btnCopy
            // 
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Location = new System.Drawing.Point(24, 300);
            this.btnCopy.Size = new System.Drawing.Size(200, 38);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "COPY";
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.BackColor = System.Drawing.Color.White;
            this.btnCopy.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnCopy.FlatAppearance.BorderSize = 1;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDone
            // 
            this.btnDone.Name = "btnDone";
            this.btnDone.Location = new System.Drawing.Point(236, 300);
            this.btnDone.Size = new System.Drawing.Size(200, 38);
            this.btnDone.TabIndex = 8;
            this.btnDone.Text = "DONE";
            this.btnDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.BackColor = System.Drawing.Color.DarkGreen;
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            // 
            // CredentialsForm
            // 
            this.Name = "CredentialsForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 350);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Account Credentials";
            this.AcceptButton = this.btnDone;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.lblUsernameCaption);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPasswordCaption);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnDone);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblUsernameCaption;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPasswordCaption;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDone;
    }
}
