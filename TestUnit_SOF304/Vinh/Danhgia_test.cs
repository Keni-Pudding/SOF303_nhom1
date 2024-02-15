using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using CTN4_Serv.ViewModel;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models;


namespace TestUnit_SOF304.Vinh
{
    [TestFixture]
    public class DanhgiaTest
    {
        private DanhGiaSanPhamService _danhgia;
        [SetUp]
        public void Setup()
        {
            
            _danhgia = new DanhGiaSanPhamService();
        }

        [Test, Order(1)]
        public void Danhgia_SP()
        {
            // Arrange
            var danhgia = new DanhGiaSanPham
            {
                BinhLuan = "abc",
                SoSao = 1
            };

            // Act
            var result = _danhgia.Them(danhgia);

            // Assert
            Assert.IsTrue(result);
        }
        [Test, Order(2)]
        public void Danhgia_SP_abc()
        {
            // Arrange
            var danhgia = new DanhGiaSanPham
            {
                BinhLuan = "abc",
            };

            // Act
            var result = _danhgia.Them(danhgia);

            // Assert
            Assert.True(result);
        }
        [Test, Order(3)]
        public void Danhgia_SP_null()
        {
            // Arrange
            var danhgia = new DanhGiaSanPham
            {
                BinhLuan = null
            };

            // Act
            var result = _danhgia.Them(danhgia);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }
        [Test, Order(4)]
        public void Danhgia_SP_Delete()
        {
            // Arrange
            var id = new Guid("FA2D4E85-EE91-4B81-A5CE-F5942FD1D617");

            // Act
            var result = _danhgia.Xoa(id);

            // Assert
            Assert.True(result);
        }
        [Test, Order(5)]
        public void Danhgia_SP_DeleteNull()
        {
            // Arrange
            var id = new Guid();

            // Act
            var result = _danhgia.Xoa(id);

            // Assert
            Assert.False(result);
        }
        [Test, Order(6)]
        public void GetById_WhenItemExists_ShouldReturnCorrectItem()
        {
            // Arrange
            var Id = new Guid("FA2D4E85-EE91-4B81-A5CE-F5942FD1D617");
            var expectedItem = new DanhGiaSanPham { Id = Id };
            var items = new List<DanhGiaSanPham>
            {
                expectedItem, new DanhGiaSanPham { Id = Guid.NewGuid() },
            };
            

            // Act
            var actualItem = _danhgia.GetById(Id);

            // Assert
            Assert.AreEqual(expectedItem, actualItem);
        }

        [Test, Order(7)]
        public void GetById_Null()
        {
            // Arrange
            var id = Guid.NewGuid();
            var items = new List<DanhGiaSanPham>(); // Danh sách rỗng
            // Act
            var result = _danhgia.GetById(id);

            // Assert
            Assert.IsNull(result);
        }
        [Test, Order(8)]
        public void Danhgia_SP_suaTrue()
        {
            // Arrange
            var danhgia = new DanhGiaSanPham
            {
                BinhLuan = "Finish"
            };

            // Act
            var result = _danhgia.Sua(danhgia);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
        [Test, Order(8)]
        public void Danhgia_SP_suaFalse()
        {
            // Arrange
            var danhgia = new DanhGiaSanPham
            {
                
            };

            // Act
            var result = _danhgia.Sua(danhgia);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result);
        }
    }
}
