namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.NguonLuc
{
    partial class FrmTaiXe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTaiXe;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtMaNV, txtHoTenNV, txtCCCDNV, txtSDTNV, txtEmailNV, txtSoBangLai;
        private System.Windows.Forms.ComboBox cmbHangBangLai, cmbTrangThai;
        private System.Windows.Forms.DateTimePicker dtpNgayHHBangLai;
        private System.Windows.Forms.Button btnThem, btnSua, btnLuu, btnHuy, btnLamMoi;
        private System.Windows.Forms.Label lblMaNV, lblHoTenNV, lblCCCDNV, lblSDTNV, lblEmailNV, lblSoBangLai, lblHangBangLai, lblNgayHHBangLai, lblTrangThai;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTop, pnlToolbar, pnlFilter, pnlBottom;
        
        // Filter controls
        private System.Windows.Forms.Label lblTimKiem, lblLocTrangThai;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnTimKiem, btnBoLoc;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            var fNormal = new System.Drawing.Font("Segoe UI", 10.5F);
            
            this.dgvTaiXe = new System.Windows.Forms.DataGridView();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtMaNV = new System.Windows.Forms.TextBox(); this.txtHoTenNV = new System.Windows.Forms.TextBox();
            this.txtCCCDNV = new System.Windows.Forms.TextBox(); this.txtSDTNV = new System.Windows.Forms.TextBox();
            this.txtEmailNV = new System.Windows.Forms.TextBox(); this.txtSoBangLai = new System.Windows.Forms.TextBox();
            this.cmbHangBangLai = new System.Windows.Forms.ComboBox(); this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.dtpNgayHHBangLai = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button(); this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button(); this.btnHuy = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            
            this.lblMaNV = new System.Windows.Forms.Label(); this.lblHoTenNV = new System.Windows.Forms.Label();
            this.lblCCCDNV = new System.Windows.Forms.Label(); this.lblSDTNV = new System.Windows.Forms.Label();
            this.lblEmailNV = new System.Windows.Forms.Label(); this.lblSoBangLai = new System.Windows.Forms.Label();
            this.lblHangBangLai = new System.Windows.Forms.Label(); this.lblNgayHHBangLai = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiXe)).BeginInit();
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
            this.lblTitle.Text = "QUẢN LÝ TÀI XẾ";

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
            this.txtTimKiem.Font = fNormal; this.txtTimKiem.Size = new System.Drawing.Size(250, 30);
            
            this.lblLocTrangThai.AutoSize = true; this.lblLocTrangThai.Font = fNormal; this.lblLocTrangThai.Text = "Trạng thái:"; this.lblLocTrangThai.Margin = new System.Windows.Forms.Padding(15, 5, 5, 0);
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
            this.pnlBottom.Height = 250;
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(15, 5, 15, 10);
            
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBottom.Controls.Add(this.grpThongTin);

            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Text = "Thông tin tài xế";
            
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.RowCount = 5;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpThongTin.Padding = new System.Windows.Forms.Padding(10, 20, 30, 10);

            System.Drawing.Font lf = new System.Drawing.Font("Segoe UI", 10F);
            System.Drawing.Font tf = new System.Drawing.Font("Segoe UI", 11F);
            // Cột Trái
            this.lblMaNV.Dock = System.Windows.Forms.DockStyle.Fill; this.lblMaNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblMaNV.Font = lf; this.lblMaNV.Text = "Mã tài xế:";
            this.txtMaNV.Font = tf; this.txtMaNV.ReadOnly = true; this.txtMaNV.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblCCCDNV.Dock = System.Windows.Forms.DockStyle.Fill; this.lblCCCDNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblCCCDNV.Font = lf; this.lblCCCDNV.Text = "Số CCCD:";
            this.txtCCCDNV.Font = tf; this.txtCCCDNV.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblEmailNV.Dock = System.Windows.Forms.DockStyle.Fill; this.lblEmailNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblEmailNV.Font = lf; this.lblEmailNV.Text = "Email:";
            this.txtEmailNV.Font = tf; this.txtEmailNV.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblHangBangLai.Dock = System.Windows.Forms.DockStyle.Fill; this.lblHangBangLai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblHangBangLai.Font = lf; this.lblHangBangLai.Text = "Hạng Bằng Lái:";
            this.cmbHangBangLai.Font = tf; this.cmbHangBangLai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbHangBangLai.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblTrangThai.Font = lf; this.lblTrangThai.Text = "Trạng thái:";
            this.cmbTrangThai.Font = tf; this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbTrangThai.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Cột Phải
            this.lblHoTenNV.Dock = System.Windows.Forms.DockStyle.Fill; this.lblHoTenNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblHoTenNV.Font = lf; this.lblHoTenNV.Text = "Họ tên:";
            this.txtHoTenNV.Font = tf; this.txtHoTenNV.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblSDTNV.Dock = System.Windows.Forms.DockStyle.Fill; this.lblSDTNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblSDTNV.Font = lf; this.lblSDTNV.Text = "SĐT:";
            this.txtSDTNV.Font = tf; this.txtSDTNV.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblSoBangLai.Dock = System.Windows.Forms.DockStyle.Fill; this.lblSoBangLai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblSoBangLai.Font = lf; this.lblSoBangLai.Text = "Số Bằng Lái:";
            this.txtSoBangLai.Font = tf; this.txtSoBangLai.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.lblNgayHHBangLai.Dock = System.Windows.Forms.DockStyle.Fill; this.lblNgayHHBangLai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblNgayHHBangLai.Font = lf; this.lblNgayHHBangLai.Text = "Ngày HH Bằng Lái:";
            this.dtpNgayHHBangLai.Font = tf; this.dtpNgayHHBangLai.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpNgayHHBangLai.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.tlpThongTin.Controls.Add(this.lblMaNV, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtMaNV, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblHoTenNV, 2, 0);
            this.tlpThongTin.Controls.Add(this.txtHoTenNV, 3, 0);

            this.tlpThongTin.Controls.Add(this.lblCCCDNV, 0, 1);
            this.tlpThongTin.Controls.Add(this.txtCCCDNV, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblSDTNV, 2, 1);
            this.tlpThongTin.Controls.Add(this.txtSDTNV, 3, 1);

            this.tlpThongTin.Controls.Add(this.lblEmailNV, 0, 2);
            this.tlpThongTin.Controls.Add(this.txtEmailNV, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblSoBangLai, 2, 2);
            this.tlpThongTin.Controls.Add(this.txtSoBangLai, 3, 2);

            this.tlpThongTin.Controls.Add(this.lblHangBangLai, 0, 3);
            this.tlpThongTin.Controls.Add(this.cmbHangBangLai, 1, 3);
            this.tlpThongTin.Controls.Add(this.lblNgayHHBangLai, 2, 3);
            this.tlpThongTin.Controls.Add(this.dtpNgayHHBangLai, 3, 3);

            this.tlpThongTin.Controls.Add(this.lblTrangThai, 0, 4);
            this.tlpThongTin.Controls.Add(this.cmbTrangThai, 1, 4);

            this.grpThongTin.Controls.Add(this.tlpThongTin);

            // ═══════════════════════════════════════════════════
            // dgvTaiXe
            // ═══════════════════════════════════════════════════
            this.dgvTaiXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiXe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiXe_CellClick);

            // ═══════════════════════════════════════════════════
            // FrmTaiXe
            // ═══════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.dgvTaiXe);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmTaiXe";
            this.Text = "Quản lý Tài xế";
            this.Load += new System.EventHandler(this.FrmTaiXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiXe)).EndInit();
            this.ResumeLayout(false);
        }
        
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
    }
}
