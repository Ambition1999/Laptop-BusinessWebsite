using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONTAP.Models;
namespace ONTAP.Controllers
{
    public class AppController : Controller
    {
        //
        // GET: /App/

        public ActionResult HienThiSP()
        {
            return View();
        }
       
        public ActionResult ChiTietSP()
        {
            return View();
        }
         [HttpPost]
        public ActionResult Sanpham(FormCollection c)
        {
            var ten = c["txt1"] + " " + c["txt2"];
            var mail = c["txt3"];
            User a = new User();
            a.name = ten;
            a.email = mail;
            return RedirectToAction("Contact", a);
        }
        public ActionResult Contact(User s)
        {
            return View(s);
        }
    }
}
