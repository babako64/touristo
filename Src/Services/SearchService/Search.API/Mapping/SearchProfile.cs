using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SearchService.API.Entities;
using SearchService.API.Models;

namespace SearchService.API.Mapping
{
    public class SearchProfile : Profile
    {

        public SearchProfile()
        {
            CreateMap<FlightSearchResponseModel, Flight>().ForMember(f => f.FlightId, 
                opt => 
                    opt.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<FlightSectionResponseModel, FlightSection>().
                ForMember(des => des.FlightSectionId,
                    opt => 
                        opt.MapFrom(src => src.Id)).ReverseMap();
            
            CreateMap<HotelSearchResponseModel, Hotel>().
                ForMember(des => des.HotelId, 
                    opt => 
                        opt.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<HotelRoomSearchResponseModel, HotelRoom>().ForMember(des => des.HotelRoomId,
                opt => 
                    opt.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<SearchResponseModel, Search>().ReverseMap();
        }

    }
}
