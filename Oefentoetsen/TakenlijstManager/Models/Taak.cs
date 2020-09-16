using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakenlijstManager.Models
{
    public class Taak
    {
        [Key]
        public int TaakId { get; set; }
        [Required, MinLength(3), MaxLength(40)]
        public string Naam { get; set; }
        public int Omvang { get; set; }
        [MinLength(0), MaxLength(10, ErrorMessage = "Minimaal 0, maximaal 10!")]
        public int Prioriteit { get; set; }

        public Status TaakStatus { get; set; }
        public int? StatusId { get; set; }
    }
}
