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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_login_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();

            this.Hide();
        }

        private void chkRegister_showpass_CheckedChanged(object sender, EventArgs e)
        {
            txtRegister_password.PasswordChar = chkRegister_showpass.Checked ? '\0' : '*';
            txtRegister_rpassword.PasswordChar = chkRegister_showpass.Checked ? '\0' : '*';
            // \0 lam textbox hien thi duoi dang binh thuong
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
        private void SaveCredentials(string username, string password)
        {
            using (StreamWriter sw = new StreamWriter("credentials.txt", true))
            {
                sw.WriteLine($"{username}:{password}");
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegister_username.Text;
            string password = txtRegister_password.Text;

            SaveCredentials(username, password);
        }
    }
}
