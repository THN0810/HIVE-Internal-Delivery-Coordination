namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.QuanTri
{
    partial class FrmTaiKhoan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtMaTK, txtTenDangNhap, txtMatKhau;
        private System.Windows.Forms.ComboBox cmbVaiTro, cmbNhanVien, cmbTrangThai;
        private System.Windows.Forms.Button btnThem, btnSua, btnLuu, btnHuy, btnLamMoi;
        private System.Windows.Forms.Label lblTitle, lblMaTK, lblTenDN, lblMK, lblVaiTro, lblNV, lblTrangThai;
        private System.Windows.Forms.Panel pnlTop, pnlToolbar, pnlBottom;
        private System.Windows.Forms.FlowLayoutPanel pnlFilter;

        // Filter controls
        private System.Windows.Forms.Label lblTimKiem, lblLocTrangThai;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnTimKiem, btnBoLoc;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaTK = new System.Windows.Forms.Label();
            this.txtMaTK = new System.Windows.Forms.TextBox();
            this.lblTenDN = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMK = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.cmbVaiTro = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.tlpThongTin.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.ColumnHeadersHeight = 46;
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(0, 297);
            this.dgvTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersWidth = 82;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(1650, 516);
            this.dgvTaiKhoan.TabIndex = 0;
            this.dgvTaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiKhoan_CellClick);
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.tlpThongTin);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Location = new System.Drawing.Point(22, 8);
            this.grpThongTin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpThongTin.Size = new System.Drawing.Size(1606, 257);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin tài khoản";
            // 
            // tlpThongTin
            // 
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpThongTin.Controls.Add(this.lblMaTK, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtMaTK, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblTenDN, 2, 0);
            this.tlpThongTin.Controls.Add(this.txtTenDangNhap, 3, 0);
            this.tlpThongTin.Controls.Add(this.lblMK, 0, 1);
            this.tlpThongTin.Controls.Add(this.txtMatKhau, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblNV, 2, 1);
            this.tlpThongTin.Controls.Add(this.cmbNhanVien, 3, 1);
            this.tlpThongTin.Controls.Add(this.lblVaiTro, 0, 2);
            this.tlpThongTin.Controls.Add(this.cmbVaiTro, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblTrangThai, 2, 2);
            this.tlpThongTin.Controls.Add(this.cmbTrangThai, 3, 2);
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.Location = new System.Drawing.Point(4, 41);
            this.tlpThongTin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpThongTin.Name = "tlpThongTin";
            this.tlpThongTin.Padding = new System.Windows.Forms.Padding(15, 31, 45, 16);
            this.tlpThongTin.RowCount = 3;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpThongTin.Size = new System.Drawing.Size(1598, 211);
            this.tlpThongTin.TabIndex = 0;
            // 
            // lblMaTK
            // 
            this.lblMaTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaTK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMaTK.Location = new System.Drawing.Point(19, 31);
            this.lblMaTK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaTK.Name = "lblMaTK";
            this.lblMaTK.Size = new System.Drawing.Size(202, 54);
            this.lblMaTK.TabIndex = 0;
            this.lblMaTK.Text = "Mã TK:";
            this.lblMaTK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaTK
            // 
            this.txtMaTK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaTK.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMaTK.Location = new System.Drawing.Point(229, 36);
            this.txtMaTK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaTK.Name = "txtMaTK";
            this.txtMaTK.ReadOnly = true;
            this.txtMaTK.Size = new System.Drawing.Size(615, 47);
            this.txtMaTK.TabIndex = 1;
            // 
            // lblTenDN
            // 
            this.lblTenDN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenDN.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTenDN.Location = new System.Drawing.Point(852, 31);
            this.lblTenDN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(187, 54);
            this.lblTenDN.TabIndex = 2;
            this.lblTenDN.Text = "Tên ĐN:";
            this.lblTenDN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTenDangNhap.Location = new System.Drawing.Point(1047, 36);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(502, 47);
            this.txtTenDangNhap.TabIndex = 3;
            // 
            // lblMK
            // 
            this.lblMK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMK.Location = new System.Drawing.Point(19, 85);
            this.lblMK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMK.Name = "lblMK";
            this.lblMK.Size = new System.Drawing.Size(202, 54);
            this.lblMK.TabIndex = 4;
            this.lblMK.Text = "Mật khẩu:";
            this.lblMK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMatKhau.Location = new System.Drawing.Point(229, 90);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Size = new System.Drawing.Size(615, 47);
            this.txtMatKhau.TabIndex = 5;
            // 
            // lblNV
            // 
            this.lblNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNV.Location = new System.Drawing.Point(852, 85);
            this.lblNV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(187, 54);
            this.lblNV.TabIndex = 6;
            this.lblNV.Text = "Nhân viên:";
            this.lblNV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbNhanVien.Location = new System.Drawing.Point(1047, 90);
            this.cmbNhanVien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(502, 48);
            this.cmbNhanVien.TabIndex = 7;
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVaiTro.Location = new System.Drawing.Point(19, 139);
            this.lblVaiTro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(202, 56);
            this.lblVaiTro.TabIndex = 8;
            this.lblVaiTro.Text = "Vai trò:";
            this.lblVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbVaiTro
            // 
            this.cmbVaiTro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVaiTro.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbVaiTro.Location = new System.Drawing.Point(229, 144);
            this.cmbVaiTro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbVaiTro.Name = "cmbVaiTro";
            this.cmbVaiTro.Size = new System.Drawing.Size(615, 48);
            this.cmbVaiTro.TabIndex = 9;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThai.Location = new System.Drawing.Point(852, 139);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(187, 56);
            this.lblTrangThai.TabIndex = 10;
            this.lblTrangThai.Text = "Trạng thái:";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbTrangThai.Location = new System.Drawing.Point(1047, 144);
            this.cmbTrangThai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(502, 48);
            this.cmbTrangThai.TabIndex = 11;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(30, 12);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(180, 70);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "＋ Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(225, 12);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(180, 70);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "✎ Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(420, 12);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(180, 70);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(615, 12);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(240, 70);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "↩ Hủy thao tác";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(870, 12);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(180, 70);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "⟳ Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 19);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(459, 59);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1650, 86);
            this.pnlTop.TabIndex = 4;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlToolbar.Controls.Add(this.btnLamMoi);
            this.pnlToolbar.Controls.Add(this.btnHuy);
            this.pnlToolbar.Controls.Add(this.btnLuu);
            this.pnlToolbar.Controls.Add(this.btnSua);
            this.pnlToolbar.Controls.Add(this.btnThem);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 86);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1650, 102);
            this.pnlToolbar.TabIndex = 3;
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
            this.pnlFilter.Location = new System.Drawing.Point(0, 188);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(22, 16, 22, 16);
            this.pnlFilter.Size = new System.Drawing.Size(1650, 109);
            this.pnlFilter.TabIndex = 2;
            this.pnlFilter.WrapContents = false;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblTimKiem.Location = new System.Drawing.Point(22, 24);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(0, 8, 8, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(137, 38);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(171, 21);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(373, 45);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblLocTrangThai.Location = new System.Drawing.Point(570, 24);
            this.lblLocTrangThai.Margin = new System.Windows.Forms.Padding(22, 8, 8, 0);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(185, 38);
            this.lblLocTrangThai.TabIndex = 2;
            this.lblLocTrangThai.Text = "Trạng thái TK:";
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboLocTrangThai.Location = new System.Drawing.Point(767, 21);
            this.cboLocTrangThai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(223, 46);
            this.cboLocTrangThai.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnTimKiem.Location = new System.Drawing.Point(1016, 16);
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
            this.btnBoLoc.Location = new System.Drawing.Point(1242, 16);
            this.btnBoLoc.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(210, 70);
            this.btnBoLoc.TabIndex = 5;
            this.btnBoLoc.Text = "✕ Bỏ lọc";
            this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.grpThongTin);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 813);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(22, 8, 22, 16);
            this.pnlBottom.Size = new System.Drawing.Size(1650, 281);
            this.pnlBottom.TabIndex = 1;
            // 
            // FrmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1650, 1094);
            this.Controls.Add(this.dgvTaiKhoan);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmTaiKhoan";
            this.Text = "Quản lý tài khoản";
            this.Load += new System.EventHandler(this.FrmTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.tlpThongTin.ResumeLayout(false);
            this.tlpThongTin.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
    }
}
