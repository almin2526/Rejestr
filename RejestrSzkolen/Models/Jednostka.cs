using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RejestrSzkolen.Models
{
    public class Jednostka
    {
        public int JednostkaID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Nazwa { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        [Display(Name = "Start")]
        public DateTime StartDate { get; set; }

        public int? DydaktykID { get; set; }

        public virtual Dydaktyk Administrator { get; set; }
        public virtual ICollection<Kurs> Kursy { get; set; }
    }
}