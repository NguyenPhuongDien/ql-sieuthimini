using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Nhom1_QuanLySieuThiMini
{
    public class HangHoa
    {
        public  string MaHH { get; set; }
        public string TenHH { get; set; }
        public  string DVT { get; set; }
        public double GiaNhap { get; set; }
        public double GiaBan { get; set; }
        public double SoLuong { get; set; }
        public string MaloaiHH { get; set; }
        public string MaNCC { get; set; }
        public HangHoa()
        {

        }
        public HangHoa(string mahh,string tenhh,string dvt,double gianhap,
            double giaban,double soluong,string maloaihh,string mancc)
        {
            this.MaHH = mahh;
            this.TenHH = tenhh;
            this.DVT = dvt;
            this.GiaNhap = gianhap;
            this.GiaBan = giaban;
            this.SoLuong = soluong;
            this.MaloaiHH = maloaihh;
            this.MaNCC = mancc;
        }
    }
    public class DsHangHoa
    {
        public  List<HangHoa> ListHangHoa { get; set; }
        //Kết nối cơ sở dữ liệu
        DBConnect db = new DBConnect();
        public DsHangHoa()
        {
            ListHangHoa = new List<HangHoa>();
        }
        public void GetHangHoa()
        {
            string sql = "select * from HangHoa";
            // Sử dụng phương thức getDataReader để lấy dữ liệu từ cơ sở dữ liệu
            SqlDataReader reader = db.getDataReader(sql);

            if (reader != null)
            {// Kiểm tra xem có dữ liệu trả về hay không
                if (reader.HasRows)
                {
                    while (reader.Read())
                    { // Đọc dữ liệu từ SqlDataReader và tạo đối tượng HangHoa
                        string maHH = reader["MaHH"].ToString();
                        string tenHH = reader["TenHH"].ToString();
                        string dvt = reader["DVT"].ToString();
                        double giaNhap = (double)reader["GiaNhap"];
                        double giaBan = (double)reader["GiaBan"];
                        double soLuong = (double)reader["SoLuong"];
                        string maloaiHH = reader["MaLoaiHH"].ToString();
                        string maNCC = reader["MaNCC"].ToString();

                        // Tạo đối tượng HangHoa và thêm vào danh sách
                        HangHoa hangHoa = new HangHoa(maHH, tenHH, dvt, giaNhap, giaBan, soLuong, maloaiHH, maNCC);
                        ListHangHoa.Add(hangHoa);
                    }
                }

                // Đóng SqlDataReader sau khi đọc xong dữ liệu
                reader.Close();
            }
        }
        
    }
}
