using System;
using System.Linq;
using Credit.Repositories.Models;

namespace Credit.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly CreditDefinitionsDemoContext _creditDefinitionsDemoContext;

        public Repository(CreditDefinitionsDemoContext creditDefinitionsDemoContext)
        {
            _creditDefinitionsDemoContext = creditDefinitionsDemoContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _creditDefinitionsDemoContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                _creditDefinitionsDemoContext.Add(entity);
                _creditDefinitionsDemoContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }
    }
}
