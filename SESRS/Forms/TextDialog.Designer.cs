namespace SESRS.Forms
{
    partial class TextDialog
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
            this.txtBody = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBody
            // 
            this.txtBody.Name = "txtBody";
            this.txtBody.BackColor = System.Drawing.Color.White;
            this.txtBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBody.Multiline = true;
            this.txtBody.ReadOnly = true;
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.TabIndex = 0;
            this.txtBody.Text = "";
            // 
            // lblHeader
            // 
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblHeader.Padding = new System.Windows.Forms.Padding(16, 12, 16, 0);
            this.lblHeader.Size = new System.Drawing.Size(560, 62);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlFooter.Size = new System.Drawing.Size(560, 56);
            this.pnlFooter.TabIndex = 2;
            this.pnlFooter.Controls.Add(this.btnClose);
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "CLOSE";
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.BackColor = System.Drawing.Color.DarkGreen;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            // 
            // TextDialog
            // 
            this.Name = "TextDialog";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 420);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message";
            this.AcceptButton = this.btnClose;
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pnlFooter);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnClose;
    }
}
