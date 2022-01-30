using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightService.Application.Flights.Query.GetFlightSearch
{
    public class FlightSearchVm
    {
        public Guid Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int SeatAvailable { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<FlightSectionSearchVm> Sections { get; set; }
    }

    public class FlightSectionSearchVm
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
