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
    public class ValidStoresController : Controller
    {
        private RSML_web_appdbContext db = new RSML_web_appdbContext();

        // GET: ValidStores
        public ActionResult Index()
        {
            return View(db.ValidStores.ToList());
        }

        // GET: ValidStores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValidStores validStores = db.ValidStores.Find(id);
            if (validStores == null)
            {
                return HttpNotFound();
            }
            return View(validStores);
        }

        // GET: ValidStores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValidStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StoreName,StoreLocation")] ValidStores validStores)
        {
            if (ModelState.IsValid)
            {
                db.ValidStores.Add(validStores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(validStores);
        }

        // GET: ValidStores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValidStores validStores = db.ValidStores.Find(id);
            if (validStores == null)
            {
                return HttpNotFound();
            }
            return View(validStores);
        }

        // POST: ValidStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StoreName,StoreLocation")] ValidStores validStores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(validStores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(validStores);
        }

        // GET: ValidStores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValidStores validStores = db.ValidStores.Find(id);
            if (validStores == null)
            {
                return HttpNotFound();
            }
            return View(validStores);
        }

        // POST: ValidStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValidStores validStores = db.ValidStores.Find(id);
            db.ValidStores.Remove(validStores);
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
