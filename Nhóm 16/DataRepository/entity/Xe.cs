using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.entity
{
    public class Xe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
		public string bien_so_xe { get; set; }
		public string nhan_hieu { get; set; }
		public string mau_sac { get; set; }
		public string so_khung { get; set; }
		public string loai_phuong_tien { get; set; }
		public string so_may { get; set; }
		public float kich_thuoc_bao { get; set; }
		public float kich_thuoc_thung_hang { get; set; }
		public float khoi_luong_xe { get; set; }
		public float khoi_luong_cho_phep { get; set; }
		public int so_nguoi_cho_phep { get; set; }
		public float khoi_luong_toan_bo_cho_phep { get; set; }
		public DateTime ngay_kiem_dinh { get; set; }
		public string so_ten_GCN { get; set; }
		public string hinh_anh_xe { get; set; }

		public int chu_xe { get; set; }
		public int don_vi_kiem_dinh { get; set; }

	}
}
