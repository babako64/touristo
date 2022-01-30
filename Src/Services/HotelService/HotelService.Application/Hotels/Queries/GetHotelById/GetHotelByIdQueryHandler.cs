using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HotelService.Application.Common.Exceptions;
using HotelService.Application.Common.Interfaces.Persistence;
using HotelService.Domain.Entities;
using MediatR;

namespace HotelService.Application.Hotels.Queries.GetHotelById
{
    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery,HotelVm>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public GetHotelByIdQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<HotelVm> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetByIdAsync(request.Id, 
                new List<Expression<Func<Hotel, object>>> { e => e.Rooms });

            if (hotel == null) throw new NotFoundException(nameof(Hotel), request.Id);

            var hotelVm = _mapper.Map<HotelVm>(hotel);
            return hotelVm;
        }
    }
}
