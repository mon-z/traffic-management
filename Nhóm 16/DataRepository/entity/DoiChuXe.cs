using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.entity
{
    public class DoiChuXe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ma_dang_ky { get; set; }
        public DateTime ngay_chuyen_nhuong { get; set; }

        public string bien_so_xe { get; set; }
        public int chu_xe_cu { get; set; }
        public int chu_xe_moi { get; set; }
        public int nguoi_duyet { get; set; }
    }
}
