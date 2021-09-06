using LegoApi.Data;
using LegoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Repos.EmployeCongeRepo
{
    public class EmployeCongeRepo : IEmployeCongeRepo

    {
        private readonly LegoApiContext context;

        public EmployeCongeRepo(LegoApiContext context)
        {
            this.context = context;
        }
        public void AddCongeEmploye(EmployeConge conge)
        {
            context.EmployeConges.Add(conge);
            context.SaveChanges();
        }

        public IEnumerable<EmployeConge> getEmployeCongees(int id)
        {
            return context.EmployeConges.Where(e => e.EmployeId == id).ToList();
        }
    }
}
