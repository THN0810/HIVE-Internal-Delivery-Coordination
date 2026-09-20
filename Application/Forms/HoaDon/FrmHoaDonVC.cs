using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.HoaDon
{
    public partial class FrmHoaDonVC : Form
    {
        private enum FormMode { View, Add }
        private FormMode currentMode = FormMode.View;
        
        private DataTable dtHoaDon;

        public FrmHoaDonVC() { InitializeComponent(); }

        private void FrmHoaDonVC_Load(object sender, EventArgs e)
        {
            ApplyStyling();
            SetupGridColumns();
            LoadComboBoxes();
            RefreshData();
        }

        private void ApplyStyling()
        {
            this.BackColor = UIHelper.BgMain;
            lblTitle.ForeColor = UIHelper.Navy;
            
            UIHelper.StyleDataGridView(dgvHoaDon);
            UIHelper.StyleDataGridView(dgvPhieuChoXuatHD);
            UIHelper.StyleGroupBox(grpThongTin);
            
            UIHelper.StyleButtonGreen(btnPhatHanhHD);
            UIHelper.StyleButtonDanger(btnHuyHD);
            UIHelper.StyleButtonOutline(btnXemChiTiet);
            UIHelper.StyleButtonPrimary(btnXuatHoaDon);
            UIHelper.StyleButtonOutline(btnLamMoi);
            
            UIHelper.StyleButtonPrimary(btnTimKiem);
            UIHelper.StyleButtonOutline(btnBoLoc);
            
            UIHelper.StyleButtonPrimary(btnTimKiem);
            UIHelper.StyleButtonOutline(btnBoLoc);
        }

        private void SetupGridColumns()
        {
            dgvPhieuChoXuatHD.AutoGenerateColumns = false;
            dgvPhieuChoXuatHD.Columns.Clear();
            dgvPhieuChoXuatHD.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaPhieuTT", HeaderText = "Mã Phiếu", DataPropertyName = "MaPhieuTT", Width = 100 });
            dgvPhieuChoXuatHD.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaDonVC", HeaderText = "Mã Đơn", DataPropertyName = "MaDonVC", Width = 100 });
            dgvPhieuChoXuatHD.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKH", HeaderText = "Khách hàng", DataPropertyName = "TenKH", Width = 200 });
            dgvPhieuChoXuatHD.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoTienTT", HeaderText = "Số Tiền TT (Gồm VAT)", DataPropertyName = "SoTienTT", Width = 160, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvPhieuChoXuatHD.CellClick += new DataGridViewCellEventHandler(this.dgvPhieuChoXuatHD_CellClick);

            dgvHoaDon.AutoGenerateColumns = false; 
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaHD", HeaderText = "Mã HĐ", DataPropertyName = "MaHD", Width = 80 });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKH", HeaderText = "Khách hàng", DataPropertyName = "TenKH", Width = 160 });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayPhatHanh", HeaderText = "Ngày phát hành", DataPropertyName = "NgayPhatHanh", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "TongTienTruocThue", HeaderText = "Trước thuế", DataPropertyName = "TongTienTruocThue", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThueVAT", HeaderText = "VAT (%)", DataPropertyName = "ThueVAT", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "0.00" } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "TongTienSauThue", HeaderText = "Sau thuế", DataPropertyName = "TongTienSauThue", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiHD", HeaderText = "Trạng thái", DataPropertyName = "TrangThaiHD", Width = 120 });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaPhieuTT", HeaderText = "Mã Phiếu TT", DataPropertyName = "MaPhieuTT", Width = 100 });

        }

        private void LoadComboBoxes()
        {
            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.AddRange(new object[] { "Đã phát hành", "Đã hủy" });
            cmbTrangThai.SelectedIndex = 0;

            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Đã phát hành", "Đã hủy" });
            cboLocTrangThai.SelectedIndex = 0;
        }

        private void LoadPhieuChoXuatHD()
        {
            string q = @"SELECT p.MaPhieuTT, p.MaDonVC, kh.TenKH, p.SoTienTT
                         FROM PhieuThanhToanVC p
                         INNER JOIN KhachHang kh ON p.MaKH = kh.MaKH
                         WHERE p.TrangThaiTT = N'Đã thanh toán' 
                         AND NOT EXISTS (SELECT 1 FROM HoaDonVanChuyen hd WHERE hd.MaPhieuTT = p.MaPhieuTT)
                         ORDER BY p.NgayTT DESC";
            dgvPhieuChoXuatHD.DataSource = DatabaseHelper.GetDataTable(q);
        }

        private void LoadData()
        {
            string q = @"
                SELECT hd.MaHD, kh.TenKH, hd.NgayPhatHanh, hd.TongTienTruocThue, hd.ThueVAT,
                       hd.TongTienSauThue, hd.TrangThaiHD, hd.MaPhieuTT
                FROM HoaDonVanChuyen hd
                INNER JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                ORDER BY hd.NgayPhatHanh DESC";
            dtHoaDon = DatabaseHelper.GetDataTable(q);
        }

        private void ApplyFilter()
        {
            if (dtHoaDon == null) return;

            string keyword = txtTimKiem.Text.Trim().ToLower();
            string trangThai = cboLocTrangThai.Text;

            DataView dv = dtHoaDon.DefaultView;
            string filter = "1=1";

            if (trangThai != "Tất cả")
            {
                filter += string.Format(" AND TrangThaiHD = '{0}'", trangThai.Replace("'", "''"));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += string.Format(" AND (MaHD LIKE '%{0}%' OR TenKH LIKE '%{0}%' OR MaPhieuTT LIKE '%{0}%')", keyword.Replace("'", "''"));
            }

            dv.RowFilter = filter;
            dgvHoaDon.DataSource = dv;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocTrangThai.SelectedIndex = 0;
            ApplyFilter();
        }

        private void ClearForm()
        {
            txtMaHD.Clear(); 
            txtKhachHang.Clear();
            txtTongTruocThue.Text = "0"; 
            txtThueVAT.Text = "8"; 
            txtTongSauThue.Text = "0";
            
            if (cmbPhieuTT.Items.Count > 0 && cmbPhieuTT.DataSource == null) cmbPhieuTT.SelectedIndex = 0;
            if (cmbTrangThai.Items.Count > 0) cmbTrangThai.SelectedIndex = 0;
        }

        private void SetFormMode(FormMode mode)
        {
            currentMode = mode;
            bool isAdding = (mode == FormMode.Add);

            System.Drawing.Color editBg = System.Drawing.Color.White;
            System.Drawing.Color viewBg = System.Drawing.Color.White;

            dtpNgayPhatHanh.Enabled = isAdding;
            cmbTrangThai.Enabled = isAdding;
            cmbPhieuTT.Enabled = isAdding;

            txtThueVAT.ReadOnly = !isAdding;
            txtThueVAT.BackColor = isAdding ? editBg : viewBg;

            txtMaHD.ReadOnly = true; txtMaHD.BackColor = viewBg;
            txtKhachHang.ReadOnly = true; txtKhachHang.BackColor = viewBg;
            txtTongTruocThue.ReadOnly = true; txtTongTruocThue.BackColor = viewBg;
            txtTongSauThue.ReadOnly = true; txtTongSauThue.BackColor = viewBg;

            bool isQuanLy = SessionManager.TenVT == "Quản lý";
            btnPhatHanhHD.Enabled = isAdding && !isQuanLy;
            btnHuyHD.Enabled = !isAdding && cmbTrangThai.Text != "Đã hủy" && !string.IsNullOrEmpty(txtMaHD.Text) && !isQuanLy;
            btnXemChiTiet.Enabled = !isAdding && !string.IsNullOrEmpty(txtMaHD.Text);
            
            btnXuatHoaDon.Enabled = !isAdding && !string.IsNullOrEmpty(txtMaHD.Text);
            btnLamMoi.Enabled = true;
            
            pnlFilter.Enabled = true;
        }

        private void RefreshData()
        {
            LoadData();
            LoadPhieuChoXuatHD();
            ApplyFilter();
            ClearForm();
            SetFormMode(FormMode.View);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            if (cboLocTrangThai.Items.Count > 0) cboLocTrangThai.SelectedIndex = 0;
            RefreshData();
        }



        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView drv = dgvHoaDon.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv == null) return;
                
                string maHD = drv["MaHD"].ToString();

                txtMaHD.Text = maHD;
                
                cmbPhieuTT.DataSource = null;
                cmbPhieuTT.Items.Clear();
                cmbPhieuTT.Items.Add(drv["MaPhieuTT"].ToString());
                cmbPhieuTT.SelectedIndex = 0;

                txtKhachHang.Text = drv["TenKH"].ToString();
                
                if (drv["NgayPhatHanh"] != DBNull.Value)
                    dtpNgayPhatHanh.Value = Convert.ToDateTime(drv["NgayPhatHanh"]);
                
                txtTongTruocThue.Text = string.Format("{0:N0}", drv["TongTienTruocThue"]);
                txtThueVAT.Text = Convert.ToDecimal(drv["ThueVAT"]).ToString("0.00");
                txtTongSauThue.Text = string.Format("{0:N0}", drv["TongTienSauThue"]);
                cmbTrangThai.Text = drv["TrangThaiHD"].ToString();

                SetFormMode(FormMode.View);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var frm = new FrmChiTietHoaDon(txtMaHD.Text);
            frm.ShowDialog();
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView drv = dgvHoaDon.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv != null)
                {
                    string maHD = drv["MaHD"].ToString();
                    if (!string.IsNullOrEmpty(maHD))
                    {
                        var frm = new FrmChiTietHoaDon(maHD);
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void dgvPhieuChoXuatHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (SessionManager.TenVT == "Quản lý") return;
                DataRowView drv = dgvPhieuChoXuatHD.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv == null) return;
                
                ClearForm();
                txtMaHD.Text = IdGenerator.GetNextId("HoaDonVanChuyen", "MaHD", "HD");
                SetFormMode(FormMode.Add);

                string maPhieu = drv["MaPhieuTT"].ToString();
                cmbPhieuTT.DataSource = null;
                cmbPhieuTT.Items.Clear();
                cmbPhieuTT.Items.Add(maPhieu);
                cmbPhieuTT.SelectedIndex = 0;

                txtKhachHang.Text = drv["TenKH"].ToString();
                
                dtpNgayPhatHanh.Value = DateTime.Now;
                
                decimal soTienTT = Convert.ToDecimal(drv["SoTienTT"]);
                decimal truocThue = Math.Round(soTienTT / 1.08m, 2);
                
                txtTongTruocThue.Text = truocThue.ToString("N0");
                txtThueVAT.Text = "8";
                
                TinhTongTien();
            }
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            if (currentMode != FormMode.View || string.IsNullOrEmpty(txtMaHD.Text)) { MessageBox.Show("Vui lòng chọn một hóa đơn đã phát hành để hủy."); return; }
            if (cmbTrangThai.Text == "Đã hủy") { MessageBox.Show("Hóa đơn này đã bị hủy."); return; }
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn này không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "UPDATE HoaDonVanChuyen SET TrangThaiHD = N'Đã hủy' WHERE MaHD = @M";
                DatabaseHelper.ExecuteNonQuery(sql, new SqlParameter[] { new SqlParameter("@M", txtMaHD.Text) });
                MessageBox.Show("Đã hủy hóa đơn thành công!");
                RefreshData();
            }
        }

        private void txtThueVAT_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal tongTruocThue = 0;
            string txtT = txtTongTruocThue.Text.Replace(".", "").Replace(",", "");
            if (decimal.TryParse(txtT, out decimal t)) tongTruocThue = t;

            if (decimal.TryParse(txtThueVAT.Text, out decimal vat) && vat >= 0)
            {
                decimal tongSauThue = tongTruocThue * (1 + vat / 100m);
                txtTongSauThue.Text = tongSauThue.ToString("N0");
            }
            else
            {
                txtTongSauThue.Text = "Lỗi VAT";
            }
        }

        private void btnPhatHanhHD_Click(object sender, EventArgs e)
        {
            if (currentMode != FormMode.Add) return;
            
            if (cmbPhieuTT.Items.Count == 0 || string.IsNullOrEmpty(cmbPhieuTT.Text)) { MessageBox.Show("Vui lòng chọn một phiếu thanh toán chờ xuất!"); return; }
            if (!decimal.TryParse(txtThueVAT.Text, out decimal vat) || vat < 0 || vat > 100) { MessageBox.Show("Thuế VAT không hợp lệ (0-100)!"); return; }

            string maHD = txtMaHD.Text;
            string maPTT = cmbPhieuTT.Text;

            // Check if MaPhieuTT already exists in HoaDonVanChuyen
            int exists = (int)DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM HoaDonVanChuyen WHERE MaPhieuTT = @M", new SqlParameter[] { new SqlParameter("@M", maPTT) });
            if (exists > 0)
            {
                MessageBox.Show("Phiếu thanh toán này đã từng được xuất hóa đơn (kể cả hóa đơn đã hủy). Không thể phát hành thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string maKH = "";
            DataTable dtKH = DatabaseHelper.GetDataTable("SELECT MaKH FROM PhieuThanhToanVC WHERE MaPhieuTT = @M", new SqlParameter[] { new SqlParameter("@M", maPTT) });
            if (dtKH.Rows.Count > 0) maKH = dtKH.Rows[0]["MaKH"].ToString();

            decimal tongTruoc = 0;
            string txtT = txtTongTruocThue.Text.Replace(".", "").Replace(",", "");
            if (decimal.TryParse(txtT, out decimal t)) tongTruoc = t;

            if (tongTruoc < 0)
            {
                MessageBox.Show("Tổng tiền trước thuế không được là số âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cmds = new System.Collections.Generic.List<SqlCommand>();

            string qHD = @"INSERT INTO HoaDonVanChuyen (MaHD, NgayPhatHanh, TongTienTruocThue, ThueVAT, TrangThaiHD, MaPhieuTT, MaNV, MaKH)
                           VALUES (@MaHD, @NgayPH, @TienTruoc, @VAT, @TrangThai, @MaPTT, @MaNV, @MaKH)";
            var cmdHD = new SqlCommand(qHD);
            cmdHD.Parameters.AddWithValue("@MaHD", maHD);
            cmdHD.Parameters.AddWithValue("@NgayPH", dtpNgayPhatHanh.Value);
            cmdHD.Parameters.AddWithValue("@TienTruoc", tongTruoc);
            cmdHD.Parameters.AddWithValue("@VAT", vat);
            cmdHD.Parameters.AddWithValue("@TrangThai", "Đã phát hành"); // Luôn là Đã phát hành khi tạo mới
            cmdHD.Parameters.AddWithValue("@MaPTT", maPTT);
            cmdHD.Parameters.AddWithValue("@MaNV", SessionManager.MaNV);
            cmdHD.Parameters.AddWithValue("@MaKH", maKH);
            cmds.Add(cmdHD);

            // Tự động sinh 1 dòng chi tiết theo yêu cầu
            string qCT = "INSERT INTO ChiTietHDVC (MaHD, MaLoaiPhi, SoLuong, DonGia) VALUES (@HD, @LP, @SL, @DG)";
            var cmdCT = new SqlCommand(qCT);
            cmdCT.Parameters.AddWithValue("@HD", maHD);
            cmdCT.Parameters.AddWithValue("@LP", "LP001");
            cmdCT.Parameters.AddWithValue("@SL", 1);
            cmdCT.Parameters.AddWithValue("@DG", tongTruoc);
            cmds.Add(cmdCT);

            if (DatabaseHelper.ExecuteTransaction(cmds))
            {
                MessageBox.Show("Phát hành hóa đơn thành công!");
                RefreshData();
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text) || currentMode == FormMode.Add) return;
            string maHD = txtMaHD.Text;

            string q = @"
                SELECT hd.MaHD, hd.NgayPhatHanh, hd.TongTienTruocThue, hd.ThueVAT, hd.TongTienSauThue,
                       ptt.MaPhieuTT, dvc.MaDonVC, dvc.DiaChiLayHang, dvc.DiaChiGiao, dvc.TenNguoiNhan, dvc.SDTNguoiNhan,
                       kh.TenKH, kh.SDTKH, kh.EmailKH, kh.DiaChiKH, kh.MST, nv.HoTenNV
                FROM HoaDonVanChuyen hd
                INNER JOIN PhieuThanhToanVC ptt ON hd.MaPhieuTT = ptt.MaPhieuTT
                INNER JOIN DonVanChuyen dvc ON ptt.MaDonVC = dvc.MaDonVC
                INNER JOIN KhachHang kh ON hd.MaKH = kh.MaKH
                INNER JOIN NhanVien nv ON hd.MaNV = nv.MaNV
                WHERE hd.MaHD = @M";
            DataTable dtInfo = DatabaseHelper.GetDataTable(q, new SqlParameter[] { new SqlParameter("@M", maHD) });
            if (dtInfo.Rows.Count == 0) return;

            DataRow info = dtInfo.Rows[0];

            string logoPath = System.IO.Path.Combine(Application.StartupPath, "Resources", "logo_hive.png").Replace("\\", "/");
            string html = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Hóa Đơn {maHD}</title>
    <style>
        body {{ font-family: Arial, sans-serif; padding: 30px; color: #333; }}
        .top-header {{ display: flex; align-items: center; border-bottom: 2px solid #0d47a1; padding-bottom: 15px; margin-bottom: 20px; }}
        .logo-container {{ width: 160px; text-align: center; }}
        .logo-container img {{ max-width: 140px; max-height: 90px; object-fit: contain; }}
        .company-info {{ flex: 1; padding-left: 20px; font-size: 13px; line-height: 1.6; }}
        .company-name {{ font-size: 16px; font-weight: bold; margin: 0 0 5px 0; text-transform: uppercase; color: #0d47a1; }}
        .info-row {{ display: flex; }}
        .info-label {{ width: 140px; font-style: italic; color: #555; }}
        .info-value {{ font-weight: bold; flex: 1; }}
        
        .invoice-title {{ text-align: center; margin: 20px 0 30px 0; }}
        .invoice-title h1 {{ color: #d32f2f; margin: 0; font-size: 26px; text-transform: uppercase; }}
        .invoice-title p {{ margin: 5px 0; font-size: 13px; color: #666; }}
        
        .info-box {{ display: flex; justify-content: space-between; margin-bottom: 30px; }}
        .col {{ width: 48%; }}
        h3 {{ border-bottom: 2px solid #0d47a1; padding-bottom: 5px; color: #0d47a1; font-size: 15px; margin-bottom: 10px; }}
        table {{ width: 100%; border-collapse: collapse; margin-bottom: 30px; font-size: 13px; }}
        th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
        th {{ background-color: #f5f5f5; color: #0d47a1; }}
        .totals {{ float: right; width: 300px; }}
        .totals-row {{ display: flex; justify-content: space-between; padding: 5px 0; border-bottom: 1px dashed #eee; font-size: 13px; }}
        .totals-row.bold {{ font-weight: bold; font-size: 15px; color: #d32f2f; border-bottom: none; margin-top: 5px; }}
        .footer {{ margin-top: 60px; display: flex; justify-content: space-between; text-align: center; font-size: 13px; }}
    </style>
</head>
<body>
    <div class='top-header'>
        <div class='logo-container'>
            <img src='file:///{logoPath}' alt='HIVE Logo' onerror=""this.style.display='none'"" />
        </div>
        <div class='company-info'>
            <div class='company-name'>CÔNG TY TNHH THƯƠNG MẠI DỊCH VỤ VẬN TẢI HIVE</div>
            <div class='info-row'><div class='info-label'>Mã số thuế (Tax code):</div><div class='info-value'>0317186018</div></div>
            <div class='info-row'><div class='info-label'>Địa chỉ (Address):</div><div class='info-value'>Tòa nhà Pax Sky, 51 Nguyễn Cư Trinh, Phường Cầu Ông Lãnh,<br/>Thành phố Hồ Chí Minh, Việt Nam</div></div>
            <div class='info-row'><div class='info-label'>Điện thoại (Tel):</div><div class='info-value'>0931 749 550</div></div>
        </div>
    </div>

    <div class='invoice-title'>
        <h1>HÓA ĐƠN VẬN CHUYỂN</h1>
        <p>Mẫu số (Form): <strong>01GTKT0/001</strong> | Mã Hóa Đơn: <strong>{maHD}</strong></p>
        <p>Ngày phát hành: <strong>{Convert.ToDateTime(info["NgayPhatHanh"]):dd/MM/yyyy}</strong> | Mã Phiếu TT: <strong>{info["MaPhieuTT"]}</strong> | Mã Đơn VC: <strong>{info["MaDonVC"]}</strong></p>
    </div>

    <div class='info-box'>
        <div class='col'>
            <h3>Thông tin Khách hàng</h3>
            <p><strong>Tên:</strong> {info["TenKH"]}</p>
            <p><strong>SĐT:</strong> {info["SDTKH"]} | <strong>Email:</strong> {info["EmailKH"]}</p>
            <p><strong>Địa chỉ:</strong> {info["DiaChiKH"]}</p>
            <p><strong>MST:</strong> {info["MST"]}</p>
        </div>
        <div class='col'>
            <h3>Thông tin Vận chuyển</h3>
            <p><strong>Người nhận:</strong> {info["TenNguoiNhan"]}</p>
            <p><strong>SĐT nhận:</strong> {info["SDTNguoiNhan"]}</p>
            <p><strong>Nơi lấy hàng:</strong> {info["DiaChiLayHang"]}</p>
            <p><strong>Nơi giao:</strong> {info["DiaChiGiao"]}</p>
        </div>
    </div>

    <h3>Chi tiết Phí</h3>
    <table>
        <thead>
            <tr>
                <th>STT</th>
                <th>Loại phí</th>
                <th>Số lượng</th>
                <th>Đơn giá</th>
                <th>Thành tiền</th>
            </tr>
        </thead>
        <tbody>";
            
            string qCT = @"SELECT lp.TenLoaiPhi, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
                           FROM ChiTietHDVC ct INNER JOIN LoaiPhiVanChuyen lp ON ct.MaLoaiPhi = lp.MaLoaiPhi
                           WHERE ct.MaHD = @M";
            DataTable dtChiTietDB = DatabaseHelper.GetDataTable(qCT, new SqlParameter[] { new SqlParameter("@M", maHD) });
            int stt = 1;
            foreach (DataRow r in dtChiTietDB.Rows)
            {
                html += $@"
            <tr>
                <td>{stt++}</td>
                <td>{r["TenLoaiPhi"]}</td>
                <td>{r["SoLuong"]}</td>
                <td>{Convert.ToDecimal(r["DonGia"]):N0} đ</td>
                <td>{Convert.ToDecimal(r["ThanhTien"]):N0} đ</td>
            </tr>";
            }

            html += $@"
        </tbody>
    </table>

    <div class='totals'>
        <div class='totals-row'><span>Tổng trước thuế:</span> <span>{Convert.ToDecimal(info["TongTienTruocThue"]):N0} đ</span></div>
        <div class='totals-row'><span>Thuế VAT:</span> <span>{info["ThueVAT"]}%</span></div>
        <div class='totals-row bold'><span>Tổng thanh toán:</span> <span>{Convert.ToDecimal(info["TongTienSauThue"]):N0} đ</span></div>
    </div>
    <div style='clear:both;'></div>

    <div class='footer'>
        <div>
            <p><strong>Người lập hóa đơn</strong></p>
            <p style='margin-top:50px;'>{info["HoTenNV"]}</p>
        </div>
        <div>
            <p><strong>Khách hàng</strong></p>
            <p style='margin-top:50px;'>(Ký và ghi rõ họ tên)</p>
        </div>
    </div>
</body>
</html>";

            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"HoaDon_{maHD}.pdf");
                
                SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
                converter.Options.PdfPageSize = SelectPdf.PdfPageSize.A4;
                converter.Options.PdfPageOrientation = SelectPdf.PdfPageOrientation.Portrait;
                converter.Options.MarginLeft = 20;
                converter.Options.MarginRight = 20;
                converter.Options.MarginTop = 20;
                converter.Options.MarginBottom = 20;

                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(html);
                doc.Save(path);
                doc.Close();

                MessageBox.Show($"Đã tạo file Hóa đơn PDF thành công tại Desktop:\n{path}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = path, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
