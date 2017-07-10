using RejestrSzkolen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.DAL
{
    public class RejestrInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RejestrContext>
    {
        protected override void Seed(RejestrContext context)
        {
           
            var students = new List<Student>
            {
             new Student{Imie="Alexander",Nazwisko="Alexanderowy",DataRejestracji= DateTime.Parse("2016-09-01")},
             new Student{Imie="Jan",Nazwisko="Jankowski",DataRejestracji= DateTime.Parse("2015-09-01")}
            };

            students.ForEach(s => context.Studenci.Add(s));
            context.SaveChanges();

            var kursy = new List<Kurs>
            {
             new Kurs{KursID=21010,Tytul="C#",Punkty=3},
             new Kurs{KursID=20486,Tytul="Developing Web Applications",Punkty=3}
            };

            kursy.ForEach(s => context.Kursy.Add(s));
            context.SaveChanges();

            var zapisy = new List<Zapis>
            {
             new Zapis{KursID=21010,StudentID=1,Ocena=Ocena.BardzoDobra},
             new Zapis{KursID=21010,StudentID=2,Ocena=Ocena.Celujaca},
             new Zapis{KursID=20486,StudentID=2},
            };

            zapisy.ForEach(s => context.Zapisy.Add(s));
            context.SaveChanges();


        }
    }
}