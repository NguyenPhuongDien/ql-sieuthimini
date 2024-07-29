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
    public partial class frmBanHang : Form
    {
        DBConnect db = new DBConnect();
        DsHangHoa dsHangHoa = new DsHangHoa();
        DsKhachHang dsKhachHang = new DsKhachHang();
        public frmBanHang()
        {
            InitializeComponent();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string gettime = DateTime.Now.ToString();
            txtDateTime.Text = gettime;
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            radKH_Cu.Checked = true;
            btnThemKH_Moi.Visible = false;
            //Hiển thị hàng hoá
            ShowHangHoa();
            //Hiển thị khách hàng
            ShowKhachHang();
            //Thành tiền
            string thanhtien = "0";
            txtThanhTien.Text = thanhtien + "  VND";
            dgv_Chon_SP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_SanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void radKH_Cu_CheckedChanged(object sender, EventArgs e)
        {
            if (radKH_Cu.Checked == true)
            {
                btnThemKH_Moi.Visible = false;
                cboKhachHang.Enabled = true;
            }    

        }

        private void radKH_Moi_CheckedChanged(object sender, EventArgs e)
        {
            if (radKH_Moi.Checked == true)
                btnThemKH_Moi.Visible = true;
            cboKhachHang.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "")
            {
                double soluong = double.Parse(txtSoLuong.Text);
                double slHienCo = double.Parse(txtSLHienTai.Text);
                if(soluong>slHienCo)
                {
                    MessageBox.Show("Số lượng hiện tại không đủ!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Clear();
                }    
                else
                {
                    
                    foreach (DataGridViewRow row in dgv_SanPham.SelectedRows)
                    {
                        int temp = 0;
                        string maHH = row.Cells["MaHH"].Value.ToString();
                        string tenHH = row.Cells["TenHH"].Value.ToString();
                        string dvt = row.Cells["DVT"].Value.ToString();
                        double giaBan = (double)row.Cells["GiaBan"].Value;
                        double soLuong = double.Parse(txtSoLuong.Text);
                        double thanhtien = giaBan * soLuong;
                        foreach (DataGridViewRow item in dgv_Chon_SP.Rows)
                        {
                            if(item.Cells[0].Value.ToString()==maHH)
                            {
                                //Cập nhật số lượng
                                double sl = (double)item.Cells[3].Value;
                                sl += soluong;
                                item.Cells[3].Value = sl.ToString();
                                //Cập nhật thành tiền
                                double tt = sl * giaBan;
                                item.Cells[5].Value = tt.ToString();
                                temp = 1;
                                break;
                            }
                        }    
                        if(temp==0)
                        {
                            dgv_Chon_SP.Rows.Add(maHH, tenHH, dvt, soLuong, giaBan, thanhtien);
                        }    
                    }
                    txtThanhTien.Text = tinhTongTien().ToString() + "  VND";
                    txtSoLuong.Clear();
                }
            }
            else
                MessageBox.Show("Nhập số lượng sản phẩm");
            
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgv_Chon_SP.SelectedRows.Count!=0)
            {
                // Lấy đối tượng DataRow của dòng đang chọn
                var selectedRow = dgv_Chon_SP.SelectedRows[0];
                if (selectedRow != null)
                {
                    dgv_Chon_SP.Rows.Remove(selectedRow);
                }
            }
        }
        private void dgv_SanPham_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang được chọn hay không
            if (dgv_SanPham.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgv_SanPham.SelectedRows[0];

                // Hiển thị thông tin từ dòng được chọn vào các TextBox
                txtMaSP.Text = selectedRow.Cells["MaHH"].Value.ToString();
                txtTenSP.Text = selectedRow.Cells["TenHH"].Value.ToString();
                txtDVT.Text = selectedRow.Cells["DVT"].Value.ToString();
                txtGiaBan.Text = selectedRow.Cells["GiaBan"].Value.ToString();
                txtSLHienTai.Text = selectedRow.Cells["SoLuong"].Value.ToString();
            }
        }
        //Hàm xử lý
        private void ShowGiamGia()
        {

        }
        //Hiển thị sản phẩm lên dataBase
        private void ShowHangHoa()
        {
            dsHangHoa.GetHangHoa();
            foreach(var item in dsHangHoa.ListHangHoa)
            {
                dgv_SanPham.Rows.Add(item.MaHH, item.TenHH, item.DVT, item.SoLuong, item.GiaBan);
            }
        }
        private void ShowKhachHang()
        {
            dsKhachHang.GetKhachHang();

            // Gán nguồn dữ liệu
            cboKhachHang.DataSource = dsKhachHang.ListKhachHang;

            // Chỉ định ValueMember và DisplayMember
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.DisplayMember = "TenKH";

            // Tuỳ chọn: thiết lập SelectedValue nếu cần
            // cboKhachHang.SelectedValue = "DefaultMaKH";
        }
        //Reset
        void reset()
        {
            dgv_Chon_SP.DataSource = null;
            txtSoLuong.Clear();
            txtKhachDua.Clear();
            txtThoiLai.Clear();
        }
        //Tính tổng tiền
        public double tinhTongTien()
        {
            double tTien = 0;
            foreach (DataGridViewRow row in dgv_Chon_SP.Rows)
            {
                // Kiểm tra xem giá trị trong ô "ThanhTien" có null hay không
                if (row.Cells["TTien"].Value != null)
                {
                    // Ép kiểu giá trị thành double và cộng vào tổng tiền
                    tTien += Convert.ToDouble(row.Cells["TTien"].Value);
                }
            }
            return tTien;
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {

            //Xoá toàn bộ sản phẩm được chọn
            dgv_Chon_SP.Rows.Clear();
        }

        private void frmBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đóng form?", "Thông báo"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

      

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có khách hàng nào được chọn hay không
            if (cboKhachHang.SelectedIndex != -1)
            {
                // Lấy thông tin của khách hàng được chọn
                string sdtKhachHang = ((KhachHang)cboKhachHang.SelectedItem).SDT_KH;
                // Hiển thị số điện thoại trong TextBox txtSDTKH
                txtSDT.Text = sdtKhachHang;
            }
            else
            {
                // Nếu không có khách hàng nào được chọn, xóa nội dung trong TextBox txtSDTKH
                txtSDT.Text = "";
            }
        }

        private void btnThemKH_Moi_Click(object sender, EventArgs e)
        {
            frmQuanLy_KhachHang frmKH = new frmQuanLy_KhachHang();
            frmKH.Show();
        }
        private void btnTimKH_Click(object sender, EventArgs e)
        {
            string sdtTimKiem = txtTimKH.Text;
            KhachHang khachHangTimKiem = dsKhachHang.ListKhachHang.Find(kh => kh.SDT_KH == sdtTimKiem);
            if (khachHangTimKiem != null)
            {
                cboKhachHang.SelectedValue = khachHangTimKiem.MaKH;
            }
            else
                MessageBox.Show("Không tồn tại khách hàng có SDT " + sdtTimKiem + "","Thông báo");
        }

        private void txtTimKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ được nhập vào TextBox
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtKhachDua.Text == "")
            {
                MessageBox.Show("Chưa nhập tiền khách đưa!", "Thông báo");
            }
            else
            {
                string ngay = DateTime.Now.ToString("yyyy-MM-dd");

                string demHD = "select count(*) from PhieuBanHang where NgayBH='" + ngay + "'";
                //Tạo mã hoá đơn
                int kq = (int)db.getScalar(demHD);
                kq = kq + 1;
                string ngay1 = DateTime.Now.ToString("ddMMyyyy");
                string MaNV = QuanLy_DangNhap.Instance.MaNV;
                string MaHD = MaNV + ngay1 + kq.ToString("D3");
                string MaKH = cboKhachHang.SelectedValue.ToString();
                double tongTien = 0;
                //Tạo hoá đơn trong DTB
                string taoHD = "INSERT INTO PhieuBanHang(MaBanHang, MaNV, MaKH, NgayBH)" +
                        "VALUES('" + MaHD + "', '" + MaNV + "', '" + MaKH + "', '" + ngay + "')";
                int temp = db.getNonQuery(taoHD);
               
                if (temp != 0)
                {
                    foreach (DataGridViewRow row in dgv_Chon_SP.Rows)
                    {

                        if (row != null)
                        {
                            //string MaSP = row.Cells["MaSP"].Value.ToString();

                            string MaSP = Convert.ToString(row.Cells["MaSP"].Value);
                            double giaBan = Convert.ToDouble(row.Cells["SLuong"].Value);
                            int soLuong = Convert.ToInt32(row.Cells["SLuong"].Value);
                            double thanhTien = Convert.ToDouble(row.Cells["TTien"].Value);
                            if (MaSP != "")
                            {
                                string themChiTietHD = "INSERT INTO ChiTietBanHang VALUES ('" + MaHD + "', '" + MaSP + "', " + giaBan + ", " + soLuong + "," + thanhTien + ");";
                                db.getNonQuery(themChiTietHD);
                                tongTien += thanhTien;
                            }
                        }
                    }
                }


                //In Hoá đơn

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
                rpt.SetParameterValue("KhachDua", txtKhachDua.Text);
                rpt.SetParameterValue("ThoiLai",txtThoiLai.Text);
                frmChiTietHoaDon frmHoaDon = new frmChiTietHoaDon();
                frmHoaDon.Report_HoaDon.ReportSource = rpt;
                frmHoaDon.Show();
                
                frmHoaDon.FormClosed += (s, eventArgs) =>
                {
                    //Cập nhật số lượng
                    dgv_SanPham.DataSource = null;
                    dsHangHoa.GetHangHoa();
                    dgv_SanPham.DataSource = dsHangHoa.ListHangHoa;
                    dgv_SanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                };
                //Clear text
                dgv_Chon_SP.Rows.Clear();
                txtSoLuong.Clear();
                txtThoiLai.Clear();
                txtKhachDua.Clear();
                string thanhtien = "0";
                txtThanhTien.Text = thanhtien + "  VND";
            }    
            
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtKhachDua.Text))
            {
                double khachdua = Convert.ToDouble(txtKhachDua.Text);
                double thoitien = khachdua - tinhTongTien();
                txtThoiLai.Text = thoitien.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text.ToLower();
            List<HangHoa> ketQuaTimKiem = dsHangHoa.ListHangHoa.Where(hh => hh.TenHH.ToLower().Contains(timkiem)).ToList();
            dgv_SanPham.DataSource = null; // Xóa dữ liệu 
            dgv_SanPham.DataSource = ketQuaTimKiem;
        }

        private void txtKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là số và không phải là phím Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho phép nhập ký tự này vào TextBox
            }
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là số và không phải là phím Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Không cho phép nhập ký tự này vào TextBox
            }
        }
    }
}
