using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakenlijstManager.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string Naam { get; set; }
        [Required(AllowEmptyStrings = true)]
        public int VolgendeStatus { get; set; }
    }
}
