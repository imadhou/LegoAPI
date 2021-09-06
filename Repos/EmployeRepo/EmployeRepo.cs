using LegoApi.Data;
using LegoApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Repos.EmployeRepo
{
    public class EmployeRepo : IEmployeRepo
    {
        private readonly LegoApiContext context;

        public EmployeRepo(LegoApiContext context)
        {
            this.context = context;
        }
        //Add new Employee
        public void AddEmploye(Employe entity)
        {
            context.Employes.Add(entity);
            context.SaveChanges();
        }

        //Delete an existing employee
        public void DeleteEntity(int id)
        {
            var empl = context.Employes.FirstOrDefault(e=>e.ID == id);
            context.Employes.Remove(empl);
        }

        //Get all employees including their service
        public IEnumerable<Employe> getEmployees()
        {
            return context.Employes.ToList();
        }

        //For updating entities
        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        //Add a holiday foran employee
        void IEmployeRepo.AddConge(EmployeConge conge)
        {
            context.EmployeConges.Add(conge);
        }

        //get an employee by his ID including his holidays and services
        Employe IEmployeRepo.GetById(int id)
        {
            return context.Employes.Include(e => e.EmployeConges).ThenInclude(c => c.Conge).Include(e => e.Service).FirstOrDefault(e => e.ID == id);
        }

        //Get all holidays for a specefic employee
        IEnumerable<EmployeConge> IEmployeRepo.getCongees(int id)
        {
            return context.EmployeConges.Where(e => e.EmployeId == id).ToList();
        }
    }
}
