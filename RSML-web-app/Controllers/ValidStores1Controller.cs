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
    public class ValidStores1Controller : ApiController
    {
        private RSML_web_appdbContext db = new RSML_web_appdbContext();

        // GET: api/ValidStores1
        public IQueryable<ValidStores> GetValidStores()
        {
            return db.ValidStores;
        }

        // GET: api/ValidStores1/5
        [ResponseType(typeof(ValidStores))]
        public IHttpActionResult GetValidStores(int id)
        {
            ValidStores validStores = db.ValidStores.Find(id);
            if (validStores == null)
            {
                return NotFound();
            }

            return Ok(validStores);
        }

        // PUT: api/ValidStores1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutValidStores(int id, ValidStores validStores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != validStores.Id)
            {
                return BadRequest();
            }

            db.Entry(validStores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValidStoresExists(id))
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

        // POST: api/ValidStores1
        [ResponseType(typeof(ValidStores))]
        public IHttpActionResult PostValidStores(ValidStores validStores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ValidStores.Add(validStores);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = validStores.Id }, validStores);
        }

        // DELETE: api/ValidStores1/5
        [ResponseType(typeof(ValidStores))]
        public IHttpActionResult DeleteValidStores(int id)
        {
            ValidStores validStores = db.ValidStores.Find(id);
            if (validStores == null)
            {
                return NotFound();
            }

            db.ValidStores.Remove(validStores);
            db.SaveChanges();

            return Ok(validStores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ValidStoresExists(int id)
        {
            return db.ValidStores.Count(e => e.Id == id) > 0;
        }
    }
}