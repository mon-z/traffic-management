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
    public class DonCongAnsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/DonCongAns
        public IQueryable<DonCongAn> GetDonCongAns()
        {
            return db.DonCongAn;
        }

        // GET: api/DonCongAns/5
        [ResponseType(typeof(DonCongAn))]
        public IHttpActionResult GetDonCongAn(int id)
        {
            DonCongAn donCongAn = db.DonCongAn.Find(id);
            if (donCongAn == null)
            {
                return NotFound();
            }

            return Ok(donCongAn);
        }

        // PUT: api/DonCongAns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonCongAn(int id, DonCongAn donCongAn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donCongAn.ma_don_cong_an)
            {
                return BadRequest();
            }

            db.Entry(donCongAn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonCongAnExists(id))
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

        // POST: api/DonCongAns
        [ResponseType(typeof(DonCongAn))]
        public IHttpActionResult PostDonCongAn(DonCongAn donCongAn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DonCongAn.Add(donCongAn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donCongAn.ma_don_cong_an }, donCongAn);
        }

        // DELETE: api/DonCongAns/5
        [ResponseType(typeof(DonCongAn))]
        public IHttpActionResult DeleteDonCongAn(int id)
        {
            DonCongAn donCongAn = db.DonCongAn.Find(id);
            if (donCongAn == null)
            {
                return NotFound();
            }

            db.DonCongAn.Remove(donCongAn);
            db.SaveChanges();

            return Ok(donCongAn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonCongAnExists(int id)
        {
            return db.DonCongAn.Count(e => e.ma_don_cong_an == id) > 0;
        }
    }
}