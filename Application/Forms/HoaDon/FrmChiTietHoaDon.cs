using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.HoaDon
{
    public partial class FrmChiTietHoaDon : Form
    {
        private string _maHD;

        public FrmChiTietHoaDon(string maHD)
        {
            InitializeComponent();
            _maHD = maHD;
        }

        private void FrmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            ApplyStyling();
            lblTitle.Text = "CHI TIẾT HÓA ĐƠN: " + _maHD;
            SetupGridColumns();
            LoadData();
        }

        private void ApplyStyling()
        {
            this.BackColor = UIHelper.BgMain;
            lblTitle.ForeColor = UIHelper.Navy;
            UIHelper.StyleDataGridView(dgvChiTiet);
            UIHelper.StyleButtonOutline(btnDong);
        }

        private void SetupGridColumns()
        {
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaLoaiPhi", HeaderText = "Mã loại phí", DataPropertyName = "MaLoaiPhi", Width = 100 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenLoaiPhi", HeaderText = "Tên loại phí", DataPropertyName = "TenLoaiPhi", Width = 200 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuong", HeaderText = "Số lượng", DataPropertyName = "SoLuong", Width = 100 });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "DonGia", HeaderText = "Đơn giá", DataPropertyName = "DonGia", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThanhTien", HeaderText = "Thành tiền", DataPropertyName = "ThanhTien", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
        }

        private void LoadData()
        {
            string query = @"
                SELECT ct.MaLoaiPhi, lp.TenLoaiPhi, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
                FROM ChiTietHDVC ct
                INNER JOIN LoaiPhiVanChuyen lp ON ct.MaLoaiPhi = lp.MaLoaiPhi
                WHERE ct.MaHD = @M";
            dgvChiTiet.DataSource = DatabaseHelper.GetDataTable(query, new SqlParameter[] { new SqlParameter("@M", _maHD) });
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
