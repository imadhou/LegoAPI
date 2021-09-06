using LegoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LegoApi.Repos.EmployeRepo
{
    public interface IEmployeRepo
    {
        IEnumerable<Employe> getEmployees();
        Employe GetById(int id);
        void AddEmploye(Employe entity);
        void DeleteEntity(int id);
        Task<bool> SaveAsync();


        void AddConge(EmployeConge conge);
        IEnumerable<EmployeConge> getCongees(int id);

    }
}
