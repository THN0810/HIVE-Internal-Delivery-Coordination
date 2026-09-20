using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core
{
    /// <summary>
    /// Quản lý thông tin phiên đăng nhập.
    /// Lưu user hiện tại + danh sách quyền (đã tính cấp riêng / thu hồi riêng).
    /// </summary>
    public static class SessionManager
    {
        // Thông tin tài khoản
        public static string MaTK { get; set; }
        public static string TenDangNhap { get; set; }

        // Thông tin nhân viên
        public static string MaNV { get; set; }
        public static string HoTenNV { get; set; }

        // Thông tin vai trò
        public static string MaVT { get; set; }
        public static string TenVT { get; set; }

        // Danh sách mã quyền đã được tính toán
        public static List<string> DanhSachQuyen { get; set; } = new List<string>();

        /// <summary>
        /// Kiểm tra user có quyền cụ thể hay không.
        /// Quản trị viên (VT005) luôn trả về true.
        /// </summary>
        public static bool CoQuyen(string maQuyen)
        {
            if (MaVT == "VT005") return true;
            return DanhSachQuyen.Contains(maQuyen);
        }

        /// <summary>
        /// Load toàn bộ quyền từ PhanQuyen.
        /// Logic: (Quyền theo vai trò + Quyền cấp riêng) - Quyền thu hồi riêng.
        /// </summary>
        public static void LoadQuyen()
        {
            DanhSachQuyen.Clear();

            string query = @"
                ;WITH QuyenDuocCap AS (
                    SELECT MaQuyen FROM PhanQuyen 
                    WHERE MaVT = @MaVT AND LoaiPQ = N'Cấp quyền' AND TrangThaiPQ = N'Hoạt động'
                    UNION
                    SELECT MaQuyen FROM PhanQuyen 
                    WHERE MaTK = @MaTK AND LoaiPQ = N'Cấp quyền' AND TrangThaiPQ = N'Hoạt động'
                ),
                QuyenBiThuHoi AS (
                    SELECT MaQuyen FROM PhanQuyen 
                    WHERE MaTK = @MaTK AND LoaiPQ = N'Thu hồi quyền' AND TrangThaiPQ = N'Hoạt động'
                )
                SELECT MaQuyen FROM QuyenDuocCap 
                WHERE MaQuyen NOT IN (SELECT MaQuyen FROM QuyenBiThuHoi)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaVT", MaVT ?? (object)DBNull.Value),
                new SqlParameter("@MaTK", MaTK ?? (object)DBNull.Value)
            };

            DataTable dt = DatabaseHelper.GetDataTable(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                DanhSachQuyen.Add(row["MaQuyen"].ToString().Trim());
            }
        }

        /// <summary>
        /// Xóa toàn bộ session khi đăng xuất.
        /// </summary>
        public static void DangXuat()
        {
            MaTK = null;
            TenDangNhap = null;
            MaNV = null;
            HoTenNV = null;
            MaVT = null;
            TenVT = null;
            DanhSachQuyen.Clear();
        }
    }
}
