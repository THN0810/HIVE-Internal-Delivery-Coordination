namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.DieuPhoi
{
    partial class FrmDieuPhoi
    {
        private System.ComponentModel.IContainer components = null;

        // ── Panels / GroupBoxes ─────────────────────────────────
        private System.Windows.Forms.Panel         pnlTop;
        private System.Windows.Forms.Panel         pnlToolbar;
        private System.Windows.Forms.FlowLayoutPanel pnlFilter;
        private System.Windows.Forms.Panel         pnlMiddle;    // Fill — chứa label + dgvLenhDieuPhoi
        private System.Windows.Forms.Panel         pnlDonCho;    // chiều cao cố định, chứa dgvDonChoDieuPhoi

        // ── Labels tiêu đề ──────────────────────────────────────
        private System.Windows.Forms.Label         lblTitle;
        private System.Windows.Forms.Label         lblHeaderDon;
        private System.Windows.Forms.Label         lblHeaderLenh;

        // ── GroupBox thông tin lệnh ─────────────────────────────
        private System.Windows.Forms.GroupBox      grpThongTin;

        // ── Toolbar buttons ─────────────────────────────────────
        private System.Windows.Forms.Button        btnLapLenh;
        private System.Windows.Forms.Button        btnLuuLenh;
        private System.Windows.Forms.Button        btnHuyThaoTac;
        private System.Windows.Forms.Button        btnHuyLenh;
        private System.Windows.Forms.Button        btnPhanCongLai;
        private System.Windows.Forms.Button        btnLamMoi;

        // ── Filter Controls ─────────────────────────────────────
        private System.Windows.Forms.Label         lblTimKiem;
        private System.Windows.Forms.TextBox       txtTimKiem;
        private System.Windows.Forms.Label         lblLocTrangThaiLenh;
        private System.Windows.Forms.ComboBox      cboLocTrangThaiLenh;
        private System.Windows.Forms.Button        btnTimKiem;
        private System.Windows.Forms.Button        btnBoLoc;

        // ── DataGridViews ────────────────────────────────────────
        private System.Windows.Forms.DataGridView  dgvDonChoDieuPhoi;
        private System.Windows.Forms.DataGridView  dgvLenhDieuPhoi;

        // ── Thông tin lệnh — Row 1 ───────────────────────────────
        private System.Windows.Forms.Label         lblMaLenhDP;
        private System.Windows.Forms.TextBox       txtMaLenhDP;
        private System.Windows.Forms.Label         lblDonVC;
        private System.Windows.Forms.ComboBox      cboDonVC;

        // ── Thông tin lệnh — Row 2 ───────────────────────────────
        private System.Windows.Forms.Label         lblTaiXe;
        private System.Windows.Forms.ComboBox      cboTaiXe;
        private System.Windows.Forms.Label         lblPhuongTien;
        private System.Windows.Forms.ComboBox      cboPhuongTien;

        // ── Thông tin lệnh — Row 3 ───────────────────────────────
        private System.Windows.Forms.Label         lblTGLapLenh;
        private System.Windows.Forms.DateTimePicker dtpTGLapLenh;
        private System.Windows.Forms.Label         lblTGPhanCong;
        private System.Windows.Forms.DateTimePicker dtpTGPhanCong;

        // ── Thông tin lệnh — Row 4 ───────────────────────────────
        private System.Windows.Forms.Label         lblTrangThaiLenh;
        private System.Windows.Forms.ComboBox      cboTrangThaiLenh;
        private System.Windows.Forms.Label         lblLyDoTuChoi;
        private System.Windows.Forms.TextBox       txtLyDoTuChoi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnLapLenh = new System.Windows.Forms.Button();
            this.btnLuuLenh = new System.Windows.Forms.Button();
            this.btnHuyThaoTac = new System.Windows.Forms.Button();
            this.btnHuyLenh = new System.Windows.Forms.Button();
            this.btnPhanCongLai = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocTrangThaiLenh = new System.Windows.Forms.Label();
            this.cboLocTrangThaiLenh = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            this.pnlDonCho = new System.Windows.Forms.Panel();
            this.dgvDonChoDieuPhoi = new System.Windows.Forms.DataGridView();
            this.lblHeaderDon = new System.Windows.Forms.Label();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.dgvLenhDieuPhoi = new System.Windows.Forms.DataGridView();
            this.lblHeaderLenh = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaLenhDP = new System.Windows.Forms.Label();
            this.txtMaLenhDP = new System.Windows.Forms.TextBox();
            this.lblDonVC = new System.Windows.Forms.Label();
            this.cboDonVC = new System.Windows.Forms.ComboBox();
            this.lblTaiXe = new System.Windows.Forms.Label();
            this.cboTaiXe = new System.Windows.Forms.ComboBox();
            this.lblPhuongTien = new System.Windows.Forms.Label();
            this.cboPhuongTien = new System.Windows.Forms.ComboBox();
            this.lblTGLapLenh = new System.Windows.Forms.Label();
            this.dtpTGLapLenh = new System.Windows.Forms.DateTimePicker();
            this.lblTGPhanCong = new System.Windows.Forms.Label();
            this.dtpTGPhanCong = new System.Windows.Forms.DateTimePicker();
            this.lblTrangThaiLenh = new System.Windows.Forms.Label();
            this.cboTrangThaiLenh = new System.Windows.Forms.ComboBox();
            this.lblLyDoTuChoi = new System.Windows.Forms.Label();
            this.txtLyDoTuChoi = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlDonCho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonChoDieuPhoi)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLenhDieuPhoi)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.tlpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1725, 86);
            this.pnlTop.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 19);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(534, 59);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐIỀU PHỐI VẬN CHUYỂN";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlToolbar.Controls.Add(this.btnLapLenh);
            this.pnlToolbar.Controls.Add(this.btnLuuLenh);
            this.pnlToolbar.Controls.Add(this.btnHuyThaoTac);
            this.pnlToolbar.Controls.Add(this.btnHuyLenh);
            this.pnlToolbar.Controls.Add(this.btnPhanCongLai);
            this.pnlToolbar.Controls.Add(this.btnLamMoi);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 86);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1725, 102);
            this.pnlToolbar.TabIndex = 4;
            // 
            // btnLapLenh
            // 
            this.btnLapLenh.Location = new System.Drawing.Point(22, 16);
            this.btnLapLenh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLapLenh.Name = "btnLapLenh";
            this.btnLapLenh.Size = new System.Drawing.Size(240, 69);
            this.btnLapLenh.TabIndex = 0;
            this.btnLapLenh.Text = "📋 Lập lệnh";
            this.btnLapLenh.Click += new System.EventHandler(this.btnLapLenh_Click);
            // 
            // btnLuuLenh
            // 
            this.btnLuuLenh.Location = new System.Drawing.Point(278, 16);
            this.btnLuuLenh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLuuLenh.Name = "btnLuuLenh";
            this.btnLuuLenh.Size = new System.Drawing.Size(240, 69);
            this.btnLuuLenh.TabIndex = 1;
            this.btnLuuLenh.Text = "💾 Lưu lệnh";
            this.btnLuuLenh.Click += new System.EventHandler(this.btnLuuLenh_Click);
            // 
            // btnHuyThaoTac
            // 
            this.btnHuyThaoTac.Location = new System.Drawing.Point(532, 16);
            this.btnHuyThaoTac.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHuyThaoTac.Name = "btnHuyThaoTac";
            this.btnHuyThaoTac.Size = new System.Drawing.Size(240, 69);
            this.btnHuyThaoTac.TabIndex = 2;
            this.btnHuyThaoTac.Text = "↩ Hủy thao tác";
            this.btnHuyThaoTac.Click += new System.EventHandler(this.btnHuyThaoTac_Click);
            // 
            // btnHuyLenh
            // 
            this.btnHuyLenh.Location = new System.Drawing.Point(788, 16);
            this.btnHuyLenh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHuyLenh.Name = "btnHuyLenh";
            this.btnHuyLenh.Size = new System.Drawing.Size(240, 69);
            this.btnHuyLenh.TabIndex = 3;
            this.btnHuyLenh.Text = "🚫 Hủy lệnh";
            this.btnHuyLenh.Click += new System.EventHandler(this.btnHuyLenh_Click);
            // 
            // btnPhanCongLai
            // 
            this.btnPhanCongLai.Location = new System.Drawing.Point(1042, 16);
            this.btnPhanCongLai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPhanCongLai.Name = "btnPhanCongLai";
            this.btnPhanCongLai.Size = new System.Drawing.Size(270, 69);
            this.btnPhanCongLai.TabIndex = 4;
            this.btnPhanCongLai.Text = "🔄 Phân công lại";
            this.btnPhanCongLai.Click += new System.EventHandler(this.btnPhanCongLai_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(1328, 16);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(240, 69);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "🔃 Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.lblTimKiem);
            this.pnlFilter.Controls.Add(this.txtTimKiem);
            this.pnlFilter.Controls.Add(this.lblLocTrangThaiLenh);
            this.pnlFilter.Controls.Add(this.cboLocTrangThaiLenh);
            this.pnlFilter.Controls.Add(this.btnTimKiem);
            this.pnlFilter.Controls.Add(this.btnBoLoc);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 485);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.pnlFilter.Size = new System.Drawing.Size(1725, 109);
            this.pnlFilter.TabIndex = 2;
            this.pnlFilter.WrapContents = false;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblTimKiem.Location = new System.Drawing.Point(15, 24);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(0, 8, 8, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(131, 38);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm lệnh:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(158, 21);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(373, 45);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblLocTrangThaiLenh
            // 
            this.lblLocTrangThaiLenh.AutoSize = true;
            this.lblLocTrangThaiLenh.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblLocTrangThaiLenh.Location = new System.Drawing.Point(557, 24);
            this.lblLocTrangThaiLenh.Margin = new System.Windows.Forms.Padding(22, 8, 8, 0);
            this.lblLocTrangThaiLenh.Name = "lblLocTrangThaiLenh";
            this.lblLocTrangThaiLenh.Size = new System.Drawing.Size(146, 38);
            this.lblLocTrangThaiLenh.TabIndex = 2;
            this.lblLocTrangThaiLenh.Text = "Trạng thái:";
            // 
            // cboLocTrangThaiLenh
            // 
            this.cboLocTrangThaiLenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThaiLenh.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboLocTrangThaiLenh.Location = new System.Drawing.Point(715, 21);
            this.cboLocTrangThaiLenh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLocTrangThaiLenh.Name = "cboLocTrangThaiLenh";
            this.cboLocTrangThaiLenh.Size = new System.Drawing.Size(223, 46);
            this.cboLocTrangThaiLenh.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnTimKiem.Location = new System.Drawing.Point(964, 16);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(22, 0, 8, 0);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(210, 70);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnBoLoc.Location = new System.Drawing.Point(1190, 16);
            this.btnBoLoc.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(210, 70);
            this.btnBoLoc.TabIndex = 5;
            this.btnBoLoc.Text = "✕ Bỏ lọc";
            this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);
            // 
            // pnlDonCho
            // 
            this.pnlDonCho.BackColor = System.Drawing.Color.White;
            this.pnlDonCho.Controls.Add(this.dgvDonChoDieuPhoi);
            this.pnlDonCho.Controls.Add(this.lblHeaderDon);
            this.pnlDonCho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDonCho.Location = new System.Drawing.Point(0, 188);
            this.pnlDonCho.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlDonCho.Name = "pnlDonCho";
            this.pnlDonCho.Padding = new System.Windows.Forms.Padding(15, 0, 15, 8);
            this.pnlDonCho.Size = new System.Drawing.Size(1725, 297);
            this.pnlDonCho.TabIndex = 3;
            // 
            // dgvDonChoDieuPhoi
            // 
            this.dgvDonChoDieuPhoi.ColumnHeadersHeight = 46;
            this.dgvDonChoDieuPhoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDonChoDieuPhoi.Location = new System.Drawing.Point(15, 47);
            this.dgvDonChoDieuPhoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDonChoDieuPhoi.Name = "dgvDonChoDieuPhoi";
            this.dgvDonChoDieuPhoi.RowHeadersWidth = 82;
            this.dgvDonChoDieuPhoi.Size = new System.Drawing.Size(1695, 242);
            this.dgvDonChoDieuPhoi.TabIndex = 0;
            this.dgvDonChoDieuPhoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonChoDieuPhoi_CellClick);
            // 
            // lblHeaderDon
            // 
            this.lblHeaderDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.lblHeaderDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(33)))), ((int)(((byte)(55)))));
            this.lblHeaderDon.Location = new System.Drawing.Point(15, 0);
            this.lblHeaderDon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderDon.Name = "lblHeaderDon";
            this.lblHeaderDon.Size = new System.Drawing.Size(1695, 47);
            this.lblHeaderDon.TabIndex = 1;
            this.lblHeaderDon.Text = "  📦  DANH SÁCH ĐƠN CHỜ ĐIỀU PHỐI";
            this.lblHeaderDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.BackColor = System.Drawing.Color.White;
            this.pnlMiddle.Controls.Add(this.dgvLenhDieuPhoi);
            this.pnlMiddle.Controls.Add(this.lblHeaderLenh);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 594);
            this.pnlMiddle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(15, 0, 15, 8);
            this.pnlMiddle.Size = new System.Drawing.Size(1725, 289);
            this.pnlMiddle.TabIndex = 0;
            // 
            // dgvLenhDieuPhoi
            // 
            this.dgvLenhDieuPhoi.ColumnHeadersHeight = 46;
            this.dgvLenhDieuPhoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLenhDieuPhoi.Location = new System.Drawing.Point(15, 47);
            this.dgvLenhDieuPhoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLenhDieuPhoi.Name = "dgvLenhDieuPhoi";
            this.dgvLenhDieuPhoi.RowHeadersWidth = 82;
            this.dgvLenhDieuPhoi.Size = new System.Drawing.Size(1695, 234);
            this.dgvLenhDieuPhoi.TabIndex = 0;
            this.dgvLenhDieuPhoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLenhDieuPhoi_CellClick);
            // 
            // lblHeaderLenh
            // 
            this.lblHeaderLenh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.lblHeaderLenh.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderLenh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderLenh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(33)))), ((int)(((byte)(55)))));
            this.lblHeaderLenh.Location = new System.Drawing.Point(15, 0);
            this.lblHeaderLenh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderLenh.Name = "lblHeaderLenh";
            this.lblHeaderLenh.Size = new System.Drawing.Size(1695, 47);
            this.lblHeaderLenh.TabIndex = 1;
            this.lblHeaderLenh.Text = "  📋  DANH SÁCH LỆNH ĐIỀU PHỐI";
            this.lblHeaderLenh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpThongTin
            // 
            this.grpThongTin.BackColor = System.Drawing.Color.White;
            this.grpThongTin.Controls.Add(this.tlpThongTin);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTin.Location = new System.Drawing.Point(0, 883);
            this.grpThongTin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.grpThongTin.Size = new System.Drawing.Size(1725, 367);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin lệnh điều phối";
            // 
            // tlpThongTin
            // 
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.Controls.Add(this.lblMaLenhDP, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtMaLenhDP, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblDonVC, 2, 0);
            this.tlpThongTin.Controls.Add(this.cboDonVC, 3, 0);
            this.tlpThongTin.Controls.Add(this.lblTaiXe, 0, 1);
            this.tlpThongTin.Controls.Add(this.cboTaiXe, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblPhuongTien, 2, 1);
            this.tlpThongTin.Controls.Add(this.cboPhuongTien, 3, 1);
            this.tlpThongTin.Controls.Add(this.lblTGLapLenh, 0, 2);
            this.tlpThongTin.Controls.Add(this.dtpTGLapLenh, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblTGPhanCong, 2, 2);
            this.tlpThongTin.Controls.Add(this.dtpTGPhanCong, 3, 2);
            this.tlpThongTin.Controls.Add(this.lblTrangThaiLenh, 0, 3);
            this.tlpThongTin.Controls.Add(this.cboTrangThaiLenh, 1, 3);
            this.tlpThongTin.Controls.Add(this.lblLyDoTuChoi, 2, 3);
            this.tlpThongTin.Controls.Add(this.txtLyDoTuChoi, 3, 3);
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.Location = new System.Drawing.Point(18, 55);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.Padding = new System.Windows.Forms.Padding(15, 30, 45, 15);
            this.tlpThongTin.RowCount = 4;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpThongTin.Size = new System.Drawing.Size(1689, 300);
            this.tlpThongTin.TabIndex = 0;
            // 
            // lblMaLenhDP
            // 
            this.lblMaLenhDP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaLenhDP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaLenhDP.Location = new System.Drawing.Point(13, 20);
            this.lblMaLenhDP.Name = "lblMaLenhDP";
            this.lblMaLenhDP.Size = new System.Drawing.Size(100, 67);
            this.lblMaLenhDP.TabIndex = 0;
            this.lblMaLenhDP.Text = "Mã lệnh:";
            this.lblMaLenhDP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaLenhDP
            // 
            this.txtMaLenhDP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaLenhDP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.txtMaLenhDP.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMaLenhDP.Location = new System.Drawing.Point(119, 30);
            this.txtMaLenhDP.Name = "txtMaLenhDP";
            this.txtMaLenhDP.ReadOnly = true;
            this.txtMaLenhDP.Size = new System.Drawing.Size(712, 47);
            this.txtMaLenhDP.TabIndex = 1;
            // 
            // lblDonVC
            // 
            this.lblDonVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDonVC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDonVC.Location = new System.Drawing.Point(837, 20);
            this.lblDonVC.Name = "lblDonVC";
            this.lblDonVC.Size = new System.Drawing.Size(100, 67);
            this.lblDonVC.TabIndex = 2;
            this.lblDonVC.Text = "Đơn vận chuyển:";
            this.lblDonVC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDonVC
            // 
            this.cboDonVC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDonVC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonVC.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboDonVC.Location = new System.Drawing.Point(943, 37);
            this.cboDonVC.Name = "cboDonVC";
            this.cboDonVC.Size = new System.Drawing.Size(713, 48);
            this.cboDonVC.TabIndex = 3;
            // 
            // lblTaiXe
            // 
            this.lblTaiXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTaiXe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaiXe.Location = new System.Drawing.Point(13, 87);
            this.lblTaiXe.Name = "lblTaiXe";
            this.lblTaiXe.Size = new System.Drawing.Size(100, 67);
            this.lblTaiXe.TabIndex = 4;
            this.lblTaiXe.Text = "Tài xế:";
            this.lblTaiXe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTaiXe
            // 
            this.cboTaiXe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTaiXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaiXe.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboTaiXe.Location = new System.Drawing.Point(119, 104);
            this.cboTaiXe.Name = "cboTaiXe";
            this.cboTaiXe.Size = new System.Drawing.Size(712, 48);
            this.cboTaiXe.TabIndex = 5;
            // 
            // lblPhuongTien
            // 
            this.lblPhuongTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhuongTien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhuongTien.Location = new System.Drawing.Point(837, 87);
            this.lblPhuongTien.Name = "lblPhuongTien";
            this.lblPhuongTien.Size = new System.Drawing.Size(100, 67);
            this.lblPhuongTien.TabIndex = 6;
            this.lblPhuongTien.Text = "Phương tiện:";
            this.lblPhuongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPhuongTien
            // 
            this.cboPhuongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPhuongTien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongTien.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboPhuongTien.Location = new System.Drawing.Point(943, 104);
            this.cboPhuongTien.Name = "cboPhuongTien";
            this.cboPhuongTien.Size = new System.Drawing.Size(713, 48);
            this.cboPhuongTien.TabIndex = 7;
            // 
            // lblTGLapLenh
            // 
            this.lblTGLapLenh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTGLapLenh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTGLapLenh.Location = new System.Drawing.Point(13, 154);
            this.lblTGLapLenh.Name = "lblTGLapLenh";
            this.lblTGLapLenh.Size = new System.Drawing.Size(100, 67);
            this.lblTGLapLenh.TabIndex = 8;
            this.lblTGLapLenh.Text = "TG lập lệnh:";
            this.lblTGLapLenh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTGLapLenh
            // 
            this.dtpTGLapLenh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTGLapLenh.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTGLapLenh.Enabled = false;
            this.dtpTGLapLenh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpTGLapLenh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTGLapLenh.Location = new System.Drawing.Point(119, 164);
            this.dtpTGLapLenh.Name = "dtpTGLapLenh";
            this.dtpTGLapLenh.Size = new System.Drawing.Size(712, 47);
            this.dtpTGLapLenh.TabIndex = 9;
            // 
            // lblTGPhanCong
            // 
            this.lblTGPhanCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTGPhanCong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTGPhanCong.Location = new System.Drawing.Point(837, 154);
            this.lblTGPhanCong.Name = "lblTGPhanCong";
            this.lblTGPhanCong.Size = new System.Drawing.Size(100, 67);
            this.lblTGPhanCong.TabIndex = 10;
            this.lblTGPhanCong.Text = "TG phân công:";
            this.lblTGPhanCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTGPhanCong
            // 
            this.dtpTGPhanCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTGPhanCong.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTGPhanCong.Enabled = false;
            this.dtpTGPhanCong.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpTGPhanCong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTGPhanCong.Location = new System.Drawing.Point(943, 164);
            this.dtpTGPhanCong.Name = "dtpTGPhanCong";
            this.dtpTGPhanCong.Size = new System.Drawing.Size(713, 47);
            this.dtpTGPhanCong.TabIndex = 11;
            // 
            // lblTrangThaiLenh
            // 
            this.lblTrangThaiLenh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThaiLenh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThaiLenh.Location = new System.Drawing.Point(13, 221);
            this.lblTrangThaiLenh.Name = "lblTrangThaiLenh";
            this.lblTrangThaiLenh.Size = new System.Drawing.Size(100, 69);
            this.lblTrangThaiLenh.TabIndex = 12;
            this.lblTrangThaiLenh.Text = "Trạng thái:";
            this.lblTrangThaiLenh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTrangThaiLenh
            // 
            this.cboTrangThaiLenh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTrangThaiLenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiLenh.Enabled = false;
            this.cboTrangThaiLenh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboTrangThaiLenh.Items.AddRange(new object[] {
            "Chờ xác nhận",
            "Đã tiếp nhận",
            "Từ chối",
            "Đang thực hiện",
            "Hoàn thành",
            "Đã hủy"});
            this.cboTrangThaiLenh.Location = new System.Drawing.Point(119, 239);
            this.cboTrangThaiLenh.Name = "cboTrangThaiLenh";
            this.cboTrangThaiLenh.Size = new System.Drawing.Size(712, 48);
            this.cboTrangThaiLenh.TabIndex = 13;
            // 
            // lblLyDoTuChoi
            // 
            this.lblLyDoTuChoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLyDoTuChoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLyDoTuChoi.Location = new System.Drawing.Point(837, 221);
            this.lblLyDoTuChoi.Name = "lblLyDoTuChoi";
            this.lblLyDoTuChoi.Size = new System.Drawing.Size(100, 69);
            this.lblLyDoTuChoi.TabIndex = 14;
            this.lblLyDoTuChoi.Text = "Lý do từ chối:";
            this.lblLyDoTuChoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLyDoTuChoi
            // 
            this.txtLyDoTuChoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLyDoTuChoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.txtLyDoTuChoi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtLyDoTuChoi.Location = new System.Drawing.Point(943, 232);
            this.txtLyDoTuChoi.Name = "txtLyDoTuChoi";
            this.txtLyDoTuChoi.ReadOnly = true;
            this.txtLyDoTuChoi.Size = new System.Drawing.Size(713, 47);
            this.txtLyDoTuChoi.TabIndex = 15;
            // 
            // FrmDieuPhoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1725, 1250);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlDonCho);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDieuPhoi";
            this.Text = "Điều phối vận chuyển";
            this.Load += new System.EventHandler(this.FrmDieuPhoi_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlDonCho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonChoDieuPhoi)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLenhDieuPhoi)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.tlpThongTin.ResumeLayout(false);
            this.tlpThongTin.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
    }
}
