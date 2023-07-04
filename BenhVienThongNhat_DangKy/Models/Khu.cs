using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BenhVienThongNhat_DangKy.Models
{
	public class Khu
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		public string name { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Khoa> khoa { get; set; }
    }
}
