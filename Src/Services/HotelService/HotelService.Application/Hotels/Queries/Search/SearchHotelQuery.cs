using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HotelService.Application.Hotels.Queries.Search
{
    public class SearchHotelQuery : IRequest<IList<HotelVm>>
    {
        public string CityCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public IList<SearchRoom> Rooms { get; set; }
    }

    public class SearchRoom
    {
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
    }
}
