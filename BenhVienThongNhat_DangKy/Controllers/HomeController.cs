using BenhVienThongNhat_DangKy.Models;
using BenhVienThongNhat_DangKy.Models.View_Models;
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
		
        public async Task<IActionResult> Create(int id_khu)
		{
            ViewData["id_gioitinh1"] = new SelectList(_context.GioiTinh, "id", "name");
			ViewData["id_phong"] = new SelectList(_context.Phong.Where(p => p.khoa.id_khu == id_khu), "id", "name");

            ViewData["phong"] = _context.Phong.Where(p => p.khoa.id_khu == id_khu).Select(a => new SelectListItem
            {
                Text = a.name,
                Value = a.id.ToString()
            });

            BenhNhanViewModel model = new BenhNhanViewModel()
			{
				//thoigian = DateTime.Now,
				id_khu = id_khu
			};
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id_khu, [Bind("hoten,namsinh,mabn,thoigian,id_gioitinh,id_khu,phongs,id_phong")] BenhNhanViewModel thongTinKhamBenh)
        {
            
            if (ModelState.IsValid)
            {
                for (int i = 0; i < thongTinKhamBenh.phongs.Count; i++)
                {
                    if (i > 0)
                    {
                        thongTinKhamBenh.id++;
                        thongTinKhamBenh.id_phong = thongTinKhamBenh.phongs[i];
                        thongTinKhamBenh.thoigian = DateTime.Now;
                        _context.Add(thongTinKhamBenh);
                        await _context.SaveChangesAsync();
                        continue;
                    }
                    thongTinKhamBenh.id_phong = thongTinKhamBenh.phongs[i];
                    thongTinKhamBenh.thoigian = DateTime.Now;
                    _context.Add(thongTinKhamBenh);
                    await _context.SaveChangesAsync();
                }
                
                BenhNhanViewModel model = new BenhNhanViewModel()
                {
                    //thoigian = DateTime.Now,
                    id_khu = id_khu
                };
                return RedirectToAction(nameof(abc), model);
            }
            ViewData["phong"] = _context.Phong.Where(p => p.khoa.id_khu == id_khu).Select(a => new SelectListItem
            {
                 Text = a.name,
                 Value = a.id.ToString(),
                 Selected= true
            });
            ViewData["id_gioitinh1"] = new SelectList(_context.GioiTinh, "Id", "Name", thongTinKhamBenh.id_gioitinh);
            return View(thongTinKhamBenh);
        }
        public async Task<IActionResult> abc(int id_khu)
        {
            BenhNhanViewModel model = new BenhNhanViewModel()
            {
                //thoigian = DateTime.Now,
                id_khu = id_khu
            };
            return RedirectToAction(nameof(Create), model);
        }

        //public async Task<IActionResult> ChonPhong(int id_khoa,int id)
        //{

        //	//var id = await _context.BenhNhan.MaxAsync(p=>p.id);
        //	var bn = await _context.BenhNhan.Where(p => p.id == id).FirstAsync();
        //	if (bn == null)
        //	{
        //		return NotFound();
        //	}
        //	ViewData["id_phong"] = new SelectList(_context.Phong.Where(s => s.id_khoa == id_khoa).Include(s => s.khoa), "id", "name");
        //	return View(bn);
        //}

        //[HttpPatch]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChonPhong(int id,int id_khoa,[Bind("hoten,namsinh,mabn,thoigian,id_gioitinh,id_khoa,id_phong")] BenhNhan thongTinKhamBenh)
        //{
        //	if(id !=thongTinKhamBenh.id)
        //	{
        //		return NotFound();
        //	}
        //	thongTinKhamBenh.thoigian = DateTime.Now;
        //	if (ModelState.IsValid)
        //	{
        //		try
        //		{
        //                  _context.Update(thongTinKhamBenh);
        //                  await _context.SaveChangesAsync();
        //              }
        //		catch (DbUpdateConcurrencyException)
        //		{

        //			throw;
        //              }
        //              return RedirectToAction(nameof(Index));
        //          }
        //          ViewData["id_phong"] = new SelectList(_context.Phong.Where(p => p.id_khoa ==  id_khoa).Include(p => p.khoa), "id", "name", thongTinKhamBenh.phong.id_khoa);
        //	return View(thongTinKhamBenh);
        //}
    }
}
