using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FlightService.Application.Flights.Query.GetFlightSearch
{
   public class FlightSearchQuery : IRequest<ICollection<FlightSearchVm>>
    {
        public string OriginCityCode { get; set; }
        public string OriginCityName { get; set; }
        public string DestinationCityCode { get; set; }
        public string DestinationCityName { get; set; }
        public DateTime FlightDate { get; set; }
        public int PassengerCount { get; set; }
    }
}
