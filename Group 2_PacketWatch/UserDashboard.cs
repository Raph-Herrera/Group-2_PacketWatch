using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_2_PacketWatch
{
    public partial class UserDashboard : Form
    {
        private string _loggedInUser;

        public UserDashboard(string username)
        {
            InitializeComponent();
            _loggedInUser = username;
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
        private void LoadDashboardData()
        {
            // Sample data
            dgvDashboard.Rows.Clear();
            dgvDashboard.Rows.Add("2024-01-01 10:00:00", "192.168.1.1", "10.0.0.1", "TCP", "80", "Normal");
            dgvDashboard.Rows.Add("2024-01-01 10:01:00", "192.168.1.2", "10.0.0.2", "UDP", "53", "Normal");
            dgvDashboard.Rows.Add("2024-01-01 10:02:00", "192.168.1.3", "10.0.0.3", "TCP", "22", "Suspicious");
            dgvDashboard.Rows.Add("2024-01-01 10:03:00", "10.0.0.50", "192.168.1.1", "ICMP", "0", "Suspicious");
            dgvDashboard.Rows.Add("2024-01-01 10:04:00", "192.168.1.5", "8.8.8.8", "UDP", "443", "Normal");

            lblTotalValue.Text = dgvDashboard.Rows.Count.ToString();
            lblActiveUsersValue.Text = "1";
            lblAlertsValue.Text = "2";
        }

        private void btnNavPacketLogs_Click(object sender, EventArgs e)
        {
            UserPacketLogs child = new UserPacketLogs(_loggedInUser);
            child.Show();
            this.Close();
        }

        private void btnNavAlerts_Click(object sender, EventArgs e)
        {
            UserSuspiciousAlerts child = new UserSuspiciousAlerts(_loggedInUser);
            child.Show();
            this.Close();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnRefreshStats_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
    }
}
