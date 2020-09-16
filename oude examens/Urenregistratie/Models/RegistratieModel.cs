using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Urenregistratie.Models
{
    public class RegistratieModel
    {
        [Key]
        public int RegistratieId { get; set; }
        [Range(2000,9999)]
        public int Jaar { get; set; }
        [Range(1,53)]
        public int Week { get; set; }
        public int? Maandag { get; set; } = 0;
        public int? Dinsdag { get; set; } = 0;
        public int? Woensdag { get; set; } = 0;
        public int? Donderdag { get; set; } = 0;
        public int? Vrijdag { get; set; } = 0;
        public int? Zaterdag { get; set; } = 0;
        public int? Zondag { get; set; } = 0;

        public MedewerkerModel Medewerker  { get; set; }
        public int? MedewerkerId { get; set; }
    }
}
