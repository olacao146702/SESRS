namespace SESRS.Forms
{
    partial class StudentEditDialog
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
            this.lblIntro = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.lblMiddle = new System.Windows.Forms.Label();
            this.txtMiddle = new System.Windows.Forms.TextBox();
            this.lblLast = new System.Windows.Forms.Label();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblBirth = new System.Windows.Forms.Label();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Location = new System.Drawing.Point(24, 20);
            this.lblIntro.Size = new System.Drawing.Size(392, 21);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "Student number: -";
            this.lblIntro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.ForeColor = System.Drawing.Color.DimGray;
            // 
            // lblFirst
            // 
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Location = new System.Drawing.Point(24, 51);
            this.lblFirst.Size = new System.Drawing.Size(190, 20);
            this.lblFirst.TabIndex = 1;
            this.lblFirst.Text = "First name *";
            // 
            // txtFirst
            // 
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Location = new System.Drawing.Point(24, 73);
            this.txtFirst.Size = new System.Drawing.Size(190, 23);
            this.txtFirst.TabIndex = 2;
            this.txtFirst.MaxLength = 50;
            // 
            // lblMiddle
            // 
            this.lblMiddle.Name = "lblMiddle";
            this.lblMiddle.Location = new System.Drawing.Point(226, 51);
            this.lblMiddle.Size = new System.Drawing.Size(190, 20);
            this.lblMiddle.TabIndex = 3;
            this.lblMiddle.Text = "Middle name";
            // 
            // txtMiddle
            // 
            this.txtMiddle.Name = "txtMiddle";
            this.txtMiddle.Location = new System.Drawing.Point(226, 73);
            this.txtMiddle.Size = new System.Drawing.Size(190, 23);
            this.txtMiddle.TabIndex = 4;
            this.txtMiddle.MaxLength = 50;
            // 
            // lblLast
            // 
            this.lblLast.Name = "lblLast";
            this.lblLast.Location = new System.Drawing.Point(24, 110);
            this.lblLast.Size = new System.Drawing.Size(190, 20);
            this.lblLast.TabIndex = 5;
            this.lblLast.Text = "Last name *";
            // 
            // txtLast
            // 
            this.txtLast.Name = "txtLast";
            this.txtLast.Location = new System.Drawing.Point(24, 132);
            this.txtLast.Size = new System.Drawing.Size(190, 23);
            this.txtLast.TabIndex = 6;
            this.txtLast.MaxLength = 50;
            // 
            // lblGender
            // 
            this.lblGender.Name = "lblGender";
            this.lblGender.Location = new System.Drawing.Point(226, 110);
            this.lblGender.Size = new System.Drawing.Size(190, 20);
            this.lblGender.TabIndex = 7;
            this.lblGender.Text = "Gender *";
            // 
            // cmbGender
            // 
            this.cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(226, 132);
            this.cmbGender.Size = new System.Drawing.Size(190, 23);
            this.cmbGender.TabIndex = 8;
            // 
            // lblBirth
            // 
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Location = new System.Drawing.Point(24, 169);
            this.lblBirth.Size = new System.Drawing.Size(190, 20);
            this.lblBirth.TabIndex = 9;
            this.lblBirth.Text = "Birth date *";
            // 
            // dtpBirth
            // 
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirth.Location = new System.Drawing.Point(24, 191);
            this.dtpBirth.Size = new System.Drawing.Size(190, 23);
            this.dtpBirth.TabIndex = 10;
            // 
            // lblPhone
            // 
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Location = new System.Drawing.Point(226, 169);
            this.lblPhone.Size = new System.Drawing.Size(190, 20);
            this.lblPhone.TabIndex = 11;
            this.lblPhone.Text = "Phone *";
            // 
            // txtPhone
            // 
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Location = new System.Drawing.Point(226, 191);
            this.txtPhone.Size = new System.Drawing.Size(190, 23);
            this.txtPhone.TabIndex = 12;
            this.txtPhone.MaxLength = 20;
            // 
            // lblEmail
            // 
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Location = new System.Drawing.Point(24, 228);
            this.lblEmail.Size = new System.Drawing.Size(392, 20);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email *";
            // 
            // txtEmail
            // 
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Location = new System.Drawing.Point(24, 250);
            this.txtEmail.Size = new System.Drawing.Size(392, 23);
            this.txtEmail.TabIndex = 14;
            this.txtEmail.MaxLength = 100;
            // 
            // lblAddress
            // 
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Location = new System.Drawing.Point(24, 287);
            this.lblAddress.Size = new System.Drawing.Size(392, 20);
            this.lblAddress.TabIndex = 15;
            this.lblAddress.Text = "Address *";
            // 
            // txtAddress
            // 
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Location = new System.Drawing.Point(24, 309);
            this.txtAddress.Size = new System.Drawing.Size(392, 56);
            this.txtAddress.TabIndex = 16;
            this.txtAddress.MaxLength = 255;
            this.txtAddress.Multiline = true;
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // 
            // lblProgram
            // 
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Location = new System.Drawing.Point(24, 379);
            this.lblProgram.Size = new System.Drawing.Size(190, 20);
            this.lblProgram.TabIndex = 17;
            this.lblProgram.Text = "Program *";
            // 
            // cmbProgram
            // 
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(24, 401);
            this.cmbProgram.Size = new System.Drawing.Size(190, 23);
            this.cmbProgram.TabIndex = 18;
            // 
            // lblYear
            // 
            this.lblYear.Name = "lblYear";
            this.lblYear.Location = new System.Drawing.Point(226, 379);
            this.lblYear.Size = new System.Drawing.Size(190, 20);
            this.lblYear.TabIndex = 19;
            this.lblYear.Text = "Year level *";
            // 
            // cmbYear
            // 
            this.cmbYear.Items.AddRange(new object[] { "1st Year", "2nd Year", "3rd Year", "4th Year", "5th Year", "6th Year" });
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(226, 401);
            this.cmbYear.Size = new System.Drawing.Size(190, 23);
            this.cmbYear.TabIndex = 20;
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 438);
            this.lblError.Size = new System.Drawing.Size(392, 36);
            this.lblError.TabIndex = 21;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 478);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "SAVE";
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
            this.btnCancel.Location = new System.Drawing.Point(226, 478);
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.TabIndex = 23;
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
            // StudentEditDialog
            // 
            this.Name = "StudentEditDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 538);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Student";
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.lblMiddle);
            this.Controls.Add(this.txtMiddle);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.txtLast);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.dtpBirth);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblProgram);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label lblMiddle;
        private System.Windows.Forms.TextBox txtMiddle;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
