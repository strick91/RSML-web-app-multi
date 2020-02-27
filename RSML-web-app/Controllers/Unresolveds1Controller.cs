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
using RSML_web_app.Data;
using RSML_web_app.Models;

namespace RSML_web_app.Controllers
{
    public class Unresolveds1Controller : ApiController
    {
        private RSML_web_appdbContext db = new RSML_web_appdbContext();

        // GET: api/Unresolveds1
        public IQueryable<Unresolved> GetUnresolveds()
        {
            return db.Unresolveds;
        }

        // GET: api/Unresolveds1/5
        [ResponseType(typeof(Unresolved))]
        public IHttpActionResult GetUnresolved(int id)
        {
            Unresolved unresolved = db.Unresolveds.Find(id);
            if (unresolved == null)
            {
                return NotFound();
            }

            return Ok(unresolved);
        }

        // PUT: api/Unresolveds1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUnresolved(int id, Unresolved unresolved)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unresolved.Id)
            {
                return BadRequest();
            }

            db.Entry(unresolved).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnresolvedExists(id))
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

        // POST: api/Unresolveds1
        [ResponseType(typeof(Unresolved))]
        public IHttpActionResult PostUnresolved(Unresolved unresolved)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Unresolveds.Add(unresolved);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unresolved.Id }, unresolved);
        }

        // DELETE: api/Unresolveds1/5
        [ResponseType(typeof(Unresolved))]
        public IHttpActionResult DeleteUnresolved(int id)
        {
            Unresolved unresolved = db.Unresolveds.Find(id);
            if (unresolved == null)
            {
                return NotFound();
            }

            db.Unresolveds.Remove(unresolved);
            db.SaveChanges();

            return Ok(unresolved);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnresolvedExists(int id)
        {
            return db.Unresolveds.Count(e => e.Id == id) > 0;
        }
    }
}