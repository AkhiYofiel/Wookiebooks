using Microsoft.EntityFrameworkCore;

namespace WookieBooksApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WookieBooks.Models.Book> bookItem{ get; set; }
    }
}
