using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class FlightBookEvent
    {
        public IList<Guid> FlightIds { get; set; }
        public int PassengersCount { get; set; }
    }
}
