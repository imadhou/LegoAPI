using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoApi.Models
{
    public class Employe
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(250)]
        public string email { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
        
        public List<EmployeConge> EmployeConges { get; set; }
    }
}
