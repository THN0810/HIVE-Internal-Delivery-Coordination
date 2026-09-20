namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.BaoCao
{
    partial class FrmBaoCao
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.ComboBox cmbLoaiBaoCao, cboDinhDangXuat, cmbTieuChiThongKe;
        private System.Windows.Forms.DateTimePicker dtpTuNgay, dtpDenNgay;
        private System.Windows.Forms.Button btnXem, btnXuatBaoCao, btnLamMoi;
        private System.Windows.Forms.Label lblTitle, lblLoai, lblTuNgay, lblDenNgay, lblDinhDang, lblTieuChi;
        private System.Windows.Forms.Panel pnlTop, pnlToolbar, pnlTongHop;
        private System.Windows.Forms.Label lblTongHop1, lblTongHop2, lblTongHop3, lblTongHop4;

        // Bổ sung tìm kiếm cục bộ trên lưới
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem, btnBoLoc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.cmbLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.cmbTieuChiThongKe = new System.Windows.Forms.ComboBox();
            this.cboDinhDangXuat = new System.Windows.Forms.ComboBox();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXuatBaoCao = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lblTieuChi = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblDinhDang = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            this.pnlTongHop = new System.Windows.Forms.Panel();
            this.lblTongHop1 = new System.Windows.Forms.Label();
            this.lblTongHop2 = new System.Windows.Forms.Label();
            this.lblTongHop3 = new System.Windows.Forms.Label();
            this.lblTongHop4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlTongHop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.ColumnHeadersHeight = 46;
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCao.Location = new System.Drawing.Point(0, 539);
            this.dgvBaoCao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersWidth = 82;
            this.dgvBaoCao.Size = new System.Drawing.Size(1650, 399);
            this.dgvBaoCao.TabIndex = 0;
            // 
            // cmbLoaiBaoCao
            // 
            this.cmbLoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiBaoCao.DropDownWidth = 320;
            this.cmbLoaiBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbLoaiBaoCao.Location = new System.Drawing.Point(321, 28);
            this.cmbLoaiBaoCao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLoaiBaoCao.Name = "cmbLoaiBaoCao";
            this.cmbLoaiBaoCao.Size = new System.Drawing.Size(433, 48);
            this.cmbLoaiBaoCao.TabIndex = 1;
            // 
            // cmbTieuChiThongKe
            // 
            this.cmbTieuChiThongKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTieuChiThongKe.DropDownWidth = 320;
            this.cmbTieuChiThongKe.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbTieuChiThongKe.Location = new System.Drawing.Point(321, 99);
            this.cmbTieuChiThongKe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTieuChiThongKe.Name = "cmbTieuChiThongKe";
            this.cmbTieuChiThongKe.Size = new System.Drawing.Size(433, 48);
            this.cmbTieuChiThongKe.TabIndex = 3;
            // 
            // cboDinhDangXuat
            // 
            this.cboDinhDangXuat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDinhDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboDinhDangXuat.Location = new System.Drawing.Point(321, 169);
            this.cboDinhDangXuat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboDinhDangXuat.Name = "cboDinhDangXuat";
            this.cboDinhDangXuat.Size = new System.Drawing.Size(298, 48);
            this.cboDinhDangXuat.TabIndex = 11;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(951, 28);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(193, 47);
            this.dtpTuNgay.TabIndex = 5;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(951, 99);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(193, 47);
            this.dtpDenNgay.TabIndex = 7;
            // 
            // btnXem
            // 
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXem.Location = new System.Drawing.Point(1176, 28);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(270, 117);
            this.btnXem.TabIndex = 8;
            this.btnXem.Text = "Xem báo cáo";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXuatBaoCao.Location = new System.Drawing.Point(651, 161);
            this.btnXuatBaoCao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size = new System.Drawing.Size(300, 62);
            this.btnXuatBaoCao.TabIndex = 12;
            this.btnXuatBaoCao.Text = "Xuất báo cáo";
            this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLamMoi.Location = new System.Drawing.Point(1191, 236);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(210, 62);
            this.btnLamMoi.TabIndex = 9;
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
            this.lblTitle.Size = new System.Drawing.Size(449, 59);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO THỐNG KÊ";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblLoai.Location = new System.Drawing.Point(22, 28);
            this.lblLoai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(193, 41);
            this.lblLoai.TabIndex = 0;
            this.lblLoai.Text = "Loại báo cáo:";
            // 
            // lblTieuChi
            // 
            this.lblTieuChi.AutoSize = true;
            this.lblTieuChi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTieuChi.Location = new System.Drawing.Point(22, 98);
            this.lblTieuChi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTieuChi.Name = "lblTieuChi";
            this.lblTieuChi.Size = new System.Drawing.Size(127, 41);
            this.lblTieuChi.TabIndex = 2;
            this.lblTieuChi.Text = "Tiêu chí:";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTuNgay.Location = new System.Drawing.Point(786, 33);
            this.lblTuNgay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(132, 41);
            this.lblTuNgay.TabIndex = 4;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDenNgay.Location = new System.Drawing.Point(786, 103);
            this.lblDenNgay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(152, 41);
            this.lblDenNgay.TabIndex = 6;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblDinhDang
            // 
            this.lblDinhDang.AutoSize = true;
            this.lblDinhDang.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDinhDang.Location = new System.Drawing.Point(22, 169);
            this.lblDinhDang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDinhDang.Name = "lblDinhDang";
            this.lblDinhDang.Size = new System.Drawing.Size(227, 41);
            this.lblDinhDang.TabIndex = 10;
            this.lblDinhDang.Text = "Định dạng xuất:";
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
            this.pnlTop.TabIndex = 3;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlToolbar.Controls.Add(this.lblLoai);
            this.pnlToolbar.Controls.Add(this.cmbLoaiBaoCao);
            this.pnlToolbar.Controls.Add(this.lblTieuChi);
            this.pnlToolbar.Controls.Add(this.cmbTieuChiThongKe);
            this.pnlToolbar.Controls.Add(this.lblTuNgay);
            this.pnlToolbar.Controls.Add(this.dtpTuNgay);
            this.pnlToolbar.Controls.Add(this.lblDenNgay);
            this.pnlToolbar.Controls.Add(this.dtpDenNgay);
            this.pnlToolbar.Controls.Add(this.btnXem);
            this.pnlToolbar.Controls.Add(this.btnLamMoi);
            this.pnlToolbar.Controls.Add(this.lblDinhDang);
            this.pnlToolbar.Controls.Add(this.cboDinhDangXuat);
            this.pnlToolbar.Controls.Add(this.btnXuatBaoCao);
            this.pnlToolbar.Controls.Add(this.lblTimKiem);
            this.pnlToolbar.Controls.Add(this.txtTimKiem);
            this.pnlToolbar.Controls.Add(this.btnTimKiem);
            this.pnlToolbar.Controls.Add(this.btnBoLoc);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 86);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1650, 312);
            this.pnlToolbar.TabIndex = 2;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTimKiem.Location = new System.Drawing.Point(22, 239);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(269, 41);
            this.lblTimKiem.TabIndex = 13;
            this.lblTimKiem.Text = "Tìm trong báo cáo:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTimKiem.Location = new System.Drawing.Point(321, 244);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(383, 47);
            this.txtTimKiem.TabIndex = 14;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTimKiem.Location = new System.Drawing.Point(741, 236);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(210, 62);
            this.btnTimKiem.TabIndex = 15;
            this.btnTimKiem.Text = "🔍 Tìm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBoLoc.Location = new System.Drawing.Point(966, 236);
            this.btnBoLoc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(210, 62);
            this.btnBoLoc.TabIndex = 16;
            this.btnBoLoc.Text = "✕ Bỏ lọc";
            this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);
            // 
            // pnlTongHop
            // 
            this.pnlTongHop.BackColor = System.Drawing.Color.White;
            this.pnlTongHop.Controls.Add(this.lblTongHop1);
            this.pnlTongHop.Controls.Add(this.lblTongHop2);
            this.pnlTongHop.Controls.Add(this.lblTongHop3);
            this.pnlTongHop.Controls.Add(this.lblTongHop4);
            this.pnlTongHop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTongHop.Location = new System.Drawing.Point(0, 398);
            this.pnlTongHop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTongHop.Name = "pnlTongHop";
            this.pnlTongHop.Padding = new System.Windows.Forms.Padding(22, 23, 22, 23);
            this.pnlTongHop.Size = new System.Drawing.Size(1650, 141);
            this.pnlTongHop.TabIndex = 1;
            // 
            // lblTongHop1
            // 
            this.lblTongHop1.AutoSize = true;
            this.lblTongHop1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongHop1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(33)))), ((int)(((byte)(55)))));
            this.lblTongHop1.Location = new System.Drawing.Point(30, 23);
            this.lblTongHop1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongHop1.Name = "lblTongHop1";
            this.lblTongHop1.Size = new System.Drawing.Size(0, 45);
            this.lblTongHop1.TabIndex = 0;
            // 
            // lblTongHop2
            // 
            this.lblTongHop2.AutoSize = true;
            this.lblTongHop2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongHop2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.lblTongHop2.Location = new System.Drawing.Point(750, 23);
            this.lblTongHop2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongHop2.Name = "lblTongHop2";
            this.lblTongHop2.Size = new System.Drawing.Size(0, 45);
            this.lblTongHop2.TabIndex = 1;
            // 
            // lblTongHop3
            // 
            this.lblTongHop3.AutoSize = true;
            this.lblTongHop3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongHop3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblTongHop3.Location = new System.Drawing.Point(30, 78);
            this.lblTongHop3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongHop3.Name = "lblTongHop3";
            this.lblTongHop3.Size = new System.Drawing.Size(0, 45);
            this.lblTongHop3.TabIndex = 2;
            // 
            // lblTongHop4
            // 
            this.lblTongHop4.AutoSize = true;
            this.lblTongHop4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongHop4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblTongHop4.Location = new System.Drawing.Point(750, 78);
            this.lblTongHop4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongHop4.Name = "lblTongHop4";
            this.lblTongHop4.Size = new System.Drawing.Size(0, 45);
            this.lblTongHop4.TabIndex = 3;
            // 
            // FrmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1650, 938);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.pnlTongHop);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmBaoCao";
            this.Text = "Báo cáo thống kê";
            this.Load += new System.EventHandler(this.FrmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlTongHop.ResumeLayout(false);
            this.pnlTongHop.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
