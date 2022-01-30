using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightService.Application.Common.Interfaces.Persistence;
using MediatR;

namespace FlightService.Application.Flights.Query.GetFlightList
{
    class GetFlightListQueryHandler : IRequestHandler<GetFlightListQuery, IList<FlightVm>>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public GetFlightListQueryHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<IList<FlightVm>> Handle(GetFlightListQuery request, CancellationToken cancellationToken)
        {
            var flights = await _flightRepository.GetAllAsync();

            var flightVms = _mapper.Map<IList<FlightVm>>(flights);

            return flightVms;
        }
    }
}
