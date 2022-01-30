using System;

namespace FlightService.Domain.Common
{
    public abstract class EntityBase
    {

        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }

    }
}
