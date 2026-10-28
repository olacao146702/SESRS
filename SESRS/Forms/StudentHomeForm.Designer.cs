namespace SESRS.Forms
{
    partial class StudentHomeForm
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
            this.tlpLists = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAlerts = new System.Windows.Forms.Panel();
            this.rtbAlerts = new System.Windows.Forms.RichTextBox();
            this.pnlAlertsHeader = new System.Windows.Forms.Panel();
            this.lblAlertsTitle = new System.Windows.Forms.Label();
            this.pnlAnnouncements = new System.Windows.Forms.Panel();
            this.lstAnnouncements = new System.Windows.Forms.ListBox();
            this.pnlAnnouncementsHeader = new System.Windows.Forms.Panel();
            this.lblAnnouncementsTitle = new System.Windows.Forms.Label();
            this.lnkAnnouncements = new System.Windows.Forms.Label();
            this.pnlNotifications = new System.Windows.Forms.Panel();
            this.lstNotifications = new System.Windows.Forms.ListBox();
            this.pnlNotificationsHeader = new System.Windows.Forms.Panel();
            this.lblNotificationsTitle = new System.Windows.Forms.Label();
            this.lnkNotifications = new System.Windows.Forms.Label();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.prgCurriculum = new System.Windows.Forms.ProgressBar();
            this.lblProgressText = new System.Windows.Forms.Label();
            this.flowCards = new System.Windows.Forms.FlowLayoutPanel();
            this.cardTerm = new System.Windows.Forms.Panel();
            this.lblTermCaption = new System.Windows.Forms.Label();
            this.lblTermValue = new System.Windows.Forms.Label();
            this.cardStatus = new System.Windows.Forms.Panel();
            this.lblStatusCaption = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.cardUnits = new System.Windows.Forms.Panel();
            this.lblUnitsCaption = new System.Windows.Forms.Label();
            this.lblUnitsValue = new System.Windows.Forms.Label();
            this.cardNotifications = new System.Windows.Forms.Panel();
            this.lblNotificationsCaption = new System.Windows.Forms.Label();
            this.lblNotificationsValue = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblIdentity = new System.Windows.Forms.Label();
            this.tlpLists.SuspendLayout();
            this.pnlAlerts.SuspendLayout();
            this.pnlAlertsHeader.SuspendLayout();
            this.pnlAnnouncements.SuspendLayout();
            this.pnlAnnouncementsHeader.SuspendLayout();
            this.pnlNotifications.SuspendLayout();
            this.pnlNotificationsHeader.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.flowCards.SuspendLayout();
            this.cardTerm.SuspendLayout();
            this.cardStatus.SuspendLayout();
            this.cardUnits.SuspendLayout();
            this.cardNotifications.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpLists
            // 
            this.tlpLists.Name = "tlpLists";
            this.tlpLists.ColumnCount = 3;
            this.tlpLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLists.Padding = new System.Windows.Forms.Padding(16, 6, 16, 16);
            this.tlpLists.RowCount = 1;
            this.tlpLists.TabIndex = 22;
            this.tlpLists.Controls.Add(this.pnlAlerts, 0, 0);
            this.tlpLists.Controls.Add(this.pnlAnnouncements, 1, 0);
            this.tlpLists.Controls.Add(this.pnlNotifications, 2, 0);
            this.tlpLists.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpLists.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpLists.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpLists.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // 
            // pnlAlerts
            // 
            this.pnlAlerts.Name = "pnlAlerts";
            this.pnlAlerts.BackColor = System.Drawing.Color.White;
            this.pnlAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAlerts.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.pnlAlerts.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlAlerts.TabIndex = 23;
            this.pnlAlerts.Controls.Add(this.rtbAlerts);
            this.pnlAlerts.Controls.Add(this.pnlAlertsHeader);
            // 
            // rtbAlerts
            // 
            this.rtbAlerts.Name = "rtbAlerts";
            this.rtbAlerts.BackColor = System.Drawing.Color.White;
            this.rtbAlerts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAlerts.ReadOnly = true;
            this.rtbAlerts.TabIndex = 19;
            this.rtbAlerts.Text = "";
            // 
            // pnlAlertsHeader
            // 
            this.pnlAlertsHeader.Name = "pnlAlertsHeader";
            this.pnlAlertsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAlertsHeader.Size = new System.Drawing.Size(300, 30);
            this.pnlAlertsHeader.TabIndex = 24;
            this.pnlAlertsHeader.Controls.Add(this.lblAlertsTitle);
            // 
            // lblAlertsTitle
            // 
            this.lblAlertsTitle.Name = "lblAlertsTitle";
            this.lblAlertsTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAlertsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertsTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblAlertsTitle.Size = new System.Drawing.Size(190, 30);
            this.lblAlertsTitle.TabIndex = 25;
            this.lblAlertsTitle.Text = "DEADLINES AND ALERTS";
            this.lblAlertsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAnnouncements
            // 
            this.pnlAnnouncements.Name = "pnlAnnouncements";
            this.pnlAnnouncements.BackColor = System.Drawing.Color.White;
            this.pnlAnnouncements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAnnouncements.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.pnlAnnouncements.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlAnnouncements.TabIndex = 26;
            this.pnlAnnouncements.Controls.Add(this.lstAnnouncements);
            this.pnlAnnouncements.Controls.Add(this.pnlAnnouncementsHeader);
            // 
            // lstAnnouncements
            // 
            this.lstAnnouncements.Name = "lstAnnouncements";
            this.lstAnnouncements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstAnnouncements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAnnouncements.FormattingEnabled = true;
            this.lstAnnouncements.ItemHeight = 15;
            this.lstAnnouncements.TabIndex = 20;
            this.lstAnnouncements.DoubleClick += new System.EventHandler(this.lstAnnouncements_DoubleClick);
            // 
            // pnlAnnouncementsHeader
            // 
            this.pnlAnnouncementsHeader.Name = "pnlAnnouncementsHeader";
            this.pnlAnnouncementsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAnnouncementsHeader.Size = new System.Drawing.Size(300, 30);
            this.pnlAnnouncementsHeader.TabIndex = 27;
            this.pnlAnnouncementsHeader.Controls.Add(this.lblAnnouncementsTitle);
            this.pnlAnnouncementsHeader.Controls.Add(this.lnkAnnouncements);
            // 
            // lblAnnouncementsTitle
            // 
            this.lblAnnouncementsTitle.Name = "lblAnnouncementsTitle";
            this.lblAnnouncementsTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAnnouncementsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnouncementsTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblAnnouncementsTitle.Size = new System.Drawing.Size(190, 30);
            this.lblAnnouncementsTitle.TabIndex = 28;
            this.lblAnnouncementsTitle.Text = "ANNOUNCEMENTS";
            this.lblAnnouncementsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnkAnnouncements
            // 
            this.lnkAnnouncements.Name = "lnkAnnouncements";
            this.lnkAnnouncements.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkAnnouncements.Dock = System.Windows.Forms.DockStyle.Right;
            this.lnkAnnouncements.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAnnouncements.ForeColor = System.Drawing.Color.SteelBlue;
            this.lnkAnnouncements.Size = new System.Drawing.Size(70, 30);
            this.lnkAnnouncements.TabIndex = 29;
            this.lnkAnnouncements.Text = "View all";
            this.lnkAnnouncements.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkAnnouncements.Click += new System.EventHandler(this.lnkAnnouncements_Click);
            // 
            // pnlNotifications
            // 
            this.pnlNotifications.Name = "pnlNotifications";
            this.pnlNotifications.BackColor = System.Drawing.Color.White;
            this.pnlNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNotifications.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.pnlNotifications.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlNotifications.TabIndex = 30;
            this.pnlNotifications.Controls.Add(this.lstNotifications);
            this.pnlNotifications.Controls.Add(this.pnlNotificationsHeader);
            // 
            // lstNotifications
            // 
            this.lstNotifications.Name = "lstNotifications";
            this.lstNotifications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNotifications.FormattingEnabled = true;
            this.lstNotifications.ItemHeight = 15;
            this.lstNotifications.TabIndex = 21;
            this.lstNotifications.DoubleClick += new System.EventHandler(this.lstNotifications_DoubleClick);
            // 
            // pnlNotificationsHeader
            // 
            this.pnlNotificationsHeader.Name = "pnlNotificationsHeader";
            this.pnlNotificationsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNotificationsHeader.Size = new System.Drawing.Size(300, 30);
            this.pnlNotificationsHeader.TabIndex = 31;
            this.pnlNotificationsHeader.Controls.Add(this.lblNotificationsTitle);
            this.pnlNotificationsHeader.Controls.Add(this.lnkNotifications);
            // 
            // lblNotificationsTitle
            // 
            this.lblNotificationsTitle.Name = "lblNotificationsTitle";
            this.lblNotificationsTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNotificationsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificationsTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblNotificationsTitle.Size = new System.Drawing.Size(190, 30);
            this.lblNotificationsTitle.TabIndex = 32;
            this.lblNotificationsTitle.Text = "RECENT NOTIFICATIONS";
            this.lblNotificationsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnkNotifications
            // 
            this.lnkNotifications.Name = "lnkNotifications";
            this.lnkNotifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkNotifications.Dock = System.Windows.Forms.DockStyle.Right;
            this.lnkNotifications.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkNotifications.ForeColor = System.Drawing.Color.SteelBlue;
            this.lnkNotifications.Size = new System.Drawing.Size(70, 30);
            this.lnkNotifications.TabIndex = 33;
            this.lnkNotifications.Text = "View all";
            this.lnkNotifications.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkNotifications.Click += new System.EventHandler(this.lnkNotifications_Click);
            // 
            // pnlProgress
            // 
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProgress.Padding = new System.Windows.Forms.Padding(24, 8, 24, 0);
            this.pnlProgress.Size = new System.Drawing.Size(1000, 74);
            this.pnlProgress.TabIndex = 16;
            this.pnlProgress.Controls.Add(this.prgCurriculum);
            this.pnlProgress.Controls.Add(this.lblProgressText);
            // 
            // prgCurriculum
            // 
            this.prgCurriculum.Name = "prgCurriculum";
            this.prgCurriculum.Dock = System.Windows.Forms.DockStyle.Top;
            this.prgCurriculum.Size = new System.Drawing.Size(952, 20);
            this.prgCurriculum.TabIndex = 17;
            // 
            // lblProgressText
            // 
            this.lblProgressText.Name = "lblProgressText";
            this.lblProgressText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProgressText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressText.Size = new System.Drawing.Size(952, 26);
            this.lblProgressText.TabIndex = 18;
            this.lblProgressText.Text = "";
            // 
            // flowCards
            // 
            this.flowCards.Name = "flowCards";
            this.flowCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowCards.Padding = new System.Windows.Forms.Padding(16, 14, 16, 0);
            this.flowCards.Size = new System.Drawing.Size(1000, 124);
            this.flowCards.TabIndex = 3;
            this.flowCards.WrapContents = false;
            this.flowCards.Controls.Add(this.cardTerm);
            this.flowCards.Controls.Add(this.cardStatus);
            this.flowCards.Controls.Add(this.cardUnits);
            this.flowCards.Controls.Add(this.cardNotifications);
            // 
            // cardTerm
            // 
            this.cardTerm.Name = "cardTerm";
            this.cardTerm.BackColor = System.Drawing.Color.White;
            this.cardTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardTerm.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.cardTerm.Size = new System.Drawing.Size(220, 100);
            this.cardTerm.TabIndex = 4;
            this.cardTerm.Controls.Add(this.lblTermCaption);
            this.cardTerm.Controls.Add(this.lblTermValue);
            // 
            // lblTermCaption
            // 
            this.lblTermCaption.Name = "lblTermCaption";
            this.lblTermCaption.AutoSize = true;
            this.lblTermCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermCaption.ForeColor = System.Drawing.Color.DimGray;
            this.lblTermCaption.Location = new System.Drawing.Point(14, 10);
            this.lblTermCaption.TabIndex = 5;
            this.lblTermCaption.Text = "CURRENT TERM";
            // 
            // lblTermValue
            // 
            this.lblTermValue.Name = "lblTermValue";
            this.lblTermValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermValue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTermValue.Location = new System.Drawing.Point(12, 36);
            this.lblTermValue.Size = new System.Drawing.Size(196, 56);
            this.lblTermValue.TabIndex = 6;
            this.lblTermValue.Text = "-";
            // 
            // cardStatus
            // 
            this.cardStatus.Name = "cardStatus";
            this.cardStatus.BackColor = System.Drawing.Color.White;
            this.cardStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardStatus.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.cardStatus.Size = new System.Drawing.Size(220, 100);
            this.cardStatus.TabIndex = 7;
            this.cardStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardStatus.Controls.Add(this.lblStatusCaption);
            this.cardStatus.Controls.Add(this.lblStatusValue);
            this.cardStatus.Click += new System.EventHandler(this.cardStatus_Click);
            // 
            // lblStatusCaption
            // 
            this.lblStatusCaption.Name = "lblStatusCaption";
            this.lblStatusCaption.AutoSize = true;
            this.lblStatusCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusCaption.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatusCaption.Location = new System.Drawing.Point(14, 10);
            this.lblStatusCaption.TabIndex = 8;
            this.lblStatusCaption.Text = "ENROLLMENT STATUS";
            this.lblStatusCaption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStatusCaption.Click += new System.EventHandler(this.cardStatus_Click);
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusValue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStatusValue.Location = new System.Drawing.Point(12, 36);
            this.lblStatusValue.Size = new System.Drawing.Size(196, 56);
            this.lblStatusValue.TabIndex = 9;
            this.lblStatusValue.Text = "-";
            this.lblStatusValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStatusValue.Click += new System.EventHandler(this.cardStatus_Click);
            // 
            // cardUnits
            // 
            this.cardUnits.Name = "cardUnits";
            this.cardUnits.BackColor = System.Drawing.Color.White;
            this.cardUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardUnits.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.cardUnits.Size = new System.Drawing.Size(220, 100);
            this.cardUnits.TabIndex = 10;
            this.cardUnits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardUnits.Controls.Add(this.lblUnitsCaption);
            this.cardUnits.Controls.Add(this.lblUnitsValue);
            this.cardUnits.Click += new System.EventHandler(this.cardUnits_Click);
            // 
            // lblUnitsCaption
            // 
            this.lblUnitsCaption.Name = "lblUnitsCaption";
            this.lblUnitsCaption.AutoSize = true;
            this.lblUnitsCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitsCaption.ForeColor = System.Drawing.Color.DimGray;
            this.lblUnitsCaption.Location = new System.Drawing.Point(14, 10);
            this.lblUnitsCaption.TabIndex = 11;
            this.lblUnitsCaption.Text = "ENROLLED UNITS";
            this.lblUnitsCaption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUnitsCaption.Click += new System.EventHandler(this.cardUnits_Click);
            // 
            // lblUnitsValue
            // 
            this.lblUnitsValue.Name = "lblUnitsValue";
            this.lblUnitsValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitsValue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblUnitsValue.Location = new System.Drawing.Point(12, 36);
            this.lblUnitsValue.Size = new System.Drawing.Size(196, 56);
            this.lblUnitsValue.TabIndex = 12;
            this.lblUnitsValue.Text = "-";
            this.lblUnitsValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUnitsValue.Click += new System.EventHandler(this.cardUnits_Click);
            // 
            // cardNotifications
            // 
            this.cardNotifications.Name = "cardNotifications";
            this.cardNotifications.BackColor = System.Drawing.Color.White;
            this.cardNotifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardNotifications.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.cardNotifications.Size = new System.Drawing.Size(220, 100);
            this.cardNotifications.TabIndex = 13;
            this.cardNotifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardNotifications.Controls.Add(this.lblNotificationsCaption);
            this.cardNotifications.Controls.Add(this.lblNotificationsValue);
            this.cardNotifications.Click += new System.EventHandler(this.cardNotifications_Click);
            // 
            // lblNotificationsCaption
            // 
            this.lblNotificationsCaption.Name = "lblNotificationsCaption";
            this.lblNotificationsCaption.AutoSize = true;
            this.lblNotificationsCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificationsCaption.ForeColor = System.Drawing.Color.DimGray;
            this.lblNotificationsCaption.Location = new System.Drawing.Point(14, 10);
            this.lblNotificationsCaption.TabIndex = 14;
            this.lblNotificationsCaption.Text = "UNREAD NOTIFICATIONS";
            this.lblNotificationsCaption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNotificationsCaption.Click += new System.EventHandler(this.cardNotifications_Click);
            // 
            // lblNotificationsValue
            // 
            this.lblNotificationsValue.Name = "lblNotificationsValue";
            this.lblNotificationsValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificationsValue.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblNotificationsValue.Location = new System.Drawing.Point(12, 36);
            this.lblNotificationsValue.Size = new System.Drawing.Size(196, 56);
            this.lblNotificationsValue.TabIndex = 15;
            this.lblNotificationsValue.Text = "-";
            this.lblNotificationsValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNotificationsValue.Click += new System.EventHandler(this.cardNotifications_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1000, 92);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblIdentity);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Location = new System.Drawing.Point(24, 10);
            this.lblWelcome.Size = new System.Drawing.Size(900, 36);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.DarkGreen;
            // 
            // lblIdentity
            // 
            this.lblIdentity.Name = "lblIdentity";
            this.lblIdentity.Location = new System.Drawing.Point(26, 52);
            this.lblIdentity.Size = new System.Drawing.Size(900, 28);
            this.lblIdentity.TabIndex = 2;
            this.lblIdentity.Text = "";
            this.lblIdentity.ForeColor = System.Drawing.Color.DimGray;
            // 
            // StudentHomeForm
            // 
            this.Name = "StudentHomeForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "Dashboard";
            this.AutoScroll = true;
            this.Controls.Add(this.tlpLists);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.flowCards);
            this.Controls.Add(this.pnlHeader);
            this.Load += new System.EventHandler(this.StudentHomeForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.cardNotifications.ResumeLayout(false);
            this.cardNotifications.PerformLayout();
            this.cardUnits.ResumeLayout(false);
            this.cardUnits.PerformLayout();
            this.cardStatus.ResumeLayout(false);
            this.cardStatus.PerformLayout();
            this.cardTerm.ResumeLayout(false);
            this.cardTerm.PerformLayout();
            this.flowCards.ResumeLayout(false);
            this.flowCards.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            this.pnlNotificationsHeader.ResumeLayout(false);
            this.pnlNotificationsHeader.PerformLayout();
            this.pnlNotifications.ResumeLayout(false);
            this.pnlNotifications.PerformLayout();
            this.pnlAnnouncementsHeader.ResumeLayout(false);
            this.pnlAnnouncementsHeader.PerformLayout();
            this.pnlAnnouncements.ResumeLayout(false);
            this.pnlAnnouncements.PerformLayout();
            this.pnlAlertsHeader.ResumeLayout(false);
            this.pnlAlertsHeader.PerformLayout();
            this.pnlAlerts.ResumeLayout(false);
            this.pnlAlerts.PerformLayout();
            this.tlpLists.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLists;
        private System.Windows.Forms.Panel pnlAlerts;
        private System.Windows.Forms.RichTextBox rtbAlerts;
        private System.Windows.Forms.Panel pnlAlertsHeader;
        private System.Windows.Forms.Label lblAlertsTitle;
        private System.Windows.Forms.Panel pnlAnnouncements;
        private System.Windows.Forms.ListBox lstAnnouncements;
        private System.Windows.Forms.Panel pnlAnnouncementsHeader;
        private System.Windows.Forms.Label lblAnnouncementsTitle;
        private System.Windows.Forms.Label lnkAnnouncements;
        private System.Windows.Forms.Panel pnlNotifications;
        private System.Windows.Forms.ListBox lstNotifications;
        private System.Windows.Forms.Panel pnlNotificationsHeader;
        private System.Windows.Forms.Label lblNotificationsTitle;
        private System.Windows.Forms.Label lnkNotifications;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar prgCurriculum;
        private System.Windows.Forms.Label lblProgressText;
        private System.Windows.Forms.FlowLayoutPanel flowCards;
        private System.Windows.Forms.Panel cardTerm;
        private System.Windows.Forms.Label lblTermCaption;
        private System.Windows.Forms.Label lblTermValue;
        private System.Windows.Forms.Panel cardStatus;
        private System.Windows.Forms.Label lblStatusCaption;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Panel cardUnits;
        private System.Windows.Forms.Label lblUnitsCaption;
        private System.Windows.Forms.Label lblUnitsValue;
        private System.Windows.Forms.Panel cardNotifications;
        private System.Windows.Forms.Label lblNotificationsCaption;
        private System.Windows.Forms.Label lblNotificationsValue;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblIdentity;
    }
}
