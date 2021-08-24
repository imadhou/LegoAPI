using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LegoApi.Models
{
    public class EmployeConge : IEntity
    {
        public int ID { get; set; }
        public int Duree { get; set; }
        public DateTime DateDebut { get; set; }
        public int EmployeId { get; set; }
        [JsonIgnore]
        public Employe Employe { get; set; }
        public int CongeID { get; set; }
        public Conge Conge { get; set; }
    }
}
