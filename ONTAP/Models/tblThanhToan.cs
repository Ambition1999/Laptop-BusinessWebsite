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
    
    public partial class tblThanhToan
    {
        public int MaHD { get; set; }
        public int MaThanhToan { get; set; }
        public decimal SoTienThanhToan { get; set; }
        public System.DateTime NgayThanhToan { get; set; }
        public string PhuongThucThanhToan { get; set; }
    
        public virtual tblHoaDon tblHoaDon { get; set; }
    }
}
