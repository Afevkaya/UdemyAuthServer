using System.Linq.Expressions;

namespace UdemyAuthServer.Core.Repositories
{
    // REPO LAR GERİYE ENTİTY CLASS DÖNERLER. ÇÜNKÜ DATAYI TÜKETECEK OLAN KATMAN SERVICE KATMANIDIR.
    // Service katmanı aldığı entity class'ı dto class'a çevirerek client tarafında döndürür. 

    // IGenericRepository interface
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
