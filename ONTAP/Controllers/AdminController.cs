using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONTAP.Models;
using System.Web.Services;
using System.Collections;
using System.IO;
namespace ONTAP.Controllers
{
    public class AdminController : Controller
    {
        quanlybanlaptop2Entities tx = new quanlybanlaptop2Entities();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SanPham()
        {
            List<tblChiTietThietBi> lstLsp = tx.tblChiTietThietBi.ToList();
            return View(lstLsp);
        }
        public ActionResult NhanVien()
        {
            List<tblNhanVien> lstLsp = tx.tblNhanVien.ToList();
            return View(lstLsp);
        }
        public ActionResult KH()
        {
            List<tblKhachHang> lstLsp = tx.tblKhachHang.ToList();
            return View(lstLsp);
        }
        public ActionResult NhomThietBi()
        {
            List<tblNhomTB> lstLsp = tx.tblNhomTB.ToList();
            return View(lstLsp);
        }
        public ActionResult themSP()
        {
            ViewBag.LoaiThietBi = new SelectList(tx.tblLoaiThietBi.ToList(), "MaLoai", "TenLoai");
            ViewBag.NhaCungCap = new SelectList(tx.tblNhaCungCap.ToList(), "MaNCC", "TenNCC");
            ViewBag.NhomThietBi = new SelectList(tx.tblNhomTB.ToList(), "MaNhomTB", "TenNhom");
            return View();
        }
        [HttpPost]
        public ActionResult themSP(FormCollection c, HttpPostedFileBase fileUpLoad)
        {
            try
            {
                tblThietBi sp = new tblThietBi();
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(c["txtName"]))
                    {
                        setAlert("Tên Sản Phẩm Không Được Để Trống", "warning");
                        return RedirectToAction("themSP");
                    }
                    sp.TenTB= c["txtName"];
                    if (string.IsNullOrEmpty(c["txtHH"]))
                    {
                        setAlert("Nhãn Hiệu Không Được Để Trống", "warning");
                        return RedirectToAction("themSP");
                    }
                    sp.NhanHieu = c["txtHH"];
                    if (string.IsNullOrEmpty(c["txtMoTa"]))
                    {
                        setAlert("Mô Tả Không Được Để Trống", "warning");
                        return RedirectToAction("themSP");
                    }
                    sp.ThongTinMoTa = c["txtMoTa"];
                    sp.MaLoai = int.Parse(c["LoaiThietBi"]);
                    sp.MaNCC = int.Parse(c["NhaCungCap"]);
                    sp.MaNhomTB = int.Parse(c["NhomThietBi"]);
                    //var fileName = "";
                    //if (fileUpLoad != null)
                    //{
                    //    fileName = Path.GetFileName(fileUpLoad.FileName);
                    //    var x = fileName;
                    //    int y = x.IndexOf(".");
                    //    var z = x.Substring(0,y);
                    //    fileName = x + "," + x + "," + x + "," + x + "," + x;
                    //    var path = Path.Combine(Server.MapPath("~/Content/hinh"), x);
                    //    fileUpLoad.SaveAs(path);
                    //}
                    sp.HinhAnhChung = "LGGRAM_1,LGGRAM_2,LGGRAM_3,LGGRAM_4,LGGRAM_5";

                    tx.tblThietBi.Add(sp);
                    tx.SaveChanges();

                    //add vo chi tiet
                    tblChiTietThietBi ct = new tblChiTietThietBi();
                    ct.MaTB = sp.MaTB;
                    ct.SoLuong = 0;
                    ct.GiaTien = 0;
                    if (string.IsNullOrEmpty(c["txtCPU"]))
                    {
                        setAlert("CPU Không Được Để Trống", "warning");
                        return RedirectToAction("themSP");
                    }
                    ct.CPU = c["txtCPU"];
                    if (string.IsNullOrEmpty(c["txtRAM"]))
                    {
                        setAlert("RAM Không Được Để Trống", "warning");
                        return RedirectToAction("themSP");
                    }
                    ct.RAM = c["txtRAM"];
                    if (string.IsNullOrEmpty(c["txtOCung"]))
                    {
                        setAlert("Ổ Cứng Không Được Để Trống", "warning");
                        return RedirectToAction("themSP");
                    }
                    ct.OCung = c["txtOCung"];
                    if (string.IsNullOrEmpty(c["txtManHinh"]))
                    {
                        setAlert("Màn Hình Không Được Để Trống", "warning");
                        return RedirectToAction("themSP");
                    }
                    ct.ManHinh = c["txtManHinh"];
                    if (string.IsNullOrEmpty(c["txtDoHoa"]))
                    {
                        setAlert("Đồ Họa Không Được Để Trống", "warning");
                        return RedirectToAction("themSP");
                    }
                    ct.DoHoa = c["txtDoHoa"];
                    if (string.IsNullOrEmpty(c["txtPin"]))
                    {
                        setAlert("Pin Không Được Để Trống", "warning");
                        return RedirectToAction("themSP");
                    }
                    ct.Pin = c["txtPin"];
                    ct.Khac = c["txtKhac"];
                    tx.tblChiTietThietBi.Add(ct);
                    tx.SaveChanges();
                }
                setAlert("Thêm Sản Phẩm Thành Công", "success");
                return RedirectToAction("sanpham");
            }
            catch
            {
                setAlert("Error", "error");
                return RedirectToAction("sanpham");
            }
        }
        public ActionResult suaSP(int msp)
        {
            tblThietBi sp = tx.tblThietBi.SingleOrDefault(n => n.MaTB == msp);
            if (sp == null)
            {
                setAlert("Không Thể Sửa Sản Phẩm Này", "warning");
                return RedirectToAction("hienthi");
            }
            ViewBag.LoaiThietBi = new SelectList(tx.tblLoaiThietBi.ToList(), "MaLoai", "TenLoai", sp.MaLoai);
            ViewBag.NhaCungCap = new SelectList(tx.tblNhaCungCap.ToList(), "MaNCC", "TenNCC", sp.MaNCC);
            ViewBag.NhomThietBi = new SelectList(tx.tblNhomTB.ToList(), "MaNhomTB", "TenNhom", sp.MaNhomTB);
            return View(sp);
        }
        [HttpPost]
        public ActionResult suaSP(int msp, FormCollection c, HttpPostedFileBase fileUpLoad)
        {
            try
            {
                tblThietBi sp = tx.tblThietBi.SingleOrDefault(n => n.MaTB == msp);
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(c["txtName"]))
                    {
                        setAlert("Tên Sản Phẩm Không Được Để Trống", "warning");
                        return RedirectToAction("suaSP", new { msp = msp });
                    }
                    sp.TenTB = c["txtName"];
                    if (string.IsNullOrEmpty(c["txtHH"]))
                    {
                        setAlert("Nhãn Hiệu Không Được Để Trống", "warning");
                        return RedirectToAction("suaSP", new { msp = msp });
                    }
                    sp.NhanHieu = c["txtHH"];
                    if (string.IsNullOrEmpty(c["txtmota"]))
                    {
                        setAlert("Mô Tả Không Được Để Trống", "warning");
                        return RedirectToAction("suaSP", new { msp = msp });
                    }
                    sp.ThongTinMoTa = c["txtmota"];
                    sp.MaLoai = int.Parse(c["LoaiThietBi"]);
                    sp.MaNCC = int.Parse(c["NhaCungCap"]);
                    sp.MaNhomTB = int.Parse(c["NhomThietBi"]);
                    tx.SaveChanges();
                }
                setAlert("Sửa Sản Phẩm Thành Công", "success");
                return RedirectToAction("sanpham");
            }
            catch
            {
                setAlert("Error", "error");
                return RedirectToAction("sanpham");
            }
        }
        public ActionResult nhapHang()
        {
            List<tblChiTietThietBi> lstLsp = tx.tblChiTietThietBi.ToList();
            return View(lstLsp);
        }
 
        public ActionResult nhapHang2(int maTB, int maCauHinh)
        {
            saveTemp s = new saveTemp(maTB,maCauHinh);
            ViewBag.NhaCungCap = new SelectList(tx.tblNhaCungCap.ToList(), "MaNCC", "TenNCC");
            return View();
        }
        [HttpPost]
        public ActionResult nhapHang2(FormCollection c, HttpPostedFileBase fileUpLoad)
        {
            try
            {
                saveTemp s = new saveTemp();
                int maTB = s.getMa1();
                int maCauHinh = s.getMa2();
                //phieu nhap
                int soLuong = int.Parse(c["sl"]);
                double donGia = double.Parse(c["gia"]);
                int ncc = int.Parse(c["NhaCungCap"]);
                tblPhieuNhapHang pn = new tblPhieuNhapHang();
                tblNhanVien tk = Session["dangnhap"] as tblNhanVien;
                if (tk != null)
                {
                    pn.MaNVNhanHang = tk.MaNV;
                }
                else
                    pn.MaNVNhanHang = 1;
                pn.MaNCC = ncc;
                pn.TongTien = (double)(soLuong * donGia);
                pn.NgayNhap = DateTime.Now;
                tx.tblPhieuNhapHang.Add(pn);
                tx.SaveChanges();
                //chi tiet
                tblChiTietPhieuNhap ct = new tblChiTietPhieuNhap();
                int maPn = pn.MaPhieuNH;
                ct.MaPhieuNH = maPn;
                ct.MaTB = maTB;
                ct.MaCauHinh = maCauHinh;
                ct.SoLuong = soLuong;
                ct.DonGia = (decimal)donGia;
                ct.ThanhTien = (decimal)(soLuong * donGia);
                tx.tblChiTietPhieuNhap.Add(ct);
                tx.SaveChanges();
                //update sl
                tblChiTietThietBi ctt = tx.tblChiTietThietBi.SingleOrDefault(n => n.MaTB == maTB && n.MaCauHinh == maCauHinh);
                ctt.SoLuong = ctt.SoLuong + soLuong;
                tx.SaveChanges();
                //thong bao
                setAlert("Nhập Sản Phẩm Thành Công", "success");
                return RedirectToAction("nhapHang");
            }
            catch (Exception ee)
            {
                setAlert("Error", "error");
                return RedirectToAction("nhaphang");
            }
        }

        public ActionResult XemChiTiet(int maTB, int maCauHinh)
        {
            if (maTB == null || maCauHinh == null)
                return HttpNotFound();
            tblChiTietThietBi ct = tx.tblChiTietThietBi.SingleOrDefault(n => n.MaTB == maTB && n.MaCauHinh == maCauHinh);
            return View(ct);
        }
        public ActionResult TTTK(string tk)
        {
            List<tblKhachHang> lst = tx.tblKhachHang.ToList();
            tblKhachHang t = lst.FirstOrDefault(n => n.TaiKhoan == tk);
            if (t != null)
            {
                if (t.tblTaiKhoan.TrangThai == true)
                    t.tblTaiKhoan.TrangThai = false;
                else
                    t.tblTaiKhoan.TrangThai = true;
                tx.SaveChanges();
            }
            setAlert("Cập Nhật Trạng Thái Thành Công", "success");
            return RedirectToAction("KH");
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
        //////////////////////////////////////////////////////

        Utils u = new Utils();
        public ActionResult thongke()
        {
            return View();
        }
        public ActionResult ThongKeThuongHieu()
        {
            List<ThongKeThuongHieu> lst = u.getThongKeNgay();
            return PartialView(lst);
        }
        public ActionResult ThongKeTheoThuongHieu()
        {
            List<ThongKeThuongHieu> lst = u.getThuongHieu();
            return PartialView(lst);
        }

        //public ActionResult DonHangGanDay()
        //{
        //    List<tblHoaDon> lst = u.getDonHangGanDay();
        //    return PartialView(lst);
        //}
        public ActionResult TrangThaiSanPham()
        {
            List<ThietBi> lst = u.getTrangThaiSanPham();
            return PartialView(lst);
        }

        public ActionResult ThanhToanHoaDon(int mahd, int option)
        {
            Utils u = new Utils();
            u.thanhToanHoaDon(mahd, option);
            return RedirectToAction("DonHang");
        }

        public ActionResult ThongKeMain()
        {
            Utils u = new Utils();
            List<String> lst = u.getThongKeMain();
            return PartialView(lst);
        }
        public ActionResult DonHang()
        {
            Utils u = new Utils();
            List<tblHoaDon> lst = u.getDonHangGanDay();
            return View(lst);
        }
    }
}
