using DangKy_API.Models;
using DangKy_API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DangKy_API.Controllers
{

    [Route("api/[Controller]/[action]")]
    [ApiController]
    [Consumes("application/json")]
    public class PhongController : ControllerBase
    {
      

        private readonly DataBaseContext _context;
        private readonly HttpClient _client;
        public PhongController(DataBaseContext context, HttpClient client)
        {
            _context = context;
            _client = client;
        }

        [HttpGet]
        public IEnumerable<phong> Get()
        {
            List<phong> data = _context.Phong
                                    .Include(p =>p.khoa)
                                    .Include(p =>p.khoa.khu)
                                    .ToList();
            return data;
        }

        [HttpGet("{id}")]
        public IEnumerable<phong> Get(int id)
        {
            List<phong> data = _context.Phong.Where(p => p.id == id).ToList();
            return data;
        }

        [HttpPost]
        public void Post([FromBody] phong value)
        {
            _context.Phong.Add(value);
            _context.SaveChanges();
        }
    }
}
