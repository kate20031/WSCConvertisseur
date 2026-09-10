using System.ComponentModel.DataAnnotations;
namespace WSCConvertisseur.Models
{
    public class Currency
    {
        public Currency(int id, string currencyName, double rate)
        {
            Id = id;
            CurrencyName = currencyName;
            Rate = rate;
        }

        public Currency() {
            Id = 0;
            CurrencyName = string.Empty;
            Rate = 0.0;
        }


        public int Id { get; set; }
        [Required]
        public string CurrencyName { get; set; }
        public double Rate { get; set; }
    }
}
