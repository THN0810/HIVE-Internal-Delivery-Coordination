namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.ThanhToan
{
    partial class FrmThanhToanVC
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvThanhToan;
        private System.Windows.Forms.TextBox txtMaPhieuTT, txtSoTien, txtMaGiaoDich;
        private System.Windows.Forms.ComboBox cmbHinhThuc, cmbTrangThai, cmbDonVC, cmbKhachHang;
        private System.Windows.Forms.Label lblNgayTT;
        private System.Windows.Forms.DateTimePicker dtpNgayTT;
        private System.Windows.Forms.Button btnThem, btnSua, btnLuu, btnHuy, btnLamMoi;
        private System.Windows.Forms.Label lblTitle, lblMa, lblSoTien, lblHinhThuc, lblTrangThai, lblMaGD, lblDonVC, lblKH;
        private System.Windows.Forms.Panel pnlTop, pnlToolbar, pnlBottom, pnlDonCho, pnlMiddle;
        private System.Windows.Forms.FlowLayoutPanel pnlFilter;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.DataGridView dgvDonChoThanhToan;
        private System.Windows.Forms.Label lblHeaderDon, lblHeaderPhieu;

        // Filter controls
        private System.Windows.Forms.Label lblTimKiem, lblLocTrangThai;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnTimKiem, btnBoLoc;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            var fNormal = new System.Drawing.Font("Segoe UI", 10.5F);

            this.dgvThanhToan = new System.Windows.Forms.DataGridView();
            this.dgvDonChoThanhToan = new System.Windows.Forms.DataGridView();
            this.pnlDonCho = new System.Windows.Forms.Panel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.lblHeaderDon = new System.Windows.Forms.Label();
            this.lblHeaderPhieu = new System.Windows.Forms.Label();

            this.txtMaPhieuTT = new System.Windows.Forms.TextBox(); this.txtSoTien = new System.Windows.Forms.TextBox(); this.txtMaGiaoDich = new System.Windows.Forms.TextBox();
            this.cmbHinhThuc = new System.Windows.Forms.ComboBox(); this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.cmbDonVC = new System.Windows.Forms.ComboBox(); this.cmbKhachHang = new System.Windows.Forms.ComboBox();
            
            this.btnThem = new System.Windows.Forms.Button(); this.btnSua = new System.Windows.Forms.Button(); 
            this.btnLuu = new System.Windows.Forms.Button(); this.btnHuy = new System.Windows.Forms.Button(); 
            this.btnLamMoi = new System.Windows.Forms.Button();
            
            this.lblTitle = new System.Windows.Forms.Label(); this.lblMa = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label(); this.lblHinhThuc = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label(); this.lblMaGD = new System.Windows.Forms.Label();
            this.lblDonVC = new System.Windows.Forms.Label(); this.lblKH = new System.Windows.Forms.Label();
            this.lblNgayTT = new System.Windows.Forms.Label(); this.dtpNgayTT = new System.Windows.Forms.DateTimePicker();
            
            this.pnlTop = new System.Windows.Forms.Panel(); this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBottom = new System.Windows.Forms.Panel(); this.grpThongTin = new System.Windows.Forms.GroupBox();

            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).BeginInit(); 
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonChoThanhToan)).BeginInit(); 
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
            this.lblTitle.Text = "QUẢN LÝ THANH TOÁN";

            // ═══════════════════════════════════════════════════
            // pnlToolbar — Thêm | Sửa | Lưu | Hủy | Làm mới
            // ═══════════════════════════════════════════════════
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top; 
            this.pnlToolbar.Height = 65; 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            
            this.btnThem.Location = new System.Drawing.Point(20, 8); this.btnThem.Size = new System.Drawing.Size(120, 45); 
            this.btnThem.Text = "＋ Thêm"; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            
            this.btnSua.Location = new System.Drawing.Point(150, 8); this.btnSua.Size = new System.Drawing.Size(120, 45); 
            this.btnSua.Text = "✎ Sửa"; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            
            this.btnLuu.Location = new System.Drawing.Point(280, 8); this.btnLuu.Size = new System.Drawing.Size(120, 45); 
            this.btnLuu.Text = "💾 Lưu"; this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            
            this.btnHuy.Location = new System.Drawing.Point(410, 8); this.btnHuy.Size = new System.Drawing.Size(160, 45); 
            this.btnHuy.Text = "↩ Hủy thao tác"; this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            
            this.btnLamMoi.Location = new System.Drawing.Point(580, 8); this.btnLamMoi.Size = new System.Drawing.Size(120, 45); 
            this.btnLamMoi.Text = "⟳ Làm mới"; this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            
            this.pnlToolbar.Controls.Add(this.btnLamMoi); 
            this.pnlToolbar.Controls.Add(this.btnHuy); 
            this.pnlToolbar.Controls.Add(this.btnLuu); 
            this.pnlToolbar.Controls.Add(this.btnSua); 
            this.pnlToolbar.Controls.Add(this.btnThem);

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
            
            this.lblLocTrangThai.AutoSize = true; this.lblLocTrangThai.Font = fNormal; this.lblLocTrangThai.Text = "Trạng thái TT:"; this.lblLocTrangThai.Margin = new System.Windows.Forms.Padding(15, 5, 5, 0);
            this.cboLocTrangThai.Font = fNormal; this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboLocTrangThai.Size = new System.Drawing.Size(250, 30);

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
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBottom.Controls.Add(this.grpThongTin);
            
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); 
            this.grpThongTin.Text = "Thông tin phiếu thanh toán";
            
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
            this.lblMa.Dock = System.Windows.Forms.DockStyle.Fill; this.lblMa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblMa.Font = lf; this.lblMa.Text = "Mã phiếu:";
            this.txtMaPhieuTT.Font = tf; this.txtMaPhieuTT.ReadOnly = true; this.txtMaPhieuTT.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblKH.Dock = System.Windows.Forms.DockStyle.Fill; this.lblKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblKH.Font = lf; this.lblKH.Text = "Khách hàng:";
            this.cmbKhachHang.Font = tf; this.cmbKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbKhachHang.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblHinhThuc.Dock = System.Windows.Forms.DockStyle.Fill; this.lblHinhThuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblHinhThuc.Font = lf; this.lblHinhThuc.Text = "Hình thức:";
            this.cmbHinhThuc.Font = tf; this.cmbHinhThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbHinhThuc.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblTrangThai.Font = lf; this.lblTrangThai.Text = "Trạng thái:";
            this.cmbTrangThai.Font = tf; this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            // Cột Phải
            this.lblDonVC.Dock = System.Windows.Forms.DockStyle.Fill; this.lblDonVC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblDonVC.Font = lf; this.lblDonVC.Text = "Đơn VC:";
            this.cmbDonVC.Font = tf; this.cmbDonVC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbDonVC.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cmbDonVC.SelectedIndexChanged += new System.EventHandler(this.cmbDonVC_SelectedIndexChanged);
            
            this.lblSoTien.Dock = System.Windows.Forms.DockStyle.Fill; this.lblSoTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblSoTien.Font = lf; this.lblSoTien.Text = "Số tiền:";
            this.txtSoTien.Font = tf; this.txtSoTien.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblMaGD.Dock = System.Windows.Forms.DockStyle.Fill; this.lblMaGD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblMaGD.Font = lf; this.lblMaGD.Text = "Mã GD:";
            this.txtMaGiaoDich.Font = tf; this.txtMaGiaoDich.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblNgayTT.Dock = System.Windows.Forms.DockStyle.Fill; this.lblNgayTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblNgayTT.Font = lf; this.lblNgayTT.Text = "Ngày TT:";
            this.dtpNgayTT.Font = tf; this.dtpNgayTT.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpNgayTT.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.tlpThongTin.Controls.Add(this.lblMa, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtMaPhieuTT, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblDonVC, 2, 0);
            this.tlpThongTin.Controls.Add(this.cmbDonVC, 3, 0);
            
            this.tlpThongTin.Controls.Add(this.lblKH, 0, 1);
            this.tlpThongTin.Controls.Add(this.cmbKhachHang, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblSoTien, 2, 1);
            this.tlpThongTin.Controls.Add(this.txtSoTien, 3, 1);
            
            this.tlpThongTin.Controls.Add(this.lblHinhThuc, 0, 2);
            this.tlpThongTin.Controls.Add(this.cmbHinhThuc, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblMaGD, 2, 2);
            this.tlpThongTin.Controls.Add(this.txtMaGiaoDich, 3, 2);
            
            this.tlpThongTin.Controls.Add(this.lblTrangThai, 0, 3);
            this.tlpThongTin.Controls.Add(this.cmbTrangThai, 1, 3);
            this.tlpThongTin.Controls.Add(this.lblNgayTT, 2, 3);
            this.tlpThongTin.Controls.Add(this.dtpNgayTT, 3, 3);
            
            this.grpThongTin.Controls.Add(this.tlpThongTin);
                
            // ═══════════════════════════════════════════════════
            // pnlDonCho — Bảng đơn chờ thanh toán
            // ═══════════════════════════════════════════════════
            this.pnlDonCho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDonCho.Height = 190;
            this.pnlDonCho.BackColor = System.Drawing.Color.White;
            this.pnlDonCho.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);

            this.lblHeaderDon.AutoSize = false;
            this.lblHeaderDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderDon.Height = 30;
            this.lblHeaderDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderDon.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblHeaderDon.Text = "  📦  DANH SÁCH ĐƠN CHỜ THANH TOÁN";
            this.lblHeaderDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeaderDon.BackColor = System.Drawing.Color.FromArgb(227, 242, 253);

            this.dgvDonChoThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            // The event will be wired in cs code

            this.pnlDonCho.Controls.Add(this.dgvDonChoThanhToan);
            this.pnlDonCho.Controls.Add(this.lblHeaderDon);

            // ═══════════════════════════════════════════════════
            // pnlMiddle — Bảng phiếu thanh toán
            // ═══════════════════════════════════════════════════
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.BackColor = System.Drawing.Color.White;
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);

            this.lblHeaderPhieu.AutoSize = false;
            this.lblHeaderPhieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderPhieu.Height = 30;
            this.lblHeaderPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPhieu.ForeColor = System.Drawing.Color.FromArgb(13, 33, 55);
            this.lblHeaderPhieu.Text = "  📋  DANH SÁCH PHIẾU THANH TOÁN";
            this.lblHeaderPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeaderPhieu.BackColor = System.Drawing.Color.FromArgb(227, 242, 253);

            this.dgvThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThanhToan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThanhToan_CellClick);

            this.pnlMiddle.Controls.Add(this.dgvThanhToan);
            this.pnlMiddle.Controls.Add(this.lblHeaderPhieu);

            // ═══════════════════════════════════════════════════
            // FrmThanhToanVC
            // ═══════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F); 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 800);
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            
            // Thứ tự Add: Fill trước, rồi mới Add các Dock khác
            this.Controls.Add(this.pnlMiddle); 
            this.Controls.Add(this.pnlBottom); 
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlDonCho);
            this.Controls.Add(this.pnlToolbar); 
            this.Controls.Add(this.pnlTop);
            
            this.Name = "FrmThanhToanVC"; 
            this.Text = "Thanh toán vận chuyển";
            this.Load += new System.EventHandler(this.FrmThanhToanVC_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).EndInit(); 
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonChoThanhToan)).EndInit(); 
            this.ResumeLayout(false);
        }
        
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
    }
}
