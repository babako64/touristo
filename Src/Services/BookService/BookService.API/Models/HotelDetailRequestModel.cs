using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.API.Models
{
    public class HotelDetailRequestModel
    {
        public IList<Guid> Ids { get; set; }

        public HotelDetailRequestModel(IList<Guid> ids)
        {
            Ids = ids;
        }
    }
}
