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

namespace HotelService.Application.Hotels.Queries.Search
{
    public class SearchHotelQueryHandler : IRequestHandler<SearchHotelQuery, IList<HotelVm>>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public SearchHotelQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<IList<HotelVm>> Handle(SearchHotelQuery request, CancellationToken cancellationToken)
        {

            var hotels = await _hotelRepository.Search(h => h.CityCode == request.CityCode &&
                                                           request.Rooms.All(r => h.Rooms.Any(hr => hr.Guest.Adults >= r.AdultCount &&
                                                               hr.Guest.Child >= r.ChildCount && 
                                                               request.CheckIn >= hr.FromDate && 
                                                               request.CheckOut <= hr.ToDate)),
                new List<Expression<Func<Hotel, object>>> { e => e.Rooms });

            var hotelVms = _mapper.Map<IList<HotelVm>>(hotels);

            return hotelVms;
        }
    }
}
