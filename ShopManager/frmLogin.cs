using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManager
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private bool CheckCredentials(string username, string password)
        {
            foreach (var line in File.ReadLines("credentials.txt"))
            {
                string[] parts = line.Split(':'); // Tách tên tài khoản và mật khẩu
                if (parts[0] == username && parts[1] == password)
                {
                    return true;
                }
            }
            return false;
        }
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_register_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.Show();
            this.Hide();
        }

        private void chkLogin_showpass_CheckedChanged(object sender, EventArgs e)
        {
            txtLogin_password.PasswordChar = chkLogin_showpass.Checked ? '\0' : '*';
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtLogin_username.Text;
            string password = txtLogin_password.Text;

            if (CheckCredentials(username, password))
            {
                frmMainShop frmMainShop = new frmMainShop();
                frmMainShop.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;  
            }
        }
        //Maximize window application

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Minimize window application

    }
}
