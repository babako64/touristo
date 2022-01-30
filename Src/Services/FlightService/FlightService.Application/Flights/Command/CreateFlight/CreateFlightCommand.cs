using System;
using System.Collections.Generic;
using FlightService.Application.Flights.Query;
using MediatR;

namespace FlightService.Application.Flights.Command.CreateFlight
{
    public class CreateFlightCommand : IRequest<FlightVm>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int SeatAvailable { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<CreateFlightSectionCommand> Sections { get; set; } 

    }
}
