using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_View_Admin.Controllers.QuanLY;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Size = CTN4_Data.Models.DB_CTN4.Size;

namespace TestUnit_SOF304
{
    [TestClass]
    public class SizeTest
    {
        Size _size;
        DB_CTN4_ok _dbcontext;
        SizeService _sizesv;

        public SizeTest()
        {
            _dbcontext = new DB_CTN4_ok();
            _sizesv = new SizeService();
            _size = new Size();
        }

        [Test]
        public void AS_01()
        {
            Size size = new Size() { Id = new Guid(), TenSize = "", CoSize = "", TrangThai = true, Is_detele = true };

            var result = _sizesv.Them(size);

            _size = _dbcontext.Sizes.Find(size.Id);
            Assert.AreEqual("", _size.TenSize);
            Assert.AreEqual("", _size.CoSize);
        }

        [Test]
        public void AS_02()
        {
            Size size = new Size() { Id = new Guid(), TenSize = "15cm x 9.5cm x 15cm", CoSize = "XLL", TrangThai = true, Is_detele = true };

            var result = _sizesv.Them(size);

            _size = _dbcontext.Sizes.Find(size.Id);
            Assert.AreEqual("15cm x 9.5cm x 15cm", _size.TenSize);
            Assert.AreEqual("XLL", _size.CoSize);
        }

        [Test]
        public void AS_03()
        {
            Size size = new Size() { Id = new Guid(), TenSize = "A", CoSize = "XL", TrangThai = true, Is_detele = true };

            var result = _sizesv.Them(size);

            Assert.IsFalse(result, "Không được thêm vào db khi sai định dạng tên");
        }

        [Test]
        public void AS_04()
        {
            Size size = new Size() { Id = new Guid(), TenSize = "15cm x 9.5cm x 7cm", CoSize = "S", TrangThai = true, Is_detele = true };

            var result = _sizesv.Them(size);

            Assert.IsFalse(result, "Không được thêm vào database khi Tên Size hoặc Cỡ size đã tồn tại");
        }

        [Test] 
        public void AS_05()
        {
            Size size = new Size() { Id = new Guid(), TenSize = new string('a', 30), CoSize = "XL", TrangThai = true, Is_detele = true };

            var result = _sizesv.Them(size);

            Assert.IsTrue(result);
        }

        [Test]
        public void AS_06()
        {
            Size size = new Size() { Id = new Guid(), TenSize = new string('a', 31), CoSize = "XL", TrangThai = true, Is_detele = true };

            var result = _sizesv.Them(size);

            Assert.IsFalse(result, "Không được thêm vào db khi Tên Size dài quá 30 ký tự");
        }

        [Test]
        public void AS_07()
        {
            Size size = new Size() { Id = new Guid(), TenSize = "15cm x 9.5cm x 8cm", CoSize = null, TrangThai = true, Is_detele = true };

            var result = _sizesv.Them(size);

            _size = _dbcontext.Sizes.Find(size.Id);
            Assert.IsFalse(result, "Không được thêm vào db khi Cỡ Size trống");
            /*Assert.AreEqual("15cm x 9.5cm x 8cm", _size.TenSize);
            Assert.AreEqual(null, _size.CoSize);*/
        }
        [Test]
        public void AS_08()
        {
            Size size = new Size() { Id = new Guid(), TenSize = "15cm x 9.5cm x 8cm", CoSize = "123123", TrangThai = true, Is_detele = true };

            var result = _sizesv.Them(size);

            _size = _dbcontext.Sizes.Find(size.Id);
            Assert.IsFalse(result, "Chỉ được nhập chữ");
        }

        [Test]
        public void AS_09()
        {
            Size size = new Size() { Id = new Guid(), TenSize = "15cm x 9.5cm x 7cm", CoSize = new string('S', 31), TrangThai = true, Is_detele = true };

            var result = _sizesv.Them(size);

            Assert.IsFalse(result, "Không được thêm vào db khi Cỡ Size dài quá 30 ký tự");
        }

        [Test]
        public void AS_10()
        {

        }

        [Test]
        public void AS_11()
        {
            Size size = new Size()
            {
                Id = new Guid(),
                TenSize = "@#$%",
                CoSize = "@#$%",
                TrangThai = true,
                Is_detele = true
            };

            var result = _sizesv.Them(size);

            Assert.IsFalse(result, "Chỉ được nhập chữ");
        }

        [TestMethod]
        [DataRow("56DD3EE2-C4DF-4376-B982-E2C0F7081149")]
        public void US_01(string idstring)
        {
            Guid id = new Guid(idstring);
            Size size = _dbcontext.Sizes.Find(id);

            if (size != null)
            {
                string newTenSize = "30cm x 21cm x 11cm";
                string newCoSize = "L";
                size.TenSize = newTenSize;
                size.CoSize = newCoSize;

                _sizesv.Sua(size);
                _size = _dbcontext.Sizes.Find(size.Id);

                Assert.AreEqual(newTenSize, _size.TenSize);
                Assert.AreEqual(newCoSize, _size.CoSize);
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }

        [TestMethod]
        [DataRow("56DD3EE2-C4DF-4376-B982-E2C0F7081149")]
        public void US_02(string idstring)
        {
            Guid id = new Guid(idstring);
            Size size = _dbcontext.Sizes.Find(id);

            if (size != null)
            {
                string newTenSize = "15cm x 9.5cm x 15cm";
                string newCoSize = "SL";
                bool newTrangThai = true;
                bool newIs_detele = true;
                size.TenSize = newTenSize;
                size.CoSize = newCoSize;
                size.TrangThai = newTrangThai;
                size.Is_detele = newIs_detele;

                _sizesv.Sua(size);
                _size = _dbcontext.Sizes.Find(size.Id);

                Assert.AreEqual(newTenSize, _size.TenSize);
                Assert.AreEqual(newCoSize, _size.CoSize);
                Assert.AreEqual(newTrangThai, _size.TrangThai);
                Assert.AreEqual(newIs_detele, _size.Is_detele);
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }

        [TestMethod]
        [DataRow("56DD3EE2-C4DF-4376-B982-E2C0F7081149")]
        public void US_03(string idstring)
        {
            Guid id = new Guid(idstring);
            Size size = _dbcontext.Sizes.Find(id);

            if (size != null)
            {
                string newTenSize = "15cm x 9.5cm x 15cm";
                string newCoSize = "SL";
                bool newTrangThai = false;
                bool newIs_detele = false;
                size.TenSize = newTenSize;
                size.CoSize = newCoSize;
                size.TrangThai = newTrangThai;
                size.Is_detele = newIs_detele;

                _sizesv.Sua(size);
                _size = _dbcontext.Sizes.Find(size.Id);

                Assert.AreEqual(newTenSize, _size.TenSize);
                Assert.AreEqual(newCoSize, _size.CoSize);
                Assert.AreEqual(newTrangThai, _size.TrangThai);
                Assert.AreEqual(newIs_detele, _size.Is_detele);
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }

        [TestMethod]
        [DataRow("56DD3EE2-C4DF-4376-B982-E2C0F7081149")]
        public void US_04(string idstring)
        {
            Guid id = new Guid(idstring);
            Size size = _dbcontext.Sizes.Find(id);

            if (size != null)
            {
                string newTenSize = "15cm x 9.5cm x 15cm";
                string newCoSize = null;
                bool newTrangThai = true;
                bool newIs_detele = true;
                size.TenSize = newTenSize;
                size.CoSize = newCoSize;
                size.TrangThai = newTrangThai;
                size.Is_detele = newIs_detele;

                var result = _sizesv.Sua(size);
                _size = _dbcontext.Sizes.Find(size.Id);

                Assert.IsFalse(result, "Không thêm được do trống trường Cỡ Size");
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }


        [TestMethod]
        [DataRow("56DD3EE2-C4DF-4376-B982-E2C0F7081149")]
        public void US_05(string idstring)
        {
            Guid id = new Guid(idstring);
            Size size = _dbcontext.Sizes.Find(id);

            if (size != null)
            {
                string newTenSize = null;
                string newCoSize = "S";
                bool newTrangThai = true;
                bool newIs_detele = true;
                size.TenSize = newTenSize;
                size.CoSize = newCoSize;
                size.TrangThai = newTrangThai;
                size.Is_detele = newIs_detele;

                var result = _sizesv.Sua(size);
                _size = _dbcontext.Sizes.Find(size.Id);

                Assert.IsFalse(result, "Không thêm được do trống trường Cỡ Size");
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }

        [TestMethod]
        [DataRow("56DD3EE2-C4DF-4376-B982-E2C0F7081149")]
        public void US_06(string idstring)
        {
            Guid id = new Guid(idstring);
            Size size = _dbcontext.Sizes.Find(id);

            if (size != null)
            {
                string newTenSize = "15cm x 9.5cm x 7cmx15cm x 9.5cm x 7cmx1";
                string newCoSize = "S";
                bool newTrangThai = true;
                bool newIs_detele = true;
                size.TenSize = newTenSize;
                size.CoSize = newCoSize;
                size.TrangThai = newTrangThai;
                size.Is_detele = newIs_detele;

                var result = _sizesv.Sua(size);
                _size = _dbcontext.Sizes.Find(size.Id);

                Assert.IsFalse(result, "Không được thêm dữ liệu khi quá 30 ký tự");
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }

        [TestMethod]
        [DataRow("56DD3EE2-C4DF-4376-B982-E2C0F7081149")]
        public void US_07(string idstring)
        {
            Guid id = new Guid(idstring);
            Size size = _dbcontext.Sizes.Find(id);

            if (size != null)
            {
                string newTenSize = "15cm x 9.5cm x 7cm";
                string newCoSize = "SSSSSSSSSSSSSSSSSSSSSSSSSSSS";
                bool newTrangThai = true;
                bool newIs_detele = true;
                size.TenSize = newTenSize;
                size.CoSize = newCoSize;
                size.TrangThai = newTrangThai;
                size.Is_detele = newIs_detele;

                var result = _sizesv.Sua(size);
                _size = _dbcontext.Sizes.Find(size.Id);

                Assert.IsTrue(result, "Không được thêm dữ liệu khi quá 30 ký tự");
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }

        [Test]
        public void GAS_01()
        {
            var sizeService = new SizeService();

            var actualSizes = sizeService.GetAll();

            Assert.IsNotNull(actualSizes);
            Assert.IsInstanceOfType<List<Size>>(actualSizes); //Kiểm tra xem actualSizes có nằm trong List<Size hay không. Nếu không ném ra Exception
        }

        [TestMethod]
        [DataRow("8181B4CE-517F-46F7-13E1-08DC30602A6D")]
        public void DS_01(string idstring)
        {
            Guid id = new Guid(idstring);
            Size size = _dbcontext.Sizes.Find(id);

            if (size != null)
            {
                var result = _sizesv.Xoa(id);

                Assert.IsTrue(result);
            }
            else
            {
                Assert.Fail("ID không tồn tại hoặc đã bị xóa");
            }
        }

        [Test]
        public void SS_01()
        {
            Guid IDnull = Guid.Empty;

            var result = _sizesv.GetById(IDnull);

            Assert.IsNull(result);
        }

        [Test]
        public void SS_02()
        {
            Guid id = Guid.Parse("4B92378D-06D7-452C-FAE6-08DC2460F570");

            var result = _sizesv.GetById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SS_03()
        {
            Guid id = Guid.Parse("1292378D-06D7-452C-FAE6-08DC2460F570");

            var result = _sizesv.GetById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SS_04()
        {
            Guid id = Guid.Parse("1292378D-06D7-452C-FAE6-08DC2460F570");

            var result = _sizesv.GetById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SS_05()
        {
            // Arrange
            string IDfail = "@#$%";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _sizesv.GetById(Guid.Parse(IDfail)));
        }
    }
}
