using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace challange1tomany.Models
{
    public class TestModel
    {
        [Key]
        public int TestId { get; set; }
        public string Name { get; set; }
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public CourseModel Course { get; set; }
    }
}
