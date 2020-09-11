using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONTAP.Models;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { set; get; }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
           "|DataDirectory|\\XMLFile2.xml", "add", DataAccessMethod.Sequential)]
        public void TestMethodTaiKhoan()
        {
            string first = this.TestContext.DataRow["first"].ToString();
            User u = new User();
            Assert.AreEqual(true, u.kiemTraNhapDungTaiKhoan(first.ToString()));
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
           "|DataDirectory|\\XMLFile3.xml", "add", DataAccessMethod.Sequential)]
        public void TestMethodMatKhau()
        {
            string first = this.TestContext.DataRow["first"].ToString();
            User u = new User();
            Assert.AreEqual(true, u.kieTraNhapDungMatKhau(first));
        }
        [TestMethod]
        public void TestMethodKhongDeTrongDiaChi()
        {
            User u = new User();
            Assert.AreEqual(true, u.kiemTraKhongDuocDeTrong("f"));
        }
        [TestMethod]
        public void TestMethodKhongDeTrongHoTen()
        {
            User u = new User();
            Assert.AreEqual(true, u.kiemTraKhongDuocDeTrong("f"));
        }
        [TestMethod]
        public void TestMethodQua100kiTu()
        {
            User u = new User();
            Assert.AreEqual(true, u.kiemTraQua100("f"));
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
           "|DataDirectory|\\XMLFile4.xml", "add", DataAccessMethod.Sequential)]
        public void TestMethodEmail()
        {
            string first = this.TestContext.DataRow["first"].ToString();
            User u = new User();
            Assert.AreEqual(true, u.kiemTraEmail(first));
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
           "|DataDirectory|\\XMLFile5.xml", "add", DataAccessMethod.Sequential)]
        public void TestMethodSDT()
        {
            string first = this.TestContext.DataRow["first"].ToString();
            User u = new User();
            Assert.AreEqual(true, u.kiemTraSDT(first));
        }
        [TestMethod]
        public void TestMethodNgaySinh()
        {
            User u = new User();
            Assert.AreEqual(true, u.kiemTraNgaySinh("27/12/2019"));
        }
    }
}
