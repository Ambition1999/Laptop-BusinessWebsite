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
    
    public partial class tblChiTietThietBi
    {
        public tblChiTietThietBi()
        {
            this.tblChiTietHD = new HashSet<tblChiTietHD>();
            this.tblChiTietPhieuNhap = new HashSet<tblChiTietPhieuNhap>();
            this.tblChiTietPhieuXuat = new HashSet<tblChiTietPhieuXuat>();
        }
    
        public int MaTB { get; set; }
        public int MaCauHinh { get; set; }
        public int SoLuong { get; set; }
        public double GiaTien { get; set; }
        public bool TrangThai { get; set; }
        public string HinhAnhThem { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string OCung { get; set; }
        public string ManHinh { get; set; }
        public string DoHoa { get; set; }
        public string Pin { get; set; }
        public string Khac { get; set; }
    
        public virtual ICollection<tblChiTietHD> tblChiTietHD { get; set; }
        public virtual ICollection<tblChiTietPhieuNhap> tblChiTietPhieuNhap { get; set; }
        public virtual ICollection<tblChiTietPhieuXuat> tblChiTietPhieuXuat { get; set; }
        public virtual tblThietBi tblThietBi { get; set; }
    }
}
