using MongoDB.Driver;
using SearchService.API.Entities;
using SearchService.API.Settings;

namespace SearchService.API.Data
{
    public class SearchContext : ISearchContext
    {

        public IMongoCollection<Search> SearchCollection { get; set; }

        public SearchContext(ISearchDatabaseSettings databaseSettings)
        {

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            SearchCollection = database.GetCollection<Search>(databaseSettings.CollectionName);
        }
        

    }
}
