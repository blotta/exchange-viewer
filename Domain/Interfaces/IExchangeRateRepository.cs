using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IExchangeRateRepository
    {
        public Task<ExchangeRate?> GetByIdAsync(int id);
        public Task<List<ExchangeRate>> GetAllAsync();
        public Task AddAsync(ExchangeRate rate);
        public Task UpdateAsync(ExchangeRate rate);
        public Task DeleteAsync(ExchangeRate rate);
    }
}
