
using AutoMapper;
using HotelService.Application.Hotels;
using HotelService.Application.Hotels.Commands.CreateHotel;
using HotelService.Application.Hotels.Commands.UpdateHotel;
using HotelService.Domain.Entities;

namespace HotelService.Application.Common.Mappings
{
    public class HotelMappingProfile : Profile
    {

        public HotelMappingProfile()
        {
            CreateMap<CreateHotelCommand, Hotel>().ReverseMap();
            CreateMap<CreateHotelRoomCommand, HotelRoom>().ReverseMap();

            CreateMap<Hotel, HotelVm>().ReverseMap();
            CreateMap<HotelRoom, HotelRoomVm>().ReverseMap();

            CreateMap<UpdateHotelCommand, Hotel>().ReverseMap();
            CreateMap<UpdateHotelRoomCommand, HotelRoom>().ReverseMap();


        }

    }
}
