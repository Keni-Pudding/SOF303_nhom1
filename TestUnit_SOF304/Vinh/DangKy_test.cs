using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_View.Controllers;
using CTN4_Serv.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CTN4_Serv.Service.Service;
using NUnit.Framework.Internal;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Net.Http;
using CTN4_Serv.ServiceJoin;
using Moq;
namespace TestUnit_SOF304.Vinh
{
    [TestFixture]
    public class DangkyTest
    {
        private HomeController _homeController;
        private Mock<ILogger<HomeController>> _mockLogger;
        private Mock<IConfiguration> _mockConfig;
        private Mock<ITokenService> _mockTokenService;
        private Mock<ILoginService> _mockLoginService;
        private Mock<ICurrentUser> _mockCurrentUser;
        private Mock<IKhachHangService> _mockKhachHangService;
        private Mock<ISanPhamService> _mockSanPhamService;
        private Mock<IHttpClientFactory> _mockHttpClientFactory;
        private Mock<IDiaChiNhanHangService> _mockDiaChiNhanHangService;
        private Mock<IGiamGiaService> _mockGiamGiaService;
        private Mock<IEmailService> _mockEmailService;
        private Mock<IGioHangService> _mockGioHangService;
        private KhachHangService _khachHangService;
        [SetUp]
        public void Setup()
        {
            // Khởi tạo các đối tượng Mock
            _mockLogger = new Mock<ILogger<HomeController>>();
            _mockConfig = new Mock<IConfiguration>();
            _mockTokenService = new Mock<ITokenService>();
            _mockLoginService = new Mock<ILoginService>();
            _mockCurrentUser = new Mock<ICurrentUser>();
            _mockKhachHangService = new Mock<IKhachHangService>();
            _mockSanPhamService = new Mock<ISanPhamService>();
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _mockDiaChiNhanHangService = new Mock<IDiaChiNhanHangService>();
            _mockGiamGiaService = new Mock<IGiamGiaService>();
            _mockEmailService = new Mock<IEmailService>();
            _mockGioHangService = new Mock<IGioHangService>();

            // Khởi tạo HomeController với các Mock đã tạo
            _homeController = new HomeController(
                _mockLogger.Object,
                _mockConfig.Object,
                _mockTokenService.Object,
                _mockLoginService.Object,
                _mockCurrentUser.Object,
                _mockKhachHangService.Object,
                _mockSanPhamService.Object,
                _mockHttpClientFactory.Object,
                _mockDiaChiNhanHangService.Object,
                _mockGiamGiaService.Object,
                _mockEmailService.Object,
                _mockGioHangService.Object
            );

            _khachHangService = new KhachHangService();
        }

        [Test, Order(1)]
        public void Dangky_Null()
        {
            // Arrange
            KhachHang nullKhachHang = new KhachHang
            {
                Ho = null,
                Ten = null,
                TenDangNhap = null,
                MatKhau = null,
                GioiTinh = null,
                Email = null,
                SDT = null,
                DiaChi = null,
                AnhDaiDien = null,
                // Các thuộc tính khác của KhachHang cũng được đặt là null
            };


            // Act
            bool result = _khachHangService.Them(nullKhachHang);

            // Assert
            Assert.IsFalse(result);
        }

        [Test, Order(2)]
        public void Dangky_AddTen()
        {
            // Arrange
            KhachHang nullKhachHang = new KhachHang
            {
                Ho = null,
                Ten = "Vinh",
                TenDangNhap = null,
                MatKhau = null,
                GioiTinh = null,
                Email = null,
                SDT = null,
                DiaChi = null,
                AnhDaiDien = null,
                // Các thuộc tính khác của KhachHang cũng được đặt là null
            };

            // Act
            bool result = _khachHangService.Them(nullKhachHang);

            // Assert
            Assert.IsFalse(result);
        }
        [Test, Order(3)]
        public void Dangky_All()
        {
            // Arrange
            KhachHang khachHang = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Vinh",
                TenDangNhap = "vinh236",
                MatKhau = "vinh123",
                GioiTinh = "Nam",
                Email = "ntvinh236@gmail.com",
                SDT = "0971717771",
                DiaChi = "Hà Nội",
            };

            // Act
            bool result = _khachHangService.Them(khachHang);

            // Assert
            Assert.IsFalse(result);
        }
        [Test, Order(4)]
        public void Dangky_All1()
        {
            // Arrange
            KhachHang khachHang = new KhachHang
            {
                Ho = "1",
                Ten = "1",
                TenDangNhap = "1",
                MatKhau = "1",
                GioiTinh = "1",
                Email = "1",
                SDT = "1",
                DiaChi = "1",
            };

            // Act
            bool result = _khachHangService.Them(khachHang);

            // Assert
            Assert.IsFalse(result);
        }
        [Test, Order(5)]
        public void Dangky_AddSDT_Char()
        {
            // Arrange
            KhachHang khachHang = new KhachHang
            {
                Ho = null,
                Ten = null,
                TenDangNhap = null,
                MatKhau = null,
                GioiTinh = null,
                Email = null,
                SDT = "123",
                DiaChi = null,
                AnhDaiDien = null,
            };

            // Act
            bool result = _khachHangService.Them(khachHang);

            // Assert
            Assert.IsFalse(result);
        }
        [Test, Order(6)]
        public void DangKy_NullHo()
        {
            // Arrange
            _homeController.ModelState.AddModelError("Ho", "Required"); // ModelState Invalid

            // Act
            var khachHang = new KhachHang();
            var result = _homeController.DangKys(khachHang) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("DangKy", result.ViewName);
        }
        [Test, Order(7)]
        public void DangKy_NullEmail()
        {
            // Arrange
            KhachHang khachHang = new KhachHang
            {
                Ho = "Nguyen",
                Ten = "Van A",
                TenDangNhap = "user123",
                MatKhau = "password",
                GioiTinh = "Nam",
                Email = "invalidemail", // Địa chỉ email không đúng định dạng
                SDT = "0123456789",
                DiaChi = "123 Street",
            };

            // Act
            var result = _homeController.DangKys(khachHang) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("DangKy", result.ViewName);
            Assert.IsNotNull(result.ViewData["Message"]);
            Assert.AreEqual("Định dạng email không hợp lệ", result.ViewData["Message"]);
        }
        [Test, Order(8)]
        public void DangKys_TenDangNhapDaSuDung_ReturnsViewResult()
        {

            // Arrange
            KhachHang khachHang = new KhachHang
            {
                Ho = "vinh",
                Ten = "Nguyễn",
                TenDangNhap = "1",
                MatKhau = "Bazagi89",
                GioiTinh = "Nam",
                Email = "Vinh@gmail.com",
                SDT = "0971717171",
                DiaChi = "Hà Nội",
                Trangthai = true,
                Is_detele = true,
            };
            var result = _homeController.DangKys(khachHang) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("DangKy", result.ViewName);

        }
        [Test, Order(9)]
        public void DangKys_SDTFails()
        {

            // Arrange
            KhachHang khachHang = new KhachHang
            {
                Ho = "vinh",
                Ten = "Nguyễn",
                TenDangNhap = "1",
                MatKhau = "Bazagi89",
                GioiTinh = "Nam",
                Email = "Vinh@gmail.com",
                SDT = "aa",
                DiaChi = "Hà Nội",
                Trangthai = true,
                Is_detele = true,
            };
            var result = _homeController.DangKys(khachHang) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("DangKy", result.ViewName);
            Assert.AreEqual("Số điện thoại không hợp lệ", result.ViewData["Message"]);

        }
        [Test, Order(10)]
        public void DangKys_100Char()
        {

            // Arrange
            KhachHang khachHang = new KhachHang
            {
                Ho = "0AbeUTnxg6bnMTsZNyf8DO2eyZ2lzPMecfAA8GTFIthzMyPSutjBD1RHQeeyAgg2pbE8jJhiyK2VEPtoIWY1VKCpl9VOtbKGdYkUaa",
                Ten = "Nguyễn",
                TenDangNhap = "1",
                MatKhau = "Bazagi89",
                GioiTinh = "Nam",
                Email = "Vinh@gmail.com",
                SDT = "0971717171",
                DiaChi = "Hà Nội",
                Trangthai = true,
                Is_detele = true,
            };
            var result = _homeController.DangKys(khachHang) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("DangKy", result.ViewName);
            Assert.AreEqual("Dữ liệu không được vượt quá 100 ký tự", result.ViewData["Message"]);

        }
      
    }
}

