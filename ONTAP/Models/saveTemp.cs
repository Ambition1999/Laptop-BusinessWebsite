using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ONTAP.Models
{
    public class saveTemp
    {
        private static int ma2;
        private static int ma1;
        public saveTemp(int m, int n)
        {
            ma1 = m;
            ma2 = n;
        }
        public saveTemp()
        {
           
        }
        public void setMa1(int ma)
        {
            ma1 = ma;
        }
        public int getMa1()
        {
            return ma1;
        }
        public void setMa2(int ma)
        {
            ma2 = ma;
        }
        public int getMa2()
        {
            return ma2;
        }
    }
}