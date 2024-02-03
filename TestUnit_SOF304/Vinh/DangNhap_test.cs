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

namespace TestUnit_SOF304.Vinh
{
    [TestFixture]
    public class DangnhapTest
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
        private LoginServices _loginService;
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
            _loginService = new LoginServices();
        }
        [Test,Order(1)]
        public void DangNhap_NV_True()
        {
            // Arrange
            var validLogin = new LoginAdmin
            {
                User = "trangnt34",
                Password = "12345678"
            };

            // Act
            var result = _loginService.GetUserNV(validLogin);

            // Assert
            Assert.IsNotNull(result);
            
        }
        [Test, Order(2)]
        public void DangNhap_NV_Null()
        {
            // Arrange
            var validLogin = new LoginAdmin
            {
                User = "",
                Password = ""
            };

            // Act
            var result = _loginService.GetUserNV(validLogin);

            // Assert
            Assert.IsNull(result);
            // Kiểm tra xem kết quả có phải là một người dùng hợp lệ đã đăng nhập hay không
            // Có thể kiểm tra các thuộc tính khác của người dùng nếu cần
            // Ví dụ: Assert.AreEqual("expectedValue", result.Property);
        }
        [Test, Order(3)]
        public void DangNhap_KH_True()
        {
            // Arrange
            var validLogin = new Loginviewmodel
            {
                User = "vinh2306",
                Password = "Bazagi89"
            };

            // Act
            var result = _loginService.GetUserKH(validLogin);

            // Assert
            Assert.IsNotNull(result);
            // Kiểm tra xem kết quả có phải là một người dùng hợp lệ đã đăng nhập hay không
            // Có thể kiểm tra các thuộc tính khác của người dùng nếu cần
            // Ví dụ: Assert.AreEqual("expectedValue", result.Property);
        }
        [Test,Order(4)]
        public void DangNhap_KH_False()
        {
            // Arrange
            var validLogin = new Loginviewmodel
            {
                User = "",
                Password = ""
            };

            // Act
            var result = _loginService.GetUserKH(validLogin);

            // Assert
            Assert.IsNull(result);
            // Kiểm tra xem kết quả có phải là một người dùng hợp lệ đã đăng nhập hay không
            // Có thể kiểm tra các thuộc tính khác của người dùng nếu cần
            // Ví dụ: Assert.AreEqual("expectedValue", result.Property);
        }
       
        [Test, Order(5)]
        public void Dangnhap_KH_UserNull()
        {
            // Arrange
            var invalidModel = new Loginviewmodel();
            _homeController.ModelState.AddModelError("User", "Vui lòng nhập tên đăng nhập.");

            // Act
            var result = _homeController.Login(invalidModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData["Message"]); // Kiểm tra xem ViewBag.Message có giá trị hay không
            Assert.AreEqual("Vui lòng nhập đúng đầu vào.", result.ViewData["Message"]);
        }
        [Test, Order(6)]
        public void Dangnhap_KH_PasswordNull()
        {
            // Arrange
            var invalidModel = new Loginviewmodel();
            _homeController.ModelState.AddModelError("Pass", "Vui lòng nhập mật khẩu.");

            // Act
            var result = _homeController.Login(invalidModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData["Message"]); // Kiểm tra xem ViewBag.Message có giá trị hay không
            Assert.AreEqual("Vui lòng nhập đúng đầu vào.", result.ViewData["Message"]);
        }
        [Test, Order(7)]
        public void Dangnhap_returnLogin()
        {
            // Arrange
            var validModel = new Loginviewmodel
            {
               
            };

            // Act
            var result = _homeController.Login(validModel) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Login", result.ActionName);
        }
        [Test,Order(8)]
        public void Dangnhap_returnViewLogin()
        {
            // Arrange
            var invalidModel = new Loginviewmodel
            {
                User = "invalidUser",
                Password = "invalidPassword"
            };
            _homeController.ModelState.AddModelError("User", "Invalid username or password"); // Simulate invalid ModelState

            // Act
            var result = _homeController.Login(invalidModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData["Message"]);
            Assert.AreEqual("Vui lòng nhập đúng đầu vào.", result.ViewData["Message"]);
            Assert.AreEqual(null, result.ViewName);
        }
        [Test,Order(9)]
        public void DangNhap_User_Char()
        {
            var property = typeof(LoginAdmin).GetProperty("User");
            var attribute = Attribute.GetCustomAttribute(property, typeof(RegularExpressionAttribute)) as RegularExpressionAttribute;

            Assert.IsNotNull(attribute);
            Assert.AreEqual("^[a-zA-Z0-9]{8,31}$", attribute.Pattern);
        }
        [Test,Order(10)]
        public void DangNhap_Password_Char()
        {
            var property = typeof(LoginAdmin).GetProperty("Password");
            var attribute = Attribute.GetCustomAttribute(property, typeof(RegularExpressionAttribute)) as RegularExpressionAttribute;

            Assert.IsNotNull(attribute);
            Assert.AreEqual("^[a-zA-Z0-9]{8,31}$", attribute.Pattern);
        }
        [Test, Order(11)]
        public void DangNhap_NV_Username_required()
        {
           
            var property = typeof(LoginAdmin).GetProperty("User");
            var attribute = Attribute.GetCustomAttribute(property, typeof(RequiredAttribute)) as RequiredAttribute;

            // Assert
            Assert.IsNotNull(attribute);
            Assert.AreEqual("Username is required", attribute.ErrorMessage);
        }
        [Test, Order(12)]
        public void DangNhap_NV_Password_required()
        {

            var property = typeof(LoginAdmin).GetProperty("Password");
            var attribute = Attribute.GetCustomAttribute(property, typeof(RequiredAttribute)) as RequiredAttribute;

            // Assert
            Assert.IsNotNull(attribute);
            Assert.AreEqual("Tên đăng nhập không được bỏ trống", attribute.ErrorMessage);
        }


    }
}
