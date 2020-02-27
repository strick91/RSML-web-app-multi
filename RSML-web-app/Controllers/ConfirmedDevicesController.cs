using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RSML_web_app.Data;
using RSML_web_app.Models;

namespace RSML_web_app.Controllers
{
    public class ConfirmedDevicesController : Controller
    {
        private RSML_web_appdbContext db = new RSML_web_appdbContext();

        // GET: ConfirmedDevices
        public ActionResult Index()
        {
            return View(db.ConfirmedDevices.ToList());
        }

        // GET: ConfirmedDevices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmedDevices confirmedDevices = db.ConfirmedDevices.Find(id);
            if (confirmedDevices == null)
            {
                return HttpNotFound();
            }
            return View(confirmedDevices);
        }

        // GET: ConfirmedDevices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfirmedDevices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeviceId")] ConfirmedDevices confirmedDevices)
        {
            if (ModelState.IsValid)
            {
                db.ConfirmedDevices.Add(confirmedDevices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(confirmedDevices);
        }

        // GET: ConfirmedDevices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmedDevices confirmedDevices = db.ConfirmedDevices.Find(id);
            if (confirmedDevices == null)
            {
                return HttpNotFound();
            }
            return View(confirmedDevices);
        }

        // POST: ConfirmedDevices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceId")] ConfirmedDevices confirmedDevices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(confirmedDevices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(confirmedDevices);
        }

        // GET: ConfirmedDevices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmedDevices confirmedDevices = db.ConfirmedDevices.Find(id);
            if (confirmedDevices == null)
            {
                return HttpNotFound();
            }
            return View(confirmedDevices);
        }

        // POST: ConfirmedDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConfirmedDevices confirmedDevices = db.ConfirmedDevices.Find(id);
            db.ConfirmedDevices.Remove(confirmedDevices);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
