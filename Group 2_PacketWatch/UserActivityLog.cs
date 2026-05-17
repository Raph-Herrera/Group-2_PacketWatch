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
    public partial class UserActivityLog : Form
    {
        public UserActivityLog()
        {
            InitializeComponent();
        }

        private void UserActivityLog_Load(object sender, EventArgs e)
        {
            LoadActivityLog();
        }

        private void LoadActivityLog(string actionFilter = "")
        {
            string sql = @"SELECT activity_id, action, details, ip_address, activity_at
                           FROM user_activity_log
                           WHERE user_id = @uid
                             AND (@filter = '' OR action LIKE @filterLike)
                           ORDER BY activity_at DESC
                           LIMIT 200";

            DataTable dt = DBHelper.ExecuteQuery(sql,
                new MySqlParameter("@uid", Session.UserId),
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
            txtSearch.Clear();
            txtFilter.Clear();
            LoadActivityLog();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            UserDashboard parent = new UserDashboard();
            parent.Show();
            this.Hide();
        }
        private void btnNavActivityLog_Click(object sender, EventArgs e)
        {
            LoadActivityLog();
        }

        private void btnNavPacketLogs_Click(object sender, EventArgs e)
        {
            UserPacketLogs child = new UserPacketLogs();
            child.Show();
            this.Hide();
        }

        private void btnNavAlerts_Click(object sender, EventArgs e)
        {
            UserSuspiciousAlerts child = new UserSuspiciousAlerts();
            child.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ActivityLogger.Log("LOGOUT", $"User '{Session.Username}' logged out");
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
