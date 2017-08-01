using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RejestrSzkolen.DAL;
using RejestrSzkolen.Models;

namespace RejestrSzkolen.Controllers
{
    public class KursController : Controller
    {
        private RejestrContext db = new RejestrContext();

        // GET: Kurs
        public ActionResult Index()
        {
            var kursy = db.Kursy.Include(k => k.Jednostka);
            return View(kursy.ToList());
        }

        // GET: Kurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurs kurs = db.Kursy.Find(id);
            if (kurs == null)
            {
                return HttpNotFound();
            }
            return View(kurs);
        }

        // GET: Kurs/Create
        public ActionResult Create()
        {
            ViewBag.JednostkaID = new SelectList(db.Jednostki, "JednostkaID", "Nazwa");
            return View();
        }

        // POST: Kurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KursID,Tytul,Punkty,JednostkaID")] Kurs kurs)
        {
            if (ModelState.IsValid)
            {
                db.Kursy.Add(kurs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JednostkaID = new SelectList(db.Jednostki, "JednostkaID", "Nazwa", kurs.JednostkaID);
            return View(kurs);
        }

        // GET: Kurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurs kurs = db.Kursy.Find(id);
            if (kurs == null)
            {
                return HttpNotFound();
            }
            ViewBag.JednostkaID = new SelectList(db.Jednostki, "JednostkaID", "Nazwa", kurs.JednostkaID);
            return View(kurs);
        }

        // POST: Kurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KursID,Tytul,Punkty,JednostkaID")] Kurs kurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kurs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JednostkaID = new SelectList(db.Jednostki, "JednostkaID", "Nazwa", kurs.JednostkaID);
            return View(kurs);
        }

        // GET: Kurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurs kurs = db.Kursy.Find(id);
            if (kurs == null)
            {
                return HttpNotFound();
            }
            return View(kurs);
        }

        // POST: Kurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kurs kurs = db.Kursy.Find(id);
            db.Kursy.Remove(kurs);
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
