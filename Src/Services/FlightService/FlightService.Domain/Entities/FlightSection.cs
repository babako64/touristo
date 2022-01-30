using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightService.Domain.Common;

namespace FlightService.Domain.Entities
{
    public class FlightSection : EntityBase
    {
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

        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }

    }
}
