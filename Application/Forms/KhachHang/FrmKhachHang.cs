using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.KhachHang
{
    public partial class FrmKhachHang : Form
    {
        private enum FormMode { View, Add, Edit }
        private FormMode currentMode = FormMode.View;
        private DataTable dtKhachHang;

        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
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
            
            UIHelper.StyleDataGridView(dgvKhachHang);
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
            dgvKhachHang.AutoGenerateColumns = false;
            dgvKhachHang.Columns.Clear();
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaKH", HeaderText = "Mã KH", DataPropertyName = "MaKH", Width = 80 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKH", HeaderText = "Tên khách hàng", DataPropertyName = "TenKH", Width = 200 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "SDTKH", HeaderText = "SĐT", DataPropertyName = "SDTKH", Width = 100 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmailKH", HeaderText = "Email", DataPropertyName = "EmailKH", Width = 160 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "DiaChiKH", HeaderText = "Địa chỉ", DataPropertyName = "DiaChiKH", Width = 200 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "MST", HeaderText = "Mã số thuế", DataPropertyName = "MST", Width = 120 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiSuDung", HeaderText = "Trạng thái", DataPropertyName = "TrangThaiSuDung", Width = 120 });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenLoaiKH", HeaderText = "Loại KH", DataPropertyName = "TenLoaiKH", Width = 150 });
        }

        private void LoadComboBoxes()
        {
            // Input Combos
            string query = "SELECT MaLoaiKH, TenLoaiKH FROM LoaiKhachHang WHERE TenLoaiKH != N'Khách hàng test'";
            DataTable dtLoai = DatabaseHelper.GetDataTable(query);

            cmbLoaiKH.DataSource = dtLoai.Copy();
            cmbLoaiKH.DisplayMember = "TenLoaiKH";
            cmbLoaiKH.ValueMember = "MaLoaiKH";

            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.AddRange(new object[] { "Đang sử dụng", "Ngừng sử dụng" });
            cmbTrangThai.SelectedIndex = 0;

            // Filter Combos
            DataTable dtLocLoai = dtLoai.Copy();
            DataRow rowAll = dtLocLoai.NewRow();
            rowAll["MaLoaiKH"] = "";
            rowAll["TenLoaiKH"] = "Tất cả";
            dtLocLoai.Rows.InsertAt(rowAll, 0);

            cboLocLoaiKH.DataSource = dtLocLoai;
            cboLocLoaiKH.DisplayMember = "TenLoaiKH";
            cboLocLoaiKH.ValueMember = "MaLoaiKH";
            cboLocLoaiKH.SelectedIndex = 0;

            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Đang sử dụng", "Ngừng sử dụng" });
            cboLocTrangThai.SelectedIndex = 0;
        }

        private void LoadData()
        {
            string query = @"
                SELECT kh.MaKH, kh.TenKH, kh.SDTKH, kh.EmailKH, kh.DiaChiKH, 
                       kh.MST, kh.TrangThaiSuDung, lkh.TenLoaiKH, kh.MaLoaiKH
                FROM KhachHang kh
                INNER JOIN LoaiKhachHang lkh ON kh.MaLoaiKH = lkh.MaLoaiKH
                ORDER BY kh.MaKH";
            dtKhachHang = DatabaseHelper.GetDataTable(query);
        }

        private void ClearForm()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDTKH.Clear();
            txtEmailKH.Clear();
            txtDiaChiKH.Clear();
            txtMST.Clear();
            if (cmbTrangThai.Items.Count > 0) cmbTrangThai.SelectedIndex = 0;
            if (cmbLoaiKH.Items.Count > 0) cmbLoaiKH.SelectedIndex = 0;
        }

        private void SetFormMode(FormMode mode)
        {
            currentMode = mode;
            bool isEditing = (mode == FormMode.Add || mode == FormMode.Edit);

            System.Drawing.Color editBg = System.Drawing.Color.White;
            System.Drawing.Color viewBg = System.Drawing.Color.White;

            txtTenKH.ReadOnly = !isEditing; txtTenKH.BackColor = editBg;
            txtSDTKH.ReadOnly = !isEditing; txtSDTKH.BackColor = editBg;
            txtEmailKH.ReadOnly = !isEditing; txtEmailKH.BackColor = editBg;
            txtDiaChiKH.ReadOnly = !isEditing; txtDiaChiKH.BackColor = editBg;
            txtMST.ReadOnly = !isEditing; txtMST.BackColor = editBg;
            
            cmbLoaiKH.Enabled = isEditing;
            cmbTrangThai.Enabled = isEditing;

            txtMaKH.ReadOnly = true; txtMaKH.BackColor = viewBg;

            // Nút Thêm, Sửa bật khi View và có quyền
            btnThem.Enabled = !isEditing && SessionManager.CoQuyen("Q025");
            btnSua.Enabled = !isEditing && SessionManager.CoQuyen("Q026") && !string.IsNullOrEmpty(txtMaKH.Text);
            
            // Nút Lưu, Hủy bật khi Edit
            btnLuu.Enabled = isEditing;
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
            if (dtKhachHang == null) return;

            string keyword = txtTimKiem.Text.Trim().ToLower();
            string loaiKH = cboLocLoaiKH.Text;
            string trangThai = cboLocTrangThai.Text;

            DataView dv = dtKhachHang.DefaultView;
            string filter = "1=1";

            if (loaiKH != "Tất cả")
            {
                filter += string.Format(" AND TenLoaiKH = '{0}'", loaiKH.Replace("'", "''"));
            }

            if (trangThai != "Tất cả")
            {
                filter += string.Format(" AND TrangThaiSuDung = '{0}'", trangThai.Replace("'", "''"));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += string.Format(" AND (MaKH LIKE '%{0}%' OR TenKH LIKE '%{0}%' OR SDTKH LIKE '%{0}%' OR EmailKH LIKE '%{0}%' OR MST LIKE '%{0}%')", keyword.Replace("'", "''"));
            }

            dv.RowFilter = filter;
            dgvKhachHang.DataSource = dv;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocLoaiKH.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;
            ApplyFilter();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            if (cboLocLoaiKH.Items.Count > 0) cboLocLoaiKH.SelectedIndex = 0;
            if (cboLocTrangThai.Items.Count > 0) cboLocTrangThai.SelectedIndex = 0;
            RefreshData();
        }

        // ══════════════════════════════════════════════════════
        // THAO TÁC DỮ LIỆU
        // ══════════════════════════════════════════════════════
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentMode == FormMode.View)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKH"].Value?.ToString() ?? "";
                txtTenKH.Text = row.Cells["TenKH"].Value?.ToString() ?? "";
                txtSDTKH.Text = row.Cells["SDTKH"].Value?.ToString() ?? "";
                txtEmailKH.Text = row.Cells["EmailKH"].Value?.ToString() ?? "";
                txtDiaChiKH.Text = row.Cells["DiaChiKH"].Value?.ToString() ?? "";
                txtMST.Text = row.Cells["MST"].Value?.ToString() ?? "";
                cmbTrangThai.Text = row.Cells["TrangThaiSuDung"].Value?.ToString() ?? "";

                string tenLoaiKH = row.Cells["TenLoaiKH"].Value?.ToString() ?? "";
                for (int i = 0; i < cmbLoaiKH.Items.Count; i++)
                {
                    DataRowView drv = cmbLoaiKH.Items[i] as DataRowView;
                    if (drv != null && drv["TenLoaiKH"].ToString() == tenLoaiKH)
                    {
                        cmbLoaiKH.SelectedIndex = i;
                        break;
                    }
                }
                SetFormMode(FormMode.View);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMaKH.Text = IdGenerator.GetNextId("KhachHang", "MaKH", "KH");
            SetFormMode(FormMode.Add);
            txtTenKH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo");
                return;
            }
            SetFormMode(FormMode.Edit);
            txtTenKH.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string query = currentMode == FormMode.Add
                ? @"INSERT INTO KhachHang (MaKH, TenKH, SDTKH, EmailKH, DiaChiKH, MST, TrangThaiSuDung, MaLoaiKH)
                    VALUES (@MaKH, @TenKH, @SDTKH, @EmailKH, @DiaChiKH, @MST, @TrangThaiSuDung, @MaLoaiKH)"
                : @"UPDATE KhachHang SET TenKH=@TenKH, SDTKH=@SDTKH, EmailKH=@EmailKH, DiaChiKH=@DiaChiKH,
                    MST=@MST, TrangThaiSuDung=@TrangThaiSuDung, MaLoaiKH=@MaLoaiKH WHERE MaKH=@MaKH";

            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@MaKH", txtMaKH.Text.Trim()),
                    new SqlParameter("@TenKH", txtTenKH.Text.Trim()),
                    new SqlParameter("@SDTKH", txtSDTKH.Text.Trim()),
                    new SqlParameter("@EmailKH", string.IsNullOrEmpty(txtEmailKH.Text.Trim()) ? (object)DBNull.Value : txtEmailKH.Text.Trim()),
                    new SqlParameter("@DiaChiKH", txtDiaChiKH.Text.Trim()),
                    new SqlParameter("@MST", string.IsNullOrEmpty(txtMST.Text.Trim()) ? (object)DBNull.Value : txtMST.Text.Trim()),
                    new SqlParameter("@TrangThaiSuDung", cmbTrangThai.Text),
                    new SqlParameter("@MaLoaiKH", cmbLoaiKH.SelectedValue)
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

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Cảnh báo");
                txtTenKH.Focus(); return false;
            }
            
            string sdt = txtSDTKH.Text.Trim();
            if (sdt.Length != 10 || !System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d+$"))
            {
                MessageBox.Show("SĐT phải có đúng 10 chữ số và chỉ chứa ký tự số!", "Cảnh báo");
                txtSDTKH.Focus(); return false;
            }
            
            if (!string.IsNullOrWhiteSpace(txtEmailKH.Text))
            {
                string email = txtEmailKH.Text.Trim();
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không đúng định dạng!", "Cảnh báo");
                    txtEmailKH.Focus(); return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtDiaChiKH.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Cảnh báo");
                txtDiaChiKH.Focus(); return false;
            }
            if (!string.IsNullOrWhiteSpace(txtMST.Text))
            {
                string mst = txtMST.Text.Trim();
                if (mst.Length < 10 || mst.Length > 14 || !System.Text.RegularExpressions.Regex.IsMatch(mst, @"^\d+$"))
                {
                    MessageBox.Show("Mã số thuế phải chứa từ 10 đến 14 chữ số và không được chứa ký tự khác!", "Cảnh báo");
                    txtMST.Focus(); return false;
                }
            }
            return true;
        }
    }
}
