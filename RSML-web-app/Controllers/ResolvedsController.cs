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
    public class ResolvedsController : Controller
    {
        private RSML_web_appdbContext db = new RSML_web_appdbContext();

        // GET: Resolveds
        public ActionResult Index()
        {
            return View(db.Resolveds.ToList());
        }

        // GET: Resolveds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resolved resolved = db.Resolveds.Find(id);
            if (resolved == null)
            {
                return HttpNotFound();
            }
            return View(resolved);
        }

        // GET: Resolveds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resolveds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DeviceId,SuspiciousActivites,_Date,TimeResolved,Verdict, StoreName, StoreLocation")] Resolved resolved)
        {
            if (ModelState.IsValid)
            {
                db.Resolveds.Add(resolved);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resolved);
        }

        // GET: Resolveds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resolved resolved = db.Resolveds.Find(id);
            if (resolved == null)
            {
                return HttpNotFound();
            }
            return View(resolved);
        }

        // POST: Resolveds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DeviceId,SuspiciousActivites,_Date,TimeResolved,Verdict, StoreName, StoreLocation")] Resolved resolved)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resolved).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resolved);
        }

        // GET: Resolveds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resolved resolved = db.Resolveds.Find(id);
            if (resolved == null)
            {
                return HttpNotFound();
            }
            return View(resolved);
        }

        // POST: Resolveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resolved resolved = db.Resolveds.Find(id);
            db.Resolveds.Remove(resolved);
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
