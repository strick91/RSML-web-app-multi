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
    public class UnresolvedsController : Controller
    {
        private RSML_web_appdbContext db = new RSML_web_appdbContext();

        // GET: Unresolveds
        public ActionResult Index()
        {
            return View(db.Unresolveds.ToList());
        }

        // GET: Unresolveds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unresolved unresolved = db.Unresolveds.Find(id);
            if (unresolved == null)
            {
                return HttpNotFound();
            }
            return View(unresolved);
        }

        // GET: Unresolveds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unresolveds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeviceId,Department,ThreatLevel,TimeOccured, StoreNumber, StoreName")] Unresolved unresolved)
        {
            if (ModelState.IsValid)
            {
                db.Unresolveds.Add(unresolved);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unresolved);
        }

        // GET: Unresolveds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unresolved unresolved = db.Unresolveds.Find(id);
            if (unresolved == null)
            {
                return HttpNotFound();
            }
            return View(unresolved);
        }

        // POST: Unresolveds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceId,Department,ThreatLevel,TimeOccured, StoreNumber, StoreName")] Unresolved unresolved)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unresolved).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unresolved);
        }

        // GET: Unresolveds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unresolved unresolved = db.Unresolveds.Find(id);
            if (unresolved == null)
            {
                return HttpNotFound();
            }
            return View(unresolved);
        }

        // POST: Unresolveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unresolved unresolved = db.Unresolveds.Find(id);
            db.Unresolveds.Remove(unresolved);
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
