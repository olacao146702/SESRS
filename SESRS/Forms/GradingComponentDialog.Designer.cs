namespace SESRS.Forms
{
    partial class GradingComponentDialog
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
            this.lblScope = new System.Windows.Forms.Label();
            this.cmbScope = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.nudOrder = new System.Windows.Forms.NumericUpDown();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Location = new System.Drawing.Point(24, 20);
            this.lblIntro.Size = new System.Drawing.Size(392, 36);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "Weights of one setup must add up to 100%. A subject-specific setup replaces the default for that subject.";
            this.lblIntro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntro.ForeColor = System.Drawing.Color.DimGray;
            // 
            // lblScope
            // 
            this.lblScope.Name = "lblScope";
            this.lblScope.Location = new System.Drawing.Point(24, 66);
            this.lblScope.Size = new System.Drawing.Size(392, 20);
            this.lblScope.TabIndex = 1;
            this.lblScope.Text = "Applies to *";
            // 
            // cmbScope
            // 
            this.cmbScope.Name = "cmbScope";
            this.cmbScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScope.FormattingEnabled = true;
            this.cmbScope.Location = new System.Drawing.Point(24, 88);
            this.cmbScope.Size = new System.Drawing.Size(392, 23);
            this.cmbScope.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.Location = new System.Drawing.Point(24, 125);
            this.lblName.Size = new System.Drawing.Size(392, 20);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Component name (for example Quizzes) *";
            // 
            // txtName
            // 
            this.txtName.Name = "txtName";
            this.txtName.Location = new System.Drawing.Point(24, 147);
            this.txtName.Size = new System.Drawing.Size(392, 23);
            this.txtName.TabIndex = 4;
            this.txtName.MaxLength = 50;
            // 
            // lblWeight
            // 
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Location = new System.Drawing.Point(24, 184);
            this.lblWeight.Size = new System.Drawing.Size(190, 20);
            this.lblWeight.TabIndex = 5;
            this.lblWeight.Text = "Weight in percent *";
            // 
            // txtWeight
            // 
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Location = new System.Drawing.Point(24, 206);
            this.txtWeight.Size = new System.Drawing.Size(190, 23);
            this.txtWeight.TabIndex = 6;
            this.txtWeight.MaxLength = 6;
            // 
            // lblOrder
            // 
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Location = new System.Drawing.Point(226, 184);
            this.lblOrder.Size = new System.Drawing.Size(190, 20);
            this.lblOrder.TabIndex = 7;
            this.lblOrder.Text = "Order in the sheet";
            // 
            // nudOrder
            // 
            this.nudOrder.Name = "nudOrder";
            this.nudOrder.Location = new System.Drawing.Point(226, 206);
            this.nudOrder.Maximum = new decimal(new int[] {99, 0, 0, 0});
            this.nudOrder.Minimum = new decimal(new int[] {0, 0, 0, 0});
            this.nudOrder.Size = new System.Drawing.Size(190, 23);
            this.nudOrder.TabIndex = 8;
            this.nudOrder.Value = new decimal(new int[] {1, 0, 0, 0});
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.Location = new System.Drawing.Point(24, 243);
            this.lblError.Size = new System.Drawing.Size(392, 36);
            this.lblError.TabIndex = 9;
            this.lblError.Text = "";
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(24, 283);
            this.btnSave.Size = new System.Drawing.Size(190, 38);
            this.btnSave.TabIndex = 10;
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
            this.btnCancel.Location = new System.Drawing.Point(226, 283);
            this.btnCancel.Size = new System.Drawing.Size(190, 38);
            this.btnCancel.TabIndex = 11;
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
            // GradingComponentDialog
            // 
            this.Name = "GradingComponentDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 343);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grading Component";
            this.CancelButton = this.btnCancel;
            this.AcceptButton = this.btnSave;
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblScope);
            this.Controls.Add(this.cmbScope);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.nudOrder);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            ((System.ComponentModel.ISupportInitialize)(this.nudOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblScope;
        private System.Windows.Forms.ComboBox cmbScope;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.NumericUpDown nudOrder;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
