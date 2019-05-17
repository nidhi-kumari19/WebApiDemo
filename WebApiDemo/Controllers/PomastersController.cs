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
using WebApiDemo;

namespace WebApiDemo.Controllers
{
    public class PomastersController : ApiController
    {
        private PODbEntities db = new PODbEntities();

        // GET: api/Pomasters
        public IQueryable<Pomaster> GetPomasters()
        {
            return db.Pomasters;
        }

        // GET: api/Pomasters/5
        [ResponseType(typeof(Pomaster))]
        public IHttpActionResult GetPomaster(string id)
        {
            Pomaster pomaster = db.Pomasters.Find(id);
            if (pomaster == null)
            {
                return NotFound();
            }

            return Ok(pomaster);
        }

        // PUT: api/Pomasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPomaster(string id, Pomaster pomaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pomaster.pono)
            {
                return BadRequest();
            }

            db.Entry(pomaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PomasterExists(id))
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

        // POST: api/Pomasters
        [ResponseType(typeof(Pomaster))]
        public IHttpActionResult PostPomaster(Pomaster pomaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pomasters.Add(pomaster);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PomasterExists(pomaster.pono))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pomaster.pono }, pomaster);
        }

        // DELETE: api/Pomasters/5
        [ResponseType(typeof(Pomaster))]
        public IHttpActionResult DeletePomaster(string id)
        {
            Pomaster pomaster = db.Pomasters.Find(id);
            if (pomaster == null)
            {
                return NotFound();
            }

            db.Pomasters.Remove(pomaster);
            db.SaveChanges();

            return Ok(pomaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PomasterExists(string id)
        {
            return db.Pomasters.Count(e => e.pono == id) > 0;
        }
    }
}