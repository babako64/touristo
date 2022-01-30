using System;
using System.Collections.Generic;

namespace SearchService.API.Models
{
    public class FlightSearchResponseModel
    {
        public Guid Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int SeatAvailable { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<FlightSectionResponseModel> Sections { get; set; }
    }

    public class FlightSectionResponseModel
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
