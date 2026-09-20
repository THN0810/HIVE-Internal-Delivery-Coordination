using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.DonVanChuyen
{
    public partial class FrmChiTietDonVanChuyen : Form
    {
        private readonly string _maDonVC;

        public FrmChiTietDonVanChuyen(string maDonVC)
        {
            InitializeComponent();
            _maDonVC = maDonVC;
        }

        // ══════════════════════════════════════════════════════
        // FORM LOAD
        // ══════════════════════════════════════════════════════
        private void FrmChiTietDonVanChuyen_Load(object sender, EventArgs e)
        {
            ApplyStyling();
            SetupGridColumns();

            lblMaDon.Text = "Mã đơn: " + _maDonVC;

            LoadThongTinDon();
            LoadChiTietHangHoa();
            LoadLichSuTrangThai();
        }

        // ══════════════════════════════════════════════════════
        // STYLING
        // ══════════════════════════════════════════════════════
        private void ApplyStyling()
        {
            this.BackColor     = UIHelper.BgMain;
            lblTitle.ForeColor = UIHelper.Navy;

            UIHelper.StyleDataGridView(dgvHangHoa);
            UIHelper.StyleDataGridView(dgvLichSu);
            UIHelper.StyleButtonDanger(btnDong);
        }

        // ══════════════════════════════════════════════════════
        // SETUP GRID COLUMNS
        // ══════════════════════════════════════════════════════
        private void SetupGridColumns()
        {
            // ── dgvHangHoa ──────────────────────────────────
            dgvHangHoa.AutoGenerateColumns = false;
            dgvHangHoa.Columns.Clear();
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã loại",            DataPropertyName = "MaLoaiHH",  Width = 100 });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên loại hàng hóa",  DataPropertyName = "TenLoaiHH", Width = 220 });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Khối lượng",          DataPropertyName = "KhoiLuong", Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số kiện",             DataPropertyName = "SoKien",    Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn vị tính",         DataPropertyName = "DonViTinh", Width = 120 });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mô tả hàng hóa",     DataPropertyName = "MoTaHH",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            // ── dgvLichSu ───────────────────────────────────
            dgvLichSu.AutoGenerateColumns = false;
            dgvLichSu.Columns.Clear();
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái cũ",   DataPropertyName = "TrangThaiCu",  Width = 160 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái mới",  DataPropertyName = "TrangThaiMoi", Width = 160 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thời gian cập nhật", DataPropertyName = "TGCapNhat", Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Người cập nhật",  DataPropertyName = "HoTenNV",      Width = 180 });
            dgvLichSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ghi chú",         DataPropertyName = "GhiChu",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        // ══════════════════════════════════════════════════════
        // LOAD DATA — Tab 1: Thông tin đơn
        // ══════════════════════════════════════════════════════
        private void LoadThongTinDon()
        {
            string query = @"
                SELECT dvc.MaDonVC, kh.TenKH, dvc.TenNguoiNhan, dvc.SDTNguoiNhan,
                       dvc.DiaChiLayHang, dvc.DiaChiGiao, dvc.TGNhanDuKien, dvc.TGGiaoDuKien,
                       dvc.PhiVC, dvc.YeuCauDacBiet, dvc.TrangThaiDon, dvc.NgayTao
                FROM DonVanChuyen dvc
                INNER JOIN KhachHang kh ON dvc.MaKH = kh.MaKH
                WHERE dvc.MaDonVC = @ma";

            DataTable dt = DatabaseHelper.GetDataTable(query, new SqlParameter[] { new SqlParameter("@ma", _maDonVC) });
            if (dt.Rows.Count == 0) return;

            DataRow r = dt.Rows[0];
            lblValMaDonVC.Text      = r["MaDonVC"].ToString();
            lblValKhachHang.Text    = r["TenKH"].ToString();
            lblValTenNguoiNhan.Text = r["TenNguoiNhan"].ToString();
            lblValSDT.Text          = r["SDTNguoiNhan"].ToString();
            lblValDiaChiLayHang.Text = r["DiaChiLayHang"].ToString();
            lblValDiaChiGiao.Text   = r["DiaChiGiao"].ToString();
            lblValPhiVC.Text        = r["PhiVC"] != DBNull.Value ? string.Format("{0:N0} đ", r["PhiVC"]) : "---";
            lblValTrangThai.Text    = r["TrangThaiDon"].ToString();
            lblValYeuCau.Text       = r["YeuCauDacBiet"] != DBNull.Value ? r["YeuCauDacBiet"].ToString() : "(Không có)";

            if (r["TGNhanDuKien"] != DBNull.Value)
                lblValTGNhan.Text = Convert.ToDateTime(r["TGNhanDuKien"]).ToString("dd/MM/yyyy HH:mm");
            if (r["TGGiaoDuKien"] != DBNull.Value)
                lblValTGGiao.Text = Convert.ToDateTime(r["TGGiaoDuKien"]).ToString("dd/MM/yyyy HH:mm");
            if (r["NgayTao"] != DBNull.Value)
                lblValNgayTao.Text = Convert.ToDateTime(r["NgayTao"]).ToString("dd/MM/yyyy HH:mm");

            // Tô màu trạng thái
            switch (lblValTrangThai.Text)
            {
                case "Hoàn thành":      lblValTrangThai.ForeColor = UIHelper.GreenSuccess; break;
                case "Đã hủy":          lblValTrangThai.ForeColor = UIHelper.RedDanger;    break;
                case "Đang vận chuyển": lblValTrangThai.ForeColor = UIHelper.BluePrimary;  break;
                case "Đang điều phối":  lblValTrangThai.ForeColor = UIHelper.Orange;       break;
                default:                 lblValTrangThai.ForeColor = UIHelper.TextDark;     break;
            }
            lblValTrangThai.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        }

        // ══════════════════════════════════════════════════════
        // LOAD DATA — Tab 2: Chi tiết hàng hóa
        // ══════════════════════════════════════════════════════
        private void LoadChiTietHangHoa()
        {
            string query = @"
                SELECT ct.MaLoaiHH, lhh.TenLoaiHH, ct.KhoiLuong, ct.SoKien, ct.DonViTinh, ct.MoTaHH
                FROM ChiTietDVC ct
                INNER JOIN LoaiHangHoa lhh ON ct.MaLoaiHH = lhh.MaLoaiHH
                WHERE ct.MaDonVC = @ma
                ORDER BY ct.MaLoaiHH";
            dgvHangHoa.DataSource = DatabaseHelper.GetDataTable(query, new SqlParameter[] { new SqlParameter("@ma", _maDonVC) });
        }

        // ══════════════════════════════════════════════════════
        // LOAD DATA — Tab 3: Lịch sử trạng thái
        // ══════════════════════════════════════════════════════
        private void LoadLichSuTrangThai()
        {
            string query = @"
                SELECT ls.TrangThaiCu, ls.TrangThaiMoi, ls.TGCapNhat,
                       ISNULL(nv.HoTenNV, '---') AS HoTenNV,
                       ISNULL(ls.GhiChu, '') AS GhiChu
                FROM LichSuTrangThaiDon ls
                LEFT JOIN NhanVien nv ON ls.MaNV = nv.MaNV
                WHERE ls.MaDonVC = @ma
                ORDER BY ls.TGCapNhat DESC";
            dgvLichSu.DataSource = DatabaseHelper.GetDataTable(query, new SqlParameter[] { new SqlParameter("@ma", _maDonVC) });
        }

        // ══════════════════════════════════════════════════════
        // NÚT ĐÓNG
        // ══════════════════════════════════════════════════════
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
