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
        private void CreateSummaryCard(Panel parent, string title, string value, string subtitle, Color color, int position)
        {
            // Tính toán chiều rộng của mỗi thẻ
            int cardWidth = (parent.Width - (5 * 10)) / 4; // Chừa khoảng cách giữa các thẻ
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

        private void InitializeDashboard()
        {
            this.BackColor = Color.White;

            // Tạo panel chứa thẻ tóm tắt
            Panel pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                Padding = new Padding(10)
            };

            this.Controls.Add(pnlSummary); // Thêm panel vào form

            // Xử lý căn chỉnh lại các thẻ khi panel thay đổi kích thước
            pnlSummary.Resize += (s, e) =>
            {
                pnlSummary.Controls.Clear(); // Xóa các thẻ cũ (tránh trùng lặp)
                CreateSummaryCard(pnlSummary, "Total Sales", "$15,750", "Today", Color.FromArgb(52, 152, 219), 0);
                CreateSummaryCard(pnlSummary, "Total Orders", "245", "Today", Color.FromArgb(46, 204, 113), 1);
                CreateSummaryCard(pnlSummary, "Total Products", "1,250", "In Stock", Color.FromArgb(155, 89, 182), 2);
                CreateSummaryCard(pnlSummary, "Total Customers", "864", "Active", Color.FromArgb(230, 126, 34), 3);
            };

            pnlSummary.OnResize(EventArgs.Empty); // Kích hoạt căn chỉnh ngay khi khởi tạo
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
