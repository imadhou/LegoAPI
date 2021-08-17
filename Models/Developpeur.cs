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
        [Required]
        [MaxLength(100)]
        public string Post { get; set; }

        [Required]
        [MaxLength(100)]
        public string Langage { get; set; }

        [Required]
        public int Experience { get; set; }

    }
}
