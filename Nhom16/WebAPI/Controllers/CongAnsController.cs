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
using DataRepository.Context;
using DataRepository.entity;

namespace WebAPI.Controllers
{
    public class CongAnsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/CongAns
        public IQueryable<CongAn> GetCongAns()
        {
            return db.CongAn;
        }

        // GET: api/CongAns/5
        [ResponseType(typeof(CongAn))]
        public IHttpActionResult GetCongAn(int id)
        {
            CongAn congAn = db.CongAn.Find(id);
            if (congAn == null)
            {
                return NotFound();
            }

            return Ok(congAn);
        }

        // PUT: api/CongAns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCongAn(int id, CongAn congAn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != congAn.ma_cong_an)
            {
                return BadRequest();
            }

            db.Entry(congAn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongAnExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CongAns
        [ResponseType(typeof(CongAn))]
        public IHttpActionResult PostCongAn(CongAn congAn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CongAn.Add(congAn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = congAn.ma_cong_an }, congAn);
        }

        // DELETE: api/CongAns/5
        [ResponseType(typeof(CongAn))]
        public IHttpActionResult DeleteCongAn(int id)
        {
            CongAn congAn = db.CongAn.Find(id);
            if (congAn == null)
            {
                return NotFound();
            }

            db.CongAn.Remove(congAn);
            db.SaveChanges();

            return Ok(congAn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CongAnExists(int id)
        {
            return db.CongAn.Count(e => e.ma_cong_an == id) > 0;
        }
    }
}