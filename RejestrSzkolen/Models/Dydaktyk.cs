using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.Models
{
    public class Dydaktyk
    {
       
        public int ID { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Imię")]
        [StringLength(50)]
        public string Imie { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        [Display(Name = "Data zatrudnienia")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Imię i nazwisko")]
        public string FullName
        {
            get { return LastName + ", " + Imie; }
        }

        public virtual ICollection<Kurs> Kursy { get; set; }
        public virtual Lokalizacja Lokalizacja { get; set; }
    }
}