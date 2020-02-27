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
    public class ConfirmedDevicesInStores1Controller : ApiController
    {
        private RSML_web_appdbContext db = new RSML_web_appdbContext();

        // GET: api/ConfirmedDevicesInStores1
        public IQueryable<ConfirmedDevicesInStore> GetConfirmedDevicesInStores()
        {
            return db.ConfirmedDevicesInStores;
        }

        // GET: api/ConfirmedDevicesInStores1/5
        [ResponseType(typeof(ConfirmedDevicesInStore))]
        public IHttpActionResult GetConfirmedDevicesInStore(int id)
        {
            ConfirmedDevicesInStore confirmedDevicesInStore = db.ConfirmedDevicesInStores.Find(id);
            if (confirmedDevicesInStore == null)
            {
                return NotFound();
            }

            return Ok(confirmedDevicesInStore);
        }

        // PUT: api/ConfirmedDevicesInStores1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConfirmedDevicesInStore(int id, ConfirmedDevicesInStore confirmedDevicesInStore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != confirmedDevicesInStore.Id)
            {
                return BadRequest();
            }

            db.Entry(confirmedDevicesInStore).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfirmedDevicesInStoreExists(id))
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

        // POST: api/ConfirmedDevicesInStores1
        [ResponseType(typeof(ConfirmedDevicesInStore))]
        public IHttpActionResult PostConfirmedDevicesInStore(ConfirmedDevicesInStore confirmedDevicesInStore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConfirmedDevicesInStores.Add(confirmedDevicesInStore);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = confirmedDevicesInStore.Id }, confirmedDevicesInStore);
        }

        // DELETE: api/ConfirmedDevicesInStores1/5
        [ResponseType(typeof(ConfirmedDevicesInStore))]
        public IHttpActionResult DeleteConfirmedDevicesInStore(int id)
        {
            ConfirmedDevicesInStore confirmedDevicesInStore = db.ConfirmedDevicesInStores.Find(id);
            if (confirmedDevicesInStore == null)
            {
                return NotFound();
            }

            db.ConfirmedDevicesInStores.Remove(confirmedDevicesInStore);
            db.SaveChanges();

            return Ok(confirmedDevicesInStore);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfirmedDevicesInStoreExists(int id)
        {
            return db.ConfirmedDevicesInStores.Count(e => e.Id == id) > 0;
        }
    }
}