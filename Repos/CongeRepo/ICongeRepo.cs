using LegoApi.DTO;
using LegoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.Repos.CongeRepo
{
    public interface ICongeRepo
    {
        void AddConge(Conge conge);
        IEnumerable<Conge> getAllConges();
    }
}
