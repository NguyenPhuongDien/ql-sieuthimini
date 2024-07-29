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
    public partial class frmDangNhap : Form
    {
        ListTaiKhoan dstk = new ListTaiKhoan();
        ListNhanVien dsnv = new ListNhanVien();
        public NhanVien nhanVien { get; set; }
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            string tieuDe = "Bạn muốn đóng form?";
            string caption = "Thông báo";
            DialogResult r = MessageBox.Show(tieuDe, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            dsnv.GetData_NhanVien();
            dstk.GetData_TaiKhoan();
        }
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
                txtMatKhau.PasswordChar = '*';
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
           
            if(tk=="")
            {
                MessageBox.Show("Chưa nhập tài khoản");
            }
            else if(mk=="")
            {
                MessageBox.Show("Chưa nhập mật khẩu");
            }    
            else
            {
                bool login = dstk.Login(tk, mk);
                if (login == true)
                {
                    string MaNV = dstk.Find_MaNV_By_TK(tk);
                    string MaCV = dsnv.Find_MaCV(MaNV);
                    if (MaCV == "CV01")
                    {
                        frmTrangChu frmTrangChu = new frmTrangChu();
                        frmTrangChu.Load += (s, eventArgs) =>
                        {
                            frmTrangChu.txtPhanQuyen.Text = NhanVien.FindTenCV_MANV(MaNV);
                        };
                        frmTrangChu.Show();
                        this.Visible = false;
                        frmTrangChu.FormClosed += (s, eventArgs) =>
                        {
                            txtTaiKhoan.Clear();
                            txtMatKhau.Clear();
                            txtTaiKhoan.Focus();
                            
                            // Làm cho form hiện tại trở nên hiển thị khi frmTrangChu đóng
                            this.Visible = true;
                        };

                    }
                    else
                    {
                        frmTrangChu frmTrangChu = new frmTrangChu();
                        
                        frmTrangChu.Load += (s, eventArgs) =>
                        {
                            frmTrangChu.txtPhanQuyen.Text = NhanVien.FindTenCV_MANV(MaNV);
                            frmTrangChu.mn_quanly.Enabled = false;
                            frmTrangChu.ToolStripMenu_QL_HoaDon.Enabled = false;
                            frmTrangChu.ToolStrip_BackUp.Enabled = false;
                            frmTrangChu.ToolStripRestore.Enabled = false;
                            this.Visible = false;
                        };
                        frmTrangChu.Show();
                        frmTrangChu.FormClosed += (s, eventArgs) =>
                        {
                            txtTaiKhoan.Clear();
                            txtMatKhau.Clear();
                            txtTaiKhoan.Focus();
                            // Làm cho form hiện tại trở nên hiển thị khi frmTrangChu đóng
                            this.Visible = true;
                        };

                    }

                    QuanLy_DangNhap.Instance.SetCredentials(tk, mk, MaNV);

                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!");
                }
            }    
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy frmdangky = new frmDangKy();
            frmdangky.Show();
            this.Visible = false;
            frmdangky.FormClosed += (s, eventArgs) =>
            {
                this.Visible = true;
            };
        }
    }
}
