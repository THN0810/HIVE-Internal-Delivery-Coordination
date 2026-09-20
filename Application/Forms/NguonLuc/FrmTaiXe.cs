using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.NguonLuc
{
    public partial class FrmTaiXe : Form
    {
        private enum FormMode { View, Add, Edit }
        private FormMode currentMode = FormMode.View;
        private DataTable dtTaiXe;

        public FrmTaiXe()
        {
            InitializeComponent();
        }

        private void FrmTaiXe_Load(object sender, EventArgs e)
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
            
            UIHelper.StyleDataGridView(dgvTaiXe);
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
            dgvTaiXe.AutoGenerateColumns = false;
            dgvTaiXe.Columns.Clear();
            dgvTaiXe.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNV", HeaderText = "Mã NV", DataPropertyName = "MaNV", Width = 80 });
            dgvTaiXe.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTenNV", HeaderText = "Họ tên", DataPropertyName = "HoTenNV", Width = 180 });
            dgvTaiXe.Columns.Add(new DataGridViewTextBoxColumn { Name = "CCCDNV", HeaderText = "CCCD", DataPropertyName = "CCCDNV", Width = 120 });
            dgvTaiXe.Columns.Add(new DataGridViewTextBoxColumn { Name = "SDTNV", HeaderText = "SĐT", DataPropertyName = "SDTNV", Width = 100 });
            dgvTaiXe.Columns.Add(new DataGridViewTextBoxColumn { Name = "HangBangLai", HeaderText = "Hạng BL", DataPropertyName = "HangBangLai", Width = 80 });
            dgvTaiXe.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayHHBangLai", HeaderText = "Hạn BL", DataPropertyName = "NgayHHBangLai", Width = 100 });
            dgvTaiXe.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThaiLV", HeaderText = "Trạng thái", DataPropertyName = "TrangThaiLV", Width = 120 });
        }

        private void LoadComboBoxes()
        {
            cmbHangBangLai.Items.Clear();
            cmbHangBangLai.Items.AddRange(new object[] { "B1", "B2", "C", "D", "E", "FC" });
            if (cmbHangBangLai.Items.Count > 0) cmbHangBangLai.SelectedIndex = 0;

            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.AddRange(new object[] { "Đang làm việc", "Nghỉ việc" });
            cmbTrangThai.SelectedIndex = 0;

            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Đang làm việc", "Nghỉ việc" });
            cboLocTrangThai.SelectedIndex = 0;
        }

        private void LoadData()
        {
            string query = @"
                SELECT MaNV, HoTenNV, CCCDNV, SDTNV, EmailNV, TrangThaiLV,
                       SoBangLai, HangBangLai, NgayHHBangLai
                FROM NhanVien
                WHERE MaCV = N'CV002'
                ORDER BY MaNV";
            dtTaiXe = DatabaseHelper.GetDataTable(query);
        }

        private void ClearForm()
        {
            txtMaNV.Clear(); txtHoTenNV.Clear(); txtCCCDNV.Clear();
            txtSDTNV.Clear(); txtEmailNV.Clear(); txtSoBangLai.Clear();
            if (cmbHangBangLai.Items.Count > 0) cmbHangBangLai.SelectedIndex = 0;
            if (cmbTrangThai.Items.Count > 0) cmbTrangThai.SelectedIndex = 0;
            dtpNgayHHBangLai.Value = DateTime.Now;
        }

        private void SetFormMode(FormMode mode)
        {
            currentMode = mode;
            bool isEditing = (mode == FormMode.Add || mode == FormMode.Edit);

            System.Drawing.Color editBg = System.Drawing.Color.White;
            System.Drawing.Color viewBg = System.Drawing.Color.White;

            txtHoTenNV.ReadOnly = !isEditing; txtHoTenNV.BackColor = editBg;
            txtCCCDNV.ReadOnly = !isEditing; txtCCCDNV.BackColor = editBg;
            txtSDTNV.ReadOnly = !isEditing; txtSDTNV.BackColor = editBg;
            txtEmailNV.ReadOnly = !isEditing; txtEmailNV.BackColor = editBg;
            txtSoBangLai.ReadOnly = !isEditing; txtSoBangLai.BackColor = editBg;

            cmbHangBangLai.Enabled = isEditing;
            cmbTrangThai.Enabled = isEditing;
            dtpNgayHHBangLai.Enabled = isEditing;

            txtMaNV.ReadOnly = true; txtMaNV.BackColor = viewBg;

            // Nút Thêm, Sửa bật khi View và có quyền
            btnThem.Enabled = !isEditing && SessionManager.CoQuyen("Q005");
            btnSua.Enabled = !isEditing && SessionManager.CoQuyen("Q006") && !string.IsNullOrEmpty(txtMaNV.Text);
            
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
            if (dtTaiXe == null) return;

            string keyword = txtTimKiem.Text.Trim().ToLower();
            string trangThai = cboLocTrangThai.Text;

            DataView dv = dtTaiXe.DefaultView;
            string filter = "1=1";

            if (trangThai != "Tất cả")
            {
                filter += string.Format(" AND TrangThaiLV = '{0}'", trangThai.Replace("'", "''"));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += string.Format(" AND (MaNV LIKE '%{0}%' OR HoTenNV LIKE '%{0}%' OR CCCDNV LIKE '%{0}%' OR SDTNV LIKE '%{0}%' OR SoBangLai LIKE '%{0}%')", keyword.Replace("'", "''"));
            }

            dv.RowFilter = filter;
            dgvTaiXe.DataSource = dv;
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
        private void dgvTaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentMode == FormMode.View)
            {
                DataRowView drv = dgvTaiXe.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (drv == null) return;

                txtMaNV.Text = drv["MaNV"].ToString();
                txtHoTenNV.Text = drv["HoTenNV"].ToString();
                txtCCCDNV.Text = drv["CCCDNV"].ToString();
                txtSDTNV.Text = drv["SDTNV"].ToString();
                txtEmailNV.Text = drv["EmailNV"] != DBNull.Value ? drv["EmailNV"].ToString() : "";
                txtSoBangLai.Text = drv["SoBangLai"] != DBNull.Value ? drv["SoBangLai"].ToString() : "";

                string hangBL = drv["HangBangLai"].ToString();
                if (cmbHangBangLai.Items.Contains(hangBL))
                    cmbHangBangLai.SelectedItem = hangBL;

                if (drv["NgayHHBangLai"] != DBNull.Value)
                    dtpNgayHHBangLai.Value = Convert.ToDateTime(drv["NgayHHBangLai"]);

                cmbTrangThai.Text = drv["TrangThaiLV"].ToString();
                SetFormMode(FormMode.View);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMaNV.Text = IdGenerator.GetNextId("NhanVien", "MaNV", "NV");
            SetFormMode(FormMode.Add);
            txtHoTenNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn tài xế cần sửa!", "Thông báo");
                return;
            }
            SetFormMode(FormMode.Edit);
            txtHoTenNV.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string query = currentMode == FormMode.Add
                ? @"INSERT INTO NhanVien (MaNV, HoTenNV, CCCDNV, SDTNV, EmailNV, TrangThaiLV, SoBangLai, HangBangLai, NgayHHBangLai, MaCV)
                    VALUES (@MaNV, @HoTenNV, @CCCDNV, @SDTNV, @EmailNV, @TrangThaiLV, @SoBangLai, @HangBangLai, @NgayHHBangLai, N'CV002')"
                : @"UPDATE NhanVien SET HoTenNV=@HoTenNV, CCCDNV=@CCCDNV, SDTNV=@SDTNV, EmailNV=@EmailNV,
                    TrangThaiLV=@TrangThaiLV, SoBangLai=@SoBangLai, HangBangLai=@HangBangLai, NgayHHBangLai=@NgayHHBangLai
                    WHERE MaNV=@MaNV";

            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@MaNV", txtMaNV.Text.Trim()),
                    new SqlParameter("@HoTenNV", txtHoTenNV.Text.Trim()),
                    new SqlParameter("@CCCDNV", txtCCCDNV.Text.Trim()),
                    new SqlParameter("@SDTNV", txtSDTNV.Text.Trim()),
                    new SqlParameter("@EmailNV", string.IsNullOrEmpty(txtEmailNV.Text.Trim()) ? (object)DBNull.Value : txtEmailNV.Text.Trim()),
                    new SqlParameter("@TrangThaiLV", cmbTrangThai.Text),
                    new SqlParameter("@SoBangLai", string.IsNullOrEmpty(txtSoBangLai.Text.Trim()) ? (object)DBNull.Value : txtSoBangLai.Text.Trim()),
                    new SqlParameter("@HangBangLai", cmbHangBangLai.Text),
                    new SqlParameter("@NgayHHBangLai", dtpNgayHHBangLai.Value.Date)
                };

                DatabaseHelper.ExecuteNonQuery(query, param);
                MessageBox.Show("Lưu thành công!", "Thông báo");
                RefreshData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTenNV.Text)) { MessageBox.Show("Vui lòng nhập họ tên!", "Cảnh báo"); txtHoTenNV.Focus(); return false; }
            
            string cccd = txtCCCDNV.Text.Trim();
            if (cccd.Length != 12 || !System.Text.RegularExpressions.Regex.IsMatch(cccd, @"^\d+$")) 
            { 
                MessageBox.Show("CCCD phải có đúng 12 chữ số và chỉ chứa ký tự số!", "Cảnh báo"); 
                txtCCCDNV.Focus(); return false; 
            }
            
            string sdt = txtSDTNV.Text.Trim();
            if (sdt.Length != 10 || !System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d+$")) 
            { 
                MessageBox.Show("SĐT phải có đúng 10 chữ số và chỉ chứa ký tự số!", "Cảnh báo"); 
                txtSDTNV.Focus(); return false; 
            }

            if (!string.IsNullOrWhiteSpace(txtEmailNV.Text))
            {
                string email = txtEmailNV.Text.Trim();
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không đúng định dạng!", "Cảnh báo");
                    txtEmailNV.Focus(); return false;
                }
            }
            return true;
        }
    }
}
