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
using CTN4_View.Controllers;
using CTN4_View.Areas.Admin.Controllers.QuanLyVouvher;
using CTN4_Serv.ViewModel;

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
            public void TestValidation_MaGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với MaGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    MaGiam = null
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
                    SoTienGiam = 0
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
                    SoTienGiam = -1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }



            [Test]
            public void TestValidation_PhanTramGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    PhanTramGiam = 0
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
                    PhanTramGiam = -1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_PhanTramGiam_quamottram_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    PhanTramGiam = 101
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }

            [Test]
            public void TestValidation_DieuKienGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    DieuKienGiam = 0
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
                        DieuKienGiam = -1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }

            [Test]
            public void TestValidation_Soluong_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    SoLuong = 0
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_Soluon_Bangkhong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    SoLuong = -1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }


            [Test]
            public void TestValidation_SoTienGiamToiDa_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    SoTienGiamToiDa = 0
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
                    SoTienGiamToiDa = -1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Them(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
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
                    MaGiam = null
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
                    SoTienGiam = 0
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
                    SoTienGiam = -1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }



            [Test]
            public void TestValidation_SuaPhanTramGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    PhanTramGiam = 0
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
                    PhanTramGiam = -1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]

            public void TestValidation_SuaPhanTramGiam_Hontram_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    PhanTramGiam = 101
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }

            [Test]
            public void TestValidation_SuaDieuKienGiam_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    DieuKienGiam = 0
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

            public void TestValidation_SuaDieukienGiam_Bangkhong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với SoTienGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    DieuKienGiam = -1
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
            [Test]
            public void TestValidation_SuaSoluong_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    SoLuong = 0
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }


            [Test]
            public void TestValidation_SuaSoTienGiamToiDa_Khi_BiBoTrong_ThongBaoLoi()
            {
                // Tạo một đối tượng mã giảm giá với PhanTramGiam bị bỏ trống
                GiamGia voucher = new GiamGia
                {
                    SoTienGiamToiDa = 0
                };

                // Sử dụng Assert để kiểm tra việc xác nhận dữ liệu
                bool result = _GiamGiaservice.Sua(voucher);

                // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
                Assert.IsFalse(result);
            }
        }

        public class TimVoucher
        {

            private GiamGiaService _GiamGiaservice;
            private VoucherController _voucher;
            private HomeController _homeController;
            [SetUp]
            public void Setup()
            {
                _GiamGiaservice = new GiamGiaService();
                _voucher = new VoucherController();
            }


            //[Test]
            //public void TestValidation_TimKiem_BoTrong_ThongBaoLoi()
            //{
            //    // Tạo một đối tượng mã giảm giá với MaGiam bị bỏ trống
            //    GiamGia voucher = new GiamGia
            //    {
            //        MaGiam = null,


            //    };

            //    // Sử dụng Validator để kiểm tra việc xác nhận dữ liệu
            //    bool result = _GiamGiaservice.Ti(voucher);

            //    // Kiểm tra xem việc xác nhận dữ liệu có trả về kết quả là false (có lỗi) hay không
            //    Assert.IsFalse(result);


            //}
        }
    }

}



