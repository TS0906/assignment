using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShopManager
{
    public partial class frmSales : Form
    {
        private ListView lvProducts;
        private ListView lvCart;
        private ComboBox cboCategory;
        private TextBox txtSearch;
        private Label lblTotal;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnCheckout;

        public frmSales()
        {
            InitializeComponent();
            InitializeSales();
            LoadSampleData();
        }

        private void InitializeSales()
        {
            this.Text = "Sales Management";
            this.Size = new Size(1200, 700); // Kích thước tổng thể của form
            this.BackColor = Color.White;

            // Top Panel - Search and Filter
            Panel pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70, // Đảm bảo đủ không gian
                BackColor = Color.FromArgb(241, 241, 241),
                Padding = new Padding(10)
            };

            Label lblCategory = new Label
            {
                Text = "Category:",
                Location = new Point(10, 25),
                AutoSize = true
            };

            cboCategory = new ComboBox
            {
                Location = new Point(80, 22),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboCategory.Items.AddRange(new string[] { "All", "Electronics", "Accessories", "Wearables" });
            cboCategory.SelectedIndex = 0;
            cboCategory.SelectedIndexChanged += CboCategory_SelectedIndexChanged;

            Label lblSearch = new Label
            {
                Text = "Search:",
                Location = new Point(250, 25),
                AutoSize = true
            };

            txtSearch = new TextBox
            {
                Location = new Point(310, 22),
                Size = new Size(250, 25),
                ForeColor = Color.Gray,
                Text = "Search products..."
            };

            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == "Search products...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = "Search products...";
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            pnlTop.Controls.AddRange(new Control[] { lblCategory, cboCategory, lblSearch, txtSearch });

            // Products ListView - Left Side
            lvProducts = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(10, pnlTop.Bottom + 10),
                Size = new Size(570, 450), // Giảm chiều cao để không đè lên nút
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom
            };
            lvProducts.Columns.AddRange(new ColumnHeader[]
            {
        new ColumnHeader { Text = "ID", Width = 80 },
        new ColumnHeader { Text = "Product", Width = 200 },
        new ColumnHeader { Text = "Category", Width = 100 },
        new ColumnHeader { Text = "Price", Width = 100 },
        new ColumnHeader { Text = "Stock", Width = 90 }
            });

            // Cart ListView - Right Side
            lvCart = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(610, pnlTop.Bottom + 10),
                Size = new Size(570, 450), // Giảm chiều cao tương tự
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
            };
            lvCart.Columns.AddRange(new ColumnHeader[]
            {
        new ColumnHeader { Text = "ID", Width = 80 },
        new ColumnHeader { Text = "Product", Width = 200 },
        new ColumnHeader { Text = "Price", Width = 100 },
        new ColumnHeader { Text = "Quantity", Width = 80 },
        new ColumnHeader { Text = "Subtotal", Width = 100 }
            });

            // Buttons Panel
            Panel pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 100, // Đảm bảo không bị che
                BackColor = Color.FromArgb(241, 241, 241)
            };

            btnAdd = new Button
            {
                Text = "Add to Cart",
                Size = new Size(120, 35),
                Location = new Point(400, 30), // Đặt nút cân đối
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White
            };
            btnAdd.Click += BtnAdd_Click;

            btnRemove = new Button
            {
                Text = "Remove Item",
                Size = new Size(120, 35),
                Location = new Point(540, 30), // Cách nút Add khoảng 140px
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White
            };
            btnRemove.Click += BtnRemove_Click;

            btnCheckout = new Button
            {
                Text = "Checkout",
                Size = new Size(120, 35),
                Location = new Point(1050, 30),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White
            };
            btnCheckout.Click += BtnCheckout_Click;

            lblTotal = new Label
            {
                Text = "Total: $0.00",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(850, 40),
                AutoSize = true
            };

            pnlButtons.Controls.AddRange(new Control[] { btnAdd, btnRemove, btnCheckout, lblTotal });

            // Add Controls to Form
            this.Controls.AddRange(new Control[] { pnlTop, lvProducts, lvCart, pnlButtons });
        }


        private void LoadSampleData()
        {
            // Sample Products
            var products = new[]
            {
                new ListViewItem(new[] { "PRD001", "Laptop X1000", "Electronics", "$999.99", "50" }),
                new ListViewItem(new[] { "PRD002", "Wireless Mouse", "Accessories", "$29.99", "100" }),
                new ListViewItem(new[] { "PRD003", "Smart Watch", "Wearables", "$199.99", "75" }),
                new ListViewItem(new[] { "PRD004", "Bluetooth Headphones", "Accessories", "$89.99", "60" })
            };

            lvProducts.Items.AddRange(products);
        }

        private void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void FilterProducts()
        {
            lvProducts.Items.Clear();
            LoadSampleData(); // Reload all items

            string searchText = txtSearch.Text.ToLower();
            string category = cboCategory.SelectedItem.ToString();

            for (int i = lvProducts.Items.Count - 1; i >= 0; i--)
            {
                ListViewItem item = lvProducts.Items[i];
                bool categoryMatch = category == "All" || item.SubItems[2].Text == category;
                bool searchMatch = string.IsNullOrEmpty(searchText) ||
                                 item.SubItems[1].Text.ToLower().Contains(searchText);

                if (!categoryMatch || !searchMatch)
                {
                    lvProducts.Items.RemoveAt(i);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product to add to cart.", "No Product Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem selectedProduct = lvProducts.SelectedItems[0];

            // Show quantity input dialog
            using (Form quantityForm = new Form())
            {
                quantityForm.Text = "Enter Quantity";
                quantityForm.Size = new Size(300, 150);
                quantityForm.StartPosition = FormStartPosition.CenterParent;
                quantityForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                quantityForm.MaximizeBox = false;
                quantityForm.MinimizeBox = false;

                NumericUpDown numQuantity = new NumericUpDown
                {
                    Location = new Point(20, 20),
                    Size = new Size(240, 25),
                    Minimum = 1,
                    Maximum = 100,
                    Value = 1
                };

                Button btnOk = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(100, 60),
                    Size = new Size(80, 30)
                };

                quantityForm.Controls.AddRange(new Control[] { numQuantity, btnOk });

                if (quantityForm.ShowDialog() == DialogResult.OK)
                {
                    decimal price = decimal.Parse(selectedProduct.SubItems[3].Text.TrimStart('$'));
                    decimal quantity = numQuantity.Value;
                    decimal subtotal = price * quantity;

                    var cartItem = new ListViewItem(new[]
                    {
                        selectedProduct.SubItems[0].Text,
                        selectedProduct.SubItems[1].Text,
                        selectedProduct.SubItems[3].Text,
                        quantity.ToString(),
                        $"${subtotal:F2}"
                    });

                    lvCart.Items.Add(cartItem);
                    UpdateTotal();
                }
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lvCart.SelectedItems.Count > 0)
            {
                lvCart.Items.Remove(lvCart.SelectedItems[0]);
                UpdateTotal();
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (lvCart.Items.Count == 0)
            {
                MessageBox.Show("Cart is empty.", "Checkout Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = CalculateTotal();
            string message = $"Total Amount: ${total:F2}\nProceed with checkout?";

            if (MessageBox.Show(message, "Confirm Checkout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Here you would typically:
                // 1. Save the transaction to database
                // 2. Update inventory
                // 3. Generate receipt
                MessageBox.Show("Checkout completed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lvCart.Items.Clear();
                UpdateTotal();
            }
        }

        private void UpdateTotal()
        {
            decimal total = CalculateTotal();
            lblTotal.Text = $"Total: ${total:F2}";
        }

        private decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (ListViewItem item in lvCart.Items)
            {
                total += decimal.Parse(item.SubItems[4].Text.TrimStart('$'));
            }
            return total;
        }
    }
}