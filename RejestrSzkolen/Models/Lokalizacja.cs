using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RejestrSzkolen.Models
{
    public class Lokalizacja
    {
        [Key]
        [ForeignKey("Dydaktyk")]
        public int DydaktykID { get; set; }
        [StringLength(50)]
        [Display(Name = "Miejsce")]
        public string Miejsce { get; set; }

        public virtual Dydaktyk Dydaktyk { get; set; }
    }
}