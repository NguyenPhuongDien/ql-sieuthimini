using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nhom1_QuanLySieuThiMini
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void chk_Show_MkCu_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Show_MkCu.Checked == true)
            {
                txtMK_Cu.PasswordChar = '\0';
            }
            else
                txtMK_Cu.PasswordChar = '*';
        }

        private void chkShow_MkMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow_MkMoi.Checked == true)
                txtMK_Moi.PasswordChar = '\0';
            else
                txtMK_Moi.PasswordChar = '*';
        }

        private void chkShow_MKNhapLai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow_MKNhapLai.Checked == true)
                txtNhapLai_MK.PasswordChar = '\0';
            else
                txtNhapLai_MK.PasswordChar = '*';
        }
        private void DoiMK(string tk, string mk, string mkmoi, string mknhaplai)
        {
            string mkHienTai = QuanLy_DangNhap.Instance.MatKhau;

            if (mk.Trim() == mkHienTai)
            {
                if (mknhaplai == mkmoi)
                {
                    DBConnect db = new DBConnect();
                    string sql = "UPDATE TaiKhoan SET MatKhau = '"+mkmoi+"' WHERE TaiKhoan = '"+tk+"'";
                    int kq = db.getNonQuery(sql);
                    if(kq!=0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                        this.Close();
                    }    
                }
                else
                {
                    MessageBox.Show("Nhập lại mật khẩu không trùng", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không đúng");
            }
        }


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string mk = txtMK_Cu.Text;
            string mkmoi = txtMK_Moi.Text;
            string repass = txtNhapLai_MK.Text;
            string tk = QuanLy_DangNhap.Instance.TaiKhoan;
            DoiMK(tk, mk, mkmoi, repass);
            this.Close();
        }
    }
}
