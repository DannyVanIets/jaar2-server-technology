using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Schaakclubuitslag.Models.SCUSpelerModel;

namespace Schaakclubuitslag.Models
{
    public class PartijModel
    {
        public enum Uitslagen { verloren, remise, gewonnen }

        [Key]
        public int PartijId { get; set; }
        [EnumDataType(typeof(Dagen))]
        public Dagen Dag { get; set; }
        [EnumDataType(typeof(Uitslagen))]
        public Uitslagen Uitslag { get; set; }
        [ForeignKey("SCUSpelerId")]
        public int SCUSpelerId { get; set; }
        public SCUSpelerModel SCUSpeler { get; set; } //Navigation property
    }
}
