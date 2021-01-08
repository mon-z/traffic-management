using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class NgaDuong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int ma_nga_duong { get; set; }
        public int stt { get; set; }

        public int ma_chot_GT { get; set; }
        public int ma_CT_duong { get; set; }

        public List<CTDenGiaoThong> cTDens { get; set; }
        //public virtual ChotGiaoThong ChotGT { get; set; }
        //public virtual CT_Duong CTDuong { get; set; }
        //public virtual ICollection<CTDenGiaoThong> Nga_Duong { get; set; }
        //public virtual ICollection<Camera> NgaDuong_ { get; set; }
    }
}
