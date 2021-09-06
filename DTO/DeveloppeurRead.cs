using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class DeveloppeurRead
    {
 
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Post { get; set; }
        public string Langage { get; set; }
        public int Experience { get; set; }
        public int ServiceID { get; set; }
        public ICollection<CongeEmplDTO> Conges { get; set; }
    }
}
