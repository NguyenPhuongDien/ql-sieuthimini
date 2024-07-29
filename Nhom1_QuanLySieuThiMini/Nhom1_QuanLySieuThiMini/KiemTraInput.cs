using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom1_QuanLySieuThiMini
{
    public class KiemTraInput
    {
        public bool KiemTraMaLoaiHangHoa(string input)
        {
            //Nếu rỗng hoặc null -> false 
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            else
            {
                //Nếu 2 ký tự đầu không phải LH: false
                if (input[0] != 'L') return false;
                if (input[1] != 'H') return false;
                //Nếu các ký tự sau đó không phải là số nguyên dương từ 0-> 9: false
                for (int i = 2; i < input.Length; i++)
                {
                    if (char.IsDigit(input[i]) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public bool IsMoney(string input)
        {
            if (input.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsValidDate(string date)
        {
            // Kiểm tra độ dài của chuỗi
            if (date.Length != 10)
            {
                return false;
            }

            // Kiểm tra từng ký tự trong chuỗi
            for (int i = 0; i < date.Length; i++)
            {
                if (i == 2 || i == 5)
                {
                    if (date[i] != '/')
                    {
                        return false;
                    }
                }
                else
                {
                    if (!char.IsDigit(date[i]))
                    {
                        return false;
                    }
                }
            }

            // Kiểm tra giá trị của các số
            int day = int.Parse(date.Substring(0, 2));
            int month = int.Parse(date.Substring(3, 2));
            int year = int.Parse(date.Substring(6, 4));

            if (year < 1000 || year > 9999)
            {
                return false;
            }

            if (month < 1 || month > 12)
            {
                return false;
            }

            // Tháng 2 có 28 ngày hoặc 29 ngày trong năm nhuận
            if (month == 2 && year % 4 == 0 && year % 100 != 0)
            {
                if (day > 29)
                {
                    return false;
                }
            }
            else if (month == 2 && day > 28)
            {
                return false;
            }

            // Các tháng còn lại có 30 ngày hoặc 31 ngày
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (day > 31)
                {
                    return false;
                }
            }
            else if (day > 30)
            {
                return false;
            }

            return true;
        }
        //Hàm Kiểm tra số điện thoại
        public bool IsPhoneNumber(string input)
        {
            if (input.Length != 10)
            {
                return false;
            }

            // Kiểm tra đầu số
            string[] prefixes = { "09", "08", "07", "03", "05" };
            if (!prefixes.Contains(input.Substring(0, 2)))
            {
                return false;
            }

            // Kiểm tra các ký tự còn lại
            for (int i = 2; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return false;
                }
            }

            return true;
        }
        //Hàm kiểm tra mã nhân viên
        public bool KiemTraMaNhanVien(string input)
        {
            //Nếu rỗng hoặc null -> false 
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            else
            {
                //Nếu 2 ký tự đầu không phải NV: false
                if (input[0] != 'N') return false;
                if (input[1] != 'V') return false;
                //Nếu các ký tự sau đó không phải là số nguyên dương từ 0-> 9: false
                for (int i = 2; i < input.Length; i++)
                {
                    if (char.IsDigit(input[i]) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        
    }
}
