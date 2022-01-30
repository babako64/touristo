using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchService.API.Models;
using SearchService.API.Services.Interfaces;

namespace SearchService.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SearchController :  ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IFlightService _flightService;
        private readonly IHotelService _hotelService;


        public SearchController(ISearchService searchService, IFlightService flightService, IHotelService hotelService)
        {
            _searchService = searchService;
            _flightService = flightService;
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<object>>> GetSearches()
        {
            return Ok(await _searchService.GetSearches());
        }

        [HttpPost]
        public async Task<ActionResult<object>> Search(SearchModel model)
        {
            return Ok(await _searchService.Search(model));
        }

        [HttpPost("GetCachedSearch")]
        public async Task<ActionResult<SearchResponseModel>> GetCachedSearch(GetCachedSearchRequestModel model)
        {

            var searchResponseModel = await _searchService.GetCachedSearch(model);

            return Ok(searchResponseModel);

        }

        [HttpDelete("all")]
        public async Task<ActionResult> DeleteAllSearches()
        {
            await _searchService.DeleteAllSearches();
            return Ok();
        }
    }
}
