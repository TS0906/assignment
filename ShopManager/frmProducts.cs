using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManager
{
    public partial class frmProducts : Form
    {
        private DataGridView dgvProducts;

        public frmProducts()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Products";
            this.BackColor = Color.White;
            this.Size = new Size(800, 600);

            // Title Label
            Label lblTitle = new Label
            {
                Text = "Product Management",
                Font = new Font("Times New Roman", 18, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 50
            };

            // Products DataGridView
            dgvProducts = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            // Define Columns
            dgvProducts.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "ProductID", HeaderText = "Product ID" },
                new DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "Product Name" },
                new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Category" },
                new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Price" },
                new DataGridViewTextBoxColumn { Name = "Stock", HeaderText = "Stock" }
            });

            // Add Sample Data
            PopulateSampleProducts();

            // Action Panel
            Panel pnlActions = CreateActionPanel();

            // Add Controls
            this.Controls.Add(dgvProducts);
            this.Controls.Add(pnlActions);
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

            Button btnAddProduct = new Button
            {
                Text = "Add Product",
                Location = new Point(10, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White
            };

            Button btnEditProduct = new Button
            {
                Text = "Edit Product",
                Location = new Point(140, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White
            };

            Button btnDeleteProduct = new Button
            {
                Text = "Delete Product",
                Location = new Point(270, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White
            };

            pnlActions.Controls.AddRange(new Control[] { btnAddProduct, btnEditProduct, btnDeleteProduct });

            return pnlActions;
        }

        private void PopulateSampleProducts()
        {
            dgvProducts.Rows.Add("PRD-001", "Laptop X1000", "Electronics", "$999.99", "50");
            dgvProducts.Rows.Add("PRD-002", "Wireless Headphones", "Electronics", "$199.99", "100");
            dgvProducts.Rows.Add("PRD-003", "Smart Watch", "Wearables", "$249.99", "75");
            dgvProducts.Rows.Add("PRD-004", "Bluetooth Speaker", "Audio", "$129.99", "60");
        }
    }
}
