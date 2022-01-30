using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SearchService.API.Entities;
using SearchService.API.Models;
using SearchService.API.Models.Interfaces;
using SearchService.API.Repositories.Interfaces;
using SearchService.API.Services.Interfaces;

namespace SearchService.API.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;
        private readonly IFlightService _flightService;
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public SearchService(ISearchRepository searchRepository, IFlightService flightService, 
            IHotelService hotelService, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _flightService = flightService;
            _hotelService = hotelService;
            _mapper = mapper;
        }

        public async Task CreateSearch(SearchResponseModel searchResponseModel)
        {
            var search = _mapper.Map<Search>(searchResponseModel);
            await _searchRepository.CreateSearch(search);
        }

        public async Task<SearchResponseModel> GetSearch(string id)
        {
            var search = await _searchRepository.GetSearch(id);
            return _mapper.Map<SearchResponseModel>(search);
        }

        public async Task<IList<SearchResponseModel>> GetSearches()
        {
            var search = await _searchRepository.GetAll();

            return _mapper.Map<IList<SearchResponseModel>>(search);
        }

        public async Task DeleteSearch(string id)
        {
            await _searchRepository.DeleteSearch(id);
        }

        public async Task<IList<FlightSearchResponseModel>> SearchFlight(FlightSearchModel flightSearchModel)
        {
            if (flightSearchModel == null) return new List<FlightSearchResponseModel>();
            var result = await _flightService.FlightSearch(flightSearchModel);
            return result;
        }

        public async Task<IList<HotelSearchResponseModel>> SearchHotel(HotelSearchModel hotelSearchModel)
        {
            if (hotelSearchModel == null) return new List<HotelSearchResponseModel>();
            var result = await _hotelService.SearchHotel(hotelSearchModel);
            return result;
        }

        public async Task<SearchResponseModel> Search(SearchModel model)
        {
            
            var flightSearchTask = SearchFlight(model.FlightSearchModel);
            var hotelSearchTask = SearchHotel(model.HotelSearchModel);

            IEnumerable<Task> tasks = new List<Task> {flightSearchTask,hotelSearchTask};

            await Task.WhenAll(tasks);

            var flightSearchResponse = await flightSearchTask;
            var hotelSearchResponse = await hotelSearchTask;

            var searchResult = new SearchResponseModel
            {
                Flights = flightSearchResponse,
                Hotels = hotelSearchResponse
            };

            if (searchResult.Flights.Count > 0 && searchResult.Hotels.Count > 0)
            {
                var search = _mapper.Map<Search>(searchResult);
                var searchId = await _searchRepository.CreateSearch(search);
                searchResult.Id = searchId;
            }

            return searchResult;
        }

        public async Task<SearchResponseModel> GetCachedSearch(GetCachedSearchRequestModel model)
        {

            if (!await _searchRepository.SearchIdExist(model.SearchId))
            {
                return new SearchResponseModel();
            }

            var flights = await _searchRepository.GetFlightByIds(model.SearchId, model.FlightIds);
            var hotels = await _searchRepository.GetHotelByIds(model.SearchId, model.HotelIds);

            var flightResponseModels = _mapper.Map<IList<FlightSearchResponseModel>>(flights);
            var hotelResponseModels = _mapper.Map<IList<HotelSearchResponseModel>>(hotels);

            var searchResult = new SearchResponseModel
            {
                Id = model.SearchId,
                Flights = flightResponseModels,
                Hotels = hotelResponseModels
            };

            return searchResult;
        }

        public async Task DeleteAllSearches()
        {
            await _searchRepository.DeleteAllSearches();
        }
    }
}
