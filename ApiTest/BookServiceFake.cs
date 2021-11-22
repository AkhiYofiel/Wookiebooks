using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WookieBooks.Core.IRepository;
using WookieBooks.Models;

namespace booksApiTest
{
    public class BookServiceFake : IBookService
    {
        private readonly List<Book> _book;

        public BookServiceFake()
        {
            _book = new List<Book>()
            {
                new Book() { Id =1,
                    Title = "title1", Description="des1",Author="auth1",CoverImage="img1",Price = 500 },
                new Book() { Id = 2,
                    Title = "title2", Description="des2",CoverImage="auth2",Author="img2", Price = 400 },
                new Book() { Id = 3,
                    Title = "title3", Description="des3",CoverImage="auth3",Author="img3", Price = 1200 }
            };
        }
   
        public async Task<Book> Get(int id)
        {
            return _book.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Book> Create(Book entity)
        {
            entity.Id = 10; ;
            _book.Add(entity);
            return entity;
        }

        public async Task<Book> Update(Book entity)
        {

            entity.Id = 10; ;
            _book.Add(entity);
            return entity;
        }

        public async Task<Book> Delete(int id)
        {
            var existing = _book.First(a => a.Id == id);
            _book.Remove(existing);
            return existing;
        }

        public async Task<List<Book>> GetAll()
        {
            return _book.ToList();
        }

        public bool duplicateCheck(Book book)
        {
            return false;
        }
    }
}
