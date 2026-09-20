namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.DonVanChuyen
{
    partial class FrmChiTietDonVanChuyen
    {
        private System.ComponentModel.IContainer components = null;

        // ── Header ──────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaDon;

        // ── TabControl ──────────────────────────────────────
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabThongTin;
        private System.Windows.Forms.TabPage tabHangHoa;
        private System.Windows.Forms.TabPage tabLichSu;

        // ── Tab 1: Thông tin đơn ────────────────────────────
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
        private System.Windows.Forms.Label lblLblMaDonVC, lblLblKhachHang, lblLblTenNguoiNhan;
        private System.Windows.Forms.Label lblLblSDT, lblLblDiaChiLayHang, lblLblDiaChiGiao;
        private System.Windows.Forms.Label lblLblTGNhan, lblLblTGGiao, lblLblPhiVC;
        private System.Windows.Forms.Label lblLblTrangThai, lblLblYeuCau, lblLblNgayTao;
        private System.Windows.Forms.Label lblValMaDonVC, lblValKhachHang, lblValTenNguoiNhan;
        private System.Windows.Forms.Label lblValSDT, lblValDiaChiLayHang, lblValDiaChiGiao;
        private System.Windows.Forms.Label lblValTGNhan, lblValTGGiao, lblValPhiVC;
        private System.Windows.Forms.Label lblValTrangThai, lblValYeuCau, lblValNgayTao;

        // ── Tab 2: Chi tiết hàng hóa ───────────────────────
        private System.Windows.Forms.DataGridView dgvHangHoa;

        // ── Tab 3: Lịch sử trạng thái ──────────────────────
        private System.Windows.Forms.DataGridView dgvLichSu;

        // ── Nút Đóng ───────────────────────────────────────
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            var fNormal = new System.Drawing.Font("Segoe UI", 10F);
            var fBold   = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            var fTitle  = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            var fLabel  = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            var fValue  = new System.Drawing.Font("Segoe UI", 10.5F);

            // ── Khởi tạo controls ──────────────────────────
            this.pnlHeader   = new System.Windows.Forms.Panel();
            this.lblTitle    = new System.Windows.Forms.Label();
            this.lblMaDon    = new System.Windows.Forms.Label();
            this.tabMain     = new System.Windows.Forms.TabControl();
            this.tabThongTin = new System.Windows.Forms.TabPage();
            this.tabHangHoa  = new System.Windows.Forms.TabPage();
            this.tabLichSu   = new System.Windows.Forms.TabPage();

            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();

            // Labels - Tiêu đề
            this.lblLblMaDonVC      = new System.Windows.Forms.Label();
            this.lblLblKhachHang    = new System.Windows.Forms.Label();
            this.lblLblTenNguoiNhan = new System.Windows.Forms.Label();
            this.lblLblSDT          = new System.Windows.Forms.Label();
            this.lblLblDiaChiLayHang = new System.Windows.Forms.Label();
            this.lblLblDiaChiGiao   = new System.Windows.Forms.Label();
            this.lblLblTGNhan       = new System.Windows.Forms.Label();
            this.lblLblTGGiao       = new System.Windows.Forms.Label();
            this.lblLblPhiVC        = new System.Windows.Forms.Label();
            this.lblLblTrangThai    = new System.Windows.Forms.Label();
            this.lblLblYeuCau       = new System.Windows.Forms.Label();
            this.lblLblNgayTao      = new System.Windows.Forms.Label();

            // Labels - Giá trị
            this.lblValMaDonVC      = new System.Windows.Forms.Label();
            this.lblValKhachHang    = new System.Windows.Forms.Label();
            this.lblValTenNguoiNhan = new System.Windows.Forms.Label();
            this.lblValSDT          = new System.Windows.Forms.Label();
            this.lblValDiaChiLayHang = new System.Windows.Forms.Label();
            this.lblValDiaChiGiao   = new System.Windows.Forms.Label();
            this.lblValTGNhan       = new System.Windows.Forms.Label();
            this.lblValTGGiao       = new System.Windows.Forms.Label();
            this.lblValPhiVC        = new System.Windows.Forms.Label();
            this.lblValTrangThai    = new System.Windows.Forms.Label();
            this.lblValYeuCau       = new System.Windows.Forms.Label();
            this.lblValNgayTao      = new System.Windows.Forms.Label();

            // DataGridViews
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.dgvLichSu  = new System.Windows.Forms.DataGridView();

            // Nút đóng
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnDong   = new System.Windows.Forms.Button();

            // SuspendLayout
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();

            // ═══════════════════════════════════════════════════
            // pnlHeader
            // ═══════════════════════════════════════════════════
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 70;
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Padding   = new System.Windows.Forms.Padding(20, 10, 20, 10);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font     = fTitle;
            this.lblTitle.Text     = "CHI TIẾT ĐƠN VẬN CHUYỂN";
            this.lblTitle.Location = new System.Drawing.Point(20, 10);

            this.lblMaDon.AutoSize  = true;
            this.lblMaDon.Font      = fBold;
            this.lblMaDon.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblMaDon.Location  = new System.Drawing.Point(20, 42);
            this.lblMaDon.Text      = "Mã đơn: ---";

            this.pnlHeader.Controls.Add(this.lblMaDon);
            this.pnlHeader.Controls.Add(this.lblTitle);

            // ═══════════════════════════════════════════════════
            // pnlBottom — Nút Đóng
            // ═══════════════════════════════════════════════════
            this.pnlBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height    = 55;
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.pnlBottom.Padding   = new System.Windows.Forms.Padding(0, 8, 20, 8);

            this.btnDong.Font   = fBold;
            this.btnDong.Text   = "✕ Đóng";
            this.btnDong.Size   = new System.Drawing.Size(120, 38);
            this.btnDong.Dock   = System.Windows.Forms.DockStyle.Right;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            this.pnlBottom.Controls.Add(this.btnDong);

            // ═══════════════════════════════════════════════════
            // tabMain — TabControl
            // ═══════════════════════════════════════════════════
            this.tabMain.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font    = fNormal;
            this.tabMain.Padding = new System.Drawing.Point(12, 6);

            // ─── Tab 1: Thông tin đơn ───────────────────────
            this.tabThongTin.Text      = "📋 Thông tin đơn";
            this.tabThongTin.Padding   = new System.Windows.Forms.Padding(15);
            this.tabThongTin.BackColor = System.Drawing.Color.White;

            // TableLayoutPanel 6 hàng × 4 cột
            this.tlpThongTin.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.ColumnCount  = 4;
            this.tlpThongTin.RowCount     = 6;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));

            // lblLblMaDonVC
            this.lblLblMaDonVC.AutoSize = true; this.lblLblMaDonVC.Font = fLabel; this.lblLblMaDonVC.Text = "Mã đơn VC:"; this.lblLblMaDonVC.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblMaDonVC.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValMaDonVC.AutoSize = true; this.lblValMaDonVC.Font = fValue; this.lblValMaDonVC.Text = "---"; this.lblValMaDonVC.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValMaDonVC.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblKhachHang
            this.lblLblKhachHang.AutoSize = true; this.lblLblKhachHang.Font = fLabel; this.lblLblKhachHang.Text = "Khách hàng:"; this.lblLblKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblKhachHang.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValKhachHang.AutoSize = true; this.lblValKhachHang.Font = fValue; this.lblValKhachHang.Text = "---"; this.lblValKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValKhachHang.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblTenNguoiNhan
            this.lblLblTenNguoiNhan.AutoSize = true; this.lblLblTenNguoiNhan.Font = fLabel; this.lblLblTenNguoiNhan.Text = "Tên người nhận:"; this.lblLblTenNguoiNhan.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblTenNguoiNhan.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValTenNguoiNhan.AutoSize = true; this.lblValTenNguoiNhan.Font = fValue; this.lblValTenNguoiNhan.Text = "---"; this.lblValTenNguoiNhan.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValTenNguoiNhan.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblSDT
            this.lblLblSDT.AutoSize = true; this.lblLblSDT.Font = fLabel; this.lblLblSDT.Text = "SĐT người nhận:"; this.lblLblSDT.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblSDT.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValSDT.AutoSize = true; this.lblValSDT.Font = fValue; this.lblValSDT.Text = "---"; this.lblValSDT.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValSDT.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblDiaChiLayHang
            this.lblLblDiaChiLayHang.AutoSize = true; this.lblLblDiaChiLayHang.Font = fLabel; this.lblLblDiaChiLayHang.Text = "Địa chỉ lấy hàng:"; this.lblLblDiaChiLayHang.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblDiaChiLayHang.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValDiaChiLayHang.AutoSize = true; this.lblValDiaChiLayHang.Font = fValue; this.lblValDiaChiLayHang.Text = "---"; this.lblValDiaChiLayHang.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValDiaChiLayHang.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblDiaChiGiao
            this.lblLblDiaChiGiao.AutoSize = true; this.lblLblDiaChiGiao.Font = fLabel; this.lblLblDiaChiGiao.Text = "Địa chỉ giao:"; this.lblLblDiaChiGiao.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblDiaChiGiao.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValDiaChiGiao.AutoSize = true; this.lblValDiaChiGiao.Font = fValue; this.lblValDiaChiGiao.Text = "---"; this.lblValDiaChiGiao.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValDiaChiGiao.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblTGNhan
            this.lblLblTGNhan.AutoSize = true; this.lblLblTGNhan.Font = fLabel; this.lblLblTGNhan.Text = "TG nhận dự kiến:"; this.lblLblTGNhan.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblTGNhan.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValTGNhan.AutoSize = true; this.lblValTGNhan.Font = fValue; this.lblValTGNhan.Text = "---"; this.lblValTGNhan.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValTGNhan.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblTGGiao
            this.lblLblTGGiao.AutoSize = true; this.lblLblTGGiao.Font = fLabel; this.lblLblTGGiao.Text = "TG giao dự kiến:"; this.lblLblTGGiao.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblTGGiao.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValTGGiao.AutoSize = true; this.lblValTGGiao.Font = fValue; this.lblValTGGiao.Text = "---"; this.lblValTGGiao.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValTGGiao.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblPhiVC
            this.lblLblPhiVC.AutoSize = true; this.lblLblPhiVC.Font = fLabel; this.lblLblPhiVC.Text = "Phí vận chuyển:"; this.lblLblPhiVC.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblPhiVC.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValPhiVC.AutoSize = true; this.lblValPhiVC.Font = fValue; this.lblValPhiVC.Text = "---"; this.lblValPhiVC.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValPhiVC.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblTrangThai
            this.lblLblTrangThai.AutoSize = true; this.lblLblTrangThai.Font = fLabel; this.lblLblTrangThai.Text = "Trạng thái:"; this.lblLblTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblTrangThai.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValTrangThai.AutoSize = true; this.lblValTrangThai.Font = fValue; this.lblValTrangThai.Text = "---"; this.lblValTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValTrangThai.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblYeuCau
            this.lblLblYeuCau.AutoSize = true; this.lblLblYeuCau.Font = fLabel; this.lblLblYeuCau.Text = "Yêu cầu đặc biệt:"; this.lblLblYeuCau.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblYeuCau.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValYeuCau.AutoSize = true; this.lblValYeuCau.Font = fValue; this.lblValYeuCau.Text = "---"; this.lblValYeuCau.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValYeuCau.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            // lblLblNgayTao
            this.lblLblNgayTao.AutoSize = true; this.lblLblNgayTao.Font = fLabel; this.lblLblNgayTao.Text = "Ngày tạo:"; this.lblLblNgayTao.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblLblNgayTao.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblValNgayTao.AutoSize = true; this.lblValNgayTao.Font = fValue; this.lblValNgayTao.Text = "---"; this.lblValNgayTao.Anchor = System.Windows.Forms.AnchorStyles.Left; this.lblValNgayTao.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);

            // Row 0: MaDonVC | KhachHang
            this.tlpThongTin.Controls.Add(this.lblLblMaDonVC,      0, 0);
            this.tlpThongTin.Controls.Add(this.lblValMaDonVC,      1, 0);
            this.tlpThongTin.Controls.Add(this.lblLblKhachHang,    2, 0);
            this.tlpThongTin.Controls.Add(this.lblValKhachHang,    3, 0);
            // Row 1: TenNguoiNhan | SDT
            this.tlpThongTin.Controls.Add(this.lblLblTenNguoiNhan, 0, 1);
            this.tlpThongTin.Controls.Add(this.lblValTenNguoiNhan, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblLblSDT,          2, 1);
            this.tlpThongTin.Controls.Add(this.lblValSDT,          3, 1);
            // Row 2: DiaChiLayHang | DiaChiGiao
            this.tlpThongTin.Controls.Add(this.lblLblDiaChiLayHang, 0, 2);
            this.tlpThongTin.Controls.Add(this.lblValDiaChiLayHang, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblLblDiaChiGiao,    2, 2);
            this.tlpThongTin.Controls.Add(this.lblValDiaChiGiao,    3, 2);
            // Row 3: TGNhan | TGGiao
            this.tlpThongTin.Controls.Add(this.lblLblTGNhan,       0, 3);
            this.tlpThongTin.Controls.Add(this.lblValTGNhan,       1, 3);
            this.tlpThongTin.Controls.Add(this.lblLblTGGiao,       2, 3);
            this.tlpThongTin.Controls.Add(this.lblValTGGiao,       3, 3);
            // Row 4: PhiVC | TrangThai
            this.tlpThongTin.Controls.Add(this.lblLblPhiVC,        0, 4);
            this.tlpThongTin.Controls.Add(this.lblValPhiVC,        1, 4);
            this.tlpThongTin.Controls.Add(this.lblLblTrangThai,    2, 4);
            this.tlpThongTin.Controls.Add(this.lblValTrangThai,    3, 4);
            // Row 5: YeuCau | NgayTao
            this.tlpThongTin.Controls.Add(this.lblLblYeuCau,       0, 5);
            this.tlpThongTin.Controls.Add(this.lblValYeuCau,       1, 5);
            this.tlpThongTin.Controls.Add(this.lblLblNgayTao,      2, 5);
            this.tlpThongTin.Controls.Add(this.lblValNgayTao,      3, 5);

            this.tabThongTin.Controls.Add(this.tlpThongTin);

            // ─── Tab 2: Chi tiết hàng hóa ──────────────────
            this.tabHangHoa.Text      = "📦 Hàng hóa";
            this.tabHangHoa.Padding   = new System.Windows.Forms.Padding(10);
            this.tabHangHoa.BackColor = System.Drawing.Color.White;
            this.dgvHangHoa.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.tabHangHoa.Controls.Add(this.dgvHangHoa);

            // ─── Tab 3: Lịch sử trạng thái ─────────────────
            this.tabLichSu.Text      = "📜 Lịch sử trạng thái";
            this.tabLichSu.Padding   = new System.Windows.Forms.Padding(10);
            this.tabLichSu.BackColor = System.Drawing.Color.White;
            this.dgvLichSu.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.tabLichSu.Controls.Add(this.dgvLichSu);

            // ─── Add tabs ──────────────────────────────────
            this.tabMain.TabPages.AddRange(new System.Windows.Forms.TabPage[] {
                this.tabThongTin, this.tabHangHoa, this.tabLichSu
            });

            // ═══════════════════════════════════════════════════
            // FORM
            // ═══════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize          = new System.Drawing.Size(1200, 700);
            this.MinimumSize         = new System.Drawing.Size(1000, 600);
            this.WindowState         = System.Windows.Forms.FormWindowState.Maximized;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font                = fNormal;

            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);

            this.Name = "FrmChiTietDonVanChuyen";
            this.Text = "Chi tiết đơn vận chuyển";
            this.Load += new System.EventHandler(this.FrmChiTietDonVanChuyen_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
