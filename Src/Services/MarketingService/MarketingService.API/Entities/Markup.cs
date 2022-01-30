using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingService.API.Enums;

namespace MarketingService.API.Entities
{
    public class Markup
    {
        public int Id { get; set; }
        public decimal Percent { get; set; }
        public string CityCode { get; set; }
        public string Airline { get; set; }
        public MarkupType Type { get; set; }
    }
}
