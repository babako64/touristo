using System;

namespace HotelService.Application.Common.Exceptions
{
    class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" {key} not found")
        {
        }
    }
}
