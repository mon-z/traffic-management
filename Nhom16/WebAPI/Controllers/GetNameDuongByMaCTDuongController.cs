using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataRepository.Context;
using DataRepository;
namespace WebAPI.Controllers
{
    public class GetNameDuongByMaCTDuongController : ApiController
    {
        private DataContext db = new DataContext();
        
        [ResponseType(typeof(Duong))]
        public IHttpActionResult GetCongAn(int id)
        {
            
            CT_Duong cT_Duong = db.CT_Duong.Find(id);
            if(cT_Duong != null)
            {
                Duong duong = db.Duong.Find(cT_Duong.ma_duong);
                return Ok(duong);
            }
            else
            { 
                return BadRequest();
            }
        }
    }
}
