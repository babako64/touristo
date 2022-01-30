using System;
using FlightService.Application.Common.Interfaces.Infrastructure;
using FlightService.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddHttpClient<IMarketingService, MarketingService>(c =>
            {
                c.BaseAddress = new Uri(configuration["ApiSettings:MarketingUrl"]);
            });

            return service;
        }
    }
}
