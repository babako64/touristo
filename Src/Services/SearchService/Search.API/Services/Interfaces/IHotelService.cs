using System.Collections.Generic;
using System.Threading.Tasks;
using SearchService.API.Models;

namespace SearchService.API.Services.Interfaces
{
    public interface IHotelService
    {
        Task<IList<HotelSearchResponseModel>> SearchHotel(HotelSearchModel hotelSearchModel);
    }
}
