using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterReservering.Models
{
    public class KlantEnReserveringen
    {
        public KlantModel Klant { get; set; }
        public List<ReserveringModel> ReserveringenA { get; set; }
        public List<ReserveringModel> ReserveringenB { get; set; }
        public List<ReserveringModel> ReserveringenC { get; set; }
        public List<ReserveringModel> ReserveringenD { get; set; }
        public List<ReserveringModel> ReserveringenE { get; set; }
    }
}
