using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HotelService.Domain.Common;
using HotelService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Persistence.Data
{
    public class HotelDbContext : DbContext
    {

        public HotelDbContext(DbContextOptions<HotelDbContext> options):base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelDbContext).Assembly);
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
