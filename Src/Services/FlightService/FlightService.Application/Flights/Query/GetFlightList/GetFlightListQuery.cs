using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FlightService.Application.Flights.Query.GetFlightList
{
    public record GetFlightListQuery() : IRequest<IList<FlightVm>>;
}
