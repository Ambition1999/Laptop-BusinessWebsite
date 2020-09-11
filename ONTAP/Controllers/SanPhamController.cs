using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONTAP.Models;
using PagedList;

namespace ONTAP.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/

        quanlybanlaptop2Entities db = new quanlybanlaptop2Entities();

        public ActionResult SanPham(int? page)
        {
            var lstLT = db.tblChiTietThietBi;
            ViewBag.lstLT = lstLT;

            int PageSize = 8;
            int Pagenumber = (page ?? 1);
            return View(lstLT.OrderByDescending(n => n.GiaTien).ToPagedList(Pagenumber, PageSize));
        }

        public ActionResult SanPhamPartial()
        {
            return PartialView();
        }


        public ActionResult XemChiTiet(int? maTB, int? maCauHinh)
        {
            if (maTB == null || maCauHinh == null)
                return HttpNotFound();
            tblChiTietThietBi ct = db.tblChiTietThietBi.SingleOrDefault(n => n.MaTB == maTB && n.MaCauHinh == maCauHinh);
            return View(ct);
        }

        public ActionResult LapTop(int? page)
        {
            var lstLT = db.tblChiTietThietBi.Where(t => t.tblThietBi.MaLoai == 1);
            ViewBag.lstLT = lstLT;

            int PageSize = 8;
            int Pagenumber = (page ?? 1);
            return View(lstLT.OrderByDescending(n => n.GiaTien).ToPagedList(Pagenumber, PageSize));
        }

        public ActionResult LinhKien(int? page)
        {
            var lstLT = db.tblChiTietThietBi.Where(t => t.tblThietBi.MaLoai == 2);
            ViewBag.lstLT = lstLT;

            int PageSize = 8;
            int Pagenumber = (page ?? 1);
            return View(lstLT.OrderByDescending(n => n.GiaTien).ToPagedList(Pagenumber, PageSize));
        }
    }
}
