using MySql.Data.MySqlClient;
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
    public partial class AdminActivityLog : Form
    {
        public AdminActivityLog()
        {
            InitializeComponent();
        }

        private void AdminActivityLog_Load(object sender, EventArgs e)
        {
            LoadActivityLog();
            ActivityLogger.Log("VIEW_ACTIVITY_LOG", "Admin viewed activity log");
        }

        private void LoadActivityLog(string actionFilter = "")
        {
            string sql = @"SELECT al.activity_id, al.action, al.details,
                                  al.ip_address, al.activity_at,
                                  u.username
                           FROM user_activity_log al
                           JOIN users u ON al.user_id = u.user_id
                           WHERE (@filter = '' OR al.action LIKE @filterLike)
                           ORDER BY al.activity_at DESC
                           LIMIT 500";

            DataTable dt = DBHelper.ExecuteQuery(sql,
                new MySqlParameter("@filter", actionFilter),
                new MySqlParameter("@filterLike", "%" + actionFilter + "%"));

            dgvActivityLog.AutoGenerateColumns = false;
            dgvActivityLog.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadActivityLog(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear(); txtFilter.Clear();
            LoadActivityLog();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            AdminDashboard parent = new AdminDashboard();
            parent.Show(); 
            this.Hide();
        }
        private void btnNavActivityLog_Click(object sender, EventArgs e)
        {
            LoadActivityLog();
        }

        private void btnNavPacketLogs_Click(object sender, EventArgs e)
        {
            AdminPacketLogs child = new AdminPacketLogs();
            child.Show();
            this.Hide();
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

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to clear all activity logs? This cannot be undone.",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            DBHelper.ExecuteNonQuery("DELETE FROM user_activity_log");
            DBHelper.ExecuteNonQuery("ALTER TABLE user_activity_log AUTO_INCREMENT = 1");

            ActivityLogger.Log("CLEAR_LOG", "Activity log cleared");

            LoadActivityLog();

            MessageBox.Show("Activity log has been cleared.", "Cleared",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
