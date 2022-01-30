using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelService.Persistence.Configurations
{
    class HotelRoomConfiguration : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder.Property(r => r.BedType).IsRequired();
            builder.Property(r => r.Currency).HasMaxLength(3);
            builder.Property(r => r.Description).HasMaxLength(150);
            builder.OwnsOne(r => r.Guest);
        }
    }
}
