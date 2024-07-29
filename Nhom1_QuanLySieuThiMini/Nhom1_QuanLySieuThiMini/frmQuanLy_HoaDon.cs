using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Nhom1_QuanLySieuThiMini
{
    public partial class frmQuanLy_HoaDon : Form
    {
        DBConnect db = new DBConnect();
        KiemTraInput kt = new KiemTraInput();
        public frmQuanLy_HoaDon()
        {
            InitializeComponent();
        }
        private void load_HoaDon()
        {
            DataTable tblHoaDon = db.getDatatable("SELECT	hd.MaBanHang, nv.TenNV, kh.TenKH, NgayBH, hd.GhiChu, ISNULL(TongTien,0) " +
                                                    "FROM	PhieuBanHang hd, NhanVien nv, KhachHang kh " +
                                                    "WHERE	hd.MaNV = nv.MaNV	AND " +
                                                            "hd.MaKH = kh.MaKH");
            tblHoaDon.Columns[0].ColumnName = "Mã hóa đơn";
            tblHoaDon.Columns[1].ColumnName = "Nhân viên";
            tblHoaDon.Columns[2].ColumnName = "Khách hàng";
            tblHoaDon.Columns[3].ColumnName = "Ngày lập";
            tblHoaDon.Columns[4].ColumnName = "Ghi chú";
            tblHoaDon.Columns[5].ColumnName = "Tổng tiền";


            dataGridViewHoaDons.DataSource = tblHoaDon;
            load_soLuongHoaDonVaTongDoanhTHu();
        }
        private void load_cboNhanVien()
        {
            DataTable tblNhanVien = db.getDatatable("SELECT * FROM NhanVien");
            cboSearchNhanVien.DataSource = tblNhanVien;
            cboSearchNhanVien.DisplayMember = "TenNV";
            cboSearchNhanVien.ValueMember = "MaNV";

        }
        private void load_cboKhachHang()
        {
            DataTable tblKhachHang = db.getDatatable("SELECT * FROM KhachHang");
            cboSearchKhachHang.DataSource = tblKhachHang;
            cboSearchKhachHang.DisplayMember = "TenKH";
            cboSearchKhachHang.ValueMember = "MaKH";


        }
        private void load_soLuongHoaDonVaTongDoanhTHu()
        {
            int countHoaDon = dataGridViewHoaDons.Rows.Count;
            double tongDoanhThu = 0;


            DataTable table = (DataTable)dataGridViewHoaDons.DataSource;
            tongDoanhThu = table.AsEnumerable().Sum(row => (double)row["Tổng tiền"]);


            lblDisplaySoLuongHoaDon.Text = countHoaDon.ToString();
            lblDisplayTongDoanhThu.Text = tongDoanhThu.ToString();
        }

        private void frmQuanLy_HoaDon_Load(object sender, EventArgs e)
        {
            load_HoaDon();
            load_cboNhanVien();
            load_cboKhachHang();


            radSearchNgayBan_Ngay.Checked = false;
            radSearchNgayBan_KhoangThoiGian.Checked = false;
            txtSearch_rad_ngay.Enabled = false;
            txtSearch_radKhoangThoiGian_A.Enabled = false;
            txtSearch_radKhoangThoiGian_B.Enabled = false;


            string manv = QuanLy_DangNhap.Instance.MaNV;
            txtTenNV.Text = NhanVien.FindTenNV_MaNV(manv);
            txtChucVu.Text = NhanVien.FindTenCV_MANV(manv);
            txtMaNV.Text = manv;

            dataGridViewHoaDons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void radSearchNgayBan_Ngay_CheckedChanged(object sender, EventArgs e)
        {
            if (radSearchNgayBan_Ngay.Checked)
            {
                txtSearch_rad_ngay.Enabled = true;
                radSearchNgayBan_KhoangThoiGian.Checked = false;
                txtSearch_radKhoangThoiGian_A.Enabled = false;
                txtSearch_radKhoangThoiGian_B.Enabled = false;
            }
            else
            {
                txtSearch_rad_ngay.Enabled = false;
                radSearchNgayBan_KhoangThoiGian.Checked = true;
                txtSearch_radKhoangThoiGian_A.Enabled = true;
                txtSearch_radKhoangThoiGian_B.Enabled = true;
            }
        }

        private void radSearchNgayBan_KhoangThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            if (radSearchNgayBan_KhoangThoiGian.Checked)
            {
                txtSearch_rad_ngay.Enabled = false;
                radSearchNgayBan_KhoangThoiGian.Checked = true;
                txtSearch_radKhoangThoiGian_A.Enabled = true;
                txtSearch_radKhoangThoiGian_B.Enabled = true;
            }
            else
            {
                txtSearch_rad_ngay.Enabled = true;
                radSearchNgayBan_KhoangThoiGian.Checked = false;
                txtSearch_radKhoangThoiGian_A.Enabled = false;
                txtSearch_radKhoangThoiGian_B.Enabled = false;
            }
        }

        private void dataGridViewHoaDons_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewHoaDons.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewHoaDons.SelectedRows[0];
                string nhanVien = row.Cells["Nhân viên"].Value.ToString();
                cboSearchNhanVien.Text = nhanVien;

                string maHD = row.Cells["Mã hóa đơn"].Value.ToString();
                txtSearchMaHoaDon.Text = maHD;

                string khachHang = row.Cells["Khách hàng"].Value.ToString();
                cboSearchKhachHang.Text = khachHang;

            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            load_HoaDon();
            dataGridViewHoaDons.ClearSelection();
            txtSearchMaHoaDon.Clear();
            cboSearchNhanVien.SelectedIndex = -1;
            cboSearchKhachHang.SelectedIndex = -1;

            radSearchNgayBan_Ngay.Checked = false;
            radSearchNgayBan_KhoangThoiGian.Checked = false;
            txtSearch_rad_ngay.Enabled = false;
            txtSearch_radKhoangThoiGian_A.Enabled = false;
            txtSearch_radKhoangThoiGian_A.Clear();
            txtSearch_radKhoangThoiGian_B.Enabled = false;
            txtSearch_radKhoangThoiGian_B.Clear();

            txtSearchKhoangGiaA.Clear();
            txtSearchKhoangGiaB.Clear();
            txtSearch_rad_ngay.Clear();
            txtSearch_radKhoangThoiGian_A.Clear();
            txtSearch_radKhoangThoiGian_B.Clear();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            //Kiem tra dau vao
            if (!kt.IsMoney(txtSearchKhoangGiaA.Text))
            {
                MessageBox.Show("Giá trị khoảng giá A không hợp lệ! Vui lòng nhập lại!");
                txtSearchKhoangGiaA.Focus();
                return;
            }
            if (!kt.IsMoney(txtSearchKhoangGiaB.Text))
            {
                MessageBox.Show("Giá trị khoảng giá B không hợp lệ! Vui lòng nhập lại!");
                txtSearchKhoangGiaB.Focus();
                return;
            }

            if (radSearchNgayBan_Ngay.Checked)
            {
                if (string.IsNullOrEmpty(txtSearch_rad_ngay.Text))
                {
                    MessageBox.Show("Ngày không được để trống!");
                    txtSearch_rad_ngay.Focus();
                    return;
                }
                if (!kt.IsValidDate(txtSearch_rad_ngay.Text))
                {
                    MessageBox.Show("Ngày không hợp lệ! Vui lòng kiểm tra và nhập lại!");
                    txtSearch_rad_ngay.Focus();
                    return;
                }

            }

            if (radSearchNgayBan_KhoangThoiGian.Checked)
            {
                if (string.IsNullOrEmpty(txtSearch_radKhoangThoiGian_A.Text))
                {
                    MessageBox.Show("Ngày bắt đầu không được để trống!");
                    txtSearch_radKhoangThoiGian_A.Focus();
                    return;
                }
                if (!kt.IsValidDate(txtSearch_radKhoangThoiGian_A.Text))
                {
                    MessageBox.Show("Ngày bắt đầu không hợp lệ! Vui lòng kiểm tra và nhập lại!");
                    txtSearch_radKhoangThoiGian_A.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtSearch_radKhoangThoiGian_B.Text))
                {
                    MessageBox.Show("Ngày kết thúc  không được để trống!");
                    txtSearch_radKhoangThoiGian_B.Focus();
                    return;
                }
                if (!kt.IsValidDate(txtSearch_radKhoangThoiGian_B.Text))
                {
                    MessageBox.Show("Ngày kết thúc không hợp lệ! Vui lòng kiểm tra và nhập lại!");
                    txtSearch_radKhoangThoiGian_B.Focus();
                    return;
                }
            }



            //Xu ly

            //Chuan bi cac gia tri cho truy van
            string khoangGiaA = "0";
            string khoangGiaB = "1000000000000";

            if (!string.IsNullOrEmpty(txtSearchKhoangGiaA.Text))
            {
                khoangGiaA = txtSearchKhoangGiaA.Text;
            }
            if (!string.IsNullOrEmpty(txtSearchKhoangGiaB.Text))
            {
                khoangGiaB = txtSearchKhoangGiaB.Text;
            }




            string sql = "SELECT	hd.MaBanHang, nv.TenNV, kh.TenKH, NgayBH, hd.GhiChu, ISNULL(TongTien,0) as TongTien " +
                            "FROM	PhieuBanHang hd, NhanVien nv, KhachHang kh " +
                            "WHERE 	hd.MaBanHang LIKE '%" + txtSearchMaHoaDon.Text + "%' AND " +
                            "hd.MaNV LIKE '%" + cboSearchNhanVien.SelectedValue + "%'	AND " +
                            "hd.MaKH LIKE '%" + cboSearchKhachHang.SelectedValue + "%' AND " +
                            "hd.MaNV = nv.MaNV	AND " +
                            "hd.MaKH = kh.MaKH " +
                            ((radSearchNgayBan_Ngay.Checked) ? "AND CONVERT(Date,hd.NgayBH,103) = CONVERT(date,'" + txtSearch_rad_ngay.Text + "',103) " : "") +
                            ((radSearchNgayBan_KhoangThoiGian.Checked) ? "AND (CONVERT(Date,hd.NgayBH,103) BETWEEN CONVERT(date,'" + txtSearch_radKhoangThoiGian_A.Text + "',103) AND CONVERT(date,'" + txtSearch_radKhoangThoiGian_B.Text + "',103)) " : "") +
                            "AND (hd.TongTien Between " + khoangGiaA + " AND " + khoangGiaB + ")";


            DataTable tblHoaDon = db.getDatatable(sql);
            tblHoaDon.Columns[0].ColumnName = "Mã hóa đơn";
            tblHoaDon.Columns[1].ColumnName = "Nhân viên";
            tblHoaDon.Columns[2].ColumnName = "Khách hàng";
            tblHoaDon.Columns[3].ColumnName = "Ngày lập";
            tblHoaDon.Columns[4].ColumnName = "Ghi chú";
            tblHoaDon.Columns[5].ColumnName = "Tổng tiền";


            dataGridViewHoaDons.DataSource = tblHoaDon;
            load_soLuongHoaDonVaTongDoanhTHu();

        }

      

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            string MaHD = "";
            if (dataGridViewHoaDons.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewHoaDons.SelectedRows[0];
                MaHD = row.Cells["Mã hóa đơn"].Value.ToString();
            }

            SqlConnection con = new SqlConnection(CauHinh.strConn);
            SqlCommand cmd = new SqlCommand("Show_Report", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaBanHang", MaHD);


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            Report_ChiTietHD rpt = new Report_ChiTietHD();
            rpt.SetDataSource(dt);
            rpt.SetParameterValue("KhachDua", 0);
            rpt.SetParameterValue("ThoiLai", 0);
            frmChiTietHoaDon frmHoaDon = new frmChiTietHoaDon();
            frmHoaDon.Report_HoaDon.ReportSource = rpt;
            frmHoaDon.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewHoaDons.SelectedRows.Count > 0)
            {
                string mahd = null;
                foreach (DataGridViewRow row in dataGridViewHoaDons.SelectedRows)
                {
                    mahd = row.Cells[0].Value.ToString();
                }
                if(string.IsNullOrEmpty(mahd))
                {
                    MessageBox.Show("Chưa chọn hoá đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    DialogResult r=  MessageBox.Show("Bạn có muốn xoá hoá đơn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(r==DialogResult.Yes)
                    {
                        string xoachitiet = "delete from chitietbanhang where MaBanHang='" + mahd + "'";
                        string xoaHD = "delete from phieubanhang where MabanHang='" + mahd + "'";

                        //Xoá chi tiết hoá đơn trước
                        db.getNonQuery(xoachitiet);
                        int kq = db.getNonQuery(xoaHD);
                        if (kq != 0)
                        {
                            MessageBox.Show("Xoá thành công", "Thông báo");
                            dataGridViewHoaDons.DataSource = null;
                            load_HoaDon();
                        }    
                        else
                            MessageBox.Show("Xoá thất bại", "Thông báo");

                    }
                }
            }
        }
    }
}
