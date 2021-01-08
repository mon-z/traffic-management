using DataRepository;
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
        private ChotGTContext db = new ChotGTContext();

        [ResponseType(typeof(ChotGiaoThongDetail))]
        public IHttpActionResult GetChotGTDetail(int id)
        {
            List<NgaDuong> ngaDuong = (from nd in db.NgaDuong where nd.ma_chot_GT == id select nd).ToList();
            
            ChotGiaoThongDetail chotGiaoThongDetail = new ChotGiaoThongDetail();
            chotGiaoThongDetail.ngaDuongs = ngaDuong;
            foreach(var ctduong in chotGiaoThongDetail.ngaDuongs)
            {
                ctduong.cTDens = (from ct in db.CTDenGiaoThong where ct.ma_nga_duong == ctduong.ma_nga_duong select ct).ToList();
            }    
            return Ok(chotGiaoThongDetail);
        }

        

    }
}
