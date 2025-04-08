using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ExchangeRateDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BaseCurrency { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
