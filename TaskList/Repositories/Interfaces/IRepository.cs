using TaskList.Models;

namespace TaskList.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T?> UpdateAsync(int id, T entity);
        Task<T?> UpdateConcluirAsync(int id);
        Task<T?> DeleteAsync(int id);
    }

    //public interface  IRepositoryWrite<T> where T : class
    //{
    //    Task<T> CreateAsync(T entity);
    //}
}
