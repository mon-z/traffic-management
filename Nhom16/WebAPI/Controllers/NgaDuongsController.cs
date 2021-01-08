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
using DataRepository.Context;
using DataRepository.entity;

namespace WebAPI.Controllers
{
    public class NgaDuongsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/NgaDuongs
        public IQueryable<NgaDuong> GetNgaDuong()
        {
            return db.NgaDuong;
        }

        // GET: api/NgaDuongs/5
        [ResponseType(typeof(NgaDuong))]
        public IHttpActionResult GetNgaDuong(int id)
        {
            NgaDuong ngaDuong = db.NgaDuong.Find(id);
            if (ngaDuong == null)
            {
                return NotFound();
            }

            return Ok(ngaDuong);
        }

        // PUT: api/NgaDuongs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNgaDuong(int id, NgaDuong ngaDuong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ngaDuong.ma_nga_duong)
            {
                return BadRequest();
            }

            db.Entry(ngaDuong).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NgaDuongExists(id))
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

        // POST: api/NgaDuongs
        [ResponseType(typeof(NgaDuong))]
        public IHttpActionResult PostNgaDuong(NgaDuong ngaDuong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NgaDuong.Add(ngaDuong);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ngaDuong.ma_nga_duong }, ngaDuong);
        }

        // DELETE: api/NgaDuongs/5
        [ResponseType(typeof(NgaDuong))]
        public IHttpActionResult DeleteNgaDuong(int id)
        {
            NgaDuong ngaDuong = db.NgaDuong.Find(id);
            if (ngaDuong == null)
            {
                return NotFound();
            }

            db.NgaDuong.Remove(ngaDuong);
            db.SaveChanges();

            return Ok(ngaDuong);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NgaDuongExists(int id)
        {
            return db.NgaDuong.Count(e => e.ma_nga_duong == id) > 0;
        }
    }
}