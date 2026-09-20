namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.Main
{
    partial class FrmTrangChu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnDonVanChuyen;
        private System.Windows.Forms.Button btnDieuPhoi;
        private System.Windows.Forms.Button btnTaiXe;
        private System.Windows.Forms.Button btnPhuongTien;
        private System.Windows.Forms.Button btnNhiemVuTaiXe;
        private System.Windows.Forms.Button btnPhatSinh;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnQuanTri;
        private System.Windows.Forms.Button btnDangXuat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnDonVanChuyen = new System.Windows.Forms.Button();
            this.btnDieuPhoi = new System.Windows.Forms.Button();
            this.btnTaiXe = new System.Windows.Forms.Button();
            this.btnPhuongTien = new System.Windows.Forms.Button();
            this.btnNhiemVuTaiXe = new System.Windows.Forms.Button();
            this.btnPhatSinh = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnQuanTri = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUserInfo — Khu vực hiển thị tên NV
            // 
            this.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlUserInfo.Size = new System.Drawing.Size(240, 80);
            this.pnlUserInfo.Controls.Add(this.lblVaiTro);
            this.pnlUserInfo.Controls.Add(this.lblTenNV);
            // 
            // lblTenNV
            // 
            this.lblTenNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenNV.Location = new System.Drawing.Point(0, 0);
            this.lblTenNV.Padding = new System.Windows.Forms.Padding(20, 15, 10, 0);
            this.lblTenNV.Size = new System.Drawing.Size(240, 45);
            this.lblTenNV.Text = "Tên nhân viên";
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVaiTro.Location = new System.Drawing.Point(0, 45);
            this.lblVaiTro.Padding = new System.Windows.Forms.Padding(20, 0, 10, 10);
            this.lblVaiTro.Size = new System.Drawing.Size(240, 30);
            this.lblVaiTro.Text = "Vai trò";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Size = new System.Drawing.Size(240, 700);
            this.pnlSidebar.Controls.Add(this.btnDangXuat);
            this.pnlSidebar.Controls.Add(this.btnQuanTri);
            this.pnlSidebar.Controls.Add(this.btnBaoCao);
            this.pnlSidebar.Controls.Add(this.btnHoaDon);
            this.pnlSidebar.Controls.Add(this.btnThanhToan);
            this.pnlSidebar.Controls.Add(this.btnPhatSinh);
            this.pnlSidebar.Controls.Add(this.btnNhiemVuTaiXe);
            this.pnlSidebar.Controls.Add(this.btnPhuongTien);
            this.pnlSidebar.Controls.Add(this.btnTaiXe);
            this.pnlSidebar.Controls.Add(this.btnDieuPhoi);
            this.pnlSidebar.Controls.Add(this.btnDonVanChuyen);
            this.pnlSidebar.Controls.Add(this.btnKhachHang);
            this.pnlSidebar.Controls.Add(this.pnlUserInfo);
            // 
            // Sidebar Buttons — Dock Top, Size = 240x42
            // 
            this.btnKhachHang.Dock = System.Windows.Forms.DockStyle.Top; this.btnKhachHang.Size = new System.Drawing.Size(240, 42); this.btnKhachHang.Text = "  ● Khách hàng"; this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            this.btnDonVanChuyen.Dock = System.Windows.Forms.DockStyle.Top; this.btnDonVanChuyen.Size = new System.Drawing.Size(240, 42); this.btnDonVanChuyen.Text = "  ● Đơn vận chuyển"; this.btnDonVanChuyen.Click += new System.EventHandler(this.btnDonVanChuyen_Click);
            this.btnDieuPhoi.Dock = System.Windows.Forms.DockStyle.Top; this.btnDieuPhoi.Size = new System.Drawing.Size(240, 42); this.btnDieuPhoi.Text = "  ● Điều phối"; this.btnDieuPhoi.Click += new System.EventHandler(this.btnDieuPhoi_Click);
            this.btnTaiXe.Dock = System.Windows.Forms.DockStyle.Top; this.btnTaiXe.Size = new System.Drawing.Size(240, 42); this.btnTaiXe.Text = "  ● Quản lý tài xế"; this.btnTaiXe.Click += new System.EventHandler(this.btnTaiXe_Click);
            this.btnPhuongTien.Dock = System.Windows.Forms.DockStyle.Top; this.btnPhuongTien.Size = new System.Drawing.Size(240, 42); this.btnPhuongTien.Text = "  ● Phương tiện"; this.btnPhuongTien.Click += new System.EventHandler(this.btnPhuongTien_Click);
            this.btnNhiemVuTaiXe.Dock = System.Windows.Forms.DockStyle.Top; this.btnNhiemVuTaiXe.Size = new System.Drawing.Size(240, 42); this.btnNhiemVuTaiXe.Text = "  ● Nhiệm vụ của tôi"; this.btnNhiemVuTaiXe.Click += new System.EventHandler(this.btnNhiemVuTaiXe_Click);
            this.btnPhatSinh.Dock = System.Windows.Forms.DockStyle.Top; this.btnPhatSinh.Size = new System.Drawing.Size(240, 42); this.btnPhatSinh.Text = "  ● Phát sinh VC"; this.btnPhatSinh.Click += new System.EventHandler(this.btnPhatSinh_Click);
            this.btnThanhToan.Dock = System.Windows.Forms.DockStyle.Top; this.btnThanhToan.Size = new System.Drawing.Size(240, 42); this.btnThanhToan.Text = "  ● Thanh toán"; this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            this.btnHoaDon.Dock = System.Windows.Forms.DockStyle.Top; this.btnHoaDon.Size = new System.Drawing.Size(240, 42); this.btnHoaDon.Text = "  ● Hóa đơn"; this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top; this.btnBaoCao.Size = new System.Drawing.Size(240, 42); this.btnBaoCao.Text = "  ● Báo cáo"; this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            this.btnQuanTri.Dock = System.Windows.Forms.DockStyle.Top; this.btnQuanTri.Size = new System.Drawing.Size(240, 42); this.btnQuanTri.Text = "  ● Quản lý tài khoản"; this.btnQuanTri.Click += new System.EventHandler(this.btnQuanTri_Click);
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom; this.btnDangXuat.Size = new System.Drawing.Size(240, 42); this.btnDangXuat.Text = "  ◀ Đăng xuất"; this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(240, 0);
            this.pnlMain.Size = new System.Drawing.Size(960, 700);
            // 
            // FrmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "FrmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HIVE - Hệ thống Quản lý Điều phối Vận chuyển";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTrangChu_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlUserInfo.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
