using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class ChotGiaoThong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int ma_chotGT { get; set; }
        public string ten_chot_GT { get; set; }
        public int edit { get; set; }

       //public virtual ICollection<NgaDuong> ChotGT { get; set; }
    }
}
