using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightService.Application.Common.Interfaces.Infrastructure;
using FlightService.Application.Common.Interfaces.Persistence;
using FlightService.Application.Models;
using FlightService.Domain.Entities;
using MediatR;

namespace FlightService.Application.Flights.Query.GetFlightSearch
{
    class FlightSearchQueryHandler : IRequestHandler<FlightSearchQuery,ICollection<FlightSearchVm>>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMarketingService _marketingService;
        private readonly IMapper _mapper;

        public FlightSearchQueryHandler(IFlightRepository flightRepository, IMarketingService marketingService, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _marketingService = marketingService;
            _mapper = mapper;
        }

        public async Task<ICollection<FlightSearchVm>> Handle(FlightSearchQuery request, CancellationToken cancellationToken)
        {

            var flight = await _flightRepository.SearchFlight(f => f.IsAvailable == true &&
                                                                   f.FromDate <= request.FlightDate &&
                                                                   f.ToDate >= request.FlightDate &&
                                                                   f.SeatAvailable >= request.PassengerCount &&
                                                                   f.Sections != null && f.Sections.Count > 0 &&
                                                                   f.Sections.Any(s =>
                                                                       s.OriginCityCode == request.OriginCityCode &&
                                                                       s.DestinationCityCode ==
                                                                       request.DestinationCityCode), 
                new List<Expression<Func<Flight, object>>>{i => i.Sections});

            if (flight == null)
            {
                return null;
            }

            var marketing = await _marketingService.GetMarkupByAirline(new MarketingServiceRequestModel()
                {Airline = flight.Select(f => f.Sections.Select(s => s.AirlineName)).
                    SelectMany(m => m).ToList()});

            var flightSearchVm = _mapper.Map<IList<FlightSearchVm>>(flight);

            CalculatePrice(marketing, flightSearchVm);

            return flightSearchVm;
        }

        private void CalculatePrice(IList<MarketingServiceResponseModel> marketModel, IList<FlightSearchVm> flightSearch)
        {

              flightSearch.ToList().ForEach(f =>
                f.Sections.ToList().ForEach(s =>
                {
                    var markup = marketModel.FirstOrDefault(m => m.Airline == s.AirlineName);

                    if (markup != null)
                    {
                        s.Price += (s.Price * (double)markup.Percent) / 100;
                    }

                }));
        }
    }
}
