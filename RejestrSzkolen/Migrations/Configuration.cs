namespace RejestrSzkolen.Migrations
{
    using RejestrSzkolen.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RejestrSzkolen.DAL.RejestrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RejestrSzkolen.DAL.RejestrContext";
        }

        protected override void Seed(RejestrSzkolen.DAL.RejestrContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var d1 = new Dydaktyk() { ID = 1234,Imie="Jan",Nazwisko="Kowalski",DataZatrudnienia=DateTime.Parse("2012-02-11")};
            d1.Lokalizacja = new Lokalizacja() { Miejsce="Mokotów",DydaktykID=1234,Dydaktyk=d1};
       
            context.Dydaktycy.AddOrUpdate(d => d.Nazwisko, d1);
            context.SaveChanges();

            var j1 = new Jednostka();
            j1.JednostkaID = 1234;
            j1.Nazwa = "Finanse";
            j1.Budget = 10000;
            j1.Administrator = d1;

            context.Jednostki.AddOrUpdate(j => j.Nazwa, j1);
            context.SaveChanges();
    
        }
    }
}
