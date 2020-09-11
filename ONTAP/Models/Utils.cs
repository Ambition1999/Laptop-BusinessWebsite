using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ONTAP.Models
{
    public class Utils
    {
        quanlybanlaptop2Entities db = new quanlybanlaptop2Entities();
        public Utils() { }

        public  List<ThongKeThuongHieu> getThuongHieu(){
            List<ThongKeThuongHieu> lst = new List<ThongKeThuongHieu>();
            lst = (from p in db.tblChiTietHD
                   group p by p.MaTB into pg
                   // join *after* group
                   join bp in db.tblThietBi on pg.FirstOrDefault().MaTB equals bp.MaTB
                   select new ThongKeThuongHieu
                   {
                       tenThuongHieu =bp.NhanHieu,
                       doanhThu=(double)pg.Sum(t=>t.ThanhTien),
                       luotDat=pg.Count()
                       // now there is a 'bp' in scope
                   }).ToList();
            return lst;
        }
        public List<ThongKeThuongHieu> getThongKeNgay()
        {
            List<ThongKeThuongHieu> lst = new List<ThongKeThuongHieu>();
            lst = (from p in db.tblHoaDon
                   where p.TinhTrangHD =="Đã thanh toán"
                   group p by new {p.NgayHD.Day,p.NgayHD.Month,p.NgayHD.Year } into pg
                  
                   //  orderby pg.Key descending
                   // join *after* group
                   select new ThongKeThuongHieu
                   {
                       ngay = pg.Key.Day,
                       thang=pg.Key.Month,
                       nam=pg.Key.Year,
                       doanhThu = (double)pg.Sum(t => t.TongTien),
                       luotDat=pg.Count()
                       // now there is a 'bp' in scope
                   }).ToList();
            return lst;
        }

        public List<tblHoaDon> getDonHangGanDay()
        {
            return db.tblHoaDon.Where(t => t.TinhTrangHD.Trim() == "Chưa thanh toán").Select(t => t).ToList().OrderByDescending(t => t.NgayHD).Take(5).ToList();
        }

        public List<ThietBi> getTrangThaiSanPham()
        {
            List<ThietBi> lst = new List<ThietBi>();
            lst = (from p in db.tblThietBi
                   join pq in db.tblChiTietThietBi on p.MaTB equals pq.MaTB
                   where p.MaTB == pq.MaTB
                   select new ThietBi
                   {
                       mathietbi=p.MaTB,
                       tenthietbi=p.TenTB,
                       nhanhieu=p.NhanHieu,
                       soluongton=pq.SoLuong
                   }
                ).ToList();
            return lst;
        }

        public bool thanhToanHoaDon(int mahd,int option)
        {
            tblHoaDon hd = db.tblHoaDon.Where(t => t.MaHD == mahd).FirstOrDefault();
            if (hd != null)
            {
                if (option == 0)
                {
                    hd.TinhTrangHD="Đã thanh toán";
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    hd.TinhTrangHD = "Đã hủy";
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public List<String> getThongKeMain()
        {
            List<String> list = new List<string>();
            string doanhthu = (decimal?)db.tblHoaDon.Where(t => t.TinhTrangHD.Trim() == "Đã thanh toán").Sum(t => (decimal?)t.TongTien).GetValueOrDefault() + "";
            string sohoadon = db.tblHoaDon.Count()+"";

            List<ThongKeThuongHieu> lst = new List<ThongKeThuongHieu>();
            lst = (from p in db.tblChiTietHD
                   group p by p.MaTB into pg
                   // join *after* group 
                   join bp in db.tblThietBi on pg.FirstOrDefault().MaTB equals bp.MaTB
                   select new ThongKeThuongHieu
                   {
                       tenThuongHieu = bp.NhanHieu,
                       doanhThu = (double)pg.Sum(t => t.ThanhTien),
                       luotDat = pg.Count(),
                       tenThietBi=bp.TenTB
                       // now there is a 'bp' in scope
                   }).ToList().OrderByDescending(t=>t.luotDat).ToList();
            string tenThietBi = lst.FirstOrDefault().tenThietBi;
            string luotDat = lst.FirstOrDefault().luotDat+"";
            string doanhThuBestSale = lst.FirstOrDefault().doanhThu+"";
            list.AddRange( new []{doanhthu,sohoadon,tenThietBi,luotDat,doanhThuBestSale});
            return list;


        }
    }
}