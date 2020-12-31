using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.entity
{
    public class ViPhamLuat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        
        public int ma_vi_pham_luat { get; set; }
        public string mo_ta_vi_pham { get; set; }

        public int ma_luat { get; set; }
        public int ma_vi_pham { get; set; }
    }
}
