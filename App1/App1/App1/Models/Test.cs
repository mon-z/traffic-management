using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    class Test
    {
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

		public virtual ICollection<Luat> Authors { get; set; } = new HashSet<Luat>();
	}
}
