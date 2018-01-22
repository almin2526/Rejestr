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
    public class ZapisController : Controller
    {
        private RejestrContext db = new RejestrContext();
        // GET: Zapis
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Studenci.Find(id);
            
            if (student == null)
            {
                return HttpNotFound();
            }

            var kursyZapisane = student.Zapisy.Select(z => z.Kurs).ToList();
            var list = db.Kursy.ToList().Except(kursyZapisane);
            ViewBag.ID = id;
            return View(list);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        
            var list = Enum.GetNames(typeof(Ocena));
            ViewBag.ID = id;
            return View(list);
        }
        public ActionResult EditPost(string ocena, int ZapisID)
        {
            try
            {
                Zapis z = db.Zapisy.FirstOrDefault(f => f.ZapisID == ZapisID);
                if (ModelState.IsValid)
                {
                    
                    z.Ocena = (Ocena)Enum.Parse(typeof(Ocena), ocena, true);
                    db.SaveChanges();
                    return RedirectToAction("Details", "Students", new { ID = z.StudentID });
                }
                
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID, KursID")] Zapis zapis)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    db.Zapisy.Add(zapis);
                    db.SaveChanges();
                    return RedirectToAction("Details","Students",new { ID=zapis.StudentID });
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(zapis);
        }
        public ActionResult Delete(int id)
        {          
            //Zapis z = db.Zapisy.FirstOrDefault(f => f.KursID == zapis.KursID && f.Student == zapis.StudentID);
            Zapis z = db.Zapisy.FirstOrDefault(f => f.ZapisID == id);
            if (z == null)
            {
                return HttpNotFound();
            }

            return View(z);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zapis z = db.Zapisy.FirstOrDefault(f => f.ZapisID == id);

            db.Zapisy.Remove(z);
            db.SaveChanges();
            return RedirectToAction("Details", "Students", new { ID = z.StudentID });
        }
    }
}