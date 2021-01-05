using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class Camera
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ma_camera { get; set; }
        public string ip_ { get; set; }
        public string images { get; set; }
        public int stt { get; set; }

        public int ma_nga_duong { get; set; }
        public int ma_duong { get; set; }

        //public virtual NgaDuong Nga_Duong { get; set; }
        //public virtual Duong Duong { get; set; }
        //public virtual ICollection<Camera_Backup> Camera_ { get; set; }
    }
}
