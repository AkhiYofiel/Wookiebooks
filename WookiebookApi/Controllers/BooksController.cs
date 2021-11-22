using Microsoft.AspNetCore.Mvc;
using WookieBooks.Core.IRepository;
using WookieBooks.Models;

namespace WookieBooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookRepository;
        public BooksController(IBookService _bookRepository)
        {
            this._bookRepository = _bookRepository;

        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Getbooks()
        {

            return await _bookRepository.GetAll();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            if (id <= 0)
            {

                throw new KeyNotFoundException("Invalid Book Id");
            }
            var book = await _bookRepository.Get(id);

            if (book == null)
            {
                throw new FileNotFoundException("Book Details not found");
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                throw new Exception("Book Id doesn't match");
            }

            await _bookRepository.Update(book);
            return Ok("Updated Successfully");
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            //checking  duplicate records
            if (_bookRepository.duplicateCheck(book))
                throw new Exception("Duplicate Record");
            await _bookRepository.Create(book);
            return Ok(book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (id <= 0)
            {
                throw new KeyNotFoundException("Invalid BookId");
            }
            var book = await _bookRepository.Delete(id);
            if (book == null)
            {
                throw new FileNotFoundException("Book Details not found");
            }

            return Ok("Deleted Successfully");
        }


    }
}
