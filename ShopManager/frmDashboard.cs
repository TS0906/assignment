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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeDashboard();
        }
        private void InitializeDashboard()
        {
            this.BackColor = Color.White;

            // Summary Cards Panel
            Panel pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                Padding = new Padding(10)
            };

            // Create summary cards
            CreateSummaryCard(pnlSummary, "Total Sales", "$15,750", "Today", Color.FromArgb(52, 152, 219), 0);
            CreateSummaryCard(pnlSummary, "Total Orders", "245", "Today", Color.FromArgb(46, 204, 113), 1);
            CreateSummaryCard(pnlSummary, "Total Products", "1,250", "In Stock", Color.FromArgb(155, 89, 182), 2);
            CreateSummaryCard(pnlSummary, "Total Customers", "864", "Active", Color.FromArgb(230, 126, 34), 3);

            // Sales Overview Panel
            Panel pnlSalesOverview = new Panel
            {
                Dock = DockStyle.Top,
                Height = 300,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            Label lblSalesTitle = new Label
            {
                Text = "Sales Overview",
                Font = new Font("Times New Roman", 14, FontStyle.Bold),
                Location = new Point(15, 15)
            };

            // Create simple visualization using labels
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
            int[] sales = { 10500, 12800, 11200, 14500, 13800, 15750 };

            for (int i = 0; i < months.Length; i++)
            {
                Label lblMonth = new Label
                {
                    Text = months[i],
                    AutoSize = true,
                    Location = new Point(50 + i * 100, 250)
                };

                Label lblValue = new Label
                {
                    Text = "$" + sales[i].ToString("N0"),
                    AutoSize = true,
                    Location = new Point(50 + i * 100, 230)
                };

                Panel barPanel = new Panel
                {
                    Width = 40,
                    Height = (int)(sales[i] / 200), // Scale down for visualization
                    BackColor = Color.FromArgb(52, 152, 219),
                    Location = new Point(50 + i * 100, 220 - (int)(sales[i] / 200))
                };

                pnlSalesOverview.Controls.Add(lblMonth);
                pnlSalesOverview.Controls.Add(lblValue);
                pnlSalesOverview.Controls.Add(barPanel);
            }

            pnlSalesOverview.Controls.Add(lblSalesTitle);

            // Recent Orders Grid
            DataGridView dgvRecentOrders = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            dgvRecentOrders.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "OrderID", HeaderText = "Order ID" },
                new DataGridViewTextBoxColumn { Name = "Customer", HeaderText = "Customer" },
                new DataGridViewTextBoxColumn { Name = "Amount", HeaderText = "Amount" },
                new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status" },
                new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Date" }
            });

            // Add sample data
            dgvRecentOrders.Rows.Add("ORD-001", "John Doe", "$150.00", "Completed", "2024-11-24");
            dgvRecentOrders.Rows.Add("ORD-002", "Jane Smith", "$275.50", "Pending", "2024-11-24");
            dgvRecentOrders.Rows.Add("ORD-003", "Mike Johnson", "$420.00", "Processing", "2024-11-24");

            // Add controls to form
            this.Controls.AddRange(new Control[] { pnlSummary, pnlSalesOverview, dgvRecentOrders });
        }

        private void CreateSummaryCard(Panel parent, string title, string value, string subtitle, Color color, int position)
        {
            Panel card = new Panel
            {
                Width = (parent.Width - 50) / 4,
                Height = parent.Height - 20,
                BackColor = color,
                Location = new Point((card.Width + 10) * position + 10, 10)
            };

            Label lblTitle = new Label
            {
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Times New Roman", 12),
                Location = new Point(10, 10)
            };

            Label lblValue = new Label
            {
                Text = value,
                ForeColor = Color.White,
                Font = new Font("Times New Roman", 20, FontStyle.Bold),
                Location = new Point(10, 35)
            };

            Label lblSubtitle = new Label
            {
                Text = subtitle,
                ForeColor = Color.White,
                Font = new Font("Times New Roman", 10),
                Location = new Point(10, 70)
            };

            card.Controls.AddRange(new Control[] { lblTitle, lblValue, lblSubtitle });
            parent.Controls.Add(card);
        }
    }
}
