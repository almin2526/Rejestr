using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.ViewModels
{
    public class PrzydzieloneDaneKursuVM
    {
        public int KursID { get; set; }
        public string Tytuł { get; set; }
        public bool Przypisany { get; set; }
    }
}