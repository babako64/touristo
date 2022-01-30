using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightService.Application.Models;

namespace FlightService.Application.Common.Interfaces.Infrastructure
{
    public interface IMarketingService
    {
        Task<IList<MarketingServiceResponseModel>> GetMarkupByAirline(MarketingServiceRequestModel model);
    }
}
