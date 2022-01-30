using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FlightService.Application.Flights.Command.UpdateFlight
{
    public class UpdateFlightCommand: IRequest
    {
        public Guid Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int SeatAvailable { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<UpdateFlightSectionCommand> Sections { get; set; }
    }
}
