using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Globalization;
namespace ONTAP.Models
{
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }

        public bool kiemTraNhapDungTaiKhoan(String taiKhoan) 
        {
            if (taiKhoan.Length > 20||taiKhoan.Length<5)
                return false;
            char[] arr = taiKhoan.ToCharArray();
            foreach (char i in arr) 
            {
                if (Char.IsWhiteSpace(i))
                    return false;
            }
            if (taiKhoan.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                return false;
            }
            return true;
        }
        public bool kieTraNhapDungMatKhau(String matKhau)
        {
            if (matKhau.Length > 8 || matKhau.Length < 4)
                return false;
            char[] arr = matKhau.ToCharArray();
            foreach (char i in arr)
            {
                if (Char.IsWhiteSpace(i))
                    return false;
            }
            if (matKhau.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                return false;
            }
            return true;
        }
        public bool kiemTraKhongDuocDeTrong(String chuoi)
        {
            if (String.IsNullOrEmpty(chuoi))
                return false;
            return true;
        }
        public bool kiemTraEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public bool kiemTraSDT(String sdt)
        {
            if (sdt.Length != 10)
                return false;
            string dau = sdt.Substring(0,2);
            string chuan="09|03|07|08|05";
            if (!chuan.Contains(dau))
                return false;
            char[] arr = sdt.ToCharArray();
            foreach (char i in arr)
            {
                if (!Char.IsDigit(i))
                    return false;
            }
            return true;
        }
        public bool kiemTraNgaySinh(String ngaySinh)
        {
            string[] formats = { "d/MM/yyyy", "dd/MM/yyyy" };
            DateTime parsedDate;
            var isValidFormat = DateTime.TryParseExact(ngaySinh, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out parsedDate);

            if (isValidFormat)
            {
                string.Format("{0:d/MM/yyyy}", parsedDate);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool kiemTraQua100(String chuoi)
        {
            if (chuoi.Length > 100)
            {
                return false;
            }
            return true;
        }
    }
}