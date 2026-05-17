namespace Group_2_PacketWatch
{
    partial class UserDashboard
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
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavPacketLogs = new System.Windows.Forms.Button();
            this.btnNavAlerts = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnNavActivityLog = new System.Windows.Forms.Button();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.pnlStatsRow = new System.Windows.Forms.Panel();
            this.btnToggleCapture = new System.Windows.Forms.Button();
            this.btnRefreshStats = new System.Windows.Forms.Button();
            this.lblAlertsValue = new System.Windows.Forms.Label();
            this.lblAlerts = new System.Windows.Forms.Label();
            this.lblActiveUsersValue = new System.Windows.Forms.Label();
            this.lblActiveUsers = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalPackets = new System.Windows.Forms.Label();
            this.dgvDashboard = new System.Windows.Forms.DataGridView();
            this.colTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTitleBar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlStatsRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDashboard)).BeginInit();
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
            this.pnlTitleBar.TabIndex = 4;
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
            this.lblAppName.Size = new System.Drawing.Size(294, 33);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "PacketWatch (User)";
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavDashboard.Location = new System.Drawing.Point(755, 6);
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
            this.btnNavPacketLogs.Location = new System.Drawing.Point(796, 6);
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
            this.btnNavAlerts.Location = new System.Drawing.Point(837, 6);
            this.btnNavAlerts.Name = "btnNavAlerts";
            this.btnNavAlerts.Size = new System.Drawing.Size(35, 30);
            this.btnNavAlerts.TabIndex = 5;
            this.btnNavAlerts.Text = "⚠";
            this.btnNavAlerts.UseVisualStyleBackColor = true;
            this.btnNavAlerts.Click += new System.EventHandler(this.btnNavAlerts_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlHeader.Controls.Add(this.btnNavActivityLog);
            this.pnlHeader.Controls.Add(this.btnNavDashboard);
            this.pnlHeader.Controls.Add(this.btnNavPacketLogs);
            this.pnlHeader.Controls.Add(this.btnNavAlerts);
            this.pnlHeader.Controls.Add(this.lblDashboardTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 45);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(884, 40);
            this.pnlHeader.TabIndex = 5;
            // 
            // btnNavActivityLog
            // 
            this.btnNavActivityLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavActivityLog.Location = new System.Drawing.Point(714, 6);
            this.btnNavActivityLog.Name = "btnNavActivityLog";
            this.btnNavActivityLog.Size = new System.Drawing.Size(35, 30);
            this.btnNavActivityLog.TabIndex = 6;
            this.btnNavActivityLog.Text = "📋";
            this.btnNavActivityLog.UseVisualStyleBackColor = true;
            this.btnNavActivityLog.Click += new System.EventHandler(this.btnNavActivityLog_Click);
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.AutoSize = true;
            this.lblDashboardTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboardTitle.Location = new System.Drawing.Point(3, 3);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(198, 33);
            this.lblDashboardTitle.TabIndex = 2;
            this.lblDashboardTitle.Text = "DASHBOARD";
            // 
            // pnlStatsRow
            // 
            this.pnlStatsRow.Controls.Add(this.btnToggleCapture);
            this.pnlStatsRow.Controls.Add(this.btnRefreshStats);
            this.pnlStatsRow.Controls.Add(this.lblAlertsValue);
            this.pnlStatsRow.Controls.Add(this.lblAlerts);
            this.pnlStatsRow.Controls.Add(this.lblActiveUsersValue);
            this.pnlStatsRow.Controls.Add(this.lblActiveUsers);
            this.pnlStatsRow.Controls.Add(this.lblTotalValue);
            this.pnlStatsRow.Controls.Add(this.lblTotalPackets);
            this.pnlStatsRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatsRow.Location = new System.Drawing.Point(0, 85);
            this.pnlStatsRow.Name = "pnlStatsRow";
            this.pnlStatsRow.Size = new System.Drawing.Size(884, 40);
            this.pnlStatsRow.TabIndex = 6;
            // 
            // btnToggleCapture
            // 
            this.btnToggleCapture.Location = new System.Drawing.Point(712, 8);
            this.btnToggleCapture.Name = "btnToggleCapture";
            this.btnToggleCapture.Size = new System.Drawing.Size(78, 23);
            this.btnToggleCapture.TabIndex = 7;
            this.btnToggleCapture.Text = "Start Capture";
            this.btnToggleCapture.UseVisualStyleBackColor = true;
            this.btnToggleCapture.Click += new System.EventHandler(this.btnToggleCapture_Click);
            // 
            // btnRefreshStats
            // 
            this.btnRefreshStats.Location = new System.Drawing.Point(797, 8);
            this.btnRefreshStats.Name = "btnRefreshStats";
            this.btnRefreshStats.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshStats.TabIndex = 6;
            this.btnRefreshStats.Text = "Refresh";
            this.btnRefreshStats.UseVisualStyleBackColor = true;
            this.btnRefreshStats.Click += new System.EventHandler(this.btnRefreshStats_Click);
            // 
            // lblAlertsValue
            // 
            this.lblAlertsValue.AutoSize = true;
            this.lblAlertsValue.Location = new System.Drawing.Point(392, 13);
            this.lblAlertsValue.Name = "lblAlertsValue";
            this.lblAlertsValue.Size = new System.Drawing.Size(13, 13);
            this.lblAlertsValue.TabIndex = 5;
            this.lblAlertsValue.Text = "0";
            // 
            // lblAlerts
            // 
            this.lblAlerts.AutoSize = true;
            this.lblAlerts.Location = new System.Drawing.Point(350, 13);
            this.lblAlerts.Name = "lblAlerts";
            this.lblAlerts.Size = new System.Drawing.Size(36, 13);
            this.lblAlerts.TabIndex = 4;
            this.lblAlerts.Text = "Alerts:";
            // 
            // lblActiveUsersValue
            // 
            this.lblActiveUsersValue.AutoSize = true;
            this.lblActiveUsersValue.Location = new System.Drawing.Point(274, 13);
            this.lblActiveUsersValue.Name = "lblActiveUsersValue";
            this.lblActiveUsersValue.Size = new System.Drawing.Size(13, 13);
            this.lblActiveUsersValue.TabIndex = 3;
            this.lblActiveUsersValue.Text = "0";
            // 
            // lblActiveUsers
            // 
            this.lblActiveUsers.AutoSize = true;
            this.lblActiveUsers.Location = new System.Drawing.Point(198, 13);
            this.lblActiveUsers.Name = "lblActiveUsers";
            this.lblActiveUsers.Size = new System.Drawing.Size(70, 13);
            this.lblActiveUsers.TabIndex = 2;
            this.lblActiveUsers.Text = "Active Users:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(133, 13);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(13, 13);
            this.lblTotalValue.TabIndex = 1;
            this.lblTotalValue.Text = "0";
            // 
            // lblTotalPackets
            // 
            this.lblTotalPackets.AutoSize = true;
            this.lblTotalPackets.Location = new System.Drawing.Point(12, 13);
            this.lblTotalPackets.Name = "lblTotalPackets";
            this.lblTotalPackets.Size = new System.Drawing.Size(115, 13);
            this.lblTotalPackets.TabIndex = 0;
            this.lblTotalPackets.Text = "Total Packets Logged:";
            // 
            // dgvDashboard
            // 
            this.dgvDashboard.AllowUserToAddRows = false;
            this.dgvDashboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDashboard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTimestamp,
            this.colSourceIP,
            this.colDestIP,
            this.colProtocol,
            this.colPort,
            this.colStatus});
            this.dgvDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDashboard.Location = new System.Drawing.Point(0, 125);
            this.dgvDashboard.Name = "dgvDashboard";
            this.dgvDashboard.ReadOnly = true;
            this.dgvDashboard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDashboard.Size = new System.Drawing.Size(884, 436);
            this.dgvDashboard.TabIndex = 7;
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
            // colStatus
            // 
            this.colStatus.DataPropertyName = "status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.dgvDashboard);
            this.Controls.Add(this.pnlStatsRow);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlTitleBar);
            this.IsMdiContainer = true;
            this.Name = "UserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PacketWatch - User Dashboard";
            this.Load += new System.EventHandler(this.UserDashboard_Load);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStatsRow.ResumeLayout(false);
            this.pnlStatsRow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDashboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnNavAlerts;
        private System.Windows.Forms.Button btnNavPacketLogs;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.Panel pnlStatsRow;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblTotalPackets;
        private System.Windows.Forms.Label lblActiveUsersValue;
        private System.Windows.Forms.Label lblActiveUsers;
        private System.Windows.Forms.Button btnRefreshStats;
        private System.Windows.Forms.Label lblAlertsValue;
        private System.Windows.Forms.Label lblAlerts;
        private System.Windows.Forms.DataGridView dgvDashboard;
        private System.Windows.Forms.Button btnNavActivityLog;
        private System.Windows.Forms.Button btnToggleCapture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}