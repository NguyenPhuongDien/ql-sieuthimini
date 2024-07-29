using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Nhom1_QuanLySieuThiMini
{
    public class PhieuGiamGia
    {
        public string MaPGG { get; set; }
        public string TenPGG { get; set; }
        public string NgayBD { get; set; }
        public string NgayKT { get; set; }
        public double GiaTriGG { get; set; }
        public string GhiChu { get; set; }
        public PhieuGiamGia()
        {

        }
        public PhieuGiamGia(string ma,string ten,string bd,string kt,double giatri,string notes)
        {
            this.MaPGG = ma;
            this.TenPGG = ten;
            this.NgayBD = bd;
            this.NgayKT = kt;
            this.GiaTriGG = giatri;
            this.GhiChu = notes;
        }
    }
    public class DsPhieuGiamGia
    {
        public List<PhieuGiamGia> ListPGG = new List<PhieuGiamGia>();
        DBConnect db = new DBConnect();
        public void GetPGG()
        {
            string sql = "select * from PhieuGiamGia";
            // Sử dụng phương thức getDataReader để lấy dữ liệu từ cơ sở dữ liệu
            SqlDataReader reader = db.getDataReader(sql);

            if (reader != null)
            {// Kiểm tra xem có dữ liệu trả về hay không
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string MaPGG = reader["MaPGG"].ToString();
                        string TenPGG = reader["TenPGG"].ToString();
                        string NgayBD = reader["NgayBD"].ToString();
                        string NgayKT = reader["NgayKT"].ToString();
                        double GiaTriGG = (double)reader["GiaTriGG"];
                        string GhiChu = reader["GhiChu"].ToString();
                        PhieuGiamGia pgg = new PhieuGiamGia(MaPGG, TenPGG, NgayBD, NgayKT, GiaTriGG, GhiChu);
                        ListPGG.Add(pgg);
                    }
                }
                reader.Close();
            }
        }
    }
}
