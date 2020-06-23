using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QT9_WebAPI.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class

    {
        IQueryable<TEntity> GetAll(TEntity entity);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Save();
    }
}
