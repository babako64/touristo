using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.API.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
