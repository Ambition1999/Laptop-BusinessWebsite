//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ONTAP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTaiKhoan
    {
        public tblTaiKhoan()
        {
            this.tblKhachHang = new HashSet<tblKhachHang>();
            this.tblNhanVien = new HashSet<tblNhanVien>();
        }
    
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public bool TrangThai { get; set; }
        public Nullable<System.DateTime> NgayDangKy { get; set; }
        public string LoaiTK { get; set; }
    
        public virtual ICollection<tblKhachHang> tblKhachHang { get; set; }
        public virtual ICollection<tblNhanVien> tblNhanVien { get; set; }
    }
}
