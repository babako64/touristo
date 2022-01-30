using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlightService.Application.Common.Interfaces.Persistence;
using FlightService.Domain.Common;
using FlightService.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Persistence.Repositories
{
    public class RepositoryBase<TEntity> : IAsyncRepository<TEntity> where TEntity : EntityBase
    {
        private readonly FlightDbContext _context;
        private readonly DbSet<TEntity> dbset;
        
        public RepositoryBase(FlightDbContext context)
        {
            _context = context;
            dbset = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            dbset.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await dbset.Include("Sections").ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await dbset.Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbset;
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbset;
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id, List<Expression<Func<TEntity, object>>> includes = null)
        {
            IQueryable<TEntity> query = dbset;
            if (includes != null) query = includes.Aggregate(query, (current, include) => 
                current.Include(include));

            return await query.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
