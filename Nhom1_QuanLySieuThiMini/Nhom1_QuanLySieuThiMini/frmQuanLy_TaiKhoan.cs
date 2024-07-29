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
    public partial class frmQuanLy_TaiKhoan : Form
    {
        ListTaiKhoan listtaiKhoan = new ListTaiKhoan();
        ListNhanVien listnhanVien = new ListNhanVien();
        int check = 0;//Trạng thái ban đầu
        public frmQuanLy_TaiKhoan()
        {
            InitializeComponent();
        }
    
        private void frmQuanLy_TaiKhoan_Load(object sender, EventArgs e)
        {
            listtaiKhoan.GetData_TaiKhoan();
            listnhanVien.GetData_NhanVien();
            
            dgvTaiKhoan.DataSource = listtaiKhoan.DsTaiKhoan;
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cboMaNV.DataSource = listnhanVien.DsNhanVien;
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.DisplayMember = "TenNV";

            txtMatKhau.Enabled = txtTaiKhoan.Enabled = cboMaNV.Enabled = false;
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            check = 1;//Khi bấm button thêm thì check=1
            txtMatKhau.Enabled = txtTaiKhoan.Enabled = cboMaNV.Enabled = true;
            txtMatKhau.Clear();
            txtTaiKhoan.Clear();
            cboMaNV.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            string  manv = cboMaNV.SelectedValue.ToString();
    
            if (string.IsNullOrEmpty(tk))
                MessageBox.Show("Chưa nhập tài khoản!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Chưa nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(manv==null)
            {
                MessageBox.Show("Chưa nhập nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else if (check==1)
            {
                    int kq= Acount.insertTaiKhoan(tk, mk, manv);
                    if (kq == -1)
                        MessageBox.Show("Nhân viên có mã " + manv + " đã có tài khoản!");
                    else if (kq != 0)
                    {
                        MessageBox.Show("Thêm thành công");
                        foreach (DataGridViewRow row in dgvTaiKhoan.SelectedRows)
                        {
                            row.Selected = false;
                        }
                        dgvTaiKhoan.DataSource = null;

                        listtaiKhoan.GetData_TaiKhoan();
                        dgvTaiKhoan.DataSource = listtaiKhoan.DsTaiKhoan;

                    }
                    else
                        MessageBox.Show("Thêm thất bại");
               
                check = 0;
            } 
            else if(check==2)
            {
                DialogResult r= MessageBox.Show("Bạn có muốn xoá tài khoản này?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(r==DialogResult.Yes)
                {
                    int kq = Acount.XoaTaiKhoan(tk);
                    if (kq == 2)
                        MessageBox.Show("Không tìm thấy tài khoản!");
                    else if (kq == 0)
                        MessageBox.Show("Xoá thất bại!");
                    else
                    {
                        MessageBox.Show("Xoá thành công!");
                        dgvTaiKhoan.DataSource = null;

                        listtaiKhoan.GetData_TaiKhoan();
                        dgvTaiKhoan.DataSource = listtaiKhoan.DsTaiKhoan;
                    }
                } 
                check = 0;
            }
            txtMatKhau.Enabled = txtTaiKhoan.Enabled = cboMaNV.Enabled = false;
            check = 0;
            reSet();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            check = 2;
            string tk = txtTaiKhoan.Text;
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void reSet()
        {
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cboMaNV.SelectedIndex = -1;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reSet();
        }

        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.SelectedRows.Count>0)
            {
                DataGridViewRow row = dgvTaiKhoan.SelectedRows[0];
                string taikhoan = row.Cells["TK"].Value.ToString();
                string matkhau = row.Cells["MK"].Value.ToString();
                string manv = row.Cells["MaNV"].Value.ToString();

                txtTaiKhoan.Text = taikhoan;
                txtMatKhau.Text = matkhau;
                cboMaNV.SelectedValue = manv;
            }
        }
    }
}
