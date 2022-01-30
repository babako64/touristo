using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain.Enums;

namespace HotelService.Domain.Entities
{
    public class Guest
    {
        public int Adults { get; set; }
        public int Child { get; set; }
    }
}
