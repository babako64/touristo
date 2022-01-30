using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HotelService.Application.Common.Interfaces.Persistence;
using HotelService.Domain.Entities;
using MediatR;

namespace HotelService.Application.Hotels.Queries.GetHotelList
{
    public class GetHotelListQueryHandler : IRequestHandler<GetHotelListQuery, IList<HotelVm>>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public GetHotelListQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<IList<HotelVm>> Handle(GetHotelListQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetAllAsync(
                new List<Expression<Func<Hotel, object>>> { e => e.Rooms });
            var hotelVms = _mapper.Map<IList<HotelVm>>(hotels);
            return hotelVms;
        }
    }
}
