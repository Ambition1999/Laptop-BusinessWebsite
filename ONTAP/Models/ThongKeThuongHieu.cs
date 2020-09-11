using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ONTAP.Models
{
    public class ThongKeThuongHieu
    {
        public string tenThuongHieu { get; set; }
        public int ngay { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }
        public double doanhThu { get; set; }
        public int luotDat { get; set; }
        public string tenThietBi { get; set; }
        
    }
}