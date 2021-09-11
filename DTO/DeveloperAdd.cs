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


        [Required(ErrorMessage ="L'adresse mail est requise")]
        [EmailAddress(ErrorMessage ="Vueillez introduire une adresse mail valide")]
        [MaxLength(250)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Le post que le dev ocuppe est requis")]
        [MaxLength(100)]
        public string Post { get; set; }


        [Required(ErrorMessage = "Le langage est requis")]
        [MaxLength(100)]
        public string Langage { get; set; }


        [Required(ErrorMessage = "Le nombre d'annés d'exp est requis")]
        public int Experience { get; set; }


        [Required(ErrorMessage ="le service est requis")]
        public int ServiceID { get; set; }
    }
}
