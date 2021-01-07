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
    public class XesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Xes
        public IQueryable<Xe> GetXes()
        {
            return db.Xes;
        }

        // GET: api/Xes/5
        [ResponseType(typeof(Xe))]
        public IHttpActionResult GetXe(string id)
        {
            Xe xe = db.Xes.Find(id);
            if (xe == null)
            {
                return NotFound();
            }

            return Ok(xe);
        }

        // PUT: api/Xes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutXe(string id, Xe xe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != xe.bien_so_xe)
            {
                return BadRequest();
            }

            db.Entry(xe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XeExists(id))
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

        // POST: api/Xes
        [ResponseType(typeof(Xe))]
        public IHttpActionResult PostXe(Xe xe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Xes.Add(xe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = xe.bien_so_xe }, xe);
        }

        // DELETE: api/Xes/5
        [ResponseType(typeof(Xe))]
        public IHttpActionResult DeleteXe(string id)
        {
            Xe xe = db.Xes.Find(id);
            if (xe == null)
            {
                return NotFound();
            }

            db.Xes.Remove(xe);
            db.SaveChanges();

            return Ok(xe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool XeExists(string id)
        {
            return db.Xes.Count(e => e.bien_so_xe == id) > 0;
        }
    }
}