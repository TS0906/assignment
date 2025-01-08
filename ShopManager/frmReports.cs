using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

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

            Label lblTitle = new Label
            {
                Text = "Business Reports",
                Font = new Font("Times New Roman", 18, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 50
            };

            tabReports = new TabControl
            {
                Dock = DockStyle.Fill
            };

            TabPage tabSalesReport = CreateSalesReportTab();
            TabPage tabInventoryReport = CreateInventoryReportTab();
            TabPage tabCustomerReport = CreateCustomerReportTab();

            tabReports.TabPages.AddRange(new TabPage[] { tabSalesReport, tabInventoryReport, tabCustomerReport });

            Panel pnlActions = CreateActionPanel();

            this.Controls.Add(tabReports);
            this.Controls.Add(pnlActions);
            this.Controls.Add(lblTitle);
        }
        // Existing implementation remains unchanged
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
            btnExportReport.Click += BtnExportReport_Click;

            Button btnPrintReport = new Button
            {
                Text = "Print Report",
                Location = new Point(140, 10),
                Size = new Size(120, 30),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White
            };
            btnPrintReport.Click += BtnPrintReport_Click;

            pnlActions.Controls.AddRange(new Control[] { btnExportReport, btnPrintReport });

            return pnlActions;
        }
        // make an export output by excel files
        private void BtnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView currentGrid = GetCurrentDataGridView();
                if (currentGrid == null) return;

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(saveDialog.FileName).ToLower();

                    if (extension == ".csv")
                    {
                        ExportToCSV(currentGrid, saveDialog.FileName);
                    }
                    else if (extension == ".xlsx")
                    {
                        ExportToExcel(currentGrid, saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // make a print preview clone 
        private void BtnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView currentGrid = GetCurrentDataGridView();
                if (currentGrid == null) return;

                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += (s, ev) => PrintPage(s, ev, currentGrid);

                PrintPreviewDialog preview = new PrintPreviewDialog
                {
                    Document = printDoc,
                    WindowState = FormWindowState.Maximized
                };

                if (preview.ShowDialog() == DialogResult.OK)
                {
                    PrintDialog printDialog = new PrintDialog
                    {
                        Document = printDoc,
                        UseEXDialog = true
                    };

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDoc.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Printing failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // return if SelectedTab == null but in this applycation that situation can't appear 100%
        private DataGridView GetCurrentDataGridView()
        {
            if (tabReports.SelectedTab == null)
            {
                MessageBox.Show("Please select a report tab first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return tabReports.SelectedTab.Controls.OfType<DataGridView>().FirstOrDefault();
        }
        // method export to excel
        private void ExportToCSV(DataGridView grid, string filename)
        {
            StringBuilder sb = new StringBuilder();

            // Add headers
            string[] headers = grid.Columns.Cast<DataGridViewColumn>()
                                         .Select(column => column.HeaderText)
                                         .ToArray();
            sb.AppendLine(string.Join(",", headers));

            // Add rows
            foreach (DataGridViewRow row in grid.Rows)
            {
                string[] cells = row.Cells.Cast<DataGridViewCell>()
                                        .Select(cell => cell.Value?.ToString() ?? "")
                                        .Select(cell => cell.Contains(",") ? $"\"{cell}\"" : cell)
                                        .ToArray();
                sb.AppendLine(string.Join(",", cells));
            }

            File.WriteAllText(filename, sb.ToString());
            MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportToExcel(DataGridView grid, string filename)
        {
            MessageBox.Show("Excel export functionality requires additional libraries. Please implement using your preferred Excel library.",
                          "Not Implemented",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
        //page settings for print preview
        private void PrintPage(object sender, PrintPageEventArgs e, DataGridView grid)
        {
            // Page settings
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float availableWidth = e.MarginBounds.Width;
            float availableHeight = e.MarginBounds.Height;

            // Print title
            string title = tabReports.SelectedTab.Text;
            using (Font titleFont = new Font("Times New Roman", 14, FontStyle.Bold))
            {
                e.Graphics.DrawString(title, titleFont, Brushes.Black, leftMargin, topMargin);
                topMargin += titleFont.GetHeight() + 10;
            }

            // Print headers
            float[] columnWidths = new float[grid.Columns.Count];
            float totalWidth = 0;
            using (Font headerFont = new Font("Times New Roman", 10, FontStyle.Bold))
            {
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    float width = e.Graphics.MeasureString(grid.Columns[i].HeaderText, headerFont).Width + 10;
                    columnWidths[i] = width;
                    totalWidth += width;
                }

                float scale = Math.Min(1.0f, availableWidth / totalWidth);
                float x = leftMargin;

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    columnWidths[i] *= scale;
                    e.Graphics.DrawString(grid.Columns[i].HeaderText, headerFont, Brushes.Black, x, topMargin);
                    x += columnWidths[i];
                }
                topMargin += headerFont.GetHeight() + 5;
            }

            // Print data
            using (Font dataFont = new Font("Times New Roman", 9))
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (topMargin > availableHeight)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    float x = leftMargin;
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        string cellValue = row.Cells[i].Value?.ToString() ?? "";
                        e.Graphics.DrawString(cellValue, dataFont, Brushes.Black, x, topMargin);
                        x += columnWidths[i];
                    }
                    topMargin += dataFont.GetHeight() + 5;
                }
            }

            e.HasMorePages = false;
        }
    }
}