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
    public class TraCuuThongTinsController : ApiController
    {
        private ChotGTContext db = new ChotGTContext();

        // GET: api/TraCuuThongTins
        public IQueryable<TraCuuThongTin> GetTraCuuThongTin()
        {
            return db.TraCuuThongTin;
        }

        // GET: api/TraCuuThongTins/5
        [ResponseType(typeof(TraCuuThongTin))]
        public IHttpActionResult GetTraCuuThongTin(int id)
        {
            TraCuuThongTin traCuuThongTin = db.TraCuuThongTin.Find(id);
            if (traCuuThongTin == null)
            {
                return NotFound();
            }

            return Ok(traCuuThongTin);
        }

        // PUT: api/TraCuuThongTins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTraCuuThongTin(int id, TraCuuThongTin traCuuThongTin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != traCuuThongTin.MaTraCuu)
            {
                return BadRequest();
            }

            db.Entry(traCuuThongTin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraCuuThongTinExists(id))
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

        // POST: api/TraCuuThongTins
        [ResponseType(typeof(TraCuuThongTin))]
        public IHttpActionResult PostTraCuuThongTin(TraCuuThongTin traCuuThongTin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TraCuuThongTin.Add(traCuuThongTin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = traCuuThongTin.MaTraCuu }, traCuuThongTin);
        }

        // DELETE: api/TraCuuThongTins/5
        [ResponseType(typeof(TraCuuThongTin))]
        public IHttpActionResult DeleteTraCuuThongTin(int id)
        {
            TraCuuThongTin traCuuThongTin = db.TraCuuThongTin.Find(id);
            if (traCuuThongTin == null)
            {
                return NotFound();
            }

            db.TraCuuThongTin.Remove(traCuuThongTin);
            db.SaveChanges();

            return Ok(traCuuThongTin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TraCuuThongTinExists(int id)
        {
            return db.TraCuuThongTin.Count(e => e.MaTraCuu == id) > 0;
        }
    }
}