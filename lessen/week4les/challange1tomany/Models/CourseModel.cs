using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace challange1tomany.Models
{
    public class CourseModel
    {
        [Key]
        public int CourseId { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        public string Code { get; set; }
        public ICollection<TestModel> Tests { get; set; }
    }
}
