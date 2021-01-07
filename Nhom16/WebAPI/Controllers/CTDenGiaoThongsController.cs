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
    public class CTDenGiaoThongsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/CTDenGiaoThongs
        public IQueryable<CTDenGiaoThong> GetCTDenGiaoThong()
        {
            return db.CTDenGiaoThong;
        }

        // GET: api/CTDenGiaoThongs/5
        [ResponseType(typeof(CTDenGiaoThong))]
        public IHttpActionResult GetCTDenGiaoThong(int id)
        {
            CTDenGiaoThong cTDenGiaoThong = db.CTDenGiaoThong.Find(id);
            if (cTDenGiaoThong == null)
            {
                return NotFound();
            }

            return Ok(cTDenGiaoThong);
        }

        // PUT: api/CTDenGiaoThongs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCTDenGiaoThong(int id, CTDenGiaoThong cTDenGiaoThong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cTDenGiaoThong.ma_ct_den)
            {
                return BadRequest();
            }

            db.Entry(cTDenGiaoThong).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CTDenGiaoThongExists(id))
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

        // POST: api/CTDenGiaoThongs
        [ResponseType(typeof(CTDenGiaoThong))]
        public IHttpActionResult PostCTDenGiaoThong(CTDenGiaoThong cTDenGiaoThong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CTDenGiaoThong.Add(cTDenGiaoThong);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cTDenGiaoThong.ma_ct_den }, cTDenGiaoThong);
        }

        // DELETE: api/CTDenGiaoThongs/5
        [ResponseType(typeof(CTDenGiaoThong))]
        public IHttpActionResult DeleteCTDenGiaoThong(int id)
        {
            CTDenGiaoThong cTDenGiaoThong = db.CTDenGiaoThong.Find(id);
            if (cTDenGiaoThong == null)
            {
                return NotFound();
            }

            db.CTDenGiaoThong.Remove(cTDenGiaoThong);
            db.SaveChanges();

            return Ok(cTDenGiaoThong);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CTDenGiaoThongExists(int id)
        {
            return db.CTDenGiaoThong.Count(e => e.ma_ct_den == id) > 0;
        }
    }
}