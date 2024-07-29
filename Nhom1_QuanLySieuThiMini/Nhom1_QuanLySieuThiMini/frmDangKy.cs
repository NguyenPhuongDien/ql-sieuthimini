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
    public partial class frmDangKy : Form
    {
        ListNhanVien nhanVien = new ListNhanVien();
        public frmDangKy()
        {
            InitializeComponent();
        }

       

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            nhanVien.GetData_NhanVien();
            cboMaNV.DataSource = nhanVien.DsNhanVien;
            cboMaNV.DisplayMember = "TenNV";
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.SelectedIndex = -1;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            string manv = cboMaNV.SelectedValue.ToString();

            if (string.IsNullOrEmpty(tk))
                MessageBox.Show("Chưa nhập tài khoản");
            else if (string.IsNullOrEmpty(mk))
                MessageBox.Show("Chưa nhập mật khẩu");
            else if (string.IsNullOrEmpty(manv))
                MessageBox.Show("Chưa nhập nhân viên");
            else
            {
                int kq = Acount.insertTaiKhoan(tk, mk, manv);
                string tenNV = NhanVien.FindTenNV_MaNV(manv);
                if (kq == -1)
                    MessageBox.Show("Nhân viên " + tenNV + " đã có tài khoản!");
                else if (kq != 0)
                {
                    MessageBox.Show("Đăng ký thành công");
                    reset();
                }
                else
                    MessageBox.Show("Đăng ký thất bại");
            }
        }
        private void reset()
        {
            txtMatKhau.Clear();
            txtTaiKhoan.Clear();
            cboMaNV.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
