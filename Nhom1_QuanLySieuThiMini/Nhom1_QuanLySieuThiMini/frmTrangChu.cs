using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom1_QuanLySieuThiMini
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void mn_thongtin_Click(object sender, EventArgs e)
        {
            String tt = "Phần mềm : Quản lý Siêu thị  \n\nNhóm 1:\n\t-Nguyễn Phương Điền-2001215720\n\t-Trà Thị Thanh Trúc-2001216251\n\t-Mai Sĩ Tuấn-20012162814\n\t-Phạm Đình Thiên Vũ-2001216323\n\n\t\tGVHD: Ths.Vũ Văn Vinh\n";
            MessageBox.Show((tt), "Thông tin", MessageBoxButtons.OK);
        }

        private void ToolStripMenu_BanHang_Click(object sender, EventArgs e)
        {
            frmBanHang frmbanhang = new frmBanHang();
            frmbanhang.MdiParent = this;
            frmbanhang.Show();
        }

        private void ToolStripMenuI_Ql_HangHoa_Click(object sender, EventArgs e)
        {
            frmQuanLy_LoaiHangHoa frmQuanLy_Loai = new frmQuanLy_LoaiHangHoa();
            frmQuanLy_Loai.MdiParent = this;
            frmQuanLy_Loai.Show();
        }

     

        private void ToolStripMenu_QL_SanPham_Click(object sender, EventArgs e)
        {
            frmQuanLy_HangHoa frmHangHoa = new frmQuanLy_HangHoa();
            frmHangHoa.MdiParent = this;
            frmHangHoa.Show();
        }

        private void ToolStripMenu_QL_KhachHang_Click(object sender, EventArgs e)
        {
            frmQuanLy_KhachHang frmKhachHang = new frmQuanLy_KhachHang();
            frmKhachHang.MdiParent = this;
            frmKhachHang.Show();
        }

        private void ToolStripMenu_QL_TaiKhoan_Click(object sender, EventArgs e)
        {
            frmQuanLy_TaiKhoan frmTaiKhoan = new frmQuanLy_TaiKhoan();
            frmTaiKhoan.MdiParent = this;
            frmTaiKhoan.Show();
        }

        private void ToolStripMenu_QL_NhaCungCap_Click(object sender, EventArgs e)
        {
            frmQuanLy_NhaCungCap frmNCC = new frmQuanLy_NhaCungCap();
            frmNCC.MdiParent = this;
            frmNCC.Show();
        }

        private void ToolStripMenuI_QL_NhanVien_Click(object sender, EventArgs e)
        {
            frmQuanLy_NhanVien frmNhanVien = new frmQuanLy_NhanVien();
            frmNhanVien.MdiParent = this;
            frmNhanVien.Show();
        }

        private void ToolStripMenu_QL_HoaDon_Click(object sender, EventArgs e)
        {
            frmQuanLy_HoaDon frmHoaDon = new frmQuanLy_HoaDon();
            frmHoaDon.MdiParent = this;
            frmHoaDon.Show();
        }

        private void ToolStripMenu_DangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenu_DoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmDoiMK = new frmDoiMatKhau();
            frmDoiMK.MdiParent = this;
            frmDoiMK.Show(); 
        }
        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            
        }

        private void ToolStrip_BackUp_Click(object sender, EventArgs e)
        {
            frmBackUp backup = new frmBackUp();
            backup.Show();
        }

        private void ToolStripRestore_Click(object sender, EventArgs e)
        {
            frmRestore frmrestore = new frmRestore();
            frmrestore.Show();
        }
    }
}
