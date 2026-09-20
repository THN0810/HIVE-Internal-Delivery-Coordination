namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.NguonLuc
{
    partial class FrmPhuongTien
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPhuongTien;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtMaPT, txtBienSoXe, txtTaiTrong;
        private System.Windows.Forms.ComboBox cmbLoaiPT, cmbTinhTrang;
        private System.Windows.Forms.Button btnThem, btnSua, btnLuu, btnHuy, btnLamMoi;
        private System.Windows.Forms.Label lblMaPT, lblBienSoXe, lblTaiTrong, lblLoaiPT, lblTinhTrang;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTop, pnlToolbar, pnlFilter, pnlBottom;
        
        // Filter controls
        private System.Windows.Forms.Label lblTimKiem, lblLocLoaiPT, lblLocTinhTrang;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocLoaiPT, cboLocTinhTrang;
        private System.Windows.Forms.Button btnTimKiem, btnBoLoc;

        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            var fNormal = new System.Drawing.Font("Segoe UI", 10.5F);
            
            this.dgvPhuongTien = new System.Windows.Forms.DataGridView();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtMaPT = new System.Windows.Forms.TextBox(); this.txtBienSoXe = new System.Windows.Forms.TextBox();
            this.txtTaiTrong = new System.Windows.Forms.TextBox(); 
            this.cmbLoaiPT = new System.Windows.Forms.ComboBox(); this.cmbTinhTrang = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button(); this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button(); this.btnHuy = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            
            this.lblMaPT = new System.Windows.Forms.Label(); this.lblBienSoXe = new System.Windows.Forms.Label();
            this.lblTaiTrong = new System.Windows.Forms.Label(); this.lblLoaiPT = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label(); 
            this.lblTitle = new System.Windows.Forms.Label();
            
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocLoaiPT = new System.Windows.Forms.Label();
            this.cboLocLoaiPT = new System.Windows.Forms.ComboBox();
            this.lblLocTinhTrang = new System.Windows.Forms.Label();
            this.cboLocTinhTrang = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuongTien)).BeginInit();
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
            this.lblTitle.Text = "QUẢN LÝ PHƯƠNG TIỆN";

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
            
            this.lblLocLoaiPT.AutoSize = true; this.lblLocLoaiPT.Font = fNormal; this.lblLocLoaiPT.Text = "Loại PT:"; this.lblLocLoaiPT.Margin = new System.Windows.Forms.Padding(15, 5, 5, 0);
            this.cboLocLoaiPT.Font = fNormal; this.cboLocLoaiPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboLocLoaiPT.Size = new System.Drawing.Size(150, 30);
            
            this.lblLocTinhTrang.AutoSize = true; this.lblLocTinhTrang.Font = fNormal; this.lblLocTinhTrang.Text = "Tình trạng:"; this.lblLocTinhTrang.Margin = new System.Windows.Forms.Padding(15, 5, 5, 0);
            this.cboLocTinhTrang.Font = fNormal; this.cboLocTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboLocTinhTrang.Size = new System.Drawing.Size(150, 30);

            this.btnTimKiem.Font = fNormal; this.btnTimKiem.Size = new System.Drawing.Size(140, 45); this.btnTimKiem.Text = "🔍 Tìm"; this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click); this.btnTimKiem.Margin = new System.Windows.Forms.Padding(15, 0, 5, 0);
            this.btnBoLoc.Font = fNormal; this.btnBoLoc.Size = new System.Drawing.Size(140, 45); this.btnBoLoc.Text = "✕ Bỏ lọc"; this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click); this.btnBoLoc.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);

            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTimKiem, this.txtTimKiem,
                this.lblLocLoaiPT, this.cboLocLoaiPT,
                this.lblLocTinhTrang, this.cboLocTinhTrang,
                this.btnTimKiem, this.btnBoLoc
            });

            // ═══════════════════════════════════════════════════
            // pnlBottom — GroupBox input
            // ═══════════════════════════════════════════════════
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 180;
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(15, 5, 15, 10);
            this.tlpThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBottom.Controls.Add(this.grpThongTin);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.Text = "Thông tin phương tiện";
            
            this.tlpThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThongTin.ColumnCount = 4;
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThongTin.RowCount = 3;
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpThongTin.Padding = new System.Windows.Forms.Padding(10, 20, 30, 10);

            // Input fields — 2 cột
            System.Drawing.Font lf = new System.Drawing.Font("Segoe UI", 10F);
            System.Drawing.Font tf = new System.Drawing.Font("Segoe UI", 11F);

            // Cột Trái
            this.lblMaPT.Dock = System.Windows.Forms.DockStyle.Fill; this.lblMaPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblMaPT.Font = lf; this.lblMaPT.Text = "Mã PT:";
            this.txtMaPT.Font = tf; this.txtMaPT.ReadOnly = true; this.txtMaPT.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblTaiTrong.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTaiTrong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblTaiTrong.Font = lf; this.lblTaiTrong.Text = "Tải trọng:";
            this.txtTaiTrong.Font = tf; this.txtTaiTrong.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblTinhTrang.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTinhTrang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblTinhTrang.Font = lf; this.lblTinhTrang.Text = "Tình trạng:";
            this.cmbTinhTrang.Font = tf; this.cmbTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbTinhTrang.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            // Cột Phải
            this.lblBienSoXe.Dock = System.Windows.Forms.DockStyle.Fill; this.lblBienSoXe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblBienSoXe.Font = lf; this.lblBienSoXe.Text = "Biển số xe:";
            this.txtBienSoXe.Font = tf; this.txtBienSoXe.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.lblLoaiPT.Dock = System.Windows.Forms.DockStyle.Fill; this.lblLoaiPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblLoaiPT.Font = lf; this.lblLoaiPT.Text = "Loại PT:";
            this.cmbLoaiPT.Font = tf; this.cmbLoaiPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbLoaiPT.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            
            this.tlpThongTin.Controls.Add(this.lblMaPT, 0, 0);
            this.tlpThongTin.Controls.Add(this.txtMaPT, 1, 0);
            this.tlpThongTin.Controls.Add(this.lblBienSoXe, 2, 0);
            this.tlpThongTin.Controls.Add(this.txtBienSoXe, 3, 0);
            
            this.tlpThongTin.Controls.Add(this.lblTaiTrong, 0, 1);
            this.tlpThongTin.Controls.Add(this.txtTaiTrong, 1, 1);
            this.tlpThongTin.Controls.Add(this.lblLoaiPT, 2, 1);
            this.tlpThongTin.Controls.Add(this.cmbLoaiPT, 3, 1);
            
            this.tlpThongTin.Controls.Add(this.lblTinhTrang, 0, 2);
            this.tlpThongTin.Controls.Add(this.cmbTinhTrang, 1, 2);
            
            this.grpThongTin.Controls.Add(this.tlpThongTin);

            // ═══════════════════════════════════════════════════
            // dgvPhuongTien
            // ═══════════════════════════════════════════════════
            this.dgvPhuongTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhuongTien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhuongTien_CellClick);

            // ═══════════════════════════════════════════════════
            // FrmPhuongTien
            // ═══════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.dgvPhuongTien);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmPhuongTien";
            this.Text = "Quản lý Phương tiện";
            this.Load += new System.EventHandler(this.FrmPhuongTien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhuongTien)).EndInit();
            this.ResumeLayout(false);
        }
        
        private System.Windows.Forms.TableLayoutPanel tlpThongTin;
    }
}
