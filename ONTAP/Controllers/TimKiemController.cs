using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONTAP.Models;
using PagedList;

namespace ONTAP.Controllers
{
    public class TimKiemController : Controller
    {
        //
        // GET: /TimKiem/

        quanlybanlaptop2Entities db = new quanlybanlaptop2Entities();

        [HttpGet]
        public ActionResult KQTimKiemTen(string sTuKhoa, int? page)
        {
            if(Request.HttpMethod != "GET")
            {
                page = 1;
            }
            var lstSP = db.tblChiTietThietBi.Where(n => n.tblThietBi.TenTB.Contains(sTuKhoa));
            int PageSize = 8;
            int Pagenumber = (page ?? 1);
            ViewBag.TuKhoa = sTuKhoa;
            return View(lstSP.OrderBy(n => n.tblThietBi.TenTB).ToPagedList(Pagenumber, PageSize));
        }

        [HttpPost]
        public ActionResult KQTimKiemTen(string sTuKhoa, int? page, FormCollection f)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            var lstSP = db.tblChiTietThietBi.Where(n => n.tblThietBi.TenTB.Contains(sTuKhoa.Trim()));
            int PageSize = 8;
            int Pagenumber = (page ?? 1);
            ViewBag.TuKhoa = sTuKhoa;
            return View(lstSP.OrderBy(n => n.tblThietBi.TenTB).ToPagedList(Pagenumber, PageSize));
        }

        public ActionResult KQTimKiemGia(int GiaTien1, int GiaTien2, int? page)
        {
            var lstSP = db.tblChiTietThietBi.Where(n => n.GiaTien >= GiaTien1 && n.GiaTien <= GiaTien2);
            int PageSize = 8;
            int Pagenumber = (page ?? 1);
            ViewBag.GiaTien1 = GiaTien1;
            ViewBag.GiaTien2 = GiaTien2;
            return View(lstSP.OrderBy(n => n.GiaTien).ToPagedList(Pagenumber, PageSize));
        }

        public ActionResult KQTimNhanHieu(string sTuKhoa, int? page)
        {
            var lstSP = db.tblChiTietThietBi.Where(n => n.tblThietBi.NhanHieu == sTuKhoa);
            int PageSize = 8;
            int Pagenumber = (page ?? 1);
            ViewBag.TuKhoa = sTuKhoa;
            return View(lstSP.OrderBy(n => n.tblThietBi.TenTB).ToPagedList(Pagenumber, PageSize));
        }

        public ActionResult KQTimNhom(int sTuKhoa, int? page)
        {
            var lstSP = db.tblChiTietThietBi.Where(n => n.tblThietBi.MaNhomTB == sTuKhoa);
            int PageSize = 8;
            int Pagenumber = (page ?? 1);
            ViewBag.TuKhoa = sTuKhoa;
            return View(lstSP.OrderBy(n => n.tblThietBi.TenTB).ToPagedList(Pagenumber, PageSize));
        }
    }
}
