using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HotelService.Application.Hotels.Queries.GetHotelListByIds
{
    public class GetHotelListByIdsQuery : IRequest<IList<HotelVm>>
    {
        public IList<Guid> Ids { get; set; }
    }
}
