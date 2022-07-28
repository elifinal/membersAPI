using MembersDataAccess.Abstract;
using MembersDataAccess.Data;
using System.Linq.Expressions;

namespace MembersDataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context=context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(_context.Set<T>().Where(expression));

        }
    

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(_context.Set<T>().ToList());
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            await Task.FromResult(_context.Set<T>().Remove(entity));
            await SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var data = await GetByIdAsync(id);
            if (data ==null)
                throw new ArgumentNullException("Data bulunamadı");

            await Task.FromResult(_context.Set<T>().Remove(data));
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var updateRresult = _context.Set<T>().Update(entity);
            await Task.FromResult(updateRresult.Entity);

            await SaveChangesAsync();
        }

        private Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
