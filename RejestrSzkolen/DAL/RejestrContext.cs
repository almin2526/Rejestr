using RejestrSzkolen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.DAL
{
    public class RejestrContext :DbContext
    {
        public RejestrContext() : base("RejestrContext")
        {
        }
        public DbSet<Student> Studenci { get; set; }
        public DbSet<Kurs> Kursy { get; set; }
        public DbSet<Zapis> Zapisy { get; set; }
        public DbSet<Dydaktyk> Dydaktycy { get; set; }
        public DbSet<Jednostka> Jednostki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}