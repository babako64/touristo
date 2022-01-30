using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FlightService.Application.Flights.Query.GetFlightById
{
    public class GetFlightByIdQuery : IRequest<FlightVm>
    {

        public Guid Id { get; set; }
    }
}
