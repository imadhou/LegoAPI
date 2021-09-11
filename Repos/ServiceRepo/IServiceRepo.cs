using LegoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Repos.ServiceRepo
{
    public interface IServiceRepo
    {
        void AddService(Service service);
        IEnumerable<Service> GetAllServices();
        Service GetServiceByID(int id);
    }
}
