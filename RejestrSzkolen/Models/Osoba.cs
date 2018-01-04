using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.Models
{
    public abstract class Osoba
    {
        public int ID { get; set; }

        [StringLength(50, ErrorMessage = "Nazwisko nie może mieć więcej niż 50 znaków", MinimumLength = 1)]
        [Required]
        public string Nazwisko { get; set; }

        [Required]
        [Display(Name = "Imię")]
        [StringLength(50)]
        public string Imie { get; set; }

        [Display(Name = "Imię i nazwisko")]
        public string Opis
        {
            get { return Nazwisko + ", " + Imie; }
        }


    }
}