using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DangKy_API.Models
{ 
	public class DataBaseContext : DbContext
	{
		public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			base.OnConfiguring(builder);
		}
		protected override void OnModelCreating(ModelBuilder modelbuilder)
		{
			base.OnModelCreating(modelbuilder);

			//foreach (var entityType in modelbuilder.Model.GetEntityTypes())
			//{
			//	var tablbename = entityType.GetTableName();
			//	if (tablbename.StartsWith("AspNet"))
			//	{
			//		entityType.SetTableName(tablbename.Substring(6));
			//	}

			//}

		}

		public  DbSet<GioiTinh> GioiTinh { get; set; }

		public  DbSet<BenhNhan> BenhNhan { get; set; }

		public  DbSet<Khu> Khu { get; set; }

		public  DbSet<Khoa> Khoa { get; set; }

		public  DbSet<phong> Phong { get; set; }
	}
}
