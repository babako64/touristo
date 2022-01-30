using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightService.Application.Flights.Command.CreateFlight;
using FlightService.Application.Flights.Command.DeleteFlight;
using FlightService.Application.Flights.Command.UpdateFlight;
using FlightService.Application.Flights.Query;
using FlightService.Application.Flights.Query.GetFlightById;
using FlightService.Application.Flights.Query.GetFlightList;
using FlightService.Application.Flights.Query.GetFlightListByIds;
using FlightService.Application.Flights.Query.GetFlightSearch;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlightService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FlightController> _logger;

        public FlightController(IMediator mediator, ILogger<FlightController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<object>> GetFlight()
        {
            var getAllQuery = new GetFlightListQuery();
            var flightVm = await _mediator.Send(getAllQuery);

            return Ok(flightVm);
        }

        [HttpPost("GetFlightListByIds")]
        public async Task<ActionResult<IList<FlightVm>>> GeFlightListByIds(GetFlightListByIdsQuery query)
        {
            var flightVms = await _mediator.Send(query);

            return Ok(flightVms);
        }

        [HttpGet("{id}", Name = "GetFlight")]
        public async Task<ActionResult<object>> GetFlightById(Guid id)
        {
            var getFlightQuery = new GetFlightByIdQuery {Id = id};

            var flightVm = await _mediator.Send(getFlightQuery);
            if (flightVm == null) return NotFound();

            return Ok(flightVm);
        }

        [HttpPost]
        public async Task<ActionResult<object>> AddFlight(CreateFlightCommand flightCommand)
        {
            if (flightCommand == null)
            {
                return BadRequest();
            }

            var flightVm = await _mediator.Send(flightCommand);

            return CreatedAtRoute("GetFlight", new {Id = flightVm.Id}, flightVm);
        }


        [HttpPost("search")]
        public async Task<ActionResult<IList<FlightSearchVm>>> SearchFlight(FlightSearchQuery searchQuery)
        {
            var flightSearchVm = await _mediator.Send(searchQuery);

            return Ok(flightSearchVm);
        }

        [HttpPut]
        public async Task<ActionResult<object>> UpdateFlight(UpdateFlightCommand updateFlightCommand)
        {

            await _mediator.Send(updateFlightCommand);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<object>> DeleteFlight(DeleteFlightCommand deleteFlightCommand)
        {

            await _mediator.Send(deleteFlightCommand);

            return NoContent();
        }
    }
}
