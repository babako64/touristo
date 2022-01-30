using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightService.Application.Common.Exceptions;
using FlightService.Application.Common.Interfaces.Persistence;
using MediatR;

namespace FlightService.Application.Flights.Command.DeleteFlight
{
    public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand>
    {
        private readonly IFlightRepository _flightRepository;

        public DeleteFlightCommandHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<Unit> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepository.GetByIdAsync(request.Id);

            if (flight == null)
            {
                throw new NotFoundException(nameof(flight), request.Id);
            }

            await _flightRepository.DeleteAsync(flight);

            return Unit.Value;
        }
    }
}
