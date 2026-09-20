namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.TaiXeNhiemVu
{
    partial class FrmNhiemVuTaiXe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvNhiemVu;
        private System.Windows.Forms.TextBox txtMaLenhDP, txtLyDo;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label lblTitle, lblMaLenh, lblTrangThai, lblLyDo;
        private System.Windows.Forms.Panel pnlTop, pnlToolbar;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.dgvNhiemVu = new System.Windows.Forms.DataGridView();
            this.txtMaLenhDP = new System.Windows.Forms.TextBox();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMaLenh = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhiemVu)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNhiemVu
            // 
            this.dgvNhiemVu.ColumnHeadersHeight = 46;
            this.dgvNhiemVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhiemVu.Location = new System.Drawing.Point(0, 188);
            this.dgvNhiemVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvNhiemVu.Name = "dgvNhiemVu";
            this.dgvNhiemVu.RowHeadersWidth = 82;
            this.dgvNhiemVu.Size = new System.Drawing.Size(1650, 750);
            this.dgvNhiemVu.TabIndex = 0;
            this.dgvNhiemVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhiemVu_CellClick);
            // 
            // txtMaLenhDP
            // 
            this.txtMaLenhDP.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMaLenhDP.Location = new System.Drawing.Point(150, 25);
            this.txtMaLenhDP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaLenhDP.Name = "txtMaLenhDP";
            this.txtMaLenhDP.ReadOnly = true;
            this.txtMaLenhDP.Size = new System.Drawing.Size(193, 47);
            this.txtMaLenhDP.TabIndex = 1;
            // 
            // txtLyDo
            // 
            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtLyDo.Location = new System.Drawing.Point(915, 25);
            this.txtLyDo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(388, 47);
            this.txtLyDo.TabIndex = 5;
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbTrangThai.Location = new System.Drawing.Point(518, 25);
            this.cmbTrangThai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(283, 48);
            this.cmbTrangThai.TabIndex = 3;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCapNhat.Location = new System.Drawing.Point(1335, 16);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(240, 70);
            this.btnCapNhat.TabIndex = 6;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 19);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(385, 59);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Nhiệm Vụ Của Tôi";
            // 
            // lblMaLenh
            // 
            this.lblMaLenh.AutoSize = true;
            this.lblMaLenh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMaLenh.Location = new System.Drawing.Point(22, 31);
            this.lblMaLenh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaLenh.Name = "lblMaLenh";
            this.lblMaLenh.Size = new System.Drawing.Size(132, 41);
            this.lblMaLenh.TabIndex = 0;
            this.lblMaLenh.Text = "Mã lệnh:";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTrangThai.Location = new System.Drawing.Point(355, 31);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(155, 41);
            this.lblTrangThai.TabIndex = 2;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblLyDo.Location = new System.Drawing.Point(810, 28);
            this.lblLyDo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(97, 41);
            this.lblLyDo.TabIndex = 4;
            this.lblLyDo.Text = "Lý do:";
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
            this.pnlTop.TabIndex = 2;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlToolbar.Controls.Add(this.lblMaLenh);
            this.pnlToolbar.Controls.Add(this.txtMaLenhDP);
            this.pnlToolbar.Controls.Add(this.lblTrangThai);
            this.pnlToolbar.Controls.Add(this.cmbTrangThai);
            this.pnlToolbar.Controls.Add(this.lblLyDo);
            this.pnlToolbar.Controls.Add(this.txtLyDo);
            this.pnlToolbar.Controls.Add(this.btnCapNhat);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 86);
            this.pnlToolbar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1650, 102);
            this.pnlToolbar.TabIndex = 1;
            // 
            // FrmNhiemVuTaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1650, 938);
            this.Controls.Add(this.dgvNhiemVu);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmNhiemVuTaiXe";
            this.Text = "Nhiệm vụ của tôi";
            this.Load += new System.EventHandler(this.FrmNhiemVuTaiXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhiemVu)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
