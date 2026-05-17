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
    public partial class AdminUserManagement : Form
    {
        public AdminUserManagement()
        {
            InitializeComponent();
        }

        private void AdminUserManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
            ActivityLogger.Log("VIEW_USER_MANAGEMENT", "Admin opened User Management");
        }

        private void LoadUsers(string usernameFilter = "")
        {
            string sql = @"SELECT user_id, CONCAT(first_name, ' ', last_name) AS name,
                                  username,
                                  CASE WHEN is_active = 1 THEN 'Active' ELSE 'Inactive' END AS status,
                                  role
                           FROM users
                           WHERE (@filter = '' OR username LIKE @filterLike)
                           ORDER BY created_at DESC";

            DataTable dt = DBHelper.ExecuteQuery(sql,
                new MySqlParameter("@filter", usernameFilter),
                new MySqlParameter("@filterLike", "%" + usernameFilter + "%"));

            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = dt;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an account to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvUsers.SelectedRows[0];
            int userId = Convert.ToInt32(row.Cells["colUserID"].Value);
            string username = row.Cells["colUsername"].Value?.ToString() ?? "";
            string role = row.Cells["colRole"].Value?.ToString() ?? "";

            if (userId == Session.UserId)
            {
                MessageBox.Show("You cannot delete your own account.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to permanently delete account '{username}' ({role})?\n\nThis cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                DBHelper.ExecuteNonQuery(
                    "DELETE FROM users WHERE user_id = @id",
                    new MySqlParameter("@id", userId));

                ActivityLogger.Log("DELETE_USER",
                    $"Admin deleted account: '{username}' (ID: {userId}, Role: {role})");

                MessageBox.Show($"Account '{username}' has been deleted.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete account: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers(txtSearchUsername.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchUsername.Clear(); txtFilter.Clear();
            LoadUsers();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            AdminDashboard parent = new AdminDashboard();
            parent.Show();
            this.Hide();
        }

        private void btnNavUserMgmt_Click(object sender, EventArgs e)
        {
            LoadUsers();
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