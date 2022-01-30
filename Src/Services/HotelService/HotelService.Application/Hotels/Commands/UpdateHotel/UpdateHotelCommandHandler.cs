using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HotelService.Application.Common.Exceptions;
using HotelService.Application.Common.Interfaces.Persistence;
using HotelService.Domain.Entities;
using MediatR;

namespace HotelService.Application.Hotels.Commands.UpdateHotel
{
    class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, Unit>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public UpdateHotelCommandHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {

            var hotel = await _hotelRepository.GetByIdAsync(request.Id);

            if (hotel == null) throw new NotFoundException(nameof(Hotel), request.Id);

            _mapper.Map(request, hotel, typeof(UpdateHotelCommand), typeof(Hotel));
            
            await _hotelRepository.UpdateAsync(hotel);

            return Unit.Value;

        }
    }
}
