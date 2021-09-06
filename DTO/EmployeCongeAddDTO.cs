using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class EmployeCongeAddDTO
    {
        [Required]
        public int Duree { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }
        [Required]
        public int CongeID { get; set; }
    }
}
