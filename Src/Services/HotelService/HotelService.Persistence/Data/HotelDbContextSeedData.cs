using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace HotelService.Persistence.Data
{
    public class HotelDbContextSeedData
    {
        public static async Task SeedData(HotelDbContext context, ILogger<HotelDbContextSeedData> logger)
        {
            if (!context.Hotels.Any())
            {
                await context.Hotels.AddRangeAsync(HotelData());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", nameof(HotelDbContext));
            }
        }

        private static IList<Hotel> HotelData()
        {
            return new List<Hotel>
            {
                new Hotel
                {
                    Name = "Grand hotel",
                    Rate = 3,
                    HotelCode = "A01",
                    CityCode = "JPY",
                    CityName = "Tokyo",
                    Latitude = 1.5555,
                    Longitude = 2.884,
                    Phone = "00845125789",
                    Rooms = new List<HotelRoom>
                    {
                        new HotelRoom
                        {
                            Category = "SUPERIOR_ROOM",
                            Beds = 1,
                            BedType = "KING",
                            Guest = new Guest{Adults = 1, Child = 0},
                            Price = 80,
                            Currency = "USD",
                            Description = "Regular Rate\nSuperior Room garden or patio view, large bathr\noom, 1 King, 35sqm/377sqft, Wireless internet",
                            FromDate = DateTime.Now,
                            ToDate = DateTime.Now.AddDays(20)
                        }
                    }
                }
            };
        }
    }
}
