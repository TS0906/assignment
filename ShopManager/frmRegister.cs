using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
