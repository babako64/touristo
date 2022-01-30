using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightService.Application.Common.Interfaces.Persistence;
using MediatR;

namespace FlightService.Application.Flights.Query.GetFlightListByIds
{
    public class GetFlightListByIdsQueryHandler : IRequestHandler<GetFlightListByIdsQuery,IList<FlightVm>>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public GetFlightListByIdsQueryHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<IList<FlightVm>> Handle(GetFlightListByIdsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _flightRepository.GetFlightListByIds(request.Ids);

            var flightVms = _mapper.Map<IList<FlightVm>>(flights);

            return flightVms;
        }
    }
}
