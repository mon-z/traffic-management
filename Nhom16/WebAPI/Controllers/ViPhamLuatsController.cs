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
    public class ViPhamLuatsController : ApiController
    {
        private ChotGTContext db = new ChotGTContext();

        // GET: api/ViPhamLuats
        public IQueryable<ViPhamLuat> GetViPhamLuats()
        {
            return db.ViPhamLuats;
        }

        // GET: api/ViPhamLuats/5
        [ResponseType(typeof(ViPhamLuat))]
        public IHttpActionResult GetViPhamLuat(int id)
        {
            ViPhamLuat viPhamLuat = db.ViPhamLuats.Find(id);
            if (viPhamLuat == null)
            {
                return NotFound();
            }

            return Ok(viPhamLuat);
        }

        public IQueryable<ViPhamLuat> GetViPhamLuatByVPId(int viPhamId)
        {
            IQueryable<ViPhamLuat> viPhamLuats = db.ViPhamLuats.Where(d => d.ma_vi_pham == viPhamId);
            if (viPhamLuats == null)
            {
                return null;
            }

            return viPhamLuats;
        }

        // PUT: api/ViPhamLuats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViPhamLuat(int id, ViPhamLuat viPhamLuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viPhamLuat.ma_vi_pham_luat)
            {
                return BadRequest();
            }

            db.Entry(viPhamLuat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViPhamLuatExists(id))
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

        // POST: api/ViPhamLuats
        [ResponseType(typeof(ViPhamLuat))]
        public IHttpActionResult PostViPhamLuat(ViPhamLuat viPhamLuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViPhamLuats.Add(viPhamLuat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = viPhamLuat.ma_vi_pham_luat }, viPhamLuat);
        }

        // DELETE: api/ViPhamLuats/5
        [ResponseType(typeof(ViPhamLuat))]
        public IHttpActionResult DeleteViPhamLuat(int id)
        {
            ViPhamLuat viPhamLuat = db.ViPhamLuats.Find(id);
            if (viPhamLuat == null)
            {
                return NotFound();
            }

            db.ViPhamLuats.Remove(viPhamLuat);
            db.SaveChanges();

            return Ok(viPhamLuat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViPhamLuatExists(int id)
        {
            return db.ViPhamLuats.Count(e => e.ma_vi_pham_luat == id) > 0;
        }
    }
}