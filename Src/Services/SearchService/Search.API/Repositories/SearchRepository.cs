using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SearchService.API.Data;
using SearchService.API.Entities;
using SearchService.API.Repositories.Interfaces;

namespace SearchService.API.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ISearchContext _context;
        private readonly IMongoCollection<Search> searchCollection;

        public SearchRepository(ISearchContext context)
        {
            _context = context;
            searchCollection = _context.SearchCollection;
        }


        public async Task<bool> SearchIdExist(string searchId)
        {
            var search = await searchCollection.Find(s => s.Id == searchId).FirstOrDefaultAsync();
            if (search == null)
            {
                return false;
            }

            return true;
        }

        public async Task<string> CreateSearch(Search search)
        {
            await searchCollection.InsertOneAsync(search);
            return search.Id;
        }

        public async Task<IList<Search>> GetAll()
        {
            return await searchCollection.Find(f => true).ToListAsync();
        }

        public async Task<Search> GetSearch(string id)
        {
            var search = await searchCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
            return search;
        }

        public async Task<IList<Flight>> GetFlightByIds(string searchId,IList<Guid> ids)
        {
            FilterDefinition<Search> filter =
                Builders<Search>.Filter.Where(s => s.Id == searchId);

            var search = await searchCollection.Find(filter).FirstOrDefaultAsync();

            var flights = search.Flights.Where(s => ids.Contains(s.FlightId)).ToList();

            return flights;
        }

        public async Task<IList<Hotel>> GetHotelByIds(string searchId,IList<Guid> ids)
        {
            FilterDefinition<Search> filter =
                Builders<Search>.Filter.Where(s => s.Id == searchId);

            var search = await searchCollection.Find(filter).FirstOrDefaultAsync();

            var hotels = search.Hotels.Where(h => ids.Contains(h.HotelId)).ToList();

            return hotels;
        }

        public async Task DeleteSearch(string id)
        {
            await searchCollection.DeleteOneAsync(s => s.Id == id);
        }

        public async Task DeleteAllSearches()
        {
            await searchCollection.DeleteManyAsync(Builders<Search>.Filter.Empty);
        }
    }
}
