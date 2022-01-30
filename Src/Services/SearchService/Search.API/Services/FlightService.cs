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
    public class FlightService : IFlightService
    {
        private readonly HttpClient _httpClient;

        public FlightService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<FlightSearchResponseModel>> FlightSearch(FlightSearchModel flightSearchModel)
        {
            var flightSearchModelJson = new StringContent(
                JsonSerializer.Serialize(flightSearchModel, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/flight/search", flightSearchModelJson);
            if (!response.IsSuccessStatusCode)
            {
                
            }
           var result = await response.ReadContentAs<IList<FlightSearchResponseModel>>();
           return result;
        }
    }
}
