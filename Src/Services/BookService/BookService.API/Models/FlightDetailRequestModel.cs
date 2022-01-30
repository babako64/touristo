using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.API.Models
{
    public class FlightDetailRequestModel
    {
        public IList<Guid> Ids { get; set; }

        public FlightDetailRequestModel(IList<Guid> ids)
        {
            Ids = ids;
        }
    }
}
