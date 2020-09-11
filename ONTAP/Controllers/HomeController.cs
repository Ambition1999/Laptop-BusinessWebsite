using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONTAP.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult TrangChu()
        {
            return View();
        }
        public ActionResult ChiTiet1SP()
        {
            return View();
        }
        public ActionResult HuongDanSD()
        {
            return View();
        }


        public ActionResult QuyDinhDoiTra()
        {
            return View();
        }

        public ActionResult PhuongThucVanChuyen()
        {
            return View();
        }


    }
}
