using System;
using System.Data;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.Main
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Chào mừng {SessionManager.HoTenNV} - Vai trò: {SessionManager.TenVT}";
            LoadThongKeTheoVaiTro();
        }

        private void LoadThongKeTheoVaiTro()
        {
            try
            {
                string vt = SessionManager.MaVT;
                string stats = "";

                if (vt == "VT005") // Quản trị viên
                {
                    stats += "• Quản trị hệ thống toàn diện\n";
                    stats += $"• Tổng số tài khoản hoạt động: {DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM TaiKhoan WHERE TrangThaiTK = N'Đang hoạt động'")}\n";
                }
                else if (vt == "VT001") // Điều phối viên
                {
                    stats += $"• Số đơn chờ điều phối: {DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM DonVanChuyen WHERE TrangThaiDon = N'Chờ điều phối'")}\n";
                    stats += $"• Số xe đang sẵn sàng: {DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM PhuongTien WHERE TinhTrangPT = N'Sẵn sàng'")}\n";
                }
                else if (vt == "VT002") // Tài xế
                {
                    stats += $"• Số chuyến đang chạy: {DatabaseHelper.ExecuteScalar($"SELECT COUNT(*) FROM LenhDieuPhoi WHERE MaNV = '{SessionManager.MaNV}' AND TrangThaiLenh = N'Đang thực hiện'")}\n";
                }
                else if (vt == "VT003") // Kế toán
                {
                    stats += $"• Số đơn chờ thanh toán: {DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM DonVanChuyen WHERE TrangThaiDon = N'Chờ thanh toán'")}\n";
                    stats += $"• Tổng hóa đơn đã xuất tháng này: {DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM HoaDonVanChuyen WHERE MONTH(NgayPhatHanh) = MONTH(GETDATE())")}\n";
                }
                else if (vt == "VT004") // Ban quản lý
                {
                    stats += $"• Tổng doanh thu dự kiến tháng: {DatabaseHelper.ExecuteScalar("SELECT ISNULL(SUM(SoTienTT), 0) FROM PhieuThanhToanVC WHERE MONTH(NgayTT) = MONTH(GETDATE())"):N0} VNĐ\n";
                }

                lblRoleStats.Text = stats;
            }
            catch (Exception ex)
            {
                lblRoleStats.Text = "Lỗi khi tải thống kê: " + ex.Message;
            }
        }
    }
}
