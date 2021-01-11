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
    public class ViPhamsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/ViPhams
        public IQueryable<ViPham> GetViPhams()
        {
            return db.ViPhams;
        }

        public IQueryable<ViPham> GetViPhamsByDanId(int danId)
        {
            IQueryable<ViPham> lstViPham = db.ViPhams.Where(d => d.nguoi_vi_pham == danId);
            if (lstViPham == null)
            {
                return null;
            }

            return lstViPham;
        }

        public IQueryable<ViPham> GetViPhamsChuaNopPhatByDanId(int danChuaNopPhatId)
        {
            IQueryable<ViPham> lstViPham = db.ViPhams.Where(d => d.nguoi_vi_pham == danChuaNopPhatId).Where(c => c.flag_da_nop_phat == 0);
            if (lstViPham == null)
            {
                return null;
            }

            return lstViPham;
        }

        // GET: api/ViPhams/5
        [ResponseType(typeof(ViPham))]
        public IHttpActionResult GetViPham(int id)
        {
            ViPham viPham = db.ViPhams.Find(id);
            if (viPham == null)
            {
                return NotFound();
            }
            return Ok(viPham);
        }

        public void Put([FromBody] ViPham altViPham)
        {
            using (var ctx = new DataContext())
            {
                var existingLuat = ctx.ViPhams.Where(s => s.ma_vi_pham == altViPham.ma_vi_pham).FirstOrDefault<ViPham>();

                if (existingLuat != null)
                {
                    existingLuat.flag_da_nop_phat = 1;
                    ctx.SaveChanges();
                }
            }
        }

        // PUT: api/ViPhams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViPham(int id, ViPham viPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viPham.ma_vi_pham)
            {
                return BadRequest();
            }

            db.Entry(viPham).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViPhamExists(id))
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

        // POST: api/ViPhams
        [ResponseType(typeof(ViPham))]
        public IHttpActionResult PostViPham(ViPham viPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViPhams.Add(viPham);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = viPham.ma_vi_pham }, viPham);
        }

        // DELETE: api/ViPhams/5
        [ResponseType(typeof(ViPham))]
        public IHttpActionResult DeleteViPham(int id)
        {
            ViPham viPham = db.ViPhams.Find(id);
            if (viPham == null)
            {
                return NotFound();
            }

            db.ViPhams.Remove(viPham);
            db.SaveChanges();

            return Ok(viPham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViPhamExists(int id)
        {
            return db.ViPhams.Count(e => e.ma_vi_pham == id) > 0;
        }
    }
}