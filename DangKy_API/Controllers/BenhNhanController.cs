using Microsoft.AspNetCore.Mvc;
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
        public BenhNhanController(HttpClient client) 
        {
            _client= client;
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
    }
}
