namespace EksiSozluk.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
