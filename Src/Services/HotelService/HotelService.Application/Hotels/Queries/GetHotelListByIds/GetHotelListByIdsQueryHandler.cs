using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HotelService.Application.Common.Interfaces.Persistence;
using MediatR;

namespace HotelService.Application.Hotels.Queries.GetHotelListByIds
{
    public class GetHotelListByIdsQueryHandler : IRequestHandler<GetHotelListByIdsQuery, IList<HotelVm>>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public GetHotelListByIdsQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<IList<HotelVm>> Handle(GetHotelListByIdsQuery request, CancellationToken cancellationToken)
        {

            var hotels = await _hotelRepository.GetHotelsByIds(request.Ids);

            var hotelVms = _mapper.Map<IList<HotelVm>>(hotels);

            return hotelVms;

        }
    }
}
