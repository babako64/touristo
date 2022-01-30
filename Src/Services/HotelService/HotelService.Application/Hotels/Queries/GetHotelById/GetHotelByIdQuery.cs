using System;
using MediatR;

namespace HotelService.Application.Hotels.Queries.GetHotelById
{
    public record GetHotelByIdQuery(Guid Id) : IRequest<HotelVm>;
}
