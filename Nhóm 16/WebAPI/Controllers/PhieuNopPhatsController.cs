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
    public class PhieuNopPhatsController : ApiController
    {
        private ChotGTContext db = new ChotGTContext();

        // GET: api/PhieuNopPhats
        public IQueryable<PhieuNopPhat> GetPhieuNopPhats()
        {
            return db.PhieuNopPhats;
        }

        // GET: api/PhieuNopPhats/5
        [ResponseType(typeof(PhieuNopPhat))]
        public IHttpActionResult GetPhieuNopPhat(int id)
        {
            PhieuNopPhat phieuNopPhat = db.PhieuNopPhats.Find(id);
            if (phieuNopPhat == null)
            {
                return NotFound();
            }

            return Ok(phieuNopPhat);
        }

        // PUT: api/PhieuNopPhats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhieuNopPhat(int id, PhieuNopPhat phieuNopPhat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phieuNopPhat.ma_phieu)
            {
                return BadRequest();
            }

            db.Entry(phieuNopPhat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuNopPhatExists(id))
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

        // POST: api/PhieuNopPhats
        [ResponseType(typeof(PhieuNopPhat))]
        public IHttpActionResult PostPhieuNopPhat(PhieuNopPhat phieuNopPhat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhieuNopPhats.Add(phieuNopPhat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phieuNopPhat.ma_phieu }, phieuNopPhat);
        }

        // DELETE: api/PhieuNopPhats/5
        [ResponseType(typeof(PhieuNopPhat))]
        public IHttpActionResult DeletePhieuNopPhat(int id)
        {
            PhieuNopPhat phieuNopPhat = db.PhieuNopPhats.Find(id);
            if (phieuNopPhat == null)
            {
                return NotFound();
            }

            db.PhieuNopPhats.Remove(phieuNopPhat);
            db.SaveChanges();

            return Ok(phieuNopPhat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhieuNopPhatExists(int id)
        {
            return db.PhieuNopPhats.Count(e => e.ma_phieu == id) > 0;
        }
    }
}