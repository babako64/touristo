using System;
using System.Collections.Generic;
using FlightService.Domain.Common;

namespace FlightService.Domain.Entities
{
    public class Flight : EntityBase
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int SeatAvailable { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<FlightSection> Sections { get; set; }
    }
}
