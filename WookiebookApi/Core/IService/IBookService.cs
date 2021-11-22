using WookieBooks.Models;

namespace WookieBooks.Core.IRepository
{
    public interface IBookService :IGenericService<Book>
    {
        bool duplicateCheck(Book book);
    }
}
