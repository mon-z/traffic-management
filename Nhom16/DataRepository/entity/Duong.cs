using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class Duong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ma_duong { get; set; }
        public string ten_duong { get; set; }

       //public virtual ICollection<CT_Duong> CTDUONG { get; set; }
        //public virtual ICollection<Camera> Camera { get; set; }
        //public virtual ICollection<TraCuuThongTin> TCTT { get; set; }
    }
}
