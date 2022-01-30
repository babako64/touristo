using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelService.Application.Common.Interfaces.Persistence;
using HotelService.Domain.Common;
using HotelService.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Persistence.Repository
{
    public class RepositoryBase<TEntity> : IAsyncRepository<TEntity> where TEntity : EntityBase
    {
        private readonly HotelDbContext _context;
        private readonly DbSet<TEntity> _dbset;

        public RepositoryBase(HotelDbContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }


        public async Task<IReadOnlyList<TEntity>> GetAllAsync(List<Expression<Func<TEntity, object>>> includes = null)
        {
            IQueryable<TEntity> query = _dbset;
            if (includes != null) query = includes.Aggregate(query, (current, include) =>
                current.Include(include));

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbset.Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeString = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbset;
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbset;
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id, List<Expression<Func<TEntity, object>>> includes = null)
        {
            IQueryable<TEntity> query = _dbset;
            if (includes != null) query = includes.Aggregate(query, (current, include) => 
                current.Include(include));
            var entity = await query.FirstOrDefaultAsync(h => h.Id == id);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbset.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
