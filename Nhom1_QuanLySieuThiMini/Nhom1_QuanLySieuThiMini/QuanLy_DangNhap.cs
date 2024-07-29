using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom1_QuanLySieuThiMini
{
    public class QuanLy_DangNhap
    {
        private static QuanLy_DangNhap _instance;

        // Thông tin đăng nhập
        public string TaiKhoan { get; private set; }
        public string MatKhau { get; private set; }
        public string MaNV { get;private set; }

        private QuanLy_DangNhap() { }

        public static QuanLy_DangNhap Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QuanLy_DangNhap();
                }
                return _instance;
            }
        }

        public void SetCredentials(string taiKhoan, string matKhau,string manv)
        {
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            MaNV = manv;
        }
    }
}
