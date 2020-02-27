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
    public class ConfirmedDevices1Controller : ApiController
    {
        private RSML_web_appdbContext db = new RSML_web_appdbContext();

        // GET: api/ConfirmedDevices1
        public IQueryable<ConfirmedDevices> GetConfirmedDevices()
        {
            return db.ConfirmedDevices;
        }

        // GET: api/ConfirmedDevices1/5
        [ResponseType(typeof(ConfirmedDevices))]
        public IHttpActionResult GetConfirmedDevices(int id)
        {
            ConfirmedDevices confirmedDevices = db.ConfirmedDevices.Find(id);
            if (confirmedDevices == null)
            {
                return NotFound();
            }

            return Ok(confirmedDevices);
        }

        // PUT: api/ConfirmedDevices1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConfirmedDevices(int id, ConfirmedDevices confirmedDevices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != confirmedDevices.Id)
            {
                return BadRequest();
            }

            db.Entry(confirmedDevices).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfirmedDevicesExists(id))
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

        // POST: api/ConfirmedDevices1
        [ResponseType(typeof(ConfirmedDevices))]
        public IHttpActionResult PostConfirmedDevices(ConfirmedDevices confirmedDevices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConfirmedDevices.Add(confirmedDevices);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = confirmedDevices.Id }, confirmedDevices);
        }

        // DELETE: api/ConfirmedDevices1/5
        [ResponseType(typeof(ConfirmedDevices))]
        public IHttpActionResult DeleteConfirmedDevices(int id)
        {
            ConfirmedDevices confirmedDevices = db.ConfirmedDevices.Find(id);
            if (confirmedDevices == null)
            {
                return NotFound();
            }

            db.ConfirmedDevices.Remove(confirmedDevices);
            db.SaveChanges();

            return Ok(confirmedDevices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfirmedDevicesExists(int id)
        {
            return db.ConfirmedDevices.Count(e => e.Id == id) > 0;
        }
    }
}