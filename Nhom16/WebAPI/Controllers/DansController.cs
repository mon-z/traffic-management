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
    public class DansController : ApiController
    {
        private ChotGTContext db = new ChotGTContext();

        // GET: api/Dans
        public IQueryable<Dan> GetDans()
        {
            return db.Dans;
        }

        // GET: api/Dans/5
        [ResponseType(typeof(Dan))]
        public IHttpActionResult GetDan(int id)
        {
            Dan dan = db.Dans.Find(id);
            if (dan == null)
            {
                return NotFound();
            }
            return Ok(dan);
        }

        public IHttpActionResult GetTenDan(int idDan)
        {
            Dan dan = db.Dans.Find(idDan);
            if (dan == null)
            {
                return NotFound();
            }
            return Ok(dan.ho_ten);
        }

        // GET: api/Dans/5
        [ResponseType(typeof(Dan))]
        public IHttpActionResult GetDanLogin(string email, string password)
        {
            Dan dan = db.Dans.Where(d => d.email == email).FirstOrDefault();
            if (dan == null || dan.pass_word != password)
            {
                return NotFound();
            }

            return Ok(dan);
        }

        // PUT: api/Dans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDan(int id, Dan dan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dan.ma_dan)
            {
                return BadRequest();
            }

            db.Entry(dan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanExists(id))
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

        // POST: api/Dans
        [ResponseType(typeof(Dan))]
        public IHttpActionResult PostDan(Dan dan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dans.Add(dan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dan.ma_dan }, dan);
        }

        // DELETE: api/Dans/5
        [ResponseType(typeof(Dan))]
        public IHttpActionResult DeleteDan(int id)
        {
            Dan dan = db.Dans.Find(id);
            if (dan == null)
            {
                return NotFound();
            }

            db.Dans.Remove(dan);
            db.SaveChanges();

            return Ok(dan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DanExists(int id)
        {
            return db.Dans.Count(e => e.ma_dan == id) > 0;
        }
    }
}