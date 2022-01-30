using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain.Common;

namespace HotelService.Domain.Entities
{
    public class Hotel : EntityBase
    {
        public string Name { get; set; }
        public short Rate { get; set; }
        public string HotelCode { get; set; }
        public String CityCode { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Phone { get; set; }

        public ICollection<HotelRoom> Rooms { get; set; }
    }
}
