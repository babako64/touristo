using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelService.Application.Hotels;
using HotelService.Application.Hotels.Commands.CreateHotel;
using HotelService.Application.Hotels.Commands.DeleteHotel;
using HotelService.Application.Hotels.Queries.GetHotelById;
using HotelService.Application.Hotels.Queries.GetHotelList;
using HotelService.Application.Hotels.Queries.GetHotelListByIds;
using HotelService.Application.Hotels.Queries.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HotelController> _logger;

        public HotelController(IMediator mediator, ILogger<HotelController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IList<HotelVm>>> GetHotelList()
        {
            var hotels = await _mediator.Send(new GetHotelListQuery());

            if (hotels == null) return Ok(new List<HotelVm> {new HotelVm()});

            return Ok(hotels);
        }

        [HttpPost("GetHotelListByIds")]
        public async Task<ActionResult<IList<HotelVm>>> GetHotelListByIds(GetHotelListByIdsQuery query)
        {
            var hotelVms = await _mediator.Send(query);

            return Ok(hotelVms);
        }


        [HttpGet("{id}", Name = "GetHotel")]
        public async Task<ActionResult<HotelVm>> GetHotelById([FromRoute] Guid id)
        {
            var hotelVm = await _mediator.Send(new GetHotelByIdQuery(id));

            if (hotelVm == null) return NotFound();

            return Ok(hotelVm);
        }

        [HttpPost("search")]
        public async Task<ActionResult<IList<HotelVm>>> HotelSearch(SearchHotelQuery searchHotelQuery)
        {
            var hotelVms = await _mediator.Send(searchHotelQuery);
            return Ok(hotelVms);
        }

        [HttpPost]
        public async Task<ActionResult<object>> AddHotel(CreateHotelCommand hotelCommand)
        {
            var addHotel = await _mediator.Send(hotelCommand);

            if (addHotel == null)
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetHotel", new {id = addHotel.Id}, addHotel);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteHotel(DeleteHotelCommand deleteHotelCommand)
        {
            await _mediator.Send(deleteHotelCommand);
            return NoContent();
        }
    }
}
