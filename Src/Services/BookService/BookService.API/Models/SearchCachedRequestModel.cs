using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.API.Models
{
    public class SearchCachedRequestModel
    {
        public string SearchId { get; set; }
        public IList<Guid> FlightIds { get; set; }
        public IList<Guid> HotelIds { get; set; }
    }
}
