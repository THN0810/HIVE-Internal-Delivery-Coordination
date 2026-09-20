using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.DieuPhoi
{
    public partial class FrmDieuPhoi : Form
    {
        // ── State ────────────────────────────────────────────────
        private bool   _isEditing       = false;   // đang lập lệnh / phân công lại
        private bool   _isPhanCongLai   = false;   // đang phân công lại
        private string _maDonVCGiuLai   = "";      // MaDonVC khi phân công lại
        private string _maLenhDangChon  = "";      // MaLenhDP đang chọn trên bảng
        
        private DataTable dtLenhDieuPhoi;

        // ── Trạng thái lệnh được xem là "đang hoạt động" ────────
        private static readonly string[] TrangThaiHoatDong =
            { "Chờ xác nhận", "Đã tiếp nhận", "Đang thực hiện" };

        // ── Trạng thái cho phép hủy lệnh ────────────────────────
        private static readonly string[] TrangThaiDuocHuy =
            { "Chờ xác nhận", "Đã tiếp nhận" };

        // ════════════════════════════════════════════════════════
        public FrmDieuPhoi() { InitializeComponent(); }

        // ════════════════════════════════════════════════════════
        // LOAD
        // ════════════════════════════════════════════════════════
        private void FrmDieuPhoi_Load(object sender, EventArgs e)
        {
            ApplyStyling();
            SetupGridColumns();
            LoadComboBoxFilter();
            LoadDonChoDieuPhoi();
            LoadDanhSachLenhDP();
            ResetToIdle();
        }

        // ════════════════════════════════════════════════════════
        // STYLING
        // ════════════════════════════════════════════════════════
        private void ApplyStyling()
        {
            this.BackColor = UIHelper.BgMain;
            lblTitle.ForeColor = UIHelper.Navy;

            UIHelper.StyleDataGridView(dgvDonChoDieuPhoi);
            UIHelper.StyleDataGridView(dgvLenhDieuPhoi);
            UIHelper.StyleGroupBox(grpThongTin);

            UIHelper.StyleButtonGreen(btnLapLenh);
            UIHelper.StyleButtonPrimary(btnLuuLenh);
            UIHelper.StyleButtonGray(btnHuyThaoTac);
            UIHelper.StyleButtonDanger(btnHuyLenh);
            UIHelper.StyleButtonOrange(btnPhanCongLai);
            UIHelper.StyleButtonOutline(btnLamMoi);
            
            UIHelper.StyleButtonPrimary(btnTimKiem);
            UIHelper.StyleButtonOutline(btnBoLoc);
        }

        // ════════════════════════════════════════════════════════
        // SETUP GRID COLUMNS
        // ════════════════════════════════════════════════════════
        private void SetupGridColumns()
        {
            // ── Bảng đơn chờ điều phối ──────────────────────────
            dgvDonChoDieuPhoi.AutoGenerateColumns = false;
            dgvDonChoDieuPhoi.Columns.Clear();
            dgvDonChoDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaDonVC",      HeaderText = "Mã đơn",           DataPropertyName = "MaDonVC",      Width = 80  });
            dgvDonChoDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKH",        HeaderText = "Khách hàng",        DataPropertyName = "TenKH",        Width = 160 });
            dgvDonChoDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiaChiLayHang",   HeaderText = "Địa chỉ lấy hàng",      DataPropertyName = "DiaChiLayHang",   Width = 200 });
            dgvDonChoDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiaChiGiao",   HeaderText = "Địa chỉ giao",      DataPropertyName = "DiaChiGiao",   Width = 200 });
            dgvDonChoDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "TGNhanDuKien", HeaderText = "TG nhận dự kiến",   DataPropertyName = "TGNhanDuKien", Width = 140 });
            dgvDonChoDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "TGGiaoDuKien", HeaderText = "TG giao dự kiến",   DataPropertyName = "TGGiaoDuKien", Width = 140 });
            dgvDonChoDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiDon", HeaderText = "Trạng thái đơn",    DataPropertyName = "TrangThaiDon", Width = 140 });

            // ── Bảng lệnh điều phối ──────────────────────────────
            dgvLenhDieuPhoi.AutoGenerateColumns = false;
            dgvLenhDieuPhoi.Columns.Clear();
            dgvLenhDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaLenhDP",      HeaderText = "Mã lệnh",          DataPropertyName = "MaLenhDP",      Width = 80  });
            dgvLenhDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaDonVC",        HeaderText = "Mã đơn",           DataPropertyName = "MaDonVC",        Width = 80  });
            dgvLenhDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTenTaiXe",    HeaderText = "Tài xế",           DataPropertyName = "HoTenTaiXe",    Width = 150 });
            dgvLenhDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "BienSoXe",      HeaderText = "Biển số",          DataPropertyName = "BienSoXe",      Width = 100 });
            dgvLenhDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "TGLapLenh",     HeaderText = "TG lập lệnh",      DataPropertyName = "TGLapLenh",     Width = 130 });
            dgvLenhDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "TGPhanCong",    HeaderText = "TG phân công",     DataPropertyName = "TGPhanCong",    Width = 130 });
            dgvLenhDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "TGXacNhan",     HeaderText = "TG xác nhận",      DataPropertyName = "TGXacNhan",     Width = 130 });
            dgvLenhDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiLenh", HeaderText = "Trạng thái",       DataPropertyName = "TrangThaiLenh", Width = 130 });
            dgvLenhDieuPhoi.Columns.Add(new DataGridViewTextBoxColumn { Name = "LyDoTuChoi",    HeaderText = "Lý do từ chối",    DataPropertyName = "LyDoTuChoi",    Width = 180 });
        }

        private void LoadComboBoxFilter()
        {
            cboLocTrangThaiLenh.Items.Clear();
            cboLocTrangThaiLenh.Items.AddRange(new object[] { "Tất cả", "Chờ xác nhận", "Đã tiếp nhận", "Từ chối", "Đang thực hiện", "Hoàn thành", "Đã hủy" });
            cboLocTrangThaiLenh.SelectedIndex = 0;
        }

        // ════════════════════════════════════════════════════════
        // LOAD DỮ LIỆU
        // ════════════════════════════════════════════════════════

        private void LoadDonChoDieuPhoi()
        {
            string sql = @"
                SELECT dvc.MaDonVC, kh.TenKH, dvc.DiaChiLayHang, dvc.DiaChiGiao,
                       CONVERT(VARCHAR(16), dvc.TGNhanDuKien, 103) + ' ' + CONVERT(VARCHAR(5), dvc.TGNhanDuKien, 108) AS TGNhanDuKien,
                       CONVERT(VARCHAR(16), dvc.TGGiaoDuKien, 103) + ' ' + CONVERT(VARCHAR(5), dvc.TGGiaoDuKien, 108) AS TGGiaoDuKien,
                       dvc.TrangThaiDon
                FROM DonVanChuyen dvc
                INNER JOIN KhachHang kh ON dvc.MaKH = kh.MaKH
                WHERE dvc.TrangThaiDon = N'Đang điều phối'
                  AND NOT EXISTS (
                      SELECT 1 FROM LenhDieuPhoi ldp
                      WHERE ldp.MaDonVC = dvc.MaDonVC
                        AND ldp.TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')
                  )
                ORDER BY dvc.TGNhanDuKien";
            dgvDonChoDieuPhoi.DataSource = DatabaseHelper.GetDataTable(sql);
        }

        private void LoadDanhSachLenhDP()
        {
            string sql = @"
                SELECT ldp.MaLenhDP, ldp.MaDonVC,
                       nv.HoTenNV AS HoTenTaiXe,
                       pt.BienSoXe,
                       CONVERT(VARCHAR(16), ldp.TGLapLenh, 103) + ' ' + CONVERT(VARCHAR(5), ldp.TGLapLenh, 108) AS TGLapLenh,
                       ISNULL(CONVERT(VARCHAR(16), ldp.TGPhanCong, 103) + ' ' + CONVERT(VARCHAR(5), ldp.TGPhanCong, 108), '') AS TGPhanCong,
                       ISNULL(CONVERT(VARCHAR(16), ldp.TGXacNhan,  103) + ' ' + CONVERT(VARCHAR(5), ldp.TGXacNhan,  108), '') AS TGXacNhan,
                       ldp.TrangThaiLenh,
                       ISNULL(ldp.LyDoTuChoi, '') AS LyDoTuChoi,
                       ldp.MaNV, ldp.MaPT
                FROM LenhDieuPhoi ldp
                INNER JOIN NhanVien   nv ON ldp.MaNV = nv.MaNV
                INNER JOIN PhuongTien pt ON ldp.MaPT = pt.MaPT
                ORDER BY ldp.TGLapLenh DESC";
            dtLenhDieuPhoi = DatabaseHelper.GetDataTable(sql);
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (dtLenhDieuPhoi == null) return;
            
            string keyword = txtTimKiem.Text.Trim().ToLower();
            string trangThai = cboLocTrangThaiLenh.Text;
            
            DataView dv = dtLenhDieuPhoi.DefaultView;
            string filter = "1=1";
            
            if (trangThai != "Tất cả")
            {
                filter += string.Format(" AND TrangThaiLenh = '{0}'", trangThai.Replace("'", "''"));
            }
            
            if (!string.IsNullOrEmpty(keyword))
            {
                filter += string.Format(" AND (MaLenhDP LIKE '%{0}%' OR MaDonVC LIKE '%{0}%' OR HoTenTaiXe LIKE '%{0}%' OR BienSoXe LIKE '%{0}%')", keyword.Replace("'", "''"));
            }
            
            dv.RowFilter = filter;
            dgvLenhDieuPhoi.DataSource = dv;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocTrangThaiLenh.SelectedIndex = 0;
            ApplyFilter();
        }

        private void LoadCboDonVC(string forceSelectMaDon = null)
        {
            string sql = @"
                SELECT dvc.MaDonVC,
                       dvc.MaDonVC + N' - ' + kh.TenKH + N' - ' + dvc.DiaChiGiao AS HienThi
                FROM DonVanChuyen dvc
                INNER JOIN KhachHang kh ON dvc.MaKH = kh.MaKH
                WHERE dvc.TrangThaiDon = N'Đang điều phối'
                  AND NOT EXISTS (
                      SELECT 1 FROM LenhDieuPhoi ldp
                      WHERE ldp.MaDonVC = dvc.MaDonVC
                        AND ldp.TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')
                  )
                ORDER BY dvc.MaDonVC";

            DataTable dt = DatabaseHelper.GetDataTable(sql);

            if (!string.IsNullOrEmpty(forceSelectMaDon))
            {
                bool found = false;
                foreach (DataRow r in dt.Rows)
                    if (r["MaDonVC"].ToString().Trim() == forceSelectMaDon) { found = true; break; }
                if (!found)
                {
                    DataRow nr = dt.NewRow();
                    nr["MaDonVC"] = forceSelectMaDon;
                    nr["HienThi"] = forceSelectMaDon + " (phân công lại)";
                    dt.Rows.InsertAt(nr, 0);
                }
            }

            cboDonVC.DataSource    = dt;
            cboDonVC.DisplayMember = "HienThi";
            cboDonVC.ValueMember   = "MaDonVC";

            if (!string.IsNullOrEmpty(forceSelectMaDon))
                cboDonVC.SelectedValue = forceSelectMaDon;
        }

        private void LoadCboTaiXe()
        {
            string sql = @"
                SELECT nv.MaNV,
                       nv.MaNV + N' - ' + nv.HoTenNV AS HienThi
                FROM NhanVien nv
                INNER JOIN ChucVu cv ON nv.MaCV = cv.MaCV
                WHERE (nv.MaCV = N'CV002' OR cv.TenCV LIKE N'%tài xế%' OR cv.TenCV LIKE N'%Tài xế%')
                  AND nv.TrangThaiLV = N'Đang làm việc'
                  AND NOT EXISTS (
                      SELECT 1 FROM LenhDieuPhoi ldp
                      WHERE ldp.MaNV = nv.MaNV
                        AND ldp.TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')
                  )
                ORDER BY nv.HoTenNV";

            DataTable dt = DatabaseHelper.GetDataTable(sql);
            cboTaiXe.DataSource    = dt;
            cboTaiXe.DisplayMember = "HienThi";
            cboTaiXe.ValueMember   = "MaNV";
        }

        private void LoadCboPhuongTien()
        {
            string sql = @"
                SELECT pt.MaPT,
                       pt.MaPT + N' - ' + pt.BienSoXe + N' - ' + lpt.TenLoaiPT AS HienThi
                FROM PhuongTien pt
                INNER JOIN LoaiPhuongTien lpt ON pt.MaLoaiPT = lpt.MaLoaiPT
                WHERE pt.TinhTrangPT = N'Sẵn sàng'
                  AND NOT EXISTS (
                      SELECT 1 FROM LenhDieuPhoi ldp
                      WHERE ldp.MaPT = pt.MaPT
                        AND ldp.TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')
                  )
                ORDER BY pt.BienSoXe";

            DataTable dt = DatabaseHelper.GetDataTable(sql);
            cboPhuongTien.DataSource    = dt;
            cboPhuongTien.DisplayMember = "HienThi";
            cboPhuongTien.ValueMember   = "MaPT";
        }

        // ════════════════════════════════════════════════════════
        // TOOLBAR BUTTONS
        // ════════════════════════════════════════════════════════

        private void btnLapLenh_Click(object sender, EventArgs e)
        {
            _isPhanCongLai  = false;
            _maDonVCGiuLai  = "";

            txtMaLenhDP.Text = IdGenerator.GetNextId("LenhDieuPhoi", "MaLenhDP", "LDP");

            dtpTGLapLenh.Value = DateTime.Now;
            dtpTGPhanCong.Value = DateTime.Now;

            LoadCboDonVC();
            LoadCboTaiXe();
            LoadCboPhuongTien();

            cboTrangThaiLenh.SelectedIndex = -1;
            cboTrangThaiLenh.Text = "Chờ xác nhận";

            if (dgvDonChoDieuPhoi.CurrentRow != null)
            {
                string maDon = dgvDonChoDieuPhoi.CurrentRow.Cells["MaDonVC"].Value?.ToString();
                if (!string.IsNullOrEmpty(maDon))
                    cboDonVC.SelectedValue = maDon;
            }

            txtLyDoTuChoi.Text = "";
            _isEditing = true;
            EnableInputs(true);
            SetButtonState(editMode: true);
        }

        private void btnLuuLenh_Click(object sender, EventArgs e)
        {
            if (cboDonVC.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vận chuyển!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (cboTaiXe.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn tài xế!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (cboPhuongTien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phương tiện!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (dtpTGPhanCong.Value < dtpTGLapLenh.Value)
            {
                MessageBox.Show("Thời gian phân công không được nhỏ hơn thời gian lập lệnh!", "Lỗi thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            string maLenhDP   = txtMaLenhDP.Text.Trim();
            string maDonVC    = cboDonVC.SelectedValue.ToString().Trim();
            string maNV       = cboTaiXe.SelectedValue.ToString().Trim();
            string maPT       = cboPhuongTien.SelectedValue.ToString().Trim();
            DateTime tgLap    = dtpTGLapLenh.Value;
            DateTime tgPhanCong = dtpTGPhanCong.Value;

            if (KiemTraTaiXeBan(maNV))
            {
                MessageBox.Show("Tài xế đang có lệnh điều phối chưa hoàn thành!\nVui lòng chọn tài xế khác.", "Tài xế bận", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (KiemTraPhuongTienBan(maPT))
            {
                MessageBox.Show("Phương tiện đang trong lệnh điều phối chưa hoàn thành!\nVui lòng chọn phương tiện khác.", "Phương tiện bận", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (KiemTraDonDaCoPhanCong(maDonVC))
            {
                MessageBox.Show("Đơn vận chuyển này đã có lệnh điều phối đang hoạt động!", "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            string maNhanVienHienTai = SessionManager.MaNV;
            if (string.IsNullOrEmpty(maNhanVienHienTai)) maNhanVienHienTai = maNV;

            string sqlInsertLenh = @"
                INSERT INTO LenhDieuPhoi (MaLenhDP, TGLapLenh, TGPhanCong, TrangThaiLenh, MaDonVC, MaNV, MaPT)
                VALUES (@MaLenhDP, @TGLapLenh, @TGPhanCong, N'Chờ xác nhận', @MaDonVC, @MaNV, @MaPT)";

            string maMaLichSu = IdGenerator.GetNextId("LichSuTrangThaiDon", "MaLichSu", "LS");
            string sqlInsertLichSu = @"
                INSERT INTO LichSuTrangThaiDon (MaLichSu, TrangThaiCu, TrangThaiMoi, TGCapNhat, GhiChu, MaDonVC, MaNV)
                VALUES (@MaLichSu, N'Đang điều phối', N'Đã phân công', GETDATE(), N'Lập lệnh điều phối mới', @MaDonVC2, @MaNV2)";

            var cmds = new List<SqlCommand>();

            var cmdLenh = new SqlCommand(sqlInsertLenh);
            cmdLenh.Parameters.AddWithValue("@MaLenhDP",    maLenhDP);
            cmdLenh.Parameters.AddWithValue("@TGLapLenh",   tgLap);
            cmdLenh.Parameters.AddWithValue("@TGPhanCong",  tgPhanCong);
            cmdLenh.Parameters.AddWithValue("@MaDonVC",     maDonVC);
            cmdLenh.Parameters.AddWithValue("@MaNV",        maNV);
            cmdLenh.Parameters.AddWithValue("@MaPT",        maPT);
            cmds.Add(cmdLenh);

            var cmdLS = new SqlCommand(sqlInsertLichSu);
            cmdLS.Parameters.AddWithValue("@MaLichSu", maMaLichSu);
            cmdLS.Parameters.AddWithValue("@MaDonVC2",  maDonVC);
            cmdLS.Parameters.AddWithValue("@MaNV2",     maNhanVienHienTai);
            cmds.Add(cmdLS);

            if (DatabaseHelper.ExecuteTransaction(cmds))
            {
                MessageBox.Show("Lập lệnh điều phối thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadAll();
                ResetToIdle();
            }
        }

        private void btnHuyThaoTac_Click(object sender, EventArgs e)
        {
            ResetToIdle();
        }

        private void btnHuyLenh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maLenhDangChon))
            {
                MessageBox.Show("Vui lòng chọn lệnh điều phối cần hủy từ danh sách.", "Chưa chọn lệnh", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            string trangThai = GetTrangThaiLenh(_maLenhDangChon);
            if (!Array.Exists(TrangThaiDuocHuy, t => t == trangThai))
            {
                MessageBox.Show($"Không thể hủy lệnh có trạng thái \"{trangThai}\".\nChỉ hủy được lệnh: Chờ xác nhận hoặc Đã tiếp nhận.", "Không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn hủy lệnh điều phối này không?", "Xác nhận hủy lệnh", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE LenhDieuPhoi SET TrangThaiLenh = N'Đã hủy' WHERE MaLenhDP = @MaLenhDP",
                    new SqlParameter[] { new SqlParameter("@MaLenhDP", _maLenhDangChon) });

                MessageBox.Show("Hủy lệnh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadAll();
                ResetToIdle();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi hủy lệnh:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhanCongLai_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maLenhDangChon))
            {
                MessageBox.Show("Vui lòng chọn lệnh điều phối cần phân công lại từ danh sách.", "Chưa chọn lệnh", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            string maDon = GetMaDonVCCuaLenh(_maLenhDangChon);
            if (string.IsNullOrEmpty(maDon)) return;

            _isPhanCongLai = true;
            _maDonVCGiuLai = maDon;

            txtMaLenhDP.Text = IdGenerator.GetNextId("LenhDieuPhoi", "MaLenhDP", "LDP");
            dtpTGLapLenh.Value  = DateTime.Now;
            dtpTGPhanCong.Value = DateTime.Now;

            LoadCboDonVC(forceSelectMaDon: maDon);
            LoadCboTaiXe();
            LoadCboPhuongTien();

            cboTrangThaiLenh.Text = "Chờ xác nhận";
            txtLyDoTuChoi.Text    = "";

            _isEditing = true;
            EnableInputs(true);
            cboDonVC.Enabled = false;

            SetButtonState(editMode: true);
            MessageBox.Show($"Đang phân công lại cho đơn vận chuyển [{maDon}].\nVui lòng chọn tài xế và phương tiện mới.", "Phân công lại", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocTrangThaiLenh.SelectedIndex = 0;
            ReloadAll();
            ResetToIdle();
        }

        // ════════════════════════════════════════════════════════
        // GRID EVENTS
        // ════════════════════════════════════════════════════════

        private void dgvDonChoDieuPhoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string maDon = dgvDonChoDieuPhoi.Rows[e.RowIndex].Cells["MaDonVC"].Value?.ToString();
            if (string.IsNullOrEmpty(maDon)) return;

            if (_isEditing && !_isPhanCongLai && cboDonVC.Enabled)
            {
                cboDonVC.SelectedValue = maDon;
            }
        }

        private void dgvLenhDieuPhoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _isEditing) return;

            DataRowView drv = dgvLenhDieuPhoi.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;
            
            string maLenh = drv["MaLenhDP"]?.ToString() ?? "";
            if (string.IsNullOrEmpty(maLenh)) return;

            ResetToIdle();
            _maLenhDangChon = maLenh;

            DataTable dt = DatabaseHelper.GetDataTable("SELECT * FROM LenhDieuPhoi WHERE MaLenhDP = @MaLenhDP", 
                new SqlParameter[] { new SqlParameter("@MaLenhDP", maLenh) });

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string maDon = dr["MaDonVC"].ToString();
                string maNV = dr["MaNV"].ToString();
                string maPT = dr["MaPT"].ToString();
                string trangThai = dr["TrangThaiLenh"].ToString();
                string lyDo = dr["LyDoTuChoi"] != DBNull.Value ? dr["LyDoTuChoi"].ToString() : "";

                LoadCboTatCaDonVC(maDon);
                LoadCboTatCaTaiXe(maNV);
                LoadCboTatCaPhuongTien(maPT);

                txtMaLenhDP.Text = maLenh;
                txtLyDoTuChoi.Text = lyDo;
                
                int idx = cboTrangThaiLenh.Items.IndexOf(trangThai);
                if (idx >= 0) cboTrangThaiLenh.SelectedIndex = idx;
                else cboTrangThaiLenh.Text = trangThai;

                if (dr["TGLapLenh"] != DBNull.Value)
                    dtpTGLapLenh.Value = Convert.ToDateTime(dr["TGLapLenh"]);
                if (dr["TGPhanCong"] != DBNull.Value)
                    dtpTGPhanCong.Value = Convert.ToDateTime(dr["TGPhanCong"]);

                EnableInputs(false);
                SetButtonStateByTrangThai(trangThai);
            }
        }

        // ════════════════════════════════════════════════════════
        // HELPER — LOAD COMBO ĐẦY ĐỦ (để bind khi xem lệnh)
        // ════════════════════════════════════════════════════════

        private void LoadCboTatCaDonVC(string selectMaDon)
        {
            DataTable dt2 = DatabaseHelper.GetDataTable(@"
                SELECT dvc.MaDonVC, dvc.MaDonVC + N' - ' + kh.TenKH AS HienThi
                FROM DonVanChuyen dvc INNER JOIN KhachHang kh ON dvc.MaKH = kh.MaKH
                ORDER BY dvc.MaDonVC");
            cboDonVC.DataSource    = dt2;
            cboDonVC.DisplayMember = "HienThi";
            cboDonVC.ValueMember   = "MaDonVC";
            if (!string.IsNullOrEmpty(selectMaDon))
                cboDonVC.SelectedValue = selectMaDon;
        }

        private void LoadCboTatCaTaiXe(string selectMaNV)
        {
            DataTable dt = DatabaseHelper.GetDataTable(@"
                SELECT nv.MaNV, nv.MaNV + N' - ' + nv.HoTenNV AS HienThi
                FROM NhanVien nv
                WHERE nv.TrangThaiLV = N'Đang làm việc'
                ORDER BY nv.HoTenNV");
            cboTaiXe.DataSource    = dt;
            cboTaiXe.DisplayMember = "HienThi";
            cboTaiXe.ValueMember   = "MaNV";
            if (!string.IsNullOrEmpty(selectMaNV))
                cboTaiXe.SelectedValue = selectMaNV;
        }

        private void LoadCboTatCaPhuongTien(string selectMaPT)
        {
            DataTable dt = DatabaseHelper.GetDataTable(@"
                SELECT pt.MaPT, pt.MaPT + N' - ' + pt.BienSoXe + N' - ' + lpt.TenLoaiPT AS HienThi
                FROM PhuongTien pt INNER JOIN LoaiPhuongTien lpt ON pt.MaLoaiPT = lpt.MaLoaiPT
                ORDER BY pt.BienSoXe");
            cboPhuongTien.DataSource    = dt;
            cboPhuongTien.DisplayMember = "HienThi";
            cboPhuongTien.ValueMember   = "MaPT";
            if (!string.IsNullOrEmpty(selectMaPT))
                cboPhuongTien.SelectedValue = selectMaPT;
        }

        // ════════════════════════════════════════════════════════
        // HELPER — KIỂM TRA NGHIỆP VỤ
        // ════════════════════════════════════════════════════════

        private bool KiemTraTaiXeBan(string maNV)
        {
            string sql = @"SELECT COUNT(1) FROM LenhDieuPhoi
                           WHERE MaNV = @MaNV
                             AND TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')";
            object result = DatabaseHelper.ExecuteScalar(sql, new SqlParameter[] { new SqlParameter("@MaNV", maNV) });
            return Convert.ToInt32(result) > 0;
        }

        private bool KiemTraPhuongTienBan(string maPT)
        {
            string sql = @"SELECT COUNT(1) FROM LenhDieuPhoi
                           WHERE MaPT = @MaPT
                             AND TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')";
            object result = DatabaseHelper.ExecuteScalar(sql, new SqlParameter[] { new SqlParameter("@MaPT", maPT) });
            return Convert.ToInt32(result) > 0;
        }

        private bool KiemTraDonDaCoPhanCong(string maDonVC)
        {
            string sql = @"SELECT COUNT(1) FROM LenhDieuPhoi
                           WHERE MaDonVC = @MaDonVC
                             AND TrangThaiLenh IN (N'Chờ xác nhận', N'Đã tiếp nhận', N'Đang thực hiện')";
            object result = DatabaseHelper.ExecuteScalar(sql, new SqlParameter[] { new SqlParameter("@MaDonVC", maDonVC) });
            return Convert.ToInt32(result) > 0;
        }

        private string GetTrangThaiLenh(string maLenhDP)
        {
            object result = DatabaseHelper.ExecuteScalar(
                "SELECT TrangThaiLenh FROM LenhDieuPhoi WHERE MaLenhDP = @MaLenhDP",
                new SqlParameter[] { new SqlParameter("@MaLenhDP", maLenhDP) });
            return result?.ToString() ?? "";
        }

        private string GetMaDonVCCuaLenh(string maLenhDP)
        {
            object result = DatabaseHelper.ExecuteScalar(
                "SELECT MaDonVC FROM LenhDieuPhoi WHERE MaLenhDP = @MaLenhDP",
                new SqlParameter[] { new SqlParameter("@MaLenhDP", maLenhDP) });
            return result?.ToString() ?? "";
        }

        // ════════════════════════════════════════════════════════
        // STATE MANAGEMENT
        // ════════════════════════════════════════════════════════

        private void SetButtonState(bool editMode)
        {
            bool isQuanLy = SessionManager.TenVT == "Quản lý";
            btnLapLenh.Enabled     = !editMode && !isQuanLy;
            btnLuuLenh.Enabled     = editMode && !isQuanLy;
            btnHuyThaoTac.Enabled  = editMode && !isQuanLy;
            btnHuyLenh.Enabled     = false;
            btnPhanCongLai.Enabled = false;
            btnLamMoi.Enabled      = !editMode;
            pnlFilter.Enabled      = !editMode;
        }

        private void SetButtonStateByTrangThai(string trangThai)
        {
            bool isQuanLy = SessionManager.TenVT == "Quản lý";
            btnLapLenh.Enabled     = !isQuanLy;
            btnLuuLenh.Enabled     = false;
            btnHuyThaoTac.Enabled  = false;
            btnLamMoi.Enabled      = true;
            pnlFilter.Enabled      = true;

            switch (trangThai)
            {
                case "Chờ xác nhận":
                case "Đã tiếp nhận":
                    btnHuyLenh.Enabled     = !isQuanLy;
                    btnPhanCongLai.Enabled = false;
                    break;
                case "Từ chối":
                    btnHuyLenh.Enabled     = false;
                    btnPhanCongLai.Enabled = !isQuanLy;
                    break;
                default: 
                    btnHuyLenh.Enabled     = false;
                    btnPhanCongLai.Enabled = false;
                    break;
            }
        }

        private void EnableInputs(bool enable)
        {
            cboDonVC.Enabled        = enable;
            cboTaiXe.Enabled        = enable;
            cboPhuongTien.Enabled   = enable;
            dtpTGPhanCong.Enabled   = enable;

            txtMaLenhDP.ReadOnly    = true;
            dtpTGLapLenh.Enabled    = false;
            cboTrangThaiLenh.Enabled = false;
            txtLyDoTuChoi.ReadOnly  = true;
        }

        private void ResetToIdle()
        {
            _isEditing      = false;
            _isPhanCongLai  = false;
            _maDonVCGiuLai  = "";
            _maLenhDangChon = "";

            txtMaLenhDP.Text   = "";
            txtLyDoTuChoi.Text = "";

            cboDonVC.DataSource      = null;
            cboTaiXe.DataSource      = null;
            cboPhuongTien.DataSource = null;
            dtpTGLapLenh.Value       = DateTime.Now;
            dtpTGPhanCong.Value      = DateTime.Now;
            cboTrangThaiLenh.SelectedIndex = -1;

            EnableInputs(false);
            SetButtonState(editMode: false);
        }

        private void ReloadAll()
        {
            LoadDonChoDieuPhoi();
            LoadDanhSachLenhDP();
        }
    }
}
