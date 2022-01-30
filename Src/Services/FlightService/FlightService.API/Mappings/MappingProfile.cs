using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventBus.Messages.Events;
using FlightService.Application.Flights.Command.BookFlight;

namespace FlightService.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookFlightCommand, FlightBookEvent>().ReverseMap();
        }
    }
}
