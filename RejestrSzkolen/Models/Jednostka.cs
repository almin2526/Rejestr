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

        public int? DydaktykID { get; set; }

        public virtual Dydaktyk Administrator { get; set; }
        public virtual ICollection<Kurs> Kursy { get; set; }
    }
}