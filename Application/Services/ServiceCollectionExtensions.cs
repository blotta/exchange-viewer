using Application.Interfaces;
using Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IExchangeRateService, ExchangeRateService>();
        }

        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddInfraLayer(config);
        }
    }
}
