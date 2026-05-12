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
    public partial class AdminSuspiciousAlerts : Form
    {
        private string _loggedInUser;

        public AdminSuspiciousAlerts(string username)
        {
            InitializeComponent();
            _loggedInUser = username;
        }
        private void AdminSuspiciousAlerts_Load(object sender, EventArgs e)
        {
            LoadAlerts();
        }

        private void LoadAlerts(string ipFilter = "")
        {
            dgvAlerts.Rows.Clear();

            var data = new string[,]
            {
                // sample data
                {"1", "Port Scan Detected",      "192.168.1.3",  "10.0.0.3",    "High"},
                {"2", "ICMP Flood",              "10.0.0.50",    "192.168.1.1", "Medium"},
                {"3", "Unauthorized SSH Access", "192.168.2.10", "10.0.0.5",    "High"}
            };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (!string.IsNullOrEmpty(ipFilter) && !data[i, 2].Contains(ipFilter)) continue;
                dgvAlerts.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3], data[i, 4]);
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
            AdminDashboard parent = new AdminDashboard(_loggedInUser);
            parent.Show();
            this.Close();
        }

        private void btnNavPacketLogs_Click(object sender, EventArgs e)
        {
            AdminPacketLogs logs = new AdminPacketLogs(_loggedInUser);
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

        private void btnNavUserMgmt_Click(object sender, EventArgs e)
        {
            AdminUserManagement child = new AdminUserManagement(_loggedInUser);
            child.Show();
            this.Close();
        }
    }
}
