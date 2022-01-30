using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelService.API.Extensions;
using HotelService.Persistence.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HotelService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                .MigrateDatabase<HotelDbContext>((context, serviceProvider) =>
                {
                    var logger = serviceProvider.GetService<ILogger<HotelDbContextSeedData>>();
                    HotelDbContextSeedData.SeedData(context, logger).Wait();
                }).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
