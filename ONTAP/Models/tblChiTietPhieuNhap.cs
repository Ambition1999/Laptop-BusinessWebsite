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
    
    public partial class tblChiTietPhieuNhap
    {
        public int MaPhieuNH { get; set; }
        public int MaTB { get; set; }
        public int MaCauHinh { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
    
        public virtual tblChiTietThietBi tblChiTietThietBi { get; set; }
        public virtual tblPhieuNhapHang tblPhieuNhapHang { get; set; }
    }
}
