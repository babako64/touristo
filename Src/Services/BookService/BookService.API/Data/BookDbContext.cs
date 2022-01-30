using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookService.API.Data
{
    public class BookDbContext : DbContext
    {

        public BookDbContext(DbContextOptions<BookDbContext> options):base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookDbContext).Assembly);
        }
    }
}
