using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.API.Models;

namespace BookService.API.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookModel> GetBookById(Guid id);
        Task<IList<BookModel>> GetBooks();
        Task<IList<FlightModel>> GetFlightsFromFlightService(IList<Guid> ids);
        Task<IList<FlightModel>> GetHotelsFromHotelService(IList<Guid> ids);
        Task<BookModel> Book(BookRequestModel model);
    }
}
