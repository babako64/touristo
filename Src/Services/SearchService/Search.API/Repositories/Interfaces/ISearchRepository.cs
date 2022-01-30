using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchService.API.Entities;

namespace SearchService.API.Repositories.Interfaces
{
    public interface ISearchRepository
    {
        Task<bool> SearchIdExist(string searchId);
        Task<string> CreateSearch(Search search);
        public Task<IList<Search>> GetAll();
        public Task<Search> GetSearch(string id);
        Task<IList<Flight>> GetFlightByIds(string searchId, IList<Guid> ids);
        Task<IList<Hotel>> GetHotelByIds(string searchId, IList<Guid> ids);
        public Task DeleteSearch(string id);
        Task DeleteAllSearches();
    }
}
