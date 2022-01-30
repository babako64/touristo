using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightService.API.Extensions;
using FlightService.Persistence.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Flight.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
             CreateHostBuilder(args).Build()
                .MigrateDatabase<FlightDbContext>((context, serviceProvider) =>
                {
                    var logger = serviceProvider.GetService<ILogger<FlightDbContextSeedData>>();
                    FlightDbContextSeedData.SeedDateAsync(context, logger).Wait();
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
