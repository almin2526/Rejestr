using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RejestrSzkolen.ViewModels;
using RejestrSzkolen.DAL;

namespace RejestrSzkolen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {           
            using (var db = new RejestrContext())
            {
                var vm = from s in db.Studenci
                         group s by s.DataRejestracji into grupa
                         select new ViewModels.StatystykiVM { DataRejestracji = grupa.Key, LiczbaStudentow = grupa.Count() };
                return View(vm.ToList());
            }            
        }
        public ActionResult Stat()
        {
            using (var db = new RejestrContext())
            {
                var vm = from s in db.Studenci
                         group s by s.Imie into grupa
                         select new ViewModels.Statystyki2VM { Imie = grupa.Key, LiczbaStudentow = grupa.Count() };
                return View(vm.ToList());
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}