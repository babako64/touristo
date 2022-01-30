using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.API.Data;
using BookService.API.Entities;
using BookService.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookService.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBookById(Guid id)
        {
            var book = await _context.Books.Include(b => b.Passengers).
                Include(b => b.Flights).ThenInclude(f => f.Sections).
                Include(b => b.Hotels).ThenInclude(h => h.Rooms).
                FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }

        public async Task<IList<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> AddBook(Book book)
        {
            book.Id = Guid.Empty;
            book.Flights.ToList().ForEach(f =>
            {
                f.Id = Guid.Empty;
                f.Sections.ToList().ForEach(s => s.Id = Guid.Empty);
            });

            book.Hotels.ToList().ForEach(h =>
            {
                h.Id = Guid.Empty;
                h.Rooms.ToList().ForEach(r => r.Id = Guid.Empty);
            });

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(Guid id)
        {
            var book = await _context.FindAsync<Book>(id);
            _context.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
