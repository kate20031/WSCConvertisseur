namespace WSCConvertisseur.Models
{
    public class Devise
    {
        public Devise(int id, string nom, double taux)
        {
            Id = id;
            Nom = nom;
            Taux = taux;
        }

        public Devise() {
            Id = 0;
            Nom = string.Empty;
            Taux = 0.0;
        }


        public int Id { get; set; }
        public string Nom { get; set; }
        public double Taux { get; set; }
    }
}
