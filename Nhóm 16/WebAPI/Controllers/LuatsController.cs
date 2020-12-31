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
using DataRepository.entity;

namespace WebAPI.Controllers
{
    public class LuatsController : ApiController
    {
        private ChotGTContext db = new ChotGTContext();

        // GET: api/Luats
        public IQueryable<Luat> GetLuats()
        {
            return db.Luats;
        }

        // GET: api/Luats/5
        [ResponseType(typeof(Luat))]
        public IHttpActionResult GetLuat(int id)
        {
            Luat luat = db.Luats.Find(id);
            if (luat == null)
            {
                return NotFound();
            }

            return Ok(luat);
        }

        // PUT: api/Luats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLuat(int id, Luat luat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != luat.ma_luat)
            {
                return BadRequest();
            }

            db.Entry(luat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LuatExists(id))
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

        // POST: api/Luats
        [ResponseType(typeof(Luat))]
        public IHttpActionResult PostLuat(Luat luat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Luats.Add(luat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = luat.ma_luat }, luat);
        }

        // DELETE: api/Luats/5
        [ResponseType(typeof(Luat))]
        public IHttpActionResult DeleteLuat(int id)
        {
            Luat luat = db.Luats.Find(id);
            if (luat == null)
            {
                return NotFound();
            }

            db.Luats.Remove(luat);
            db.SaveChanges();

            return Ok(luat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LuatExists(int id)
        {
            return db.Luats.Count(e => e.ma_luat == id) > 0;
        }
    }
}