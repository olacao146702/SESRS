namespace SESRS.Forms
{
    partial class GradeSheetForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.lblInfo = new System.Windows.Forms.Label();
            this.flowFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTerm = new System.Windows.Forms.Label();
            this.cmbTerm = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnUnpublish = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnPrior = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.flowFilters.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.flowButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGrades
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(24, 82, 58);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(24, 82, 58);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(244, 248, 245);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(198, 226, 208);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrades.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AllowUserToDeleteRows = false;
            this.dgvGrades.AllowUserToResizeRows = false;
            this.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGrades.ColumnHeadersHeight = 46;
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrades.EnableHeadersVisualStyles = false;
            this.dgvGrades.MultiSelect = false;
            this.dgvGrades.ReadOnly = false;
            this.dgvGrades.RowHeadersVisible = false;
            this.dgvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvGrades.TabIndex = 9;
            this.dgvGrades.RowTemplate.Height = 32;
            // 
            // lblInfo
            // 
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.BackColor = System.Drawing.Color.White;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Padding = new System.Windows.Forms.Padding(20, 6, 20, 0);
            this.lblInfo.Size = new System.Drawing.Size(1000, 30);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "";
            // 
            // flowFilters
            // 
            this.flowFilters.Name = "flowFilters";
            this.flowFilters.BackColor = System.Drawing.Color.White;
            this.flowFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowFilters.Padding = new System.Windows.Forms.Padding(16, 6, 16, 0);
            this.flowFilters.Size = new System.Drawing.Size(1000, 48);
            this.flowFilters.TabIndex = 3;
            this.flowFilters.WrapContents = false;
            this.flowFilters.Controls.Add(this.lblTerm);
            this.flowFilters.Controls.Add(this.cmbTerm);
            this.flowFilters.Controls.Add(this.lblClass);
            this.flowFilters.Controls.Add(this.cmbClass);
            // 
            // lblTerm
            // 
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.AutoSize = true;
            this.lblTerm.TabIndex = 4;
            this.lblTerm.Text = "Term:";
            this.lblTerm.Margin = new System.Windows.Forms.Padding(8, 8, 4, 0);
            // 
            // cmbTerm
            // 
            this.cmbTerm.Name = "cmbTerm";
            this.cmbTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerm.FormattingEnabled = true;
            this.cmbTerm.Location = new System.Drawing.Point(0, 0);
            this.cmbTerm.Size = new System.Drawing.Size(240, 23);
            this.cmbTerm.TabIndex = 5;
            this.cmbTerm.Margin = new System.Windows.Forms.Padding(0, 4, 12, 0);
            this.cmbTerm.SelectedIndexChanged += new System.EventHandler(this.cmbTerm_SelectedIndexChanged);
            // 
            // lblClass
            // 
            this.lblClass.Name = "lblClass";
            this.lblClass.AutoSize = true;
            this.lblClass.TabIndex = 6;
            this.lblClass.Text = "Class:";
            this.lblClass.Margin = new System.Windows.Forms.Padding(8, 8, 4, 0);
            // 
            // cmbClass
            // 
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(0, 0);
            this.cmbClass.Size = new System.Drawing.Size(520, 23);
            this.cmbClass.TabIndex = 7;
            this.cmbClass.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1000, 78);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            // 
            // lblTitle
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Grades";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(22, 48);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Enter scores per component, review, then publish. Students only see published grades.";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlBottom.Size = new System.Drawing.Size(1000, 96);
            this.pnlBottom.TabIndex = 19;
            this.pnlBottom.Controls.Add(this.flowButtons);
            this.pnlBottom.Controls.Add(this.lblStatus);
            // 
            // flowButtons
            // 
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.AutoScroll = true;
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowButtons.Size = new System.Drawing.Size(1000, 44);
            this.flowButtons.TabIndex = 10;
            this.flowButtons.WrapContents = false;
            this.flowButtons.Controls.Add(this.btnSave);
            this.flowButtons.Controls.Add(this.btnReview);
            this.flowButtons.Controls.Add(this.btnPublish);
            this.flowButtons.Controls.Add(this.btnUnpublish);
            this.flowButtons.Controls.Add(this.btnHistory);
            this.flowButtons.Controls.Add(this.btnPrior);
            this.flowButtons.Controls.Add(this.btnPrint);
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 36);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "SAVE SCORES";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReview
            // 
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(100, 36);
            this.btnReview.TabIndex = 12;
            this.btnReview.Text = "REVIEW";
            this.btnReview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReview.BackColor = System.Drawing.Color.White;
            this.btnReview.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnReview.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnReview.FlatAppearance.BorderSize = 1;
            this.btnReview.UseVisualStyleBackColor = false;
            this.btnReview.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(110, 36);
            this.btnPublish.TabIndex = 13;
            this.btnPublish.Text = "PUBLISH";
            this.btnPublish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublish.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublish.BackColor = System.Drawing.Color.White;
            this.btnPublish.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnPublish.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPublish.FlatAppearance.BorderSize = 1;
            this.btnPublish.UseVisualStyleBackColor = false;
            this.btnPublish.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // btnUnpublish
            // 
            this.btnUnpublish.Name = "btnUnpublish";
            this.btnUnpublish.Size = new System.Drawing.Size(120, 36);
            this.btnUnpublish.TabIndex = 14;
            this.btnUnpublish.Text = "UNPUBLISH";
            this.btnUnpublish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnpublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnpublish.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnpublish.BackColor = System.Drawing.Color.White;
            this.btnUnpublish.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnUnpublish.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnUnpublish.FlatAppearance.BorderSize = 1;
            this.btnUnpublish.UseVisualStyleBackColor = false;
            this.btnUnpublish.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnUnpublish.Click += new System.EventHandler(this.btnUnpublish_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(110, 36);
            this.btnHistory.TabIndex = 15;
            this.btnHistory.Text = "HISTORY";
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.BackColor = System.Drawing.Color.White;
            this.btnHistory.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnHistory.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnHistory.FlatAppearance.BorderSize = 1;
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnPrior
            // 
            this.btnPrior.Name = "btnPrior";
            this.btnPrior.Size = new System.Drawing.Size(190, 36);
            this.btnPrior.TabIndex = 16;
            this.btnPrior.Text = "ADD PRIOR RECORD";
            this.btnPrior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrior.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrior.BackColor = System.Drawing.Color.White;
            this.btnPrior.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnPrior.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPrior.FlatAppearance.BorderSize = 1;
            this.btnPrior.UseVisualStyleBackColor = false;
            this.btnPrior.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnPrior.Click += new System.EventHandler(this.btnPrior_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 36);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPrint.FlatAppearance.BorderSize = 1;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Size = new System.Drawing.Size(968, 24);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "";
            // 
            // GradeSheetForm
            // 
            this.Name = "GradeSheetForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "Grades";
            this.Controls.Add(this.dgvGrades);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.flowFilters);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBottom);
            this.Load += new System.EventHandler(this.GradeSheetForm_Load);
            this.flowButtons.ResumeLayout(false);
            this.flowButtons.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flowFilters.ResumeLayout(false);
            this.flowFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.FlowLayoutPanel flowFilters;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.ComboBox cmbTerm;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnUnpublish;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnPrior;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblStatus;
    }
}
