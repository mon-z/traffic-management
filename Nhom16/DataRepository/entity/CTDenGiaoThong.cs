using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class CTDenGiaoThong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] 
        public int ma_ct_den { get; set; }
        public int do_ { get; set; }
        public int xanh { get; set; }
        public int vang { get; set; }

        public int ma_den { get; set; }
        public int ma_nga_duong { get; set; }

        public  string link { get; set; }


        //public virtual DenGiaoThong Den { get; set; }
        //public virtual NgaDuong Nga_Duong { get; set; }
    }
}
