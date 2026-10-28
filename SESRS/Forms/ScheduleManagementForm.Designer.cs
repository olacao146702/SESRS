namespace SESRS.Forms
{
    partial class ScheduleManagementForm
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
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.flowFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFilterSection = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClassList = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.flowPager = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.flowFilters.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.flowButtons.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.flowPager.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.TabIndex = 5;
            this.pnlGrid.Controls.Add(this.lblEmpty);
            this.pnlGrid.Controls.Add(this.dgv);
            // 
            // lblEmpty
            // 
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.BackColor = System.Drawing.Color.White;
            this.lblEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpty.ForeColor = System.Drawing.Color.DimGray;
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpty.Visible = false;
            this.lblEmpty.Text = "";
            // 
            // dgv
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
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Name = "dgv";
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeight = 38;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.MultiSelect = false;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.TabIndex = 4;
            this.dgv.RowTemplate.Height = 32;
            // 
            // flowFilters
            // 
            this.flowFilters.Name = "flowFilters";
            this.flowFilters.BackColor = System.Drawing.Color.White;
            this.flowFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowFilters.Padding = new System.Windows.Forms.Padding(16, 6, 16, 0);
            this.flowFilters.Size = new System.Drawing.Size(1000, 48);
            this.flowFilters.TabIndex = 19;
            this.flowFilters.WrapContents = true;
            this.flowFilters.Controls.Add(this.lblFilterSection);
            this.flowFilters.Controls.Add(this.cmbSection);
            // 
            // lblFilterSection
            // 
            this.lblFilterSection.Name = "lblFilterSection";
            this.lblFilterSection.AutoSize = true;
            this.lblFilterSection.TabIndex = 20;
            this.lblFilterSection.Text = "Section:";
            this.lblFilterSection.Margin = new System.Windows.Forms.Padding(8, 8, 4, 0);
            // 
            // cmbSection
            // 
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(0, 0);
            this.cmbSection.Size = new System.Drawing.Size(460, 23);
            this.cmbSection.TabIndex = 21;
            this.cmbSection.Margin = new System.Windows.Forms.Padding(0, 4, 12, 0);
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.cmbSection_SelectedIndexChanged);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1000, 78);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.txtSearch);
            // 
            // lblTitle
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Class Schedules";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(22, 48);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Meeting times, rooms and instructors for each section";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.txtSearch.Location = new System.Drawing.Point(716, 22);
            this.txtSearch.PlaceholderText = "Search...";
            this.txtSearch.Size = new System.Drawing.Size(260, 23);
            this.txtSearch.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlBottom.Size = new System.Drawing.Size(1000, 92);
            this.pnlBottom.TabIndex = 18;
            this.pnlBottom.Controls.Add(this.flowButtons);
            this.pnlBottom.Controls.Add(this.pnlStatus);
            // 
            // flowButtons
            // 
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.AutoScroll = true;
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowButtons.Size = new System.Drawing.Size(1000, 44);
            this.flowButtons.TabIndex = 6;
            this.flowButtons.WrapContents = false;
            this.flowButtons.Controls.Add(this.btnAdd);
            this.flowButtons.Controls.Add(this.btnEdit);
            this.flowButtons.Controls.Add(this.btnDelete);
            this.flowButtons.Controls.Add(this.btnClassList);
            this.flowButtons.Controls.Add(this.btnExport);
            // 
            // btnAdd
            // 
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 36);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "ADD MEETING";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 36);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.FlatAppearance.BorderSize = 1;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 36);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.FlatAppearance.BorderSize = 1;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClassList
            // 
            this.btnClassList.Name = "btnClassList";
            this.btnClassList.Size = new System.Drawing.Size(140, 36);
            this.btnClassList.TabIndex = 10;
            this.btnClassList.Text = "CLASS LIST";
            this.btnClassList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClassList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClassList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassList.BackColor = System.Drawing.Color.White;
            this.btnClassList.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnClassList.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnClassList.FlatAppearance.BorderSize = 1;
            this.btnClassList.UseVisualStyleBackColor = false;
            this.btnClassList.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnClassList.Click += new System.EventHandler(this.btnClassList_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(130, 36);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "EXPORT CSV";
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnExport.FlatAppearance.BorderSize = 1;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pnlStatus
            // 
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Size = new System.Drawing.Size(1000, 28);
            this.pnlStatus.TabIndex = 17;
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.Controls.Add(this.flowPager);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "";
            // 
            // flowPager
            // 
            this.flowPager.Name = "flowPager";
            this.flowPager.AutoSize = true;
            this.flowPager.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowPager.Size = new System.Drawing.Size(220, 28);
            this.flowPager.TabIndex = 13;
            this.flowPager.WrapContents = false;
            this.flowPager.Controls.Add(this.btnPrev);
            this.flowPager.Controls.Add(this.lblPageInfo);
            this.flowPager.Controls.Add(this.btnNext);
            // 
            // btnPrev
            // 
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(72, 26);
            this.btnPrev.TabIndex = 14;
            this.btnPrev.Text = "< Prev";
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.BackColor = System.Drawing.Color.White;
            this.btnPrev.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPrev.FlatAppearance.BorderSize = 1;
            this.btnPrev.UseVisualStyleBackColor = false;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(8, 6, 8, 0);
            this.lblPageInfo.TabIndex = 15;
            this.lblPageInfo.Text = "0 records";
            // 
            // btnNext
            // 
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 26);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next >";
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnNext.FlatAppearance.BorderSize = 1;
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // ScheduleManagementForm
            // 
            this.Name = "ScheduleManagementForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "Class Schedules";
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.flowFilters);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBottom);
            this.Load += new System.EventHandler(this.ScheduleManagementForm_Load);
            this.flowPager.ResumeLayout(false);
            this.flowPager.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.flowButtons.ResumeLayout(false);
            this.flowButtons.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flowFilters.ResumeLayout(false);
            this.flowFilters.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.FlowLayoutPanel flowFilters;
        private System.Windows.Forms.Label lblFilterSection;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClassList;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.FlowLayoutPanel flowPager;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNext;
    }
}
