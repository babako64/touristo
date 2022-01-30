using SearchService.API.Models.Interfaces;

namespace SearchService.API.Models
{
    public class SearchModel : ISearchModel
    {
        public FlightSearchModel FlightSearchModel { get; set; }
        public HotelSearchModel HotelSearchModel { get; set; }
    }
}
