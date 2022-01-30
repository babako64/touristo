using System;
using System.Collections.Generic;

namespace BookService.API.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public IEnumerable<PassengerModel> Passengers { get; set; }
        public IEnumerable<FlightModel> Flights { get; set; }
        public IEnumerable<HotelModel> Hotels { get; set; }
    }
}