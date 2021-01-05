using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class DenGiaoThong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ma_den { get; set; }
        public string ten_den { get; set; }

        //public virtual ICollection<CTDenGiaoThong> Den { get; set; }
    }
}
