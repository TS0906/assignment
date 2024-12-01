using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManager
{
    public partial class frmInventory : Form
    {
        private DataGridView dgvInventory;

        public frmInventory()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Inventory Management";
            this.BackColor = Color.White;
            this.Size = new Size(800, 600);

            // Title Label
            Label lblTitle = new Label
            {
                Text = "Inventory Overview",
                Font = new Font("Times New Roman", 18, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 50
            };

            // Inventory DataGridView
            dgvInventory = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            // Define Columns
            dgvInventory.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "ProductID", HeaderText = "Product ID" },
                new DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "Product Name" },
                new DataGridViewTextBoxColumn { Name = "TotalStock", HeaderText = "Total Stock" },
                new DataGridViewTextBoxColumn { Name = "LowStockAlert", HeaderText = "Low Stock Alert" },
                new DataGridViewTextBoxColumn { Name = "LastRestocked", HeaderText = "Last Restocked" }
            });

            // Add Sample Data
            PopulateSampleInventory();

            // Action Panel
            Panel pnlActions = CreateActionPanel();

            // Add Summary Panel
            Panel pnlSummary = CreateSummaryPanel();

            // Add Controls
            this.Controls.Add(dgvInventory);
            this.Controls.Add(pnlActions);
            this.Controls.Add(pnlSummary);
            this.Controls.Add(lblTitle);
        }

        private Panel CreateActionPanel()
        {
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.FromArgb(241, 241, 241)
            };

            Button btnRestock = new Button
            {
                Text = "Restock",
                Location = new Point(10, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White
            };

            Button btnAdjustStock = new Button
            {
                Text = "Adjust Stock",
                Location = new Point(140, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White
            };

            pnlActions.Controls.AddRange(new Control[] { btnRestock, btnAdjustStock });

            return pnlActions;
        }

        private Panel CreateSummaryPanel()
        {
            Panel pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(241, 241, 241)
            };

            Label lblTotalProducts = new Label
            {
                Text = "Total Products: 23",
                Font = new Font("Times New Roman", 12),
                Location = new Point(10, 10)
            };

            Label lblLowStockItems = new Label
            {
                Text = "Low Stock Items: 5",
                Font = new Font("Times New Roman", 12),
                Location = new Point(10, 40)
            };

            pnlSummary.Controls.AddRange(new Control[] { lblTotalProducts, lblLowStockItems });

            return pnlSummary;
        }

        private void PopulateSampleInventory()
        {
            dgvInventory.Rows.Add("PRD-001", "Laptop X1000", "50", "Yes", "2024-11-24");
            dgvInventory.Rows.Add("PRD-002", "Wireless Headphones", "100", "No", "2024-11-15");
            dgvInventory.Rows.Add("PRD-003", "Smart Watch", "75", "Yes", "2024-11-20");
            dgvInventory.Rows.Add("PRD-004", "Bluetooth Speaker", "20", "Yes", "2024-11-10");
        }
    }
}
