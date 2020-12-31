using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.entity
{
    public class PhieuNopPhat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ma_phieu { get; set; }
        public byte flag_ship { get; set; }
        public string dia_chi_ship { get; set; }
        public DateTime ngay_nop_phat { get; set; }
        public byte flag_da_nhan_xe { get; set; }

        public int ma_vi_pham { get; set; }

    }
}
