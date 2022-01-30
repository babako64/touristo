using System;
using System.Collections.Generic;
using HotelService.Application.Hotels;
using HotelService.Application.Hotels.Commands.CreateHotel;
using MediatR;

namespace HotelService.Application.Hotels.Commands.CreateHotel
{
    public class CreateHotelCommand : IRequest<HotelVm>
    {
        public string Name { get; set; }
        public short Rate { get; set; }
        public string HotelCode { get; set; }
        public String CityCode { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Phone { get; set; }

        public ICollection<CreateHotelRoomCommand> Rooms { get; set; }
    }
}
