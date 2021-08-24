using LegoApi.Data;
using LegoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LegoApi.Repos
{
    public class GenericRepo2<TEntity> : IGenericRepo2<TEntity> where TEntity : class, IEntity
    {

        private readonly LegoApiContext context;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepo2(LegoApiContext context)
        {
            this.context = context;
            this._dbSet = context.Set<TEntity>();
        }
        public virtual void Add(TEntity entity)
        {
            var entry = _dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        public virtual  IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual TEntity GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include,
            bool disableTracking)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }

        public virtual IEnumerable<TEntity> GetMuliple(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include,
            bool disableTracking)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
