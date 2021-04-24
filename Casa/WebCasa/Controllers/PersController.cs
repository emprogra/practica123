using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCasa.Models;

namespace WebCasa.Controllers
{
    public class PersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Pers
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Pers.ToList());
        }

        // GET: Pers/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pers pers = db.Pers.Find(id);
            if (pers == null)
            {
                return HttpNotFound();
            }
            return View(pers);
        }

        // GET: Pers/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "PerosnId,Name,CovidCount")] Pers pers)
        {
            if (ModelState.IsValid)
            {
                db.Pers.Add(pers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pers);
        }

        // GET: Pers/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pers pers = db.Pers.Find(id);
            if (pers == null)
            {
                return HttpNotFound();
            }
            return View(pers);
        }

        // POST: Pers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "PerosnId,Name,CovidCount")] Pers pers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pers);
        }

        // GET: Pers/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pers pers = db.Pers.Find(id);
            if (pers == null)
            {
                return HttpNotFound();
            }
            return View(pers);
        }

        // POST: Pers/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pers pers = db.Pers.Find(id);
            db.Pers.Remove(pers);
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
