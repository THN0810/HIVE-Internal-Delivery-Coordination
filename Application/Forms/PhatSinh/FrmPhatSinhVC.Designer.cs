namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.PhatSinh
{
    partial class FrmPhatSinhVC
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPhatSinh;
        private System.Windows.Forms.TextBox txtMaPhieuPS, txtNoiDung, txtHuongXuLy, txtKetQua;
        private System.Windows.Forms.ComboBox cmbTrangThaiXL, cmbDonVC, cmbLenhDP;
        private System.Windows.Forms.Button btnThem, btnSua, btnLuu, btnHuy, btnLamMoi;
        private System.Windows.Forms.Label lblTitle, lblMa, lblNoiDung, lblHuongXL, lblKetQua, lblTrangThai, lblDonVC, lblLenhDP;
        private System.Windows.Forms.Panel pnlTop, pnlToolbar, pnlBottom;
        private System.Windows.Forms.FlowLayoutPanel pnlFilter;
        private System.Windows.Forms.GroupBox grpThongTin;

        // Filter controls
        private System.Windows.Forms.Label lblTimKiem, lblLocTrangThaiXL;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocTrangThaiXL;
        private System.Windows.Forms.Button btnTimKiem, btnBoLoc;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            var fNormal = new System.Drawing.Font("Segoe UI", 10.5F);

            this.dgvPhatSinh = new System.Windows.Forms.DataGridView();
            this.txtMaPhieuPS = new System.Windows.Forms.TextBox(); this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtHuongXuLy = new System.Windows.Forms.TextBox(); this.txtKetQua = new System.Windows.Forms.TextBox();
            this.cmbTrangThaiXL = new System.Windows.Forms.ComboBox(); this.cmbDonVC = new System.Windows.Forms.ComboBox(); this.cmbLenhDP = new System.Windows.Forms.ComboBox();
            
            this.btnThem = new System.Windows.Forms.Button(); this.btnSua = new System.Windows.Forms.Button(); 
            this.btnLuu = new System.Windows.Forms.Button(); this.btnHuy = new System.Windows.Forms.Button(); 
            this.btnLamMoi = new System.Windows.Forms.Button();
            
            this.lblTitle = new System.Windows.Forms.Label(); this.lblMa = new System.Windows.Forms.Label();
            this.lblNoiDung = new System.Windows.Forms.Label(); this.lblHuongXL = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label(); this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblDonVC = new System.Windows.Forms.Label(); this.lblLenhDP = new System.Windows.Forms.Label();
            
            this.pnlTop = new System.Windows.Forms.Panel(); this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBottom = new System.Windows.Forms.Panel(); this.grpThongTin = new System.Windows.Forms.GroupBox();

            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocTrangThaiXL = new System.Windows.Forms.Label();
            this.cboLocTrangThaiXL = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPhatSinh)).BeginInit(); 
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
            this.lblTitle.Text = "QUẢN LÝ PHÁT SINH VẬN CHUYỂN";

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
            
            this.lblLocTrangThaiXL.AutoSize = true; this.lblLocTrangThaiXL.Font = fNormal; this.lblLocTrangThaiXL.Text = "Trạng thái XL:"; this.lblLocTrangThaiXL.Margin = new System.Windows.Forms.Padding(15, 5, 5, 0);
            this.cboLocTrangThaiXL.Font = fNormal; this.cboLocTrangThaiXL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboLocTrangThaiXL.Size = new System.Drawing.Size(150, 30);

            this.btnTimKiem.Font = fNormal; this.btnTimKiem.Size = new System.Drawing.Size(140, 45); this.btnTimKiem.Text = "🔍 Tìm"; this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click); this.btnTimKiem.Margin = new System.Windows.Forms.Padding(15, 0, 5, 0);
            this.btnBoLoc.Font = fNormal; this.btnBoLoc.Size = new System.Drawing.Size(140, 45); this.btnBoLoc.Text = "✕ Bỏ lọc"; this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click); this.btnBoLoc.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);

            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTimKiem, this.txtTimKiem,
                this.lblLocTrangThaiXL, this.cboLocTrangThaiXL,
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
            this.grpThongTin.Text = "Thông tin phiếu phát sinh";
            
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
            this.txtMaPhieuPS.Font = tf; this.txtMaPhieuPS.ReadOnly = true; this.txtMaPhieuPS.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblLenhDP.Dock = System.Windows.Forms.DockStyle.Fill; this.lblLenhDP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblLenhDP.Font = lf; this.lblLenhDP.Text = "Lệnh ĐP:";
            this.cmbLenhDP.Font = tf; this.cmbLenhDP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbLenhDP.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblHuongXL.Dock = System.Windows.Forms.DockStyle.Fill; this.lblHuongXL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblHuongXL.Font = lf; this.lblHuongXL.Text = "Hướng XL:";
            this.txtHuongXuLy.Font = tf; this.txtHuongXuLy.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblTrangThai.Font = lf; this.lblTrangThai.Text = "Trạng thái XL:";
            this.cmbTrangThaiXL.Font = tf; this.cmbTrangThaiXL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbTrangThaiXL.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            // Cột Phải
            this.lblDonVC.Dock = System.Windows.Forms.DockStyle.Fill; this.lblDonVC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblDonVC.Font = lf; this.lblDonVC.Text = "Đơn VC:";
            this.cmbDonVC.Font = tf; this.cmbDonVC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbDonVC.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblNoiDung.Dock = System.Windows.Forms.DockStyle.Fill; this.lblNoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblNoiDung.Font = lf; this.lblNoiDung.Text = "Nội dung:";
            this.txtNoiDung.Font = tf; this.txtNoiDung.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblKetQua.Dock = System.Windows.Forms.DockStyle.Fill; this.lblKetQua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblKetQua.Font = lf; this.lblKetQua.Text = "Kết quả:";
            this.txtKetQua.Font = tf; this.txtKetQua.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.tlpThongTin.Controls.Add(this.lblMa, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtMaPhieuPS, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblDonVC, 2, 0);
            this.tlpThongTin.Controls.Add(this.cmbDonVC, 3, 0);
            
            this.tlpThongTin.Controls.Add(this.lblLenhDP, 0, 1);
            this.tlpThongTin.Controls.Add(this.cmbLenhDP, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblNoiDung, 2, 1);
            this.tlpThongTin.Controls.Add(this.txtNoiDung, 3, 1);
            
            this.tlpThongTin.Controls.Add(this.lblHuongXL, 0, 2);
            this.tlpThongTin.Controls.Add(this.txtHuongXuLy, 1, 2);
            this.tlpThongTin.Controls.Add(this.lblKetQua, 2, 2);
            this.tlpThongTin.Controls.Add(this.txtKetQua, 3, 2);
            
            this.tlpThongTin.Controls.Add(this.lblTrangThai, 0, 3);
            this.tlpThongTin.Controls.Add(this.cmbTrangThaiXL, 1, 3);
            
            this.grpThongTin.Controls.Add(this.tlpThongTin);
                
            // ═══════════════════════════════════════════════════
            // dgvPhatSinh
            // ═══════════════════════════════════════════════════
            this.dgvPhatSinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhatSinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhatSinh_CellClick);

            // ═══════════════════════════════════════════════════
            // FrmPhatSinhVC
            // ═══════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F); 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            
            this.Controls.Add(this.dgvPhatSinh); 
            this.Controls.Add(this.pnlBottom); 
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlToolbar); 
            this.Controls.Add(this.pnlTop);
            
            this.Name = "FrmPhatSinhVC"; 
            this.Text = "Phát sinh vận chuyển";
            this.Load += new System.EventHandler(this.FrmPhatSinhVC_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhatSinh)).EndInit(); 
            this.ResumeLayout(false);
        }
        
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
    }
}
