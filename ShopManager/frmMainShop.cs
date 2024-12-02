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
    public partial class frmMainShop : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public frmMainShop()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            customizeDesign();
        }
        private void customizeDesign()
        {
            // Customize panel2 (Logo panel)
            Label lblLogo = new Label();
            lblLogo.Text = "SHOP MANAGER";
            lblLogo.Font = new Font("Times New Roman", 20, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            panel2.Controls.Add(lblLogo);

            // Customize buttons
            button1.Text = "DASHBOARD";
            button2.Text = "PRODUCTS";
            button3.Text = "INVENTORY";
            button4.Text = "SALES";
            button5.Text = "REPORTS";
            button6.Text = "LOG OUT";

            // Add icons to buttons
            button1.Image = SystemIcons.Application.ToBitmap();
            button2.Image = SystemIcons.Shield.ToBitmap();
            button3.Image = SystemIcons.Information.ToBitmap();
            button4.Image = SystemIcons.Warning.ToBitmap();
            button5.Image = SystemIcons.Question.ToBitmap();
            button6.Image = SystemIcons.Error.ToBitmap();

            // Configure button properties
            foreach (Button btn in panel1.Controls.OfType<Button>())
            {
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.Padding = new Padding(10, 0, 0, 0);
                btn.MouseEnter += Btn_MouseEnter;
                btn.MouseLeave += Btn_MouseLeave;
                btn.Click += Btn_Click;
            }
            // Add title to top panel
            Label lblTitle = new Label();
            lblTitle.Text = "WELCOME TO SHOP MANAGER";
            lblTitle.Font = new Font("Times New Roman", 24, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 30);
            panel3.Controls.Add(lblTitle);

            // Add date time label
            Label lblDateTime = new Label();
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(25, 65);
            panel3.Controls.Add(lblDateTime);

            // Add timer to update date time
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, e) => {
                lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            };
            timer.Start();
        }
        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(230, 126, 34); // Darker orange
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (currentButton != btn)
                btn.BackColor = Color.DarkOrange;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.DarkOrange;
            }
            Button btn = sender as Button;
            currentButton = btn;
            btn.BackColor = Color.FromArgb(230, 126, 34);

            // Handle button clicks here
            // For example: OpenChildForm(new frmProducts());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard()); // Mở form frmDashboard khi nhấn Button1
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmProducts()); // Mở form frmProducts khi nhấn Button2
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInventory()); // Mở form frmInventory khi nhấn Button3
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSales()); // Mở form frmSales khi nhấn Button4
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReports()); // Mở form frmReports khi nhấn Button5
        }
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void lblMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
