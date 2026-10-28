namespace SESRS.Forms
{
    partial class ScaleRowDialog
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
            this.lblMin = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbResult = new System.Windows.Forms.ComboBox();
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
            this.lblIntro.Text = "A final percent receives the grade of the highest row whose minimum it reaches.";
            this.lblIntro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.ForeColor = System.Drawing.Color.DimGray;
            // 
            // lblMin
            // 
            this.lblMin.Name = "lblMin";
            this.lblMin.Location = new System.Drawing.Point(24, 66);
            this.lblMin.Size = new System.Drawing.Size(190, 20);
            this.lblMin.TabIndex = 1;
            this.lblMin.Text = "Minimum percent (0 - 100) *";
            // 
            // txtMin
            // 
            this.txtMin.Name = "txtMin";
            this.txtMin.Location = new System.Drawing.Point(24, 88);
            this.txtMin.Size = new System.Drawing.Size(190, 23);
            this.txtMin.TabIndex = 2;
            this.txtMin.MaxLength = 6;
            // 
            // lblPoint
            // 
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Location = new System.Drawing.Point(226, 66);
            this.lblPoint.Size = new System.Drawing.Size(190, 20);
            this.lblPoint.TabIndex = 3;
            this.lblPoint.Text = "Grade point (1.00 - 5.00) *";
            // 
            // txtPoint
            // 
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Location = new System.Drawing.Point(226, 88);
            this.txtPoint.Size = new System.Drawing.Size(190, 23);
            this.txtPoint.TabIndex = 4;
            this.txtPoint.MaxLength = 4;
            // 
            // lblResult
            // 
            this.lblResult.Name = "lblResult";
            this.lblResult.Location = new System.Drawing.Point(24, 125);
            this.lblResult.Size = new System.Drawing.Size(392, 20);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "Result *";
            // 
            // cmbResult
            // 
            this.cmbResult.Items.AddRange(new object[] { "Passed", "Failed" });
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Location = new System.Drawing.Point(24, 147);
            this.cmbResult.Size = new System.Drawing.Size(392, 23);
            this.cmbResult.TabIndex = 6;
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 184);
            this.lblError.Size = new System.Drawing.Size(392, 36);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 224);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 8;
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
            this.btnCancel.Location = new System.Drawing.Point(226, 224);
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.TabIndex = 9;
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
            // ScaleRowDialog
            // 
            this.Name = "ScaleRowDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 284);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scale Row";
            this.CancelButton = this.btnCancel;
            this.AcceptButton = this.btnSave;
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cmbResult);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
