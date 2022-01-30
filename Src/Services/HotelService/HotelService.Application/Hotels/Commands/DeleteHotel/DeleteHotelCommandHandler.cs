using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HotelService.Application.Common.Exceptions;
using HotelService.Application.Common.Interfaces.Persistence;
using HotelService.Domain.Entities;
using MediatR;

namespace HotelService.Application.Hotels.Commands.DeleteHotel
{
    class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand,Unit>
    {
        private readonly IHotelRepository _hotelRepository;

        public DeleteHotelCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Unit> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {

            var hotel = await _hotelRepository.GetByIdAsync(request.Id);

            if (hotel == null) throw new NotFoundException(nameof(Hotel), request.Id);

            await _hotelRepository.DeleteAsync(hotel);

            return Unit.Value;
        }
    }
}
