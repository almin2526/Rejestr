using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.Models
{
    public class Student : Osoba
    {       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data rejestracji", Prompt = "Podaj datę rejestracji", Description = "Data rejestracji studenta")]
        public DateTime DataRejestracji { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual ICollection<Zapis> Zapisy { get; set; }

    }
    //public class Student
    //{
    //    public int ID { get; set; }
    //    [StringLength(50, ErrorMessage ="Nazwisko nie może mieć więcej niż 50 znaków",MinimumLength =1)]
    //    public string Nazwisko { get; set; }
    //    [Display(Name = "Imię"),StringLength(50, ErrorMessage = "Imię nie może mieć więcej niż 50 znaków")]
    //    public string Imie { get; set; }
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
    //    [Display(Name = "Data rejestracji", Prompt = "Podaj datę rejestracji", Description = "Data rejestracji studenta")]
    //    public DateTime DataRejestracji { get; set; }
    //    public string Email { get; set; }
    //    public virtual ICollection<Zapis> Zapisy { get; set; }

    //}
}