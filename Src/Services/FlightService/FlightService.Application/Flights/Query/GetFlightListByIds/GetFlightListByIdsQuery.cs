using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FlightService.Application.Flights.Query.GetFlightListByIds
{
    public class GetFlightListByIdsQuery : IRequest<IList<FlightVm>>
    {
        public IList<Guid> Ids { get; set; }
    }
}
