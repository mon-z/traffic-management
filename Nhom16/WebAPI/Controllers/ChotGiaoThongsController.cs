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
    public class ChotGiaoThongsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/ChotGiaoThongs
        public IQueryable<ChotGiaoThong> GetChotGiaoThong()
        {
            return db.ChotGiaoThong;
        }

        // GET: api/ChotGiaoThongs/5
        [ResponseType(typeof(ChotGiaoThong))]
        public IHttpActionResult GetChotGiaoThong(int id)
        {
            ChotGiaoThong chotGiaoThong = db.ChotGiaoThong.Find(id);
            if (chotGiaoThong == null)
            {
                return NotFound();
            }

            return Ok(chotGiaoThong);
        }

        // PUT: api/ChotGiaoThongs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChotGiaoThong(int id, ChotGiaoThong chotGiaoThong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chotGiaoThong.ma_chotGT)
            {
                return BadRequest();
            }

            db.Entry(chotGiaoThong).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChotGiaoThongExists(id))
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

        // POST: api/ChotGiaoThongs
        [ResponseType(typeof(ChotGiaoThong))]
        public IHttpActionResult PostChotGiaoThong(ChotGiaoThong chotGiaoThong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChotGiaoThong.Add(chotGiaoThong);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chotGiaoThong.ma_chotGT }, chotGiaoThong);
        }

        // DELETE: api/ChotGiaoThongs/5
        [ResponseType(typeof(ChotGiaoThong))]
        public IHttpActionResult DeleteChotGiaoThong(int id)
        {
            ChotGiaoThong chotGiaoThong = db.ChotGiaoThong.Find(id);
            if (chotGiaoThong == null)
            {
                return NotFound();
            }

            db.ChotGiaoThong.Remove(chotGiaoThong);
            db.SaveChanges();

            return Ok(chotGiaoThong);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChotGiaoThongExists(int id)
        {
            return db.ChotGiaoThong.Count(e => e.ma_chotGT == id) > 0;
        }
    }
}