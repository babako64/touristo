using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightService.Application.Common.Exceptions;
using FlightService.Application.Common.Interfaces.Persistence;
using FlightService.Domain.Entities;
using MediatR;

namespace FlightService.Application.Flights.Query.GetFlightById
{
    public class GetFlightByIdQueryHandler : IRequestHandler<GetFlightByIdQuery, FlightVm>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public GetFlightByIdQueryHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<FlightVm> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
        {

            var flight = await _flightRepository.GetByIdAsync(request.Id, 
                new List<Expression<Func<Flight, object>>>{e => e.Sections});

            _ = flight ?? throw new NotFoundException(nameof(Flight), request.Id);

            var flightVm = _mapper.Map<FlightVm>(flight);

            return flightVm;

        }
    }
}
