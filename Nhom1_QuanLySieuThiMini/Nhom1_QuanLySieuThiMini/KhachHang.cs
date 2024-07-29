using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Nhom1_QuanLySieuThiMini
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT_KH { get; set; }
        public string DiaChi_KH { get; set; }
        public KhachHang()
        { 
        }
        public KhachHang(string makh,string tenkh,string sdt,string diachi)
        {
            this.MaKH = makh;
            this.TenKH = tenkh;
            this.SDT_KH = sdt;
            this.DiaChi_KH = diachi;
        }
    }
    public class DsKhachHang
    {
        public List<KhachHang> ListKhachHang { get; set; }
        DBConnect db = new DBConnect();
        public DsKhachHang()
        {
            ListKhachHang = new List<KhachHang>();
        }
        public void GetKhachHang()
        {
            string sql = "select * from KhachHang";
            // Sử dụng phương thức getDataReader để lấy dữ liệu từ cơ sở dữ liệu
            SqlDataReader reader = db.getDataReader(sql);
            if (reader != null)
            {// Kiểm tra xem có dữ liệu trả về hay không
                if (reader.HasRows)
                {
                    while (reader.Read())
                    { // Đọc dữ liệu từ SqlDataReader và tạo đối tượng HangHoa
                        string maKH = reader["MaKH"].ToString();
                        string tenKH = reader["TenKH"].ToString();
                        string sdt = reader["SDT_KH"].ToString();
                        string diachi = reader["DiaChi_KH"].ToString();
                        // Tạo đối tượng KhachHang và thêm vào danh sách
                        KhachHang kh = new KhachHang(maKH, tenKH, sdt, diachi);
                        ListKhachHang.Add(kh);
                    }
                }
                // Đóng SqlDataReader sau khi đọc xong dữ liệu
                reader.Close();
            }
        }
    }
}
