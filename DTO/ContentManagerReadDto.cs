using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class ContentManagerReadDto
    {
        public string Nom { get; set; }
        public string email { get; set; }
        public int ServiceId { get; set; }
        public string Application { get; set; }
        public string Langue { get; set; }
        public int NbFollowers { get; set; }
        public List<EmployeCongeDto> Conges;
        
    }

    public class EmployeCongeDto
    {
        public Raison Raison { get; set; }
        public bool EstPayee { get; set; }
        public int Duree { get; set; }
        public DateTime DateDebut { get; set; }

    }

    public enum Raison
    {
        Maladie, Vacances, Maternite, Autres
    }
}
