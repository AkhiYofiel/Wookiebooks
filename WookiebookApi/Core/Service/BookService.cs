using WookieBooks.Core.IRepository;
using WookieBooks.Models;
using WookieBooksApi.Data;

namespace WookieBooks.Core.Repository
{
    public class BookService : GenericService<Book>, IBookService
    {
        public BookService(ApplicationDbContext context) : base(context)
        {
            if(context.bookItem.Count()<1)
            {
                AddDefaultValues(context);
            }
        }

        private void AddDefaultValues(ApplicationDbContext context)
        {
            context.bookItem.AddRange(
                new Book
                {
                    Title = "Elon Musk",
                    Description = "Life lessons with successful entrepreneur",
                    Author = "Olivia",
                    CoverImage = "https://Elon.jpg",
                    Price = 18.19
                },
                new Book
                {
                    Title = " In Search of Lost Time",
                    Description = "In Search of Lost Time",
                    Author = "Marcel Proust",
                    CoverImage = "https://time.jpg",
                    Price = 60
                }

                );
            context.SaveChanges();
        }

        public bool duplicateCheck(Book book)
        {
            bool isDuplicate = false;
            if (_context.bookItem.Count() > 0)
            {
                isDuplicate= _context.bookItem.Any(cus => cus.Author == book.Author && cus.Title== book.Title);
            }
            return isDuplicate; 
        }

        
    }
}
