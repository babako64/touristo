using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightService.Application.Common.Interfaces.Persistence;
using MediatR;

namespace FlightService.Application.Flights.Command.BookFlight
{
    public class BookFlightCommandHandler : IRequestHandler<BookFlightCommand>
    {
        private readonly IFlightRepository _repository;

        public BookFlightCommandHandler(IFlightRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(BookFlightCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateBookedFlights(request.FlightIds, request.PassengersCount);
            return Unit.Value;
        }
    }
}
