using LegoApi.Data;
using LegoApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Repos.ServiceRepo
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly LegoApiContext context;

        public ServiceRepo(LegoApiContext context)
        {
            this.context = context;
        }
        public void AddService(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
        }

        public IEnumerable<Service> GetAllServices()
        {
            return context.Services.ToList();
        }

        public Service GetServiceByID(int id)
        {
            return context.Services.Find(id);
        }


    }
}
