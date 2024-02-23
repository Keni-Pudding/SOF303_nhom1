using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System;
using CTN4_Data;
using CTN4_Data.Models.DB_CTN4;
using System.ComponentModel.DataAnnotations;
using CTN4_Serv.Service;


namespace TestUnit_SOF304
{
    [TestFixture]
    public class TestKhuyenMai
    {
        public class TestThemVoucher
        {
            private KhuyenMaiService _KhuyenMaiservice;
            [SetUp]
            public void Setup()
            {
                _KhuyenMaiservice = new KhuyenMaiService();
            }

            KhuyenMai km = new KhuyenMai();
            [Test]

            public void TestValidation_BoTrongHet()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống

                KhuyenMai km = new KhuyenMai
                {
                    MaKhuyenMai = null,
                    SoTienGiam = 0,
                    PhanTramGiamGia = 0,
                    DongGia = 0,
                    Ghichu = null,
                };

                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_Themthanhcong()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống

                KhuyenMai km = new KhuyenMai
                {
                    MaKhuyenMai = "a",
                    SoTienGiam = 1,
                    PhanTramGiamGia = 1,
                    DongGia = 1,
                    Ghichu = "a",
                };

                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
            [Test]
            public void TestValidation_MaKhuyenMai_BoTrong()
            {
                // Tạo một đối tượng mã giảm giá với MaGiam bị bỏ trống
                KhuyenMai km = new KhuyenMai
                {
                    MaKhuyenMai = null,
                    SoTienGiam = 1,
                    PhanTramGiamGia = 1,
                    DongGia = 1,
                    Ghichu = "a",
                };

                // Sử dụng Validator để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);


            }
            [Test]

            public void TestValidation_SoTienGiam_BoTrong()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                KhuyenMai km = new KhuyenMai
                {

                    MaKhuyenMai = "a",
                    
                    PhanTramGiamGia = 1,
                    DongGia = 1,
                    Ghichu = "a",
                    SoTienGiam = float.NaN
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_SoTienGiam_BangKhong()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                KhuyenMai km = new KhuyenMai
                {

                    MaKhuyenMai = "a",
                    
                    PhanTramGiamGia = 1,
                    DongGia = 1,
                    Ghichu = "a",
                    SoTienGiam = 0
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }



            [Test]
            public void TestValidation_DongGia_BoTrong()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                KhuyenMai km = new KhuyenMai
                {
                    MaKhuyenMai = "a",
                    SoTienGiam = 1,
                    
                    DongGia = float.NaN,
                    Ghichu = "a",
                    PhanTramGiamGia = 1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]
            public void TestValidation_DongGia_BangKhong()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                KhuyenMai km = new KhuyenMai
                {
                    MaKhuyenMai = "a",
                    SoTienGiam = 1,
                    
                    DongGia = 0,
                    Ghichu = "a",
                    PhanTramGiamGia = 1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
             [Test]
            public void TestValidation_PhanTramGiam_BoTrong()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                KhuyenMai km = new KhuyenMai
                {
                    MaKhuyenMai = "a",
                    SoTienGiam = 1,
                    
                    DongGia = 1,
                    Ghichu = "a",
                    PhanTramGiamGia = float.NaN
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]
            public void TestValidation_PhanTramGiam_BangKhong()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                KhuyenMai km = new KhuyenMai
                {
                    MaKhuyenMai = "a",
                    SoTienGiam = 1,
                    
                    DongGia = 1,
                    Ghichu = "a",
                    PhanTramGiamGia = 0
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }

         
            [Test]
            public void TestValidation_GhiChu_BoTrong()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                KhuyenMai km = new KhuyenMai
                {
                    MaKhuyenMai = "a",
                    SoTienGiam = 1,

                    DongGia = 1,
                    Ghichu = null,
                    PhanTramGiamGia = 1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
          




        }
    }
}
