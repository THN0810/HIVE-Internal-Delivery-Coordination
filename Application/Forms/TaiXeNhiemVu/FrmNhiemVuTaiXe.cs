using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Forms.TaiXeNhiemVu
{
    public partial class FrmNhiemVuTaiXe : Form
    {
        public FrmNhiemVuTaiXe() { InitializeComponent(); }

        private void FrmNhiemVuTaiXe_Load(object sender, EventArgs e)
        {
            this.BackColor = UIHelper.BgMain; UIHelper.StyleDataGridView(dgvNhiemVu);
            UIHelper.StyleButtonOrange(btnCapNhat); lblTitle.ForeColor = UIHelper.Navy;
            cmbTrangThai.SelectedIndexChanged += cmbTrangThai_SelectedIndexChanged;
            LoadNhiemVu();
        }

        private void cmbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLyDo.Enabled = (cmbTrangThai.Text == "Từ chối");
        }

        private void LoadNhiemVu()
        {
            string query = @"
                SELECT ldp.MaLenhDP, ldp.MaDonVC, dvc.DiaChiLayHang, dvc.DiaChiGiao,
                       dvc.TenNguoiNhan, dvc.SDTNguoiNhan, pt.BienSoXe,
                       ldp.TrangThaiLenh, ldp.TGPhanCong, ldp.LyDoTuChoi
                FROM LenhDieuPhoi ldp
                INNER JOIN DonVanChuyen dvc ON ldp.MaDonVC = dvc.MaDonVC
                INNER JOIN PhuongTien pt ON ldp.MaPT = pt.MaPT
                WHERE ldp.MaNV = @MaNV
                ORDER BY ldp.TGPhanCong DESC";
            dgvNhiemVu.DataSource = DatabaseHelper.GetDataTable(query, new SqlParameter[] { new SqlParameter("@MaNV", SessionManager.MaNV) });
            SetupGridColumns();
        }

        private void SetupGridColumns()
        {
            if (dgvNhiemVu.Columns.Count > 0)
            {
                if (dgvNhiemVu.Columns.Contains("MaLenhDP")) dgvNhiemVu.Columns["MaLenhDP"].HeaderText = "Mã lệnh";
                if (dgvNhiemVu.Columns.Contains("MaDonVC")) dgvNhiemVu.Columns["MaDonVC"].HeaderText = "Mã đơn";
                if (dgvNhiemVu.Columns.Contains("DiaChiLayHang")) dgvNhiemVu.Columns["DiaChiLayHang"].HeaderText = "Địa chỉ lấy hàng";
                if (dgvNhiemVu.Columns.Contains("DiaChiGiao")) dgvNhiemVu.Columns["DiaChiGiao"].HeaderText = "Địa chỉ giao";
                if (dgvNhiemVu.Columns.Contains("TenNguoiNhan")) dgvNhiemVu.Columns["TenNguoiNhan"].HeaderText = "Người nhận";
                if (dgvNhiemVu.Columns.Contains("SDTNguoiNhan")) dgvNhiemVu.Columns["SDTNguoiNhan"].HeaderText = "SĐT người nhận";
                if (dgvNhiemVu.Columns.Contains("BienSoXe")) dgvNhiemVu.Columns["BienSoXe"].HeaderText = "Biển số xe";
                if (dgvNhiemVu.Columns.Contains("TrangThaiLenh")) dgvNhiemVu.Columns["TrangThaiLenh"].HeaderText = "Trạng thái lệnh";
                if (dgvNhiemVu.Columns.Contains("TGPhanCong")) dgvNhiemVu.Columns["TGPhanCong"].HeaderText = "TG phân công";
                if (dgvNhiemVu.Columns.Contains("LyDoTuChoi")) dgvNhiemVu.Columns["LyDoTuChoi"].Visible = false;
            }
        }

        private void dgvNhiemVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhiemVu.CurrentRow != null)
            {
                var row = dgvNhiemVu.CurrentRow;
                txtMaLenhDP.Text = row.Cells["MaLenhDP"].Value?.ToString() ?? "";
                string trangThaiLenh = row.Cells["TrangThaiLenh"].Value?.ToString() ?? "";
                txtLyDo.Text = row.Cells["LyDoTuChoi"]?.Value?.ToString() ?? "";

                cmbTrangThai.Items.Clear();
                btnCapNhat.Enabled = true;

                if (trangThaiLenh == "Chờ xác nhận")
                {
                    cmbTrangThai.Items.AddRange(new object[] { "Đã tiếp nhận", "Từ chối" });
                }
                else if (trangThaiLenh == "Đã tiếp nhận")
                {
                    cmbTrangThai.Items.Add("Đang thực hiện");
                }
                else if (trangThaiLenh == "Đang thực hiện")
                {
                    cmbTrangThai.Items.Add("Hoàn thành");
                }
                else if (trangThaiLenh == "Hoàn thành" || trangThaiLenh == "Từ chối" || trangThaiLenh == "Đã hủy")
                {
                    btnCapNhat.Enabled = false;
                }

                if (cmbTrangThai.Items.Count > 0)
                {
                    cmbTrangThai.SelectedIndex = 0;
                }
                else
                {
                    cmbTrangThai.Text = "";
                }
                
                txtLyDo.Enabled = (cmbTrangThai.Text == "Từ chối");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLenhDP.Text)) { MessageBox.Show("Vui lòng chọn nhiệm vụ!"); return; }
            if (cmbTrangThai.SelectedIndex < 0) { MessageBox.Show("Vui lòng chọn trạng thái!"); return; }

            string trangThai = cmbTrangThai.Text;
            if (trangThai == "Từ chối" && string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do từ chối!"); return;
            }

            try
            {
                var cmds = new System.Collections.Generic.List<SqlCommand>();
                string q = @"UPDATE LenhDieuPhoi SET TrangThaiLenh = @TrangThai,
                    TGXacNhan = GETDATE(), LyDoTuChoi = @LyDo WHERE MaLenhDP = @MaLenhDP";
                var cmdLDP = new SqlCommand(q);
                cmdLDP.Parameters.AddWithValue("@MaLenhDP", txtMaLenhDP.Text.Trim());
                cmdLDP.Parameters.AddWithValue("@TrangThai", trangThai);
                cmdLDP.Parameters.AddWithValue("@LyDo", string.IsNullOrEmpty(txtLyDo.Text.Trim()) ? (object)DBNull.Value : txtLyDo.Text.Trim());
                cmds.Add(cmdLDP);

                string maDonVC = dgvNhiemVu.CurrentRow?.Cells["MaDonVC"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(maDonVC))
                {
                    if (trangThai == "Đang thực hiện")
                    {
                        var cmdDVC = new SqlCommand("UPDATE DonVanChuyen SET TrangThaiDon = N'Đang vận chuyển' WHERE MaDonVC = @MaDVC");
                        cmdDVC.Parameters.AddWithValue("@MaDVC", maDonVC);
                        cmds.Add(cmdDVC);
                    }
                    else if (trangThai == "Hoàn thành")
                    {
                        var cmdDVC = new SqlCommand("UPDATE DonVanChuyen SET TrangThaiDon = N'Hoàn thành' WHERE MaDonVC = @MaDVC");
                        cmdDVC.Parameters.AddWithValue("@MaDVC", maDonVC);
                        cmds.Add(cmdDVC);
                    }
                    else if (trangThai == "Từ chối")
                    {
                        var cmdDVC = new SqlCommand("UPDATE DonVanChuyen SET TrangThaiDon = N'Mới tạo' WHERE MaDonVC = @MaDVC"); // Trả lại để điều phối viên gán lại
                        cmdDVC.Parameters.AddWithValue("@MaDVC", maDonVC);
                        cmds.Add(cmdDVC);
                    }
                }

                if (DatabaseHelper.ExecuteTransaction(cmds))
                {
                    MessageBox.Show("Cập nhật thành công!"); LoadNhiemVu();
                    txtMaLenhDP.Clear(); txtLyDo.Clear();
                }
            }
            catch (SqlException ex) { MessageBox.Show("Lỗi:\n" + ex.Message); }
        }
    }
}
