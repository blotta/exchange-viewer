using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Worker.Worker
{
    public class ExchangeRateJob
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateJob(IExchangeRateService exchangeRateService)
        {
           _exchangeRateService = exchangeRateService;
        }

        public async Task FetchAndUpsertAsync(string baseCurrency)
        {
            Console.WriteLine($"Fetching {baseCurrency} rates at {DateTime.UtcNow}");
            await _exchangeRateService.UpsertLatestRatesAsync(baseCurrency);
            Console.WriteLine($"Exchange rates updated");
        }
    }
}
