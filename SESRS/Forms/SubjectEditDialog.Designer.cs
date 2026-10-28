namespace SESRS.Forms
{
    partial class SubjectEditDialog
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
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.nudUnits = new System.Windows.Forms.NumericUpDown();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.Name = "lblCode";
            this.lblCode.Location = new System.Drawing.Point(24, 20);
            this.lblCode.Size = new System.Drawing.Size(190, 20);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Subject code (for example CS101) *";
            // 
            // txtCode
            // 
            this.txtCode.Name = "txtCode";
            this.txtCode.Location = new System.Drawing.Point(24, 42);
            this.txtCode.Size = new System.Drawing.Size(190, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.MaxLength = 30;
            // 
            // lblUnits
            // 
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Location = new System.Drawing.Point(226, 20);
            this.lblUnits.Size = new System.Drawing.Size(190, 20);
            this.lblUnits.TabIndex = 2;
            this.lblUnits.Text = "Units";
            // 
            // nudUnits
            // 
            this.nudUnits.Name = "nudUnits";
            this.nudUnits.Location = new System.Drawing.Point(226, 42);
            this.nudUnits.Maximum = new decimal(new int[] {12, 0, 0, 0});
            this.nudUnits.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudUnits.Size = new System.Drawing.Size(190, 23);
            this.nudUnits.TabIndex = 3;
            this.nudUnits.Value = new decimal(new int[] {3, 0, 0, 0});
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.Location = new System.Drawing.Point(24, 79);
            this.lblName.Size = new System.Drawing.Size(392, 20);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Subject name *";
            // 
            // txtName
            // 
            this.txtName.Name = "txtName";
            this.txtName.Location = new System.Drawing.Point(24, 101);
            this.txtName.Size = new System.Drawing.Size(392, 23);
            this.txtName.TabIndex = 5;
            this.txtName.MaxLength = 150;
            // 
            // lblDescription
            // 
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Location = new System.Drawing.Point(24, 138);
            this.lblDescription.Size = new System.Drawing.Size(392, 20);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description (optional)";
            // 
            // txtDescription
            // 
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Location = new System.Drawing.Point(24, 160);
            this.txtDescription.Size = new System.Drawing.Size(392, 56);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 230);
            this.lblError.Size = new System.Drawing.Size(392, 36);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 270);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 9;
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
            this.btnCancel.Location = new System.Drawing.Point(226, 270);
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.TabIndex = 10;
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
            // SubjectEditDialog
            // 
            this.Name = "SubjectEditDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 330);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Subject";
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblUnits);
            this.Controls.Add(this.nudUnits);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            ((System.ComponentModel.ISupportInitialize)(this.nudUnits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.NumericUpDown nudUnits;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
