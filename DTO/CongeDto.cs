using LegoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class CongeDTO
    {
        public Raison Raison { get; set; }
        public bool EstPayee { get; set; }
    }

    public class CongeEmplDTO
    {
        public int Duree { get; set; }
        public DateTime DateDebut { get; set; }
        public CongeDTO CongeDTO { get; set; }
    }
}
