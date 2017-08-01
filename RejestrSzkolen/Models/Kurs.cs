using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RejestrSzkolen.Models
{
    public class Kurs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KursID { get; set; }
        [Display(Name = "Tytuł")]
        [StringLength(50, MinimumLength = 3)]
        public string Tytul { get; set; }
        [Range(0,5)]
        public int Punkty { get; set; }

        public int? JednostkaID { get; set; }

        public virtual Jednostka Jednostka { get; set; }
        public virtual ICollection<Zapis> Zapisy { get; set; }
        public virtual ICollection<Dydaktyk> Dydaktycy { get; set; }
    }
}