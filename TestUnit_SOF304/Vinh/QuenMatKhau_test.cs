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
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Data.DB_Context;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;
using MailKit.Security;
using MimeKit;
using System.Net.Mail;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;

namespace TestUnit_SOF304.Vinh
{
    [TestFixture]
    public class QuenMatKhauTest
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

        private Mock<IKhachHangService> _khachHangServiceMock;
        private Mock<IEmailService> _emailServiceMock;
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
            _khachHangServiceMock = new Mock<IKhachHangService>();
            _emailServiceMock = new Mock<IEmailService>();


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

        }
        [Test, Order(1)]
        public void QMK_ViewModel_matkhaucu()
        {

            var property = typeof(DoiMatKhauKh).GetProperty("matKhauCu");
            var attribute = Attribute.GetCustomAttribute(property, typeof(RequiredAttribute)) as RequiredAttribute;

            // Assert
            Assert.IsNotNull(attribute);
            Assert.AreEqual("Mật khẩu cũ là bắt buộc", attribute.ErrorMessage);
        }
        [Test, Order(2)]
        public void QMK_ViewModel_matkhaumoi()
        {

            var property = typeof(DoiMatKhauKh).GetProperty("MatKhauMoi");
            var attribute = Attribute.GetCustomAttribute(property, typeof(RequiredAttribute)) as RequiredAttribute;

            // Assert
            Assert.IsNotNull(attribute);
            Assert.AreEqual("Mật khẩu mới là bắt buộc", attribute.ErrorMessage);
        }
        [Test, Order(3)]
        public void QMK_ViewModel_matkhaumoi_MaxChar30()
        {

            var property = typeof(DoiMatKhauKh).GetProperty("MatKhauMoi");
            var attribute = Attribute.GetCustomAttribute(property, typeof(StringLengthAttribute)) as StringLengthAttribute;

            Assert.IsNotNull(attribute);
            Assert.AreEqual(30, attribute.MaximumLength);
        }
        [Test, Order(4)]
        public void QMK_ViewModel_xacNhanmk_RQ()
        {

            var property = typeof(DoiMatKhauKh).GetProperty("xacNhanMatKhauMoi");
            var attribute = Attribute.GetCustomAttribute(property, typeof(RequiredAttribute)) as RequiredAttribute;

            // Assert
            Assert.IsNotNull(attribute);
            Assert.AreEqual("Xác nhận mật khẩu mới không khớp", attribute.ErrorMessage);
        }
        [Test, Order(5)]
        public async Task QuenMks_KhongDeTrong()
        {
            // Arrange
            var mailRequest = new MailRequest
            {
                Tendangnhap = "",
                ToEmail = "",
                Subject = "",
                Body = "",
                attachmentPaths = new List<string> { "" }
            };
            var khachHangServiceMock = new Mock<IKhachHangService>();
            var emailServiceMock = new Mock<IEmailService>();
            var controller = new HomeController(
                Mock.Of<ILogger<HomeController>>(),
                Mock.Of<IConfiguration>(),
                Mock.Of<ITokenService>(),
                Mock.Of<ILoginService>(),
                Mock.Of<ICurrentUser>(),
                khachHangServiceMock.Object, // Sử dụng mock của IKhachHangService
                Mock.Of<ISanPhamService>(),
                Mock.Of<IHttpClientFactory>(),
                Mock.Of<IDiaChiNhanHangService>(),
                Mock.Of<IGiamGiaService>(),
                emailServiceMock.Object, // Sử dụng mock của IEmailService
                Mock.Of<IGioHangService>()
                );

            // Act
            var result = await controller.QuenMks(mailRequest) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equals("QuenMk", result.ViewName); // Assuming "QuenMk" is the name of the view returned
            Assert.Equals("Không được để trống", result.ViewData["Message"]);
        }
        [Test, Order(6)]
        public async Task QuenMks_KhongDungTKMK()
        {
            // Arrange
            var mailRequest = new MailRequest
            {
                Tendangnhap = "abc",
                ToEmail = "abc",
            };
            var khachHangServiceMock = new Mock<IKhachHangService>();
            var emailServiceMock = new Mock<IEmailService>();
            var controller = new HomeController(
                Mock.Of<ILogger<HomeController>>(),
                Mock.Of<IConfiguration>(),
                Mock.Of<ITokenService>(),
                Mock.Of<ILoginService>(),
                Mock.Of<ICurrentUser>(),
                khachHangServiceMock.Object, // Sử dụng mock của IKhachHangService
                Mock.Of<ISanPhamService>(),
                Mock.Of<IHttpClientFactory>(),
                Mock.Of<IDiaChiNhanHangService>(),
                Mock.Of<IGiamGiaService>(),
                emailServiceMock.Object, // Sử dụng mock của IEmailService
                Mock.Of<IGioHangService>()
                );

            // Act
            var result = await controller.QuenMks(mailRequest) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equals("QuenMk", result.ViewName); // Assuming "QuenMk" is the name of the view returned
            Assert.Equals("Tên đăng nhập hoặc email không đúng", result.ViewData["Message"]);
        }
        [Test, Order(7)]
        public async Task QuenMks_Char()
        {
            // Arrange
            var mailRequest = new MailRequest
            {
                Tendangnhap = "1",
                ToEmail = "1",
            };
            var khachHangServiceMock = new Mock<IKhachHangService>();
            var emailServiceMock = new Mock<IEmailService>();
            var controller = new HomeController(
                Mock.Of<ILogger<HomeController>>(),
                Mock.Of<IConfiguration>(),
                Mock.Of<ITokenService>(),
                Mock.Of<ILoginService>(),
                Mock.Of<ICurrentUser>(),
                khachHangServiceMock.Object, // Sử dụng mock của IKhachHangService
                Mock.Of<ISanPhamService>(),
                Mock.Of<IHttpClientFactory>(),
                Mock.Of<IDiaChiNhanHangService>(),
                Mock.Of<IGiamGiaService>(),
                emailServiceMock.Object, // Sử dụng mock của IEmailService
                Mock.Of<IGioHangService>()
                );

            // Act
            var result = await controller.QuenMks(mailRequest) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equals("QuenMk", result.ViewName); // Assuming "QuenMk" is the name of the view returned
            Assert.Equals("Tên đăng nhập hoặc email không đúng", result.ViewData["Message"]);
        }
        [Test, Order(8)]
        public async Task QuenMks_TenDangNhap()
        {
            // Arrange
            var userLogin = "abc";
            var mailRequest = new MailRequest
            {
                Tendangnhap = userLogin,
                ToEmail = "abc"
            };
            var khachHangServiceMock = new Mock<IKhachHangService>();
            var emailServiceMock = new Mock<IEmailService>();
            var expectedKhachHang = new KhachHang { TenDangNhap = userLogin, Email = "abc" };
            khachHangServiceMock.Setup(mock => mock.GetAll()).Returns(new List<KhachHang> { expectedKhachHang });
            var controller = new HomeController(
                Mock.Of<ILogger<HomeController>>(),
                Mock.Of<IConfiguration>(),
                Mock.Of<ITokenService>(),
                Mock.Of<ILoginService>(),
                Mock.Of<ICurrentUser>(),
                khachHangServiceMock.Object, // Sử dụng mock của IKhachHangService
                Mock.Of<ISanPhamService>(),
                Mock.Of<IHttpClientFactory>(),
                Mock.Of<IDiaChiNhanHangService>(),
                Mock.Of<IGiamGiaService>(),
                emailServiceMock.Object, // Sử dụng mock của IEmailService
                Mock.Of<IGioHangService>()
                );

            // Act
            await controller.QuenMks(mailRequest);

            // Assert
            khachHangServiceMock.Verify(mock => mock.GetAll(), Times.Once); // Đảm bảo phương thức GetAll() được gọi một lần
            khachHangServiceMock.Verify(mock => mock.GetAll().FirstOrDefault(c => c.TenDangNhap == userLogin), Times.Once); // Đảm bảo phương thức FirstOrDefault được gọi một lần với điều kiện TenDangNhap == expectedUsername
        }
        [Test, Order(9)]
        public async Task QuenMks_Email()
        {
            // Arrange
            var email = "abc";
            var mailRequest = new MailRequest
            {
                ToEmail = email,
          
            };
            var khachHangServiceMock = new Mock<IKhachHangService>();
            var emailServiceMock = new Mock<IEmailService>();
            var expectedKhachHang = new KhachHang { Email = email};
            khachHangServiceMock.Setup(mock => mock.GetAll()).Returns(new List<KhachHang> { expectedKhachHang });
            var controller = new HomeController(
                Mock.Of<ILogger<HomeController>>(),
                Mock.Of<IConfiguration>(),
                Mock.Of<ITokenService>(),
                Mock.Of<ILoginService>(),
                Mock.Of<ICurrentUser>(),
                khachHangServiceMock.Object, // Sử dụng mock của IKhachHangService
                Mock.Of<ISanPhamService>(),
                Mock.Of<IHttpClientFactory>(),
                Mock.Of<IDiaChiNhanHangService>(),
                Mock.Of<IGiamGiaService>(),
                emailServiceMock.Object, // Sử dụng mock của IEmailService
                Mock.Of<IGioHangService>()
                );

            // Act
            await controller.QuenMks(mailRequest);

            // Assert
            khachHangServiceMock.Verify(mock => mock.GetAll(), Times.Once); // Đảm bảo phương thức GetAll() được gọi một lần
            khachHangServiceMock.Verify(mock => mock.GetAll().FirstOrDefault(c => c.Email == email), Times.Once); // Đảm bảo phương thức FirstOrDefault được gọi một lần với điều kiện TenDangNhap == expectedUsername
        }


    }
}
