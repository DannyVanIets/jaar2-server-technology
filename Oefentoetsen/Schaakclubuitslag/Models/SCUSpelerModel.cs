using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Schaakclubuitslag.Models
{
    public enum Dagen { Vrijdag, Zaterdag, Zondag };

    public class SCUSpelerModel
    {
        [Key]
        public int SCUSpelerId { get; set; }
        [Required(ErrorMessage = "Je moet een naam invullen!"), MinLength(2)]
        public string Naam { get; set; }
        public ICollection<PartijModel> Partijen { get; set; } // navigation Property
    }
}
