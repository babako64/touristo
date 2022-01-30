using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SearchService.API.Entities;

namespace SearchService.API.Data
{
    public interface ISearchContext
    {
        IMongoCollection<Search> SearchCollection { get; set; }
    }
}
