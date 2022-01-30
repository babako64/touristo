﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain.Common;

namespace HotelService.Application.Common.Interfaces.Persistence
{
    public interface IAsyncRepository<TEntity> where TEntity : EntityBase
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync(List<Expression<Func<TEntity, object>>> includes = null);
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeString = null,
            bool disableTracking = true);
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            bool disableTracking = true);
        Task<TEntity> GetByIdAsync(Guid id, List<Expression<Func<TEntity, object>>> includes = null);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
