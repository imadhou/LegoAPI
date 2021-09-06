using LegoApi.Data;
using LegoApi.DTO;
using LegoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Repos.CongeRepo
{
    public class CongeRepo : ICongeRepo
    {
        private readonly LegoApiContext context;

        public CongeRepo(LegoApiContext context)
        {
            this.context = context;
        }
        public void AddConge(Conge conge)
        {
            context.Conges.Add(conge);
            context.SaveChanges();
        }

        public IEnumerable<Conge> getAllConges()
        {
            return context.Conges.ToList();
        }
    }
}
