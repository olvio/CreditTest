using System.Linq;

namespace Credit.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        TEntity Add(TEntity entity);
    }
}
