namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.KhachHang
{
    partial class FrmKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtMaKH, txtTenKH, txtSDTKH, txtEmailKH, txtDiaChiKH, txtMST;
        private System.Windows.Forms.ComboBox cmbLoaiKH, cmbTrangThai;
        private System.Windows.Forms.Button btnThem, btnSua, btnLuu, btnHuy, btnLamMoi;
        private System.Windows.Forms.Label lblMaKH, lblTenKH, lblSDTKH, lblEmailKH, lblDiaChiKH, lblMST, lblLoaiKH, lblTrangThai;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTop, pnlToolbar, pnlFilter, pnlBottom;
        
        // Filter controls
        private System.Windows.Forms.Label lblTimKiem, lblLocLoaiKH, lblLocTrangThai;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocLoaiKH, cboLocTrangThai;
        private System.Windows.Forms.Button btnTimKiem, btnBoLoc;
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            var fNormal = new System.Drawing.Font("Segoe UI", 10.5F);
            
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaKH = new System.Windows.Forms.TextBox(); this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtSDTKH = new System.Windows.Forms.TextBox(); this.txtEmailKH = new System.Windows.Forms.TextBox();
            this.txtDiaChiKH = new System.Windows.Forms.TextBox(); this.txtMST = new System.Windows.Forms.TextBox();
            this.cmbLoaiKH = new System.Windows.Forms.ComboBox(); this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button(); this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button(); this.btnHuy = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            
            this.lblMaKH = new System.Windows.Forms.Label(); this.lblTenKH = new System.Windows.Forms.Label();
            this.lblSDTKH = new System.Windows.Forms.Label(); this.lblEmailKH = new System.Windows.Forms.Label();
            this.lblDiaChiKH = new System.Windows.Forms.Label(); this.lblMST = new System.Windows.Forms.Label();
            this.lblLoaiKH = new System.Windows.Forms.Label(); this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocLoaiKH = new System.Windows.Forms.Label();
            this.cboLocLoaiKH = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
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
            this.lblTitle.Text = "QUẢN LÝ KHÁCH HÀNG";

            // ═══════════════════════════════════════════════════
            // pnlToolbar — Thêm | Sửa | Lưu | Hủy | Làm mới
            // ═══════════════════════════════════════════════════
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 65;
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            
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

            this.lblTimKiem.AutoSize = true; this.lblTimKiem.Font = fNormal; this.lblTimKiem.Text = "Tìm kiếm:"; this.lblTimKiem.Margin = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.txtTimKiem.Font = fNormal; this.txtTimKiem.Size = new System.Drawing.Size(200, 30);
            
            this.lblLocLoaiKH.AutoSize = true; this.lblLocLoaiKH.Font = fNormal; this.lblLocLoaiKH.Text = "Loại KH:"; this.lblLocLoaiKH.Margin = new System.Windows.Forms.Padding(15, 5, 5, 0);
            this.cboLocLoaiKH.Font = fNormal; this.cboLocLoaiKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboLocLoaiKH.Size = new System.Drawing.Size(250, 30);
            
            this.lblLocTrangThai.AutoSize = true; this.lblLocTrangThai.Font = fNormal; this.lblLocTrangThai.Text = "Trạng thái:"; this.lblLocTrangThai.Margin = new System.Windows.Forms.Padding(15, 5, 5, 0);
            this.cboLocTrangThai.Font = fNormal; this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboLocTrangThai.Size = new System.Drawing.Size(150, 30);

            this.btnTimKiem.Font = fNormal; this.btnTimKiem.Size = new System.Drawing.Size(140, 45); this.btnTimKiem.Text = "🔍 Tìm"; this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click); this.btnTimKiem.Margin = new System.Windows.Forms.Padding(15, 0, 5, 0);
            this.btnBoLoc.Font = fNormal; this.btnBoLoc.Size = new System.Drawing.Size(140, 45); this.btnBoLoc.Text = "✕ Bỏ lọc"; this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click); this.btnBoLoc.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);

            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTimKiem, this.txtTimKiem,
                this.lblLocLoaiKH, this.cboLocLoaiKH,
                this.lblLocTrangThai, this.cboLocTrangThai,
                this.btnTimKiem, this.btnBoLoc
            });

            // ═══════════════════════════════════════════════════
            // pnlBottom — GroupBox input 2 cột (Dock Bottom)
            // ═══════════════════════════════════════════════════
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 230;
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(15, 5, 15, 10);
            this.pnlBottom.Controls.Add(this.grpThongTin);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Text = "Thông tin khách hàng";

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

            // Input fields — 2 cột, 4 hàng
            System.Drawing.Font lf = new System.Drawing.Font("Segoe UI", 10F);
            System.Drawing.Font tf = new System.Drawing.Font("Segoe UI", 11F);

            // Row 1
            this.lblMaKH.Dock = System.Windows.Forms.DockStyle.Fill; this.lblMaKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblMaKH.Font = lf; this.lblMaKH.Text = "Mã KH:";
            this.txtMaKH.Font = tf; this.txtMaKH.ReadOnly = true; this.txtMaKH.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblTenKH.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTenKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblTenKH.Font = lf; this.lblTenKH.Text = "Tên KH:";
            this.txtTenKH.Font = tf; this.txtTenKH.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            // Row 2
            this.lblSDTKH.Dock = System.Windows.Forms.DockStyle.Fill; this.lblSDTKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblSDTKH.Font = lf; this.lblSDTKH.Text = "SĐT:";
            this.txtSDTKH.Font = tf; this.txtSDTKH.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblEmailKH.Dock = System.Windows.Forms.DockStyle.Fill; this.lblEmailKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblEmailKH.Font = lf; this.lblEmailKH.Text = "Email:";
            this.txtEmailKH.Font = tf; this.txtEmailKH.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            // Row 3
            this.lblDiaChiKH.Dock = System.Windows.Forms.DockStyle.Fill; this.lblDiaChiKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblDiaChiKH.Font = lf; this.lblDiaChiKH.Text = "Địa chỉ:";
            this.txtDiaChiKH.Font = tf; this.txtDiaChiKH.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblMST.Dock = System.Windows.Forms.DockStyle.Fill; this.lblMST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblMST.Font = lf; this.lblMST.Text = "Mã số thuế:";
            this.txtMST.Font = tf; this.txtMST.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            // Row 4
            this.lblLoaiKH.Dock = System.Windows.Forms.DockStyle.Fill; this.lblLoaiKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblLoaiKH.Font = lf; this.lblLoaiKH.Text = "Loại KH:";
            this.cmbLoaiKH.Font = tf; this.cmbLoaiKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbLoaiKH.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblTrangThai.Font = lf; this.lblTrangThai.Text = "Trạng thái:";
            this.cmbTrangThai.Font = tf; this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.tlpThongTin.Controls.Add(this.lblMaKH, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtMaKH, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblTenKH, 2, 0);
            this.tlpThongTin.Controls.Add(this.txtTenKH, 3, 0);

            this.tlpThongTin.Controls.Add(this.lblSDTKH, 0, 1);
            this.tlpThongTin.Controls.Add(this.txtSDTKH, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblEmailKH, 2, 1);
            this.tlpThongTin.Controls.Add(this.txtEmailKH, 3, 1);

            this.tlpThongTin.Controls.Add(this.lblDiaChiKH, 0, 2);
            this.tlpThongTin.Controls.Add(this.txtDiaChiKH, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblMST, 2, 2);
            this.tlpThongTin.Controls.Add(this.txtMST, 3, 2);

            this.tlpThongTin.Controls.Add(this.lblLoaiKH, 0, 3);
            this.tlpThongTin.Controls.Add(this.cmbLoaiKH, 1, 3);
            this.tlpThongTin.Controls.Add(this.lblTrangThai, 2, 3);
            this.tlpThongTin.Controls.Add(this.cmbTrangThai, 3, 3);

            this.grpThongTin.Controls.Add(this.tlpThongTin);

            // ═══════════════════════════════════════════════════
            // dgvKhachHang
            // ═══════════════════════════════════════════════════
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);

            // ═══════════════════════════════════════════════════
            // FrmKhachHang
            // ═══════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmKhachHang";
            this.Text = "Quản lý Khách hàng";
            this.Load += new System.EventHandler(this.FrmKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

