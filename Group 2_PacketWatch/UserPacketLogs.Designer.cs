namespace Group_2_PacketWatch
{
    partial class UserPacketLogs
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
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavPacketLogs = new System.Windows.Forms.Button();
            this.btnNavAlerts = new System.Windows.Forms.Button();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchIP = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.colPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPacketLogs = new System.Windows.Forms.DataGridView();
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
            this.pnlTitleBar.TabIndex = 5;
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
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
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
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlHeader.Controls.Add(this.btnNavDashboard);
            this.pnlHeader.Controls.Add(this.btnNavPacketLogs);
            this.pnlHeader.Controls.Add(this.btnNavAlerts);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 45);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(884, 40);
            this.pnlHeader.TabIndex = 6;
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
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click_1);
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
            this.btnNavPacketLogs.Click += new System.EventHandler(this.btnNavPacketLogs_Click_1);
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
            this.btnNavAlerts.Click += new System.EventHandler(this.btnNavAlerts_Click_1);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.Location = new System.Drawing.Point(3, 3);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(219, 33);
            this.lblPageTitle.TabIndex = 2;
            this.lblPageTitle.Text = "PACKET LOGS";
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
            this.pnlSearch.TabIndex = 7;
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
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
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
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // colPort
            // 
            this.colPort.HeaderText = "Port";
            this.colPort.Name = "colPort";
            this.colPort.ReadOnly = true;
            // 
            // colProtocol
            // 
            this.colProtocol.HeaderText = "Protocol";
            this.colProtocol.Name = "colProtocol";
            this.colProtocol.ReadOnly = true;
            // 
            // colDestIP
            // 
            this.colDestIP.HeaderText = "Destination IP";
            this.colDestIP.Name = "colDestIP";
            this.colDestIP.ReadOnly = true;
            // 
            // colSourceIP
            // 
            this.colSourceIP.HeaderText = "Source IP";
            this.colSourceIP.Name = "colSourceIP";
            this.colSourceIP.ReadOnly = true;
            // 
            // colTimestamp
            // 
            this.colTimestamp.HeaderText = "Timestamp";
            this.colTimestamp.Name = "colTimestamp";
            this.colTimestamp.ReadOnly = true;
            // 
            // colLogID
            // 
            this.colLogID.HeaderText = "Log ID";
            this.colLogID.Name = "colLogID";
            this.colLogID.ReadOnly = true;
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
            this.dgvPacketLogs.TabIndex = 8;
            // 
            // UserPacketLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.dgvPacketLogs);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlTitleBar);
            this.Name = "UserPacketLogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PacketWatch - User Packet Logs";
            this.Load += new System.EventHandler(this.UserPacketLogs_Load);
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
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavPacketLogs;
        private System.Windows.Forms.Button btnNavAlerts;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchIP;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogID;
        private System.Windows.Forms.DataGridView dgvPacketLogs;
    }
}