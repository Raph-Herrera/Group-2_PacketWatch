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
    public partial class AdminSuspiciousAlerts : Form
    {
        public AdminSuspiciousAlerts()
        {
            InitializeComponent();
        }

        private void AdminSuspiciousAlerts_Load(object sender, EventArgs e)
        {
            LoadAlerts();
            ActivityLogger.Log("VIEW_ALERTS", "Admin viewed suspicious alerts");
        }

        private void LoadAlerts(string ipFilter = "")
        {
            string sql = @"SELECT alert_id, alert_message AS reason,
                                  source_ip, destination_ip, severity_level AS severity
                           FROM alerts
                           WHERE (@ip = '' OR source_ip LIKE @ipLike)
                           ORDER BY timestamp DESC
                           LIMIT 200";

            DataTable dt = DBHelper.ExecuteQuery(sql,
                new MySqlParameter("@ip", ipFilter),
                new MySqlParameter("@ipLike", "%" + ipFilter + "%"));

            dgvAlerts.AutoGenerateColumns = false;
            dgvAlerts.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAlerts(txtSearchIP.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchIP.Clear(); txtFilter.Clear();
            LoadAlerts();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            AdminDashboard parent = new AdminDashboard();
            parent.Show();
            this.Hide();
        }
        private void btnNavAlerts_Click(object sender, EventArgs e)
        {
            LoadAlerts();
        }

        private void btnNavPacketLogs_Click(object sender, EventArgs e)
        {
            AdminPacketLogs child = new AdminPacketLogs();
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