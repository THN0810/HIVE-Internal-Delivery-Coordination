using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.Main;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.Auth
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            ApplyStyling();
            txtTenDangNhap.Focus();
        }

        private void ApplyStyling()
        {
            // Panel trái — Navy gradient
            pnlLeft.BackColor = UIHelper.Navy;
            lblLogo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblSubtitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblSubtitle.ForeColor = Color.FromArgb(180, 200, 220);

            // Load logo HIVE
            try
            {
                string logoPath = System.IO.Path.Combine(Application.StartupPath, "Resources", "logo_hive.png");
                if (!System.IO.File.Exists(logoPath))
                    logoPath = System.IO.Path.Combine(Application.StartupPath, "..", "..", "Resources", "logo_hive.png");
                if (System.IO.File.Exists(logoPath))
                    picLogo.Image = Image.FromFile(logoPath);
            }
            catch { /* ignore */ }

            // Panel phải — White
            pnlRight.BackColor = Color.White;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblWelcome.ForeColor = UIHelper.Navy;

            // Labels
            lblTenDangNhap.Font = new Font("Segoe UI", 11F);
            lblTenDangNhap.ForeColor = UIHelper.TextDark;
            lblMatKhau.Font = new Font("Segoe UI", 11F);
            lblMatKhau.ForeColor = UIHelper.TextDark;

            // TextBoxes
            txtTenDangNhap.Font = new Font("Segoe UI", 13F);
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Font = new Font("Segoe UI", 13F);
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;

            // Button Đăng nhập
            UIHelper.StyleButtonOrange(btnDangNhap);
            btnDangNhap.Font = new Font("Segoe UI", 13F, FontStyle.Bold);

            // Button Thoát
            UIHelper.StyleButtonOutline(btnThoat);
            btnThoat.Font = new Font("Segoe UI", 11F);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Truy vấn lấy tài khoản không cần xét TrangThaiTK trước để kiểm tra chi tiết lỗi
            string query = @"
                SELECT tk.MaTK, tk.TenDangNhap, tk.MatKhau, tk.TrangThaiTK, tk.MaNV, tk.MaVT, 
                       vt.TenVT, nv.HoTenNV
                FROM TaiKhoan tk
                INNER JOIN VaiTroHeThong vt ON tk.MaVT = vt.MaVT
                INNER JOIN NhanVien nv ON tk.MaNV = nv.MaNV
                WHERE tk.TenDangNhap = @TenDangNhap";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenDangNhap", tenDangNhap)
            };

            DataTable dt = DatabaseHelper.GetDataTable(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                string dbMatKhau = row["MatKhau"].ToString().Trim();
                string trangThai = row["TrangThaiTK"].ToString().Trim();

                if (dbMatKhau != matKhau)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.",
                        "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                    return;
                }

                if (trangThai == "Bị khóa")
                {
                    MessageBox.Show("Tài khoản hiện đang bị khóa.",
                        "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lưu session
                SessionManager.MaTK = row["MaTK"].ToString().Trim();
                SessionManager.TenDangNhap = row["TenDangNhap"].ToString().Trim();
                SessionManager.MaNV = row["MaNV"].ToString().Trim();
                SessionManager.MaVT = row["MaVT"].ToString().Trim();
                SessionManager.TenVT = row["TenVT"].ToString().Trim();
                SessionManager.HoTenNV = row["HoTenNV"].ToString().Trim();

                // Load quyền
                SessionManager.LoadQuyen();

                // Mở trang chủ
                FrmTrangChu frmTrangChu = new FrmTrangChu();
                this.Hide();
                frmTrangChu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.",
                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
