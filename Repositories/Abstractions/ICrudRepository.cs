using RentalAppMVC.Data;
using System.Linq.Expressions;

namespace RentalAppMVC.Repositories.Abstractions
{
    public interface ICrudRepository<T>
       where T : BaseEntity
    {
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate);
    }
}
