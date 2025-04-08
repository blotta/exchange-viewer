using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ExchangeRate
    {
        [Key]
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        [MaxLength(3)]
        public string BaseCurrency { get; private set; }
        public string Currency { get; private set; }
        public decimal Amount { get; private set; }

        public ExchangeRate(DateTime date, string baseCurrency, string currency, decimal amount)
        {
            Date = date;
            BaseCurrency = baseCurrency;
            Currency = currency;
            Amount = amount;
        }

        public void UpdateRate(decimal newAmount)
        {
            Amount = newAmount;
        }
    }
}
