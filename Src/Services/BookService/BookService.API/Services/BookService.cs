using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using BookService.API.Entities;
using BookService.API.Extensions;
using BookService.API.Models;
using BookService.API.Repositories.Interfaces;
using BookService.API.Services.Interfaces;
using EventBus.Messages.Events;
using MassTransit;

namespace BookService.API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public BookService(IBookRepository bookRepository, HttpClient httpClient, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _bookRepository = bookRepository;
            _httpClient = httpClient;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<BookModel> GetBookById(Guid id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
            {
                return null;
            }
            var bookVm = _mapper.Map<BookModel>(book);
            return bookVm;
        }

        public async Task<IList<BookModel>> GetBooks()
        {
            var books = await _bookRepository.GetBooks();
            var bookVms = _mapper.Map<IList<BookModel>>(books);
            return bookVms;
        }

        public async Task<IList<FlightModel>> GetFlightsFromFlightService(IList<Guid> ids)
        {
            if (ids == null || ids.Count == 0) return new List<FlightModel>();

            var flightDetailRequestModelJson = new StringContent(JsonSerializer.Serialize(new FlightDetailRequestModel(ids), 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }), Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("api/flight/GetFlightListByIds", flightDetailRequestModelJson);
            var flightModels = await response.ReadContentAs<IList<FlightModel>>();
            return flightModels;
        }

        public async Task<IList<FlightModel>> GetHotelsFromHotelService(IList<Guid> ids)
        {
            if (ids == null || ids.Count == 0) return new List<FlightModel>();

            var hotelDetailRequestModel = new StringContent(JsonSerializer.Serialize(new HotelDetailRequestModel(ids),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }), Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("api/hotel/GetHotelListByIds", hotelDetailRequestModel);
            var flightModels = await response.ReadContentAs<IList<FlightModel>>();
            return flightModels;
        }

        public async Task<SearchCachedResponseModel> GetCachedSearchService(SearchCachedRequestModel model)
        {

            var cachedSearchRequestModel = new StringContent(JsonSerializer.Serialize(model,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }), Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("api/search/GetCachedSearch", cachedSearchRequestModel);
            var searchModel = await response.ReadContentAs<SearchCachedResponseModel>();
            return searchModel;
        }

        public async Task<BookModel> Book(BookRequestModel model)
        {
            // var flightModels = await GetFlightsFromFlightService(model.FlightIds);
            //  var hotelModels = await GetHotelsFromHotelService(model.HotelIds);

            // var flights = _mapper.Map<IList<Flight>>(flightModels);
            // var hotels = _mapper.Map<IList<Hotel>>(hotelModels);

            var SearchCachedRequestModel = new SearchCachedRequestModel()
            {
                SearchId = model.SearchId,
                FlightIds = model.FlightIds,
                HotelIds = model.HotelIds
            };

            var searchModel = await GetCachedSearchService(SearchCachedRequestModel);
            var flights = _mapper.Map<IList<Flight>>(searchModel.Flights);
            var hotels = _mapper.Map<IList<Hotel>>(searchModel.Hotels);

            var passengers = _mapper.Map<IList<Passenger>>(model.Passengers);

            var bookAdded = await _bookRepository.AddBook(new Book {Passengers = passengers, Flights = flights, Hotels = hotels});

            var bookModel = _mapper.Map<BookModel>(bookAdded);

            await _publishEndpoint.Publish<FlightBookEvent>(
                new FlightBookEvent(){FlightIds = model.FlightIds,PassengersCount = model.Passengers.Count});

            return bookModel;

        }
    }
}
