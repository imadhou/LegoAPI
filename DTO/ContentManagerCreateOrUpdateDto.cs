using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class ContentManagerCreateOrUpdateDto
    {
        public string Nom { get; set; }
        public string email { get; set; }
        public int ServiceId { get; set; }
        public string Application { get; set; }
        public string Langue { get; set; }
        public int NbFollowers { get; set; }
    }
}
