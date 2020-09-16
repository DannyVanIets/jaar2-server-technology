using Server_wk4_les8_1_veel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server_wk4_les8_1_veel.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public Course Course { get; set; } // navigation property
    }
}
