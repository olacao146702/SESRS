namespace SESRS.Forms
{
    partial class ChangePasswordForm
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Size = new System.Drawing.Size(392, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Change Password";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Location = new System.Drawing.Point(24, 60);
            this.lblMessage.Size = new System.Drawing.Size(392, 48);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Enter your current password, then choose a new one.";
            // 
            // lblCurrent
            // 
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Location = new System.Drawing.Point(24, 118);
            this.lblCurrent.Size = new System.Drawing.Size(392, 20);
            this.lblCurrent.TabIndex = 2;
            this.lblCurrent.Text = "Current password";
            // 
            // txtCurrent
            // 
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Location = new System.Drawing.Point(24, 142);
            this.txtCurrent.Size = new System.Drawing.Size(392, 23);
            this.txtCurrent.TabIndex = 3;
            this.txtCurrent.MaxLength = 72;
            this.txtCurrent.UseSystemPasswordChar = true;
            // 
            // lblNew
            // 
            this.lblNew.Name = "lblNew";
            this.lblNew.Location = new System.Drawing.Point(24, 184);
            this.lblNew.Size = new System.Drawing.Size(392, 20);
            this.lblNew.TabIndex = 4;
            this.lblNew.Text = "New password";
            // 
            // txtNew
            // 
            this.txtNew.Name = "txtNew";
            this.txtNew.Location = new System.Drawing.Point(24, 208);
            this.txtNew.Size = new System.Drawing.Size(392, 23);
            this.txtNew.TabIndex = 5;
            this.txtNew.MaxLength = 72;
            this.txtNew.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Location = new System.Drawing.Point(24, 250);
            this.lblConfirm.Size = new System.Drawing.Size(392, 20);
            this.lblConfirm.TabIndex = 6;
            this.lblConfirm.Text = "Confirm new password";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Location = new System.Drawing.Point(24, 274);
            this.txtConfirm.Size = new System.Drawing.Size(392, 23);
            this.txtConfirm.TabIndex = 7;
            this.txtConfirm.MaxLength = 72;
            this.txtConfirm.UseSystemPasswordChar = true;
            // 
            // lblHint
            // 
            this.lblHint.Name = "lblHint";
            this.lblHint.Location = new System.Drawing.Point(24, 314);
            this.lblHint.Size = new System.Drawing.Size(392, 22);
            this.lblHint.TabIndex = 8;
            this.lblHint.Text = "At least 8 characters, with letters and numbers.";
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.ForeColor = System.Drawing.Color.DimGray;
            // 
            // chkShow
            // 
            this.chkShow.Name = "chkShow";
            this.chkShow.Location = new System.Drawing.Point(24, 340);
            this.chkShow.Size = new System.Drawing.Size(200, 26);
            this.chkShow.TabIndex = 9;
            this.chkShow.Text = "Show passwords";
            this.chkShow.UseVisualStyleBackColor = true;
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 372);
            this.lblError.Size = new System.Drawing.Size(392, 44);
            this.lblError.TabIndex = 10;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 420);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "CHANGE PASSWORD";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Location = new System.Drawing.Point(226, 420);
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // ChangePasswordForm
            // 
            this.Name = "ChangePasswordForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 470);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
