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
    public class DanDangKiesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/DanDangKies
        public IQueryable<DanDangKy> GetDanDangKies()
        {
            return db.DanDangKies;
        }

        // GET: api/DanDangKies/5
        [ResponseType(typeof(DanDangKy))]
        public IHttpActionResult GetDanDangKy(int id)
        {
            DanDangKy danDangKy = db.DanDangKies.Find(id);
            if (danDangKy == null)
            {
                return NotFound();
            }

            return Ok(danDangKy);
        }

        // PUT: api/DanDangKies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDanDangKy(int id, DanDangKy danDangKy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != danDangKy.ma_dang_ky)
            {
                return BadRequest();
            }

            db.Entry(danDangKy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanDangKyExists(id))
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

        // POST: api/DanDangKies
        [ResponseType(typeof(DanDangKy))]
        public IHttpActionResult PostDanDangKy(DanDangKy danDangKy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DanDangKies.Add(danDangKy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = danDangKy.ma_dang_ky }, danDangKy);
        }

        // DELETE: api/DanDangKies/5
        [ResponseType(typeof(DanDangKy))]
        public IHttpActionResult DeleteDanDangKy(int id)
        {
            DanDangKy danDangKy = db.DanDangKies.Find(id);
            if (danDangKy == null)
            {
                return NotFound();
            }

            db.DanDangKies.Remove(danDangKy);
            db.SaveChanges();

            return Ok(danDangKy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DanDangKyExists(int id)
        {
            return db.DanDangKies.Count(e => e.ma_dang_ky == id) > 0;
        }
    }
}