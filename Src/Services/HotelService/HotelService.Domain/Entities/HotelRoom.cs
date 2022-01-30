using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain.Common;

namespace HotelService.Domain.Entities
{
    public class HotelRoom : EntityBase
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

        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
