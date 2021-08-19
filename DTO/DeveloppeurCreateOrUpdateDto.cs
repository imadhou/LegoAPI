using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class DeveloppeurCreateOrUpdateDto
    {
        public string Nom { get; set; }
        public string email { get; set; }
        public int ServiceId { get; set; }
        public string Post { get; set; }
        public string Langage { get; set; }
        public int Experience { get; set; }
    }
}
