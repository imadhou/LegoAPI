using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LegoApi.Models
{
    public class Employe : IEntity
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [MaxLength(250)]
        public string Nom { get; set; }


        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public List<EmployeConge> EmployeConges { get; set; }
    }
}
