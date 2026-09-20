using System;
using System.Drawing;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.Auth;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.KhachHang;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.NguonLuc;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.DonVanChuyen;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.DieuPhoi;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.TaiXeNhiemVu;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.PhatSinh;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.ThanhToan;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.HoaDon;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.BaoCao;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.QuanTri;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.Main
{
    public partial class FrmTrangChu : Form
    {
        private Form currentChildForm;

        public FrmTrangChu()
        {
            InitializeComponent();
        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            ApplyStyling();
            ApplyPermissions();
            OpenChildForm(new FrmDashboard());
        }

        private void ApplyStyling()
        {
            // Sidebar
            pnlSidebar.BackColor = UIHelper.Navy;
            lblTenNV.Text = SessionManager.HoTenNV;
            lblTenNV.ForeColor = Color.White;
            lblTenNV.Font = UIHelper.FontSidebarBold;
            lblVaiTro.Text = SessionManager.TenVT;
            lblVaiTro.ForeColor = UIHelper.Orange;
            lblVaiTro.Font = UIHelper.FontSmall;

            // Style sidebar buttons
            UIHelper.StyleSidebarButton(btnKhachHang);
            UIHelper.StyleSidebarButton(btnDonVanChuyen);
            UIHelper.StyleSidebarButton(btnDieuPhoi);
            UIHelper.StyleSidebarButton(btnTaiXe);
            UIHelper.StyleSidebarButton(btnPhuongTien);
            UIHelper.StyleSidebarButton(btnNhiemVuTaiXe);
            UIHelper.StyleSidebarButton(btnPhatSinh);
            UIHelper.StyleSidebarButton(btnThanhToan);
            UIHelper.StyleSidebarButton(btnHoaDon);
            UIHelper.StyleSidebarButton(btnBaoCao);
            UIHelper.StyleSidebarButton(btnQuanTri);
            UIHelper.StyleSidebarButton(btnDangXuat);

            // Đăng xuất button — red
            btnDangXuat.FlatAppearance.MouseOverBackColor = UIHelper.RedDanger;

            // Main area
            pnlMain.BackColor = UIHelper.BgMain;

            // Title bar
            this.Text = "HIVE - Hệ thống Quản lý Điều phối Vận chuyển | " + SessionManager.HoTenNV;
        }

        private void ApplyPermissions()
        {
            // Khách hàng (Q024: Xem KH)
            btnKhachHang.Visible = SessionManager.CoQuyen("Q024");

            // Đơn vận chuyển (Q036: Xem ĐVC) - Tài xế (VT002) không được phép xem
            btnDonVanChuyen.Visible = SessionManager.CoQuyen("Q036") && SessionManager.MaVT != "VT002";

            // Điều phối (Q044: Xem LệnhĐP)
            btnDieuPhoi.Visible = SessionManager.CoQuyen("Q044") && SessionManager.CoQuyen("Q045");

            // Tài xế (Q004: Xem NV)
            btnTaiXe.Visible = SessionManager.CoQuyen("Q004");

            // Phương tiện (Q030: Xem PT)
            btnPhuongTien.Visible = SessionManager.CoQuyen("Q030");

            // Nhiệm vụ (chỉ Tài xế VT002)
            btnNhiemVuTaiXe.Visible = (SessionManager.MaVT == "VT002");

            // Phát sinh (Q049: Xem PPS)
            btnPhatSinh.Visible = SessionManager.CoQuyen("Q049");

            // Thanh toán (Q052: Xem PTT)
            btnThanhToan.Visible = SessionManager.CoQuyen("Q052");

            // Hóa đơn (Q055: Xem HĐ)
            btnHoaDon.Visible = SessionManager.CoQuyen("Q055");

            // Báo cáo (Q066 hoặc Q067 hoặc là Điều phối viên)
            btnBaoCao.Visible = SessionManager.CoQuyen("Q066") || SessionManager.CoQuyen("Q067") || SessionManager.TenVT == "Điều phối viên";

            // Quản trị (Q007: Xem TK hoặc Q017: Xem PQ) - Quản lý (VT004) không được phép xem
            btnQuanTri.Visible = (SessionManager.CoQuyen("Q007") || SessionManager.CoQuyen("Q017")) && SessionManager.MaVT != "VT004";
        }

        // ── Mở form con trong pnlMain ──────────
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
                currentChildForm.Close();

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // ── Events sidebar buttons ─────────────
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmKhachHang());
        }

        private void btnTaiXe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTaiXe());
        }

        private void btnPhuongTien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmPhuongTien());
        }

        private void btnDonVanChuyen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmDonVanChuyen());
        }

        private void btnDieuPhoi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmDieuPhoi());
        }

        private void btnNhiemVuTaiXe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmNhiemVuTaiXe());
        }

        private void btnPhatSinh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmPhatSinhVC());
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmThanhToanVC());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmHoaDonVC());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBaoCao());
        }

        private void btnQuanTri_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTaiKhoan());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.DangXuat();
                FrmDangNhap frmDangNhap = new FrmDangNhap();
                this.Hide();
                frmDangNhap.ShowDialog();
                this.Close();
            }
        }
    }
}
