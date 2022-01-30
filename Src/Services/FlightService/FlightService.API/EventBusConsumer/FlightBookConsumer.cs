using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventBus.Messages.Events;
using FlightService.Application.Flights.Command.BookFlight;
using MassTransit;
using MediatR;

namespace FlightService.API.EventBusConsumer
{
    public class FlightBookConsumer : IConsumer<FlightBookEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public FlightBookConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<FlightBookEvent> context)
        {
            var bookFlightCommand = _mapper.Map<BookFlightCommand>(context.Message);
            await _mediator.Send(bookFlightCommand);
        }
    }
}
