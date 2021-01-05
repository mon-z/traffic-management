using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class Camera_Backup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ma_backup { get; set; }
        public DateTime thoi_gian { get; set; }
        public string images { get; set; }

        public int ma_camera { get; set; }

        public virtual Duong Duong { get; set; }

        //public virtual Camera Camera { get; set; }
    }
}
