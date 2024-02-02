using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Serv.ViewModel;
using CTN4_View_Admin.Controllers.QuanLY;

namespace TestUnit_SOF304.TestQuanLySP
{
	public class Data
	{

		private SanPhamView sanpham;
		private readonly SanPhamController sanPhamController = new SanPhamController();
		[SetUp]
		public void Setup()
		{
			sanpham = new SanPhamView();


		}
		

	}
}
