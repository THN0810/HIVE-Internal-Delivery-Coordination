using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.DonVanChuyen
{
    public partial class FrmDonVanChuyen : Form
    {
        // ── Chế độ form ──────────────────────────────────────
        private enum FormMode { View, Add, Edit }
        private FormMode currentMode = FormMode.View;

        // ── DataTable chi tiết hàng hóa (in-memory) ─────────
        private DataTable dtChiTiet;

        // ══════════════════════════════════════════════════════
        // CONSTRUCTOR & LOAD
        // ══════════════════════════════════════════════════════
        public FrmDonVanChuyen() { InitializeComponent(); }

        private void FrmDonVanChuyen_Load(object sender, EventArgs e)
        {
            ApplyStyling();
            ApplyPermissions();
            SetupGridColumns();
            InitChiTietDataTable();
            LoadKhachHang();
            LoadLoaiHangHoa();
            LoadComboTrangThai();
            LoadLocTrangThai();
            LoadDonVanChuyen();
            ClearForm();
            SetFormMode(FormMode.View);

            // Cấu hình lại các thuộc tính SplitContainer ở Runtime để tránh lỗi ở Designer
            splitMain.Panel1MinSize = 120;
            splitMain.Panel2MinSize = 360;
            if (splitMain.Height > 400)
                splitMain.SplitterDistance = 250;

            splitBottom.Panel1MinSize = 460;
            splitBottom.Panel2MinSize = 380;
            if (splitBottom.Width > 800)
                splitBottom.SplitterDistance = 600;
        }

        // ══════════════════════════════════════════════════════
        // STYLING & PERMISSIONS
        // ══════════════════════════════════════════════════════
        private void ApplyStyling()
        {
            this.BackColor = UIHelper.BgMain;
            UIHelper.StyleDataGridView(dgvDonVC);
            UIHelper.StyleDataGridView(dgvChiTiet);
            UIHelper.StyleGroupBox(grpThongTin);
            UIHelper.StyleGroupBox(grpChiTiet);
            lblTitle.ForeColor = UIHelper.Navy;

            UIHelper.StyleButtonGreen(btnThem);
            UIHelper.StyleButtonPrimary(btnSua);
            UIHelper.StyleButtonOrange(btnLuu);
            UIHelper.StyleButtonGray(btnHuy);
            UIHelper.StyleButtonPrimary(btnLamMoi);
            UIHelper.StyleButtonPrimary(btnChuyenDieuPhoi);
            UIHelper.StyleButtonDanger(btnHuyDon);
            UIHelper.StyleButtonPrimary(btnTimKiem);
            UIHelper.StyleButtonOutline(btnBoLoc);

            UIHelper.StyleButtonGreen(btnThemHangHoa);
            UIHelper.StyleButtonPrimary(btnSuaHangHoa);
            UIHelper.StyleButtonDanger(btnXoaHangHoa);
            UIHelper.StyleButtonOutline(btnLamMoiHangHoa);

            UIHelper.StyleButtonOutline(btnXemChiTiet);
        }

        private void ApplyPermissions()
        {
            btnThem.Enabled = SessionManager.CoQuyen("Q037");
            btnSua.Enabled = SessionManager.CoQuyen("Q038");
            btnHuyDon.Enabled = SessionManager.CoQuyen("Q039");
        }

        // ══════════════════════════════════════════════════════
        // SETUP GRID COLUMNS
        // ══════════════════════════════════════════════════════
        private void SetupGridColumns()
        {
            // ── dgvDonVC ─────────────────────────────────────
            dgvDonVC.AutoGenerateColumns = false;
            dgvDonVC.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvDonVC.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvDonVC.RowTemplate.Height = 30;
            dgvDonVC.ColumnHeadersHeight = 35;
            dgvDonVC.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvDonVC.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvDonVC.Columns.Clear();

            var colMaDon = new DataGridViewTextBoxColumn
            { Name = "MaDonVC", HeaderText = "Mã đơn", DataPropertyName = "MaDonVC" };
            colMaDon.FillWeight = 8;
            dgvDonVC.Columns.Add(colMaDon);

            var colKH = new DataGridViewTextBoxColumn
            { Name = "TenKH", HeaderText = "Khách hàng", DataPropertyName = "TenKH" };
            colKH.FillWeight = 18;
            dgvDonVC.Columns.Add(colKH);

            var colNguoiNhan = new DataGridViewTextBoxColumn
            { Name = "TenNguoiNhan", HeaderText = "Người nhận", DataPropertyName = "TenNguoiNhan" };
            colNguoiNhan.FillWeight = 14;
            dgvDonVC.Columns.Add(colNguoiNhan);

            var colDCGiao = new DataGridViewTextBoxColumn
            { Name = "DiaChiGiao", HeaderText = "Địa chỉ giao", DataPropertyName = "DiaChiGiao" };
            colDCGiao.FillWeight = 26;
            dgvDonVC.Columns.Add(colDCGiao);

            var colPhiVC = new DataGridViewTextBoxColumn
            { Name = "PhiVC", HeaderText = "Phí VC", DataPropertyName = "PhiVC" };
            colPhiVC.FillWeight = 10;
            colPhiVC.DefaultCellStyle.Format = "N0";
            colPhiVC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDonVC.Columns.Add(colPhiVC);

            var colTrangThai = new DataGridViewTextBoxColumn
            { Name = "TrangThaiDon", HeaderText = "Trạng thái", DataPropertyName = "TrangThaiDon" };
            colTrangThai.FillWeight = 13;
            dgvDonVC.Columns.Add(colTrangThai);

            var colNgayTao = new DataGridViewTextBoxColumn
            { Name = "NgayTao", HeaderText = "Ngày tạo", DataPropertyName = "NgayTao" };
            colNgayTao.FillWeight = 13;
            colNgayTao.DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
            dgvDonVC.Columns.Add(colNgayTao);

            // Bật tooltip cho ô có nội dung dài
            dgvDonVC.ShowCellToolTips = true;

            // ── dgvChiTiet ───────────────────────────────────
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvChiTiet.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvChiTiet.RowTemplate.Height = 30;
            dgvChiTiet.ColumnHeadersHeight = 35;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvChiTiet.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvChiTiet.Columns.Clear();

            var colMaLoai = new DataGridViewTextBoxColumn
            { Name = "MaLoaiHH", HeaderText = "Mã loại", DataPropertyName = "MaLoaiHH" };
            colMaLoai.Width = 80;
            dgvChiTiet.Columns.Add(colMaLoai);

            var colTenLoai = new DataGridViewTextBoxColumn
            { Name = "TenLoaiHH", HeaderText = "Tên loại hàng hóa", DataPropertyName = "TenLoaiHH" };
            colTenLoai.Width = 150;
            dgvChiTiet.Columns.Add(colTenLoai);

            var colKL = new DataGridViewTextBoxColumn
            { Name = "KhoiLuong", HeaderText = "Khối lượng", DataPropertyName = "KhoiLuong" };
            colKL.Width = 100;
            colKL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTiet.Columns.Add(colKL);

            var colSK = new DataGridViewTextBoxColumn
            { Name = "SoKien", HeaderText = "Số kiện", DataPropertyName = "SoKien" };
            colSK.Width = 80;
            colSK.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTiet.Columns.Add(colSK);

            var colDVT = new DataGridViewTextBoxColumn
            { Name = "DonViTinh", HeaderText = "Đơn vị tính", DataPropertyName = "DonViTinh" };
            colDVT.Width = 100;
            dgvChiTiet.Columns.Add(colDVT);

            var colMoTa = new DataGridViewTextBoxColumn
            { Name = "MoTaHH", HeaderText = "Mô tả", DataPropertyName = "MoTaHH" };
            colMoTa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvChiTiet.Columns.Add(colMoTa);

            dgvChiTiet.ShowCellToolTips = true;
        }

        private void InitChiTietDataTable()
        {
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("MaLoaiHH", typeof(string));
            dtChiTiet.Columns.Add("TenLoaiHH", typeof(string));
            dtChiTiet.Columns.Add("KhoiLuong", typeof(decimal));
            dtChiTiet.Columns.Add("SoKien", typeof(int));
            dtChiTiet.Columns.Add("DonViTinh", typeof(string));
            dtChiTiet.Columns.Add("MoTaHH", typeof(string));
            dgvChiTiet.DataSource = dtChiTiet;
        }

        // ══════════════════════════════════════════════════════
        // LOAD DATA
        // ══════════════════════════════════════════════════════
        private void LoadKhachHang()
        {
            DataTable dt = DatabaseHelper.GetDataTable(
                "SELECT MaKH, TenKH FROM KhachHang WHERE TrangThaiSuDung = N'Đang sử dụng' ORDER BY TenKH");
            cboKhachHang.DataSource = dt;
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
        }

        private void LoadLoaiHangHoa()
        {
            DataTable dt = DatabaseHelper.GetDataTable(
                "SELECT MaLoaiHH, TenLoaiHH FROM LoaiHangHoa WHERE TenLoaiHH != N'Hàng hóa test' ORDER BY TenLoaiHH");
            cboLoaiHangHoa.DataSource = dt;
            cboLoaiHangHoa.DisplayMember = "TenLoaiHH";
            cboLoaiHangHoa.ValueMember = "MaLoaiHH";
        }

        private void LoadComboTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] {
                "Mới tạo", "Đang điều phối", "Đang vận chuyển", "Hoàn thành", "Đã hủy" });
            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadLocTrangThai()
        {
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new object[] {
                "Tất cả", "Mới tạo", "Đang điều phối", "Đang vận chuyển", "Hoàn thành", "Đã hủy" });
            cboLocTrangThai.SelectedIndex = 0;
        }

        private void LoadDonVanChuyen()
        {
            string keyword = txtTimKiem.Text.Trim();
            string trangThai = cboLocTrangThai.SelectedItem?.ToString() ?? "Tất cả";

            string query = @"
                SELECT dvc.MaDonVC, kh.TenKH, dvc.TenNguoiNhan, dvc.SDTNguoiNhan,
                       dvc.DiaChiLayHang, dvc.DiaChiGiao, dvc.TGNhanDuKien, dvc.TGGiaoDuKien,
                       dvc.PhiVC, dvc.YeuCauDacBiet, dvc.TrangThaiDon, dvc.NgayTao, dvc.MaKH
                FROM DonVanChuyen dvc
                INNER JOIN KhachHang kh ON dvc.MaKH = kh.MaKH
                WHERE 1=1";

            var parms = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(keyword))
            {
                query += @" AND (dvc.MaDonVC LIKE @kw OR kh.TenKH LIKE @kw 
                           OR dvc.TenNguoiNhan LIKE @kw OR dvc.SDTNguoiNhan LIKE @kw)";
                parms.Add(new SqlParameter("@kw", "%" + keyword + "%"));
            }

            if (trangThai != "Tất cả")
            {
                query += " AND dvc.TrangThaiDon = @tt";
                parms.Add(new SqlParameter("@tt", trangThai));
            }

            query += " ORDER BY dvc.NgayTao DESC";

            dgvDonVC.DataSource = DatabaseHelper.GetDataTable(query, parms.Count > 0 ? parms.ToArray() : null);
        }

        private void LoadChiTietDVC(string maDonVC)
        {
            string query = @"SELECT ct.MaLoaiHH, l.TenLoaiHH, ct.KhoiLuong, ct.SoKien, ct.DonViTinh, ct.MoTaHH
                             FROM ChiTietDVC ct
                             INNER JOIN LoaiHangHoa l ON ct.MaLoaiHH = l.MaLoaiHH
                             WHERE ct.MaDonVC = @ma";
            DataTable dt = DatabaseHelper.GetDataTable(query, new SqlParameter[] { new SqlParameter("@ma", maDonVC) });
            dtChiTiet.Rows.Clear();
            foreach (DataRow r in dt.Rows)
            {
                dtChiTiet.Rows.Add(
                    r["MaLoaiHH"], r["TenLoaiHH"], r["KhoiLuong"],
                    r["SoKien"], r["DonViTinh"],
                    r["MoTaHH"] == DBNull.Value ? "" : r["MoTaHH"]);
            }
        }

        // ══════════════════════════════════════════════════════
        // CLEAR & MODE
        // ══════════════════════════════════════════════════════
        private void ClearForm()
        {
            txtMaDonVC.Clear();
            txtTenNguoiNhan.Clear();
            txtSDTNguoiNhan.Clear();
            txtDiaChiLayHang.Clear();
            txtDiaChiGiao.Clear();
            txtPhiVC.Clear();
            txtYeuCauDacBiet.Clear();
            txtNgayTao.Clear();

            if (cboKhachHang.Items.Count > 0) cboKhachHang.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            dtpTGNhanDuKien.Value = DateTime.Now;
            dtpTGGiaoDuKien.Value = DateTime.Now.AddHours(2);

            ClearChiTietInput();
            dtChiTiet.Rows.Clear();
        }

        private void ClearChiTietInput()
        {
            if (cboLoaiHangHoa.Items.Count > 0) cboLoaiHangHoa.SelectedIndex = 0;
            txtKhoiLuong.Clear();
            txtSoKien.Clear();
            txtDonViTinh.Clear();
            txtMoTaHangHoa.Clear();
        }

        private void SetFormMode(FormMode mode)
        {
            currentMode = mode;
            bool isEditing = (mode == FormMode.Add || mode == FormMode.Edit);

            // Dùng ReadOnly + BackColor thay vì Enabled=false để chữ không bị mờ
            System.Drawing.Color editBg = System.Drawing.Color.White;
            System.Drawing.Color viewBg = System.Drawing.Color.White;

            txtTenNguoiNhan.ReadOnly  = !isEditing;  txtTenNguoiNhan.BackColor  = editBg;
            txtSDTNguoiNhan.ReadOnly  = !isEditing;  txtSDTNguoiNhan.BackColor  = editBg;
            txtDiaChiLayHang.ReadOnly = !isEditing;   txtDiaChiLayHang.BackColor = editBg;
            txtDiaChiGiao.ReadOnly    = !isEditing;  txtDiaChiGiao.BackColor    = editBg;
            txtPhiVC.ReadOnly         = !isEditing;  txtPhiVC.BackColor         = editBg;
            txtYeuCauDacBiet.ReadOnly = !isEditing;  txtYeuCauDacBiet.BackColor = editBg;

            // ComboBox khách hàng và DateTimePicker
            cboKhachHang.Enabled      = isEditing;
            dtpTGNhanDuKien.Enabled   = isEditing;
            dtpTGGiaoDuKien.Enabled   = isEditing;

            // Các trường luôn ReadOnly
            txtMaDonVC.ReadOnly  = true;  txtMaDonVC.BackColor  = viewBg;
            txtNgayTao.ReadOnly  = true;  txtNgayTao.BackColor  = viewBg;
            cboTrangThai.Enabled = false;

            // Nút Lưu & Hủy thao tác: chỉ bật khi đang Thêm hoặc Sửa
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;

            // Nút Làm mới: luôn bật trừ khi đang edit
            btnLamMoi.Enabled = !isEditing;

            // Chi tiết hàng hóa — chỉ bật khi đang Thêm hoặc Sửa
            pnlChiTietInput.Enabled = isEditing;
            dgvChiTiet.ReadOnly     = true; // Luôn ReadOnly, thao tác qua nút

            if (isEditing)
            {
                // Đang Thêm/Sửa → tắt hết nút ngoài Lưu/Hủy
                btnThem.Enabled           = false;
                btnSua.Enabled            = false;
                btnChuyenDieuPhoi.Enabled = false;
                btnHuyDon.Enabled         = false;
                btnXemChiTiet.Enabled     = false;
            }
            else
            {
                // Đang View → bật/tắt theo TrangThaiDon
                string trangThai = cboTrangThai.Text;
                bool laMoiTao    = (trangThai == "Mới tạo");
                bool daKetThuc   = (trangThai == "Hoàn thành" || trangThai == "Đã hủy");
                bool daDieuPhoi  = (trangThai == "Đang điều phối" || trangThai == "Đang vận chuyển");
                bool coDonDuocChon = !string.IsNullOrEmpty(txtMaDonVC.Text);

                // Nút Thêm: luôn bật khi View (nếu có quyền)
                btnThem.Enabled = SessionManager.CoQuyen("Q037");

                // Nút Sửa: chỉ bật khi đơn Mới tạo
                btnSua.Enabled = coDonDuocChon && laMoiTao && SessionManager.CoQuyen("Q038");

                // Nút Chuyển điều phối: chỉ bật khi đơn Mới tạo
                btnChuyenDieuPhoi.Enabled = coDonDuocChon && laMoiTao;

                // Nút Hủy đơn: bật khi đơn chưa Hoàn thành và chưa Đã hủy
                btnHuyDon.Enabled = coDonDuocChon && !daKetThuc && SessionManager.CoQuyen("Q039");

                // Nút Xem chi tiết: bật khi có đơn được chọn
                btnXemChiTiet.Enabled = coDonDuocChon;
            }
        }

        private void RefreshData()
        {
            LoadDonVanChuyen();
            ClearForm();
            SetFormMode(FormMode.View);
        }

        // ══════════════════════════════════════════════════════
        // CELL CLICK — Hiển thị chi tiết đơn đã chọn
        // ══════════════════════════════════════════════════════
        private void dgvDonVC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (currentMode != FormMode.View) return; // Không cho chọn khi đang edit

            DataRowView drv = dgvDonVC.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;

            txtMaDonVC.Text = drv["MaDonVC"].ToString();
            txtTenNguoiNhan.Text = drv["TenNguoiNhan"].ToString();
            txtSDTNguoiNhan.Text = drv["SDTNguoiNhan"].ToString();
            txtDiaChiLayHang.Text = drv["DiaChiLayHang"].ToString();
            txtDiaChiGiao.Text = drv["DiaChiGiao"].ToString();
            txtPhiVC.Text = drv["PhiVC"].ToString();
            txtYeuCauDacBiet.Text = drv["YeuCauDacBiet"] == DBNull.Value ? "" : drv["YeuCauDacBiet"].ToString();
            cboTrangThai.Text = drv["TrangThaiDon"].ToString();

            if (drv["NgayTao"] != DBNull.Value)
                txtNgayTao.Text = Convert.ToDateTime(drv["NgayTao"]).ToString("dd/MM/yyyy hh:mm tt");

            if (drv["TGNhanDuKien"] != DBNull.Value)
                dtpTGNhanDuKien.Value = Convert.ToDateTime(drv["TGNhanDuKien"]);
            if (drv["TGGiaoDuKien"] != DBNull.Value)
                dtpTGGiaoDuKien.Value = Convert.ToDateTime(drv["TGGiaoDuKien"]);

            // Set khách hàng
            string maKH = drv["MaKH"].ToString();
            cboKhachHang.SelectedValue = maKH;

            // Load chi tiết hàng hóa
            LoadChiTietDVC(txtMaDonVC.Text);

            SetFormMode(FormMode.View);
        }

        // ══════════════════════════════════════════════════════
        // CELL DOUBLE CLICK — Mở form chi tiết
        // ══════════════════════════════════════════════════════
        private void dgvDonVC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (currentMode != FormMode.View) return;

            DataRowView drv = dgvDonVC.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;

            string maDon = drv["MaDonVC"].ToString();
            if (!string.IsNullOrEmpty(maDon))
            {
                var frm = new FrmChiTietDonVanChuyen(maDon);
                frm.ShowDialog();
            }
        }

        // ══════════════════════════════════════════════════════
        // NÚT XEM CHI TIẾT
        // ══════════════════════════════════════════════════════
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDonVC.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn vận chuyển cần xem chi tiết!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new FrmChiTietDonVanChuyen(txtMaDonVC.Text);
            frm.ShowDialog();
        }

        // ══════════════════════════════════════════════════════
        // NÚT THÊM
        // ══════════════════════════════════════════════════════
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMaDonVC.Text = IdGenerator.GetNextId("DonVanChuyen", "MaDonVC", "DVC");
            cboTrangThai.Text = "Mới tạo";
            txtNgayTao.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            SetFormMode(FormMode.Add);
            txtTenNguoiNhan.Focus();
        }

        // ══════════════════════════════════════════════════════
        // NÚT SỬA — Chỉ cho sửa đơn "Mới tạo"
        // ══════════════════════════════════════════════════════
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDonVC.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn vận chuyển cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTrangThai.Text != "Mới tạo")
            {
                MessageBox.Show("Chỉ được sửa đơn có trạng thái 'Mới tạo'!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetFormMode(FormMode.Edit);
        }

        // ══════════════════════════════════════════════════════
        // NÚT LƯU
        // ══════════════════════════════════════════════════════
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string maDVC = txtMaDonVC.Text.Trim();
            var cmds = new List<SqlCommand>();

            if (currentMode == FormMode.Add)
            {
                // INSERT DonVanChuyen
                string qInsert = @"INSERT INTO DonVanChuyen 
                    (MaDonVC, DiaChiLayHang, DiaChiGiao, TenNguoiNhan, SDTNguoiNhan,
                     TGNhanDuKien, TGGiaoDuKien, PhiVC, YeuCauDacBiet, TrangThaiDon, MaKH, MaNV)
                    VALUES 
                    (@MaDonVC, @DiaChiLayHang, @DiaChiGiao, @TenNguoiNhan, @SDTNguoiNhan,
                     @TGNhanDuKien, @TGGiaoDuKien, @PhiVC, @YeuCauDacBiet, N'Mới tạo', @MaKH, @MaNV)";

                var cmdInsert = new SqlCommand(qInsert);
                AddDonVCParams(cmdInsert, maDVC);
                cmdInsert.Parameters.AddWithValue("@MaNV", SessionManager.MaNV);
                cmds.Add(cmdInsert);
            }
            else if (currentMode == FormMode.Edit)
            {
                // UPDATE DonVanChuyen
                string qUpdate = @"UPDATE DonVanChuyen SET 
                    DiaChiLayHang=@DiaChiLayHang, DiaChiGiao=@DiaChiGiao, 
                    TenNguoiNhan=@TenNguoiNhan, SDTNguoiNhan=@SDTNguoiNhan,
                    TGNhanDuKien=@TGNhanDuKien, TGGiaoDuKien=@TGGiaoDuKien,
                    PhiVC=@PhiVC, YeuCauDacBiet=@YeuCauDacBiet, MaKH=@MaKH 
                    WHERE MaDonVC=@MaDonVC";

                var cmdUpdate = new SqlCommand(qUpdate);
                AddDonVCParams(cmdUpdate, maDVC);
                cmds.Add(cmdUpdate);

                // Xóa chi tiết cũ
                var cmdDel = new SqlCommand("DELETE FROM ChiTietDVC WHERE MaDonVC = @MaDonVC");
                cmdDel.Parameters.AddWithValue("@MaDonVC", maDVC);
                cmds.Add(cmdDel);
            }

            // INSERT chi tiết hàng hóa
            foreach (DataRow r in dtChiTiet.Rows)
            {
                var cmdCT = new SqlCommand(
                    @"INSERT INTO ChiTietDVC (MaDonVC, MaLoaiHH, KhoiLuong, SoKien, DonViTinh, MoTaHH) 
                      VALUES (@MaDVC, @MaLHH, @KL, @SK, @DVT, @MoTa)");
                cmdCT.Parameters.AddWithValue("@MaDVC", maDVC);
                cmdCT.Parameters.AddWithValue("@MaLHH", r["MaLoaiHH"]);
                cmdCT.Parameters.AddWithValue("@KL", r["KhoiLuong"]);
                cmdCT.Parameters.AddWithValue("@SK", r["SoKien"]);
                cmdCT.Parameters.AddWithValue("@DVT", r["DonViTinh"]);
                cmdCT.Parameters.AddWithValue("@MoTa",
                    string.IsNullOrEmpty(r["MoTaHH"]?.ToString()) ? (object)DBNull.Value : r["MoTaHH"]);
                cmds.Add(cmdCT);
            }

            if (DatabaseHelper.ExecuteTransaction(cmds))
            {
                MessageBox.Show("Lưu đơn vận chuyển thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                string savedMaDVC = maDVC;
                RefreshData();
                SelectRowByMaDonVC(savedMaDVC);
            }
        }

        /// <summary>
        /// Thêm các tham số chung cho lệnh INSERT/UPDATE DonVanChuyen.
        /// </summary>
        private void AddDonVCParams(SqlCommand cmd, string maDVC)
        {
            cmd.Parameters.AddWithValue("@MaDonVC", maDVC);
            cmd.Parameters.AddWithValue("@DiaChiLayHang", txtDiaChiLayHang.Text.Trim());
            cmd.Parameters.AddWithValue("@DiaChiGiao", txtDiaChiGiao.Text.Trim());
            cmd.Parameters.AddWithValue("@TenNguoiNhan", txtTenNguoiNhan.Text.Trim());
            cmd.Parameters.AddWithValue("@SDTNguoiNhan", txtSDTNguoiNhan.Text.Trim());
            cmd.Parameters.AddWithValue("@TGNhanDuKien", dtpTGNhanDuKien.Value);
            cmd.Parameters.AddWithValue("@TGGiaoDuKien", dtpTGGiaoDuKien.Value);
            cmd.Parameters.AddWithValue("@PhiVC", decimal.Parse(txtPhiVC.Text.Trim()));
            cmd.Parameters.AddWithValue("@YeuCauDacBiet",
                string.IsNullOrEmpty(txtYeuCauDacBiet.Text.Trim())
                    ? (object)DBNull.Value : txtYeuCauDacBiet.Text.Trim());
            cmd.Parameters.AddWithValue("@MaKH", cboKhachHang.SelectedValue);
        }

        // ══════════════════════════════════════════════════════
        // NÚT CHUYỂN ĐIỀU PHỐI + GHI LỊCH SỬ
        // ══════════════════════════════════════════════════════
        private void btnChuyenDieuPhoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDonVC.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn vận chuyển!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTrangThai.Text != "Mới tạo")
            {
                MessageBox.Show("Chỉ có thể chuyển điều phối đơn có trạng thái 'Mới tạo'!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Chuyển sang tiến hành điều phối đi?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                string maDVC = txtMaDonVC.Text.Trim();
                var cmds = new List<SqlCommand>();

                // 1. Cập nhật trạng thái đơn
                var cmdUpdate = new SqlCommand(
                    "UPDATE DonVanChuyen SET TrangThaiDon = N'Đang điều phối' WHERE MaDonVC = @MaDonVC");
                cmdUpdate.Parameters.AddWithValue("@MaDonVC", maDVC);
                cmds.Add(cmdUpdate);

                // 2. Ghi lịch sử trạng thái
                var cmdLS = CreateLichSuCommand(maDVC, "Mới tạo", "Đang điều phối");
                cmds.Add(cmdLS);

                if (DatabaseHelper.ExecuteTransaction(cmds))
                {
                    MessageBox.Show("Đã chuyển điều phối thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════
        // NÚT HỦY ĐƠN + GHI LỊCH SỬ + HỦY LỆNH ĐP LIÊN QUAN
        // ══════════════════════════════════════════════════════
        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDonVC.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn vận chuyển!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string trangThaiHienTai = cboTrangThai.Text;

            // Không cho hủy đơn Hoàn thành hoặc Đã hủy
            if (trangThaiHienTai == "Hoàn thành" || trangThaiHienTai == "Đã hủy")
            {
                MessageBox.Show("Không thể hủy đơn có trạng thái '" + trangThaiHienTai + "'!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn hủy đơn này?", "Xác nhận hủy đơn",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                string maDVC = txtMaDonVC.Text.Trim();
                var cmds = new List<SqlCommand>();

                // 1. Cập nhật trạng thái đơn → Đã hủy
                var cmdUpdate = new SqlCommand(
                    "UPDATE DonVanChuyen SET TrangThaiDon = N'Đã hủy' WHERE MaDonVC = @MaDonVC");
                cmdUpdate.Parameters.AddWithValue("@MaDonVC", maDVC);
                cmds.Add(cmdUpdate);

                // 2. Ghi lịch sử trạng thái
                var cmdLS = CreateLichSuCommand(maDVC, trangThaiHienTai, "Đã hủy");
                cmds.Add(cmdLS);

                // 3. Hủy các lệnh điều phối chưa hoàn thành liên quan đến đơn này
                var cmdHuyLDP = new SqlCommand(
                    @"UPDATE LenhDieuPhoi SET TrangThaiLenh = N'Đã hủy' 
                      WHERE MaDonVC = @MaDonVC 
                      AND TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')");
                cmdHuyLDP.Parameters.AddWithValue("@MaDonVC", maDVC);
                cmds.Add(cmdHuyLDP);

                if (DatabaseHelper.ExecuteTransaction(cmds))
                {
                    MessageBox.Show("Đã hủy đơn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tạo SqlCommand ghi lịch sử trạng thái đơn vào bảng LichSuTrangThaiDon.
        /// </summary>
        private SqlCommand CreateLichSuCommand(string maDonVC, string trangThaiCu, string trangThaiMoi)
        {
            string maLS = IdGenerator.GetNextId("LichSuTrangThaiDon", "MaLichSu", "LS");
            var cmd = new SqlCommand(
                @"INSERT INTO LichSuTrangThaiDon (MaLichSu, TrangThaiCu, TrangThaiMoi, MaDonVC, MaNV)
                  VALUES (@MaLS, @TTCu, @TTMoi, @MaDVC, @MaNV)");
            cmd.Parameters.AddWithValue("@MaLS", maLS);
            cmd.Parameters.AddWithValue("@TTCu", trangThaiCu);
            cmd.Parameters.AddWithValue("@TTMoi", trangThaiMoi);
            cmd.Parameters.AddWithValue("@MaDVC", maDonVC);
            cmd.Parameters.AddWithValue("@MaNV", SessionManager.MaNV);
            return cmd;
        }

        // ══════════════════════════════════════════════════════
        // NÚT HỦY (thao tác nhập liệu)
        // ══════════════════════════════════════════════════════
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearForm();
            SetFormMode(FormMode.View);
        }

        // ══════════════════════════════════════════════════════
        // NÚT LÀM MỚI
        // ══════════════════════════════════════════════════════
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocTrangThai.SelectedIndex = 0; // "Tất cả"
            LoadKhachHang();
            LoadLoaiHangHoa();
            RefreshData();
        }

        // ══════════════════════════════════════════════════════
        // TÌM KIẾM & LỌC
        // ══════════════════════════════════════════════════════
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDonVanChuyen();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocTrangThai.SelectedIndex = 0;
            LoadDonVanChuyen();
        }

        // ══════════════════════════════════════════════════════
        // CHI TIẾT HÀNG HÓA — THÊM
        // ══════════════════════════════════════════════════════
        private void btnThemHangHoa_Click(object sender, EventArgs e)
        {
            if (cboLoaiHangHoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại hàng hóa!", "Thông báo"); return;
            }

            if (!decimal.TryParse(txtKhoiLuong.Text, out decimal kl) || kl <= 0)
            {
                MessageBox.Show("Khối lượng phải là số lớn hơn 0!", "Thông báo"); return;
            }

            if (!int.TryParse(txtSoKien.Text, out int sk) || sk <= 0)
            {
                MessageBox.Show("Số kiện phải là số nguyên lớn hơn 0!", "Thông báo"); return;
            }

            string dvt = txtDonViTinh.Text.Trim();
            if (string.IsNullOrEmpty(dvt))
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính!", "Thông báo"); return;
            }

            string maLHH = cboLoaiHangHoa.SelectedValue.ToString();
            string tenLHH = cboLoaiHangHoa.Text;

            // Kiểm tra trùng
            foreach (DataRow r in dtChiTiet.Rows)
            {
                if (r["MaLoaiHH"].ToString() == maLHH)
                {
                    MessageBox.Show("Loại hàng hóa này đã có trong danh sách! Hãy dùng nút Sửa để thay đổi.",
                        "Thông báo"); return;
                }
            }

            dtChiTiet.Rows.Add(maLHH, tenLHH, kl, sk, dvt, txtMoTaHangHoa.Text.Trim());
            ClearChiTietInput();
        }

        // ══════════════════════════════════════════════════════
        // CHI TIẾT HÀNG HÓA — CELL CLICK
        // ══════════════════════════════════════════════════════
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRowView drv = dgvChiTiet.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;
            
            cboLoaiHangHoa.SelectedValue = drv["MaLoaiHH"].ToString();
            txtKhoiLuong.Text = drv["KhoiLuong"].ToString();
            txtSoKien.Text = drv["SoKien"].ToString();
            txtDonViTinh.Text = drv["DonViTinh"].ToString();
            txtMoTaHangHoa.Text = drv["MoTaHH"] == DBNull.Value ? "" : drv["MoTaHH"].ToString();
        }

        // ══════════════════════════════════════════════════════
        // CHI TIẾT HÀNG HÓA — SỬA
        // ══════════════════════════════════════════════════════
        private void btnSuaHangHoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng chi tiết cần sửa!", "Thông báo"); return;
            }

            if (!decimal.TryParse(txtKhoiLuong.Text, out decimal kl) || kl <= 0)
            {
                MessageBox.Show("Khối lượng phải là số lớn hơn 0!", "Thông báo"); return;
            }

            if (!int.TryParse(txtSoKien.Text, out int sk) || sk <= 0)
            {
                MessageBox.Show("Số kiện phải là số nguyên lớn hơn 0!", "Thông báo"); return;
            }

            string dvt = txtDonViTinh.Text.Trim();
            if (string.IsNullOrEmpty(dvt))
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính!", "Thông báo"); return;
            }

            int idx = dgvChiTiet.CurrentRow.Index;
            DataRow row = dtChiTiet.Rows[idx];

            // Cập nhật dữ liệu từ input
            if (cboLoaiHangHoa.SelectedValue != null)
            {
                string maLHH = cboLoaiHangHoa.SelectedValue.ToString();
                string tenLHH = cboLoaiHangHoa.Text;

                // Kiểm tra trùng loại HH (trừ dòng hiện tại)
                for (int i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    if (i != idx && dtChiTiet.Rows[i]["MaLoaiHH"].ToString() == maLHH)
                    {
                        MessageBox.Show("Loại hàng hóa này đã có trong dòng khác!", "Thông báo"); return;
                    }
                }

                row["MaLoaiHH"] = maLHH;
                row["TenLoaiHH"] = tenLHH;
            }

            row["KhoiLuong"] = kl;
            row["SoKien"] = sk;
            row["DonViTinh"] = dvt;
            row["MoTaHH"] = txtMoTaHangHoa.Text.Trim();

            ClearChiTietInput();
        }

        // ══════════════════════════════════════════════════════
        // CHI TIẾT HÀNG HÓA — XÓA
        // ══════════════════════════════════════════════════════
        private void btnXoaHangHoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn dòng chi tiết cần xóa!", "Thông báo"); return;
            }

            dtChiTiet.Rows.RemoveAt(dgvChiTiet.CurrentRow.Index);
        }

        // ══════════════════════════════════════════════════════
        // CHI TIẾT HÀNG HÓA — LÀM MỚI INPUT
        // ══════════════════════════════════════════════════════
        private void btnLamMoiHangHoa_Click(object sender, EventArgs e)
        {
            ClearChiTietInput();
        }

        // ══════════════════════════════════════════════════════
        // VALIDATE
        // ══════════════════════════════════════════════════════
        private bool ValidateInput()
        {
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenNguoiNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người nhận!", "Cảnh báo");
                txtTenNguoiNhan.Focus(); return false;
            }

            string sdt = txtSDTNguoiNhan.Text.Trim();
            if (sdt.Length != 10 || !System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{10}$"))
            {
                MessageBox.Show("SĐT người nhận phải có đúng 10 chữ số!", "Cảnh báo");
                txtSDTNguoiNhan.Focus(); return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChiLayHang.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ lấy hàng!", "Cảnh báo");
                txtDiaChiLayHang.Focus(); return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChiGiao.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ giao!", "Cảnh báo");
                txtDiaChiGiao.Focus(); return false;
            }

            if (dtpTGGiaoDuKien.Value < dtpTGNhanDuKien.Value)
            {
                MessageBox.Show("Thời gian giao dự kiến phải lớn hơn hoặc bằng thời gian nhận!", "Cảnh báo");
                return false;
            }

            if (!decimal.TryParse(txtPhiVC.Text, out decimal phi) || phi < 0)
            {
                MessageBox.Show("Phí vận chuyển phải là số lớn hơn hoặc bằng 0!", "Cảnh báo");
                txtPhiVC.Focus(); return false;
            }

            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Phải có ít nhất một dòng chi tiết hàng hóa!", "Cảnh báo");
                return false;
            }

            return true;
        }

        // ══════════════════════════════════════════════════════
        // HELPER — Chọn lại dòng theo MaDonVC sau khi refresh
        // ══════════════════════════════════════════════════════
        private void SelectRowByMaDonVC(string maDonVC)
        {
            foreach (DataGridViewRow row in dgvDonVC.Rows)
            {
                if (row.Cells["MaDonVC"].Value?.ToString() == maDonVC)
                {
                    dgvDonVC.ClearSelection();
                    row.Selected = true;
                    dgvDonVC.FirstDisplayedScrollingRowIndex = row.Index;

                    // Load lại chi tiết
                    DataRowView drv = row.DataBoundItem as DataRowView;
                    if (drv != null)
                    {
                        txtMaDonVC.Text = drv["MaDonVC"].ToString();
                        txtTenNguoiNhan.Text = drv["TenNguoiNhan"].ToString();
                        txtSDTNguoiNhan.Text = drv["SDTNguoiNhan"].ToString();
                        txtDiaChiLayHang.Text = drv["DiaChiLayHang"].ToString();
                        txtDiaChiGiao.Text = drv["DiaChiGiao"].ToString();
                        txtPhiVC.Text = drv["PhiVC"].ToString();
                        txtYeuCauDacBiet.Text = drv["YeuCauDacBiet"] == DBNull.Value ? "" : drv["YeuCauDacBiet"].ToString();
                        cboTrangThai.Text = drv["TrangThaiDon"].ToString();
                        if (drv["NgayTao"] != DBNull.Value)
                            txtNgayTao.Text = Convert.ToDateTime(drv["NgayTao"]).ToString("dd/MM/yyyy hh:mm tt");
                        if (drv["TGNhanDuKien"] != DBNull.Value)
                            dtpTGNhanDuKien.Value = Convert.ToDateTime(drv["TGNhanDuKien"]);
                        if (drv["TGGiaoDuKien"] != DBNull.Value)
                            dtpTGGiaoDuKien.Value = Convert.ToDateTime(drv["TGGiaoDuKien"]);
                        cboKhachHang.SelectedValue = drv["MaKH"].ToString();
                        LoadChiTietDVC(maDonVC);
                    }
                    break;
                }
            }
        }
    }
}
