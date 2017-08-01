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
    public class DydaktykController : Controller
    {
        private RejestrContext db = new RejestrContext();

        // GET: Dydaktyk
        public ActionResult Index(int? id, int? kursId)
        {
            //var list = db.Dydaktycy.Include(d => d.Lokalizacja).ToList();
            //return View(list);

            var vm = new ViewModels.DydaktykVM();
            vm.Dydaktycy = db.Dydaktycy
            .Include(d => d.Lokalizacja)
            .Include(d => d.Kursy.Select(k => k.Jednostka))
            .OrderBy(n => n.LastName);


            if(id!=null)
            {
                vm.DydaktykID = id.Value;
                vm.Kursy = vm.Dydaktycy.Single(d => d.ID == vm.DydaktykID).Kursy;
            }
            if (kursId!= null)
            {
                vm.KursID = kursId.Value;
                vm.Zapisy = vm.Kursy.Single(k => k.KursID == vm.KursID).Zapisy;
            }


            return View(vm);


        }

        // GET: Dydaktyk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dydaktyk dydaktyk = db.Dydaktycy.Find(id);
            if (dydaktyk == null)
            {
                return HttpNotFound();
            }
            return View(dydaktyk);
        }

        // GET: Dydaktyk/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Lokalizacje, "DydaktykID", "Miejsce");
            return View();
        }

        // POST: Dydaktyk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,Imie,HireDate")] Dydaktyk dydaktyk)
        {
            if (ModelState.IsValid)
            {
                db.Dydaktycy.Add(dydaktyk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Lokalizacje, "DydaktykID", "Miejsce", dydaktyk.ID);
            return View(dydaktyk);
        }

        // GET: Dydaktyk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dydaktyk dydaktyk = db.Dydaktycy.Find(id);
            if (dydaktyk == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Lokalizacje, "DydaktykID", "Miejsce", dydaktyk.ID);
            return View(dydaktyk);
        }

        // POST: Dydaktyk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,Imie,HireDate")] Dydaktyk dydaktyk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dydaktyk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Lokalizacje, "DydaktykID", "Miejsce", dydaktyk.ID);
            return View(dydaktyk);
        }

        // GET: Dydaktyk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dydaktyk dydaktyk = db.Dydaktycy.Find(id);
            if (dydaktyk == null)
            {
                return HttpNotFound();
            }
            return View(dydaktyk);
        }

        // POST: Dydaktyk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dydaktyk dydaktyk = db.Dydaktycy.Find(id);
            db.Dydaktycy.Remove(dydaktyk);
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
