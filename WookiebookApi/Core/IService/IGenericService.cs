namespace WookieBooks.Core.IRepository
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);

    }
}
