using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.Models
{
    public class Dydaktyk : Osoba
    {
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        [Display(Name = "Data zatrudnienia")]
        public DateTime DataZatrudnienia { get; set; }

        public virtual ICollection<Kurs> Kursy { get; set; }
        public virtual Lokalizacja Lokalizacja { get; set; }
    }
}