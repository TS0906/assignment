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

            Button btnAddProduct = new Button
            {
                Text = "Add Product",
                Location = new Point(10, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White
            };
            btnAddProduct.Click += BtnAddProduct_Click;

            Button btnEditProduct = new Button
            {
                Text = "Edit Product",
                Location = new Point(140, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White
            };
            btnEditProduct.Click += BtnEditProduct_Click;

            Button btnDeleteProduct = new Button
            {
                Text = "Delete Product",
                Location = new Point(270, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White
            };
            btnDeleteProduct.Click += BtnDeleteProduct_Click;

            pnlActions.Controls.AddRange(new Control[] { btnAddProduct, btnEditProduct, btnDeleteProduct });

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

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            using (Form frmAdd = new Form())
            {
                frmAdd.Text = "Add Product";
                frmAdd.Size = new Size(400, 300);

                TextBox txtID = CreateTextBox("Product ID", 10);
                TextBox txtName = CreateTextBox("Product Name", 50);
                TextBox txtStock = CreateTextBox("Total Stock", 90);
                TextBox txtLowStock = CreateTextBox("Low Stock Alert", 130);
                TextBox txtRestock = CreateTextBox("Last Restocked", 170);

                Button btnSave = new Button { Text = "Save", Dock = DockStyle.Bottom, Height = 40 };
                btnSave.Click += (s, ev) =>
                {
                    dgvInventory.Rows.Add(txtID.Text, txtName.Text, txtStock.Text, txtLowStock.Text, txtRestock.Text);
                    frmAdd.Close();
                };

                frmAdd.Controls.AddRange(new Control[] { txtID, txtName, txtStock, txtLowStock, txtRestock, btnSave });
                frmAdd.ShowDialog();
            }
        }

        private void BtnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to edit.", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form frmEdit = new Form())
            {
                frmEdit.Text = "Edit Product";
                frmEdit.Size = new Size(400, 300);

                DataGridViewRow row = dgvInventory.CurrentRow;

                TextBox txtID = CreateTextBox("Product ID", 10, row.Cells["ProductID"].Value.ToString());
                TextBox txtName = CreateTextBox("Product Name", 50, row.Cells["ProductName"].Value.ToString());
                TextBox txtStock = CreateTextBox("Total Stock", 90, row.Cells["TotalStock"].Value.ToString());
                TextBox txtLowStock = CreateTextBox("Low Stock Alert", 130, row.Cells["LowStockAlert"].Value.ToString());
                TextBox txtRestock = CreateTextBox("Last Restocked", 170, row.Cells["LastRestocked"].Value.ToString());

                Button btnSave = new Button { Text = "Save", Dock = DockStyle.Bottom, Height = 40 };
                btnSave.Click += (s, ev) =>
                {
                    row.SetValues(txtID.Text, txtName.Text, txtStock.Text, txtLowStock.Text, txtRestock.Text);
                    frmEdit.Close();
                };

                frmEdit.Controls.AddRange(new Control[] { txtID, txtName, txtStock, txtLowStock, txtRestock, btnSave });
                frmEdit.ShowDialog();
            }
        }

        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvInventory.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to delete.", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dgvInventory.Rows.Remove(dgvInventory.CurrentRow);
            }
        }

        private TextBox CreateTextBox(string placeholder, int top, string defaultValue = "")
        {
            TextBox textBox = new TextBox
            {
                Text = string.IsNullOrEmpty(defaultValue) ? placeholder : defaultValue,
                ForeColor = string.IsNullOrEmpty(defaultValue) ? Color.Gray : Color.Black,
                Location = new Point(10, top),
                Width = 360
            };

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder && textBox.ForeColor == Color.Gray)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };

            return textBox;
        }

    }
}
