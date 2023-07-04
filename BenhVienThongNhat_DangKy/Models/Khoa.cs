using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BenhVienThongNhat_DangKy.Models
{
	public class Khoa
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		public string name { get; set; }

		public int id_khu { get; set; }

		[ForeignKey("id_khu")]
		public Khu khu { get; set; }

		[JsonIgnore]
		[IgnoreDataMember]
		public ICollection<phong> phong { get; set; }
	}
}
