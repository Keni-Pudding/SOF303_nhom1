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


    }
}
