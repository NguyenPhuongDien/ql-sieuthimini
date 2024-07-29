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
    public class NhanVien
    {
        string maNV;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        string tenNV;

        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }
        string gioiTinh;

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        string namSinh;

        public string NamSinh
        {
            get { return namSinh; }
            set { namSinh = value; }
        }
        string sDT_NV;

        public string SDT_NV
        {
            get { return sDT_NV; }
            set { sDT_NV = value; }
        }
        string diaChi_NV;

        public string DiaChi_NV
        {
            get { return diaChi_NV; }
            set { diaChi_NV = value; }
        }
        string maCV;

        public string MaCV
        {
            get { return maCV; }
            set { maCV = value; }
        }

        

        public NhanVien()
        {

        }
        public NhanVien(string manv,string tennv,string gioitinh,string namsinh,
            string sdt_nv,string diachi_nv,string macv)
        {
            this.MaNV = manv;
            this.TenNV = tennv;
            this.GioiTinh = gioitinh;
            this.NamSinh = namsinh;
            this.SDT_NV = sdt_nv;
            this.DiaChi_NV = diachi_nv;
            this.MaCV = macv;
        }
        public static string FindTenNV_MaNV(string manv)
        {
            DBConnect db = new DBConnect();
            string tennv = "";
            string sql = "select TenNV from nhanvien where manv='" + manv + "'";
            tennv = db.getScalar(sql).ToString();
            return tennv;
        }
        public static string FindTenCV_MANV(string manv)
        {
            string tencv = "";
            DBConnect db = new DBConnect();
            string sql = "select tencv from nhanvien,chucvu where manv='" + manv + "' and nhanvien.macv=chucvu.macv";
            tencv = db.getScalar(sql).ToString();
            return tencv;
        }
    }
    public class ListNhanVien
    {
        public List<NhanVien> DsNhanVien { get; set; }
        DataSet DS_NhanVien = new DataSet();
        DBConnect db = new DBConnect();
        public void GetData_NhanVien()
        {
            string sqlSelect = "SELECT * FROM NhanVien";
            SqlDataReader reader = db.getDataReader(sqlSelect);
            // Khởi tạo danh sách nhân viên
            DsNhanVien = new List<NhanVien>();

            while (reader.Read()) // Đọc từng dòng dữ liệu từ reader
            {
                NhanVien nhanVien = new NhanVien
                {
                    MaNV = reader["MaNV"].ToString(),
                    TenNV = reader["TenNV"].ToString(),
                    GioiTinh = reader["GioiTinh"].ToString(),
                    NamSinh = reader["NamSinh"].ToString(),
                    SDT_NV = reader["SDT_NV"].ToString(),
                    DiaChi_NV = reader["DiaChi_NV"].ToString(),
                    MaCV = reader["MaCV"].ToString()
                };

                DsNhanVien.Add(nhanVien); // Thêm đối tượng NhanVien vào danh sách
            }
        }
        public NhanVien Find_NhanVienID(string id)
        {
            foreach(var item in DsNhanVien)
            {
                if (item.MaNV == id)
                    return item;
            }
            return null;
        }
        public string Find_MaCV(string MaNV)
        {
            foreach (var item in DsNhanVien)
            {
                if (MaNV == item.MaNV)
                {
                    return item.MaCV;
                }
            }
            return null;
        }
        
    }
}
