using System;
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
//using CTN4_View.Controllers;
//using CTN4_View.Areas.Admin.Controllers.QuanLyVouvher;
using CTN4_Serv.ViewModel;
using Microsoft.EntityFrameworkCore;
using CTN4_Serv.Service.IService;

namespace ClassTest
{


    [TestFixture]
    public class TestVoucher
    {

        public class TestThemVoucher
        {
            private GiamGiaService _GiamGiaservice;
            [SetUp]
            public void Setup()
            {
                _GiamGiaservice = new GiamGiaService();
            }

            GiamGia voucher = new GiamGia();
            [Test]

            public void TestValidation_BoTrongHet_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = null,
                    SoTienGiam = 0,
                    PhanTramGiam = 0,
                    SoTienGiamToiDa = 0,
                    SoLuong = 0,
                    DieuKienGiam = 0,

                };

                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_Themthanhcong()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,

                };

                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
            [Test]
            public void TestValidation_MaGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với MaGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = null,
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Validator để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);


            }
            [Test]

            public void TestValidation_SoTienGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = float.NaN,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_SoTienGiam_Bangkhong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 0,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
            //[Test]
            //public void TestValidation_SoTienGiam_NhoHonkhong_ThongBaoLoi()
            //{
            //    // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
            //    GiamGia voucher = new GiamGia
            //    {
            //        MaGiam = "a",
            //        SoTienGiam = 1,
            //        PhanTramGiam = 1,
            //        SoTienGiamToiDa = -1,
            //        SoLuong = 1,
            //        DieuKienGiam = 1,
            //    };

            //    // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
            //    bool result = _GiamGiaservice.Them(voucher);

            //    // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
            //    Assert.IsFalse(result);
            //}



            [Test]
            public void TestValidation_PhanTramGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = float.NaN,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_PhanTramGiam_Bangkhong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 0,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
            [Test]
            public void TestValidation_PhanTramGiam_Bangmottram_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 100,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
            //[Test]

            //public void TestValidation_PhanTramGiam_quamottram_ThongBaoLoi()
            //{
            //    // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
            //    GiamGia voucher = new GiamGia
            //    {
            //        MaGiam = "a",
            //        SoTienGiam = 1,
            //        PhanTramGiam = 101,
            //        SoTienGiamToiDa = 1,
            //        SoLuong = 1,
            //        DieuKienGiam = 1,
            //    };

            //    // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
            //    bool result = _GiamGiaservice.Them(voucher);

            //    // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
            //    Assert.IsFalse(result);
            //}
            //[Test]

            //public void TestValidation_PhanTramGiam_nhohonkhong_ThongBaoLoi()
            //{
            //    // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
            //    GiamGia voucher = new GiamGia
            //    {
            //        MaGiam = "a",
            //        SoTienGiam = 1,
            //        PhanTramGiam = -1,
            //        SoTienGiamToiDa = 1,
            //        SoLuong = 1,
            //        DieuKienGiam = 1,
            //    };

            //    // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
            //    bool result = _GiamGiaservice.Them(voucher);

            //    // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
            //    Assert.IsFalse(result);
            //}

            [Test]
            public void TestValidation_DieuKienGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,

                    DieuKienGiam = float.NaN
                };
                //bool result = _GiamGiaService.Them(nullGiamGia);

                //// Assert
                //Assert.IsFalse(result);

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_DieuKienGiam_Bangkhong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 0,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }

            [Test]
            public void TestValidation_Soluong_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = float.NaN,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            //[Test]

            //public void TestValidation_Soluong_Bangkhong_ThongBaoLoi()
            //{
            //    // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
            //    GiamGia voucher = new GiamGia
            //    {
            //        MaGiam = "a",
            //        SoTienGiam = 1,
            //        PhanTramGiam = 1,
            //        SoTienGiamToiDa = 1,
            //        SoLuong = 0,
            //        DieuKienGiam = 1,
            //    };

            //    // Sử dụng Assert để kiểm tra việc xác nhận ngoại lệ
            //    Assert.Throws<DbUpdateException>(() => _GiamGiaservice.Them(voucher));
            //}


            [Test]
            public void TestValidation_SoTienGiamToiDa_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = float.NaN,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_SoTienGiamToiDa_Bangkhong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 0,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }


        }
        public class SuaVoucher
        {
            private GiamGiaService _GiamGiaservice;
            [SetUp]
            public void Setup()
            {
                _GiamGiaservice = new GiamGiaService();
            }
            [Test]
            public void TestValidation_MaGiam_suathanhcong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với MaGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,

                };

                // Sử dụng Validator để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);


            }
            [Test]
            public void TestValidation_MaGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với MaGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = null,
                    SoTienGiam = 0,
                    PhanTramGiam = 0,
                    SoTienGiamToiDa = 0,
                    SoLuong = 0,
                    DieuKienGiam = 0,

                };

                // Sử dụng Validator để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);


            }

            [Test]
            public void TestValidation_SuaMaGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với MaGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = null,

                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Validator để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);


            }
            [Test]

            public void TestValidation_SuaSoTienGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = float.NaN,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_SuaSoTienGiam_Bangkhong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 0,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }



            [Test]
            public void TestValidation_SuaPhanTramGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = float.NaN,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_SuaPhanTramGiam_Bangkhong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 0,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
            [Test]
            public void TestValidation_PhanTramGiam_Bangmottram_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 100,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
            [Test]
            public void TestValidation_DieuKienGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,

                    DieuKienGiam = float.NaN
                };
                //bool result = _GiamGiaService.Them(nullGiamGia);

                //// Assert
                //Assert.IsFalse(result);

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_DieuKienGiam_Bangkhong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 0,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }

            [Test]
            public void TestValidation_Soluong_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 1,
                    SoLuong = int.MinValue,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
            //[Test]

            //public void TestValidation_Soluong_Bangkhong_ThongBaoLoi()
            //{
            //    // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
            //    GiamGia voucher = new GiamGia
            //    {
            //        MaGiam = "a",
            //        SoTienGiam = 1,
            //        PhanTramGiam = 1,
            //        SoTienGiamToiDa = 1,
            //        SoLuong = 0,
            //        DieuKienGiam = 1,
            //    };

            //    // Sử dụng Assert để kiểm tra việc xác nhận ngoại lệ
            //    Assert.Throws<DbUpdateException>(() => _GiamGiaservice.Sua(voucher));
            //}


            [Test]
            public void TestValidation_SoTienGiamToiDa_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = float.NaN,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_SoTienGiamToiDa_Bangkhong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 1,
                    SoTienGiamToiDa = 0,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsTrue(result);
            }
           


            //public class TimVoucher
            //{

            //    private GiamGiaService _GiamGiaservice;
            //    private VoucherController _voucher;
            //    private HomeController _homeController;
            //    [SetUp]
            //    public void Setup()
            //    {
            //        _GiamGiaservice = new GiamGiaService();
            //        _voucher = new VoucherController();
            //    }


            //    //[Test]
            //    //public void TestValidation_TimKiem_BoTrong_ThongBaoLoi()
            //    //{
            //    //    // Tạo một đối tượng mã giảm giá với MaGiam bị bỏ trống
            //    //    GiamGia voucher = new GiamGia
            //    //    {
            //    //        MaGiam = null,


            //    //    };

            //    //    // Sử dụng Validator để kiểm tra việc xác nhận dữ liệu
            //    //    bool result = _GiamGiaservice.Ti(voucher);

            //    //    // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
            //    //    Assert.IsFalse(result);


            //    //}
            //}
        }
        public class XoaVoucher
        {
            private GiamGiaService _GiamGiaservice;
            [SetUp]
            public void Setup()
            {
                _GiamGiaservice = new GiamGiaService();
            }
            [Test]
            public void Test_Xoa_ThanhCong()
            {
                // Tạo một đối tượng GiamGia để thêm vào cơ sở dữ liệu
                // Lấy một ID đã có sẵn trong cơ sở dữ liệu
                Guid id = LayIdDaCoSan();

                // Thực hiện xóa và kiểm tra kết quả
                bool result = _GiamGiaservice.Xoa(id);

                // Kiểm tra xem việc xóa có thành công hay không
                Assert.IsTrue(result);
            }
            private Guid LayIdDaCoSan()
            {
                // Tạo một đối tượng GiamGia để thêm vào cơ sở dữ liệu
                GiamGia voucher = new GiamGia
                {
                    MaGiam = "a",
                    SoTienGiam = 1,
                    PhanTramGiam = 10,
                    SoTienGiamToiDa = 1,
                    SoLuong = 1,
                    DieuKienGiam = 1,
                };

                // Thêm đối tượng vào cơ sở dữ liệu để có một ID hợp lệ
                _GiamGiaservice.Them(voucher);

                // Lấy ID của đối tượng vừa thêm
                return voucher.Id;
            }
        }

    }

}



