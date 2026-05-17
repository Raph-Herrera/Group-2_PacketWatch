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
    public partial class AdminDashboard : Form
    {
        private Timer _refreshTimer;

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();

            _refreshTimer = new Timer();
            _refreshTimer.Interval = 3000;
            _refreshTimer.Tick += (s, ev) => LoadDashboardData();
            _refreshTimer.Start();

            ActivityLogger.Log("VIEW_DASHBOARD", "Admin opened the dashboard");
        }

        private void LoadDashboardData()
        {
            string sql = @"SELECT p.timestamp, p.source_ip, p.destination_ip,
                                  p.protocol, p.destination_port AS port,
                                  CASE WHEN a.alert_id IS NOT NULL THEN 'Suspicious' ELSE 'Normal' END AS status
                           FROM packets p
                           LEFT JOIN alerts a ON a.packet_id = p.packet_id
                           ORDER BY p.timestamp DESC
                           LIMIT 50";

            DataTable dt = DBHelper.ExecuteQuery(sql);
            dgvDashboard.AutoGenerateColumns = false;
            dgvDashboard.DataSource = dt;

            object totalObj = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM packets");
            object alertObj = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM alerts WHERE is_resolved = FALSE");
            object userObj = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM users WHERE is_active = TRUE");

            lblTotalValue.Text = totalObj?.ToString() ?? "0";
            lblAlertsValue.Text = alertObj?.ToString() ?? "0";
            lblActiveUsersValue.Text = userObj?.ToString() ?? "0";
        }

        private void btnToggleCapture_Click(object sender, EventArgs e)
        {
            if (!PacketCaptureEngine.IsCapturing)
            {
                PacketCaptureEngine.StartCapture(2 + 3);
                btnToggleCapture.Text = "Stop Capture";
                ActivityLogger.Log("START_CAPTURE", "Admin started capturing on Realtek Wi-Fi adapter");
            }
            else
            {
                PacketCaptureEngine.StopCapture();
                btnToggleCapture.Text = "Start Capture";
                ActivityLogger.Log("STOP_CAPTURE", "Admin stopped packet capture");
            }
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
        private void btnRefreshStats_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
        private void btnNavPacketLogs_Click(object sender, EventArgs e)
        {
            ActivityLogger.Log("NAVIGATE", "Admin navigated to Packet Logs");
            AdminPacketLogs child = new AdminPacketLogs();
            child.Show();
            this.Hide();
        }

        private void btnNavAlerts_Click(object sender, EventArgs e)
        {
            ActivityLogger.Log("NAVIGATE", "Admin navigated to Suspicious Alerts");
            AdminSuspiciousAlerts child = new AdminSuspiciousAlerts();
            child.Show();
            this.Hide();
        }

        private void btnNavUserMgmt_Click(object sender, EventArgs e)
        {
            ActivityLogger.Log("NAVIGATE", "Admin navigated to User Management");
            AdminUserManagement child = new AdminUserManagement();
            child.Show();
            this.Hide();
        }

        private void btnNavActivityLog_Click(object sender, EventArgs e)
        {
            ActivityLogger.Log("NAVIGATE", "Admin navigated to Activity Log");
            AdminActivityLog child = new AdminActivityLog();
            child.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            PacketCaptureEngine.StopCapture();
            _refreshTimer?.Stop();
            DBHelper.ClearPacketData();
            ActivityLogger.Log("LOGOUT", $"Admin '{Session.Username}' logged out");
            Session.Clear();
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            PacketCaptureEngine.StopCapture();
            _refreshTimer?.Stop();
            DBHelper.ClearPacketData();
            base.OnFormClosed(e);
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
    }
}
