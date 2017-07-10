using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RejestrSzkolen.Models
{
    public class Kurs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KursID { get; set; }
        public string Tytul { get; set; }
        public int Punkty { get; set; }

        public virtual ICollection<Zapis> Zapisy { get; set; }
    }
}