using System;
using System.Threading;
using System.Threading.Tasks;
using FlightService.Domain.Common;
using FlightService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Persistence.Data
{
    public class FlightDbContext : DbContext
    {

        public FlightDbContext(DbContextOptions<FlightDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightSection> FlightSections { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlightDbContext).Assembly);

        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
