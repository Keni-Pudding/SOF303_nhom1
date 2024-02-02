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
            Size size = new Size() { Id = new Guid(), TenSize = new string('a',30), CoSize = "XL", TrangThai = true, Is_detele = true };

           var result =_sizesv.Them(size);
           
            Assert.IsTrue(result);
        }

        [Test]
        public void AS_06()
        {
            Size size = new Size() { Id = new Guid(), TenSize = new string('a', 31), CoSize = "XL", TrangThai = true, Is_detele = true };

            var result = _sizesv.Them(size);

            Assert.IsFalse(result, "Không được thêm vào db khi Tên Size dài quá 30 ký tự");
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
    }
}
