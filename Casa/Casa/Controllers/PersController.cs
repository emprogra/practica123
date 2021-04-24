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
using Casa.Models;

namespace Casa.Controllers
{
    public class PersController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Pers
        [Authorize]
        public IQueryable<Pers> GetPers()
        {
            return db.Pers;
        }

        // GET: api/Pers/5
        [Authorize]
        [ResponseType(typeof(Pers))]
        public IHttpActionResult GetPers(int id)
        {
            Pers pers = db.Pers.Find(id);
            if (pers == null)
            {
                return NotFound();
            }

            return Ok(pers);
        }

        // PUT: api/Pers/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPers(int id, Pers pers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pers.PerosnId)
            {
                return BadRequest();
            }

            db.Entry(pers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersExists(id))
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

        // POST: api/Pers
        [Authorize]
        [ResponseType(typeof(Pers))]
        public IHttpActionResult PostPers(Pers pers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pers.Add(pers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pers.PerosnId }, pers);
        }

        // DELETE: api/Pers/5
        [Authorize]
        [ResponseType(typeof(Pers))]
        public IHttpActionResult DeletePers(int id)
        {
            Pers pers = db.Pers.Find(id);
            if (pers == null)
            {
                return NotFound();
            }

            db.Pers.Remove(pers);
            db.SaveChanges();

            return Ok(pers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersExists(int id)
        {
            return db.Pers.Count(e => e.PerosnId == id) > 0;
        }
    }
}