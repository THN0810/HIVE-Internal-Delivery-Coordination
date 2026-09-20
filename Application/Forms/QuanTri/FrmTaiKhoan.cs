using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.QuanTri
{
    public partial class FrmTaiKhoan : Form
    {
        private enum FormMode { View, Add, Edit }
        private FormMode currentMode = FormMode.View;
        private DataTable dtTaiKhoan;

        public FrmTaiKhoan()
        {
            InitializeComponent();
        }

        private void FrmTaiKhoan_Load(object sender, EventArgs e)
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
            
            UIHelper.StyleDataGridView(dgvTaiKhoan);
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
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.Columns.Clear();
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaTK", HeaderText = "Mã TK", DataPropertyName = "MaTK", Width = 80 });
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenDangNhap", HeaderText = "Tên đăng nhập", DataPropertyName = "TenDangNhap", Width = 150 });
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTenNV", HeaderText = "Nhân viên", DataPropertyName = "HoTenNV", Width = 180 });
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenVT", HeaderText = "Vai trò", DataPropertyName = "TenVT", Width = 150 });
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiTK", HeaderText = "Trạng thái", DataPropertyName = "TrangThaiTK", Width = 120 });
        }

        private void LoadComboBoxes()
        {
            cmbVaiTro.DataSource = DatabaseHelper.GetDataTable("SELECT MaVT, TenVT FROM VaiTroHeThong ORDER BY TenVT");
            cmbVaiTro.DisplayMember = "TenVT"; cmbVaiTro.ValueMember = "MaVT";
            
            cmbNhanVien.DataSource = DatabaseHelper.GetDataTable("SELECT MaNV, HoTenNV FROM NhanVien WHERE TrangThaiLV = N'Đang làm việc' ORDER BY HoTenNV");
            cmbNhanVien.DisplayMember = "HoTenNV"; cmbNhanVien.ValueMember = "MaNV";

            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.AddRange(new object[] { "Đang hoạt động", "Bị khóa" });
            cmbTrangThai.SelectedIndex = 0;

            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Đang hoạt động", "Bị khóa" });
            cboLocTrangThai.SelectedIndex = 0;
        }

        private void LoadData()
        {
            string query = @"
                SELECT tk.MaTK, tk.TenDangNhap, nv.HoTenNV, vt.TenVT, tk.TrangThaiTK, tk.MaVT, tk.MaNV
                FROM TaiKhoan tk
                INNER JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                INNER JOIN VaiTroHeThong vt ON tk.MaVT = vt.MaVT
                ORDER BY tk.MaTK";
            dtTaiKhoan = DatabaseHelper.GetDataTable(query);
        }

        private void ClearForm()
        {
            txtMaTK.Clear(); 
            txtTenDangNhap.Clear(); 
            txtMatKhau.Clear(); 
            
            if (cmbVaiTro.Items.Count > 0) cmbVaiTro.SelectedIndex = 0;
            if (cmbTrangThai.Items.Count > 0) cmbTrangThai.SelectedIndex = 0;
            if (cmbNhanVien.Items.Count > 0) cmbNhanVien.SelectedIndex = 0;
        }

        private void SetFormMode(FormMode mode)
        {
            currentMode = mode;
            bool isEditing = (mode == FormMode.Add || mode == FormMode.Edit);

            System.Drawing.Color editBg = System.Drawing.Color.White;
            System.Drawing.Color viewBg = System.Drawing.Color.White;

            txtTenDangNhap.ReadOnly = !isEditing; txtTenDangNhap.BackColor = editBg;
            txtMatKhau.ReadOnly = !isEditing; txtMatKhau.BackColor = editBg;
            
            cmbVaiTro.Enabled = isEditing;
            cmbNhanVien.Enabled = isEditing;
            cmbTrangThai.Enabled = isEditing;

            txtMaTK.ReadOnly = true; txtMaTK.BackColor = viewBg;

            bool isQuanLy = SessionManager.TenVT == "Quản lý";

            // Nút Thêm, Sửa bật khi View (giả sử có quyền)
            btnThem.Enabled = !isEditing && !isQuanLy;
            btnSua.Enabled = !isEditing && !string.IsNullOrEmpty(txtMaTK.Text) && !isQuanLy;
            
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
            if (dtTaiKhoan == null) return;

            string keyword = txtTimKiem.Text.Trim().ToLower();
            string trangThai = cboLocTrangThai.Text;

            DataView dv = dtTaiKhoan.DefaultView;
            string filter = "1=1";

            if (trangThai != "Tất cả")
            {
                filter += string.Format(" AND TrangThaiTK = '{0}'", trangThai.Replace("'", "''"));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += string.Format(" AND (MaTK LIKE '%{0}%' OR TenDangNhap LIKE '%{0}%' OR HoTenNV LIKE '%{0}%')", keyword.Replace("'", "''"));
            }

            dv.RowFilter = filter;
            dgvTaiKhoan.DataSource = dv;
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
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentMode == FormMode.View)
            {
                DataRowView drv = dgvTaiKhoan.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv == null) return;

                txtMaTK.Text = drv["MaTK"].ToString();
                txtTenDangNhap.Text = drv["TenDangNhap"].ToString();
                txtMatKhau.Clear();
                cmbTrangThai.Text = drv["TrangThaiTK"].ToString();
                
                string maNV = drv["MaNV"] != DBNull.Value ? drv["MaNV"].ToString() : "";
                if (!string.IsNullOrEmpty(maNV)) cmbNhanVien.SelectedValue = maNV;
                
                string maVT = drv["MaVT"] != DBNull.Value ? drv["MaVT"].ToString() : "";
                if (!string.IsNullOrEmpty(maVT)) cmbVaiTro.SelectedValue = maVT;

                SetFormMode(FormMode.View);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMaTK.Text = IdGenerator.GetNextId("TaiKhoan", "MaTK", "TK");
            SetFormMode(FormMode.Add);
            txtTenDangNhap.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTK.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo");
                return;
            }
            SetFormMode(FormMode.Edit);
            txtTenDangNhap.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text)) { MessageBox.Show("Nhập tên đăng nhập!", "Thông báo"); return; }
            if (currentMode == FormMode.Add && string.IsNullOrWhiteSpace(txtMatKhau.Text)) { MessageBox.Show("Nhập mật khẩu!", "Thông báo"); return; }

            string q;
            if (currentMode == FormMode.Add)
                q = @"INSERT INTO TaiKhoan (MaTK, TenDangNhap, MatKhau, TrangThaiTK, MaVT, MaNV)
                    VALUES (@Ma, @TenDN, @MK, @TT, @VT, @NV)";
            else if (!string.IsNullOrEmpty(txtMatKhau.Text))
                q = "UPDATE TaiKhoan SET TenDangNhap=@TenDN, MatKhau=@MK, TrangThaiTK=@TT, MaVT=@VT, MaNV=@NV WHERE MaTK=@Ma";
            else
                q = "UPDATE TaiKhoan SET TenDangNhap=@TenDN, TrangThaiTK=@TT, MaVT=@VT, MaNV=@NV WHERE MaTK=@Ma";
            
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Ma", txtMaTK.Text.Trim()), 
                    new SqlParameter("@TenDN", txtTenDangNhap.Text.Trim()),
                    new SqlParameter("@MK", string.IsNullOrEmpty(txtMatKhau.Text) ? (object)DBNull.Value : txtMatKhau.Text.Trim()),
                    new SqlParameter("@TT", cmbTrangThai.Text),
                    new SqlParameter("@VT", cmbVaiTro.SelectedValue ?? (object)DBNull.Value), 
                    new SqlParameter("@NV", cmbNhanVien.SelectedValue ?? (object)DBNull.Value) 
                };

                DatabaseHelper.ExecuteNonQuery(q, param);
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
