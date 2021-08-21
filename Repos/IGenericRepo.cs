using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegoApi.Models;

namespace LegoApi.Repos
{
    // an interface that exposes the repository functions 
    public interface IGenericRepo<TEntity> where TEntity: class, IEntity
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetMany();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(int id);

    }
}
