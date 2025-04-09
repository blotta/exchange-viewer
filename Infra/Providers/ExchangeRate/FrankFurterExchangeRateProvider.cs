using Domain.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infra.Providers.ExchangeRate
{
    public class FrankFurterExchangeRateProvider : IExchangeRateProvider
    {
        private readonly HttpClient _httpClient;

        public FrankFurterExchangeRateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExchangeRateResult>> GetRatesAsync(DateTime date, string baseCurrency)
        {
            var url = $"https://api.frankfurter.dev/v1/{date:yyyy-MM-dd}?base={baseCurrency}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Exchange rate API call failed: {response.StatusCode}");
            }

            var contentStream = await response.Content.ReadAsStreamAsync();
            var json = await JsonDocument.ParseAsync(contentStream);

            if (!json.RootElement.TryGetProperty("rates", out var ratesElement))
            {
                throw new Exception("No 'rates' property in response");
            }

            var results = new List<ExchangeRateResult>();

            foreach (var rate in ratesElement.EnumerateObject())
            {
                var currency = rate.Name;
                var amount = rate.Value.GetDecimal();

                results.Add(
                    new ExchangeRateResult(
                        date.Date,
                        baseCurrency.ToUpperInvariant(),
                        currency.ToUpperInvariant(),
                        amount));
            }

            return results;
        }
    }
}
