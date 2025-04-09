using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Providers
{
    public record ExchangeRateResult(DateTime Date, string BaseCurrency, string Currency, decimal Amount);
    public interface IExchangeRateProvider
    {
        Task<List<ExchangeRateResult>> GetRatesAsync(DateTime date, string baseCurrency);
    }
}
