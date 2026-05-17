using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using MySql.Data.MySqlClient;

namespace Group_2_PacketWatch
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your username and password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please select a role.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = HashPassword(password);

            string sql = @"SELECT user_id, username, role, first_name, last_name, is_active
                   FROM users
                   WHERE username = @u AND password_hash = @p";

            DataTable dt = DBHelper.ExecuteQuery(sql,
                new MySqlParameter("@u", username),
                new MySqlParameter("@p", hashedPassword));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid username or password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow user = dt.Rows[0];

            string actualRole = user["role"].ToString();
            if (!actualRole.Equals(role, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Incorrect role selected. This account is registered as '{actualRole}'.",
                    "Role Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Convert.ToBoolean(user["is_active"]))
            {
                MessageBox.Show("Your account has been deactivated. Contact an administrator.",
                    "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Session.UserId = Convert.ToInt32(user["user_id"]);
            Session.Username = user["username"].ToString();
            Session.Role = user["role"].ToString();
            Session.FirstName = user["first_name"].ToString();
            Session.LastName = user["last_name"].ToString();
            Session.IpAddress = GetLocalIP();

            DBHelper.ExecuteNonQuery(
                "UPDATE users SET last_login = NOW() WHERE user_id = @id",
                new MySqlParameter("@id", Session.UserId));

            ActivityLogger.Log("LOGIN", $"User '{Session.Username}' logged in as {Session.Role} from {Session.IpAddress}");

            if (Session.Role == "Admin")
            {
                AdminDashboard adminForm = new AdminDashboard();
                adminForm.Show();
            }
            else
            {
                UserDashboard userForm = new UserDashboard();
                userForm.Show();
            }

            this.Hide();
        }

        private void lnkSignUp_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignupForm signup = new SignupForm();
            signup.Show();
            this.Hide();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (byte b in hash) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private string GetLocalIP()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        return ip.ToString();
            }
            catch { }
            return "127.0.0.1";
        }
    }
}