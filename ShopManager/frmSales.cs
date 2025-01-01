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
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
            InitializeSales();
        }
        private void InitializeSales()
        {
            this.BackColor = Color.White;

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
                Text = "Weekly Sales Overview",
                Font = new Font("Times New Roman", 14, FontStyle.Bold),
                Location = new Point(15, 15)
            };

            // Create simple visualization using panels
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            int[] sales = { 1500, 2200, 1800, 2400, 2100, 3000, 2600 };

            for (int i = 0; i < days.Length; i++)
            {
                Label lblDay = new Label
                {
                    Text = days[i],
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
                    Height = sales[i] / 15, // Scale down for visualization
                    BackColor = Color.FromArgb(52, 152, 219),
                    Location = new Point(50 + i * 100, 220 - sales[i] / 15)
                };

                pnlSalesOverview.Controls.Add(lblDay);
                pnlSalesOverview.Controls.Add(lblValue);
                pnlSalesOverview.Controls.Add(barPanel);
            }

            pnlSalesOverview.Controls.Add(lblSalesTitle);

            // Sales Grid
            DataGridView dgvSales = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            dgvSales.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "OrderID", HeaderText = "Order ID" },
                new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Date" },
                new DataGridViewTextBoxColumn { Name = "Customer", HeaderText = "Customer" },
                new DataGridViewTextBoxColumn { Name = "Items", HeaderText = "Items" },
                new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total" },
                new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status" }
            });

            // Add sample data
            dgvSales.Rows.Add("ORD-001", "2024-11-24", "John Doe", "3", "$150.00", "Completed");
            dgvSales.Rows.Add("ORD-002", "2024-11-24", "Jane Smith", "2", "$275.50", "Pending");
            dgvSales.Rows.Add("ORD-003", "2024-11-24", "Mike Johnson", "5", "$420.00", "Processing");

            this.Controls.AddRange(new Control[] { pnlSalesOverview, dgvSales });
        }
    }
}
