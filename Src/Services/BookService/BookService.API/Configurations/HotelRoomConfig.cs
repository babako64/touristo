using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookService.API.Configurations
{
    public class HotelRoomConfig : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder.OwnsOne(r => r.Guest);
        }
    }
}
