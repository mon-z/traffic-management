using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    class ViPhamDetails
    {
		public int ma_vi_pham { get; set; }
		public int tien_phat_them { get; set; }
		public int tong_tien_phat { get; set; }
		public DateTime thoi_gian_vi_pham { get; set; }
		public DateTime thoi_gian_xu_phat { get; set; }
		public byte flag_da_nop_phat { get; set; }

		public string nguoi_vi_pham { get; set; }
		public string nguoi_xu_phat { get; set; }
		public string dia_diem_vi_pham { get; set; }
		public string xe_vi_pham { get; set; }
		public string noi_giam_giu_xe { get; set; }

		public virtual ICollection<LuatDetail> LuatViPhamList { get; set; } = new HashSet<LuatDetail>();
	}
}
