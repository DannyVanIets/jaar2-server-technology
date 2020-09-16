using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Urenregistratie.Models
{
    public class MedewerkerModel
    {
        [Key]
        public int MedewerkerId { get; set; }
        [Required, MinLength(2)]
        public string Voornaam { get; set; }
        [Required, MinLength(2)]
        public string Achternaam { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefoonnummer { get; set; }

        public ICollection<RegistratieModel> Registraties { get; set; }
    }
}
