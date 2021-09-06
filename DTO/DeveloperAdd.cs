using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class DeveloperAdd
    {
        [Required(ErrorMessage = "Le nom est requis pour ajouter un employer")]
        [MaxLength(250)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Post { get; set; }

        [Required]
        [MaxLength(100)]
        public string Langage { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public int ServiceID { get; set; }
    }
}
