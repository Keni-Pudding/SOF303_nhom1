using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.ViewModel;
using CTN4_View_Admin.Controllers.QuanLY;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Vml;
using Microsoft.AspNetCore.Http;
using Moq;

namespace TestUnit_SOF304.TestQuanLySP
{
	[TestFixture]
	internal class TestQLSP
	{
		private SanPhamView sanpham;
		private SanPhamController sanPhamController = new SanPhamController();
		[SetUp]
		public void Setup()
		{
			sanpham = new SanPhamView();


		}


		
		[Test]
		public void NXS_shouldnotbenull()
		{
			Assert.IsNotNull(sanpham.NsxItems);

		}
		[Test]
		public void SanPhams_shouldnotbenull()
		{
			Assert.IsNotNull(sanpham.sanPhams);

		}
		[Test]
		public void SanPham_ShouldNotBeNull()
		{
			Assert.IsNotNull(sanpham.sanPham);
		}


		// Ma san pham khong qua 30 ky tu
		[Test]
		public void MaSp_ShouldHaveStringLengthAttribute()
		{
			var property = typeof(SanPhamView).GetProperty("MaSp");
			var attribute = Attribute.GetCustomAttribute(property, typeof(StringLengthAttribute)) as StringLengthAttribute;

			Assert.IsNotNull(attribute);
			Assert.AreEqual(30, attribute.MaximumLength);
		}


		// de trong tat ca cac truong
		[Test]
		public void TestAddProduct_AllNull()
		{
			var fileMock = new Mock<IFormFile>(); // Thay IFormFile bằng interface tương ứng
			fileMock.Setup(f => f.FileName).Returns("test.jpg");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;

			var sp = new SanPhamView()
			{

				Id = Guid.NewGuid(),
				MaSp = "",
				TenSanPham = "",
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "",
				TrangThai = true,
				GiaNhap = 10,
				GiaBan = 10,
				GiaNiemYet = 10,
				GhiChu = "",
				Is_detele = true,
				AnhDaiDien = "dàgiuhsdakbnkjsxncoiashcw",

			};
			bool result = sanPhamController.Create(sp, image);
			Assert.IsFalse(result);
		}



		//ten san pham khong duoc qua 50 ky tu
		[Test]
		public void TenSP_ShouldHaveStringLengthAttribute()
		{

			var property = typeof(SanPhamView).GetProperty("TenSanPham");
			var attribute = Attribute.GetCustomAttribute(property, typeof(StringLengthAttribute)) as StringLengthAttribute;

			Assert.IsNotNull(attribute);
			Assert.AreEqual(50, attribute.MaximumLength);
		}


		// Ten san pham phai la string
		[Test]
		public void TenSP_ShouldHaveString()
		{
			var fileMock = new Mock<IFormFile>();
			fileMock.Setup(f => f.FileName).Returns("test.jpg");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;
			var sp = new SanPhamView()
			{

				Id = Guid.NewGuid(),
				MaSp = "dfsgdfg",
				TenSanPham = ".';ư;ư.'.ưƠ}!@#$%^&",
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "joen",
				TrangThai = true,
				GiaNhap = 10,
				GiaBan = 15,
				GiaNiemYet = 20,
				GhiChu = "note",
				Is_detele = true,
				AnhDaiDien = "dàgiuhsdakbnkjsxncoiashcw",

			};
			bool result = sanPhamController.Create(sp, image);
			Assert.IsFalse(result);
		}

		// khong de trong gia nhap
		[Test]

		public void GiaNhap_ShouldHaveRequiredAttribute()
		{
			// Arrange
			var propertyName = "GiaNhap";

			// Act
			var propertyInfo = typeof(SanPhamView).GetProperty(propertyName);
			var requiredAttribute = (RequiredAttribute)propertyInfo.GetCustomAttribute(typeof(RequiredAttribute));

			// Assert
			Assert.NotNull(requiredAttribute);
			Assert.AreEqual("Giá nhập vào không được bỏ trống.", requiredAttribute.ErrorMessage);
		}

		// Gia nhap trong khoang cho phep
		[Test]
		public void GiaNhap_ShouldHaveRangeAttribute()
		{
			// Arrange
			var propertyName = "GiaNhap";

			// Act
			var propertyInfo = typeof(SanPhamView).GetProperty(propertyName);
			var rangeAttribute = (System.ComponentModel.DataAnnotations.RangeAttribute)propertyInfo.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

			// Assert
			Assert.NotNull(rangeAttribute);
			Assert.AreEqual(0, rangeAttribute.Minimum);
			Assert.AreEqual(float.MaxValue, rangeAttribute.Maximum);
			Assert.AreEqual("Giá nhập vào phải lớn hơn hoặc bằng 0.", rangeAttribute.ErrorMessage);
		}

		// gia nhap phai la so nguyen
		[Test]
		public void GiaNhap_ShouldHaveRegularExpressionAttribute()
		{
			// Arrange
			var propertyName = "GiaNhap";

			// Act
			var propertyInfo = typeof(SanPhamView).GetProperty(propertyName);
			var regexAttribute = (RegularExpressionAttribute)propertyInfo.GetCustomAttribute(typeof(RegularExpressionAttribute));

			// Assert
			Assert.NotNull(regexAttribute);
			Assert.AreEqual("^[0-9]+$", regexAttribute.Pattern);
			Assert.AreEqual("Vui lòng nhập số nguyên.", regexAttribute.ErrorMessage);
		}

		// khong de trong gia ban
		[Test]

		public void GiaBan_ShouldHaveRequiredAttribute()
		{
			// Arrange
			var propertyName = "GiaBan";

			// Act
			var propertyInfo = typeof(SanPhamView).GetProperty(propertyName);
			var requiredAttribute = (RequiredAttribute)propertyInfo.GetCustomAttribute(typeof(RequiredAttribute));

			// Assert
			Assert.NotNull(requiredAttribute);
			Assert.AreEqual("Giá bán ra không được bỏ trống.", requiredAttribute.ErrorMessage);
		}

		// Gia ban trong khoang cho phep
		[Test]
		public void GiaBan_ShouldHaveRangeAttribute()
		{
			// Arrange
			var propertyName = "GiaBan";

			// Act
			var propertyInfo = typeof(SanPhamView).GetProperty(propertyName);
			var rangeAttribute = (System.ComponentModel.DataAnnotations.RangeAttribute)propertyInfo.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

			// Assert
			Assert.NotNull(rangeAttribute);
			Assert.AreEqual(0, rangeAttribute.Minimum);
			Assert.AreEqual(float.MaxValue, rangeAttribute.Maximum);
			Assert.AreEqual("Giá bán ra phải lớn hơn hoặc bằng 0.", rangeAttribute.ErrorMessage);
		}

		// gia ban phai la so nguyen
		[Test]
		public void GiaBan_ShouldHaveRegularExpressionAttribute()
		{
			// Arrange
			var propertyName = "GiaBan";

			// Act
			var propertyInfo = typeof(SanPhamView).GetProperty(propertyName);
			var regexAttribute = (RegularExpressionAttribute)propertyInfo.GetCustomAttribute(typeof(RegularExpressionAttribute));

			// Assert
			Assert.NotNull(regexAttribute);
			Assert.AreEqual("^[0-9]+$", regexAttribute.Pattern);
			Assert.AreEqual("Vui lòng nhập số nguyên.", regexAttribute.ErrorMessage);
		}
		// khong de trong gia niem yet
		[Test]

		public void GiaNiemYet_ShouldHaveRequiredAttribute()
		{
			// Arrange
			var propertyName = "GiaNiemYet";

			// Act
			var propertyInfo = typeof(SanPhamView).GetProperty(propertyName);
			var requiredAttribute = (RequiredAttribute)propertyInfo.GetCustomAttribute(typeof(RequiredAttribute));

			// Assert
			Assert.NotNull(requiredAttribute);
			Assert.AreEqual("Giá niêm yết không được bỏ trống.", requiredAttribute.ErrorMessage);
		}

		// Gia niem yet trong khoang cho phep
		[Test]
		public void GiaNiemYet_ShouldHaveRangeAttribute()
		{
			// Arrange
			var propertyName = "GiaNiemYet";

			// Act
			var propertyInfo = typeof(SanPhamView).GetProperty(propertyName);
			var rangeAttribute = (System.ComponentModel.DataAnnotations.RangeAttribute)propertyInfo.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.RangeAttribute));

			// Assert
			Assert.NotNull(rangeAttribute);
			Assert.AreEqual(0, rangeAttribute.Minimum);
			Assert.AreEqual(float.MaxValue, rangeAttribute.Maximum);
			Assert.AreEqual("Giá niêm yết phải lớn hơn hoặc bằng 0.", rangeAttribute.ErrorMessage);
		}

		// gia niem yet phai la so nguyen
		[Test]
		public void GiaNiemYet_ShouldHaveRegularExpressionAttribute()
		{
			// Arrange
			var propertyName = "GiaNiemYet";

			// Act
			var propertyInfo = typeof(SanPhamView).GetProperty(propertyName);
			var regexAttribute = (RegularExpressionAttribute)propertyInfo.GetCustomAttribute(typeof(RegularExpressionAttribute));

			// Assert
			Assert.NotNull(regexAttribute);
			Assert.AreEqual("^[0-9]+$", regexAttribute.Pattern);
			Assert.AreEqual("Vui lòng nhập số nguyên.", regexAttribute.ErrorMessage);
		}


		// nhap gia ban nho gia nhap
		[Test]		
		public void Test_SellingPriceAndImportPrice()
		{
			var fileMock = new Mock<IFormFile>();
			fileMock.Setup(f => f.FileName).Returns("test.jpg");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;
			var sp = new SanPhamView()
			{

				Id = Guid.NewGuid(),
				MaSp = "dfsgdfg",
				TenSanPham = ".';ư;ư.'.ưƠ}!@#$%^&",
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "joen",
				TrangThai = true,
				GiaNhap = 30,
				GiaBan = 15,
				GiaNiemYet = 20,
				GhiChu = "note",
				Is_detele = true,
				AnhDaiDien = "dàgiuhsdakbnkjsxncoiashcw",

			};
			bool result = sanPhamController.Create(sp, image);
			Assert.IsFalse(result);
		}



		// nhap dung tat ca cac truong
		[Test]
		public void Test_TrueAll()
		{
			var fileMock = new Mock<IFormFile>();
			fileMock.Setup(f => f.FileName).Returns("test.jpg");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;
			var sp = new SanPhamView()
			{

				Id = Guid.NewGuid(),
				MaSp = "dfsgdfg",
				TenSanPham = "kien123456",
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "joen",
				TrangThai = true,
				GiaNhap = 30,
				GiaBan = 15,
				GiaNiemYet = 20,
				GhiChu = "note",
				Is_detele = true,
				AnhDaiDien = "dàgiuhsdakbnkjsxncoiashcw",

			};
			bool result = sanPhamController.Create(sp, image);
			Assert.IsTrue(result);
		}


		// chon anh sai dinh dang : VN/A
		[Test]
		public void Test_Add_ImageWrongFormat() 
		{
			var fileMock = new Mock<IFormFile>();
			fileMock.Setup(f => f.FileName).Returns("ConnectionStrings.txt");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;
			var sp = new SanPhamView()
			{

				Id = Guid.NewGuid(),
				MaSp = "dfsgdfg",
				TenSanPham = "kien123456",
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "joen",
				TrangThai = true,
				GiaNhap = 30,
				GiaBan = 15,
				GiaNiemYet = 20,
				GhiChu = "note",
				Is_detele = true,
				AnhDaiDien = "dàgiuhsdakbnkjsxncoiashcw",

			};
			bool result = sanPhamController.Create(sp, image);
			Assert.IsFalse(result);
		}

		// de trong Ten san pham va nhap du cac truong con lai
		[Test]
		public void Test_TenSPIsNull()
		{
			var fileMock = new Mock<IFormFile>();
			fileMock.Setup(f => f.FileName).Returns("test.jpg");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;
			var sp = new SanPhamView()
			{

				Id = Guid.NewGuid(),
				MaSp = "dfsgdfg",
				TenSanPham = null,
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "joen",
				TrangThai = true,
				GiaNhap = 30,
				GiaBan = 15,
				GiaNiemYet = 20,
				GhiChu = "note",
				Is_detele = true,
				AnhDaiDien = "dàgiuhsdakbnkjsxncoiashcw",

			};
			bool result = sanPhamController.Create(sp, image);
			Assert.IsFalse(result);
		}
		// xem thong tin chi tiet cau san pham
		[Test]
		public void Test_ShowSPDetail()
		{
			bool result = sanPhamController.Details(Guid.Parse("d4525bcf-9104-4c1b-9a8b-2332e3480d88"));
			Assert.IsTrue(result);
		}

		//de trong tat ca cac truong
		[Test]
		public void TestSuaProduct_AllNull()
		{
			var fileMock = new Mock<IFormFile>(); // Thay IFormFile bằng interface tương ứng
			fileMock.Setup(f => f.FileName).Returns("test.jpg");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;

			var sp = new SanPhamView()
			{

				Id = Guid.Parse("d4525bcf-9104-4c1b-9a8b-2332e3480d88"),
				MaSp = "",
				TenSanPham = "",
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "",
				TrangThai = true,
				GiaNhap = 10,
				GiaBan = 10,
				GiaNiemYet = 10,
				GhiChu = "",
				Is_detele = true,
				AnhDaiDien = "",

			};
			bool result = sanPhamController.Edit2(sp, image,"3435");
			Assert.IsFalse(result);
		}

		// dien dung tat ca ca truong
		[Test]
		public void TestSuaProduct_AllTrue()
		{
			var fileMock = new Mock<IFormFile>(); // Thay IFormFile bằng interface tương ứng
			fileMock.Setup(f => f.FileName).Returns("test.jpg");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;

			var sp = new SanPhamView()
			{

				Id = Guid.Parse("d4525bcf-9104-4c1b-9a8b-2332e3480d88"),
				MaSp = "",
				TenSanPham = "",
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "",
				TrangThai = true,
				GiaNhap = 10,
				GiaBan = 10,
				GiaNiemYet = 10,
				GhiChu = "",
				Is_detele = true,
				AnhDaiDien = "",

			};
			bool result = sanPhamController.Edit2(sp, image,"123");
			Assert.IsFalse(result);
		}
		// sau gia nhap lon hon gia ban
		[Test]
		public void TestSua_SellingPriceAndImportPrice()
		{
			var fileMock = new Mock<IFormFile>();
			fileMock.Setup(f => f.FileName).Returns("test.jpg");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;
			var sp = new SanPhamView()
			{

				Id = Guid.Parse("d4525bcf-9104-4c1b-9a8b-2332e3480d88"),
				MaSp = "dfsgdfg",
				TenSanPham = ".';ư;ư.'.ưƠ}!@#$%^&",
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "joen",
				TrangThai = true,
				GiaNhap = 30,
				GiaBan = 15,
				GiaNiemYet = 20,
				GhiChu = "note",
				Is_detele = true,
				AnhDaiDien = "dàgiuhsdakbnkjsxncoiashcw",

			};
			bool result = sanPhamController.Edit2(sp, image,"123");
			Assert.IsFalse(result);
		}
		
		// Ten san pham phai la string
		[Test]
		public void TestSua_TenSP_ShouldHaveString()
		{
			var fileMock = new Mock<IFormFile>();
			fileMock.Setup(f => f.FileName).Returns("test.jpg");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;
			var sp = new SanPhamView()
			{

				Id = Guid.Parse("d4525bcf-9104-4c1b-9a8b-2332e3480d88"),
				MaSp = "dfsgdfg",
				TenSanPham = ".';ư;ư.'.ưƠ}!@#$%^&",
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "joen",
				TrangThai = true,
				GiaNhap = 10,
				GiaBan = 15,
				GiaNiemYet = 20,
				GhiChu = "note",
				Is_detele = true,
				AnhDaiDien = "dàgiuhsdakbnkjsxncoiashcw",

			};
			bool result = sanPhamController.Edit2(sp, image,"123");
			Assert.IsFalse(result);
		}
		// de trong Ten san pham va nhap du cac truong con lai
		[Test]
		public void TestSua_TenSPIsNull()
		{
			var fileMock = new Mock<IFormFile>();
			fileMock.Setup(f => f.FileName).Returns("test.jpg");
			fileMock.Setup(f => f.Length).Returns(1024);
			var image = fileMock.Object;
			var sp = new SanPhamView()
			{

				Id = Guid.NewGuid(),
				MaSp = "dfsgdfg",
				TenSanPham = null,
				IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
				IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
				MoTa = "joen",
				TrangThai = true,
				GiaNhap = 30,
				GiaBan = 15,
				GiaNiemYet = 20,
				GhiChu = "note",
				Is_detele = true,
				AnhDaiDien = "dàgiuhsdakbnkjsxncoiashcw",

			};
			bool result = sanPhamController.Create(sp, image);
			Assert.IsFalse(result);
		}
	}
}
