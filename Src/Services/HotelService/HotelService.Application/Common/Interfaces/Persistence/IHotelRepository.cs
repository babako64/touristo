using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain.Entities;

namespace HotelService.Application.Common.Interfaces.Persistence
{
    public interface IHotelRepository : IAsyncRepository<Hotel>
    {
        public Task<ICollection<Hotel>> Search(Expression<Func<Hotel, bool>> predicate = null,
            List<Expression<Func<Hotel, object>>> includes = null);

        public Task<ICollection<Hotel>> GetHotelsByIds(IList<Guid> ids);
    }
}
