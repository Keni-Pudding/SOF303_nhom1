using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ServiceJoin;
using CTN4_View.Areas.Admin.Controllers.QuanLyHoaDonThieuxk;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Moq;

namespace TestUnit_SOF304
{
    public class HoaDonTest
    {
        public QuanLyHoaDonController _controller;
        private readonly HttpClient _client;
        private Mock<HttpClient> _httpClient;
        public IHoaDonService _hoaDonService;
        public IHoaDonChiTietService _hoaDonChiTietService;
        public Mock<IHoaDonService> _hoaDonService2;
        public Mock<IHoaDonChiTietService> _hoaDonChiTietService2;
        public Mock<ILichSuHoaDonService> _LichSuHoaDonService;
        public Mock<IChatLieuService> _chatLieuService;
        public Mock<INSXService> _nsxService;
        public Mock<ISanPhamService> _spService;
        public Mock<ISanPhamService> _sanPhamService;
        public Mock<IMauService> _mauService;
        public Mock<ISizeService> _sizeService;
        public Mock<SanPhamCuaHangService> _sanPhamCuaHangService;
        public Mock<DB_CTN4_ok> _db;
        public Mock<IAnhService> _anhService;
        public Mock<ISanPhamChiTietService> _sanPhamChiTietService;
        public Mock<IKhuyenMaiSanPhamService> _KhuyenMaiSanPhams;
        public Mock<IGiamGiaService> _giamGiaService;
        public Mock<IMauService> _mauSacService;
        public Mock<DB_CTN4_ok> _CTN4_Ok;
        public Mock<IGiamGiaChiTietService> _GiamGiaChiTietService;
        public Mock<IDanhGiaSanPhamService>  _danhGiaSanPhamService;


        [SetUp]
        public void Setup()
        {
            _httpClient = new Mock<HttpClient>();
            _hoaDonService = new HoaDonService();
            _hoaDonChiTietService = new HoaDonChiTietService();
            _hoaDonService2 = new Mock<IHoaDonService>();
            _hoaDonChiTietService2 = new Mock<IHoaDonChiTietService>();
            _LichSuHoaDonService = new Mock<ILichSuHoaDonService> ();
            _chatLieuService = new Mock<IChatLieuService> ();
            _nsxService = new Mock<INSXService> ();
            _spService = new Mock<ISanPhamService> ();
            _sanPhamService = new Mock<ISanPhamService>();
            _mauService = new Mock<IMauService>();
            _sizeService = new Mock<ISizeService> ();
            _sanPhamCuaHangService = new Mock<SanPhamCuaHangService> ();
            _db = new Mock<DB_CTN4_ok> ();
            _anhService = new Mock<IAnhService> ();
            _sanPhamChiTietService = new Mock<ISanPhamChiTietService> ();
            _KhuyenMaiSanPhams = new Mock<IKhuyenMaiSanPhamService>();
            _giamGiaService = new Mock<IGiamGiaService> ();
            _mauSacService = new Mock<IMauService> ();
            _CTN4_Ok = new Mock<DB_CTN4_ok>();
            _GiamGiaChiTietService = new Mock<IGiamGiaChiTietService>();
            _danhGiaSanPhamService = new Mock<IDanhGiaSanPhamService>();

            //khởi tạo controller với các mock đã tạo
            _controller = new QuanLyHoaDonController(
                _httpClient.Object
                );
        }

        [Test, ActionName("1")]
        public void HoaDonAll1()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "1",
            };

            bool result = _hoaDonService.Them(hoadon);
            Assert.IsFalse(result);
        }
        [Test, ActionName("2")]
        public void HoaDonAllNull()
        {
            HoaDon hoadon = new HoaDon();

            bool result = _hoaDonService.Them(hoadon);
            //không null
            Assert.IsFalse(result);
        }
        [Test, ActionName("3")]
        public void HoaDonTimkiem()
        {
            var nah = _controller.TimKiemSp("") as ViewResult;
            //đúng kết quả trả về
            Assert.AreEqual(nah.ViewName, "sanphammua");
        }

        [Test, ActionName("4")]
        public void HoaDonTimkiem2()
        { 
            var nah = _controller.TimKiemSp("h") as ViewResult;
            //đúng kết quả trả về
            Assert.That(nah.ViewName, Is.EqualTo("sanphammua"));
        }

        [Test, ActionName("5")]
        public void HoaDonTimkiem3()
        {
            var nah = _controller.TimKiemSp2(500, 80000) as ViewResult;
            //đúng kết quả trả về
            Assert.That(nah.ViewName, Is.EqualTo("sanphammua"));
        }

        [Test, ActionName("6")]
        public void maHoaDonNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = null,
                TrangThai = "Còn",
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            //không null
            Assert.IsFalse(result);
        }

        [Test, ActionName("7")]
        public void ngayTaoNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                NgayTaoHoaDon = null,
                TrangThai = "Còn",
                TrangThaiThanhToan = true,
                Is_detele = true
                
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("8")]
        public void ngayDatNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                TrangThaiThanhToan = true,
                Is_detele = true,
                NgayDat = null
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("9")]
        public void TrangThaiNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsFalse(result);
        }

        [Test, ActionName("10")]
        public void TongtienNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                TongTien = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("11")]
        public void TienShipNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                TienShip = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("12")]
        public void TienHangNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                TienHang = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("13")]
        public void TienGiamNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                TienGiam = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("14")]
        public void NgayGiaoNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                NgayGiao = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("15")]
        public void NgayNhanNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                NgayNhan = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("16")]
        public void TenKhachHangNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                TenKhachHang = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("17")]
        public void EmailNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                Email = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("18")]
        public void SDTNguoiNhanNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                SDTNguoiNhan = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("19")]
        public void DiaChiNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                DiaChi = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("20")]
        public void GhiChuNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                GhiChu = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("21")]
        public void IdKhachHangNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                IdKhachHang = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("22")]
        public void IdPhuongThucNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                IdPhuongThuc = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("23")]
        public void IdDiaChiNhanHangNull()
        {
            HoaDon hoadon = new HoaDon
            {
                MaHoaDon = "hd01",
                TrangThai = "Còn",
                IdDiaChiNhanHang = null,
                TrangThaiThanhToan = true,
                Is_detele = true
            };

            bool result = _hoaDonService.Them(hoadon);
            // có thể null
            Assert.IsTrue(result);
        }

        [Test, ActionName("24")]
        public void KiemtraEmail()
        {
            var abht = _controller.IsValidGmail("e");
            // không đúng định dạng
            Assert.IsFalse(abht);
        }


        [Test, ActionName("25")]
        public void KiemtraEmail_CoCachDau()
        {
            var abht = _controller.IsValidGmail("   e@gmail.com");    
            //không được nhập cách
            Assert.IsFalse(abht);
        }

        [Test, ActionName("26")]
        public void KiemtraEmail_CoCachCuoi()
        { 
            var abht = _controller.IsValidGmail("e@gmail.com  ");
            //không được nhập cách
            Assert.IsFalse(abht);
        }

        [Test, ActionName("27")]
        public void KiemtraEmail_CoCachGiua()
        {
            var abht = _controller.IsValidGmail("e@g ma il.com");
            //không được nhập cách
            Assert.IsFalse(abht);
        }

        [Test, ActionName("28")]
        public void hdct_GiaTienAm()
        {
            HoaDonChiTiet hoadon1 = new HoaDonChiTiet
            {
                SoLuong = 2,
                GiaTien = -232,
                TrangThai = true,
                Is_detele = true,
                IdSanPhamChiTiet = new Guid(),
                IdHoaDon = 12,
            };
            
            bool result = _hoaDonChiTietService.Them(hoadon1);
            //không nhận giá trị âm
            Assert.IsFalse(result);
        }

        [Test, ActionName("29")]
        public void hdct_SoLuongAm()
        {
            HoaDonChiTiet hoadon1 = new HoaDonChiTiet
            {
                SoLuong = -5,
                GiaTien = 599,
                TrangThai = true,
                Is_detele = true,
                IdSanPhamChiTiet = new Guid(),
                IdHoaDon = 12,
            };

            bool result = _hoaDonChiTietService.Them(hoadon1);
            //không nhận giá trị âm
            Assert.IsFalse(result);
        }

        [Test, ActionName("30")]
        public void hdct_spct_null()
        {
            HoaDonChiTiet hoadon1 = new HoaDonChiTiet
            {
                SoLuong = 5,
                GiaTien = 599,
                TrangThai = true,
                Is_detele = true,
                IdSanPhamChiTiet = null,
                IdHoaDon = 12,
            };

            bool result = _hoaDonChiTietService.Them(hoadon1);
            //không null
            Assert.IsFalse(result);
        }

    }
}
