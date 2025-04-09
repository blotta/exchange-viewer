using Domain.Interfaces;
using Domain.Providers;
using Infra.Data;
using Infra.Providers.ExchangeRate;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public static class ServiceCollectoinExtensions
    {
        public static IServiceCollection AddInfraLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")
                    ?? throw new InvalidOperationException("Connection string not found")));

            services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();

            services.AddHttpClient<IExchangeRateProvider, FrankFurterExchangeRateProvider>();

            return services;
        }
    }
}
