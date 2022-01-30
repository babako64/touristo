using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain.Entities;
using HotelService.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelService.Persistence.Configurations
{
    class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {

            builder.Property(h => h.CityCode).HasMaxLength(3);
            builder.Property(h => h.Rate).HasMaxLength(5);
            builder.Property(h => h.Name).IsRequired();
            builder.HasMany(h => h.Rooms).
                WithOne(r => r.Hotel).HasForeignKey(r => r.HotelId);
        }
    }
}
