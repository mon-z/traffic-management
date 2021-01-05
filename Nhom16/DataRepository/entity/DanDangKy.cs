using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.entity
{
    public class DanDangKy
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int ma_dang_ky { get; set; }
		public string email { get; set; }
		public string pass_word { get; set; }
		public string ho_ten { get; set; }
		public string dia_chi { get; set; }
		public string sdt { get; set; }
		public string cmnd { get; set; }
		public DateTime ngaysinh { get; set; }
		public string gioi_tinh { get; set; }

		public int nguoi_duyet { get; set; }
	}
}
