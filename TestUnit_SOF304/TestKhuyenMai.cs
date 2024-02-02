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
            public void TestValidation_MaKhuyenMai_BoTrong()
            {
                // Tạo một đối tượng mã giảm giá với MaGiam bị bỏ trống
                 KhuyenMai km = new KhuyenMai
                {
                    MaKhuyenMai = null
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
                    SoTienGiam = 0
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }



            [Test]
            public void TestValidation_PhanTramGiam_BoTrong()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                 KhuyenMai km = new KhuyenMai
                {
                    PhanTramGiamGia = 0
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }

            [Test]
            public void TestValidation_DieuKienGiam_BoTrong()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                 KhuyenMai km = new KhuyenMai
                {
                    DongGia = 0
                };
                //bool result = _GiamGiaService.Them(nullGiamGia);

                //// Assert
                //Assert.IsFalse(result);

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }

            [Test]
            public void TestValidation_Soluong_BoTrong()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                 KhuyenMai km = new KhuyenMai
                {
                    Ghichu = null
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _KhuyenMaiservice.Them(km);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }


            

        }
    }
}
