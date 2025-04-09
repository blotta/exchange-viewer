using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExchangeRateService
    {
        Task<List<ExchangeRateDto>> GetAllAsync();
        Task<ExchangeRateDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(ExchangeRateDto dto);
        Task UpdateAsync(int id, decimal newAmount);
        Task DeleteAsync(int id);
        Task UpsertAsync(ExchangeRateDto dto);
        Task UpsertRatesAsync(string baseCurrency, DateTime? date = null);
    }
}
