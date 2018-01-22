using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RejestrSzkolen.DAL;
using RejestrSzkolen.Models;
using RejestrSzkolen.ViewModels;
using System.Data.Entity.Validation;

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
            .OrderBy(n => n.Nazwisko);


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
            Dydaktyk dydaktyk = db.Dydaktycy.Include(d => d.Lokalizacja).FirstOrDefault(d => d.ID == id);
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
        public ActionResult Create([Bind(Include = "ID,Nazwisko,Imie,DataZatrudnienia,Lokalizacja")] Dydaktyk dydaktyk)
        {
            if (ModelState.IsValid)
            {
                dydaktyk.Lokalizacja.DydaktykID = dydaktyk.ID;
                if (!String.IsNullOrEmpty(dydaktyk.Lokalizacja.Miejsce))
                {
                    db.Lokalizacje.Add(dydaktyk.Lokalizacja);
                }
                
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
            Dydaktyk dydaktyk = db.Dydaktycy.Include(d=>d.Lokalizacja).Include(d=>d.Kursy).FirstOrDefault(d=>d.ID==id);
            WpiszPrzydzieloneDaneKursu(dydaktyk);
            if (dydaktyk == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Lokalizacje, "DydaktykID", "Miejsce", dydaktyk.ID);
            return View(dydaktyk);
        }

        private void WpiszPrzydzieloneDaneKursu(Dydaktyk dydaktyk)
        {
            var wszystkieKursy = db.Kursy;
            var kursyDydaktyka = new HashSet<int>(dydaktyk.Kursy.Select(k => k.KursID));
            var viewModel = new List<PrzydzieloneDaneKursuVM>();
            foreach (var kurs in wszystkieKursy)
            {
                viewModel.Add(new PrzydzieloneDaneKursuVM
                {
                    KursID = kurs.KursID,
                    Tytuł = kurs.Tytul,
                    Przypisany = kursyDydaktyka.Contains(kurs.KursID)
                });
                ViewBag.Kursy = viewModel;
            }
        }



        // POST: Dydaktyk/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwisko,Imie,DataZatrudnienia,Lokalizacja")] Dydaktyk dydaktyk,string[] wybraneKursy)
        
            //public ActionResult Edit(Dydaktyk dydaktyk)
        {
            db.Database.Log = s => System.Diagnostics.Debug.Write(s);
            if (ModelState.IsValid)
            {
                //dydaktyk.Lokalizacja.DydaktykID = dydaktyk.ID;
                //if (!String.IsNullOrEmpty(dydaktyk.Lokalizacja.Miejsce))
                //{
                //    if (db.Lokalizacje.Any(l => l.DydaktykID == dydaktyk.ID))
                //    {
                //        db.Entry(dydaktyk.Lokalizacja).State = EntityState.Modified;
                //    }
                //    else
                //    {
                //        db.Lokalizacje.Add(dydaktyk.Lokalizacja);
                //    }
                //}

                ZaktualizujKursyDydaktyka(wybraneKursy, dydaktyk);

                //db.Entry(dydaktyk).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
             

                WpiszPrzydzieloneDaneKursu(dydaktyk);

             
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Lokalizacje, "DydaktykID", "Miejsce", dydaktyk.ID);
            return View(dydaktyk);
        }

        private void ZaktualizujKursyDydaktyka(string[] wybraneKursy, Dydaktyk dydaktyk)
        {
            dydaktyk.Kursy = new List<Kurs>();

            Dydaktyk dydaktyk2 = db.Dydaktycy.Include(d => d.Lokalizacja).FirstOrDefault(d => d.ID == dydaktyk.ID);       
            dydaktyk2.Kursy.Clear();
            dydaktyk2.Imie = dydaktyk.Imie;
            dydaktyk2.Nazwisko = dydaktyk.Nazwisko;
            dydaktyk2.Lokalizacja = dydaktyk.Lokalizacja;


            if (wybraneKursy != null)
            {
                foreach (int kursID in wybraneKursy.Select(s => Convert.ToInt32(s)))
                {
                    var item = db.Kursy.Single(k => k.KursID == kursID);
                    //item.Dydaktycy.Add(dydaktyk2);
                    //db.Entry(item).State = EntityState.Modified;
                    dydaktyk2.Kursy.Add(item);                     
                }
            }
         
            
        }

        // GET: Dydaktyk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dydaktyk dydaktyk = db.Dydaktycy.Include(d => d.Lokalizacja).FirstOrDefault(d => d.ID == id);
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
            //dydaktyk.Lokalizacja = null;
            var lok = db.Lokalizacje.FirstOrDefault(f => f.DydaktykID == id);
            db.Lokalizacje.Remove(lok);

            
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
