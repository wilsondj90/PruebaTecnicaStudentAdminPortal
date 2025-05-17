using System.Linq.Expressions;

namespace StudentAdminPortal.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        bool Any(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();

        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    }
}
