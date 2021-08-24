using LegoApi.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LegoApi.Repos
{
    // specifying some crud functions that will be implemented for our api
    public interface IGenericRepo2<TEntity> where TEntity: class, IEntity
    {
        void Add(TEntity entity);
        TEntity GetByID(int id);

        //Performing an advanced querying by providig lambda functions for each type
        TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true
            );
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetMuliple(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        bool disableTracking = true
            );
        void Update(TEntity entity);
        void Delete(int id);
       
    }
}
