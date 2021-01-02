using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataRepository.entity;

namespace WebAPI.Models
{
    public class ThongtinModel
    {
        public IList<Detail> details = new List<Detail>();
        public class Detail
        {
            public int camera_id { get; set; }
            public string image { get; set; }
            public DateTime? thoi_gian { get; set; }
            public string TenDuong { get; set; }
        }
    }
}