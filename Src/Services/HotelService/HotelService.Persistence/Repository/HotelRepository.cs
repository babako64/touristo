using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelService.Application.Common.Interfaces.Persistence;
using HotelService.Domain.Entities;
using HotelService.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Persistence.Repository
{
    public class HotelRepository : RepositoryBase<Hotel>,IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<Hotel>> Search(Expression<Func<Hotel, bool>> predicate, List<Expression<Func<Hotel, object>>> includes = null)
        {

            IQueryable<Hotel> query = _context.Hotels;
            if (includes != null) query = includes.Aggregate(query, (current, include) =>
                current.Include(include));

            var listAsync = await query.ToListAsync();
            var enumerable = listAsync.Where(predicate.Compile()).ToList();

            return enumerable;
        }

        public async Task<ICollection<Hotel>> GetHotelsByIds(IList<Guid> ids)
        {
            var hotels = await _context.Hotels.Where(h => ids.Contains(h.Id)).ToListAsync();

            return hotels;
        }
    }
}
