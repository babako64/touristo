using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FlightService.Application.Common.Interfaces.Persistence;
using FlightService.Domain.Entities;
using FlightService.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Persistence.Repositories
{
    class FlightRepository : RepositoryBase<Flight>, IFlightRepository
    {
        private readonly FlightDbContext _context;

        public FlightRepository(FlightDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Flight>> SearchFlight(Expression<Func<Flight, bool>> predict, IList<Expression<Func<Flight, object>>> includes)
        {

            IQueryable<Flight> query = _context.Flights;
            if (includes != null) query = includes.Aggregate(query, (current, include) =>
                current.Include(include));

            return await query.Where(predict).ToListAsync();
        }

        public async Task<ICollection<Flight>> GetFlightListByIds(IList<Guid> ids)
        {
            var flights = await _context.Flights.Where(f => ids.Contains(f.Id)).ToListAsync();

            return flights;
        }

        public async Task UpdateBookedFlights(IList<Guid> flightIds, int passengerCount)
        {
            var flights = await _context.Flights.Where(f => flightIds.Contains(f.Id)).ToListAsync();
            flights.ForEach(f => f.SeatAvailable -= passengerCount);

            await _context.SaveChangesAsync();
        }
    }
}
