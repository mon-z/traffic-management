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
    public class DenGiaoThongsController : ApiController
    {
        private ChotGTContext db = new ChotGTContext();

        // GET: api/DenGiaoThongs
        public IQueryable<DenGiaoThong> GetDenGiaoThong()
        {
            return db.DenGiaoThong;
        }

        // GET: api/DenGiaoThongs/5
        [ResponseType(typeof(DenGiaoThong))]
        public IHttpActionResult GetDenGiaoThong(int id)
        {
            DenGiaoThong denGiaoThong = db.DenGiaoThong.Find(id);
            if (denGiaoThong == null)
            {
                return NotFound();
            }

            return Ok(denGiaoThong);
        }

        // PUT: api/DenGiaoThongs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDenGiaoThong(int id, DenGiaoThong denGiaoThong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != denGiaoThong.ma_den)
            {
                return BadRequest();
            }

            db.Entry(denGiaoThong).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DenGiaoThongExists(id))
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

        // POST: api/DenGiaoThongs
        [ResponseType(typeof(DenGiaoThong))]
        public IHttpActionResult PostDenGiaoThong(DenGiaoThong denGiaoThong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DenGiaoThong.Add(denGiaoThong);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = denGiaoThong.ma_den }, denGiaoThong);
        }

        // DELETE: api/DenGiaoThongs/5
        [ResponseType(typeof(DenGiaoThong))]
        public IHttpActionResult DeleteDenGiaoThong(int id)
        {
            DenGiaoThong denGiaoThong = db.DenGiaoThong.Find(id);
            if (denGiaoThong == null)
            {
                return NotFound();
            }

            db.DenGiaoThong.Remove(denGiaoThong);
            db.SaveChanges();

            return Ok(denGiaoThong);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DenGiaoThongExists(int id)
        {
            return db.DenGiaoThong.Count(e => e.ma_den == id) > 0;
        }
    }
}