using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class TraCuuThongTin
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaTraCuu { get; set; }
        public DateTime ThoiGian { get; set; }
        public string images { get; set; }

        public int ma_duong { get; set; }

        //public virtual Duong Duong { get; set; }
        
    }
}
