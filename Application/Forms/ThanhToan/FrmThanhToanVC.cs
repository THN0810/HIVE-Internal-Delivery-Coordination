using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.ThanhToan
{
    public partial class FrmThanhToanVC : Form
    {
        private enum FormMode { View, Add, Edit }
        private FormMode currentMode = FormMode.View;
        private DataTable dtThanhToan;

        public FrmThanhToanVC()
        {
            InitializeComponent();
        }

        private void FrmThanhToanVC_Load(object sender, EventArgs e)
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
            
            UIHelper.StyleDataGridView(dgvThanhToan);
            UIHelper.StyleDataGridView(dgvDonChoThanhToan);
            UIHelper.StyleGroupBox(grpThongTin);
            
            UIHelper.StyleButtonGreen(btnThem);
            UIHelper.StyleButtonPrimary(btnSua);
            UIHelper.StyleButtonOrange(btnLuu);
            UIHelper.StyleButtonGray(btnHuy);
            UIHelper.StyleButtonOutline(btnLamMoi);
            
            UIHelper.StyleButtonPrimary(btnTimKiem);
            UIHelper.StyleButtonOutline(btnBoLoc);
        }

        private void SetupGridColumns()
        {
            // dgvDonChoThanhToan
            dgvDonChoThanhToan.AutoGenerateColumns = false;
            dgvDonChoThanhToan.Columns.Clear();
            dgvDonChoThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaDonVC", HeaderText = "Mã đơn", DataPropertyName = "MaDonVC", Width = 100 });
            dgvDonChoThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKH", HeaderText = "Khách hàng", DataPropertyName = "TenKH", Width = 250 });
            dgvDonChoThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "PhiVC", HeaderText = "Phí VC (VNĐ)", DataPropertyName = "PhiVC", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvDonChoThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiDon", HeaderText = "Trạng thái", DataPropertyName = "TrangThaiDon", Width = 150 });
            dgvDonChoThanhToan.CellClick += new DataGridViewCellEventHandler(this.dgvDonChoThanhToan_CellClick);

            // dgvThanhToan
            dgvThanhToan.AutoGenerateColumns = false;
            dgvThanhToan.Columns.Clear();
            dgvThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaPhieuTT", HeaderText = "Mã Phiếu", DataPropertyName = "MaPhieuTT", Width = 100 });
            dgvThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaDonVC", HeaderText = "Đơn VC", DataPropertyName = "MaDonVC", Width = 90 });
            dgvThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKH", HeaderText = "Khách hàng", DataPropertyName = "TenKH", Width = 160 });
            dgvThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoTienTT", HeaderText = "Số tiền (VNĐ)", DataPropertyName = "SoTienTT", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "HinhThucTT", HeaderText = "Hình thức", DataPropertyName = "HinhThucTT", Width = 120 });
            dgvThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayTT", HeaderText = "Ngày thanh toán", DataPropertyName = "NgayTT", Width = 140 });
            dgvThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiTT", HeaderText = "Trạng thái", DataPropertyName = "TrangThaiTT", Width = 130 });
            dgvThanhToan.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaGiaoDich", HeaderText = "Mã giao dịch", DataPropertyName = "MaGiaoDich", Width = 150 });
        }

        private void LoadComboBoxes()
        {
            cmbDonVC.DataSource = DatabaseHelper.GetDataTable("SELECT MaDonVC FROM DonVanChuyen ORDER BY MaDonVC DESC");
            cmbDonVC.DisplayMember = "MaDonVC"; cmbDonVC.ValueMember = "MaDonVC";
            
            cmbKhachHang.DataSource = DatabaseHelper.GetDataTable("SELECT MaKH, TenKH FROM KhachHang ORDER BY TenKH");
            cmbKhachHang.DisplayMember = "TenKH"; cmbKhachHang.ValueMember = "MaKH";

            cmbHinhThuc.Items.Clear();
            cmbHinhThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ tín dụng" });
            cmbHinhThuc.SelectedIndex = 0;

            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.AddRange(new object[] { "Chưa thanh toán", "Đã thanh toán", "Thanh toán một phần" });
            cmbTrangThai.SelectedIndex = 0;

            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Chưa thanh toán", "Đã thanh toán", "Thanh toán một phần" });
            cboLocTrangThai.SelectedIndex = 0;
        }

        private void LoadData()
        {
            string query = @"
                SELECT ptt.MaPhieuTT, ptt.MaDonVC, kh.TenKH, ptt.SoTienTT, ptt.HinhThucTT,
                       ptt.NgayTT, ptt.TrangThaiTT, ptt.MaGiaoDich, ptt.MaKH
                FROM PhieuThanhToanVC ptt
                INNER JOIN KhachHang kh ON ptt.MaKH = kh.MaKH
                ORDER BY ptt.NgayTT DESC";
            dtThanhToan = DatabaseHelper.GetDataTable(query);
        }

        private void LoadDonChoThanhToan()
        {
            string sql = @"
                SELECT dvc.MaDonVC, kh.TenKH, dvc.PhiVC, dvc.TrangThaiDon
                FROM DonVanChuyen dvc
                INNER JOIN KhachHang kh ON dvc.MaKH = kh.MaKH
                WHERE dvc.TrangThaiDon = N'Hoàn thành'
                  AND NOT EXISTS (
                      SELECT 1 FROM PhieuThanhToanVC ptt
                      WHERE ptt.MaDonVC = dvc.MaDonVC
                  )
                ORDER BY dvc.MaDonVC DESC";
            dgvDonChoThanhToan.DataSource = DatabaseHelper.GetDataTable(sql);
        }

        private void ClearForm()
        {
            txtMaPhieuTT.Clear(); 
            txtSoTien.Clear(); 
            txtMaGiaoDich.Clear(); 
            
            if (cmbHinhThuc.Items.Count > 0) cmbHinhThuc.SelectedIndex = 0;
            if (cmbTrangThai.Items.Count > 0) cmbTrangThai.SelectedIndex = 0;
            if (cmbDonVC.Items.Count > 0) cmbDonVC.SelectedIndex = 0;
            if (cmbKhachHang.Items.Count > 0) cmbKhachHang.SelectedIndex = 0;
            dtpNgayTT.Value = DateTime.Now;
        }

        private void SetFormMode(FormMode mode)
        {
            currentMode = mode;
            bool isEditing = (mode == FormMode.Add || mode == FormMode.Edit);

            System.Drawing.Color editBg = System.Drawing.Color.White;
            System.Drawing.Color viewBg = System.Drawing.Color.White;

            txtSoTien.ReadOnly = !isEditing; txtSoTien.BackColor = editBg;
            txtMaGiaoDich.ReadOnly = !isEditing; txtMaGiaoDich.BackColor = editBg;
            
            cmbDonVC.Enabled = false;
            cmbKhachHang.Enabled = false;
            cmbHinhThuc.Enabled = isEditing;
            cmbTrangThai.Enabled = isEditing;
            dtpNgayTT.Enabled = isEditing;

            txtMaPhieuTT.ReadOnly = true; txtMaPhieuTT.BackColor = viewBg;

            bool isQuanLy = SessionManager.TenVT == "Quản lý";

            // Nút Thêm, Sửa bật khi View (giả sử có quyền)
            btnThem.Enabled = !isEditing && !isQuanLy;
            btnSua.Enabled = !isEditing && !string.IsNullOrEmpty(txtMaPhieuTT.Text) && !isQuanLy;
            
            // Nút Lưu, Hủy bật khi Edit
            btnLuu.Enabled = isEditing && !isQuanLy;
            btnHuy.Enabled = isEditing;
            
            // Làm mới luôn bật khi View
            btnLamMoi.Enabled = !isEditing;
            
            // Filter panel chỉ bật khi View
            pnlFilter.Enabled = !isEditing;
        }

        private void RefreshData()
        {
            LoadData();
            LoadDonChoThanhToan();
            ApplyFilter();
            ClearForm();
            SetFormMode(FormMode.View);
        }

        // ══════════════════════════════════════════════════════
        // TÌM KIẾM VÀ LỌC
        // ══════════════════════════════════════════════════════
        private void ApplyFilter()
        {
            if (dtThanhToan == null) return;

            string keyword = txtTimKiem.Text.Trim().ToLower();
            string trangThai = cboLocTrangThai.Text;

            DataView dv = dtThanhToan.DefaultView;
            string filter = "1=1";

            if (trangThai != "Tất cả")
            {
                filter += string.Format(" AND TrangThaiTT = '{0}'", trangThai.Replace("'", "''"));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += string.Format(" AND (MaPhieuTT LIKE '%{0}%' OR MaDonVC LIKE '%{0}%' OR TenKH LIKE '%{0}%' OR MaGiaoDich LIKE '%{0}%')", keyword.Replace("'", "''"));
            }

            dv.RowFilter = filter;
            dgvThanhToan.DataSource = dv;
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            if (cboLocTrangThai.Items.Count > 0) cboLocTrangThai.SelectedIndex = 0;
            RefreshData();
        }

        // ══════════════════════════════════════════════════════
        // THAO TÁC DỮ LIỆU
        // ══════════════════════════════════════════════════════
        private void dgvThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentMode == FormMode.View)
            {
                DataRowView drv = dgvThanhToan.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv == null) return;

                txtMaPhieuTT.Text = drv["MaPhieuTT"].ToString();
                txtSoTien.Text = drv["SoTienTT"].ToString();
                txtMaGiaoDich.Text = drv["MaGiaoDich"] != DBNull.Value ? drv["MaGiaoDich"].ToString() : "";
                cmbHinhThuc.Text = drv["HinhThucTT"].ToString();
                cmbTrangThai.Text = drv["TrangThaiTT"].ToString();
                
                if (drv["NgayTT"] != DBNull.Value) dtpNgayTT.Value = Convert.ToDateTime(drv["NgayTT"]);
                
                string maDon = drv["MaDonVC"] != DBNull.Value ? drv["MaDonVC"].ToString() : "";
                if (!string.IsNullOrEmpty(maDon)) cmbDonVC.Text = maDon;
                
                string maKH = drv["MaKH"] != DBNull.Value ? drv["MaKH"].ToString() : "";
                if (!string.IsNullOrEmpty(maKH)) cmbKhachHang.SelectedValue = maKH;

                SetFormMode(FormMode.View);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMaPhieuTT.Text = IdGenerator.GetNextId("PhieuThanhToanVC", "MaPhieuTT", "PTT");
            SetFormMode(FormMode.Add);
            txtSoTien.Focus();
            MessageBox.Show("Vui lòng chọn một đơn từ 'Danh sách đơn chờ thanh toán' ở phía trên.", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvDonChoThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentMode == FormMode.Add)
            {
                DataRowView drv = dgvDonChoThanhToan.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv == null) return;
                
                string maDon = drv["MaDonVC"].ToString();
                string phiVC = drv["PhiVC"] != DBNull.Value ? drv["PhiVC"].ToString() : "0";
                
                cmbDonVC.SelectedValue = maDon;
                txtSoTien.Text = phiVC;
            }
        }

        private void cmbDonVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMode == FormMode.Add && cmbDonVC.SelectedValue != null && cmbDonVC.SelectedValue is string maDonVC)
            {
                DataTable dt = DatabaseHelper.GetDataTable("SELECT MaKH FROM DonVanChuyen WHERE MaDonVC = @M", new SqlParameter[] { new SqlParameter("@M", maDonVC) });
                if (dt.Rows.Count > 0)
                {
                    cmbKhachHang.SelectedValue = dt.Rows[0]["MaKH"].ToString();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieuTT.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu cần sửa!", "Thông báo");
                return;
            }
            
            string maPhieu = txtMaPhieuTT.Text.Trim();
            DataTable dtCheck = DatabaseHelper.GetDataTable("SELECT MaHD FROM HoaDonVanChuyen WHERE MaPhieuTT = @M AND TrangThaiHD != N'Đã hủy'", new SqlParameter[] { new SqlParameter("@M", maPhieu) });
            if (dtCheck.Rows.Count > 0)
            {
                MessageBox.Show("Phiếu thanh toán này đang có hóa đơn (" + dtCheck.Rows[0]["MaHD"].ToString() + ") ở trạng thái hoạt động, không thể sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetFormMode(FormMode.Edit);
            txtSoTien.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtSoTien.Text, out decimal soTien) || soTien <= 0)
            { 
                MessageBox.Show("Số tiền phải là số dương!", "Thông báo"); return; 
            }
            
            if (cmbHinhThuc.Text == "Chuyển khoản" && string.IsNullOrWhiteSpace(txtMaGiaoDich.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã giao dịch khi thanh toán bằng Chuyển khoản!", "Thông báo"); return;
            }

            string query = currentMode == FormMode.Add
                ? @"INSERT INTO PhieuThanhToanVC (MaPhieuTT, SoTienTT, HinhThucTT, TrangThaiTT, MaGiaoDich, MaDonVC, MaNV, MaKH, NgayTT)
                    VALUES (@Ma, @SoTien, @HinhThuc, @TrangThai, @MaGD, @DonVC, @NV, @KH, @NgayTT)"
                : @"UPDATE PhieuThanhToanVC SET SoTienTT=@SoTien, HinhThucTT=@HinhThuc, TrangThaiTT=@TrangThai, MaGiaoDich=@MaGD, MaDonVC=@DonVC, MaKH=@KH, NgayTT=@NgayTT WHERE MaPhieuTT=@Ma";
            
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Ma", txtMaPhieuTT.Text.Trim()), 
                    new SqlParameter("@SoTien", soTien),
                    new SqlParameter("@HinhThuc", cmbHinhThuc.Text), 
                    new SqlParameter("@TrangThai", cmbTrangThai.Text),
                    new SqlParameter("@MaGD", string.IsNullOrEmpty(txtMaGiaoDich.Text) ? (object)DBNull.Value : txtMaGiaoDich.Text.Trim()),
                    new SqlParameter("@DonVC", cmbDonVC.SelectedValue ?? (object)DBNull.Value), 
                    new SqlParameter("@NV", SessionManager.MaNV),
                    new SqlParameter("@KH", cmbKhachHang.SelectedValue ?? (object)DBNull.Value),
                    new SqlParameter("@NgayTT", dtpNgayTT.Value)
                };

                DatabaseHelper.ExecuteNonQuery(query, param);
                MessageBox.Show("Lưu thành công!", "Thông báo");
                RefreshData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
