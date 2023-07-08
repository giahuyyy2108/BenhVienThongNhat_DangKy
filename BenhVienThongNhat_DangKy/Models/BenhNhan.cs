using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BenhVienThongNhat_DangKy.Models
{
	public class BenhNhan
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		[StringLength(100)]
		[Required(ErrorMessage = "Phải nhập đầy đủ thông tin")]
		public string hoten { get; set; }

		[StringLength(7)]
		public string namsinh { get; set; }

		[Required(ErrorMessage = "Phải nhập đầy đủ thông tin")]
		public string mabn { get; set; }
		public string sothe { get; set; }

        [Required(ErrorMessage = "Phải nhập đầy đủ thông tin")]
        public int id_gioitinh { get; set; }

		[ForeignKey("id_gioitinh")]
		public GioiTinh gioiTinh { get; set; }

        [Required(ErrorMessage = "Phải nhập đầy đủ thông tin")]
        public int? id_phong { get; set; }

		[ForeignKey("id_phong")]
		public phong phong { get; set; }

		public DateTime thoigian { get; set; }

	}
}
