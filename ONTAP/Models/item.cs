using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ONTAP.Models
{
    public class item
    {
        quanlybanlaptop2Entities db = new quanlybanlaptop2Entities();
        public int maTB { get; set; }
        public string tenTB { get; set; }
        public double gia { get; set; }
        public string hinh { get; set; }
        public string moTa { get; set; }
        public int sl { get; set; }
        public int cauHinh { get; set; }
        public string tenCauHinh { get; set; }
        public int tongSL { get; set; }

        public double thanhTien
        {
            get { return sl * gia; }
        }
        public item() { }
        public item(int ms, int ch)
        {
            maTB = ms;
            tblThietBi tb = db.tblThietBi.FirstOrDefault(n => n.MaTB == ms);
            tblChiTietThietBi ct = db.tblChiTietThietBi.Where(t => t.MaTB == ms && t.MaCauHinh == ch).FirstOrDefault();
            tenTB = tb.TenTB;
            moTa = tb.ThongTinMoTa;
            hinh = catHinh(tb.HinhAnhChung);
            tenCauHinh = ct.CPU;
            sl = 1;
            cauHinh = ch;
            gia = ct.GiaTien;
            tongSL = ct.SoLuong;
        }
        public string catHinh(string hinh)
        {
            String[] arr = hinh.Split(',');
            return arr[0];
        }
    }
}