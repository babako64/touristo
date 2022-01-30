using System.Collections.Generic;
using AutoMapper;
using FlightService.Application.Flights.Command;
using FlightService.Application.Flights.Command.BookFlight;
using FlightService.Application.Flights.Command.CreateFlight;
using FlightService.Application.Flights.Command.UpdateFlight;
using FlightService.Application.Flights.Query;
using FlightService.Application.Flights.Query.GetFlightSearch;
using FlightService.Domain.Entities;

namespace FlightService.Application.Common.Mappings
{
    class FlightMappingProfile : Profile
    {

        public FlightMappingProfile()
        {
            CreateMap<CreateFlightCommand, Flight>().ReverseMap();
            CreateMap<CreateFlightSectionCommand, FlightSection>();
            CreateMap<UpdateFlightCommand, Flight>().ReverseMap();
            CreateMap<Flight, FlightSearchVm>().ReverseMap();
            CreateMap<FlightSection, FlightSectionSearchVm>().ReverseMap();
            CreateMap<Flight, FlightVm>().ReverseMap();
            CreateMap<FlightSection, FlightSectionVm>().ReverseMap();
        }

    }
}
