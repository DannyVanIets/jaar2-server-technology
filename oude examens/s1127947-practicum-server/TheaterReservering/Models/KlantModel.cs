using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterReservering.Models
{
    public class KlantModel
    {
        [Key]
        public int KlantId { get; set; }
        [Required, MinLength(2)]
        public string Naam { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Woonplaats { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [NotMapped]
        public int Prijs { get; set; }
        public ICollection<ReserveringModel>? Reservingen { get; set; } // navigation Property
    }
}
