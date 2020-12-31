using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.entity
{
    public class DonCongAn
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ma_don_cong_an { get; set; }
        public string ten_don_cong_an { get; set; }
        public string dia_chi { get; set; }



    }
}
