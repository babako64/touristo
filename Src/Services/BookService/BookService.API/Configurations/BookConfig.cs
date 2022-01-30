using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookService.API.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(b => b.Passengers);
            builder.HasMany(b => b.Flights);
            builder.HasMany(b => b.Hotels);
        }
    }
}
