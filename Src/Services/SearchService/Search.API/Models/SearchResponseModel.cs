using System.Collections.Generic;

namespace SearchService.API.Models
{
    public class SearchResponseModel
    {
        public string Id { get; set; }
        public ICollection<FlightSearchResponseModel> Flights { get; set; }
        public ICollection<HotelSearchResponseModel> Hotels { get; set; }
    }
}
