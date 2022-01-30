using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.API.Models;
using BookService.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;


        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost]
        public async Task<ActionResult<BookModel>> Book(BookRequestModel model)
        {
            var bookModel = await _bookService.Book(model);

            if (bookModel == null || bookModel.Id == Guid.Empty)
            {
                return BadRequest("Something went wrong please try again later");
            }

            return Ok(bookModel);
        }
    }
}
