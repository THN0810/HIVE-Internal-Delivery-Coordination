using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.PhatSinh
{
    public partial class FrmPhatSinhVC : Form
    {
        private enum FormMode { View, Add, Edit }
        private FormMode currentMode = FormMode.View;
        private DataTable dtPhatSinh;

        public FrmPhatSinhVC()
        {
            InitializeComponent();
        }

        private bool isUpdatingCombo = false;

        private void FrmPhatSinhVC_Load(object sender, EventArgs e)
        {
            ApplyStyling();
            SetupGridColumns();
            LoadComboBoxes();
            
            cmbDonVC.SelectedIndexChanged += cmbDonVC_SelectedIndexChanged;
            cmbLenhDP.SelectedIndexChanged += cmbLenhDP_SelectedIndexChanged;
            
            RefreshData();
        }

        private void ApplyStyling()
        {
            this.BackColor = UIHelper.BgMain;
            lblTitle.ForeColor = UIHelper.Navy;
            
            UIHelper.StyleDataGridView(dgvPhatSinh);
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
            dgvPhatSinh.AutoGenerateColumns = false;
            dgvPhatSinh.Columns.Clear();
            dgvPhatSinh.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaPhieuPS", HeaderText = "Mã Phiếu", DataPropertyName = "MaPhieuPS", Width = 100 });
            dgvPhatSinh.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaDonVC", HeaderText = "Đơn VC", DataPropertyName = "MaDonVC", Width = 90 });
            dgvPhatSinh.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaLenhDP", HeaderText = "Lệnh ĐP", DataPropertyName = "MaLenhDP", Width = 90 });
            dgvPhatSinh.Columns.Add(new DataGridViewTextBoxColumn { Name = "NoiDungPhatSinh", HeaderText = "Nội dung", DataPropertyName = "NoiDungPhatSinh", Width = 200 });
            dgvPhatSinh.Columns.Add(new DataGridViewTextBoxColumn { Name = "HuongXuLy", HeaderText = "Hướng xử lý", DataPropertyName = "HuongXuLy", Width = 150 });
            dgvPhatSinh.Columns.Add(new DataGridViewTextBoxColumn { Name = "KetQuaXuLy", HeaderText = "Kết quả", DataPropertyName = "KetQuaXuLy", Width = 150 });
            dgvPhatSinh.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiXuLy", HeaderText = "Trạng thái", DataPropertyName = "TrangThaiXuLy", Width = 120 });
            dgvPhatSinh.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTenNV", HeaderText = "Người lập", DataPropertyName = "HoTenNV", Width = 150 });
            dgvPhatSinh.Columns.Add(new DataGridViewTextBoxColumn { Name = "TGPhatSinh", HeaderText = "Thời gian", DataPropertyName = "TGPhatSinh", Width = 140 });
        }

        private void LoadComboBoxes()
        {
            string queryDonVC = "SELECT MaDonVC FROM DonVanChuyen WHERE TrangThaiDon NOT IN (N'Hoàn thành', N'Đã hủy') ORDER BY MaDonVC";
            string queryLenhDP = "SELECT MaLenhDP FROM LenhDieuPhoi WHERE TrangThaiLenh NOT IN (N'Hoàn thành', N'Đã hủy', N'Từ chối') ORDER BY MaLenhDP";
            SqlParameter[] paramDonVC = null;
            SqlParameter[] paramLenhDP = null;

            if (SessionManager.TenVT == "Tài xế")
            {
                queryDonVC = "SELECT MaDonVC FROM DonVanChuyen WHERE TrangThaiDon NOT IN (N'Hoàn thành', N'Đã hủy') AND MaDonVC IN (SELECT MaDonVC FROM LenhDieuPhoi WHERE MaNV = @MaNV) ORDER BY MaDonVC";
                paramDonVC = new SqlParameter[] { new SqlParameter("@MaNV", SessionManager.MaNV) };

                queryLenhDP = "SELECT MaLenhDP FROM LenhDieuPhoi WHERE TrangThaiLenh NOT IN (N'Hoàn thành', N'Đã hủy', N'Từ chối') AND MaNV = @MaNV ORDER BY MaLenhDP";
                paramLenhDP = new SqlParameter[] { new SqlParameter("@MaNV", SessionManager.MaNV) };
            }

            cmbDonVC.DataSource = DatabaseHelper.GetDataTable(queryDonVC, paramDonVC);
            cmbDonVC.DisplayMember = "MaDonVC"; 
            cmbDonVC.ValueMember = "MaDonVC";
            
            cmbLenhDP.DataSource = DatabaseHelper.GetDataTable(queryLenhDP, paramLenhDP);
            cmbLenhDP.DisplayMember = "MaLenhDP"; 
            cmbLenhDP.ValueMember = "MaLenhDP";

            cmbTrangThaiXL.Items.Clear();
            cmbTrangThaiXL.Items.AddRange(new object[] { "Chưa xử lý", "Đang xử lý", "Đã xử lý" });
            cmbTrangThaiXL.SelectedIndex = 0;

            cboLocTrangThaiXL.Items.Clear();
            cboLocTrangThaiXL.Items.AddRange(new object[] { "Tất cả", "Chưa xử lý", "Đang xử lý", "Đã xử lý" });
            cboLocTrangThaiXL.SelectedIndex = 0;
        }

        private void LoadData()
        {
            string query = "";
            SqlParameter[] param = null;

            if (SessionManager.TenVT == "Tài xế")
            {
                query = @"
                    SELECT ps.MaPhieuPS, ps.MaDonVC, ps.MaLenhDP, ps.NoiDungPhatSinh, ps.TrangThaiXuLy,
                           ps.HuongXuLy, ps.KetQuaXuLy, ps.TGPhatSinh, nv.HoTenNV, ps.MaNV
                    FROM PhieuPhatSinhVC ps 
                    INNER JOIN NhanVien nv ON ps.MaNV = nv.MaNV 
                    LEFT JOIN LenhDieuPhoi ldp ON ps.MaLenhDP = ldp.MaLenhDP
                    WHERE ps.MaNV = @MaNV 
                       OR ldp.MaNV = @MaNV 
                       OR ps.MaDonVC IN (SELECT MaDonVC FROM LenhDieuPhoi WHERE MaNV = @MaNV)
                    ORDER BY ps.TGPhatSinh DESC";
                param = new SqlParameter[] { new SqlParameter("@MaNV", SessionManager.MaNV) };
            }
            else
            {
                query = @"
                    SELECT ps.MaPhieuPS, ps.MaDonVC, ps.MaLenhDP, ps.NoiDungPhatSinh, ps.TrangThaiXuLy,
                           ps.HuongXuLy, ps.KetQuaXuLy, ps.TGPhatSinh, nv.HoTenNV, ps.MaNV
                    FROM PhieuPhatSinhVC ps 
                    INNER JOIN NhanVien nv ON ps.MaNV = nv.MaNV 
                    ORDER BY ps.TGPhatSinh DESC";
            }
            dtPhatSinh = DatabaseHelper.GetDataTable(query, param);
        }

        private void ClearForm()
        {
            txtMaPhieuPS.Clear(); 
            txtNoiDung.Clear(); 
            txtHuongXuLy.Clear(); 
            txtKetQua.Clear();
            
            if (cmbTrangThaiXL.Items.Count > 0) cmbTrangThaiXL.SelectedIndex = 0;
            if (cmbDonVC.Items.Count > 0) cmbDonVC.SelectedIndex = 0;
            if (cmbLenhDP.Items.Count > 0) cmbLenhDP.SelectedIndex = 0;
        }

        private void SetFormMode(FormMode mode)
        {
            currentMode = mode;
            bool isEditing = (mode == FormMode.Add || mode == FormMode.Edit);

            System.Drawing.Color editBg = System.Drawing.Color.White;
            System.Drawing.Color viewBg = System.Drawing.Color.White;

            txtNoiDung.ReadOnly = !isEditing; txtNoiDung.BackColor = editBg;
            
            if (SessionManager.TenVT == "Tài xế")
            {
                txtHuongXuLy.ReadOnly = true; 
                txtKetQua.ReadOnly = true; 
                cmbTrangThaiXL.Enabled = false; 
            }
            else
            {
                txtHuongXuLy.ReadOnly = !isEditing; txtHuongXuLy.BackColor = editBg;
                txtKetQua.ReadOnly = !isEditing; txtKetQua.BackColor = editBg;
                cmbTrangThaiXL.Enabled = isEditing;
            }
            
            cmbDonVC.Enabled = isEditing;
            cmbLenhDP.Enabled = isEditing;

            txtMaPhieuPS.ReadOnly = true; txtMaPhieuPS.BackColor = viewBg;

            bool isQuanLy = SessionManager.TenVT == "Quản lý";

            // Nút Thêm, Sửa bật khi View (giả sử có quyền)
            btnThem.Enabled = !isEditing && !isQuanLy;
            bool isResolved = (cmbTrangThaiXL.Text == "Đã xử lý");
            btnSua.Enabled = !isEditing && !string.IsNullOrEmpty(txtMaPhieuPS.Text) && !isResolved && !isQuanLy;
            
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
            ApplyFilter();
            ClearForm();
            SetFormMode(FormMode.View);
        }

        // ══════════════════════════════════════════════════════
        // TÌM KIẾM VÀ LỌC
        // ══════════════════════════════════════════════════════
        private void ApplyFilter()
        {
            if (dtPhatSinh == null) return;

            string keyword = txtTimKiem.Text.Trim().ToLower();
            string trangThai = cboLocTrangThaiXL.Text;

            DataView dv = dtPhatSinh.DefaultView;
            string filter = "1=1";

            if (trangThai != "Tất cả")
            {
                filter += string.Format(" AND TrangThaiXuLy = '{0}'", trangThai.Replace("'", "''"));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += string.Format(" AND (MaPhieuPS LIKE '%{0}%' OR MaDonVC LIKE '%{0}%' OR MaLenhDP LIKE '%{0}%' OR NoiDungPhatSinh LIKE '%{0}%')", keyword.Replace("'", "''"));
            }

            dv.RowFilter = filter;
            dgvPhatSinh.DataSource = dv;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocTrangThaiXL.SelectedIndex = 0;
            ApplyFilter();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            if (cboLocTrangThaiXL.Items.Count > 0) cboLocTrangThaiXL.SelectedIndex = 0;
            RefreshData();
        }

        // ══════════════════════════════════════════════════════
        // THAO TÁC DỮ LIỆU
        // ══════════════════════════════════════════════════════
        private void dgvPhatSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentMode == FormMode.View)
            {
                DataRowView drv = dgvPhatSinh.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv == null) return;

                txtMaPhieuPS.Text = drv["MaPhieuPS"].ToString();
                txtNoiDung.Text = drv["NoiDungPhatSinh"].ToString();
                txtHuongXuLy.Text = drv["HuongXuLy"] != DBNull.Value ? drv["HuongXuLy"].ToString() : "";
                txtKetQua.Text = drv["KetQuaXuLy"] != DBNull.Value ? drv["KetQuaXuLy"].ToString() : "";
                cmbTrangThaiXL.Text = drv["TrangThaiXuLy"].ToString();
                
                string maDon = drv["MaDonVC"] != DBNull.Value ? drv["MaDonVC"].ToString() : "";
                if (!string.IsNullOrEmpty(maDon)) cmbDonVC.Text = maDon;
                
                string maLenh = drv["MaLenhDP"] != DBNull.Value ? drv["MaLenhDP"].ToString() : "";
                if (!string.IsNullOrEmpty(maLenh)) cmbLenhDP.Text = maLenh;

                SetFormMode(FormMode.View);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMaPhieuPS.Text = IdGenerator.GetNextId("PhieuPhatSinhVC", "MaPhieuPS", "PPS");
            SetFormMode(FormMode.Add);
            txtNoiDung.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieuPS.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu cần sửa!", "Thông báo");
                return;
            }

            if (SessionManager.TenVT == "Tài xế")
            {
                DataRowView drv = dgvPhatSinh.CurrentRow?.DataBoundItem as DataRowView;
                if (drv != null)
                {
                    string maNVLap = drv["MaNV"].ToString();
                    if (maNVLap != SessionManager.MaNV)
                    {
                        MessageBox.Show("Bạn chỉ được phép sửa phiếu phát sinh do chính mình lập!", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (cmbTrangThaiXL.Text == "Đã xử lý")
                {
                    MessageBox.Show("Không thể sửa phiếu phát sinh đã được xử lý!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            SetFormMode(FormMode.Edit);
            txtNoiDung.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text)) { MessageBox.Show("Nhập nội dung phát sinh!", "Thông báo"); return; }
            
            string query = currentMode == FormMode.Add
                ? @"INSERT INTO PhieuPhatSinhVC (MaPhieuPS, NoiDungPhatSinh, HuongXuLy, KetQuaXuLy, TrangThaiXuLy, MaDonVC, MaLenhDP, MaNV)
                    VALUES (@Ma, @ND, @HXL, @KQ, @TT, @DonVC, @LDP, @NV)"
                : @"UPDATE PhieuPhatSinhVC SET NoiDungPhatSinh=@ND, HuongXuLy=@HXL, KetQuaXuLy=@KQ, TrangThaiXuLy=@TT, MaDonVC=@DonVC, MaLenhDP=@LDP WHERE MaPhieuPS=@Ma";
            
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Ma", txtMaPhieuPS.Text.Trim()), 
                    new SqlParameter("@ND", txtNoiDung.Text.Trim()),
                    new SqlParameter("@HXL", string.IsNullOrEmpty(txtHuongXuLy.Text) ? (object)DBNull.Value : txtHuongXuLy.Text.Trim()),
                    new SqlParameter("@KQ", string.IsNullOrEmpty(txtKetQua.Text) ? (object)DBNull.Value : txtKetQua.Text.Trim()),
                    new SqlParameter("@TT", cmbTrangThaiXL.Text),
                    new SqlParameter("@DonVC", cmbDonVC.SelectedValue ?? (object)DBNull.Value),
                    new SqlParameter("@LDP", cmbLenhDP.SelectedValue ?? (object)DBNull.Value),
                    new SqlParameter("@NV", SessionManager.MaNV) 
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

        private void cmbDonVC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingCombo) return;
            if (cmbDonVC.SelectedValue == null) return;
            
            string maDon = cmbDonVC.SelectedValue.ToString();
            string query = "SELECT TOP 1 MaLenhDP FROM LenhDieuPhoi WHERE MaDonVC = @MaDon ORDER BY MaLenhDP DESC";
            object res = DatabaseHelper.ExecuteScalar(query, new SqlParameter[] { new SqlParameter("@MaDon", maDon) });
            
            if (res != null)
            {
                isUpdatingCombo = true;
                cmbLenhDP.SelectedValue = res.ToString();
                isUpdatingCombo = false;
            }
            else 
            {
                isUpdatingCombo = true;
                cmbLenhDP.SelectedIndex = -1;
                isUpdatingCombo = false;
            }
        }

        private void cmbLenhDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingCombo) return;
            if (cmbLenhDP.SelectedValue == null) return;
            
            string maLenh = cmbLenhDP.SelectedValue.ToString();
            string query = "SELECT MaDonVC FROM LenhDieuPhoi WHERE MaLenhDP = @MaLenh";
            object res = DatabaseHelper.ExecuteScalar(query, new SqlParameter[] { new SqlParameter("@MaLenh", maLenh) });
            
            if (res != null)
            {
                isUpdatingCombo = true;
                cmbDonVC.SelectedValue = res.ToString();
                isUpdatingCombo = false;
            }
        }
    }
}
