using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONTAP.Models;
namespace ONTAP.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/

        public List<item> layGio()
        {
            List<item> lst = Session["cart"] as List<item>;
            if (lst == null)
            {
                lst = new List<item>();
                Session["cart"] = lst;
            }
            return lst;
        }
        public ActionResult xemGio()
        {
            List<item> lst = layGio();
            ViewBag.tongTien = tongTien();
            ViewBag.tongSL = tongSL();
            if (lst.Count == 0)
            {
                setAlert("Không Có Sản Phẩm Nào Trong Giỏ", "success");
            }
            return View(lst);
        }
        public ActionResult themGio(int maTB, int maCauHinh)
        {
            if (maTB == null || maCauHinh == null)
                return HttpNotFound();
            List<item> lst = layGio();
            item i = lst.FirstOrDefault(n => n.maTB == maTB && n.cauHinh == maCauHinh);

            if (i == null)
            {
                i = new item(maTB, maCauHinh);
                lst.Add(i);
            }
            else
            {
                if (ktDuSL(maTB, maCauHinh))
                {
                    if (i.sl != 4)
                    {
                        i.sl++;
                    }
                    else
                    {
                        setAlert("Số Lượng Vượt Quá 4 Sản Phẩm", "error");
                    }
                }
                else
                    setAlert("Số Lượng Vượt Quá Cho Phép", "error");
            }
            return RedirectToAction("xemGio");
        }
        public ActionResult xoaHang(int maTB,int maCauHinh)
        {
            List<item> lst = Session["cart"] as List<item>;
            item i = lst.FirstOrDefault(n => n.maTB == maTB&&n.cauHinh==maCauHinh);
            if (i != null)
                lst.Remove(i);
            return RedirectToAction("xemGio");
        }
        public ActionResult AddSL(int maTB,int maCauHinh)
        {
            List<item> lst = Session["cart"] as List<item>;
            item i = lst.FirstOrDefault(n => n.maTB == maTB&&n.cauHinh==maCauHinh);
            if (ktDuSL(maTB, maCauHinh))
            {
                
                if (i.sl != 4)
                    i.sl++;
            }
            else
                setAlert("Số Lượng Vượt Quá Cho Phép", "error");
            return RedirectToAction("xemGio");
        }
        public ActionResult MinorSL(int maTB, int maCauHinh)
        {
            List<item> lst = Session["cart"] as List<item>;
            item i = lst.FirstOrDefault(n => n.maTB == maTB && n.cauHinh == maCauHinh);
            if (i.sl != 1)
                i.sl--;
            return RedirectToAction("xemGio");
        }
        public ActionResult ThanhToan()
        {
            return View();
        }
        public double tongTien()
        {
            double tong = 0;
            List<item> lst = Session["cart"] as List<item>;
            if (lst != null)
            {
                tong = lst.Sum(n => n.thanhTien);
            }
            return tong;
        }
        public int tongSL()
        {
            int sl = 0;
            List<item> lst = Session["cart"] as List<item>;
            if (lst != null)
            {
                sl = lst.Sum(n => n.sl);
            }
            return sl;
        }
        public bool ktDuSL(int maTB, int maCauHinh)
        {
            List<item> lst = Session["cart"] as List<item>;
            item i = lst.FirstOrDefault(n => n.maTB == maTB && n.cauHinh == maCauHinh);
            if (i.sl >= i.tongSL)
                return false;
            return true;
        }
        public void setAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }

}

