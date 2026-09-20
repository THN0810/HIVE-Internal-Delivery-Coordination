using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.NguonLuc
{
    public partial class FrmPhuongTien : Form
    {
        private enum FormMode { View, Add, Edit }
        private FormMode currentMode = FormMode.View;
        private DataTable dtPhuongTien;

        public FrmPhuongTien()
        {
            InitializeComponent();
        }

        private void FrmPhuongTien_Load(object sender, EventArgs e)
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
            
            UIHelper.StyleDataGridView(dgvPhuongTien);
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
            dgvPhuongTien.AutoGenerateColumns = false;
            dgvPhuongTien.Columns.Clear();
            dgvPhuongTien.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaPT", HeaderText = "Mã PT", DataPropertyName = "MaPT", Width = 80 });
            dgvPhuongTien.Columns.Add(new DataGridViewTextBoxColumn { Name = "BienSoXe", HeaderText = "Biển số xe", DataPropertyName = "BienSoXe", Width = 120 });
            dgvPhuongTien.Columns.Add(new DataGridViewTextBoxColumn { Name = "TaiTrong", HeaderText = "Tải trọng (tấn)", DataPropertyName = "TaiTrong", Width = 120 });
            dgvPhuongTien.Columns.Add(new DataGridViewTextBoxColumn { Name = "TinhTrangPT", HeaderText = "Tình trạng", DataPropertyName = "TinhTrangPT", Width = 130 });
            dgvPhuongTien.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenLoaiPT", HeaderText = "Loại PT", DataPropertyName = "TenLoaiPT", Width = 150 });
        }

        private void LoadComboBoxes()
        {
            // Input Combos
            string query = "SELECT MaLoaiPT, TenLoaiPT FROM LoaiPhuongTien";
            DataTable dtLoai = DatabaseHelper.GetDataTable(query);

            cmbLoaiPT.DataSource = dtLoai.Copy();
            cmbLoaiPT.DisplayMember = "TenLoaiPT";
            cmbLoaiPT.ValueMember = "MaLoaiPT";

            cmbTinhTrang.Items.Clear();
            cmbTinhTrang.Items.AddRange(new object[] { "Sẵn sàng", "Đang vận chuyển", "Bảo trì" });
            cmbTinhTrang.SelectedIndex = 0;

            // Filter Combos
            DataTable dtLocLoai = dtLoai.Copy();
            DataRow rowAll = dtLocLoai.NewRow();
            rowAll["MaLoaiPT"] = "";
            rowAll["TenLoaiPT"] = "Tất cả";
            dtLocLoai.Rows.InsertAt(rowAll, 0);

            cboLocLoaiPT.DataSource = dtLocLoai;
            cboLocLoaiPT.DisplayMember = "TenLoaiPT";
            cboLocLoaiPT.ValueMember = "MaLoaiPT";
            cboLocLoaiPT.SelectedIndex = 0;

            cboLocTinhTrang.Items.Clear();
            cboLocTinhTrang.Items.AddRange(new object[] { "Tất cả", "Sẵn sàng", "Đang vận chuyển", "Bảo trì" });
            cboLocTinhTrang.SelectedIndex = 0;
        }

        private void LoadData()
        {
            string query = @"
                SELECT pt.MaPT, pt.BienSoXe, pt.TaiTrong, pt.TinhTrangPT, lpt.TenLoaiPT, pt.MaLoaiPT
                FROM PhuongTien pt 
                INNER JOIN LoaiPhuongTien lpt ON pt.MaLoaiPT = lpt.MaLoaiPT 
                ORDER BY pt.MaPT";
            dtPhuongTien = DatabaseHelper.GetDataTable(query);
        }

        private void ClearForm()
        {
            txtMaPT.Clear();
            txtBienSoXe.Clear();
            txtTaiTrong.Clear();
            if (cmbTinhTrang.Items.Count > 0) cmbTinhTrang.SelectedIndex = 0;
            if (cmbLoaiPT.Items.Count > 0) cmbLoaiPT.SelectedIndex = 0;
        }

        private void SetFormMode(FormMode mode)
        {
            currentMode = mode;
            bool isEditing = (mode == FormMode.Add || mode == FormMode.Edit);

            System.Drawing.Color editBg = System.Drawing.Color.White;
            System.Drawing.Color viewBg = System.Drawing.Color.White;

            txtBienSoXe.ReadOnly = !isEditing; txtBienSoXe.BackColor = editBg;
            txtTaiTrong.ReadOnly = !isEditing; txtTaiTrong.BackColor = editBg;
            
            cmbLoaiPT.Enabled = isEditing;
            cmbTinhTrang.Enabled = isEditing;

            txtMaPT.ReadOnly = true; txtMaPT.BackColor = viewBg;

            // Nút Thêm, Sửa bật khi View và có quyền
            btnThem.Enabled = !isEditing && SessionManager.CoQuyen("Q031");
            btnSua.Enabled = !isEditing && SessionManager.CoQuyen("Q032") && !string.IsNullOrEmpty(txtMaPT.Text);
            
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
            if (dtPhuongTien == null) return;

            string keyword = txtTimKiem.Text.Trim().ToLower();
            string loaiPT = cboLocLoaiPT.Text;
            string tinhTrang = cboLocTinhTrang.Text;

            DataView dv = dtPhuongTien.DefaultView;
            string filter = "1=1";

            if (loaiPT != "Tất cả")
            {
                filter += string.Format(" AND TenLoaiPT = '{0}'", loaiPT.Replace("'", "''"));
            }

            if (tinhTrang != "Tất cả")
            {
                filter += string.Format(" AND TinhTrangPT = '{0}'", tinhTrang.Replace("'", "''"));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += string.Format(" AND (MaPT LIKE '%{0}%' OR BienSoXe LIKE '%{0}%')", keyword.Replace("'", "''"));
            }

            dv.RowFilter = filter;
            dgvPhuongTien.DataSource = dv;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocLoaiPT.SelectedIndex = 0;
            cboLocTinhTrang.SelectedIndex = 0;
            ApplyFilter();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            if (cboLocLoaiPT.Items.Count > 0) cboLocLoaiPT.SelectedIndex = 0;
            if (cboLocTinhTrang.Items.Count > 0) cboLocTinhTrang.SelectedIndex = 0;
            RefreshData();
        }

        // ══════════════════════════════════════════════════════
        // THAO TÁC DỮ LIỆU
        // ══════════════════════════════════════════════════════
        private void dgvPhuongTien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && currentMode == FormMode.View)
            {
                DataGridViewRow row = dgvPhuongTien.Rows[e.RowIndex];
                txtMaPT.Text = row.Cells["MaPT"].Value?.ToString() ?? "";
                txtBienSoXe.Text = row.Cells["BienSoXe"].Value?.ToString() ?? "";
                txtTaiTrong.Text = row.Cells["TaiTrong"].Value?.ToString() ?? "";
                cmbTinhTrang.Text = row.Cells["TinhTrangPT"].Value?.ToString() ?? "";

                string tenLoaiPT = row.Cells["TenLoaiPT"].Value?.ToString() ?? "";
                for (int i = 0; i < cmbLoaiPT.Items.Count; i++)
                {
                    DataRowView drv = cmbLoaiPT.Items[i] as DataRowView;
                    if (drv != null && drv["TenLoaiPT"].ToString() == tenLoaiPT)
                    {
                        cmbLoaiPT.SelectedIndex = i;
                        break;
                    }
                }
                SetFormMode(FormMode.View);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtMaPT.Text = IdGenerator.GetNextId("PhuongTien", "MaPT", "PT");
            SetFormMode(FormMode.Add);
            txtBienSoXe.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPT.Text))
            {
                MessageBox.Show("Vui lòng chọn phương tiện cần sửa!", "Thông báo");
                return;
            }
            SetFormMode(FormMode.Edit);
            txtBienSoXe.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBienSoXe.Text)) { MessageBox.Show("Vui lòng nhập biển số xe!"); return; }
            if (!decimal.TryParse(txtTaiTrong.Text, out decimal taiTrong) || taiTrong <= 0) { MessageBox.Show("Tải trọng phải là số dương!"); return; }

            string query = currentMode == FormMode.Add
                ? "INSERT INTO PhuongTien (MaPT, BienSoXe, TaiTrong, TinhTrangPT, MaLoaiPT) VALUES (@MaPT, @BienSoXe, @TaiTrong, @TinhTrangPT, @MaLoaiPT)"
                : "UPDATE PhuongTien SET BienSoXe=@BienSoXe, TaiTrong=@TaiTrong, TinhTrangPT=@TinhTrangPT, MaLoaiPT=@MaLoaiPT WHERE MaPT=@MaPT";

            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@MaPT", txtMaPT.Text.Trim()), 
                    new SqlParameter("@BienSoXe", txtBienSoXe.Text.Trim()),
                    new SqlParameter("@TaiTrong", taiTrong), 
                    new SqlParameter("@TinhTrangPT", cmbTinhTrang.Text),
                    new SqlParameter("@MaLoaiPT", cmbLoaiPT.SelectedValue)
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
