using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BenhVienThongNhat_DangKy.Models.View_Models
{
    public class BenhNhanViewModel : BenhNhan
    {
        [Required(ErrorMessage ="Vui lòng chọn khoa")]
        public int id_khoa { get; set; }

        public int id_khu { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn Phòng")]

        public List<int> phongs { get; set; }
    }
}
