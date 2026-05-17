using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Group_2_PacketWatch
{
    public partial class AdminPacketLogs : Form
    {
        public AdminPacketLogs()
        {
            InitializeComponent();
        }

        private void AdminPacketLogs_Load(object sender, EventArgs e)
        {
            LoadPacketLogs();
            ActivityLogger.Log("VIEW_PACKET_LOGS", "Admin viewed packet logs");
        }

        private void LoadPacketLogs(string ipFilter = "", string protocolFilter = "")
        {
            string sql = @"SELECT pl.log_id, p.timestamp, p.source_ip,
                                  p.destination_ip, p.protocol, p.destination_port AS port
                           FROM packet_logs pl
                           JOIN packets p ON pl.packet_id = p.packet_id
                           WHERE (@ip = '' OR p.source_ip LIKE @ipLike)
                             AND (@proto = '' OR p.protocol = @proto)
                           ORDER BY pl.logged_at DESC
                           LIMIT 200";

            DataTable dt = DBHelper.ExecuteQuery(sql,
                new MySqlParameter("@ip", ipFilter),
                new MySqlParameter("@ipLike", "%" + ipFilter + "%"),
                new MySqlParameter("@proto", protocolFilter));

            dgvPacketLogs.AutoGenerateColumns = false;
            dgvPacketLogs.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPacketLogs(txtSearchIP.Text.Trim(), txtFilter.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchIP.Clear(); txtFilter.Clear();
            LoadPacketLogs();
            ActivityLogger.Log("REFRESH_PACKET_LOGS", "Admin refreshed packet logs");
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            AdminDashboard parent = new AdminDashboard();
            parent.Show();
            this.Hide();
        }
        private void btnNavPacketLogs_Click(object sender, EventArgs e)
        {
            LoadPacketLogs();
        }

        private void btnNavAlerts_Click(object sender, EventArgs e)
        {
            AdminSuspiciousAlerts child = new AdminSuspiciousAlerts();
            child.Show();
            this.Hide();
        }

        private void btnNavUserMgmt_Click(object sender, EventArgs e)
        {
            AdminUserManagement child = new AdminUserManagement();
            child.Show();
            this.Hide();
        }

        private void btnNavActivityLog_Click(object sender, EventArgs e)
        {
            AdminActivityLog child = new AdminActivityLog();
            child.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            PacketCaptureEngine.StopCapture();
            ActivityLogger.Log("LOGOUT", $"Admin '{Session.Username}' logged out");
            Session.Clear();
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            PacketCaptureEngine.StopCapture();
            DBHelper.ClearPacketData();
            base.OnFormClosed(e);
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
    }
}
