using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HotelService.Application.Common.Interfaces.Persistence;
using HotelService.Domain.Entities;
using MediatR;

namespace HotelService.Application.Hotels.Commands.CreateHotel
{
    class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, HotelVm>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public CreateHotelCommandHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<HotelVm> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = _mapper.Map<Hotel>(request);
            var addedHotel = await _hotelRepository.AddAsync(hotel);
            var hotelVm = _mapper.Map<HotelVm>(addedHotel);
            return hotelVm;
        }
    }
}
