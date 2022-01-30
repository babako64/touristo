using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SearchService.API.Extensions;
using SearchService.API.Models;
using SearchService.API.Services.Interfaces;

namespace SearchService.API.Services
{
    public class HotelService : IHotelService
    {
        private readonly HttpClient _httpClient;

        public HotelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<HotelSearchResponseModel>> SearchHotel(HotelSearchModel hotelSearchModel)
        {

            var hotelSearchModelJson = new StringContent(JsonSerializer.Serialize(hotelSearchModel,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("api/hotel/search", hotelSearchModelJson);
            if (!response.IsSuccessStatusCode)
            {
                
            }
            var result = await response.ReadContentAs<IList<HotelSearchResponseModel>>();
            return result;
        }
    }
}
