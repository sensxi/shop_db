using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;


        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            this._dbSet = _context.Set<T>(); 
         }


        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity); 
            return true;
        }

        public async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }
    }
}
