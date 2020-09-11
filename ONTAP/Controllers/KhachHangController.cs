using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ONTAP.Models;
namespace ONTAP.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /App/
        quanlybanlaptop2Entities db = new quanlybanlaptop2Entities();
        MaHoa_GiaiMa maHoa = new MaHoa_GiaiMa();

        public ActionResult DangNhap()
        {
            return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }

        public bool kiemTraTaiKhoanTonTai(String tenTK)
        {
            tblTaiKhoan tk = db.tblTaiKhoan.Where(t => t.TaiKhoan == tenTK).FirstOrDefault();
            if (tk != null)
                return true;
            return false;
        }


        [HttpPost]
        public ActionResult XuLyDangNhap(FormCollection c)
        {
            String userName = c["txtTenTK"].ToString();
            String passWord = c["txtMatKhau"].ToString();
            String matKhau_MH = maHoa.Encrypt(passWord);
            if (getTaiKhoan(userName) != "" && getTaiKhoan(userName) == userName)
            {

                tblTaiKhoan tk = db.tblTaiKhoan.FirstOrDefault(t => t.TaiKhoan == userName && t.MatKhau == matKhau_MH);
                if (tk != null)
                {
                    if (tk.TrangThai == true)
                    {
                        tblKhachHang kh = db.tblKhachHang.FirstOrDefault(t => t.TaiKhoan == tk.TaiKhoan);
                        tblNhanVien nv = db.tblNhanVien.FirstOrDefault(t => t.TaiKhoan == tk.TaiKhoan);
                        if (kh != null && tk.LoaiTK == "Khách hàng")
                        {
                            Session["dangnhap"] = kh;
                            return RedirectToAction("SanPham", "SanPham");
                        }
                        else if (nv != null && tk.LoaiTK == "admin")
                        {
                            Session["dangnhap"] = nv;
                            return RedirectToAction("index", "admin");
                        }
                        else
                        {
                            TempData["message"] = "";
                        }
                    }
                    else
                    {
                        TempData["message"] = "<script>alert('Tài khoản đang bị khóa, Vui lòng đăng nhập bằng tài khoản khác');</script>";
                    }
                }
                else
                {
                    TempData["message"] = "<script>alert('Tên đăng nhập hoặc mật khẩu không chính xác, Vui lòng kiểm tra lại');</script>";
                }
            }
            else
            {
                TempData["message"] = "<script>alert('Tên đăng nhập hoặc mật khẩu không chính xác, Vui lòng kiểm tra lại');</script>";
            }

            return RedirectToAction("DangNhap", "KhachHang");
        }

        public bool soSanhTuyetDoi(String strInputA, String strInputB)
        {
            if (strInputA.CompareTo(strInputB) == 0)
                return true;
            return false;
        }

        public string getTaiKhoan(string strInput)
        {
            tblTaiKhoan tk = db.tblTaiKhoan.Where(t => t.TaiKhoan.Equals(strInput) == true).FirstOrDefault();
            //tblTaiKhoan tk = from t in db.tblTaiKhoans where t.TaiKhoan.Equals(strInput) == true select t;
            if (tk != null)
                return tk.TaiKhoan;
            return "";
        }

        [HttpPost]
        public ActionResult XulyDangKy(FormCollection c, tblKhachHang kh, tblTaiKhoan tk)
        {
            var hoTen = c["txtHoTen"].Trim();
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", c["txtNgaySinh"]);
            var gioiTinh = c["txtGioiTinh"];
            var dienThoai = c["txtDienThoai"].Trim();
            var email = c["txtEmail"].Trim();
            var diaChi = c["txtDiaChi"].Trim();
            var taiKhoan = c["txtTenTK"].Trim();
            var matKhau = c["txtMatKhau"].Trim();
            var matKhauNhapLai = c["re_txtMatKhau"].Trim();

            if (!kiemTraTaiKhoanTonTai(taiKhoan))
            {
                try
                {
                    kh.TenKH = hoTen;
                    kh.NgaySinh = DateTime.Parse(ngaysinh);
                    kh.GioiTinh = gioiTinh;
                    kh.DienThoai = dienThoai;
                    kh.Email = email;
                    kh.DiaChi = diaChi;
                    kh.TaiKhoan = taiKhoan;

                    String matKhau_MH = maHoa.Encrypt(matKhau);
                    tk.TaiKhoan = taiKhoan;
                    tk.MatKhau = matKhau_MH;
                    tk.LoaiTK = "Khách hàng";
                    tk.TrangThai = true;
                    tk.NgayDangKy = Convert.ToDateTime(DateTime.Now.ToShortDateString());


                    db.tblKhachHang.Add(kh);
                    db.tblTaiKhoan.Add(tk);
                    db.SaveChanges();

                    TempData["message"] = "<script>alert('Đăng ký thành công');</script>";
                }
                catch (Exception ex)
                {
                    TempData["message"] = "<script>alert('Đăng ký không thành công, đã xảy ra lỗi trong quá trình add dữ liệu');</script>";
                }

            }
            else
            {
                TempData["message"] = "<script>alert('Tài khoản đã được sử dụng, vui lòng chọn tài khoản khác');</script>";
            }
            return RedirectToAction("DangKy", "KhachHang");
        }

        public ActionResult XuLyDangXuat()
        {
            Session["dangnhap"] = null;
            Session["cart"] = null;
            return RedirectToAction("SanPham", "SanPham");
        }
    }
}

