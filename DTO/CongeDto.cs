using LegoApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoApi.DTO
{
    public class CongeDTO
    {
        [Required]
        public Raison Raison { get; set; }
        [Required]
        public bool EstPayee { get; set; }
    }
}
