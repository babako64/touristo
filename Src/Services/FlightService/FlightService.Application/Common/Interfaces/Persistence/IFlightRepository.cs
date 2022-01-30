using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FlightService.Domain.Entities;

namespace FlightService.Application.Common.Interfaces.Persistence
{
    public interface IFlightRepository : IAsyncRepository<Flight>
    {
        public Task<ICollection<Flight>> SearchFlight(Expression<Func<Flight,bool>> predict, IList<Expression<Func<Flight,object>>> includes);
        public Task<ICollection<Flight>> GetFlightListByIds(IList<Guid> ids);
        Task UpdateBookedFlights(IList<Guid> flightIds, int passengerCount);
    }
}
