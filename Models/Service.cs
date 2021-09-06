using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LegoApi.Models
{
    public class Service : IEntity
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(250)]
        public string Locale { get; set; }
        [JsonIgnore]
        public List<Employe> Employes { get; set; }
    }
}
