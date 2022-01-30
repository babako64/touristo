using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightService.Application.Common.Exceptions;
using FlightService.Application.Common.Interfaces.Persistence;
using FlightService.Domain.Entities;
using MediatR;

namespace FlightService.Application.Flights.Command.UpdateFlight
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public UpdateFlightCommandHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {

            var flight = await _flightRepository.GetByIdAsync(request.Id);

            if (flight == null)
            {
                throw new NotFoundException(nameof(Flight), flight.Id);
            }

            _mapper.Map(request, flight, typeof(UpdateFlightCommand), typeof(Flight));

            await _flightRepository.UpdateAsync(flight);

            return Unit.Value;
        }
    }
}
