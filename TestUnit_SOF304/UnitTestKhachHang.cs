using CTN4_Data.Models.DB_CTN4;
using CTN4_View_Admin.Controllers.QuanLY;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;

namespace TestUnit_SOF304
{
    public class KhachHangControllerTests
    {
        private KhachHangController _controller;
        private IKhachHangService _kh;
        [SetUp]
        public void SetUp()
        {
            _controller = new KhachHangController();
            _kh = new KhachHangService();
        }

        [Test]
        public void Test1()
        {
            var khachHangInvalid = new KhachHang
            {
            };

            // Act: Gọi action Create với đối tượng Khách hàng không hợp lệ
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View vì đầu vào không hợp lệ");

            // Kiểm tra xem có thông báo lỗi hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo lỗi hiển thị trên View");
        }
        [Test]
        public void Test2()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "1",
                Ten = "1",
                TenDangNhap = "1",
                MatKhau = "1",
                GioiTinh = "1",
                Email = "1",
                SDT = "1",
                DiaChi = "1",
                AnhDaiDien = "1",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng không hợp lệ
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test3()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "1",
                Ten = "Manh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "acb@gamil.com",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test4()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "@#$",
                Ten = "Manh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "acb@gamil.com",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test5()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "Phạm",
                Ten = "1",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "acb@gamil.com",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test6()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "@#$",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "acb@gamil.com",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test7()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "1234655463",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test8()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "aaaaaaaaaaaaaa",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test9()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@gmail.cm",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test10()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@gmil.com",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test11()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@gl.co",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData ["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test12()
        {
            var khachHangValid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@gmail.com",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng KhachHang hợp lệ
            var result = _controller.Create(khachHangValid, null) as RedirectToActionResult;

            // Assert: Kiểm tra xem action có trả về Redirect không
            Assert.IsNotNull(result, "Phải trả về Redirect vì đầu vào hợp lệ");

            // Kiểm tra xem có TempData được set không
            var tempData = _controller.TempData["Notification"] as string;
            Assert.IsNull(tempData, "Không được có thông báo lỗi khi dữ liệu đầu vào hợp lệ");
        }
        [Test]
        public void Test13()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@gmail.com",
                SDT = "abcsdsdd",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test14()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@gmail.com",
                SDT = "1111111111",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test15()
        {
            var khachHangValid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@fpt.vn",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };


            // Act: Gọi action Create với đối tượng KhachHang hợp lệ
            var result = _controller.Create(khachHangValid, null) as RedirectToActionResult;

            // Assert: Kiểm tra xem action có trả về Redirect không
            Assert.IsNotNull(result, "Phải trả về Redirect vì đầu vào hợp lệ");

            // Kiểm tra xem có TempData được set không
            var tempData = _controller.TempData["Notification"] as string;
            Assert.IsNull(tempData, "Không được có thông báo lỗi khi dữ liệu đầu vào hợp lệ");
        } 
        [Test]
        public void Test16()
        {
            var khachHangInvalid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@fptpl.vn",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có họ là số
            var result = _controller.Create(khachHangInvalid, null) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View với dữ liệu không hợp lệ");

            // Kiểm tra xem có thông báo validate hiển thị trên View không
            Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo validate hiển thị trên View");
        }
        [Test]
        public void Test17()
        {
            // Chuẩn bị một file ảnh có dung lượng dưới 20MB
            var imageStream = new MemoryStream();
            // Simulate an image file with size less than 20MB
            using (var image = new Bitmap(500, 500))
            {
                image.Save(imageStream, ImageFormat.Jpeg);
            }
            var imageFile = new FormFile(imageStream, 0, imageStream.Length, "validImage", "validImage.jpg");

            var khachHangValid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@fptpl.vn",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có ảnh dung lượng dưới 20MB
            var result = _controller.Create(khachHangValid, imageFile) as RedirectToActionResult;

            // Assert: Kiểm tra xem action có chuyển hướng thành công không
            Assert.IsNotNull(result, "Phải chuyển hướng thành công sau khi thêm thông tin khách hàng");

            // Kiểm tra xem action đã chuyển hướng đến Index không
            Assert.AreEqual("Index", result.ActionName, "Phải chuyển hướng đến action Index sau khi thêm thông tin khách hàng");
        }

        [Test]
        public void Test18()
        {
            // Chuẩn bị một file ảnh có dung lượng lớn hơn 20MB
            var largeImageStream = new MemoryStream();
            // Simulate an image file with size greater than 20MB
            using (var largeImage = new Bitmap(5000, 5000))
            {
                largeImage.Save(largeImageStream, ImageFormat.Jpeg);
            }
            var largeImageFile = new FormFile(largeImageStream, 0, largeImageStream.Length, "largeImage", "largeImage.jpg");

            var khachHangValid = new KhachHang
            {
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@fptpl.vn",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Create với đối tượng Khách hàng có ảnh dung lượng lớn hơn 20MB
            var result = _controller.Create(khachHangValid, largeImageFile) as RedirectToActionResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View vì ảnh có dung lượng lớn hơn 20MB");

            // Kiểm tra xem có thông báo lỗi hiển thị trên View không
            var tempData = _controller.TempData["Notification"] as string;
            Assert.IsNotNull(tempData, "Phải có thông báo lỗi hiển thị trên View vì ảnh có dung lượng lớn hơn 20MB");
        }
        [Test]
        public void Test19()
        {
            // Arrange: Tạo một đối tượng KhachHang để xem thông tin
            var khachHangToView = new KhachHang
            {
                Id = Guid.NewGuid(),
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@fptpl.vn",
                SDT = "0867561898",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Act: Gọi action Details với đối tượng KhachHang cần xem thông tin
            var result = _controller.Details(khachHangToView.Id) as ViewResult;

            // Assert: Kiểm tra xem action có trả về View không
            Assert.IsNotNull(result, "Phải trả về View khi xem thông tin khách hàng");

            // Kiểm tra xem đối tượng được truyền đến View có phải là khachHangToView không
            var khachHangInView = result.Model as KhachHang;
            Assert.IsNotNull(khachHangInView, "Không tìm thấy thông tin của khách hàng");
            Assert.AreEqual(khachHangToView.Id, khachHangInView.Id, "Thông tin khách hàng trả về không chính xác");
        }
        [Test]
        public void Test20()
        {
            // Arrange: Tạo một đối tượng KhachHang để sửa thông tin
            var khachHangToEdit = new KhachHang
            {
                Id = Guid.NewGuid(),
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@fptpl.vn",
                SDT = "123456789",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Lưu khách hàng vào cơ sở dữ liệu để lấy Id
            _kh.Them(khachHangToEdit);

            // Mô phỏng việc chỉnh sửa số điện thoại
            var newPhoneNumber = "123456789";
            khachHangToEdit.SDT = newPhoneNumber;

            // Act: Gọi action Edit với đối tượng KhachHang đã chỉnh sửa
            var result = _controller.Edit(khachHangToEdit, null, null) as RedirectToActionResult;

            // Assert: Kiểm tra xem action có chuyển hướng về trang danh sách không
            Assert.IsNotNull(result, "Phải chuyển hướng về trang danh sách sau khi sửa thông tin khách hàng");

            // Kiểm tra xem số điện thoại đã được cập nhật thành công trong cơ sở dữ liệu hay không
            var khachHangUpdated = _kh.GetById(khachHangToEdit.Id);
            Assert.AreEqual(newPhoneNumber, khachHangUpdated.SDT, "Số điện thoại không được cập nhật thành công");
        } 
        [Test]
        public void Test21()
        {
            // Arrange: Tạo một đối tượng KhachHang để sửa thông tin
            var khachHangToEdit = new KhachHang
            {
                Id = Guid.NewGuid(),
                Ho = "Nguyễn",
                Ten = "Mạnh",
                TenDangNhap = "abc123",
                MatKhau = "12345678",
                GioiTinh = "Nam",
                Email = "abc@fptpl.vn",
                SDT = "123456789",
                DiaChi = "Hanoi",
                AnhDaiDien = "abc.png",
                Trangthai = true,
                Is_detele = true
            };

            // Lưu khách hàng vào cơ sở dữ liệu để lấy Id
            _kh.Them(khachHangToEdit);

            // Act: Gọi action Edit với đối tượng KhachHang không có thay đổi
            var result = _controller.Edit(khachHangToEdit, null, null) as RedirectToActionResult;

            // Assert: Kiểm tra xem action có chuyển hướng về trang danh sách không
            Assert.IsNotNull(result, "Phải chuyển hướng về trang danh sách sau khi sửa thông tin khách hàng");
        }

    }
}