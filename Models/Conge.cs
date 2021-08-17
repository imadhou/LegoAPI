using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoApi.Models
{
    public enum Raison
    {
        Maladie, Vacances, Maternite, Autres
    }
    public class Conge
    {
        public int ID { get; set; }
        [Required]
        public Raison Raison { get; set; }
        [Required]
        public bool EstPayee { get; set; }
        public List<EmployeConge> EmployeConges { get; set; }
    }
}
