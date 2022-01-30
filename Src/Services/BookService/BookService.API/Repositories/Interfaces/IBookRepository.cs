using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.API.Entities;

namespace BookService.API.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public Task<Book> GetBookById(Guid id);
        public Task<IList<Book>> GetBooks();
        public Task<Book> AddBook(Book book);
        public Task<Book> UpdateBook(Book book);
        public Task DeleteBook(Guid id);
    }
}
