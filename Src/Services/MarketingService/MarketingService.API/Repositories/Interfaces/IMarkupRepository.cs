using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingService.API.Entities;
using MarketingService.API.Enums;

namespace MarketingService.API.Repositories.Interfaces
{
    public interface IMarkupRepository
    {
        Task<Markup> GetById(int id);
        Task<ICollection<Markup>> GetByType(MarkupType markupType);
        Task<Markup> GetByCityCode(string cityCode);
        Task<Markup> GetByAirline(string airline);
        Task<IList<Markup>> GetByAirlines(IList<string> airlines);
        Task<bool> CreateMarkup(Markup markup);
        Task<bool> UpdateMarkup(Markup markup);
    }
}
