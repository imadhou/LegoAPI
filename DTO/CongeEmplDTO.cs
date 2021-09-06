using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class CongeEmplDTO
    {
        public int Duree { get; set; }
        public DateTime DateDebut { get; set; }
        public CongeDTO CongeDTO { get; set; }
    }
}
