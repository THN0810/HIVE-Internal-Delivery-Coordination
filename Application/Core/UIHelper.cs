using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace THNN_QuanLyDieuPhoiVanChuyen_HIVE.Core
{
    /// <summary>
    /// Lớp trung tâm quản lý thiết kế giao diện HIVE.
    /// Tone màu chính: Navy (#0D2137), Blue (#1976D2), Orange (#F5871F).
    /// </summary>
    public static class UIHelper
    {
        // ── Bảng màu HIVE ──────────────────────────
        public static readonly Color Navy       = Color.FromArgb(13, 33, 55);       // #0D2137 - sidebar, header
        public static readonly Color NavyLight  = Color.FromArgb(22, 50, 80);       // #163250 - hover sidebar
        public static readonly Color BluePrimary = Color.FromArgb(25, 118, 210);    // #1976D2 - nút chính, accent
        public static readonly Color BlueLight  = Color.FromArgb(227, 242, 253);    // #E3F2FD - nền nhạt
        public static readonly Color Orange     = Color.FromArgb(245, 135, 31);     // #F5871F - nút nổi bật, icon
        public static readonly Color OrangeHover = Color.FromArgb(230, 120, 15);    // hover orange
        public static readonly Color BgMain     = Color.FromArgb(245, 247, 250);    // #F5F7FA - nền chính
        public static readonly Color White      = Color.White;
        public static readonly Color TextDark   = Color.FromArgb(33, 37, 41);       // #212529
        public static readonly Color TextMuted  = Color.FromArgb(108, 117, 125);    // #6C757D
        public static readonly Color BorderLight = Color.FromArgb(222, 226, 230);   // #DEE2E6
        public static readonly Color GreenSuccess = Color.FromArgb(40, 167, 69);    // #28A745
        public static readonly Color RedDanger  = Color.FromArgb(220, 53, 69);      // #DC3545

        // ── Font ────────────────────────────────────
        public static readonly Font FontTitle   = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font FontHeader  = new Font("Segoe UI", 13F, FontStyle.Bold);
        public static readonly Font FontBody    = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FontSmall   = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static readonly Font FontSidebar = new Font("Segoe UI", 11F, FontStyle.Regular);
        public static readonly Font FontSidebarBold = new Font("Segoe UI", 11F, FontStyle.Bold);

        // ── Style DataGridView ──────────────────────
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = White;
            dgv.GridColor = BorderLight;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;

            // Header style
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Row style
            dgv.DefaultCellStyle.Font = FontBody;
            dgv.DefaultCellStyle.ForeColor = TextDark;
            dgv.DefaultCellStyle.SelectionBackColor = BlueLight;
            dgv.DefaultCellStyle.SelectionForeColor = TextDark;
            dgv.DefaultCellStyle.Padding = new Padding(5, 3, 5, 3);
            dgv.RowTemplate.Height = 35;

            // Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 251, 253);
        }

        // ── Style Buttons ───────────────────────────
        public static void StyleButtonPrimary(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = BluePrimary;
            btn.ForeColor = White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(10, 5, 10, 5);

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(21, 101, 192);
            btn.MouseLeave += (s, e) => btn.BackColor = BluePrimary;
        }

        public static void StyleButtonOrange(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Orange;
            btn.ForeColor = White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => btn.BackColor = OrangeHover;
            btn.MouseLeave += (s, e) => btn.BackColor = Orange;
        }

        public static void StyleButtonDanger(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = RedDanger;
            btn.ForeColor = White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(200, 35, 51);
            btn.MouseLeave += (s, e) => btn.BackColor = RedDanger;
        }

        public static void StyleButtonOutline(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = BluePrimary;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = White;
            btn.ForeColor = BluePrimary;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => { btn.BackColor = BlueLight; };
            btn.MouseLeave += (s, e) => { btn.BackColor = White; };
        }

        public static void StyleButtonGreen(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = GreenSuccess;
            btn.ForeColor = White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(33, 136, 56);
            btn.MouseLeave += (s, e) => btn.BackColor = GreenSuccess;
        }

        public static void StyleButtonGray(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(108, 117, 125);
            btn.ForeColor = White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(90, 98, 104);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(108, 117, 125);
        }

        // ── Style Sidebar Buttons ───────────────────
        public static void StyleSidebarButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = NavyLight;
            btn.BackColor = Navy;
            btn.ForeColor = White;
            btn.Font = FontSidebar;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.Cursor = Cursors.Hand;
        }

        // ── Style TextBoxes & ComboBoxes ────────────
        public static void StyleTextBox(TextBox txt)
        {
            txt.Font = FontBody;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = White;
        }

        public static void StyleComboBox(ComboBox cbo)
        {
            cbo.Font = FontBody;
            cbo.FlatStyle = FlatStyle.Flat;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.BackColor = White;
        }

        // ── Style GroupBox ──────────────────────────
        public static void StyleGroupBox(GroupBox grp)
        {
            grp.Font = FontHeader;
            grp.ForeColor = Navy;
            grp.BackColor = White;
        }

        // ── Style Labels ────────────────────────────
        public static void StyleLabel(Label lbl)
        {
            lbl.Font = FontBody;
            lbl.ForeColor = TextDark;
        }

        public static void StyleLabelHeader(Label lbl)
        {
            lbl.Font = FontHeader;
            lbl.ForeColor = Navy;
        }
    }
}
