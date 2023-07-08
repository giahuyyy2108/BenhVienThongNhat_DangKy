using DangKy_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DangKy_API.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    [Consumes("application/json")]
    public class BenhNhanController : Controller
    {
        private readonly HttpClient _client;
        private readonly DataBaseContext _context;
        public BenhNhanController(HttpClient client,DataBaseContext context) 
        {
            _client= client;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getBNbyId(string mabn)
        {
            string apiUrl = $"https://hsoftapi.bvtn.org.vn/api/upd_hsoft_benhnhan/?ip=192.168.0.75&idbv=79025&mabn={mabn}";
            try
            {
                HttpResponseMessage response = await _client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode(); // Throw an exception if the request wasn't successful

                string responseBody = await response.Content.ReadAsStringAsync();
                return Ok(responseBody);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public IEnumerable<BenhNhan> GetBN_theophong(int phong)
        {
            var data = _context.BenhNhan
                                        .Include(p => p.phong)
                                        .Include(p => p.phong.khoa)
                                        .Include(p => p.phong.khoa.khu)
                                        .Where(p => p.id_phong == phong&&p.thoigian.Date == DateTime.Now.Date)
                                        .ToList();
            return data;
        }
    }
}
