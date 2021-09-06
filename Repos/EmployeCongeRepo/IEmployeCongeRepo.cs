using LegoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Repos.EmployeCongeRepo
{
    public interface IEmployeCongeRepo
    {
        void AddCongeEmploye(EmployeConge conge);
        IEnumerable<EmployeConge> getEmployeCongees(int id);
    }
}
