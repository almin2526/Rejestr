using RejestrSzkolen.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.ViewModels
{
    public class DydaktykVM
    {
        public IEnumerable<Dydaktyk> Dydaktycy { get; set; }
        public IEnumerable<Kurs> Kursy { get; set; }
        public IEnumerable<Zapis> Zapisy { get; set; }
        public int DydaktykID { get; set; }
        public int KursID { get; set; }



    }
}