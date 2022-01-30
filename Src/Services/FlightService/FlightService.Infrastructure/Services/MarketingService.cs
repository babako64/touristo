using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FlightService.Application.Common.Interfaces.Infrastructure;
using FlightService.Application.Models;
using FlightService.Infrastructure.Extensions;

namespace FlightService.Infrastructure.Services
{
    public class MarketingService : IMarketingService
    {
        private readonly HttpClient _httpClient;

        public MarketingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<MarketingServiceResponseModel>> GetMarkupByAirline(MarketingServiceRequestModel model)
        {

            var MarketingModelJson = new StringContent(
                JsonSerializer.Serialize(model.Airline, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"/api/markup/airline", MarketingModelJson);
            if (!response.IsSuccessStatusCode)
            {

            }
            var result = await response.ReadContentAs<IList<MarketingServiceResponseModel>>();

            return result;
        }
    }
}
