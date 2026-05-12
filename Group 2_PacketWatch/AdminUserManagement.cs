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
    public partial class AdminUserManagement : Form
    {
        private string _loggedInUser;

        public AdminUserManagement(string username)
        {
            InitializeComponent();
            _loggedInUser = username;
        }

        private void AdminUserManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers(string usernameFilter = "")
        {
            dgvUsers.Rows.Clear();

            // Sample data
            var data = new string[,]
            {
                {"1", "John Doe",   "johndoe",  "Active",   "User"},
                {"2", "Jane Smith", "janesmith", "Active",   "User"},
                {"3", "Admin One",  "admin",     "Active",   "Admin"},
                {"4", "Bob Jones",  "bobjones",  "Inactive", "User"}
            };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (!string.IsNullOrEmpty(usernameFilter) &&
                    !data[i, 2].Contains(usernameFilter)) continue;
                dgvUsers.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3], data[i, 4]);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void btnNavUserMgmt_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnNavAlerts_Click(object sender, EventArgs e)
        {
            AdminSuspiciousAlerts child = new AdminSuspiciousAlerts(_loggedInUser);
            child.Show();
            this.Close();
        }

        private void btnNavPacketLogs_Click(object sender, EventArgs e)
        {
            AdminPacketLogs logs = new AdminPacketLogs(_loggedInUser);
            logs.Show();
            this.Close();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            AdminDashboard parent = new AdminDashboard(_loggedInUser);
            parent.Show();
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers(txtSearchIP.Text.Trim());
        }
    }
}