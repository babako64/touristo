using System;
using HotelService.Domain.Entities;

namespace HotelService.Application.Hotels.Commands.CreateHotel
{
    public class CreateHotelRoomCommand
    {
        public string Category { get; set; }
        public int Beds { get; set; }
        public string BedType { get; set; }
        public Guest Guest { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
