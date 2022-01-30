using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain.Entities;
using MediatR;

namespace HotelService.Application.Hotels.Commands.UpdateHotel
{
    public class UpdateHotelCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public short Rate { get; set; }
        public string HotelCode { get; set; }
        public String CityCode { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Phone { get; set; }

        public ICollection<UpdateHotelRoomCommand> Rooms { get; set; }
    }

    public class UpdateHotelRoomCommand : IRequest
    {
        public Guid Id { get; set; }
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
