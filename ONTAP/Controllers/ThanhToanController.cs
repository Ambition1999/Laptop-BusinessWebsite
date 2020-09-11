using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONTAP.Models;

namespace ONTAP.Controllers
{
    public class ThanhToanController : Controller
    {
        //
        // GET: /ThanhToan/
      quanlybanlaptop2Entities db = new quanlybanlaptop2Entities();
        public ActionResult ThanhToan()
        {
            if (layGioHang().Count == 0)
            {
                setAlert("abc!!", "warning");
                return RedirectToAction("xemGio", "GioHang");
            }
            if (Session["dangnhap"] != null)
            {
                tblKhachHang a = Session["dangnhap"] as tblKhachHang;
                return View(a);
                //return RedirectToAction("xemGio", "GioHang");
            }
            setAlert("You haven't log in yet!!", "warning");
            return RedirectToAction("xemGio", "GioHang");

        }
        public ActionResult PreGioHang()
        {
            List<item> lst = layGioHang();
            ViewBag.tt = tongTien();
            return PartialView(lst);
        }
        public ActionResult HoanTat()
        {

            return View();
        }

        [HttpPost]
        public ActionResult XacNhanThanhToan(FormCollection c)
        {
            if (Session["dangnhap"] == null)
            {
                ViewBag.TB = "Ban chua dang nhap";
                return RedirectToAction("DangNhap", "KhachHang");
            }
            try
            {
                tblKhachHang kh = Session["dangnhap"] as tblKhachHang;
                //  tblKhachHang kh = db.tblKhachHangs.FirstOrDefault();
                String pt = c["PTThanhToan"].ToString();
                String tg = c["DonViVC"].ToString();
                String dc = c["DiaChiNhan"].ToString();
                List<item> lst = layGioHang();
                tblHoaDon hd = new tblHoaDon();
                DateTime now = DateTime.Now;
                hd.NgayHD = DateTime.Parse(now.ToShortDateString());
                hd.MaNV = 1;
                hd.MaKH = kh.MaKH;
                hd.TinhTrangHD = "Chưa thanh toán";
                hd.TongTien = (decimal)tongTien();
                
                db.tblHoaDon.Add(hd);
                db.SaveChanges();

                tblThanhToan thanhtoan = new tblThanhToan();
                thanhtoan.MaHD = hd.MaHD;
                //thanhtoan.MaKH = kh.MaKH;
                thanhtoan.SoTienThanhToan = (decimal)tongTien();
                thanhtoan.NgayThanhToan = hd.NgayHD;
                if (pt == "0")
                {
                    thanhtoan.PhuongThucThanhToan = "Thanh toán khi nhận hàng";
                }
                else
                    thanhtoan.PhuongThucThanhToan = "Thanh toán ngay";
                tblGiaoHang giaohang = new tblGiaoHang();
                giaohang.MaHD = hd.MaHD;
                giaohang.TenNguoiNhan = kh.TenKH;
                giaohang.DiaChi1 = dc;
                giaohang.DiaChi2 = dc;
                giaohang.DiaChi3 = dc;
                giaohang.MaDonViVanChuyen = tg;
                giaohang.SoDT1 = kh.DienThoai;
                giaohang.Email = kh.Email;
                //   add data into database
                db.tblThanhToan.Add(thanhtoan);
                db.tblGiaoHang.Add(giaohang);
                db.SaveChanges();
                foreach (var sp in lst)
                {
                    if (ktSL(sp.maTB, sp.sl, sp.cauHinh))
                    {
                        tblChiTietHD ct = new tblChiTietHD();
                        ct.MaHD = hd.MaHD;
                        ct.MaTB = sp.maTB;
                        ct.MaCauHinh = sp.cauHinh;
                        ct.SoLuong = sp.sl;
                        ct.ThanhTien = (decimal)sp.thanhTien;
                        db.tblChiTietHD.Add(ct);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.TB = "Failed";
                        return RedirectToAction("ThanhToan", "ThanhToan");
                    }
                }
                lst.Clear();
                return RedirectToAction("HoanTat", "ThanhToan");
            }
            catch
            {
                TempData["Message"] = "Error !!";
                return RedirectToAction("ThanhToan", "ThanhToan");
            }

        }

        private List<item> layGioHang()
        {
            List<item> list = Session["cart"] as List<item>;
            if (list == null)
            {
                list = new List<item>();
                Session["cart"] = list;
            }
            return list;
        }

        private int demSoLuong()
        {
            int sl = 0;
            List<item> list = layGioHang();
            if (list != null)
            {
                sl = list.Sum(n => n.sl);
            }
            return sl;
        }
        private double tongTien()
        {
            double tt = 0;
            List<item> list = layGioHang();
            if (list != null)
            {
                tt = list.Sum(n => n.thanhTien);
            }
            return tt;
        }
        private bool ktSL(int ma, int sl, int mach)
        {
            tblChiTietThietBi a = db.tblChiTietThietBi.Where(t => t.MaTB == ma && t.MaCauHinh == mach).FirstOrDefault();
            if (a != null)
            {
                if (a.SoLuong >= sl)
                {
                    return true;
                }
            }
            return false;
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

