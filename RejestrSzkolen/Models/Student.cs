using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        [Display(Name = "Data rejestracji", Prompt = "Podaj datę rejestracji", Description = "Data rejestracji studenta")]
        public DateTime DataRejestracji { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Zapis> Zapisy { get; set; }

    }
}