using System.Linq.Expressions;

namespace MyResumeSite.DataLayer.Repositories
{
    public interface ICrudRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> Where = null);
        Task<TEntity> GetByID(object ID);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(object ID);
        Task<int> Count(Expression<Func<TEntity, bool>> Where = null);
    }
}
