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
    public class Resolveds1Controller : ApiController
    {
        private RSML_web_appdbContext db = new RSML_web_appdbContext();

        // GET: api/Resolveds1
        public IQueryable<Resolved> GetResolveds()
        {
            return db.Resolveds;
        }

        // GET: api/Resolveds1/5
        [ResponseType(typeof(Resolved))]
        public IHttpActionResult GetResolved(int id)
        {
            Resolved resolved = db.Resolveds.Find(id);
            if (resolved == null)
            {
                return NotFound();
            }

            return Ok(resolved);
        }

        // PUT: api/Resolveds1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResolved(int id, Resolved resolved)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resolved.Id)
            {
                return BadRequest();
            }

            db.Entry(resolved).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResolvedExists(id))
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

        // POST: api/Resolveds1
        [ResponseType(typeof(Resolved))]
        public IHttpActionResult PostResolved(Resolved resolved)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Resolveds.Add(resolved);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resolved.Id }, resolved);
        }

        // DELETE: api/Resolveds1/5
        [ResponseType(typeof(Resolved))]
        public IHttpActionResult DeleteResolved(int id)
        {
            Resolved resolved = db.Resolveds.Find(id);
            if (resolved == null)
            {
                return NotFound();
            }

            db.Resolveds.Remove(resolved);
            db.SaveChanges();

            return Ok(resolved);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResolvedExists(int id)
        {
            return db.Resolveds.Count(e => e.Id == id) > 0;
        }
    }
}