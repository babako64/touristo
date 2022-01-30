using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingService.API.Entities;
using MarketingService.API.Enums;
using MarketingService.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkupController : ControllerBase
    {
        private readonly IMarkupRepository _markupRepository;

        public MarkupController(IMarkupRepository markupRepository)
        {
            _markupRepository = markupRepository;
        }

        [HttpGet("{id}", Name = "GetMarkup")]
        public async Task<ActionResult<Markup>> GetMarkupById(int id)
        {
            var markup = await _markupRepository.GetById(id);
            if (markup == null)
            {
                return NotFound();
            }

            return Ok(markup);
        }

        [Route("markup-list/{markupType}")]
        [HttpGet]
        public async Task<ActionResult<ICollection<Markup>>> GetByType(string markupType)
        {
            return Ok(await _markupRepository.GetByType(Enum.Parse<MarkupType>(markupType)));
        }

        [HttpGet("city-code/{cityCode}")]
        public async Task<ActionResult<Markup>> GetByCityCode(string cityCode)
        {
            var markup = await _markupRepository.GetByCityCode(cityCode);
            if (markup == null)
            {
                return NotFound();
            }

            return Ok(markup);
        }

        [HttpGet("airline/{airline}")]
        public async Task<ActionResult<Markup>> GetByAirline(string airline)
        {
            var markup = await _markupRepository.GetByAirline(airline);
            if (markup == null)
            {
                return NotFound();
            }

            return Ok(markup);
        }

        [HttpPost("airline")]
        public async Task<ActionResult<IList<Markup>>> GetByAirlines(IList<string> airlines)
        {
            var markup = await _markupRepository.GetByAirlines(airlines);
            if (markup == null)
            {
                return NotFound();
            }

            return Ok(markup);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMarkup(Markup markup)
        {
            var affected = await _markupRepository.CreateMarkup(markup);
            if (!affected) return BadRequest();

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMarkup(Markup markup)
        {
            var affected = await _markupRepository.UpdateMarkup(markup);
            if (!affected) return BadRequest();

            return NoContent();
        }
    }
}
