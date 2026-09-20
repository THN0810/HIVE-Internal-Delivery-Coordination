using System;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.Auth;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.BaoCao;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.DieuPhoi;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.DonVanChuyen;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.HoaDon;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.Main;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
      

            Application.Run(new FrmDangNhap());
        }
    }
}
