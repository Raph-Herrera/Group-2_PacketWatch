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
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object usernameExists = DBHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM users WHERE username = @u",
                new MySqlParameter("@u", username));

            if (Convert.ToInt32(usernameExists) > 0)
            {
                MessageBox.Show("Username already taken. Please choose another.", "Duplicate Username",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object emailExists = DBHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM users WHERE email = @e",
                new MySqlParameter("@e", email));

            if (Convert.ToInt32(emailExists) > 0)
            {
                MessageBox.Show("This email is already registered. Please use a different email or log in.",
                    "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = HashPassword(password);

            string sql = @"INSERT INTO users
                           (username, password_hash, email, first_name, last_name, role, is_active)
                           VALUES (@u, @p, @e, @fn, @ln, 'User', TRUE)";

            int rows = DBHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@u", username),
                new MySqlParameter("@p", hashedPassword),
                new MySqlParameter("@e", email),
                new MySqlParameter("@fn", firstName),
                new MySqlParameter("@ln", lastName));

            if (rows > 0)
            {
                MessageBox.Show("Account created successfully! You can now log in.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Account creation failed. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void lnkLogIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}