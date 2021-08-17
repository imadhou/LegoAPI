using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoApi.Models
{
    public class ContentManager: Employe
    {
        [MaxLength(100)]
        [Required]
        public string Application { get; set; }
        [MaxLength(100)]
        [Required]
        public string Langue { get; set; }
        public int NbFollowers { get; set; }
    }
}
