using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.entity
{
    public class ViPham
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int ma_vi_pham { get; set; }
		public int tien_phat_them { get; set; }
		public int tong_tien_phat { get; set; }
		public DateTime thoi_gian_vi_pham { get; set; }
		public DateTime thoi_gian_xu_phat { get; set; }
		public byte flag_da_nop_phat { get; set; }

		public int nguoi_vi_pham { get; set; }
		public int nguoi_xu_phat { get; set; }
		public string xe_vi_pham { get; set; }
		public int noi_giam_giu_xe { get; set; }
	}
}
