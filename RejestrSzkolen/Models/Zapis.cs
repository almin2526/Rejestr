namespace RejestrSzkolen.Models
{
    public enum Ocena
    {
        Celujaca, BardzoDobra, Dobra, Dostateczna,Mierna, Niedostateczna
    }
    public class Zapis
    {
        public int ZapisID { get; set; }
        public int KursID { get; set; }
        public int StudentID { get; set; }
        public Ocena? Ocena { get; set; }

        public virtual Kurs Kurs { get; set; }
        public virtual Student Student { get; set; }
    }
}