
using FlightService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightService.Persistence.Configurations
{
    class FlightSectionConfiguration : IEntityTypeConfiguration<FlightSection>
    {
        public void Configure(EntityTypeBuilder<FlightSection> builder)
        {
            builder.Property(f => f.OriginCityCode).HasMaxLength(3);
            builder.Property(f => f.DestinationCityCode).HasMaxLength(3);
            builder.Property(f => f.Currency).HasMaxLength(3);
        }
    }
}
