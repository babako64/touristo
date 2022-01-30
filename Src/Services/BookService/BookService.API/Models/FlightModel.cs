using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.API.Models
{
    public class FlightModel
    {
        public ICollection<FlightSectionModel> Sections { get; set; }
    }

    public class FlightSectionModel
    {
        public Guid Id { get; set; }
        public string FlightNumber { get; set; }
        public string OriginCityCode { get; set; }
        public string DestinationCityCode { get; set; }
        public string OriginCityName { get; set; }
        public string DestinationCityName { get; set; }
        public string OriginAirportName { get; set; }
        public string DestinationAirportName { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string AirlineName { get; set; }
        public TimeSpan FlightSectionDuration { get; set; }
    }
}
