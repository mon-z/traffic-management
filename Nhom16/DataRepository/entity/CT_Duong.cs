using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class CT_Duong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ma_CT_duong { get; set; }
        public string phuong { get; set; }
        public string quan { get; set; }

        public int ma_duong { get; set; }

        //public virtual Duong Duong { get; set; }
        //public virtual ICollection<NgaDuong> CTDuong { get; set; }
    }
}
