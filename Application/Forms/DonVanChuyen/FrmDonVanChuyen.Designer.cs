namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.DonVanChuyen
{
    partial class FrmDonVanChuyen
    {
        private System.ComponentModel.IContainer components = null;

        // ── Panels ──────────────────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.FlowLayoutPanel pnlToolbar;
        private System.Windows.Forms.FlowLayoutPanel pnlFilter;

        // ── SplitContainers ─────────────────────────────────
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.SplitContainer splitBottom;

        // ── Labels ──────────────────────────────────────────
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaDonVC, lblKhachHang, lblTenNguoiNhan;
        private System.Windows.Forms.Label lblSDTNguoiNhan, lblDiaChiLayHang, lblDiaChiGiao;
        private System.Windows.Forms.Label lblTGNhan, lblTGGiao, lblPhiVC;
        private System.Windows.Forms.Label lblTrangThai, lblYeuCau, lblNgayTao;
        private System.Windows.Forms.Label lblTimKiem, lblLocTrangThai;

        // ── Inputs thông tin đơn ─────────────────────────────
        private System.Windows.Forms.TextBox txtMaDonVC, txtTenNguoiNhan, txtSDTNguoiNhan;
        private System.Windows.Forms.TextBox txtDiaChiLayHang, txtDiaChiGiao, txtPhiVC;
        private System.Windows.Forms.TextBox txtYeuCauDacBiet, txtNgayTao;
        private System.Windows.Forms.ComboBox cboKhachHang, cboTrangThai;
        private System.Windows.Forms.DateTimePicker dtpTGNhanDuKien, dtpTGGiaoDuKien;

        // ── Toolbar buttons ─────────────────────────────────
        private System.Windows.Forms.Button btnThem, btnSua, btnLuu, btnHuy;
        private System.Windows.Forms.Button btnLamMoi, btnChuyenDieuPhoi, btnHuyDon;
        private System.Windows.Forms.Button btnXemChiTiet;

        // ── Tìm kiếm & Lọc ─────────────────────────────────
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnTimKiem, btnBoLoc;

        // ── DataGridView danh sách ──────────────────────────
        private System.Windows.Forms.DataGridView dgvDonVC;

        // ── GroupBoxes ──────────────────────────────────────
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.GroupBox grpChiTiet;

        // ── TableLayoutPanel bên trong grpThongTin ─────────
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;

        // ── Chi tiết hàng hóa ───────────────────────────────
        private System.Windows.Forms.Panel pnlChiTietInput;
        private System.Windows.Forms.FlowLayoutPanel pnlChiTietRow1;
        private System.Windows.Forms.FlowLayoutPanel pnlChiTietRow2;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.ComboBox cboLoaiHangHoa;
        private System.Windows.Forms.TextBox txtKhoiLuong, txtSoKien, txtDonViTinh, txtMoTaHangHoa;
        private System.Windows.Forms.Button btnThemHangHoa, btnSuaHangHoa, btnXoaHangHoa, btnLamMoiHangHoa;
        private System.Windows.Forms.Label lblLoaiHH, lblKL, lblSK, lblDVT, lblMoTaHH;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnChuyenDieuPhoi = new System.Windows.Forms.Button();
            this.btnHuyDon = new System.Windows.Forms.Button();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvDonVC = new System.Windows.Forms.DataGridView();
            this.splitBottom = new System.Windows.Forms.SplitContainer();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaDonVC = new System.Windows.Forms.Label();
            this.txtMaDonVC = new System.Windows.Forms.TextBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblTenNguoiNhan = new System.Windows.Forms.Label();
            this.txtTenNguoiNhan = new System.Windows.Forms.TextBox();
            this.lblSDTNguoiNhan = new System.Windows.Forms.Label();
            this.txtSDTNguoiNhan = new System.Windows.Forms.TextBox();
            this.lblDiaChiLayHang = new System.Windows.Forms.Label();
            this.txtDiaChiLayHang = new System.Windows.Forms.TextBox();
            this.lblDiaChiGiao = new System.Windows.Forms.Label();
            this.txtDiaChiGiao = new System.Windows.Forms.TextBox();
            this.lblTGNhan = new System.Windows.Forms.Label();
            this.dtpTGNhanDuKien = new System.Windows.Forms.DateTimePicker();
            this.lblTGGiao = new System.Windows.Forms.Label();
            this.dtpTGGiaoDuKien = new System.Windows.Forms.DateTimePicker();
            this.lblPhiVC = new System.Windows.Forms.Label();
            this.txtPhiVC = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.txtNgayTao = new System.Windows.Forms.TextBox();
            this.lblYeuCau = new System.Windows.Forms.Label();
            this.txtYeuCauDacBiet = new System.Windows.Forms.TextBox();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.pnlChiTietInput = new System.Windows.Forms.Panel();
            this.pnlChiTietRow2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMoTaHH = new System.Windows.Forms.Label();
            this.txtMoTaHangHoa = new System.Windows.Forms.TextBox();
            this.btnThemHangHoa = new System.Windows.Forms.Button();
            this.btnSuaHangHoa = new System.Windows.Forms.Button();
            this.btnXoaHangHoa = new System.Windows.Forms.Button();
            this.btnLamMoiHangHoa = new System.Windows.Forms.Button();
            this.pnlChiTietRow1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLoaiHH = new System.Windows.Forms.Label();
            this.cboLoaiHangHoa = new System.Windows.Forms.ComboBox();
            this.lblKL = new System.Windows.Forms.Label();
            this.txtKhoiLuong = new System.Windows.Forms.TextBox();
            this.lblSK = new System.Windows.Forms.Label();
            this.txtSoKien = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonVC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitBottom)).BeginInit();
            this.splitBottom.Panel1.SuspendLayout();
            this.splitBottom.Panel2.SuspendLayout();
            this.splitBottom.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.tlpThongTin.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlChiTietInput.SuspendLayout();
            this.pnlChiTietRow2.SuspendLayout();
            this.pnlChiTietRow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(2732, 104);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(363, 59);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đơn Vận Chuyển";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlToolbar.Controls.Add(this.btnThem);
            this.pnlToolbar.Controls.Add(this.btnSua);
            this.pnlToolbar.Controls.Add(this.btnLuu);
            this.pnlToolbar.Controls.Add(this.btnHuy);
            this.pnlToolbar.Controls.Add(this.btnLamMoi);
            this.pnlToolbar.Controls.Add(this.btnChuyenDieuPhoi);
            this.pnlToolbar.Controls.Add(this.btnHuyDon);
            this.pnlToolbar.Controls.Add(this.btnXemChiTiet);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 104);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.pnlToolbar.Size = new System.Drawing.Size(2732, 104);
            this.pnlToolbar.TabIndex = 2;
            this.pnlToolbar.WrapContents = false;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnThem.Location = new System.Drawing.Point(20, 12);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(200, 76);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "+ Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSua.Location = new System.Drawing.Point(240, 12);
            this.btnSua.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(200, 76);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "✎ Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLuu.Location = new System.Drawing.Point(460, 12);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(200, 76);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnHuy.Location = new System.Drawing.Point(680, 12);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(200, 76);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "↩ Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLamMoi.Location = new System.Drawing.Point(900, 12);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(250, 80);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "⟳ Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnChuyenDieuPhoi
            // 
            this.btnChuyenDieuPhoi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnChuyenDieuPhoi.Location = new System.Drawing.Point(1170, 12);
            this.btnChuyenDieuPhoi.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnChuyenDieuPhoi.Name = "btnChuyenDieuPhoi";
            this.btnChuyenDieuPhoi.Size = new System.Drawing.Size(250, 80);
            this.btnChuyenDieuPhoi.TabIndex = 5;
            this.btnChuyenDieuPhoi.Text = "➡ Chuyển";
            this.btnChuyenDieuPhoi.Click += new System.EventHandler(this.btnChuyenDieuPhoi_Click);
            // 
            // btnHuyDon
            // 
            this.btnHuyDon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnHuyDon.Location = new System.Drawing.Point(1440, 12);
            this.btnHuyDon.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnHuyDon.Name = "btnHuyDon";
            this.btnHuyDon.Size = new System.Drawing.Size(250, 80);
            this.btnHuyDon.TabIndex = 6;
            this.btnHuyDon.Text = "✕ Hủy đơn";
            this.btnHuyDon.Click += new System.EventHandler(this.btnHuyDon_Click);
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnXemChiTiet.Location = new System.Drawing.Point(1710, 12);
            this.btnXemChiTiet.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(250, 80);
            this.btnXemChiTiet.TabIndex = 7;
            this.btnXemChiTiet.Text = "👁 Chi tiết";
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.lblTimKiem);
            this.pnlFilter.Controls.Add(this.txtTimKiem);
            this.pnlFilter.Controls.Add(this.lblLocTrangThai);
            this.pnlFilter.Controls.Add(this.cboLocTrangThai);
            this.pnlFilter.Controls.Add(this.btnTimKiem);
            this.pnlFilter.Controls.Add(this.btnBoLoc);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 208);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.pnlFilter.Size = new System.Drawing.Size(2732, 88);
            this.pnlFilter.TabIndex = 1;
            this.pnlFilter.WrapContents = false;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTimKiem.Location = new System.Drawing.Point(20, 24);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(125, 36);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(161, 20);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(436, 41);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLocTrangThai.Location = new System.Drawing.Point(623, 24);
            this.lblLocTrangThai.Margin = new System.Windows.Forms.Padding(20, 10, 10, 0);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(135, 36);
            this.lblLocTrangThai.TabIndex = 2;
            this.lblLocTrangThai.Text = "Trạng thái:";
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLocTrangThai.Location = new System.Drawing.Point(774, 20);
            this.cboLocTrangThai.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(326, 43);
            this.cboLocTrangThai.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTimKiem.Location = new System.Drawing.Point(1126, 14);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(200, 72);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBoLoc.Location = new System.Drawing.Point(1346, 14);
            this.btnBoLoc.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(200, 72);
            this.btnBoLoc.TabIndex = 5;
            this.btnBoLoc.Text = "✕ Bỏ lọc";
            this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);
            // 
            // splitMain
            // 
            this.splitMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 296);
            this.splitMain.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.dgvDonVC);
            this.splitMain.Panel1MinSize = 0;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitBottom);
            this.splitMain.Panel2MinSize = 0;
            this.splitMain.Size = new System.Drawing.Size(2732, 1240);
            this.splitMain.SplitterDistance = 620;
            this.splitMain.SplitterWidth = 10;
            this.splitMain.TabIndex = 0;
            // 
            // dgvDonVC
            // 
            this.dgvDonVC.AllowUserToAddRows = false;
            this.dgvDonVC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonVC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonVC.ColumnHeadersHeight = 34;
            this.dgvDonVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDonVC.Location = new System.Drawing.Point(0, 0);
            this.dgvDonVC.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvDonVC.MultiSelect = false;
            this.dgvDonVC.Name = "dgvDonVC";
            this.dgvDonVC.ReadOnly = true;
            this.dgvDonVC.RowHeadersVisible = false;
            this.dgvDonVC.RowHeadersWidth = 82;
            this.dgvDonVC.RowTemplate.Height = 30;
            this.dgvDonVC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDonVC.Size = new System.Drawing.Size(2732, 620);
            this.dgvDonVC.TabIndex = 0;
            this.dgvDonVC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonVC_CellClick);
            this.dgvDonVC.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonVC_CellDoubleClick);
            // 
            // splitBottom
            // 
            this.splitBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.splitBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBottom.Location = new System.Drawing.Point(0, 0);
            this.splitBottom.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitBottom.Name = "splitBottom";
            // 
            // splitBottom.Panel1
            // 
            this.splitBottom.Panel1.Controls.Add(this.grpThongTin);
            this.splitBottom.Panel1MinSize = 0;
            // 
            // splitBottom.Panel2
            // 
            this.splitBottom.Panel2.Controls.Add(this.grpChiTiet);
            this.splitBottom.Panel2MinSize = 0;
            this.splitBottom.Size = new System.Drawing.Size(2732, 610);
            this.splitBottom.SplitterDistance = 910;
            this.splitBottom.SplitterWidth = 10;
            this.splitBottom.TabIndex = 0;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.tlpThongTin);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Location = new System.Drawing.Point(0, 0);
            this.grpThongTin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.grpThongTin.Size = new System.Drawing.Size(910, 610);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin đơn vận chuyển";
            // 
            // tlpThongTin
            // 
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.Controls.Add(this.lblMaDonVC, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtMaDonVC, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblKhachHang, 2, 0);
            this.tlpThongTin.Controls.Add(this.cboKhachHang, 3, 0);
            this.tlpThongTin.Controls.Add(this.lblTenNguoiNhan, 0, 1);
            this.tlpThongTin.Controls.Add(this.txtTenNguoiNhan, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblSDTNguoiNhan, 2, 1);
            this.tlpThongTin.Controls.Add(this.txtSDTNguoiNhan, 3, 1);
            this.tlpThongTin.Controls.Add(this.lblDiaChiLayHang, 0, 2);
            this.tlpThongTin.Controls.Add(this.txtDiaChiLayHang, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblDiaChiGiao, 2, 2);
            this.tlpThongTin.Controls.Add(this.txtDiaChiGiao, 3, 2);
            this.tlpThongTin.Controls.Add(this.lblTGNhan, 0, 3);
            this.tlpThongTin.Controls.Add(this.dtpTGNhanDuKien, 1, 3);
            this.tlpThongTin.Controls.Add(this.lblTGGiao, 2, 3);
            this.tlpThongTin.Controls.Add(this.dtpTGGiaoDuKien, 3, 3);
            this.tlpThongTin.Controls.Add(this.lblPhiVC, 0, 4);
            this.tlpThongTin.Controls.Add(this.txtPhiVC, 1, 4);
            this.tlpThongTin.Controls.Add(this.lblTrangThai, 2, 4);
            this.tlpThongTin.Controls.Add(this.cboTrangThai, 3, 4);
            this.tlpThongTin.Controls.Add(this.lblNgayTao, 0, 5);
            this.tlpThongTin.Controls.Add(this.txtNgayTao, 1, 5);
            this.tlpThongTin.Controls.Add(this.lblYeuCau, 0, 6);
            this.tlpThongTin.Controls.Add(this.txtYeuCauDacBiet, 1, 6);
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tlpThongTin.Location = new System.Drawing.Point(16, 46);
            this.tlpThongTin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.tlpThongTin.RowCount = 8;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpThongTin.Size = new System.Drawing.Size(878, 552);
            this.tlpThongTin.TabIndex = 0;
            // 
            // lblMaDonVC
            // 
            this.lblMaDonVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaDonVC.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaDonVC.Location = new System.Drawing.Point(14, 8);
            this.lblMaDonVC.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMaDonVC.Name = "lblMaDonVC";
            this.lblMaDonVC.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblMaDonVC.Size = new System.Drawing.Size(248, 76);
            this.lblMaDonVC.TabIndex = 0;
            this.lblMaDonVC.Text = "Mã đơn:";
            this.lblMaDonVC.AutoSize = false; this.lblMaDonVC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaDonVC
            // 
            this.txtMaDonVC.BackColor = System.Drawing.Color.White;
            this.txtMaDonVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaDonVC.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMaDonVC.Location = new System.Drawing.Point(268, 16);
            this.txtMaDonVC.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.txtMaDonVC.Name = "txtMaDonVC";
            this.txtMaDonVC.ReadOnly = true;
            this.txtMaDonVC.Size = new System.Drawing.Size(163, 41);
            this.txtMaDonVC.TabIndex = 1;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKhachHang.Location = new System.Drawing.Point(445, 8);
            this.lblKhachHang.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblKhachHang.Size = new System.Drawing.Size(248, 76);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Khách hàng:";
            this.lblKhachHang.AutoSize = false; this.lblKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboKhachHang.Location = new System.Drawing.Point(699, 16);
            this.cboKhachHang.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(163, 43);
            this.cboKhachHang.TabIndex = 3;
            // 
            // lblTenNguoiNhan
            // 
            this.lblTenNguoiNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTenNguoiNhan.Location = new System.Drawing.Point(14, 84);
            this.lblTenNguoiNhan.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTenNguoiNhan.Name = "lblTenNguoiNhan";
            this.lblTenNguoiNhan.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblTenNguoiNhan.Size = new System.Drawing.Size(248, 76);
            this.lblTenNguoiNhan.TabIndex = 4;
            this.lblTenNguoiNhan.Text = "Người nhận:";
            this.lblTenNguoiNhan.AutoSize = false; this.lblTenNguoiNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenNguoiNhan
            // 
            this.txtTenNguoiNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTenNguoiNhan.Location = new System.Drawing.Point(268, 92);
            this.txtTenNguoiNhan.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.txtTenNguoiNhan.Name = "txtTenNguoiNhan";
            this.txtTenNguoiNhan.Size = new System.Drawing.Size(163, 41);
            this.txtTenNguoiNhan.TabIndex = 5;
            // 
            // lblSDTNguoiNhan
            // 
            this.lblSDTNguoiNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSDTNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSDTNguoiNhan.Location = new System.Drawing.Point(445, 84);
            this.lblSDTNguoiNhan.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSDTNguoiNhan.Name = "lblSDTNguoiNhan";
            this.lblSDTNguoiNhan.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblSDTNguoiNhan.Size = new System.Drawing.Size(248, 76);
            this.lblSDTNguoiNhan.TabIndex = 6;
            this.lblSDTNguoiNhan.Text = "SĐT nhận:";
            this.lblSDTNguoiNhan.AutoSize = false; this.lblSDTNguoiNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSDTNguoiNhan
            // 
            this.txtSDTNguoiNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSDTNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSDTNguoiNhan.Location = new System.Drawing.Point(699, 92);
            this.txtSDTNguoiNhan.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.txtSDTNguoiNhan.Name = "txtSDTNguoiNhan";
            this.txtSDTNguoiNhan.Size = new System.Drawing.Size(163, 41);
            this.txtSDTNguoiNhan.TabIndex = 7;
            // 
            // lblDiaChiLayHang
            // 
            this.lblDiaChiLayHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiaChiLayHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDiaChiLayHang.Location = new System.Drawing.Point(14, 160);
            this.lblDiaChiLayHang.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDiaChiLayHang.Name = "lblDiaChiLayHang";
            this.lblDiaChiLayHang.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblDiaChiLayHang.Size = new System.Drawing.Size(248, 76);
            this.lblDiaChiLayHang.TabIndex = 8;
            this.lblDiaChiLayHang.Text = "Địa chỉ lấy hàng:";
            this.lblDiaChiLayHang.AutoSize = false; this.lblDiaChiLayHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiaChiLayHang
            // 
            this.txtDiaChiLayHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiaChiLayHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiaChiLayHang.Location = new System.Drawing.Point(268, 168);
            this.txtDiaChiLayHang.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.txtDiaChiLayHang.Name = "txtDiaChiLayHang";
            this.txtDiaChiLayHang.Size = new System.Drawing.Size(163, 41);
            this.txtDiaChiLayHang.TabIndex = 9;
            // 
            // lblDiaChiGiao
            // 
            this.lblDiaChiGiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiaChiGiao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDiaChiGiao.Location = new System.Drawing.Point(445, 160);
            this.lblDiaChiGiao.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDiaChiGiao.Name = "lblDiaChiGiao";
            this.lblDiaChiGiao.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblDiaChiGiao.Size = new System.Drawing.Size(248, 76);
            this.lblDiaChiGiao.TabIndex = 10;
            this.lblDiaChiGiao.Text = "Địa chỉ giao:";
            this.lblDiaChiGiao.AutoSize = false; this.lblDiaChiGiao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiaChiGiao
            // 
            this.txtDiaChiGiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiaChiGiao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiaChiGiao.Location = new System.Drawing.Point(699, 168);
            this.txtDiaChiGiao.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.txtDiaChiGiao.Name = "txtDiaChiGiao";
            this.txtDiaChiGiao.Size = new System.Drawing.Size(163, 41);
            this.txtDiaChiGiao.TabIndex = 11;
            // 
            // lblTGNhan
            // 
            this.lblTGNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTGNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTGNhan.Location = new System.Drawing.Point(14, 236);
            this.lblTGNhan.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTGNhan.Name = "lblTGNhan";
            this.lblTGNhan.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblTGNhan.Size = new System.Drawing.Size(248, 76);
            this.lblTGNhan.TabIndex = 12;
            this.lblTGNhan.Text = "Thời gian nhận:";
            this.lblTGNhan.AutoSize = false; this.lblTGNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTGNhanDuKien
            // 
            this.dtpTGNhanDuKien.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTGNhanDuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTGNhanDuKien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTGNhanDuKien.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTGNhanDuKien.Location = new System.Drawing.Point(268, 244);
            this.dtpTGNhanDuKien.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.dtpTGNhanDuKien.Name = "dtpTGNhanDuKien";
            this.dtpTGNhanDuKien.Size = new System.Drawing.Size(163, 41);
            this.dtpTGNhanDuKien.TabIndex = 13;
            // 
            // lblTGGiao
            // 
            this.lblTGGiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTGGiao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTGGiao.Location = new System.Drawing.Point(445, 236);
            this.lblTGGiao.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTGGiao.Name = "lblTGGiao";
            this.lblTGGiao.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblTGGiao.Size = new System.Drawing.Size(248, 76);
            this.lblTGGiao.TabIndex = 14;
            this.lblTGGiao.Text = "Thời gian giao:";
            this.lblTGGiao.AutoSize = false; this.lblTGGiao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTGGiaoDuKien
            // 
            this.dtpTGGiaoDuKien.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTGGiaoDuKien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTGGiaoDuKien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTGGiaoDuKien.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTGGiaoDuKien.Location = new System.Drawing.Point(699, 244);
            this.dtpTGGiaoDuKien.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.dtpTGGiaoDuKien.Name = "dtpTGGiaoDuKien";
            this.dtpTGGiaoDuKien.Size = new System.Drawing.Size(163, 41);
            this.dtpTGGiaoDuKien.TabIndex = 15;
            // 
            // lblPhiVC
            // 
            this.lblPhiVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhiVC.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhiVC.Location = new System.Drawing.Point(14, 312);
            this.lblPhiVC.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPhiVC.Name = "lblPhiVC";
            this.lblPhiVC.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblPhiVC.Size = new System.Drawing.Size(248, 76);
            this.lblPhiVC.TabIndex = 16;
            this.lblPhiVC.Text = "Phí vận chuyển:";
            this.lblPhiVC.AutoSize = false; this.lblPhiVC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhiVC
            // 
            this.txtPhiVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhiVC.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPhiVC.Location = new System.Drawing.Point(268, 320);
            this.txtPhiVC.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.txtPhiVC.Name = "txtPhiVC";
            this.txtPhiVC.Size = new System.Drawing.Size(163, 41);
            this.txtPhiVC.TabIndex = 17;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTrangThai.Location = new System.Drawing.Point(445, 312);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblTrangThai.Size = new System.Drawing.Size(248, 76);
            this.lblTrangThai.TabIndex = 18;
            this.lblTrangThai.Text = "Trạng thái:";
            this.lblTrangThai.AutoSize = false; this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Enabled = false;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboTrangThai.Location = new System.Drawing.Point(699, 320);
            this.cboTrangThai.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(163, 43);
            this.cboTrangThai.TabIndex = 19;
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayTao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNgayTao.Location = new System.Drawing.Point(14, 388);
            this.lblNgayTao.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblNgayTao.Size = new System.Drawing.Size(248, 76);
            this.lblNgayTao.TabIndex = 20;
            this.lblNgayTao.Text = "Ngày tạo:";
            this.lblNgayTao.AutoSize = false; this.lblNgayTao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNgayTao
            // 
            this.txtNgayTao.BackColor = System.Drawing.Color.White;
            this.txtNgayTao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgayTao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNgayTao.Location = new System.Drawing.Point(268, 396);
            this.txtNgayTao.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.txtNgayTao.Name = "txtNgayTao";
            this.txtNgayTao.ReadOnly = true;
            this.txtNgayTao.Size = new System.Drawing.Size(163, 41);
            this.txtNgayTao.TabIndex = 21;
            // 
            // lblYeuCau
            // 
            this.lblYeuCau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYeuCau.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblYeuCau.Location = new System.Drawing.Point(14, 464);
            this.lblYeuCau.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblYeuCau.Name = "lblYeuCau";
            this.lblYeuCau.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.lblYeuCau.Size = new System.Drawing.Size(248, 120);
            this.lblYeuCau.TabIndex = 22;
            this.lblYeuCau.Text = "Yêu cầu đặc biệt:";
            this.lblYeuCau.AutoSize = false; this.lblYeuCau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtYeuCauDacBiet
            // 
            this.tlpThongTin.SetColumnSpan(this.txtYeuCauDacBiet, 3);
            this.txtYeuCauDacBiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtYeuCauDacBiet.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtYeuCauDacBiet.Location = new System.Drawing.Point(268, 472);
            this.txtYeuCauDacBiet.Margin = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.txtYeuCauDacBiet.Multiline = true;
            this.txtYeuCauDacBiet.Name = "txtYeuCauDacBiet";
            this.txtYeuCauDacBiet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtYeuCauDacBiet.Size = new System.Drawing.Size(594, 104);
            this.txtYeuCauDacBiet.TabIndex = 23;
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.dgvChiTiet);
            this.grpChiTiet.Controls.Add(this.pnlChiTietInput);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpChiTiet.Location = new System.Drawing.Point(0, 0);
            this.grpChiTiet.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.grpChiTiet.Size = new System.Drawing.Size(1812, 610);
            this.grpChiTiet.TabIndex = 0;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Chi tiết hàng hóa";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTiet.ColumnHeadersHeight = 32;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(16, 226);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 82;
            this.dgvChiTiet.RowTemplate.Height = 30;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1780, 372);
            this.dgvChiTiet.TabIndex = 0;
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            // 
            // pnlChiTietInput
            // 
            this.pnlChiTietInput.BackColor = System.Drawing.Color.Transparent;
            this.pnlChiTietInput.Controls.Add(this.pnlChiTietRow2);
            this.pnlChiTietInput.Controls.Add(this.pnlChiTietRow1);
            this.pnlChiTietInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChiTietInput.Location = new System.Drawing.Point(16, 46);
            this.pnlChiTietInput.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlChiTietInput.Name = "pnlChiTietInput";
            this.pnlChiTietInput.Size = new System.Drawing.Size(1780, 180);
            this.pnlChiTietInput.TabIndex = 1;
            // 
            // pnlChiTietRow2
            // 
            this.pnlChiTietRow2.Controls.Add(this.lblMoTaHH);
            this.pnlChiTietRow2.Controls.Add(this.txtMoTaHangHoa);
            this.pnlChiTietRow2.Controls.Add(this.btnThemHangHoa);
            this.pnlChiTietRow2.Controls.Add(this.btnSuaHangHoa);
            this.pnlChiTietRow2.Controls.Add(this.btnXoaHangHoa);
            this.pnlChiTietRow2.Controls.Add(this.btnLamMoiHangHoa);
            this.pnlChiTietRow2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChiTietRow2.Location = new System.Drawing.Point(0, 76);
            this.pnlChiTietRow2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlChiTietRow2.Name = "pnlChiTietRow2";
            this.pnlChiTietRow2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.pnlChiTietRow2.Size = new System.Drawing.Size(1780, 104);
            this.pnlChiTietRow2.TabIndex = 0;
            this.pnlChiTietRow2.WrapContents = false;
            // 
            // lblMoTaHH
            // 
            this.lblMoTaHH.AutoSize = true;
            this.lblMoTaHH.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMoTaHH.Location = new System.Drawing.Point(0, 16);
            this.lblMoTaHH.Margin = new System.Windows.Forms.Padding(0, 12, 10, 0);
            this.lblMoTaHH.Name = "lblMoTaHH";
            this.lblMoTaHH.Size = new System.Drawing.Size(203, 36);
            this.lblMoTaHH.TabIndex = 0;
            this.lblMoTaHH.Text = "Mô tả hàng hóa:";
            // 
            // txtMoTaHangHoa
            // 
            this.txtMoTaHangHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMoTaHangHoa.Location = new System.Drawing.Point(219, 10);
            this.txtMoTaHangHoa.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtMoTaHangHoa.Name = "txtMoTaHangHoa";
            this.txtMoTaHangHoa.Size = new System.Drawing.Size(356, 41);
            this.txtMoTaHangHoa.TabIndex = 1;
            // 
            // btnThemHangHoa
            // 
            this.btnThemHangHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnThemHangHoa.Location = new System.Drawing.Point(611, 4);
            this.btnThemHangHoa.Margin = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.btnThemHangHoa.Name = "btnThemHangHoa";
            this.btnThemHangHoa.Size = new System.Drawing.Size(200, 72);
            this.btnThemHangHoa.TabIndex = 2;
            this.btnThemHangHoa.Text = "Thêm hàng";
            this.btnThemHangHoa.Click += new System.EventHandler(this.btnThemHangHoa_Click);
            // 
            // btnSuaHangHoa
            // 
            this.btnSuaHangHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSuaHangHoa.Location = new System.Drawing.Point(831, 4);
            this.btnSuaHangHoa.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSuaHangHoa.Name = "btnSuaHangHoa";
            this.btnSuaHangHoa.Size = new System.Drawing.Size(200, 72);
            this.btnSuaHangHoa.TabIndex = 3;
            this.btnSuaHangHoa.Text = "Sửa hàng";
            this.btnSuaHangHoa.Click += new System.EventHandler(this.btnSuaHangHoa_Click);
            // 
            // btnXoaHangHoa
            // 
            this.btnXoaHangHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnXoaHangHoa.Location = new System.Drawing.Point(1051, 4);
            this.btnXoaHangHoa.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnXoaHangHoa.Name = "btnXoaHangHoa";
            this.btnXoaHangHoa.Size = new System.Drawing.Size(200, 72);
            this.btnXoaHangHoa.TabIndex = 4;
            this.btnXoaHangHoa.Text = "Xóa hàng";
            this.btnXoaHangHoa.Click += new System.EventHandler(this.btnXoaHangHoa_Click);
            // 
            // btnLamMoiHangHoa
            // 
            this.btnLamMoiHangHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLamMoiHangHoa.Location = new System.Drawing.Point(1271, 4);
            this.btnLamMoiHangHoa.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLamMoiHangHoa.Name = "btnLamMoiHangHoa";
            this.btnLamMoiHangHoa.Size = new System.Drawing.Size(230, 72);
            this.btnLamMoiHangHoa.TabIndex = 5;
            this.btnLamMoiHangHoa.Text = "Làm mới";
            this.btnLamMoiHangHoa.Click += new System.EventHandler(this.btnLamMoiHangHoa_Click);
            // 
            // pnlChiTietRow1
            // 
            this.pnlChiTietRow1.Controls.Add(this.lblLoaiHH);
            this.pnlChiTietRow1.Controls.Add(this.cboLoaiHangHoa);
            this.pnlChiTietRow1.Controls.Add(this.lblKL);
            this.pnlChiTietRow1.Controls.Add(this.txtKhoiLuong);
            this.pnlChiTietRow1.Controls.Add(this.lblSK);
            this.pnlChiTietRow1.Controls.Add(this.txtSoKien);
            this.pnlChiTietRow1.Controls.Add(this.lblDVT);
            this.pnlChiTietRow1.Controls.Add(this.txtDonViTinh);
            this.pnlChiTietRow1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChiTietRow1.Location = new System.Drawing.Point(0, 0);
            this.pnlChiTietRow1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlChiTietRow1.Name = "pnlChiTietRow1";
            this.pnlChiTietRow1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlChiTietRow1.Size = new System.Drawing.Size(1780, 76);
            this.pnlChiTietRow1.TabIndex = 1;
            this.pnlChiTietRow1.WrapContents = false;
            // 
            // lblLoaiHH
            // 
            this.lblLoaiHH.AutoSize = true;
            this.lblLoaiHH.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLoaiHH.Location = new System.Drawing.Point(0, 20);
            this.lblLoaiHH.Margin = new System.Windows.Forms.Padding(0, 12, 10, 0);
            this.lblLoaiHH.Name = "lblLoaiHH";
            this.lblLoaiHH.Size = new System.Drawing.Size(182, 36);
            this.lblLoaiHH.TabIndex = 0;
            this.lblLoaiHH.Text = "Loại hàng hóa:";
            // 
            // cboLoaiHangHoa
            // 
            this.cboLoaiHangHoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiHangHoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboLoaiHangHoa.Location = new System.Drawing.Point(198, 14);
            this.cboLoaiHangHoa.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboLoaiHangHoa.Name = "cboLoaiHangHoa";
            this.cboLoaiHangHoa.Size = new System.Drawing.Size(336, 43);
            this.cboLoaiHangHoa.TabIndex = 1;
            // 
            // lblKL
            // 
            this.lblKL.AutoSize = true;
            this.lblKL.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKL.Location = new System.Drawing.Point(570, 20);
            this.lblKL.Margin = new System.Windows.Forms.Padding(30, 12, 10, 0);
            this.lblKL.Name = "lblKL";
            this.lblKL.Size = new System.Drawing.Size(146, 36);
            this.lblKL.TabIndex = 2;
            this.lblKL.Text = "Khối lượng:";
            // 
            // txtKhoiLuong
            // 
            this.txtKhoiLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtKhoiLuong.Location = new System.Drawing.Point(732, 14);
            this.txtKhoiLuong.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtKhoiLuong.Name = "txtKhoiLuong";
            this.txtKhoiLuong.Size = new System.Drawing.Size(156, 41);
            this.txtKhoiLuong.TabIndex = 3;
            // 
            // lblSK
            // 
            this.lblSK.AutoSize = true;
            this.lblSK.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSK.Location = new System.Drawing.Point(924, 20);
            this.lblSK.Margin = new System.Windows.Forms.Padding(30, 12, 10, 0);
            this.lblSK.Name = "lblSK";
            this.lblSK.Size = new System.Drawing.Size(105, 36);
            this.lblSK.TabIndex = 4;
            this.lblSK.Text = "Số kiện:";
            // 
            // txtSoKien
            // 
            this.txtSoKien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSoKien.Location = new System.Drawing.Point(1045, 14);
            this.txtSoKien.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtSoKien.Name = "txtSoKien";
            this.txtSoKien.Size = new System.Drawing.Size(126, 41);
            this.txtSoKien.TabIndex = 5;
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDVT.Location = new System.Drawing.Point(1207, 20);
            this.lblDVT.Margin = new System.Windows.Forms.Padding(30, 12, 10, 0);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(147, 36);
            this.lblDVT.TabIndex = 6;
            this.lblDVT.Text = "Đơn vị tính:";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDonViTinh.Location = new System.Drawing.Point(1370, 14);
            this.txtDonViTinh.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(156, 41);
            this.txtDonViTinh.TabIndex = 7;
            // 
            // FrmDonVanChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(2732, 1536);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(2706, 1465);
            this.Name = "FrmDonVanChuyen";
            this.Text = "Quản lý Đơn vận chuyển";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDonVanChuyen_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonVC)).EndInit();
            this.splitBottom.Panel1.ResumeLayout(false);
            this.splitBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBottom)).EndInit();
            this.splitBottom.ResumeLayout(false);
            this.grpThongTin.ResumeLayout(false);
            this.tlpThongTin.ResumeLayout(false);
            this.tlpThongTin.PerformLayout();
            this.grpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlChiTietInput.ResumeLayout(false);
            this.pnlChiTietRow2.ResumeLayout(false);
            this.pnlChiTietRow2.PerformLayout();
            this.pnlChiTietRow1.ResumeLayout(false);
            this.pnlChiTietRow1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}









