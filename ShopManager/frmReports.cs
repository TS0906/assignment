using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManager
{
    public partial class frmReports : Form
    {
        private TabControl tabReports;

        public frmReports()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Reports";
            this.BackColor = Color.White;
            this.Size = new Size(800, 600);

            // Title Label
            Label lblTitle = new Label
            {
                Text = "Business Reports",
                Font = new Font("Times New Roman", 18, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 50
            };

            // Tab Control for Reports
            tabReports = new TabControl
            {
                Dock = DockStyle.Fill
            };

            // Sales Report Tab
            TabPage tabSalesReport = CreateSalesReportTab();
            TabPage tabInventoryReport = CreateInventoryReportTab();
            TabPage tabCustomerReport = CreateCustomerReportTab();

            tabReports.TabPages.AddRange(new TabPage[] { tabSalesReport, tabInventoryReport, tabCustomerReport });

            // Action Panel
            Panel pnlActions = CreateActionPanel();

            // Add Controls
            this.Controls.Add(tabReports);
            this.Controls.Add(pnlActions);
            this.Controls.Add(lblTitle);
        }

        private TabPage CreateSalesReportTab()
        {
            TabPage tabSales = new TabPage("Sales Report");
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
                new DataGridViewTextBoxColumn { Name = "Month", HeaderText = "Month" },
                new DataGridViewTextBoxColumn { Name = "TotalSales", HeaderText = "Total Sales" },
                new DataGridViewTextBoxColumn { Name = "AverageOrderValue", HeaderText = "Avg. Order Value" }
            });

            dgvSales.Rows.Add("January", "$15,750", "$64.29");
            dgvSales.Rows.Add("February", "$17,200", "$70.20");
            dgvSales.Rows.Add("March", "$16,500", "$67.35");

            tabSales.Controls.Add(dgvSales);
            return tabSales;
        }

        private TabPage CreateInventoryReportTab()
        {
            TabPage tabInventory = new TabPage("Inventory Report");
            DataGridView dgvInventory = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            dgvInventory.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Category" },
                new DataGridViewTextBoxColumn { Name = "TotalProducts", HeaderText = "Total Products" },
                new DataGridViewTextBoxColumn { Name = "LowStockItems", HeaderText = "Low Stock Items" }
            });

            dgvInventory.Rows.Add("Electronics", "10", "3");
            dgvInventory.Rows.Add("Wearables", "5", "1");
            dgvInventory.Rows.Add("Audio", "8", "2");

            tabInventory.Controls.Add(dgvInventory);
            return tabInventory;
        }

        private TabPage CreateCustomerReportTab()
        {
            TabPage tabCustomers = new TabPage("Customer Report");
            DataGridView dgvCustomers = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            dgvCustomers.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "NewCustomers", HeaderText = "New Customers" },
                new DataGridViewTextBoxColumn { Name = "ReturnCustomers", HeaderText = "Returning Customers" },
                new DataGridViewTextBoxColumn { Name = "AverageSpend", HeaderText = "Avg. Customer Spend" }
            });

            dgvCustomers.Rows.Add("120", "744", "$182.50");
            dgvCustomers.Rows.Add("135", "729", "$189.75");

            tabCustomers.Controls.Add(dgvCustomers);
            return tabCustomers;
        }

        private Panel CreateActionPanel()
        {
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.FromArgb(241, 241, 241)
            };

            Button btnExportReport = new Button
            {
                Text = "Export Report",
                Location = new Point(10, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White
            };

            Button btnPrintReport = new Button
            {
                Text = "Print Report",
                Location = new Point(140, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White
            };

            pnlActions.Controls.AddRange(new Control[] { btnExportReport, btnPrintReport });

            return pnlActions;
        }
    }
}
