using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoApi.Models
{
    public class Developpeur: Employe
    {
        public string Post { get; set; }
        public string Langage { get; set; }
        public int Experience { get; set; }
    }
}
