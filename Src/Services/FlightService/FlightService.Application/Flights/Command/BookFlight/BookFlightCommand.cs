using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FlightService.Application.Flights.Command.BookFlight
{
    public class BookFlightCommand : IRequest
    {
        public IList<Guid> FlightIds { get; set; }
        public int PassengersCount { get; set; }
    }
}
