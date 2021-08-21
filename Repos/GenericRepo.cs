using LegoApi.Data;
using LegoApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LegoApi.Repos
{
    // generic implementation of the interface: 
    // using the DbContext we provide an abstraction for accessing the db by the app
    public class GenericRepo<TEentity> : IGenericRepo<TEentity> where TEentity : class, IEntity
    {
        private readonly LegoApiContext context;

        public GenericRepo(LegoApiContext context)
        {
            this.context = context;
        }

        public async Task<TEentity> GetById(int id)
        {
            return await context.Set<TEentity>().AsNoTracking().FirstOrDefaultAsync(e=>e.ID == id);
        }

        public async Task<IEnumerable<TEentity>> GetMany()
        {
            return await context.Set<TEentity>().AsNoTracking().ToListAsync();
        }

        public async Task Add(TEentity entity)
        {

            await context.Set<TEentity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var entity = await GetById(id);
            context.Set<TEentity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(TEentity entity)
        {
            context.Set<TEentity>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
