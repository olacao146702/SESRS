namespace SESRS.Forms
{
    partial class ProgramEditDialog
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
            this.lblYears = new System.Windows.Forms.Label();
            this.nudYears = new System.Windows.Forms.NumericUpDown();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudYears)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.Name = "lblCode";
            this.lblCode.Location = new System.Drawing.Point(24, 20);
            this.lblCode.Size = new System.Drawing.Size(190, 20);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Program code (for example BSIT) *";
            // 
            // txtCode
            // 
            this.txtCode.Name = "txtCode";
            this.txtCode.Location = new System.Drawing.Point(24, 42);
            this.txtCode.Size = new System.Drawing.Size(190, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.MaxLength = 20;
            // 
            // lblYears
            // 
            this.lblYears.Name = "lblYears";
            this.lblYears.Location = new System.Drawing.Point(226, 20);
            this.lblYears.Size = new System.Drawing.Size(190, 20);
            this.lblYears.TabIndex = 2;
            this.lblYears.Text = "Duration (years)";
            // 
            // nudYears
            // 
            this.nudYears.Name = "nudYears";
            this.nudYears.Location = new System.Drawing.Point(226, 42);
            this.nudYears.Maximum = new decimal(new int[] {8, 0, 0, 0});
            this.nudYears.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudYears.Size = new System.Drawing.Size(190, 23);
            this.nudYears.TabIndex = 3;
            this.nudYears.Value = new decimal(new int[] {4, 0, 0, 0});
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.Location = new System.Drawing.Point(24, 79);
            this.lblName.Size = new System.Drawing.Size(392, 20);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Program name *";
            // 
            // txtName
            // 
            this.txtName.Name = "txtName";
            this.txtName.Location = new System.Drawing.Point(24, 101);
            this.txtName.Size = new System.Drawing.Size(392, 23);
            this.txtName.TabIndex = 5;
            this.txtName.MaxLength = 150;
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 138);
            this.lblError.Size = new System.Drawing.Size(392, 36);
            this.lblError.TabIndex = 6;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 178);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 7;
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
            this.btnCancel.Location = new System.Drawing.Point(226, 178);
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.TabIndex = 8;
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
            // ProgramEditDialog
            // 
            this.Name = "ProgramEditDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 238);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Program";
            this.CancelButton = this.btnCancel;
            this.AcceptButton = this.btnSave;
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblYears);
            this.Controls.Add(this.nudYears);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            ((System.ComponentModel.ISupportInitialize)(this.nudYears)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblYears;
        private System.Windows.Forms.NumericUpDown nudYears;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
