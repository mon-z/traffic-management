using DataRepository;
using DataRepository.Context;
using DataRepository.entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ChotGiaoThongDetailController : ApiController
    {
        private DataContext db = new DataContext();

        [ResponseType(typeof(ChotGiaoThongDetail))]
        public IHttpActionResult GetChotGTDetail(int id)
        {
            List<NgaDuong> ngaDuong = (from nd in db.NgaDuong where nd.ma_chot_GT == id select nd).ToList();
            
            ChotGiaoThongDetail chotGiaoThongDetail = new ChotGiaoThongDetail();
            chotGiaoThongDetail.ngaDuongs = ngaDuong;
            foreach(var ctduong in chotGiaoThongDetail.ngaDuongs)
            {
                ctduong.cTDens = (from ct in db.CTDenGiaoThong where ct.ma_nga_duong == ctduong.ma_nga_duong select ct).ToList();
                foreach (var Ct in ctduong.cTDens)
                {
                    var den = db.DenGiaoThong.Find(Ct.ma_den);
                    Ct.link = den.link;
                }    
            }    
            return Ok(chotGiaoThongDetail);
        }

        

    }
}
