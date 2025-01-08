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
            InitializeComponent();
            InitializeDashboard();
        }

        private void CreateSummaryCard(Panel parent, string title, string value, string subtitle, Color color, int position)
        {
            // Calculate card width
            int cardWidth = Math.Max(0, (parent.Width - (5 * 10)) / 4);
            //distance between the cards and the panel parent
            Panel card = new Panel
            {
                Width = cardWidth,
                Height = parent.Height - 20,
                BackColor = color,
                Location = new Point((cardWidth + 10) * position + 10, 10)
            };

            Label lblTitle = new Label
            {
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Times New Roman", 12),
                Location = new Point(10, 10),
                Width = cardWidth - 20
            };

            Label lblValue = new Label
            {
                Text = value,
                ForeColor = Color.White,
                Font = new Font("Times New Roman", 20, FontStyle.Bold),
                Width = cardWidth - 20,
                Height = 35,
                Location = new Point(10, 35),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblSubtitle = new Label
            {
                Text = subtitle,
                ForeColor = Color.White,
                Font = new Font("Times New Roman", 10),
                Location = new Point(10, 70),
                Width = cardWidth - 20
            };

            card.Controls.AddRange(new Control[] { lblTitle, lblValue, lblSubtitle });
            parent.Controls.Add(card);
        }

        private void InitializeDashboard()
        {
            this.BackColor = Color.White;

            // Create summary panel
            Panel pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                Padding = new Padding(10)
            };

            this.Controls.Add(pnlSummary);

            // Handle panel resize to reposition cards
            pnlSummary.Resize += (s, e) =>
            {
                pnlSummary.Controls.Clear(); // Xóa các thẻ (card) hiện tại

                // Lấy dữ liệu dashboard thực tế
                var salesData = FetchTotalSales();
                var ordersData = FetchTotalOrders();
                var productsData = FetchTotalProducts();
                var customersData = FetchTotalCustomers();

                // Tạo các thẻ với dữ liệu động
                CreateSummaryCard(pnlSummary, "Total Sales", salesData.ToString(), "Today", Color.FromArgb(52, 152, 219), 0);
                CreateSummaryCard(pnlSummary, "Total Orders", ordersData.ToString(), "Today", Color.FromArgb(46, 204, 113), 1);
                CreateSummaryCard(pnlSummary, "Total Products", productsData.ToString(), "In Stock", Color.FromArgb(155, 89, 182), 2);
                CreateSummaryCard(pnlSummary, "Total Customers", customersData.ToString(), "Active", Color.FromArgb(230, 126, 34), 3);
            };
            pnlSummary.Resize += (s, e) => pnlSummary.Invalidate(); // Kích hoạt sự kiện `Resize`
        }

        // Placeholder methods for data retrieval later not for this application    
        private decimal FetchTotalSales()
        {
            return 15750;
        }

        private int FetchTotalOrders()
        {
            return 245;
        }

        private int FetchTotalProducts()
        {
            return 1250;
        }

        private int FetchTotalCustomers()
        {
            return 864;
        }
    }
}