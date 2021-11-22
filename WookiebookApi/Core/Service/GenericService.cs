using Microsoft.EntityFrameworkCore;
using WookieBooks.Core.IRepository;
using WookieBooksApi.Data;

namespace WookieBooks.Core.Repository
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        
        protected ApplicationDbContext _context;
        protected DbSet<T> dbSet;
        public GenericService(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }
        public async Task<T> Create(T entity)
        {
            await dbSet.AddAsync(entity);
            _context.SaveChanges();
            return entity;

        }

        public async Task<T> Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            dbSet.Remove(entity);
            _context.SaveChanges();
             return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }   

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
