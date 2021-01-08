using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataRepository;
using DataRepository.entity;

namespace WebAPI.Controllers
{
    public class NgaDuongsbyMaChotController : ApiController
    {
        private ChotGTContext db = new ChotGTContext();



        // GET: api/NgaDuongsbyMaChot/5
        [ResponseType(typeof(NgaDuong))]
        public IHttpActionResult GetNgaDuong(int id)
        {
                      
            var ngaDuong =  from nd in db.NgaDuong where nd.ma_chot_GT == id select nd ;

            if (ngaDuong == null)
            {
                return NotFound();
            }

            return Ok(ngaDuong);
        }

    }
}