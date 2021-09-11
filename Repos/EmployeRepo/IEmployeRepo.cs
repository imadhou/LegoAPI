using LegoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
namespace LegoApi.Repos.EmployeRepo
{
    public interface IEmployeRepo
    {
        IEnumerable<Employe> getEmployees();
        Employe GetById(int id);
        Employe GetByEmail(string email);
        void AddEmploye(Employe entity);
        void DeleteEntity(int id);
        Task<bool> SaveAsync();
        void AddConge(EmployeConge conge);
        IEnumerable<EmployeConge> getCongees(int id);
        int TotalConges(int id, int annee);

    }
}
