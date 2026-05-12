using Group_2_PacketWatch;
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
    public partial class UserSuspiciousAlerts : Form
    {
        private string _loggedInUser;

        public UserSuspiciousAlerts(string username)
        {
            InitializeComponent();
            _loggedInUser = username;
        }

        private void UserSuspiciousAlerts_Load(object sender, EventArgs e)
        {
            LoadAlerts();
        }

        private void LoadAlerts(string ipFilter = "", string generalFilter = "")
        {
            dgvAlerts.Rows.Clear();

            // Sample data
            var data = new string[,]
            {
                {"1", "2024-01-01 10:00:00", "192.168.1.1", "10.0.0.1",   "TCP",  "80"},
                {"2", "2024-01-01 10:01:00", "192.168.1.2", "10.0.0.2",   "UDP",  "53"},
                {"3", "2024-01-01 10:02:00", "192.168.1.3", "10.0.0.3",   "TCP",  "22"},
                {"4", "2024-01-01 10:03:00", "10.0.0.50",   "192.168.1.1","ICMP", "0"},
                {"5", "2024-01-01 10:04:00", "192.168.1.5", "8.8.8.8",    "UDP",  "443"}
            };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                string srcIP = data[i, 2];
                if (!string.IsNullOrEmpty(ipFilter) &&
                    !srcIP.Contains(ipFilter)) continue;
                dgvAlerts.Rows.Add(
                    data[i, 0], data[i, 1], data[i, 2],
                    data[i, 3], data[i, 4], data[i, 5]);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            UserDashboard parent = new UserDashboard(_loggedInUser);
            parent.Show();
            this.Close();
        }

        private void btnNavPacketLogs_Click(object sender, EventArgs e)
        {
            UserPacketLogs logs = new UserPacketLogs(_loggedInUser);
            logs.Show();
            this.Close();
        }

        private void btnNavAlerts_Click(object sender, EventArgs e)
        {
            LoadAlerts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchIP.Clear();
            txtFilter.Clear();
            LoadAlerts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAlerts(txtSearchIP.Text.Trim());
        }
    }
}