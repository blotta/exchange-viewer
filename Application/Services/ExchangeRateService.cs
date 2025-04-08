using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IExchangeRateRepository _repository;

        public ExchangeRateService(IExchangeRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ExchangeRateDto>> GetAllAsync()
        {
            var rates = await _repository.GetAllAsync();
            return rates.Select(r => new ExchangeRateDto
            {
                Id = r.Id,
                Date = r.Date,
                BaseCurrency = r.BaseCurrency,
                Currency = r.Currency,
                Amount = r.Amount
            }).ToList();
        }

        public async Task<ExchangeRateDto?> GetByIdAsync(int id)
        {
            var rate = await _repository.GetByIdAsync(id);
            if (rate is null) return null;

            return new ExchangeRateDto
            {
                Id = rate.Id,
                Date = rate.Date,
                BaseCurrency = rate.BaseCurrency,
                Currency = rate.Currency,
                Amount = rate.Amount
            };
        }

        public async Task<int> CreateAsync(ExchangeRateDto dto)
        {
            var entity = new ExchangeRate(dto.Date, dto.BaseCurrency, dto.Currency, dto.Amount);
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task UpdateAsync(int id, decimal newAmount)
        {
            var entity = await _repository.GetByIdAsync(id) 
                         ?? throw new Exception("ExchangeRate not found.");
            entity.UpdateRate(newAmount);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id) 
                         ?? throw new Exception("ExchangeRate not found.");
            await _repository.DeleteAsync(entity);
        }
    }
}
