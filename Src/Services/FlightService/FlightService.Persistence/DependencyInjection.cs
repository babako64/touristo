using FlightService.Application.Common.Interfaces.Persistence;
using FlightService.Persistence.Data;
using FlightService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<FlightDbContext>(o => 
                o.UseSqlServer(configuration.GetConnectionString("FlightConnectionString")));

            service.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            service.AddScoped<IFlightRepository, FlightRepository>();

            return service;
        }
    }
}
