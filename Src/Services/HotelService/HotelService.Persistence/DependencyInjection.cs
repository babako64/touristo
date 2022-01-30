using HotelService.Application.Common.Interfaces.Persistence;
using HotelService.Persistence.Data;
using HotelService.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<HotelDbContext>(b => 
                b.UseSqlServer(configuration.GetConnectionString("HotelConnectionString")));

            service.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            service.AddScoped<IHotelRepository, HotelRepository>();

            return service;
        }
    }
}
