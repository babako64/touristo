using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookService.API.Entities;
using BookService.API.Models;

namespace BookService.API.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookModel, Book>().ReverseMap();
            CreateMap<Flight, FlightModel>().ReverseMap();
            CreateMap<FlightSection, FlightSectionModel>().ReverseMap();
            CreateMap<Hotel, HotelModel>().ReverseMap();
            CreateMap<HotelRoom, HotelRoomModel>().ReverseMap();
            CreateMap<Guest, GuestModel>().ReverseMap();

            CreateMap<Passenger, PassengerModel>().ReverseMap();

            CreateMap<Passenger, PassengerRequestModel>().ReverseMap();
        }
    }
}
