using DangKy_API.Models;
using DangKy_API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace DangKy_API.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    [Consumes("application/json")]
    public class KhoaController : Controller
    {
        private readonly DataBaseContext _context;
        private readonly HttpClient _client;
        public KhoaController(DataBaseContext context, HttpClient client)
        {
            _context = context;
            _client = client;
        }

        [HttpGet]
        public IEnumerable<Khoa> Get()
        {
            List<Khoa> data = _context.Khoa.ToList();
            return data;
        }

        [HttpGet("{id}")]
        public IEnumerable<Khoa> Get(int id)
        {
            List<Khoa> data = _context.Khoa.Where(p => p.id == id).ToList();
            return data;
        }

        [HttpPost]
        public void Post([FromBody] Khoa value)
        {
            _context.Khoa.Add(value);
            _context.SaveChanges();
        }
    }
}
