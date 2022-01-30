using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MarketingService.API.Entities;
using MarketingService.API.Enums;
using MarketingService.API.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MarketingService.API.Repositories
{
    public class MarkupRepository : IMarkupRepository
    {
        private readonly IConfiguration _configuration;

        public MarkupRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Markup> GetById(int id)
        {
            await using var connection = new NpgsqlConnection(_configuration["DatabaseSettings:ConnectionString"]);
            var markup = await connection.QueryFirstOrDefaultAsync<Markup>("SELECT * FROM Markup WHERE Id = @Id", new {Id = id});

            return markup;
        }

        public async Task<ICollection<Markup>> GetByType(MarkupType markupType)
        {
            await using var connection = new NpgsqlConnection(_configuration["DatabaseSettings:ConnectionString"]);
            var markups = await connection.QueryAsync<Markup>("SELECT * FROM Markup WHERE Type = @TypeInt",
                new {TypeInt = (int) markupType});
            if (markups == null)
            {
                return new List<Markup>();
            }

            return markups.ToList();
        }

        public async Task<Markup> GetByCityCode(string cityCode)
        {
            await using var connection = new NpgsqlConnection(_configuration["DatabaseSettings:ConnectionString"]);
            var markup = await connection.QueryFirstOrDefaultAsync<Markup>("SELECT * FROM Markup WHERE CityCode = @CityCode",
                new {CityCode = cityCode});

            if (markup == null)
            {
                return null;
            }

            return markup;
        }

        public async Task<Markup> GetByAirline(string airline)
        {
            await using var connection = new NpgsqlConnection(_configuration["DatabaseSettings:ConnectionString"]);
            var markup = await connection.QueryFirstOrDefaultAsync<Markup>("SELECT * FROM Markup WHERE Airline = @Airline",
                new { Airline =  airline});

            if (markup == null)
            {
                return null;
            }

            return markup;
        }

        public async Task<IList<Markup>> GetByAirlines(IList<string> airlines)
        {
            await using var connection = new NpgsqlConnection(_configuration["DatabaseSettings:ConnectionString"]);
            var markup = await connection.QueryAsync<Markup>("SELECT * FROM Markup WHERE Airline = ANY(@Airline)",
                new { Airline = airlines });

            if (markup == null)
            {
                return null;
            }

            return markup.ToList();
        }

        public async Task<bool> CreateMarkup(Markup markup)
        {
            await using var connection = new NpgsqlConnection(_configuration["DatabaseSettings:ConnectionString"]);
            var affected = await connection.ExecuteAsync("INSERT INTO Markup (Percent,CityCode,Airline,Type) " +
                                                         "VALUES (@Percent,@CityCode,@Airline,@Type)",
                new { Percent = markup.Percent, CityCode = markup.CityCode, Airline = markup.Airline, 
                    Type = (int)markup.Type });
            if (affected == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateMarkup(Markup markup)
        {
            await using var connection = new NpgsqlConnection(_configuration["DatabaseSettings:ConnectionString"]);
            var affected = await connection.ExecuteAsync("UPDATE Markup SET " +
                                                         "Percent = @Percent,CityCode = @CityCode,Airline = @Airline,Type = @Type " +
                                                         "WHERE Id = @Id",
                new { Percent = markup.Percent, CityCode = markup.CityCode, Airline = markup.Airline, Type = (int)markup.Type, Id = markup.Id });

            if (affected == 0)
            {
                return false;
            }

            return true;
        }
    }
}
