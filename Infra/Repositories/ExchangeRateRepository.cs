using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly ApplicationContext _context;

        public ExchangeRateRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<ExchangeRate>> GetAllAsync()
            => await _context.ExchangeRates.ToListAsync();

        public async Task<ExchangeRate?> GetByIdAsync(int id)
            => await _context.ExchangeRates.FindAsync(id);

        public async Task AddAsync(ExchangeRate rate)
        {
            await _context.ExchangeRates.AddAsync(rate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExchangeRate rate)
        {
            _context.ExchangeRates.Update(rate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ExchangeRate rate)
        {
            _context.ExchangeRates.Remove(rate);
            await _context.SaveChangesAsync();
        }
    }
}
