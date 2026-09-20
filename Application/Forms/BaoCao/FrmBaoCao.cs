using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;
using SelectPdf;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.BaoCao
{
    public partial class FrmBaoCao : Form
    {
        private DataTable currentData;

        public FrmBaoCao()
        {
            InitializeComponent();
        }

        private void FrmBaoCao_Load(object sender, EventArgs e)
        {
            ApplyStyling();
            
            cmbLoaiBaoCao.Items.Clear();
            string role = SessionManager.TenVT;
            if (role == "Điều phối viên")
            {
                cmbLoaiBaoCao.Items.Add("Tình hình xử lý đơn vận chuyển");
            }
            else if (role == "Kế toán")
            {
                cmbLoaiBaoCao.Items.Add("Doanh thu vận chuyển");
            }
            else
            {
                cmbLoaiBaoCao.Items.AddRange(new object[] {
                    "Doanh thu vận chuyển",
                    "Tình hình xử lý đơn vận chuyển"
                });
            }
            cmbLoaiBaoCao.SelectedIndexChanged += CmbLoaiBaoCao_SelectedIndexChanged;
            cmbTieuChiThongKe.SelectedIndexChanged += CmbTieuChiThongKe_SelectedIndexChanged;

            cboDinhDangXuat.Items.Clear();
            cboDinhDangXuat.Items.AddRange(new object[] { "PDF", "Excel" });
            cboDinhDangXuat.SelectedIndex = 0;

            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            ResetForm();
        }

        private void ApplyStyling()
        {
            this.BackColor = UIHelper.BgMain;
            dgvBaoCao.AutoGenerateColumns = true;
            UIHelper.StyleDataGridView(dgvBaoCao);
            
            UIHelper.StyleButtonPrimary(btnXem);
            UIHelper.StyleButtonOrange(btnXuatBaoCao);
            UIHelper.StyleButtonGray(btnLamMoi);
            
            lblTitle.ForeColor = UIHelper.Navy;
            lblLoai.ForeColor = UIHelper.TextDark;
            lblTuNgay.ForeColor = UIHelper.TextDark;
            lblDenNgay.ForeColor = UIHelper.TextDark;
            lblDinhDang.ForeColor = UIHelper.TextDark;
        }

        private void CmbLoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTieuChiThongKe.Items.Clear();
            if (cmbLoaiBaoCao.Text == "Doanh thu vận chuyển")
            {
                cmbTieuChiThongKe.Items.AddRange(new object[] {
                    "Theo ngày",
                    "Theo tháng"
                });
            }
            else if (cmbLoaiBaoCao.Text == "Tình hình xử lý đơn vận chuyển")
            {
                cmbTieuChiThongKe.Items.AddRange(new object[] {
                    "Theo trạng thái đơn"
                });
            }
            if (cmbTieuChiThongKe.Items.Count > 0)
                cmbTieuChiThongKe.SelectedIndex = 0;

            ResetGridAndSummary();
        }

        private void CmbTieuChiThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTieuChiThongKe.Text == "Theo tháng")
            {
                dtpTuNgay.Format = DateTimePickerFormat.Custom;
                dtpTuNgay.CustomFormat = "MM/yyyy";
                dtpTuNgay.ShowUpDown = true;
                lblTuNgay.Text = "Từ tháng:";
                
                dtpDenNgay.Format = DateTimePickerFormat.Custom;
                dtpDenNgay.CustomFormat = "MM/yyyy";
                dtpDenNgay.ShowUpDown = true;
                lblDenNgay.Text = "Đến tháng:";
            }
            else
            {
                dtpTuNgay.Format = DateTimePickerFormat.Custom;
                dtpTuNgay.CustomFormat = "dd/MM/yyyy";
                dtpTuNgay.ShowUpDown = false;
                lblTuNgay.Text = "Từ ngày:";
                
                dtpDenNgay.Format = DateTimePickerFormat.Custom;
                dtpDenNgay.CustomFormat = "dd/MM/yyyy";
                dtpDenNgay.ShowUpDown = false;
                lblDenNgay.Text = "Đến ngày:";
            }
            ResetGridAndSummary();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            cmbLoaiBaoCao.SelectedIndex = -1;
            cmbTieuChiThongKe.Items.Clear();
            cboDinhDangXuat.SelectedIndex = 0;
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            ResetGridAndSummary();
        }

        private void ResetGridAndSummary()
        {
            dgvBaoCao.DataSource = null;
            dgvBaoCao.Columns.Clear();
            currentData = null;
            btnXuatBaoCao.Enabled = false;
            txtTimKiem.Clear();

            lblTongHop1.Text = "";
            lblTongHop2.Text = "";
            lblTongHop3.Text = "";
            lblTongHop4.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (currentData == null) return;
            string keyword = txtTimKiem.Text.Trim().ToLower();
            
            if (string.IsNullOrEmpty(keyword))
            {
                ApplyCurrentDataFilter("");
                return;
            }

            // Build a dynamic filter string based on all string columns
            System.Collections.Generic.List<string> filters = new System.Collections.Generic.List<string>();
            foreach (DataColumn col in currentData.Columns)
            {
                if (col.DataType == typeof(string))
                {
                    filters.Add(string.Format("Convert([{0}], 'System.String') LIKE '%{1}%'", col.ColumnName, keyword.Replace("'", "''")));
                }
            }

            string finalFilter = filters.Count > 0 ? string.Join(" OR ", filters) : "1=0"; // fallback if no string columns
            ApplyCurrentDataFilter(finalFilter);
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            if (currentData != null)
            {
                ApplyCurrentDataFilter("");
            }
        }

        private void ApplyCurrentDataFilter(string filter)
        {
            if (currentData == null) return;
            DataView dv = currentData.DefaultView;
            dv.RowFilter = filter;
            dgvBaoCao.DataSource = dv;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbLoaiBaoCao.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpTuNgay.Enabled && dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResetGridAndSummary();

            string query = "";
            SqlParameter[] p = null;
            DateTime tuNgay, denNgay;

            if (cmbTieuChiThongKe.Text == "Theo tháng")
            {
                tuNgay = new DateTime(dtpTuNgay.Value.Year, dtpTuNgay.Value.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(dtpDenNgay.Value.Year, dtpDenNgay.Value.Month);
                denNgay = new DateTime(dtpDenNgay.Value.Year, dtpDenNgay.Value.Month, daysInMonth, 23, 59, 59);
            }
            else
            {
                tuNgay = dtpTuNgay.Value.Date;
                denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
            }

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Thời gian bắt đầu không được lớn hơn thời gian kết thúc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResetGridAndSummary();

            try
            {
                string loaiBaoCao = cmbLoaiBaoCao.Text;
                string tieuChi = cmbTieuChiThongKe.Text;

                if (loaiBaoCao == "Doanh thu vận chuyển")
                {
                    if (tieuChi == "Theo ngày")
                    {
                        query = @"
                            SELECT CAST(ptt.NgayTT AS DATE) AS Ngay,
                                   COUNT(*) AS SoPhieu, SUM(ptt.SoTienTT) AS TongDoanhThu
                            FROM PhieuThanhToanVC ptt
                            WHERE ptt.NgayTT >= @TuNgay AND ptt.NgayTT <= @DenNgay AND ptt.TrangThaiTT = N'Đã thanh toán'
                            GROUP BY CAST(ptt.NgayTT AS DATE)
                            ORDER BY Ngay";
                        p = new SqlParameter[] {
                            new SqlParameter("@TuNgay", tuNgay),
                            new SqlParameter("@DenNgay", denNgay)
                        };
                        currentData = DatabaseHelper.GetDataTable(query, p);
                        SetupGridDoanhThuNgay(currentData);
                    }
                    else if (tieuChi == "Theo tháng")
                    {
                        query = @"
                            SELECT MONTH(ptt.NgayTT) AS Thang, YEAR(ptt.NgayTT) AS Nam,
                                   COUNT(*) AS SoPhieu, SUM(ptt.SoTienTT) AS TongDoanhThu
                            FROM PhieuThanhToanVC ptt
                            WHERE ptt.NgayTT >= @TuNgay AND ptt.NgayTT <= @DenNgay AND ptt.TrangThaiTT = N'Đã thanh toán'
                            GROUP BY MONTH(ptt.NgayTT), YEAR(ptt.NgayTT) 
                            ORDER BY Nam, Thang";
                        p = new SqlParameter[] {
                            new SqlParameter("@TuNgay", tuNgay),
                            new SqlParameter("@DenNgay", denNgay)
                        };
                        currentData = DatabaseHelper.GetDataTable(query, p);
                        SetupGridDoanhThuThang(currentData);
                    }
                }
                else if (loaiBaoCao == "Tình hình xử lý đơn vận chuyển")
                {
                    if (tieuChi == "Theo trạng thái đơn")
                    {
                        query = @"
                            SELECT TrangThaiDon, COUNT(*) AS SoLuongDon
                            FROM DonVanChuyen 
                            WHERE NgayTao >= @TuNgay AND NgayTao <= @DenNgay
                            GROUP BY TrangThaiDon";
                        p = new SqlParameter[] {
                            new SqlParameter("@TuNgay", tuNgay),
                            new SqlParameter("@DenNgay", denNgay)
                        };
                        currentData = DatabaseHelper.GetDataTable(query, p);
                        SetupGridDonVanChuyen(currentData);
                    }
                }

                if (currentData == null || currentData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                btnXuatBaoCao.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy báo cáo:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupGridDoanhThuNgay(DataTable dt)
        {
            dgvBaoCao.DataSource = dt;
            dgvBaoCao.Columns["Ngay"].HeaderText = "Ngày";
            dgvBaoCao.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvBaoCao.Columns["SoPhieu"].HeaderText = "Số phiếu thanh toán";
            dgvBaoCao.Columns["TongDoanhThu"].HeaderText = "Tổng doanh thu";
            dgvBaoCao.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";

            int tongPhieu = 0;
            decimal tongTien = 0;
            foreach (DataRow r in dt.Rows)
            {
                tongPhieu += Convert.ToInt32(r["SoPhieu"]);
                tongTien += Convert.ToDecimal(r["TongDoanhThu"]);
            }

            lblTongHop1.Text = $"Tổng số phiếu thanh toán: {tongPhieu:N0}";
            lblTongHop2.Text = $"Tổng doanh thu trong kỳ: {tongTien:N0} VNĐ";
            lblTongHop3.Text = $"Số ngày có phát sinh doanh thu: {dt.Rows.Count:N0}";
        }

        private void SetupGridDoanhThuThang(DataTable dt)
        {
            dgvBaoCao.DataSource = dt;
            dgvBaoCao.Columns["Thang"].HeaderText = "Tháng";
            dgvBaoCao.Columns["Nam"].HeaderText = "Năm";
            dgvBaoCao.Columns["SoPhieu"].HeaderText = "Số phiếu thanh toán";
            dgvBaoCao.Columns["TongDoanhThu"].HeaderText = "Tổng doanh thu";
            dgvBaoCao.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";

            int tongPhieu = 0;
            decimal tongTien = 0;
            foreach (DataRow r in dt.Rows)
            {
                tongPhieu += Convert.ToInt32(r["SoPhieu"]);
                tongTien += Convert.ToDecimal(r["TongDoanhThu"]);
            }

            lblTongHop1.Text = $"Tổng số phiếu thanh toán: {tongPhieu:N0}";
            lblTongHop2.Text = $"Tổng doanh thu trong kỳ: {tongTien:N0} VNĐ";
            lblTongHop3.Text = $"Số tháng có phát sinh doanh thu: {dt.Rows.Count:N0}";
        }

        private void SetupGridDonVanChuyen(DataTable dt)
        {
            dgvBaoCao.DataSource = dt;
            dgvBaoCao.Columns["TrangThaiDon"].HeaderText = "Trạng thái đơn";
            dgvBaoCao.Columns["SoLuongDon"].HeaderText = "Số lượng đơn";

            int tong = 0, moi = 0, dp = 0, vc = 0, ht = 0, huy = 0;
            foreach (DataRow r in dt.Rows)
            {
                int sl = Convert.ToInt32(r["SoLuongDon"]);
                tong += sl;
                string st = r["TrangThaiDon"].ToString();
                if (st == "Mới tạo") moi += sl;
                else if (st == "Đang điều phối") dp += sl;
                else if (st == "Đang vận chuyển") vc += sl;
                else if (st == "Hoàn thành") ht += sl;
                else if (st == "Đã hủy") huy += sl;
            }

            lblTongHop1.Text = $"Tổng số đơn: {tong:N0}";
            lblTongHop2.Text = $"Mới/Điều phối: {moi+dp:N0}";
            lblTongHop3.Text = $"Đang VC/Hoàn thành: {vc}/{ht}";
            lblTongHop4.Text = $"Đã hủy: {huy:N0}";
        }


        private string GetReportTitle()
        {
            if (cmbLoaiBaoCao.SelectedIndex == -1) return "BÁO CÁO THỐNG KÊ";
            if (cmbLoaiBaoCao.Text == "Tình hình xử lý đơn vận chuyển") return "BÁO CÁO TÌNH HÌNH XỬ LÝ ĐƠN VẬN CHUYỂN";
            string titlePrefix = "BÁO CÁO DOANH THU VẬN CHUYỂN";
            return $"{titlePrefix} - {cmbTieuChiThongKe.Text.ToUpper()}";
        }

        private string GetReportFilePrefix()
        {
            if (cmbLoaiBaoCao.Text == "Doanh thu vận chuyển") return "BaoCao_DoanhThu";
            if (cmbLoaiBaoCao.Text == "Tình hình xử lý đơn vận chuyển") return "BaoCao_TinhHinhXuLyDon";
            return "BaoCao_ThongKe";
        }

        private string GetSuggestedFileName(string extension)
        {
            string prefix = GetReportFilePrefix();
            string exportTime = DateTime.Now.ToString("yyyyMMdd_HHmm");

            string tuThoiGian;
            string denThoiGian;

            if (cmbTieuChiThongKe.Text == "Theo tháng") // Doanh thu theo tháng
            {
                tuThoiGian = dtpTuNgay.Value.ToString("yyyyMM");
                denThoiGian = dtpDenNgay.Value.ToString("yyyyMM");
            }
            else
            {
                tuThoiGian = dtpTuNgay.Value.ToString("yyyyMMdd");
                denThoiGian = dtpDenNgay.Value.ToString("yyyyMMdd");
            }

            return $"{prefix}_{tuThoiGian}_{denThoiGian}_{exportTime}.{extension}";
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            if (currentData == null || currentData.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng xem báo cáo trước khi xuất file.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string type = cboDinhDangXuat.Text;

            if (type == "Excel" || type == "Excel/CSV")
            {
                string fileName = GetSuggestedFileName("xlsx");
                ExportExcel(fileName);
            }
            else if (type == "PDF")
            {
                string fileName = GetSuggestedFileName("pdf");
                string reportTitle = GetReportTitle();
                ExportPDF(fileName, reportTitle);
            }
        }

        private void ExportExcel(string fileName)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = fileName
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // EPPlus License for non-commercial (if needed for v5+, but 4.5.3.3 doesn't strictly need this, still good practice)
                    // ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 
                    
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet ws = package.Workbook.Worksheets.Add("Báo Cáo");

                        string reportTitle = GetReportTitle();
                        ws.Cells["A1"].Value = reportTitle.ToUpper();
                        ws.Cells["A1"].Style.Font.Bold = true;
                        ws.Cells["A1"].Style.Font.Size = 16;
                        ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        
                        int colCount = dgvBaoCao.Columns.Count;
                        if (colCount > 0)
                            ws.Cells[1, 1, 1, colCount].Merge = true;

                        // Headers
                        int rowStart = 3;
                        for (int i = 0; i < colCount; i++)
                        {
                            ws.Cells[rowStart, i + 1].Value = dgvBaoCao.Columns[i].HeaderText;
                            ws.Cells[rowStart, i + 1].Style.Font.Bold = true;
                            ws.Cells[rowStart, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[rowStart, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 162, 184)); // Info color
                            ws.Cells[rowStart, i + 1].Style.Font.Color.SetColor(Color.White);
                            ws.Cells[rowStart, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[rowStart, i + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }

                        // Data
                        int rowIndex = rowStart + 1;
                        foreach (DataGridViewRow row in dgvBaoCao.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < colCount; i++)
                                {
                                    object cellValue = row.Cells[i].Value;
                                    // if it's a number, make sure it is saved as number
                                    if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal numVal))
                                        ws.Cells[rowIndex, i + 1].Value = numVal;
                                    else
                                        ws.Cells[rowIndex, i + 1].Value = cellValue?.ToString() ?? "";
                                }
                                rowIndex++;
                            }
                        }

                        // AutoFit columns and add borders
                        if (rowIndex > rowStart)
                        {
                            using (ExcelRange range = ws.Cells[rowStart, 1, rowIndex - 1, colCount])
                            {
                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            }
                            ws.Cells[ws.Dimension.Address].AutoFitColumns();
                        }

                        FileInfo fi = new FileInfo(sfd.FileName);
                        package.SaveAs(fi);
                    }
                    
                    MessageBox.Show("Xuất báo cáo Excel thành công!\n" + sfd.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportPDF(string fileName, string reportTitle)
        {
            string html = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>{reportTitle}</title>
    <style>
        body {{ font-family: Arial, sans-serif; padding: 40px; color: #333; }}
        .header {{ text-align: left; margin-bottom: 20px; }}
        .header h3 {{ margin: 0; color: #0d47a1; }}
        .header p {{ margin: 2px 0; font-size: 14px; font-weight: bold; }}
        .title {{ text-align: center; margin: 40px 0 20px 0; }}
        .title h1 {{ margin: 0; text-transform: uppercase; font-size: 24px; }}
        .info-box {{ margin-bottom: 30px; font-size: 14px; line-height: 1.6; }}
        table {{ width: 100%; border-collapse: collapse; margin-bottom: 30px; font-size: 13px; }}
        th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
        th {{ background-color: #f5f5f5; color: #0d47a1; font-weight: bold; text-align: center; }}
        td.num {{ text-align: right; }}
        .summary {{ margin-bottom: 50px; font-size: 14px; font-weight: bold; line-height: 1.8; }}
        .footer {{ display: flex; justify-content: space-between; text-align: center; margin-top: 50px; }}
        .sig-box {{ width: 30%; }}
        .sig-title {{ font-weight: bold; margin-bottom: 60px; }}
    </style>
</head>
<body>
    <div class='header'>
        <h3>CÔNG TY TNHH THƯƠNG MẠI DỊCH VỤ VẬN TẢI HIVE</h3>
        <p>HỆ THỐNG QUẢN LÝ ĐIỀU PHỐI VẬN CHUYỂN</p>
    </div>

    <div class='title'>
        <h1>{reportTitle}</h1>
    </div>

    <div class='info-box'>
        <p><strong>Loại báo cáo:</strong> {cmbLoaiBaoCao.Text}{(cmbLoaiBaoCao.SelectedIndex == 0 ? " - " + cmbTieuChiThongKe.Text : "")}</p>
        <p><strong>Thời gian báo cáo:</strong> {(dtpTuNgay.Enabled ? $"{(cmbTieuChiThongKe.Text == "Theo tháng" ? "Từ tháng " + dtpTuNgay.Value.ToString("MM/yyyy") + " đến tháng " + dtpDenNgay.Value.ToString("MM/yyyy") : "Từ ngày " + dtpTuNgay.Value.ToString("dd/MM/yyyy") + " đến ngày " + dtpDenNgay.Value.ToString("dd/MM/yyyy"))}" : $"Thời điểm thống kê: {DateTime.Now:dd/MM/yyyy HH:mm}")}</p>
        <p><strong>Người xuất báo cáo:</strong> {SessionManager.HoTenNV}</p>
        <p><strong>Vai trò:</strong> {SessionManager.TenVT}</p>
        <p><strong>Ngày xuất báo cáo:</strong> {DateTime.Now:dd/MM/yyyy HH:mm}</p>
    </div>

    <table>
        <thead>
            <tr>
                <th>STT</th>";

            // Add Headers
            for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
            {
                html += $"<th>{dgvBaoCao.Columns[i].HeaderText}</th>";
            }
            
            html += @"
            </tr>
        </thead>
        <tbody>";

            // Add Data Rows
            int stt = 1;
            foreach (DataGridViewRow row in dgvBaoCao.Rows)
            {
                if (row.IsNewRow) continue;
                html += $"<tr><td style='text-align:center;'>{stt++}</td>";
                for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                {
                    string value = row.Cells[i].FormattedValue?.ToString() ?? "";
                    // If it's a number column, align right
                    string cssClass = (dgvBaoCao.Columns[i].DefaultCellStyle.Format != "") ? "class='num'" : "";
                    html += $"<td {cssClass}>{value}</td>";
                }
                html += "</tr>";
            }

            html += @"
        </tbody>
    </table>

    <div class='summary'>
        <p>TỔNG HỢP:</p>";
        
            if (!string.IsNullOrEmpty(lblTongHop1.Text)) html += $"<p>{lblTongHop1.Text}</p>";
            if (!string.IsNullOrEmpty(lblTongHop2.Text)) html += $"<p>{lblTongHop2.Text}</p>";
            if (!string.IsNullOrEmpty(lblTongHop3.Text)) html += $"<p>{lblTongHop3.Text}</p>";
            if (!string.IsNullOrEmpty(lblTongHop4.Text)) html += $"<p>{lblTongHop4.Text}</p>";

            html += $@"
    </div>

    <div class='footer'>
        <div class='sig-box'>
            <div class='sig-title'>GIÁM ĐỐC</div>
            <div>(Ký, ghi rõ họ tên)</div>
        </div>
        <div class='sig-box'>
            <div class='sig-title'>QUẢN LÝ VẬN HÀNH</div>
            <div>(Ký, ghi rõ họ tên)</div>
        </div>
        <div class='sig-box'>
            <div class='sig-title'>NGƯỜI LẬP BÁO CÁO</div>
            <div>(Ký, ghi rõ họ tên)</div>
        </div>
    </div>
</body>
</html>";

            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
                
                HtmlToPdf converter = new HtmlToPdf();
                converter.Options.PdfPageSize = PdfPageSize.A4;
                converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
                converter.Options.MarginLeft = 20;
                converter.Options.MarginRight = 20;
                converter.Options.MarginTop = 20;
                converter.Options.MarginBottom = 20;

                PdfDocument doc = converter.ConvertHtmlString(html);
                doc.Save(path);
                doc.Close();

                MessageBox.Show($"Đã tạo file báo cáo PDF thành công tại Desktop:\n{path}", "Xuất báo cáo PDF thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = path, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
