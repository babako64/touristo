using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlightService.Persistence.Data
{
    public class FlightDbContextSeedData
    {
        public static async Task SeedDateAsync(FlightDbContext context, ILogger<FlightDbContextSeedData> logger )
        {

            if (!context.Flights.Any())
            {
                await context.Flights.AddRangeAsync(GetFlightData());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", nameof(FlightDbContext));
            }
        }

        private static IList<Flight> GetFlightData()
        {
            return new List<Flight>
            {
               new Flight
               {
                   FromDate = DateTime.Now,
                   ToDate = DateTime.Now.AddDays(15),
                   SeatAvailable = 30,
                   IsAvailable = true,
                   Sections = new List<FlightSection>
                   {
                       new FlightSection
                       {
                           FlightNumber = "100",
                           OriginCityCode = "THR",
                           DestinationCityCode = "DBX",
                           OriginCityName = "Tehran",
                           DestinationCityName = "Dubai",
                           OriginAirportName = "Imam",
                           DestinationAirportName = "Dubai international airport",
                           Price = 80,
                           Currency = "USD",
                           AirlineName = "Mahan",
                           FlightSectionDuration = new TimeSpan(0,01,30,0)
                       }
                   }
               }
            };
        }
    }
}
