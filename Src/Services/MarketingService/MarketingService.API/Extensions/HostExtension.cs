using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

namespace MarketingService.API.Extensions
{
    public static class HostExtension
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {

            int retryForAvailability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();

                try
                { 
                    using var connection = new NpgsqlConnection(configuration["DatabaseSettings:ConnectionString"]);
                    connection.Open();

                    var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };

                    command.CommandText = "DROP TABLE IF EXISTS Markup";
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE Markup(Id SERIAL PRIMARY KEY, 
                                                                    CityCode VARCHAR(3),
                                                                    Airline VARCHAR(50),                                                           
                                                                    Percent decimal,
                                                                    Type INT)";
                    command.ExecuteNonQuery();

                    command.CommandText =
                        "INSERT INTO Markup(CityCode, Airline, Percent, Type) VALUES('THR', 'Iran Air', 20, 0);";
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, retryForAvailability);
                    }
                }
            }

            return host;
        }
    }
}
