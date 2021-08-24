using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class DevCr
    {
        [Required]
        [MaxLength(250)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(250)]
        public string email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Post { get; set; }

        [Required]
        [MaxLength(100)]
        public string Langage { get; set; }

        public int Experience { get; set; }
        public int ServiceID { get; set; }
    }
}
