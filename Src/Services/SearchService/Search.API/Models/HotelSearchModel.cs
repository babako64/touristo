using System;
using System.Collections.Generic;
using SearchService.API.Models.Interfaces;

namespace SearchService.API.Models
{
    public class HotelSearchModel : ISearchModel
    {
        public string CityCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public IList<HotelRoomSearchModel> Rooms { get; set; }
    }

    public class HotelRoomSearchModel 
    {
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
    }
}
