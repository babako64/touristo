using System.Collections.Generic;
using System.Threading.Tasks;
using SearchService.API.Models;

namespace SearchService.API.Services.Interfaces
{
    public interface ISearchService
    {

        Task CreateSearch(SearchResponseModel searchResponseModel);
        Task<SearchResponseModel> GetSearch(string id);

        Task<IList<SearchResponseModel>> GetSearches();

        Task DeleteSearch(string id);

        Task<IList<FlightSearchResponseModel>> SearchFlight(FlightSearchModel flightSearchModel);
        Task<IList<HotelSearchResponseModel>> SearchHotel(HotelSearchModel hotelSearchModel);
        Task<SearchResponseModel> Search(SearchModel model);

        Task<SearchResponseModel> GetCachedSearch(GetCachedSearchRequestModel model);

        Task DeleteAllSearches();

    }
}
