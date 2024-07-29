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
    public partial class frmQuanLy_NhanVien : Form
    {
        DBConnect db = new DBConnect();
        KiemTraInput kt = new KiemTraInput();
        public frmQuanLy_NhanVien()
        {
            InitializeComponent();
        }
        private void frmQuanLy_NhanVien_Load(object sender, EventArgs e)
        {
            loadNhanVien();
            loadChucVu();
            loadcboSearchChucVu();

            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadNhanVien();
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtSdt.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            cboChucVu.SelectedIndex = -1;
            cboSearchChucVu.SelectedIndex = -1;
            txtSearchTen.Clear();
            dgvNhanVien.ClearSelection();
        }
        private bool kiemTraDuLieuSua()
        {
            bool check = true;
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtMaNV.Focus();
                check = false;

            }
            else if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtTenNV.Focus();
                check = false;
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                check = false;
            }
            else if (txtSdt.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtSdt.Focus();
                check = false;
            }
            else if (txtNgaySinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtNgaySinh.Focus();
                check = false;
            }
            else if (cboChucVu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                cboChucVu.Focus();
                check = false;
            }
            else if (radNam.Checked == false && radNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);

                check = false;
            }
            //Kiem tra du lieu trong textbox
            if (kt.KiemTraMaNhanVien(txtMaNV.Text) == false)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ! Vui lòng nhập lại! \nMã Nhân viên phải có hai ký tự đầu là NV và các ký tự theo sau là số \nVí dụ: NV0010");
                check = false;
            }

            //Kiem tra khóa có tồn tại không
            if (!db.isDuplicate(txtMaNV.Text, "NhanVien", "MaNV"))
            {
                MessageBox.Show("Không tồn tại loại hàng hóa với mã đã nhập! Vui lòng kiểm tra!");
                check = false;
            }
            return check;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!kiemTraDuLieuSua())
            {
                return;
            }

            //Them vao database
            string maNV = txtMaNV.Text;
            string sdt = txtSdt.Text;
            string ngaySinh = txtNgaySinh.Value.ToString();
            // Chuyển đổi chuỗi thành đối tượng DateTime
            DateTime date = DateTime.Parse(ngaySinh);
            // Lấy chuỗi ngày trong định dạng "YYYY-MM-DD"
            string ngaySinhNew = date.ToString("yyyy-MM-dd");
            string tenNV = txtTenNV.Text;
            string diaChi = txtDiaChi.Text;
            string gioiTinh = null;
            if (radNam.Checked)
            {
                gioiTinh = "Nam";

            }
            if (radNu.Checked)
            {
                gioiTinh = "Nữ";
            }
            string chucVu = cboChucVu.SelectedValue.ToString();
            int kq = db.getNonQuery("UPDATE NhanVien SET TenNV= N'" + tenNV + "',GioiTinh=N'" + gioiTinh + "',NamSinh ='" + ngaySinhNew + "',SDT_NV='" + sdt + "',DiaChi_NV='" + diaChi + "',MaCV='" + chucVu + "' WHERE MaNV = '" + txtMaNV.Text + "'");
            if (kq == 0)
            {
                MessageBox.Show("Sửa không thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thành công!");
                loadNhanVien();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Hiển thị cảnh báo muốn xóa không?
            DialogResult luaChon = MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo);
            if (luaChon == DialogResult.No)
            {
                return;
            }


            //Xóa trong database
            int kq = db.getNonQuery("DELETE FROM NhanVien WHERE MaNV = '" + txtMaNV.Text + "'");
            if (kq == 0)
            {
                MessageBox.Show("Xóa không thành công!");
                return;
            }
            else
            {
                MessageBox.Show("Xóa thành công!");
                loadNhanVien();
            }
        }
        private bool kiemTraDL()
        {

            bool check = true;
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtMaNV.Focus();
                check = false;

            }
            else if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtTenNV.Focus();
                check = false;
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                check = false;
            }
            else if (txtSdt.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtSdt.Focus();
                check = false;
            }
            else if (txtNgaySinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtNgaySinh.Focus();
                check = false;
            }
            else if (cboChucVu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                cboChucVu.Focus();
                check = false;
            }
            else if (radNam.Checked == false && radNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);

                check = false;
            }

            //Kiem tra du lieu trong textbox
            if (kt.KiemTraMaNhanVien(txtMaNV.Text) == false)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ! Vui lòng nhập lại! \nMã nhân viên phải có hai ký tự đầu là NV và các ký tự theo sau là số \nVí dụ: NV0010");
                check = false;
            }

            //Kiem tra trung khoa
            if (db.isDuplicate(txtMaNV.Text, "NhanVien", "MaNV"))
            {
                MessageBox.Show("Trùng khóa! Vui lòng chọn mã khác!");
                check = false;
            }
            return check;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiem tra du lieu trong textbox
            if (!kiemTraDL())
            {
                return;
            }
            //Them vao database
            string maNV = txtMaNV.Text;
            string sdt = txtSdt.Text;
            string ngaySinh = txtNgaySinh.Value.ToString();
            // Chuyển đổi chuỗi thành đối tượng DateTime
            DateTime date = DateTime.Parse(ngaySinh);
            // Lấy chuỗi ngày trong định dạng "YYYY-MM-DD"
            string ngaySinhNew = date.ToString("yyyy-MM-dd");
            string tenNV = txtTenNV.Text;
            string diaChi = txtDiaChi.Text;
            string gioiTinh = null;
            if (radNam.Checked)
            {
                gioiTinh = "Nam";

            }
            if (radNu.Checked)
            {
                gioiTinh = "Nữ";
            }
            string chucVu = cboChucVu.SelectedValue.ToString();
            int kq = db.getNonQuery(" INSERT INTO NhanVien VALUES('" + maNV + "',N'" + tenNV + "',N'" + gioiTinh + "','" + ngaySinhNew + "','" + sdt + "',N'" + diaChi + "','" + chucVu + "')");
            if (kq == 0)
            {
                MessageBox.Show("Thêm không thành công!");
                return;
            }
            else
            {
                MessageBox.Show("Thêm thành công!");
                loadNhanVien();
            }
        }
        private void loadNhanVien()
        {
            DataTable tblNhanVien = db.getDatatable("SELECT MaNV,TenNV,GioiTinh,NamSinh,SDT_NV,DiaChi_NV, ChucVu.TenCV FROM NhanVien INNER JOIN ChucVu ON NhanVien.MaCV = ChucVu.MaCV");

            dgvNhanVien.DataSource = tblNhanVien;
            tblNhanVien.Columns[0].ColumnName = "Mã nhân viên";
            tblNhanVien.Columns[1].ColumnName = "Tên nhân viên";
            tblNhanVien.Columns[2].ColumnName = "Giới tính";
            tblNhanVien.Columns[3].ColumnName = "Ngày sinh";
            tblNhanVien.Columns[4].ColumnName = "Số điện thoại";
            tblNhanVien.Columns[5].ColumnName = "Địa chỉ";
            tblNhanVien.Columns[6].ColumnName = "Chức vụ";
            dgvNhanVien.DataSource = tblNhanVien;
        }
        public void loadChucVu()
        {
            DataTable tblChucVu = db.getDatatable("SELECT * FROM ChucVu");
            cboChucVu.DataSource = tblChucVu;
            cboChucVu.DisplayMember = "TenCV";
            cboChucVu.ValueMember = "MaCV";

        }

        public void loadcboSearchChucVu()
        {
            DataTable tblChucVu = db.getDatatable("SELECT * FROM ChucVu");
            cboSearchChucVu.DataSource = tblChucVu;
            cboSearchChucVu.DisplayMember = "TenCV";
            cboSearchChucVu.ValueMember = "MaCV";
        }

        private void frmQuanLy_NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            string tieuDe = "Bạn muốn đóng form?";
            string caption = "Thông báo";
            DialogResult r = MessageBox.Show(tieuDe, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = " select MaNV,TenNV,GioiTinh,NamSinh,SDT_NV,DiaChi_NV, cv.TenCV from NhanVien nv, ChucVu cv where cv.MaCV=nv.MaCV AND TenNV LIKE '%" + txtSearchTen.Text + "%' and cv.MaCV like '%" + cboSearchChucVu.SelectedValue + "%' ";

            DataTable tblNhanVien = db.getDatatable(sql);
            dgvNhanVien.DataSource = tblNhanVien;
            tblNhanVien.Columns[0].ColumnName = "Mã nhân viên";
            tblNhanVien.Columns[1].ColumnName = "Tên nhân viên";
            tblNhanVien.Columns[2].ColumnName = "Giới tính";
            tblNhanVien.Columns[3].ColumnName = "Ngày sinh";
            tblNhanVien.Columns[4].ColumnName = "Số điện thoại";
            tblNhanVien.Columns[5].ColumnName = "Địa chỉ";
            tblNhanVien.Columns[6].ColumnName = "Chức vụ";
            dgvNhanVien.DataSource = tblNhanVien;
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvNhanVien.SelectedRows[0];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtTenNV.Text = row.Cells[1].Value.ToString();
                string gioiTinh = row.Cells[2].Value.ToString();
                if (gioiTinh.Equals("Nam"))
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }
                txtNgaySinh.Text = row.Cells[3].Value.ToString();
                txtSdt.Text = row.Cells[4].Value.ToString();
                txtDiaChi.Text = row.Cells[5].Value.ToString();
                cboChucVu.Text = row.Cells[6].Value.ToString();
            }
        }

      
    }
}
