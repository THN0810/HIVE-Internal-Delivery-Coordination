namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.HoaDon
{
    partial class FrmHoaDonVC
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtMaHD, txtKhachHang, txtTongTruocThue, txtThueVAT, txtTongSauThue;
        private System.Windows.Forms.ComboBox cmbTrangThai, cmbPhieuTT;
        private System.Windows.Forms.DateTimePicker dtpNgayPhatHanh;
        private System.Windows.Forms.Button btnPhatHanhHD, btnHuyHD, btnXemChiTiet, btnXuatHoaDon, btnLamMoi;
        private System.Windows.Forms.Label lblTitle, lblMaHD, lblKhachHang, lblNgayPH, lblTrangThai, lblPhieuTT, lblTruocThue, lblVAT, lblSauThue;
        private System.Windows.Forms.Panel pnlTop, pnlToolbar, pnlBottom, pnlPhieuCho, pnlMiddle;
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
        private System.Windows.Forms.DataGridView dgvPhieuChoXuatHD;
        private System.Windows.Forms.Label lblHeaderPhieuCho, lblHeaderHoaDon;
        private System.Windows.Forms.FlowLayoutPanel pnlFilter;

        // Filter controls
        private System.Windows.Forms.Label lblTimKiem, lblLocTrangThai;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnTimKiem, btnBoLoc;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            var fNormal = new System.Drawing.Font("Segoe UI", 10.5F);

            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.txtKhachHang = new System.Windows.Forms.TextBox();
            this.dtpNgayPhatHanh = new System.Windows.Forms.DateTimePicker();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.cmbPhieuTT = new System.Windows.Forms.ComboBox();
            this.txtTongTruocThue = new System.Windows.Forms.TextBox();
            this.txtThueVAT = new System.Windows.Forms.TextBox();
            this.txtTongSauThue = new System.Windows.Forms.TextBox();
            
            this.btnPhatHanhHD = new System.Windows.Forms.Button();
            this.btnHuyHD = new System.Windows.Forms.Button();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            
            this.pnlPhieuCho = new System.Windows.Forms.Panel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.dgvPhieuChoXuatHD = new System.Windows.Forms.DataGridView();
            this.lblHeaderPhieuCho = new System.Windows.Forms.Label();
            this.lblHeaderHoaDon = new System.Windows.Forms.Label();
            
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblNgayPH = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblPhieuTT = new System.Windows.Forms.Label();
            this.lblTruocThue = new System.Windows.Forms.Label();
            this.lblVAT = new System.Windows.Forms.Label();
            this.lblSauThue = new System.Windows.Forms.Label();
            
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChoXuatHD)).BeginInit();
            this.SuspendLayout();

            // ═══════════════════════════════════════════════════
            // pnlTop — Tiêu đề
            // ═══════════════════════════════════════════════════
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top; 
            this.pnlTop.Height = 55; 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            
            this.lblTitle.AutoSize = true; 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 12); 
            this.lblTitle.Text = "QUẢN LÝ HÓA ĐƠN VẬN CHUYỂN";

            // ═══════════════════════════════════════════════════
            // pnlToolbar — Phát hành | Hủy | Xuất | Làm mới
            // ═══════════════════════════════════════════════════
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top; 
            this.pnlToolbar.Height = 65; 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            
            this.btnPhatHanhHD.Location = new System.Drawing.Point(20, 8); this.btnPhatHanhHD.Size = new System.Drawing.Size(160, 45); 
            this.btnPhatHanhHD.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnPhatHanhHD.Text = "➕ Phát hành HĐ"; this.btnPhatHanhHD.Click += new System.EventHandler(this.btnPhatHanhHD_Click);
            
            this.btnHuyHD.Location = new System.Drawing.Point(190, 8); this.btnHuyHD.Size = new System.Drawing.Size(140, 45); 
            this.btnHuyHD.Text = "🚫 Hủy HĐ"; this.btnHuyHD.Click += new System.EventHandler(this.btnHuyHD_Click);
            
            this.btnXemChiTiet.Location = new System.Drawing.Point(340, 8); this.btnXemChiTiet.Size = new System.Drawing.Size(160, 45); 
            this.btnXemChiTiet.Text = "👁 Xem chi tiết"; this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            
            this.btnXuatHoaDon.Location = new System.Drawing.Point(510, 8); this.btnXuatHoaDon.Size = new System.Drawing.Size(140, 45); 
            this.btnXuatHoaDon.Text = "⬇ Xuất PDF"; this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            
            this.btnLamMoi.Location = new System.Drawing.Point(660, 8); this.btnLamMoi.Size = new System.Drawing.Size(120, 45); 
            this.btnLamMoi.Text = "⟳ Làm mới"; this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            
            this.pnlToolbar.Controls.Add(this.btnLamMoi); 
            this.pnlToolbar.Controls.Add(this.btnXuatHoaDon); 
            this.pnlToolbar.Controls.Add(this.btnXemChiTiet);
            this.pnlToolbar.Controls.Add(this.btnHuyHD); 
            this.pnlToolbar.Controls.Add(this.btnPhatHanhHD);

            // ═══════════════════════════════════════════════════
            // pnlFilter — Tìm kiếm và Lọc
            // ═══════════════════════════════════════════════════
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Height = 70;
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlFilter.WrapContents = false;

            this.lblTimKiem.AutoSize = true; this.lblTimKiem.Font = fNormal; this.lblTimKiem.Text = "Tìm kiếm:"; this.lblTimKiem.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.txtTimKiem.Font = fNormal; this.txtTimKiem.Size = new System.Drawing.Size(250, 30);
            
            this.lblLocTrangThai.AutoSize = true; this.lblLocTrangThai.Font = fNormal; this.lblLocTrangThai.Text = "Trạng thái HĐ:"; this.lblLocTrangThai.Margin = new System.Windows.Forms.Padding(15, 5, 5, 0);
            this.cboLocTrangThai.Font = fNormal; this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboLocTrangThai.Size = new System.Drawing.Size(150, 30);

            this.btnTimKiem.Font = fNormal; this.btnTimKiem.Size = new System.Drawing.Size(140, 45); this.btnTimKiem.Text = "🔍 Tìm"; this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click); this.btnTimKiem.Margin = new System.Windows.Forms.Padding(15, 0, 5, 0);
            this.btnBoLoc.Font = fNormal; this.btnBoLoc.Size = new System.Drawing.Size(140, 45); this.btnBoLoc.Text = "✕ Bỏ lọc"; this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click); this.btnBoLoc.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);

            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTimKiem, this.txtTimKiem,
                this.lblLocTrangThai, this.cboLocTrangThai,
                this.btnTimKiem, this.btnBoLoc
            });

            // ═══════════════════════════════════════════════════
            // pnlBottom — GroupBox input
            // ═══════════════════════════════════════════════════
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom; 
            this.pnlBottom.Height = 220;
            this.pnlBottom.BackColor = System.Drawing.Color.White; 
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(15, 5, 15, 10);
            this.pnlBottom.Controls.Add(this.grpThongTin);

            // ── grpThongTin ────────────────────────────────────
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill; 
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); 
            this.grpThongTin.Text = "Thông tin hóa đơn";

            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.RowCount = 4;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongTin.Padding = new System.Windows.Forms.Padding(10, 20, 30, 10);
            
            System.Drawing.Font lf = new System.Drawing.Font("Segoe UI", 10F); 
            System.Drawing.Font tf = new System.Drawing.Font("Segoe UI", 11F);
            
            // Cột Trái
            this.lblMaHD.Dock = System.Windows.Forms.DockStyle.Fill; this.lblMaHD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblMaHD.Font = lf; this.lblMaHD.Text = "Mã hóa đơn:";
            this.txtMaHD.Font = tf; this.txtMaHD.ReadOnly = true; this.txtMaHD.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblKhachHang.Dock = System.Windows.Forms.DockStyle.Fill; this.lblKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblKhachHang.Font = lf; this.lblKhachHang.Text = "Khách hàng:";
            this.txtKhachHang.Font = tf; this.txtKhachHang.ReadOnly = true; this.txtKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblNgayPH.Dock = System.Windows.Forms.DockStyle.Fill; this.lblNgayPH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblNgayPH.Font = lf; this.lblNgayPH.Text = "Ngày PH:";
            this.dtpNgayPhatHanh.Font = tf; this.dtpNgayPhatHanh.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpNgayPhatHanh.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblTrangThai.Font = lf; this.lblTrangThai.Text = "Trạng thái:";
            this.cmbTrangThai.Font = tf; this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            // Cột Phải
            this.lblPhieuTT.Dock = System.Windows.Forms.DockStyle.Fill; this.lblPhieuTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblPhieuTT.Font = lf; this.lblPhieuTT.Text = "Phiếu TT:";
            this.cmbPhieuTT.Font = tf; this.cmbPhieuTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbPhieuTT.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblTruocThue.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTruocThue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblTruocThue.Font = lf; this.lblTruocThue.Text = "Trước thuế:";
            this.txtTongTruocThue.Font = tf; this.txtTongTruocThue.ReadOnly = true; this.txtTongTruocThue.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right; this.txtTongTruocThue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            
            this.lblVAT.Dock = System.Windows.Forms.DockStyle.Fill; this.lblVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblVAT.Font = lf; this.lblVAT.Text = "Thuế VAT (%):";
            this.txtThueVAT.Font = tf; this.txtThueVAT.Text = "8"; this.txtThueVAT.TextChanged += new System.EventHandler(this.txtThueVAT_TextChanged); this.txtThueVAT.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right; this.txtThueVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            
            this.lblSauThue.Dock = System.Windows.Forms.DockStyle.Fill; this.lblSauThue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblSauThue.Font = lf; this.lblSauThue.Text = "Sau thuế:";
            this.txtTongSauThue.Font = tf; this.txtTongSauThue.ReadOnly = true; this.txtTongSauThue.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right; this.txtTongSauThue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            
            this.tlpThongTin.Controls.Add(this.lblMaHD, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtMaHD, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblPhieuTT, 2, 0);
            this.tlpThongTin.Controls.Add(this.cmbPhieuTT, 3, 0);

            this.tlpThongTin.Controls.Add(this.lblKhachHang, 0, 1);
            this.tlpThongTin.Controls.Add(this.txtKhachHang, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblTruocThue, 2, 1);
            this.tlpThongTin.Controls.Add(this.txtTongTruocThue, 3, 1);

            this.tlpThongTin.Controls.Add(this.lblNgayPH, 0, 2);
            this.tlpThongTin.Controls.Add(this.dtpNgayPhatHanh, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblVAT, 2, 2);
            this.tlpThongTin.Controls.Add(this.txtThueVAT, 3, 2);

            this.tlpThongTin.Controls.Add(this.lblTrangThai, 0, 3);
            this.tlpThongTin.Controls.Add(this.cmbTrangThai, 1, 3);
            this.tlpThongTin.Controls.Add(this.lblSauThue, 2, 3);
            this.tlpThongTin.Controls.Add(this.txtTongSauThue, 3, 3);

            this.grpThongTin.Controls.Add(this.tlpThongTin);

            // ═══════════════════════════════════════════════════
            // pnlPhieuCho — Bảng phiếu chờ xuất hóa đơn
            // ═══════════════════════════════════════════════════
            this.pnlPhieuCho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPhieuCho.Height = 160;
            this.pnlPhieuCho.BackColor = System.Drawing.Color.White;
            this.pnlPhieuCho.Padding = new System.Windows.Forms.Padding(15, 0, 15, 5);

            this.lblHeaderPhieuCho.AutoSize = false;
            this.lblHeaderPhieuCho.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderPhieuCho.Height = 30;
            this.lblHeaderPhieuCho.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPhieuCho.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblHeaderPhieuCho.Text = "  📋  DANH SÁCH PHIẾU THANH TOÁN CHỜ XUẤT HÓA ĐƠN";
            this.lblHeaderPhieuCho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeaderPhieuCho.BackColor = System.Drawing.Color.FromArgb(227, 242, 253);

            this.dgvPhieuChoXuatHD.Dock = System.Windows.Forms.DockStyle.Fill;

            this.pnlPhieuCho.Controls.Add(this.dgvPhieuChoXuatHD);
            this.pnlPhieuCho.Controls.Add(this.lblHeaderPhieuCho);

            // ═══════════════════════════════════════════════════
            // pnlMiddle — Bảng hóa đơn vận chuyển
            // ═══════════════════════════════════════════════════
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.BackColor = System.Drawing.Color.White;
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(15, 0, 15, 5);

            this.lblHeaderHoaDon.AutoSize = false;
            this.lblHeaderHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderHoaDon.Height = 30;
            this.lblHeaderHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderHoaDon.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblHeaderHoaDon.Text = "  📄  DANH SÁCH HÓA ĐƠN VẬN CHUYỂN";
            this.lblHeaderHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeaderHoaDon.BackColor = System.Drawing.Color.FromArgb(227, 242, 253);

            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);

            this.pnlMiddle.Controls.Add(this.dgvHoaDon);
            this.pnlMiddle.Controls.Add(this.lblHeaderHoaDon);

            // ═══════════════════════════════════════════════════
            // dgvHoaDon
            // ═══════════════════════════════════════════════════
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);
            this.dgvHoaDon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellDoubleClick);

            // ═══════════════════════════════════════════════════
            // FrmHoaDonVC
            // ═══════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F); 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            
            this.Controls.Add(this.pnlMiddle); 
            this.Controls.Add(this.pnlBottom); 
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlPhieuCho);
            this.Controls.Add(this.pnlToolbar); 
            this.Controls.Add(this.pnlTop);
            
            this.Name = "FrmHoaDonVC"; 
            this.Text = "Hóa đơn vận chuyển";
            this.Load += new System.EventHandler(this.FrmHoaDonVC_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChoXuatHD)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
