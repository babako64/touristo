using System;
using SearchService.API.Models.Interfaces;

namespace SearchService.API.Models
{
    public class FlightSearchModel : ISearchModel
    {
        public string OriginCityCode { get; set; }
        public string OriginCityName { get; set; }
        public string DestinationCityCode { get; set; }
        public string DestinationCityName { get; set; }
        public DateTime FlightDate { get; set; }
        public int PassengerCount { get; set; }
    }

}
