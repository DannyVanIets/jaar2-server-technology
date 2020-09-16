using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterReservering.Models
{
    public class ReserveringModel
    {
        [Key]
        public int ReserveringId { get; set; }
        [Required]
        public string Naam { get; set; }
        public int? KlantId { get; set; }
        public KlantModel Klant { get; set; }
        public bool bezet { get; set; }
    }
}
