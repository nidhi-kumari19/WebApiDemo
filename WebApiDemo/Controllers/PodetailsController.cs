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
    public class PodetailsController : ApiController
    {
        private PODbEntities db = new PODbEntities();

        // GET: api/Podetails
        public IQueryable<Podetail> GetPodetails()
        {
            return db.Podetails;
        }

        // GET: api/Podetails/5
        [ResponseType(typeof(Podetail))]
        public IHttpActionResult GetPodetail(string id)
        {
            Podetail podetail = db.Podetails.Find(id);
            if (podetail == null)
            {
                return NotFound();
            }

            return Ok(podetail);
        }

        // PUT: api/Podetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPodetail(string id, Podetail podetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != podetail.pono)
            {
                return BadRequest();
            }

            db.Entry(podetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PodetailExists(id))
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

        // POST: api/Podetails
        [ResponseType(typeof(Podetail))]
        public IHttpActionResult PostPodetail(Podetail podetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Podetails.Add(podetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PodetailExists(podetail.pono))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = podetail.pono }, podetail);
        }

        // DELETE: api/Podetails/5
        [ResponseType(typeof(Podetail))]
        public IHttpActionResult DeletePodetail(string id)
        {
            Podetail podetail = db.Podetails.Find(id);
            if (podetail == null)
            {
                return NotFound();
            }

            db.Podetails.Remove(podetail);
            db.SaveChanges();

            return Ok(podetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PodetailExists(string id)
        {
            return db.Podetails.Count(e => e.pono == id) > 0;
        }
    }
}