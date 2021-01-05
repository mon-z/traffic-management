using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.entity
{
    public class XeDangKy
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int ma_dang_ky { get; set; }
		public string nhan_hieu { get; set; }
		public string loai_phuong_tien { get; set; }
		public string hinh_anh_xe { get; set; }

		public int nguoi_duyet { get; set; }
		public int chu_xe { get; set; }
	}
}
