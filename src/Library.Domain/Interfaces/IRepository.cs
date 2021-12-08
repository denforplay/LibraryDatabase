namespace Library.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task<T> Read(int id);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
