using DangKy_API.Models;
using DangKy_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace DangKy_API.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    [Consumes("application/json")]

    public class KhuController : ControllerBase
    {

        private readonly DataBaseContext _context;
        private readonly IGioiTinh _GTSvc;
        private readonly HttpClient _client;
        public KhuController(DataBaseContext context, IGioiTinh GTSvc, HttpClient client)
        {
            _context = context;
            _GTSvc = GTSvc;
            _client = client;
        }

        [HttpGet]
        public IEnumerable<Khu> Get()
        {
            List<Khu> data = _context.Khu.ToList();
            return data;
        }

        [HttpGet("{id}")]
        public IEnumerable<Khu> Get(int id)
        {
            List<Khu> data = _context.Khu.Where(p => p.id == id).ToList();
            return data;
        }

        [HttpPost]
        public void Post([FromBody] Khu value)
        {
            _context.Khu.Add(value);
            _context.SaveChanges();
        }
    }
}
