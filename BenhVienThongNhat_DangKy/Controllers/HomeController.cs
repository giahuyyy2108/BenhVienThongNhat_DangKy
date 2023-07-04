using BenhVienThongNhat_DangKy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
namespace BenhVienThongNhat_DangKy.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly DataBaseContext _context;

		Uri baseAdrees = new Uri("https://localhost:44360/api");

		private readonly HttpClient _client;
		public HomeController(ILogger<HomeController> logger,DataBaseContext context)
		{
			_logger = logger;
			_context = context;
			_client = new HttpClient();
			_client.BaseAddress = baseAdrees;
		}


		[HttpGet]
		public async Task<IActionResult> Index()
		{
			List<GioiTinh> gt = new List<GioiTinh>();
			HttpResponseMessage respon =await _client.GetAsync(_client.BaseAddress + "/Gioitinh");
            respon.EnsureSuccessStatusCode();
            if (respon.IsSuccessStatusCode)
			{
				string data =await respon.Content.ReadAsStringAsync();
                gt = JsonConvert.DeserializeObject<List<GioiTinh>>(data);
			}
			return View(gt);
		}

		public IActionResult Privacy()
		{
			return View();
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		// check benh nhan ton tai trong danh sasch
		//public bool checkbn(BenhNhan benhnhan)
		//{
		//    var data = _context.BenhNhan
		//                            .Where(t => t.Thoigian.Date == DateTime.Now.Date)
		//                            .ToList();
		//    foreach (var item in data)
		//    {
		//        if (benhnhan.mabn == item.mabn)
		//            return true;
		//    }
		//    return false;
		//}
		private BenhNhan _benhnhan;
		
        public async Task<IActionResult> Create(int khu)
		{
            ViewData["id_gioitinh1"] = new SelectList(_context.GioiTinh, "id", "name");
			ViewData["id_phong"] = new SelectList(_context.Phong.Where(p => p.khoa.id_khu == khu).Include(p=>p.khoa), "id", "name");
            BenhNhan model = new BenhNhan()
            {
				//thoigian = DateTime.Parse((DateTime.Now).ToShortTimeString())
			};
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int khu,[Bind("hoten,namsinh,mabn,thoigian,id_gioitinh,id_phong")] BenhNhan thongTinKhamBenh)
        {
			thongTinKhamBenh.thoigian = DateTime.Now;
            if (ModelState.IsValid)
            {
				_benhnhan = thongTinKhamBenh;
                //_context.Add(thongTinKhamBenh);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_gioitinh"] = new SelectList(_context.GioiTinh, "Id", "Name", thongTinKhamBenh.id_gioitinh);
            ViewData["id_phong"] = new SelectList(_context.Phong.Where(p => p.khoa.id_khu == khu).Include(p => p.khoa), "id", "name",thongTinKhamBenh.phong.id_khoa);
            return View(thongTinKhamBenh);
        }
    }
}
