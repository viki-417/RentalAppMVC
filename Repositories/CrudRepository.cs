using Microsoft.EntityFrameworkCore;
using RentalAppMVC.Data;
using RentalAppMVC.Repositories.Abstractions;
using System.Linq.Expressions;

namespace RentalAppMVC.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T>
       where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public CrudRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
