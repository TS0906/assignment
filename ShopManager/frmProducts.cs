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

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            using (Form frmAdd = new Form())
            {
                frmAdd.Text = "Add Product";
                frmAdd.Size = new Size(400, 300);

                Label lblProductID = new Label { Text = "Product ID:", Location = new Point(10, 20) };
                TextBox txtProductID = new TextBox { Location = new Point(120, 20), Width = 200 };

                Label lblProductName = new Label { Text = "Product Name:", Location = new Point(10, 60) };
                TextBox txtProductName = new TextBox { Location = new Point(120, 60), Width = 200 };

                Label lblCategory = new Label { Text = "Category:", Location = new Point(10, 100) };
                TextBox txtCategory = new TextBox { Location = new Point(120, 100), Width = 200 };

                Label lblPrice = new Label { Text = "Price:", Location = new Point(10, 140) };
                TextBox txtPrice = new TextBox { Location = new Point(120, 140), Width = 200 };

                Label lblStock = new Label { Text = "Stock:", Location = new Point(10, 180) };
                TextBox txtStock = new TextBox { Location = new Point(120, 180), Width = 200 };

                Button btnSave = new Button { Text = "Save", Location = new Point(120, 220), Size = new Size(80, 30) };
                btnSave.Click += (s, args) =>
                {
                    dgvProducts.Rows.Add(txtProductID.Text, txtProductName.Text, txtCategory.Text, txtPrice.Text, txtStock.Text);
                    frmAdd.Close();
                };

                frmAdd.Controls.AddRange(new Control[] { lblProductID, txtProductID, lblProductName, txtProductName, lblCategory, txtCategory, lblPrice, txtPrice, lblStock, txtStock, btnSave });
                frmAdd.ShowDialog();
            }
        }

        private void BtnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.");
                return;
            }

            DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];

            using (Form frmEdit = new Form())
            {
                frmEdit.Text = "Edit Product";
                frmEdit.Size = new Size(400, 300);

                Label lblProductID = new Label { Text = "Product ID:", Location = new Point(10, 20) };
                TextBox txtProductID = new TextBox { Location = new Point(120, 20), Width = 200, Text = selectedRow.Cells["ProductID"].Value.ToString() };

                Label lblProductName = new Label { Text = "Product Name:", Location = new Point(10, 60) };
                TextBox txtProductName = new TextBox { Location = new Point(120, 60), Width = 200, Text = selectedRow.Cells["ProductName"].Value.ToString() };

                Label lblCategory = new Label { Text = "Category:", Location = new Point(10, 100) };
                TextBox txtCategory = new TextBox { Location = new Point(120, 100), Width = 200, Text = selectedRow.Cells["Category"].Value.ToString() };

                Label lblPrice = new Label { Text = "Price:", Location = new Point(10, 140) };
                TextBox txtPrice = new TextBox { Location = new Point(120, 140), Width = 200, Text = selectedRow.Cells["Price"].Value.ToString() };

                Label lblStock = new Label { Text = "Stock:", Location = new Point(10, 180) };
                TextBox txtStock = new TextBox { Location = new Point(120, 180), Width = 200, Text = selectedRow.Cells["Stock"].Value.ToString() };

                Button btnSave = new Button { Text = "Save", Location = new Point(120, 220), Size = new Size(80, 30) };
                btnSave.Click += (s, args) =>
                {
                    selectedRow.SetValues(txtProductID.Text, txtProductName.Text, txtCategory.Text, txtPrice.Text, txtStock.Text);
                    frmEdit.Close();
                };

                frmEdit.Controls.AddRange(new Control[] { lblProductID, txtProductID, lblProductName, txtProductName, lblCategory, txtCategory, lblPrice, txtPrice, lblStock, txtStock, btnSave });
                frmEdit.ShowDialog();
            }
        }

        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dgvProducts.Rows.RemoveAt(dgvProducts.SelectedRows[0].Index);
            }
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
