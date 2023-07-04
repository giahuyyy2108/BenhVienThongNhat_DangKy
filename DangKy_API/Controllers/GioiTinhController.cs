using DangKy_API.Models;
using DangKy_API.Service;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DangKy_API.Controllers
{

    [Route("api/[Controller]")]

    [Consumes("application/json")]
    [ApiController]
	public class GioiTinhController : ControllerBase
	{
		private readonly DataBaseContext _context;
		private readonly IGioiTinh _GTSvc;
		private readonly HttpClient _client;
		public GioiTinhController (DataBaseContext context,IGioiTinh GTSvc,HttpClient client)
		{
			_context= context;	
			_GTSvc= GTSvc;
			_client= client;
		}

		// GET: api/<GioiTinh>
		[HttpGet]
		//[Produces("application/xml")]
		public IEnumerable<GioiTinh> Get()
		{
			List<GioiTinh> data =  _context.GioiTinh.ToList();
			return data;
		}
		[HttpGet]
		[Route("/api/Get-gt")]
		//[Produces("application/xml")]
		public IEnumerable<GioiTinh> Get(int id)
		{
			var data = _context.GioiTinh.Where(p=>p.id == id).ToList();

			return data;
		}

		// POST api/<GioiTinh>
		[HttpPost]
		public void Post([FromBody] GioiTinh value)
		{
			_context.GioiTinh.Add(value);
			_context.SaveChanges();
		}

		// PUT api/<GioiTinh>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] GioiTinh value)
		{

			var data = _context.GioiTinh.Find(id);
			data.name = value.name;
			_context.GioiTinh.Update(data);
			_context.SaveChanges();
		}


		[HttpPatch("{id}")]
		public async Task<IActionResult> Patch([FromBody] JsonPatchDocument value, [FromRoute] int id)
		{

			await _GTSvc.UpdateGTPatch(id, value);
			return Ok();
		}


		// DELETE api/<GioiTinh>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var data = _context.GioiTinh.Find(id);
			_context.GioiTinh.Remove(data);
			_context.SaveChanges();
		}

		
    }
}
