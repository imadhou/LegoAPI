using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LegoApi.Models
{
    public enum Raison
    {
        Maladie, Vacances, Maternite, Autres
    }
    public class Conge: IEntity
    {
        public int ID { get; set; }
        [Required]
       
        public Raison Raison { get; set; }
        [Required]
        public bool EstPayee { get; set; }
        [JsonIgnore]
        public List<EmployeConge> EmployeConges { get; set; }
    }
}
