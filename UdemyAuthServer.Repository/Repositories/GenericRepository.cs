using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyAuthServer.Core.Repositories;

namespace UdemyAuthServer.Repository.Repositories
{
    // Core katmanında yazılan IGenericRepository interface'ini implement eden class.
    // Bu katmanda yapılan işlemler database yansıması gerekli.
    // Bu yüzden database ile iletişime geçen context classını kullanmamız gerekli.

    // Generic GenericRepository class
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
       
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            // Efcore entity'mizi takip etmemesi için yazdığımız kod bloğu
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            // _dbSet.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
