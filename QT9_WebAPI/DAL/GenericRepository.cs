using Microsoft.EntityFrameworkCore;
using QT9_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QT9_WebAPI.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>, IDisposable
         where TEntity : class

    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll(TEntity entity)
        {
            return _context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            _context.Add(entity);
        }
        public int AddRange(IEnumerable<TEntity> entities)

        {
            int result = -1;

            if (entities.Any())
            {
                _context.AddRange(entities);
                result = entities.Count();
            }
            return result;
        }
        public bool Update(TEntity entity)
        {
            bool result = false;

            if (entity != null)
            {
                _context.Update(entity);
                result = true;
            }
            return result;
        }
        public virtual void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
