using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.API.Models
{
    public class SearchCachedResponseModel
    {
        public string Id { get; set; }
        public ICollection<FlightModel> Flights { get; set; }
        public ICollection<HotelModel> Hotels { get; set; }
    }
}
