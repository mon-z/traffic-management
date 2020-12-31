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
    public class DoiChuXesController : ApiController
    {
        private ChotGTContext db = new ChotGTContext();

        // GET: api/DoiChuXes
        public IQueryable<DoiChuXe> GetDoiChuXes()
        {
            return db.DoiChuXes;
        }

        // GET: api/DoiChuXes/5
        [ResponseType(typeof(DoiChuXe))]
        public IHttpActionResult GetDoiChuXe(int id)
        {
            DoiChuXe doiChuXe = db.DoiChuXes.Find(id);
            if (doiChuXe == null)
            {
                return NotFound();
            }

            return Ok(doiChuXe);
        }

        // PUT: api/DoiChuXes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoiChuXe(int id, DoiChuXe doiChuXe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doiChuXe.ma_dang_ky)
            {
                return BadRequest();
            }

            db.Entry(doiChuXe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoiChuXeExists(id))
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

        // POST: api/DoiChuXes
        [ResponseType(typeof(DoiChuXe))]
        public IHttpActionResult PostDoiChuXe(DoiChuXe doiChuXe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DoiChuXes.Add(doiChuXe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = doiChuXe.ma_dang_ky }, doiChuXe);
        }

        // DELETE: api/DoiChuXes/5
        [ResponseType(typeof(DoiChuXe))]
        public IHttpActionResult DeleteDoiChuXe(int id)
        {
            DoiChuXe doiChuXe = db.DoiChuXes.Find(id);
            if (doiChuXe == null)
            {
                return NotFound();
            }

            db.DoiChuXes.Remove(doiChuXe);
            db.SaveChanges();

            return Ok(doiChuXe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoiChuXeExists(int id)
        {
            return db.DoiChuXes.Count(e => e.ma_dang_ky == id) > 0;
        }
    }
}