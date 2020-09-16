using Server_wk4_les8_1_veel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_wk4_les8_1_veel.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<Test> Tests { get; set; } // navigation Property
    }
}
