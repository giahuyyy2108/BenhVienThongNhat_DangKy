using DangKy_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace DangKy_API.Service
{
	public interface IGioiTinh
	{
		Task UpdateGTPatch(int id, JsonPatchDocument gt);
	}

	public class GioiTinhSvc : IGioiTinh
	{
		private readonly DataBaseContext _context;
		public GioiTinhSvc(DataBaseContext context)
		{
			_context= context;
		}
		public async Task UpdateGTPatch(int id, JsonPatchDocument model)
		{
			var gt = await _context.GioiTinh.FindAsync(id);
			if(gt!=null)
			{
				model.ApplyTo(gt);
				await _context.SaveChangesAsync();
			}
		}
	}
}
