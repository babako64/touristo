using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightService.Application.Common.Interfaces.Persistence;
using FlightService.Application.Flights.Query;
using FlightService.Domain.Entities;
using MediatR;

namespace FlightService.Application.Flights.Command.CreateFlight
{
     class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, FlightVm>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public CreateFlightCommandHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<FlightVm> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = _mapper.Map<Flight>(request);

            var addedFlight = await _flightRepository.AddAsync(flight);

            var flightVm = _mapper.Map<FlightVm>(addedFlight);

            return flightVm;
        }
    }
}
