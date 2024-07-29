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
    public partial class frmQuanLy_HangHoa : Form
    {
        DBConnect db = new DBConnect();
        KiemTraInput kt = new KiemTraInput();
        public frmQuanLy_HangHoa()
        {
            InitializeComponent();
        }
        public void loadSanPham()
        {

            DataTable tblHangHoa = db.getDatatable("SELECT MaHH, TenHH, DVT, GiaNhap,GiaBan, SoLuong, TenLoaiHH, TenNCC FROM HangHoa HH, LoaiHangHoa LHH, NhaCungCap NCC where HH.MaloaiHH=LHH.MaLoaiHH AND HH.MaNCC=NCC.MaNCC ");

            dgvHangHoa.DataSource = tblHangHoa;
            tblHangHoa.Columns[0].ColumnName = "Mã hàng hóa";
            tblHangHoa.Columns[1].ColumnName = "Tên hàng hóa";
            tblHangHoa.Columns[2].ColumnName = "Đơn vị tính";
            tblHangHoa.Columns[3].ColumnName = "Giá nhập";
            tblHangHoa.Columns[4].ColumnName = "Giá bán";
            tblHangHoa.Columns[5].ColumnName = "Số lượng";
            tblHangHoa.Columns[6].ColumnName = "Tên loại hàng hóa";
            tblHangHoa.Columns[7].ColumnName = "Tên nhà cung cấp";
            loadSoLuongSanPham();
            dgvHangHoa.DataSource = tblHangHoa;

        }
        private void loadNCC()
        {
            DataTable tblNCC = db.getDatatable("SELECT * FROM NhaCungCap");
            cboNCC.DataSource = tblNCC;
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";

        }
        private void loadLoaiHH()
        {
            DataTable tblLHH = db.getDatatable("SELECT * FROM LoaiHangHoa");
            cboLoaiHH.DataSource = tblLHH;
            cboLoaiHH.DisplayMember = "TenLoaiHH";
            cboLoaiHH.ValueMember = "MaLoaiHH";

        }
        private void loadSearchNCC()
        {
            DataTable tblNCC = db.getDatatable("SELECT HH.MaNCC,TenNCC FROM HangHoa HH, NhaCungCap Where HH.MaNCC=NhaCungCap.MaNCC group by HH.MaNCC,TenNCC");
            cboSearchNCC.DataSource = tblNCC;
            cboSearchNCC.DisplayMember = "TenNCC";
            cboSearchNCC.ValueMember = "MaNCC";

        }
        private void loadSearchLoaiHH()
        {
            DataTable tblLHH = db.getDatatable("SELECT HH.MaloaiHH, TenLoaiHH FROM HangHoa HH,LoaiHangHoa LHH where HH.MaloaiHH=LHH.MaLoaiHH GROUP BY HH.MaloaiHH,TenLoaiHH ");
            cboSearchLoaiHH.DataSource = tblLHH;
            cboSearchLoaiHH.DisplayMember = "TenLoaiHH";
            cboSearchLoaiHH.ValueMember = "MaLoaiHH";
        }
        private void loadSoLuongSanPham()
        {
            int countHoaDon = dgvHangHoa.Rows.Count;
            lblSLHangHoa.Text = countHoaDon.ToString();
        }
        private void frmQuanLy_HangHoa_Load(object sender, EventArgs e)
        {
            loadSanPham();
            loadLoaiHH();
            loadNCC();
            loadSearchLoaiHH();
            loadSearchNCC();

        }
        private bool kiemTraDuLieu()
        {
            bool check = true;
            if (txtTenHangHoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông Tin !", "Error", MessageBoxButtons.OK);
                txtTenHangHoa.Focus();
                check = false;

            }
            if (txtDVT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính !", "Error", MessageBoxButtons.OK);
                txtDVT.Focus();
                check = false;

            }
            if (!kt.IsMoney(txtGiaNhap.Text) || txtGiaNhap.Text == "")
            {
                MessageBox.Show("Giá nhập phải là số và không được bỏ trống!", "Error", MessageBoxButtons.OK);
                txtGiaNhap.Clear();
                txtGiaNhap.Focus();
                check = false;
            }
            if (!kt.IsMoney(txtGiaBan.Text) || txtGiaBan.Text == "")
            {
                MessageBox.Show("Giá bán phải là số và không được bỏ trống!", "Error", MessageBoxButtons.OK);
                txtGiaBan.Clear();
                txtGiaBan.Focus();
                check = false;
            }
            if (!kt.IsMoney(txtSoLuong.Text) || txtSoLuong.Text == "")
            {
                MessageBox.Show("Số lượng phải là số và không được bỏ trống!", "Error", MessageBoxButtons.OK);
                txtSoLuong.Clear();
                txtSoLuong.Focus();
                check = false;
            }
            return check;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT SUBSTRING(MAX(MaHH), 3, 3) FROM HANGHOA";
            String st = (String)db.getScalar(sql);
            int stt = Int32.Parse(st);
            stt++;
            String strStt = stt.ToString("000");
            String maHH = "HH" + strStt;
            txtMaHangHoa.Text = maHH;

            if (!kiemTraDuLieu())
                return;


            string tenHangHoa = txtTenHangHoa.Text;
            string dvt = txtDVT.Text;
            string giaNhap = txtGiaNhap.Text;
            string giaBan = txtGiaBan.Text;
            string soLuong = txtSoLuong.Text;
            string loaiHH = cboLoaiHH.SelectedValue.ToString();
            string loaiNCC = cboNCC.SelectedValue.ToString();


            int kq = db.getNonQuery(" INSERT INTO HangHoa VALUES('" + maHH + "',N'" + tenHangHoa + "',N'" + dvt + "'," + giaNhap + "," + giaBan + "," + soLuong + ",'" + loaiHH + "','" + loaiNCC + "')");
            if (kq == 0)
            {
                MessageBox.Show("Thêm không thành công!");
                return;
            }
            else
            {
                MessageBox.Show("Thêm thành công!");
                loadSanPham();
            }
        }

        private void dgvHangHoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHangHoa.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvHangHoa.SelectedRows[0];
                txtMaHangHoa.Text = row.Cells[0].Value.ToString();
                txtTenHangHoa.Text = row.Cells[1].Value.ToString();
                txtDVT.Text = row.Cells[2].Value.ToString();
                txtGiaBan.Text = row.Cells[4].Value.ToString();
                txtGiaNhap.Text = row.Cells[3].Value.ToString();
                txtSoLuong.Text = row.Cells[5].Value.ToString();
                cboLoaiHH.Text = row.Cells[6].Value.ToString();
                cboNCC.Text = row.Cells[7].Value.ToString();

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
            int kq = db.getNonQuery("DELETE FROM HangHoa WHERE MaHH = '" + txtMaHangHoa.Text + "'");
            if (kq == 0)
            {
                MessageBox.Show("Xóa không thành công!");
                return;
            }
            else
            {
                MessageBox.Show("Xóa thành công!");
                loadSanPham();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!kiemTraDuLieu())
                return;

            //Them vao database
            string maHH = txtMaHangHoa.Text;
            string tenHH = txtTenHangHoa.Text;
            string donViTinh = txtDVT.Text;
            string giaNhap = txtGiaNhap.Text;
            string giaBan = txtGiaBan.Text;
            string sl = txtSoLuong.Text;
            string maLoaiHH = cboLoaiHH.SelectedValue.ToString();
            string maNCC = cboNCC.SelectedValue.ToString();

            int kq = db.getNonQuery("UPDATE HangHoa SET TenHH= N'" + tenHH + "',DVT=N'" + donViTinh + "',GiaNhap =" + giaNhap + ",GiaBan=" + giaBan + ",SoLuong=" + sl + ",MaloaiHH='" + maLoaiHH + "',MaNCC='" + maNCC + "' WHERE MaHH = '" + maHH + "'");
            if (kq == 0)
            {
                MessageBox.Show("Sửa không thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thành công!");
                loadSanPham();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuanLy_HangHoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            string tieuDe = "Bạn muốn đóng form?";
            string caption = "Thông báo";
            DialogResult r = MessageBox.Show(tieuDe, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!kt.IsMoney(txtGiaTu.Text))
            {
                MessageBox.Show("Giá trị giá từ không hợp lệ! Vui lòng nhập lại!");
                txtGiaTu.Focus();
                return;
            }
            if (!kt.IsMoney(txtGiaDen.Text))
            {
                MessageBox.Show("Giá trị giá đến không hợp lệ! Vui lòng nhập lại!");
                txtGiaDen.Focus();
                return;
            }

            //Chuan bi cac gia tri cho truy van
            string khoangGiaA = "0";
            string khoangGiaB = "1000000000000";

            if (!string.IsNullOrEmpty(txtGiaTu.Text))
            {
                khoangGiaA = txtGiaTu.Text;
            }
            if (!string.IsNullOrEmpty(txtGiaDen.Text))
            {
                khoangGiaB = txtGiaDen.Text;
            }

            string sql = " select MaHH, TenHH, DVT, GiaNhap, GiaBan, SoLuong, LHH.TenLoaiHH, NCC.TenNCC FROM HangHoa HH, LoaiHangHoa LHH, NhaCungCap NCC where HH.MaloaiHH=LHH.MaLoaiHH AND HH.MaNCC=NCC.MaNCC AND TenHH LIKE '%" + txtSearchTenHH.Text + "%' and HH.MaNCC like '%" + cboSearchNCC.SelectedValue + "%' and HH.MaloaiHH like '%" + cboSearchLoaiHH.SelectedValue + "%' and (GiaBan between " + khoangGiaA + " AND " + khoangGiaB + ")";
            DataTable tblHangHoa = db.getDatatable(sql);
            dgvHangHoa.DataSource = tblHangHoa;
            tblHangHoa.Columns[0].ColumnName = "Mã hàng hóa";
            tblHangHoa.Columns[1].ColumnName = "Tên hàng hóa";
            tblHangHoa.Columns[2].ColumnName = "Đơn vị tính";
            tblHangHoa.Columns[3].ColumnName = "Giá nhập";
            tblHangHoa.Columns[4].ColumnName = "Giá bán";
            tblHangHoa.Columns[5].ColumnName = "Số lượng";
            tblHangHoa.Columns[6].ColumnName = "Tên loại hàng hóa";
            tblHangHoa.Columns[7].ColumnName = "Tên nhà cung cấp";
            //int countHangHoa = dgvHangHoa.Rows.Count - 1;
            //lblSLHangHoa.Text = countHangHoa.ToString();
            dgvHangHoa.DataSource = tblHangHoa;
            loadSoLuongSanPham();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenHangHoa.Clear();
            txtSoLuong.Clear();
            txtMaHangHoa.Clear();
            txtDVT.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtGiaTu.Clear();
            txtGiaDen.Clear();
            txtSearchTenHH.Clear();
            cboLoaiHH.SelectedIndex = -1;
            cboNCC.SelectedIndex = -1;
            cboSearchLoaiHH.SelectedIndex = -1;
            cboSearchNCC.SelectedIndex = -1;
            dgvHangHoa.ClearSelection();
            loadSanPham();
        }
    }
}
