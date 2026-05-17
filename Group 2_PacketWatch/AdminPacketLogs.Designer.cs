namespace Group_2_PacketWatch
{
    partial class AdminPacketLogs
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
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnNavActivityLog = new System.Windows.Forms.Button();
            this.btnNavUserMgmt = new System.Windows.Forms.Button();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavPacketLogs = new System.Windows.Forms.Button();
            this.btnNavAlerts = new System.Windows.Forms.Button();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchIP = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvPacketLogs = new System.Windows.Forms.DataGridView();
            this.colLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTitleBar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacketLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlTitleBar.Controls.Add(this.btnLogout);
            this.pnlTitleBar.Controls.Add(this.lblAppName);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(884, 45);
            this.pnlTitleBar.TabIndex = 6;
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(837, 9);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(35, 30);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "➦";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.Location = new System.Drawing.Point(3, 6);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(316, 33);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "PacketWatch (Admin)";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlHeader.Controls.Add(this.btnNavActivityLog);
            this.pnlHeader.Controls.Add(this.btnNavUserMgmt);
            this.pnlHeader.Controls.Add(this.btnNavDashboard);
            this.pnlHeader.Controls.Add(this.btnNavPacketLogs);
            this.pnlHeader.Controls.Add(this.btnNavAlerts);
            this.pnlHeader.Controls.Add(this.lblDashboardTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 45);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(884, 40);
            this.pnlHeader.TabIndex = 7;
            // 
            // btnNavActivityLog
            // 
            this.btnNavActivityLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavActivityLog.Location = new System.Drawing.Point(673, 6);
            this.btnNavActivityLog.Name = "btnNavActivityLog";
            this.btnNavActivityLog.Size = new System.Drawing.Size(35, 30);
            this.btnNavActivityLog.TabIndex = 8;
            this.btnNavActivityLog.Text = "📋";
            this.btnNavActivityLog.UseVisualStyleBackColor = true;
            this.btnNavActivityLog.Click += new System.EventHandler(this.btnNavActivityLog_Click);
            // 
            // btnNavUserMgmt
            // 
            this.btnNavUserMgmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavUserMgmt.Location = new System.Drawing.Point(837, 6);
            this.btnNavUserMgmt.Name = "btnNavUserMgmt";
            this.btnNavUserMgmt.Size = new System.Drawing.Size(35, 30);
            this.btnNavUserMgmt.TabIndex = 6;
            this.btnNavUserMgmt.Text = "👤";
            this.btnNavUserMgmt.UseVisualStyleBackColor = true;
            this.btnNavUserMgmt.Click += new System.EventHandler(this.btnNavUserMgmt_Click);
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavDashboard.Location = new System.Drawing.Point(714, 6);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(35, 30);
            this.btnNavDashboard.TabIndex = 3;
            this.btnNavDashboard.Text = "🖥️";
            this.btnNavDashboard.UseVisualStyleBackColor = true;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // btnNavPacketLogs
            // 
            this.btnNavPacketLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavPacketLogs.Location = new System.Drawing.Point(755, 6);
            this.btnNavPacketLogs.Name = "btnNavPacketLogs";
            this.btnNavPacketLogs.Size = new System.Drawing.Size(35, 30);
            this.btnNavPacketLogs.TabIndex = 4;
            this.btnNavPacketLogs.Text = "≡≡";
            this.btnNavPacketLogs.UseVisualStyleBackColor = true;
            this.btnNavPacketLogs.Click += new System.EventHandler(this.btnNavPacketLogs_Click);
            // 
            // btnNavAlerts
            // 
            this.btnNavAlerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavAlerts.Location = new System.Drawing.Point(796, 6);
            this.btnNavAlerts.Name = "btnNavAlerts";
            this.btnNavAlerts.Size = new System.Drawing.Size(35, 30);
            this.btnNavAlerts.TabIndex = 5;
            this.btnNavAlerts.Text = "⚠";
            this.btnNavAlerts.UseVisualStyleBackColor = true;
            this.btnNavAlerts.Click += new System.EventHandler(this.btnNavAlerts_Click);
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboardTitle.Location = new System.Drawing.Point(3, 3);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(219, 33);
            this.lblDashboardTitle.TabIndex = 2;
            this.lblDashboardTitle.Text = "PACKET LOGS";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtFilter);
            this.pnlSearch.Controls.Add(this.lblFilterBy);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearchIP);
            this.pnlSearch.Controls.Add(this.btnRefresh);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 85);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(884, 40);
            this.pnlSearch.TabIndex = 8;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(458, 10);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(135, 20);
            this.txtFilter.TabIndex = 10;
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Location = new System.Drawing.Point(406, 13);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(46, 13);
            this.lblFilterBy.TabIndex = 9;
            this.lblFilterBy.Text = "Filter by:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(324, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "🔍";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchIP
            // 
            this.txtSearchIP.Location = new System.Drawing.Point(12, 10);
            this.txtSearchIP.Name = "txtSearchIP";
            this.txtSearchIP.Size = new System.Drawing.Size(315, 20);
            this.txtSearchIP.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(797, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvPacketLogs
            // 
            this.dgvPacketLogs.AllowUserToAddRows = false;
            this.dgvPacketLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPacketLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacketLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLogID,
            this.colTimestamp,
            this.colSourceIP,
            this.colDestIP,
            this.colProtocol,
            this.colPort});
            this.dgvPacketLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPacketLogs.Location = new System.Drawing.Point(0, 125);
            this.dgvPacketLogs.Name = "dgvPacketLogs";
            this.dgvPacketLogs.ReadOnly = true;
            this.dgvPacketLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacketLogs.Size = new System.Drawing.Size(884, 436);
            this.dgvPacketLogs.TabIndex = 9;
            // 
            // colLogID
            // 
            this.colLogID.DataPropertyName = "log_id";
            this.colLogID.HeaderText = "Log ID";
            this.colLogID.Name = "colLogID";
            this.colLogID.ReadOnly = true;
            // 
            // colTimestamp
            // 
            this.colTimestamp.DataPropertyName = "timestamp";
            this.colTimestamp.HeaderText = "Timestamp";
            this.colTimestamp.Name = "colTimestamp";
            this.colTimestamp.ReadOnly = true;
            // 
            // colSourceIP
            // 
            this.colSourceIP.DataPropertyName = "source_ip";
            this.colSourceIP.HeaderText = "Source IP";
            this.colSourceIP.Name = "colSourceIP";
            this.colSourceIP.ReadOnly = true;
            // 
            // colDestIP
            // 
            this.colDestIP.DataPropertyName = "destination_ip";
            this.colDestIP.HeaderText = "Destination IP";
            this.colDestIP.Name = "colDestIP";
            this.colDestIP.ReadOnly = true;
            // 
            // colProtocol
            // 
            this.colProtocol.DataPropertyName = "protocol";
            this.colProtocol.HeaderText = "Protocol";
            this.colProtocol.Name = "colProtocol";
            this.colProtocol.ReadOnly = true;
            // 
            // colPort
            // 
            this.colPort.DataPropertyName = "port";
            this.colPort.HeaderText = "Port";
            this.colPort.Name = "colPort";
            this.colPort.ReadOnly = true;
            // 
            // AdminPacketLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.dgvPacketLogs);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlTitleBar);
            this.Name = "AdminPacketLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PacketWatch - Admin Packet Logs";
            this.Load += new System.EventHandler(this.AdminPacketLogs_Load);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacketLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnNavUserMgmt;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavPacketLogs;
        private System.Windows.Forms.Button btnNavAlerts;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchIP;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvPacketLogs;
        private System.Windows.Forms.Button btnNavActivityLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPort;
    }
}