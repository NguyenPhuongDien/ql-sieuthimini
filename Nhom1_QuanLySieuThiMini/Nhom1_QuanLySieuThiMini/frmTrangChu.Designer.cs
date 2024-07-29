
namespace Nhom1_QuanLySieuThiMini
{
    partial class frmTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrangChu));
            this.timeChayChu = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenu_BanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_quanly = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuI_Ql_HangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_QL_SanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_QL_KhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_QL_TaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_QL_NhaCungCap = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuI_QL_NhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_QL_HoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_thongtin = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_DangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenu_DoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.txtPhanQuyen = new System.Windows.Forms.Label();
            this.ToolStrip_BackUp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeChayChu
            // 
            this.timeChayChu.Enabled = true;
            this.timeChayChu.Interval = 30;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_BanHang,
            this.mn_quanly,
            this.ToolStripMenu_QL_HoaDon,
            this.mn_thongtin,
            this.hệThốngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1374, 30);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menu";
            // 
            // ToolStripMenu_BanHang
            // 
            this.ToolStripMenu_BanHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripMenu_BanHang.Image = global::Nhom1_QuanLySieuThiMini.Properties.Resources.baseline_storefront_black_24dp1;
            this.ToolStripMenu_BanHang.Name = "ToolStripMenu_BanHang";
            this.ToolStripMenu_BanHang.Size = new System.Drawing.Size(120, 28);
            this.ToolStripMenu_BanHang.Text = "Bán hàng";
            this.ToolStripMenu_BanHang.Click += new System.EventHandler(this.ToolStripMenu_BanHang_Click);
            // 
            // mn_quanly
            // 
            this.mn_quanly.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuI_Ql_HangHoa,
            this.ToolStripMenu_QL_SanPham,
            this.ToolStripMenu_QL_KhachHang,
            this.ToolStripMenu_QL_TaiKhoan,
            this.ToolStripMenu_QL_NhaCungCap,
            this.ToolStripMenuI_QL_NhanVien});
            this.mn_quanly.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mn_quanly.Image = global::Nhom1_QuanLySieuThiMini.Properties.Resources.baseline_account_box_black_24dp1;
            this.mn_quanly.Name = "mn_quanly";
            this.mn_quanly.Size = new System.Drawing.Size(115, 28);
            this.mn_quanly.Text = "Quản lý ";
            // 
            // ToolStripMenuI_Ql_HangHoa
            // 
            this.ToolStripMenuI_Ql_HangHoa.Name = "ToolStripMenuI_Ql_HangHoa";
            this.ToolStripMenuI_Ql_HangHoa.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.ToolStripMenuI_Ql_HangHoa.Size = new System.Drawing.Size(355, 26);
            this.ToolStripMenuI_Ql_HangHoa.Text = "- Quản lí loại hàng hóa";
            this.ToolStripMenuI_Ql_HangHoa.Click += new System.EventHandler(this.ToolStripMenuI_Ql_HangHoa_Click);
            // 
            // ToolStripMenu_QL_SanPham
            // 
            this.ToolStripMenu_QL_SanPham.Name = "ToolStripMenu_QL_SanPham";
            this.ToolStripMenu_QL_SanPham.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.ToolStripMenu_QL_SanPham.Size = new System.Drawing.Size(355, 26);
            this.ToolStripMenu_QL_SanPham.Text = "- Quản lí hàng hoá";
            this.ToolStripMenu_QL_SanPham.Click += new System.EventHandler(this.ToolStripMenu_QL_SanPham_Click);
            // 
            // ToolStripMenu_QL_KhachHang
            // 
            this.ToolStripMenu_QL_KhachHang.Name = "ToolStripMenu_QL_KhachHang";
            this.ToolStripMenu_QL_KhachHang.Size = new System.Drawing.Size(355, 26);
            this.ToolStripMenu_QL_KhachHang.Text = "- Quản lí khách hàng";
            this.ToolStripMenu_QL_KhachHang.Click += new System.EventHandler(this.ToolStripMenu_QL_KhachHang_Click);
            // 
            // ToolStripMenu_QL_TaiKhoan
            // 
            this.ToolStripMenu_QL_TaiKhoan.Name = "ToolStripMenu_QL_TaiKhoan";
            this.ToolStripMenu_QL_TaiKhoan.Size = new System.Drawing.Size(355, 26);
            this.ToolStripMenu_QL_TaiKhoan.Text = "- Quản lí tài khoản";
            this.ToolStripMenu_QL_TaiKhoan.Click += new System.EventHandler(this.ToolStripMenu_QL_TaiKhoan_Click);
            // 
            // ToolStripMenu_QL_NhaCungCap
            // 
            this.ToolStripMenu_QL_NhaCungCap.Name = "ToolStripMenu_QL_NhaCungCap";
            this.ToolStripMenu_QL_NhaCungCap.Size = new System.Drawing.Size(355, 26);
            this.ToolStripMenu_QL_NhaCungCap.Text = "- Quản lí nhà cung cấp";
            this.ToolStripMenu_QL_NhaCungCap.Click += new System.EventHandler(this.ToolStripMenu_QL_NhaCungCap_Click);
            // 
            // ToolStripMenuI_QL_NhanVien
            // 
            this.ToolStripMenuI_QL_NhanVien.Name = "ToolStripMenuI_QL_NhanVien";
            this.ToolStripMenuI_QL_NhanVien.Size = new System.Drawing.Size(355, 26);
            this.ToolStripMenuI_QL_NhanVien.Text = "- Quản lí nhân viên";
            this.ToolStripMenuI_QL_NhanVien.Click += new System.EventHandler(this.ToolStripMenuI_QL_NhanVien_Click);
            // 
            // ToolStripMenu_QL_HoaDon
            // 
            this.ToolStripMenu_QL_HoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripMenu_QL_HoaDon.Image = global::Nhom1_QuanLySieuThiMini.Properties.Resources.bar_chart__1___1_;
            this.ToolStripMenu_QL_HoaDon.Name = "ToolStripMenu_QL_HoaDon";
            this.ToolStripMenu_QL_HoaDon.Size = new System.Drawing.Size(120, 28);
            this.ToolStripMenu_QL_HoaDon.Text = "Thống kê";
            this.ToolStripMenu_QL_HoaDon.Click += new System.EventHandler(this.ToolStripMenu_QL_HoaDon_Click);
            // 
            // mn_thongtin
            // 
            this.mn_thongtin.Image = global::Nhom1_QuanLySieuThiMini.Properties.Resources.baseline_info_black_24dp;
            this.mn_thongtin.Name = "mn_thongtin";
            this.mn_thongtin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mn_thongtin.Size = new System.Drawing.Size(110, 28);
            this.mn_thongtin.Text = "Thông tin";
            this.mn_thongtin.Click += new System.EventHandler(this.mn_thongtin_Click);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenu_DangXuat,
            this.ToolStripMenu_DoiMatKhau,
            this.ToolStrip_BackUp,
            this.ToolStripRestore});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.Image = global::Nhom1_QuanLySieuThiMini.Properties.Resources._1564529_mechanism_options_settings_configuration_setting_icon;
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(118, 28);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // ToolStripMenu_DangXuat
            // 
            this.ToolStripMenu_DangXuat.Name = "ToolStripMenu_DangXuat";
            this.ToolStripMenu_DangXuat.Size = new System.Drawing.Size(248, 26);
            this.ToolStripMenu_DangXuat.Text = "- Đăng xuất";
            this.ToolStripMenu_DangXuat.Click += new System.EventHandler(this.ToolStripMenu_DangXuat_Click);
            // 
            // ToolStripMenu_DoiMatKhau
            // 
            this.ToolStripMenu_DoiMatKhau.Name = "ToolStripMenu_DoiMatKhau";
            this.ToolStripMenu_DoiMatKhau.Size = new System.Drawing.Size(248, 26);
            this.ToolStripMenu_DoiMatKhau.Text = "- Đổi mật khẩu";
            this.ToolStripMenu_DoiMatKhau.Click += new System.EventHandler(this.ToolStripMenu_DoiMatKhau_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1192, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Phân quyền:";
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.AutoSize = true;
            this.lblNguoiDung.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDung.Location = new System.Drawing.Point(1104, 0);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(0, 26);
            this.lblNguoiDung.TabIndex = 7;
            // 
            // txtPhanQuyen
            // 
            this.txtPhanQuyen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPhanQuyen.AutoSize = true;
            this.txtPhanQuyen.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhanQuyen.Location = new System.Drawing.Point(1297, 11);
            this.txtPhanQuyen.Name = "txtPhanQuyen";
            this.txtPhanQuyen.Size = new System.Drawing.Size(55, 19);
            this.txtPhanQuyen.TabIndex = 11;
            this.txtPhanQuyen.Text = "label2";
            // 
            // ToolStrip_BackUp
            // 
            this.ToolStrip_BackUp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStrip_BackUp.Name = "ToolStrip_BackUp";
            this.ToolStrip_BackUp.Size = new System.Drawing.Size(248, 26);
            this.ToolStrip_BackUp.Text = "- Sao lưu dữ liệu";
            this.ToolStrip_BackUp.Click += new System.EventHandler(this.ToolStrip_BackUp_Click);
            // 
            // ToolStripRestore
            // 
            this.ToolStripRestore.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripRestore.Name = "ToolStripRestore";
            this.ToolStripRestore.Size = new System.Drawing.Size(248, 26);
            this.ToolStripRestore.Text = "- Khôi phục dữ liệu";
            this.ToolStripRestore.Click += new System.EventHandler(this.ToolStripRestore_Click);
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nhom1_QuanLySieuThiMini.Properties.Resources.thu_tuc_mo_sieu_thi_mini_15091548241;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1374, 599);
            this.Controls.Add(this.txtPhanQuyen);
            this.Controls.Add(this.lblNguoiDung);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.MinimizeBox = false;
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lí bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timeChayChu;
        public System.Windows.Forms.ToolStripMenuItem mn_quanly;
        public System.Windows.Forms.ToolStripMenuItem mn_thongtin;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenu_QL_HoaDon;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuI_Ql_HangHoa;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenu_QL_SanPham;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenu_QL_KhachHang;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenu_QL_TaiKhoan;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenu_BanHang;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenu_QL_NhaCungCap;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuI_QL_NhanVien;
        public System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenu_DangXuat;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenu_DoiMatKhau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNguoiDung;
        public System.Windows.Forms.Label txtPhanQuyen;
        public System.Windows.Forms.ToolStripMenuItem ToolStrip_BackUp;
        public System.Windows.Forms.ToolStripMenuItem ToolStripRestore;
    }
}