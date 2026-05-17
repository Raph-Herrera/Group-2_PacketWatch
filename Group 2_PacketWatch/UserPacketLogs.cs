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
    public partial class UserPacketLogs : Form
    {
        public UserPacketLogs()
        {
            InitializeComponent();
        }

        private void UserPacketLogs_Load(object sender, EventArgs e)
        {
            LoadPacketLogs();
            ActivityLogger.Log("VIEW_PACKET_LOGS", "User viewed packet logs");
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

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadPacketLogs(txtSearchIP.Text.Trim(), txtFilter.Text.Trim());
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            txtSearchIP.Clear();
            txtFilter.Clear();
            LoadPacketLogs();
            ActivityLogger.Log("REFRESH_PACKET_LOGS", "Refreshed packet logs");
        }

        private void btnNavDashboard_Click_1(object sender, EventArgs e)
        {
            UserDashboard parent = new UserDashboard();
            parent.Show();
            this.Hide();
        }

        private void btnNavPacketLogs_Click_1(object sender, EventArgs e)
        {
            LoadPacketLogs();
        }
        private void btnNavAlerts_Click_1(object sender, EventArgs e)
        {
            UserSuspiciousAlerts child = new UserSuspiciousAlerts();
            child.Show();
            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            PacketCaptureEngine.StopCapture();
            ActivityLogger.Log("LOGOUT", $"User '{Session.Username}' logged out");
            Session.Clear();
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void btnNavActivityLog_Click(object sender, EventArgs e)
        {
            ActivityLogger.Log("NAVIGATE", "Navigated to Activity Log");
            UserActivityLog child = new UserActivityLog();
            child.Show();
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
