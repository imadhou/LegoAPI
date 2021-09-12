using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class DeveloperUpdate
    {
        [MaxLength(250)]
        public string Nom { get; set; }
        [EmailAddress(ErrorMessage = "Vueillez introduire une adresse mail valide")]
        [MaxLength(250)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Post { get; set; }
        [MaxLength(100)]
        public string Langage { get; set; }
        public int Experience { get; set; }
        public int ServiceID { get; set; }
    }
}
