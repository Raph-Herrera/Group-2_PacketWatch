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

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your username and password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // sample credentials
            if (username == "admin" && password == "admin123" && cmbRole.SelectedItem.ToString() == "Admin")
            {
                AdminDashboard adminForm = new AdminDashboard(username);
                adminForm.Show();
                this.Hide();
            }
            else if (username == "user" && password == "user123" && cmbRole.SelectedItem.ToString() == "User")
            {
                UserDashboard userForm = new UserDashboard(username);
                userForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username, password, or role.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkSignUp_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignupForm signup = new SignupForm();
            signup.Show();
            this.Hide();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}