using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DangKy_API.Models
{
	public class phong
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		public string name { get; set; }

		public string sceensize { get; set; }

		public string scrolltime { get; set; }
        public int id_khoa { get; set; }

        [ForeignKey("id_khoa")]
        public Khoa khoa { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<BenhNhan> thongTinKhamBenh { get; set; }
    }
}
