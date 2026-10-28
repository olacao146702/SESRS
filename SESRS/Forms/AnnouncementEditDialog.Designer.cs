namespace SESRS.Forms
{
    partial class AnnouncementEditDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.chkHasExpiry = new System.Windows.Forms.CheckBox();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Location = new System.Drawing.Point(24, 20);
            this.lblIntro.Size = new System.Drawing.Size(392, 36);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "Each targeted student receives a notification when you publish.";
            this.lblIntro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.ForeColor = System.Drawing.Color.DimGray;
            // 
            // lblTitle
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Location = new System.Drawing.Point(24, 66);
            this.lblTitle.Size = new System.Drawing.Size(392, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title *";
            // 
            // txtTitle
            // 
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Location = new System.Drawing.Point(24, 88);
            this.txtTitle.Size = new System.Drawing.Size(392, 23);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.MaxLength = 150;
            // 
            // lblBody
            // 
            this.lblBody.Name = "lblBody";
            this.lblBody.Location = new System.Drawing.Point(24, 125);
            this.lblBody.Size = new System.Drawing.Size(392, 20);
            this.lblBody.TabIndex = 3;
            this.lblBody.Text = "Message *";
            // 
            // txtBody
            // 
            this.txtBody.Name = "txtBody";
            this.txtBody.Location = new System.Drawing.Point(24, 147);
            this.txtBody.Size = new System.Drawing.Size(392, 110);
            this.txtBody.TabIndex = 4;
            this.txtBody.MaxLength = 5000;
            this.txtBody.Multiline = true;
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // 
            // lblProgram
            // 
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Location = new System.Drawing.Point(24, 271);
            this.lblProgram.Size = new System.Drawing.Size(190, 20);
            this.lblProgram.TabIndex = 5;
            this.lblProgram.Text = "Program";
            // 
            // cmbProgram
            // 
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.FormattingEnabled = true;
            this.cmbProgram.Location = new System.Drawing.Point(24, 293);
            this.cmbProgram.Size = new System.Drawing.Size(190, 23);
            this.cmbProgram.TabIndex = 6;
            // 
            // lblYear
            // 
            this.lblYear.Name = "lblYear";
            this.lblYear.Location = new System.Drawing.Point(226, 271);
            this.lblYear.Size = new System.Drawing.Size(190, 20);
            this.lblYear.TabIndex = 7;
            this.lblYear.Text = "Year level";
            // 
            // cmbYear
            // 
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(226, 293);
            this.cmbYear.Size = new System.Drawing.Size(190, 23);
            this.cmbYear.TabIndex = 8;
            // 
            // lblSection
            // 
            this.lblSection.Name = "lblSection";
            this.lblSection.Location = new System.Drawing.Point(24, 330);
            this.lblSection.Size = new System.Drawing.Size(392, 20);
            this.lblSection.TabIndex = 9;
            this.lblSection.Text = "Section (students enrolled in it)";
            // 
            // cmbSection
            // 
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(24, 352);
            this.cmbSection.Size = new System.Drawing.Size(392, 23);
            this.cmbSection.TabIndex = 10;
            // 
            // chkHasExpiry
            // 
            this.chkHasExpiry.Name = "chkHasExpiry";
            this.chkHasExpiry.AutoSize = false;
            this.chkHasExpiry.Location = new System.Drawing.Point(24, 389);
            this.chkHasExpiry.Size = new System.Drawing.Size(392, 24);
            this.chkHasExpiry.TabIndex = 11;
            this.chkHasExpiry.Text = "Stop showing this announcement after a date";
            this.chkHasExpiry.UseVisualStyleBackColor = true;
            // 
            // lblExpiry
            // 
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Location = new System.Drawing.Point(24, 427);
            this.lblExpiry.Size = new System.Drawing.Size(392, 20);
            this.lblExpiry.TabIndex = 12;
            this.lblExpiry.Text = "Expiry date";
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiry.Location = new System.Drawing.Point(24, 449);
            this.dtpExpiry.Size = new System.Drawing.Size(392, 23);
            this.dtpExpiry.TabIndex = 13;
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 486);
            this.lblError.Size = new System.Drawing.Size(392, 36);
            this.lblError.TabIndex = 14;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 526);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "PUBLISH";
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
            this.btnCancel.Location = new System.Drawing.Point(226, 526);
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.TabIndex = 16;
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
            // AnnouncementEditDialog
            // 
            this.Name = "AnnouncementEditDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 586);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Announcement";
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.lblProgram);
            this.Controls.Add(this.cmbProgram);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.chkHasExpiry);
            this.Controls.Add(this.lblExpiry);
            this.Controls.Add(this.dtpExpiry);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.CheckBox chkHasExpiry;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
