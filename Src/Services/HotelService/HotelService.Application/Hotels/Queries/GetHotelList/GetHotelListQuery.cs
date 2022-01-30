using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HotelService.Application.Hotels.Queries.GetHotelList
{
    public record GetHotelListQuery() : IRequest<IList<HotelVm>>;

}
