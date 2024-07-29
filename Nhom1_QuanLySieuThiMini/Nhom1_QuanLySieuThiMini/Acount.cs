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
    public class Acount
    {
        public string TK { get; set; }
        public string MK { get; set; }
        public string MaNV { get; set; }
       
        public Acount(string tk, string mk, string manv)
        {
            this.TK = tk;
            this.MK = mk;
            this.MaNV = manv;
        }
        public Acount()
        {
            
        }
        public static int insertTaiKhoan(string tk,string mk, string manv)
        {
            int kq = 0;
            DBConnect db = new DBConnect();
            string dem = "select count(*) from TaiKhoan where MaNV='" + manv + "'";
            int soTKCuaNhanVien=(int)db.getScalar(dem);
            if (soTKCuaNhanVien != 0)
            {
                kq = -1;
                return kq;
            }   
            else
            {
                string sql = "insert into TaiKhoan values('" + tk + "','" + mk + "','" + manv + "')";
                kq = db.getNonQuery(sql);
            }
            return kq;
        }
        public static int XoaTaiKhoan(string tk)
        {
            int kq = 0;
            DBConnect db = new DBConnect();
            string dem = "select count(*) from TaiKhoan where TaiKhoan='" + tk + "'";
            int soTKCuaNhanVien = (int)db.getScalar(dem);
            if (soTKCuaNhanVien == 0)
                return 2;//Trả về 2 nếu không tìm thấy tài khoản
            else
            {
                string sql = "delete from TaiKhoan where TaiKhoan='" + tk + "'";
                kq = db.getNonQuery(sql);
            }
            return kq;
        }
        
    }
    public class ListTaiKhoan
    {
        DBConnect db = new DBConnect();
        public List<Acount> DsTaiKhoan { get; set; }
        public ListTaiKhoan ()
        {
            DsTaiKhoan = new List<Acount>();
        }

        //Lấy dữ liệu từ cơ sở dữ liệu
        public void GetData_TaiKhoan()
        {
            if (DsTaiKhoan != null)
                DsTaiKhoan.Clear();
            string sql = "select* from TaiKhoan";
            SqlDataReader reader = db.getDataReader(sql);
            while (reader.Read())
            {
                Acount acount = new Acount();
                acount.TK = reader["TaiKhoan"].ToString();
                acount.MK = reader["MatKhau"].ToString();
                acount.MaNV = reader["MaNV"].ToString();
                DsTaiKhoan.Add(acount);
            }
            reader.Close();
        }

        // Đăng nhập vào hệ thống
        public bool Login(string tk, string mk)
        {
            foreach (var item in DsTaiKhoan)
            {
                if (tk == item.TK && mk == item.MK)
                    return true;
            }
            return false;
        }
        public string Find_MaNV_By_TK(string tk)
        {
            foreach(var item in DsTaiKhoan)
            {
                if(tk==item.TK)
                {
                    return item.MaNV;
                }    
            }    
            return "Không tìm thấy";
        }
    }
}
