namespace SESRS.Forms
{
    partial class StudentEnrollmentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBuilder = new System.Windows.Forms.Panel();
            this.dgvOfferings = new System.Windows.Forms.DataGridView();
            this.pnlBuilderBottom = new System.Windows.Forms.Panel();
            this.rtbIssues = new System.Windows.Forms.RichTextBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnWaitlist = new System.Windows.Forms.Button();
            this.pnlSpacer2 = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pnlSpacer1 = new System.Windows.Forms.Panel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblUnits = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.lblSummaryInfo = new System.Windows.Forms.Label();
            this.pnlSummaryBottom = new System.Windows.Forms.Panel();
            this.btnCancelRequest = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBanner = new System.Windows.Forms.Label();
            this.lblWaitlist = new System.Windows.Forms.Label();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrerequisites = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSection = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfferings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.pnlBuilder.SuspendLayout();
            this.pnlBuilderBottom.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlSummaryBottom.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBuilder
            // 
            this.pnlBuilder.Name = "pnlBuilder";
            this.pnlBuilder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBuilder.TabIndex = 14;
            this.pnlBuilder.Controls.Add(this.dgvOfferings);
            this.pnlBuilder.Controls.Add(this.pnlBuilderBottom);
            // 
            // dgvOfferings
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
            this.dgvOfferings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOfferings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOfferings.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOfferings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colCode,
            this.colSubject,
            this.colUnits,
            this.colPrerequisites,
            this.colAvailability,
            this.colSection});
            this.dgvOfferings.Name = "dgvOfferings";
            this.dgvOfferings.AllowUserToAddRows = false;
            this.dgvOfferings.AllowUserToDeleteRows = false;
            this.dgvOfferings.AllowUserToResizeRows = false;
            this.dgvOfferings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOfferings.BackgroundColor = System.Drawing.Color.White;
            this.dgvOfferings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOfferings.ColumnHeadersHeight = 38;
            this.dgvOfferings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOfferings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOfferings.EnableHeadersVisualStyles = false;
            this.dgvOfferings.MultiSelect = false;
            this.dgvOfferings.ReadOnly = false;
            this.dgvOfferings.RowHeadersVisible = false;
            this.dgvOfferings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOfferings.TabIndex = 4;
            this.dgvOfferings.RowTemplate.Height = 32;
            // 
            // pnlBuilderBottom
            // 
            this.pnlBuilderBottom.Name = "pnlBuilderBottom";
            this.pnlBuilderBottom.BackColor = System.Drawing.Color.White;
            this.pnlBuilderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBuilderBottom.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlBuilderBottom.Size = new System.Drawing.Size(1000, 216);
            this.pnlBuilderBottom.TabIndex = 13;
            this.pnlBuilderBottom.Controls.Add(this.rtbIssues);
            this.pnlBuilderBottom.Controls.Add(this.pnlActions);
            // 
            // rtbIssues
            // 
            this.rtbIssues.Name = "rtbIssues";
            this.rtbIssues.BackColor = System.Drawing.Color.White;
            this.rtbIssues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbIssues.ReadOnly = true;
            this.rtbIssues.TabIndex = 12;
            this.rtbIssues.Text = "";
            // 
            // pnlActions
            // 
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlActions.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlActions.Size = new System.Drawing.Size(230, 180);
            this.pnlActions.TabIndex = 7;
            this.pnlActions.Controls.Add(this.btnWaitlist);
            this.pnlActions.Controls.Add(this.pnlSpacer2);
            this.pnlActions.Controls.Add(this.btnSubmit);
            this.pnlActions.Controls.Add(this.pnlSpacer1);
            this.pnlActions.Controls.Add(this.btnCheck);
            this.pnlActions.Controls.Add(this.lblUnits);
            // 
            // btnWaitlist
            // 
            this.btnWaitlist.Name = "btnWaitlist";
            this.btnWaitlist.Size = new System.Drawing.Size(206, 38);
            this.btnWaitlist.TabIndex = 8;
            this.btnWaitlist.Text = "JOIN WAITLIST (FULL SECTION)";
            this.btnWaitlist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWaitlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaitlist.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWaitlist.BackColor = System.Drawing.Color.White;
            this.btnWaitlist.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnWaitlist.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnWaitlist.FlatAppearance.BorderSize = 1;
            this.btnWaitlist.UseVisualStyleBackColor = false;
            this.btnWaitlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWaitlist.Click += new System.EventHandler(this.btnWaitlist_Click);
            // 
            // pnlSpacer2
            // 
            this.pnlSpacer2.Name = "pnlSpacer2";
            this.pnlSpacer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpacer2.Size = new System.Drawing.Size(206, 8);
            this.pnlSpacer2.TabIndex = 6;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(206, 38);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "SUBMIT ENROLLMENT";
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // pnlSpacer1
            // 
            this.pnlSpacer1.Name = "pnlSpacer1";
            this.pnlSpacer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpacer1.Size = new System.Drawing.Size(206, 8);
            this.pnlSpacer1.TabIndex = 5;
            // 
            // btnCheck
            // 
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(206, 38);
            this.btnCheck.TabIndex = 10;
            this.btnCheck.Text = "CHECK MY SELECTION";
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.BackColor = System.Drawing.Color.White;
            this.btnCheck.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnCheck.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnCheck.FlatAppearance.BorderSize = 1;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblUnits
            // 
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUnits.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnits.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblUnits.Size = new System.Drawing.Size(206, 52);
            this.lblUnits.TabIndex = 11;
            this.lblUnits.Text = "Selected: 0 units";
            // 
            // pnlSummary
            // 
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummary.Visible = false;
            this.pnlSummary.TabIndex = 19;
            this.pnlSummary.Controls.Add(this.dgvSummary);
            this.pnlSummary.Controls.Add(this.lblSummaryInfo);
            this.pnlSummary.Controls.Add(this.pnlSummaryBottom);
            // 
            // dgvSummary
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(24, 82, 58);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(24, 82, 58);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(244, 248, 245);
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(198, 226, 208);
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSummary.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.AllowUserToAddRows = false;
            this.dgvSummary.AllowUserToDeleteRows = false;
            this.dgvSummary.AllowUserToResizeRows = false;
            this.dgvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSummary.BackgroundColor = System.Drawing.Color.White;
            this.dgvSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSummary.ColumnHeadersHeight = 38;
            this.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSummary.EnableHeadersVisualStyles = false;
            this.dgvSummary.MultiSelect = false;
            this.dgvSummary.ReadOnly = true;
            this.dgvSummary.RowHeadersVisible = false;
            this.dgvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSummary.TabIndex = 15;
            this.dgvSummary.RowTemplate.Height = 32;
            // 
            // lblSummaryInfo
            // 
            this.lblSummaryInfo.Name = "lblSummaryInfo";
            this.lblSummaryInfo.BackColor = System.Drawing.Color.White;
            this.lblSummaryInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSummaryInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummaryInfo.Padding = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.lblSummaryInfo.Size = new System.Drawing.Size(1000, 54);
            this.lblSummaryInfo.TabIndex = 16;
            this.lblSummaryInfo.Text = "";
            // 
            // pnlSummaryBottom
            // 
            this.pnlSummaryBottom.Name = "pnlSummaryBottom";
            this.pnlSummaryBottom.BackColor = System.Drawing.Color.White;
            this.pnlSummaryBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummaryBottom.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlSummaryBottom.Size = new System.Drawing.Size(1000, 60);
            this.pnlSummaryBottom.TabIndex = 17;
            this.pnlSummaryBottom.Controls.Add(this.btnCancelRequest);
            // 
            // btnCancelRequest
            // 
            this.btnCancelRequest.Name = "btnCancelRequest";
            this.btnCancelRequest.Size = new System.Drawing.Size(210, 36);
            this.btnCancelRequest.TabIndex = 18;
            this.btnCancelRequest.Text = "CANCEL MY REQUEST";
            this.btnCancelRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelRequest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelRequest.BackColor = System.Drawing.Color.White;
            this.btnCancelRequest.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnCancelRequest.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnCancelRequest.FlatAppearance.BorderSize = 1;
            this.btnCancelRequest.UseVisualStyleBackColor = false;
            this.btnCancelRequest.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancelRequest.Click += new System.EventHandler(this.btnCancelRequest_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1000, 120);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblBanner);
            this.pnlHeader.Controls.Add(this.lblWaitlist);
            // 
            // lblTitle
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Enrollment";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            // 
            // lblBanner
            // 
            this.lblBanner.Name = "lblBanner";
            this.lblBanner.Location = new System.Drawing.Point(22, 52);
            this.lblBanner.Size = new System.Drawing.Size(900, 40);
            this.lblBanner.TabIndex = 2;
            this.lblBanner.Text = "";
            this.lblBanner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 
            // lblWaitlist
            // 
            this.lblWaitlist.Name = "lblWaitlist";
            this.lblWaitlist.Location = new System.Drawing.Point(22, 92);
            this.lblWaitlist.Size = new System.Drawing.Size(900, 24);
            this.lblWaitlist.TabIndex = 3;
            this.lblWaitlist.Text = "";
            this.lblWaitlist.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblWaitlist.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitlist.ForeColor = System.Drawing.Color.SteelBlue;
            // 
            // colSelect
            // 
            this.colSelect.Name = "colSelect";
            this.colSelect.HeaderText = "Enroll";
            this.colSelect.FillWeight = 40F;
            this.colSelect.MinimumWidth = 6;
            // 
            // colCode
            // 
            this.colCode.Name = "colCode";
            this.colCode.HeaderText = "Code";
            this.colCode.FillWeight = 60F;
            this.colCode.MinimumWidth = 6;
            this.colCode.ReadOnly = true;
            // 
            // colSubject
            // 
            this.colSubject.Name = "colSubject";
            this.colSubject.HeaderText = "Subject";
            this.colSubject.FillWeight = 130F;
            this.colSubject.MinimumWidth = 6;
            this.colSubject.ReadOnly = true;
            // 
            // colUnits
            // 
            this.colUnits.Name = "colUnits";
            this.colUnits.HeaderText = "Units";
            this.colUnits.FillWeight = 36F;
            this.colUnits.MinimumWidth = 6;
            this.colUnits.ReadOnly = true;
            // 
            // colPrerequisites
            // 
            this.colPrerequisites.Name = "colPrerequisites";
            this.colPrerequisites.HeaderText = "Prerequisites";
            this.colPrerequisites.FillWeight = 70F;
            this.colPrerequisites.MinimumWidth = 6;
            this.colPrerequisites.ReadOnly = true;
            // 
            // colAvailability
            // 
            this.colAvailability.Name = "colAvailability";
            this.colAvailability.HeaderText = "Availability";
            this.colAvailability.FillWeight = 90F;
            this.colAvailability.MinimumWidth = 6;
            this.colAvailability.ReadOnly = true;
            // 
            // colSection
            // 
            this.colSection.Name = "colSection";
            this.colSection.HeaderText = "Section and schedule";
            this.colSection.FillWeight = 230F;
            this.colSection.MinimumWidth = 6;
            // 
            // StudentEnrollmentForm
            // 
            this.Name = "StudentEnrollmentForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "Enrollment";
            this.Controls.Add(this.pnlBuilder);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlHeader);
            this.Load += new System.EventHandler(this.StudentEnrollmentForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSummaryBottom.ResumeLayout(false);
            this.pnlSummaryBottom.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.pnlBuilderBottom.ResumeLayout(false);
            this.pnlBuilderBottom.PerformLayout();
            this.pnlBuilder.ResumeLayout(false);
            this.pnlBuilder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfferings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlBuilder;
        private System.Windows.Forms.DataGridView dgvOfferings;
        private System.Windows.Forms.Panel pnlBuilderBottom;
        private System.Windows.Forms.RichTextBox rtbIssues;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnWaitlist;
        private System.Windows.Forms.Panel pnlSpacer2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel pnlSpacer1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.Label lblSummaryInfo;
        private System.Windows.Forms.Panel pnlSummaryBottom;
        private System.Windows.Forms.Button btnCancelRequest;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBanner;
        private System.Windows.Forms.Label lblWaitlist;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrerequisites;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailability;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSection;
    }
}
