using CTN4_Serv.ViewModel;
using CTN4_View_Admin.Controllers.QuanLY;
using Microsoft.AspNetCore.Mvc;

[TestFixture]
public class NhanVienControllerTests
{
    private NhanVienController _controller;

    [SetUp]
    public void SetUp()
    {
        _controller = new NhanVienController();
    }

    [Test]
    public void TestCase1()
    {
        var nhanVienInvalid = new NhanVienView
        {
        };

        // Gọi action Create với đối tượng Nhân viên không hợp lệ
        var result = _controller.Create(nhanVienInvalid, null) as ViewResult;

        // Kiểm tra xem action có trả về View không
        Assert.IsNotNull(result, "Phải trả về View vì đầu vào không hợp lệ");

        // Kiểm tra xem có thông báo lỗi hiển thị trên View không
        Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo lỗi hiển thị trên View");
    }
    [Test]
    public void TestCase2()
    {
        var nhanVienValidButEmpty = new NhanVienView
        {
            Ho = "1",
            Ten = "1",
            TenDangNhap = "1",
            MatKhau = "1",
            GioiTinh = "1",
            Email = "1",
            SDT = "1",
            DiaChi = "1",
            IdChucVu = Guid.NewGuid(), 
            Trangthai = true,
            AnhDaiDien = "1",
        };

        // Gọi action Create với đối tượng Nhân viên có dữ liệu hợp lệ nhưng bị trống
        var result = _controller.Create(nhanVienValidButEmpty, null) as ViewResult;

        // Kiểm tra xem action có trả về View không
        Assert.IsNotNull(result, "Phải trả về View vì đầu vào không hợp lệ");

        // Kiểm tra xem có thông báo lỗi hiển thị trên View không
        Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo lỗi hiển thị trên View");
    }
    [Test]
    public void TestCase3()
    {
        var nhanVienValid = new NhanVienView
        {
            Ho = "Nguyen",
            Ten = "Van Dai",
            TenDangNhap = "nvd",
            MatKhau = "123",
            GioiTinh = "Nam",
            Email = "nvd@gmail.com",
            SDT = "0867561898",
            DiaChi = "Hanoi",
            IdChucVu = Guid.NewGuid(),
            Trangthai = true,
            AnhDaiDien = "avatar.jpg",
        };

        // Gọi action Create với đối tượng Nhân viên có dữ liệu hợp lệ
        var result = _controller.Create(nhanVienValid, null) as RedirectToActionResult;

        // Kiểm tra xem action có chuyển hướng đến Index không
        Assert.IsNotNull(result, "Phải chuyển hướng đến action Index vì đầu vào hợp lệ");
        Assert.AreEqual("Index", result.ActionName, "Phải chuyển hướng đến action Index");
    }
    [Test]
    public void TestCase4()
    {
        // Giả sử có một nhân viên được chọn để xoá
        var nhanVienIdToDelete = Guid.NewGuid();

        // Gọi action Delete với đối tượng Nhân viên cần xoá
        var result = _controller.Delete(nhanVienIdToDelete) as RedirectToActionResult;

        // Kiểm tra xem action có chuyển hướng đến Index không
        Assert.IsNotNull(result, "Phải chuyển hướng đến action Index sau khi xoá thành công");
        Assert.AreEqual("Index", result.ActionName, "Phải chuyển hướng đến action Index sau khi xoá thành công");
    }
    [Test]
    public void TestCase5()
    {
        // Giả sử có một nhân viên cần sửa thông tin
        var nhanVienIdToEdit = Guid.NewGuid();

        // Giả sử thông tin mới cần cập nhật
        var newPhoneNumber = "987654321";

        // Tạo đối tượng Nhân viên mới với thông tin cần cập nhật
        var updatedNhanVien = new NhanVienView
        {
            Id = nhanVienIdToEdit,
            SDT = newPhoneNumber,
            // Các thông tin khác giữ nguyên hoặc thay đổi tùy theo yêu cầu
        };

        // Gọi action Edit với đối tượng Nhân viên cần sửa
        var result = _controller.Edit(updatedNhanVien, null, null) as RedirectToActionResult;

        // Assert: Kiểm tra xem action có chuyển hướng đến Index không
        Assert.IsNotNull(result, "Phải chuyển hướng đến action Index sau khi sửa thành công");
        Assert.AreEqual("Index", result.ActionName, "Phải chuyển hướng đến action Index sau khi sửa thành công");
    }
    [Test]
    public void TestCase6()
    {
        // Giả sử có một nhân viên cần sửa thông tin
        var nhanVienIdToEdit = Guid.NewGuid();

        // Tạo đối tượng Nhân viên mới với thông tin cần cập nhật
        var updatedNhanVien = new NhanVienView
        {
            Id = nhanVienIdToEdit,
            Ho = "Nguyen",
            Ten = null,
            TenDangNhap = "nvd",
            MatKhau = "123",
            GioiTinh = "Nam",
            Email = "nvd@gmail.com",
            SDT = "0867561898",
            DiaChi = "Hanoi",
            IdChucVu = Guid.NewGuid(),
            Trangthai = true,
            AnhDaiDien = "avatar.jpg",
        };

        // Gọi action Edit với đối tượng Nhân viên cần sửa
        var result = _controller.Edit(updatedNhanVien, null, null) as ViewResult;

        // Kiểm tra xem action có trả về View không
        Assert.IsNotNull(result, "Phải trả về View vì đầu vào không hợp lệ");

        // Kiểm tra xem có thông báo lỗi hiển thị trên View không
        Assert.IsNotNull(result.TempData["Notification"], "Phải có thông báo lỗi hiển thị trên View");
    }
    [Test]
    public void TestCase7()
    {
        var nhanVienIdToView = Guid.NewGuid();

        // Gọi action Details với đối tượng Nhân viên cần xem
        var result = _controller.Details(nhanVienIdToView) as ViewResult;

        // Kiểm tra xem action có trả về View không
        Assert.IsNotNull(result, "Phải trả về View để hiển thị thông tin nhân viên");

        // Kiểm tra xem Model truyền đến View có phải là đối tượng Nhân viên không
        Assert.IsInstanceOf<NhanVienView>(result.Model, "Model truyền đến View phải là đối tượng Nhân viên");

        // Kiểm tra xem View có tên là "Details" không
        Assert.AreEqual("Details", result.ViewName, "View phải có tên là 'Details'");

        // Kiểm tra xem thông tin của nhân viên trong Model có đúng không
        var modelData = result.Model as NhanVienView;
        Assert.IsNotNull(modelData, "Dữ liệu của Model không được null");
        Assert.AreEqual(nhanVienIdToView, modelData.Id, "ID của Nhân viên trong Model phải trùng với ID được chọn");
    }
}
