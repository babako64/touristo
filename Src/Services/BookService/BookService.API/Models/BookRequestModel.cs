using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.API.Models
{
    public class BookRequestModel
    {
        public IList<PassengerRequestModel> Passengers { get; set; }
        public string SearchId { get; set; }
        public IList<Guid> FlightIds { get; set; }
        public IList<Guid> HotelIds { get; set; }
    }

    public class PassengerRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
