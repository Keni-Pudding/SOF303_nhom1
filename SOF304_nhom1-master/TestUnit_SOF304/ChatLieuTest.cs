using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestUnit_SOF304
{
    [TestClass]
    public class ChatLieuTest
    {
        ChatLieu _chatlieu;
        DB_CTN4_ok _dbcontext;
        ChatLieuService _chatlieusv;

        public ChatLieuTest()
        {
            _chatlieu = new ChatLieu();
            _dbcontext = new DB_CTN4_ok();
            _chatlieusv = new ChatLieuService();
        }

        [Test]
        public void ACl_01()
        {
            ChatLieu chatlieu = new ChatLieu() { Id = new Guid(), TenChatLieu = "", TrangThai = true, Is_detele = true };

            var result = _chatlieusv.Them(chatlieu);

            _chatlieu = _dbcontext.ChatLieus.Find(chatlieu.Id);
            Assert.AreEqual("", _chatlieu.TenChatLieu);
        }

        [Test]
        public void ACL_02()
        {
            ChatLieu chatlieu = new ChatLieu() { Id = new Guid(), TenChatLieu = "Da Báo", TrangThai = true, Is_detele = true };

            var result = _chatlieusv.Them(chatlieu);

            _chatlieu = _dbcontext.ChatLieus.Find(chatlieu.Id);
            Assert.AreEqual("Da Báo", _chatlieu.TenChatLieu);
        }

        [Test]
        public void ACl_03()
        {
            ChatLieu chatlieu = new ChatLieu() { Id = new Guid(), TenChatLieu = "123456789012345678901234567890", TrangThai = true, Is_detele = true };

            var result = _chatlieusv.Them(chatlieu);

            Assert.IsTrue(result);
        }
        [Test]
        public void ACl_04()
        {
            ChatLieu chatlieu = new ChatLieu() { Id = new Guid(), TenChatLieu = "Dadadadadadadadadadadaadadadadaaaad", TrangThai = true, Is_detele = true };

            var result = _chatlieusv.Them(chatlieu);

            Assert.IsFalse(result);
        }
        [Test]
        public void ACl_05()
        {
            ChatLieu chatlieu = new ChatLieu() { Id = new Guid(), TenChatLieu = "!@#$%^", TrangThai = true, Is_detele = true };

            var result = _chatlieusv.Them(chatlieu);

            Assert.IsFalse(result);
        }

        [Test]
        public void ACl_06()
        {
            ChatLieu chatlieu = new ChatLieu() { Id = new Guid(), TenChatLieu = new string('a', 100), TrangThai = true, Is_detele = true };

            var result = _chatlieusv.Them(chatlieu);

            Assert.IsFalse(result);
        }

        [Test]
        public void ACl_07()
        {
            ChatLieu chatlieu = new ChatLieu() { Id = new Guid(), TenChatLieu = "Dada", TrangThai = true, Is_detele = true };

            var result = _chatlieusv.Them(chatlieu);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("420FC0D1-12C3-44AC-A1C7-08DC3157C185")]
        public void UCL_01(string idstring)
        {
            Guid id = new Guid(idstring);
            ChatLieu chatlieu = _dbcontext.ChatLieus.Find(id);

            if (chatlieu != null)
            {
                string newTenChatLieu = "Da";
                chatlieu.TenChatLieu = newTenChatLieu;

                _chatlieusv.Sua(chatlieu);
                _chatlieu = _dbcontext.ChatLieus.Find(chatlieu.Id);

                Assert.AreEqual(newTenChatLieu, _chatlieu.TenChatLieu);
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }

        [TestMethod]
        [DataRow("420FC0D1-12C3-44AC-A1C7-08DC3157C185")]
        public void UCL_02(string idstring)
        {
            Guid id = new Guid(idstring);
            ChatLieu chatlieu = _dbcontext.ChatLieus.Find(id);

            if (chatlieu != null)
            {
                string newTenChatLieu = "Da báo";
                chatlieu.TenChatLieu = newTenChatLieu;

                var result = _chatlieusv.Sua(chatlieu);
                _chatlieu = _dbcontext.ChatLieus.Find(chatlieu.Id);

                Assert.IsFalse(result);
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }

        [TestMethod]
        [DataRow("420FC0D1-12C3-44AC-A1C7-08DC3157C185")]
        public void UCL_03(string idstring)
        {
            Guid id = new Guid(idstring);
            ChatLieu chatlieu = _dbcontext.ChatLieus.Find(id);

            if (chatlieu != null)
            {
                string newTenChatLieu = null;
                bool newTrangThai = false;
                bool newIs_delete = false;
                chatlieu.TenChatLieu = newTenChatLieu;

                var result = _chatlieusv.Sua(chatlieu);
                _chatlieu = _dbcontext.ChatLieus.Find(chatlieu.Id);

                Assert.IsFalse(result);
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }

        [TestMethod]
        [DataRow("420FC0D1-12C3-44AC-A1C7-08DC3157C185")]
        public void UCL_04(string idstring)
        {
            Guid id = new Guid(idstring);
            ChatLieu chatlieu = _dbcontext.ChatLieus.Find(id);

            if (chatlieu != null)
            {
                string newTenChatLieu = "Da Báo";
                string newGhiChu = "ok";
                bool newTrangThai = true;
                bool newIs_delete = true;

                chatlieu.TenChatLieu = newTenChatLieu;
                chatlieu.GhiChu = newGhiChu;
                chatlieu.TrangThai = newTrangThai;
                chatlieu.Is_detele = newIs_delete;

                var result = _chatlieusv.Sua(chatlieu);
                _chatlieu = _dbcontext.ChatLieus.Find(chatlieu.Id);

                Assert.IsTrue(result);
            }
            else
            {
                Assert.Fail("ID không tồn tại");
            }
        }

        [Test]
        public void GACL_01()
        {
            var clservice = new ChatLieuService();

            var actualcl = clservice.GetAll();

            Assert.IsNotNull(actualcl);
            Assert.IsInstanceOfType<List<ChatLieu>>(actualcl); //Kiểm tra xem actualSizes có nằm trong List<Size> hay không. Nếu không ném ra Exception
        }

        [TestMethod]
        [DataRow("99D20DCB-B01B-430F-CC94-08DC315803FF")]
        public void DECL_01(string idstring)
        {
            Guid id = new Guid(idstring);
            ChatLieu chatlieu = _dbcontext.ChatLieus.Find(id);

            if (chatlieu != null)
            {
                var result = _chatlieusv.Xoa(id);

                Assert.IsTrue(result);
            }
            else
            {
                Assert.Fail("ID không tồn tại hoặc đã bị xóa");
            }
        }

        [Test]
        public void SCL_01()
        {
            Guid IDnull = Guid.Empty;

            var result = _chatlieusv.GetById(IDnull);

            Assert.IsNull(result);
        }

        [Test]
        public void SS_02()
        {
            Guid id = Guid.Parse("B58665CA-E7E6-4B6A-9CBC-08DC315874CF");

            var result = _chatlieusv.GetById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void SS_03()
        {
            Guid id = Guid.Parse("A58665CA-E7E6-4B6A-9CBC-08DC315874CF");

            var result = _chatlieusv.GetById(id);

            Assert.IsNull(result);
        }

        [Test]
        public void SS_04()
        {
            Guid id = Guid.Parse("@#$%^&");

            var result = _chatlieusv.GetById(id);

            Assert.IsNull(result, "Guid không được chứa ký tự đặc biệt");
        }
    }
}
