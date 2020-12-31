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
    public class XeDangKiesController : ApiController
    {
        private ChotGTContext db = new ChotGTContext();

        // GET: api/XeDangKies
        public IQueryable<XeDangKy> GetXeDangKies()
        {
            return db.XeDangKies;
        }

        // GET: api/XeDangKies/5
        [ResponseType(typeof(XeDangKy))]
        public IHttpActionResult GetXeDangKy(int id)
        {
            XeDangKy xeDangKy = db.XeDangKies.Find(id);
            if (xeDangKy == null)
            {
                return NotFound();
            }

            return Ok(xeDangKy);
        }

        // PUT: api/XeDangKies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutXeDangKy(int id, XeDangKy xeDangKy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != xeDangKy.ma_dang_ky)
            {
                return BadRequest();
            }

            db.Entry(xeDangKy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XeDangKyExists(id))
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

        // POST: api/XeDangKies
        [ResponseType(typeof(XeDangKy))]
        public IHttpActionResult PostXeDangKy(XeDangKy xeDangKy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.XeDangKies.Add(xeDangKy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = xeDangKy.ma_dang_ky }, xeDangKy);
        }

        // DELETE: api/XeDangKies/5
        [ResponseType(typeof(XeDangKy))]
        public IHttpActionResult DeleteXeDangKy(int id)
        {
            XeDangKy xeDangKy = db.XeDangKies.Find(id);
            if (xeDangKy == null)
            {
                return NotFound();
            }

            db.XeDangKies.Remove(xeDangKy);
            db.SaveChanges();

            return Ok(xeDangKy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool XeDangKyExists(int id)
        {
            return db.XeDangKies.Count(e => e.ma_dang_ky == id) > 0;
        }
    }
}